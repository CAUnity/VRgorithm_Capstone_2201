const { statusCode, responseMessage } = require('../globals');
const { resFormatter } = require('../utils');
const trialService = require('../services/trialService.js');
const logger = require('../utils/logger');
const day = require('../utils/day');
const {
  ValidationError,
  EntityNotExistError,
} = require('../utils/errors/commonError');

// 상세 페이지 API
module.exports.getTrialDetail = async (req, res, next) => {
  try {
    const { trialId } = req.params;

    if (trialId === undefined) throw new ValidationError();

    const trial = await trialService.readTrial(trialId);
    
    if (!trial) throw new EntityNotExistError();

    return res
      .status(statusCode.OK)
      .send(resFormatter.success(responseMessage.READ_SUCCESS, trial));
  } catch (err) {
    next(err);
  }
};

// 리스트 페이지 API
module.exports.getTrials = async (req, res, next) => {
  try {
    const { page = 1, limit = 10 } = req.query;
    
    if (page <= 0)
      throw new ValidationError();
    
    const beforeOneWeek = day.beforeOneWeek();
    
    const data = {
      page: Number(page) - 1,
      limit: Number(limit),
      beforeOneWeek
    };
    const trials = await trialService.readTrialList(data);

    return res
      .status(statusCode.OK)
      .send(resFormatter.success(responseMessage.LIST_SUCCESS, trials));
  } catch (err) {
    next(err);
  }
};

// 검색 API
module.exports.searchTrials = async (req, res, next) => {
  try {
    const { name, type, department, page = 1, limit = 10 } = req.query;

    if (
      name === undefined &&
      type === undefined &&
      department === undefined &&
      page <= 0
    )
      throw new ValidationError();

    const data = {
      name,
      type,
      department,
      page: Number(page) - 1,
      limit: Number(limit),
    };

    const trials = await trialService.searchTrials(data);

    return res
      .status(statusCode.OK)
      .send(resFormatter.success(responseMessage.SEARCH_SUCCESS, trials));
  } catch (err) {
    next(err);
  }
};
