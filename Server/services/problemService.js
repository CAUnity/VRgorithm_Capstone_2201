const logger = require('../utils/logger');
const models = require('../models');
const { Op } = require('sequelize');

exports.readProblems = async() => {
    try {
        return await models.problem.findAll();
    } catch (err) {
        throw err;
    }
};

//id
exports.readProblemDetail = async data => {
    try {
        logger.log("hihi " + data)
        return await models.problem.findOne(data);;
    } catch (err) {
        throw err;
    }
};

//name,input,output, description, teacherId
exports.createProblem = async data => {
    try {
        return await models.problem.create(data);;
    } catch (err) {
        throw err;
    }
};