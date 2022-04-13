const logger = require('../utils/logger');
const models = require('../models');
const { Op } = require('sequelize');

exports.readResults = async() => {
    try {
        return await models.result.findAll();;
    } catch (err) {
        throw err;
    }
};

//studentId, isCorrect, problemId
exports.createResult = async() => {
    try {
        return await models.result.create(data);;
    } catch (err) {
        throw err;
    }
};