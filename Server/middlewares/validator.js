const { validationResult } = require("express-validator");

exports.validErrorChecker = (req, res, next) => {
    const errors = validationResult(req);
    if (!errors.isEmpty()) {
        throw new ValidationError()
    }
    next();
}