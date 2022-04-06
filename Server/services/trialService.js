const models = require('../models');
const { InternalServerError } = require('http-errors');
const {
  EntityNotExistError,
  ValidationError,
} = require('../utils/errors/commonError');
const logger = require('../utils/logger');
const trial = require('../models/trial');
const sequelize = require('sequelize');
const { Op } = require('sequelize');

/**
 * 상세조회
 * data.trialId
 */
exports.readTrial = async trialId => {
  try {
    const trial = await models.trial.findOne({
      where: {
        id: trialId,
      },
    });
    return trial;
  } catch (err) {
    throw err;
  }
};

/**
 * 목록조회
 * data.page
 * data.limit
 */
exports.readTrialList = async data => {
  try {
    const trials = await models.trial.findAll({
      offset: data.page * data.limit,
      limit: data.limit,
      order: [['createdAt', 'DESC']],
      where: {
          updatedAt: {[Op.gte]: data.beforeOneWeek}
      }
    });
    return trials;
  } catch (err) {
    throw err;
  }
};

/**
 * 검색
 * data.name
 * data.type
 * data.page
 * data.limit
 * data.deparment
 */
exports.searchTrials = async data => {
  try {
    let query = {
      name: {
        [Op.like]: `%${data.name}%`,
      },
      type: {
        [Op.like]: `%${data.type}%`,
      },
      department: {
        [Op.like]: `%${data.department}%`,
      },
    };

    for (let value in query) {
      if (!data[value]) delete query[value];
    }

    const searchTrials = await models.trial.findAll({
      where: {
        [Op.and]: query,
      },
      offset: data.page,
      limit: data.limit
    });
    return searchTrials;
  } catch (err) {
    throw err;
  }
};

/**
 * 생성 혹은 변경
 * data = [{
 *          '과제명': 'Lymphoma Study for Auto-PBSCT',
 *          '과제번호': 'C100002',
 *          '연구기간': '1년',
 *          '연구범위': '단일기관',
 *          '연구종류': '관찰연구',
 *          '연구책임기관': '가톨릭대 서울성모병원',
 *          '임상시험단계(연구모형)': '코호트',
 *          '전체목표연구대상자수': '',
 *          '진료과': 'Hematology',
 *           hash: '3449c9e5e332f1dbb81505cd739fbf3f'
 *        },
 *        ...,
 *        ]
 */
exports.createOrUpdateTrials = async data => {
  try {
    let newTrials = [];

    for (let i = 0; i < data.length; i++) {
      let trial = data[i];

      const dbRawData = {
        id: trial['과제번호'],
        name: trial['과제명'],
        term: trial['연구기간'],
        domain: trial['연구범위'],
        type: trial['연구종류'],
        host: trial['연구책임기관'],
        model: trial['임상시험단계(연구모형)'],
        subjectCount: trial['전체목표연구대상자수'],
        department: trial['진료과'],
        hash: trial['hash'],
      };

      //존재유무 확인
      const alreadyTrial = await models.trial.findByPk(trial['과제번호']);

      if (!alreadyTrial) {
        newTrials.push(dbRawData);
      }
      //해쉬가 다르면 업데이트
      else if (alreadyTrial.hash !== trial.hash) {
        await models.trial.update(dbRawData, {
          where: {
            id: trial['과제번호'],
          },
        });
      }
    }

    logger.log('db updated');
    await models.trial.bulkCreate(newTrials);
    return;
  } catch (err) {
    throw err;
  }
};
