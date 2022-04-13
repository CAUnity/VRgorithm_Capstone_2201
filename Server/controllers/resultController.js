const { statusCode, responseMessage } = require('../globals');
const { resFormatter } = require('../utils');
const logger = require('../utils/logger');
const errors = require('../utils/errors/commonError');
const resultService = require('../services/resultService')

// 상세 페이지 API
module.exports.getResults = async(req, res, next) => {
    try {
        const records = await resultService.readResults();

        return res
            .status(statusCode.OK)
            .send(resFormatter.success(responseMessage.READ_SUCCESS, records));
    } catch (err) {
        next(err);
    }
};

module.exports.postResult = async(req, res, next) => {
    try {
        const { studentId, isCorrect, problemId } = req.body;

        const dao = {
            studentId,
            isCorrect,
            problemId
        }
        const result = await resultService.createResult(dao)

        return res
            .status(statusCode.OK)
            .send(resFormatter.success(responseMessage.READ_SUCCESS, result));
    } catch (err) {
        next(err);
    }
};