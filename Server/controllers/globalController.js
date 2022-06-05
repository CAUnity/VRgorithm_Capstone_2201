const { statusCode, responseMessage } = require('../globals');
const { resFormatter } = require('../utils');
const logger = require('../utils/logger');
const errors = require('../utils/errors/commonError');
const resultService = require('../services/teacherService')

// 상세 페이지 API
module.exports.viewIndex = async(req, res, next) => {
    try {
        res.render("main.html");
    } catch (err) {
        throw err;
    }
};