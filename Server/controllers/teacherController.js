const { statusCode, responseMessage } = require('../globals');
const { resFormatter } = require('../utils');
const logger = require('../utils/logger');
const errors = require('../utils/errors/commonError');
const { validationResult } = require('express-validator')
const crypto = require('crypto');
const teacherService = require("../services/teacherService")
const jwt = require('../utils/jwt');
const { setFlagsFromString } = require('v8');

module.exports.postRegister = async(req, res, next) => {
    try {
        const { id, name, password } = req.body;

        salt = crypto.randomBytes(128).toString('base64');
        hashPwd = crypto.createHash('sha512').update(password + salt).digest('hex');
        const result = await teacherService.createTeacher({
            id,
            name: name,
            password: hashPwd,
            salt
        });

        return res
            .status(statusCode.OK)
            .send(resFormatter.success(responseMessage.READ_SUCCESS, result));
    } catch (err) {
        throw err;
    }
};

module.exports.postToken = async(req, res, next) => {
    try {
        const { id, password } = req.body;


        const record = await teacherService.findById({ id })
        if (!record)
            throw new errors.EntityNotExistError()
        hashPwd = crypto.createHash('sha512').update(password + record.salt).digest('hex');
        if (record.password != hashPwd)
            throw new errors.UnAuthorizedError()

        const token = await jwt.sign({ teacherId: id })

        //res.cookie('teacher', token, { httpOnly: false, maxAge: 1 * 60 * 60 * 1000 })
        req.session.token = token;
        return res
            .status(statusCode.OK)
            .send(resFormatter.success(responseMessage.LIST_SUCCESS, token));
    } catch (err) {
        throw err;
    }
};

module.exports.postLogin = async(req, res, next) => {
    try {
        if (req.session.user) {
            return res.render("main.html")
        } else {
            const { id, password } = req.body;


            const record = await teacherService.findById({ id })
            if (!record)
                res.render("login.html");
            hashPwd = crypto.createHash('sha512').update(password + record.salt).digest('hex');
            if (record.password != hashPwd)
                res.render("login.html");

            req.session.user = {
                id: record.id,
                name: record.name,
            };
            return res.redirect("/");
        }
    } catch (err) {
        throw err;
    }
}

module.exports.getLogin = async(req, res, next) => {
    try {
        if (req.session.user) {
            return res.render("main.html")
        } else {
            res.render("login.html");
        }
    } catch (err) {
        throw err;
    }
};

module.exports.getLogout = async(req, res, next) => {
    try {
        if (req.session.user) {
            req.session.destroy(
                function(err) {
                    if (err) {
                        throw err;
                    }
                }
            )
        }
        res.redirect('/login');
    } catch (err) {
        throw err;
    }
};