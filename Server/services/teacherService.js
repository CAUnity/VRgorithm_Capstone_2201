const logger = require('../utils/logger');
const models = require('../models');
const { Op } = require('sequelize');

//id
exports.findById = async data => {
    try {
        return await models.teacher.findOne({
            where: data
        });
    } catch (err) {
        throw err;
    }
};

//id, password, salt, name
exports.createTeacher = async data => {
    try {
        logger.log(data)
        return await models.teacher.create(data);;
    } catch (err) {
        throw err;
    }
};