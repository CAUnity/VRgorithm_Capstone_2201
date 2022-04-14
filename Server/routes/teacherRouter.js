const express = require('express');
const routes = require('../globals/routes.js');
const teacherController = require("../controllers/teacherController")

const teacherRouter = express.Router();
const { body } = require('express-validator');
const { validErrorChecker } = require('../middlewares/validator.js');

const teacherInfoValid = [
    body("id").notEmpty(),
    body("password").notEmpty()
];
const teacherRegiValid = teacherInfoValid.concat([
    body("name").notEmpty()
]);
teacherRouter.post(routes.ROOT, teacherRegiValid, validErrorChecker, teacherController.postRegister);

teacherRouter.get(routes.TOKEN, teacherInfoValid, validErrorChecker, teacherController.postToken);



module.exports = teacherRouter;