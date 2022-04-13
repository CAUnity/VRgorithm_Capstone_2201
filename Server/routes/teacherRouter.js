const express = require('express');
const routes = require('../globals/routes.js');
const teacherController = require("../controllers/teacherController")

const teacherRouter = express.Router();
const { body } = require('express-validator');
const { validErrorChecker } = require('../middlewares/validator.js');

const teacherInfoValid = [
    body("id").notEmpty(),
    body("password").notEmpty()
]
teacherRouter.post(routes.ROOT, teacherInfoValid, validErrorChecker, teacherController.postRegister);

teacherRouter.post(routes.TOKEN, teacherInfoValid, validErrorChecker, teacherController.postToken);



module.exports = teacherRouter;