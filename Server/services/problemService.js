const logger = require('../utils/logger');
const models = require('../models');
const { Op } = require('sequelize');

exports.readProblems = async() => {
    try {
        return await models.problem.findAll({
            attributes: ['id', 'name', 'input', 'output', 'description', 'createdAt'],
            raw: true
        });
    } catch (err) {
        throw err;
    }
};

//id
exports.readProblemDetail = async data => {
    try {
        return await models.problem.findOne({
            where: data
        });;
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