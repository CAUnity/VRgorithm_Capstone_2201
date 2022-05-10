const { statusCode, responseMessage } = require('../globals');
const { resFormatter } = require('../utils');
const logger = require('../utils/logger');
const errors = require('../utils/errors/commonError');
const problemService = require('../services/problemService')

// 상세 페이지 API
module.exports.getProblems = async(req, res, next) => {
    try {
        const records = await problemService.readProblems();

        return res
            .status(statusCode.OK)
            .send(resFormatter.success(responseMessage.READ_SUCCESS, records));
    } catch (err) {
        next(err);
    }
};


// 리스트 페이지 API
module.exports.postProblem = async(req, res, next) => {
    try {
        const { name, input, output, description, teacherId } = req.body;

        const dao = {
            name,
            input,
            output,
            description,
            teacherId
        }
        const result = await problemService.createProblem(dao);

        return res
            .status(statusCode.OK)
            .send(resFormatter.success(responseMessage.LIST_SUCCESS, result));
    } catch (err) {
        next(err);
    }
};

// 리스트 페이지 API
module.exports.getProblemDetail = async(req, res, next) => {
    try {
        const { id } = req.params;

        const record = await problemService.readProblemDetail({ id });
        if (!record) {
            throw new errors.EntityNotExistError()
        }
        return res
            .status(statusCode.OK)
            .send(resFormatter.success(responseMessage.LIST_SUCCESS, record));
    } catch (err) {
        next(err);
    }
};

// 리스트 페이지 API
module.exports.makeProblem = async(req, res, next) => {
    try {
        res.render("makeProb.html");
    } catch (err) {
        next(err);
    }
};

module.exports.viewProblems = async(req, res, next) => {
    try {
        res.render("listProb.html");
    } catch (err) {
        next(err);
    }
};