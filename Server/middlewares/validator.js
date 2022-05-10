const { validationResult } = require("express-validator");
const error = require("../utils/errors/commonError");

exports.validErrorChecker = (req, res, next) => {
    const errors = validationResult(req);
    if (!errors.isEmpty()) {
        throw new error.ValidationError()
    }
    next();
}