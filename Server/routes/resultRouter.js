const express = require('express');
const routes = require('../globals/routes.js');
const resultController = require("../controllers/resultController")

const { body } = require('express-validator');
const { validErrorChecker } = require('../middlewares/validator.js');

const resultRouter = express.Router();

resultRouter.get(routes.ROOT, resultController.getResults);

const resultInfoValid = [
    body("studentId").notEmpty(),
    body("isCorrect").notEmpty(),
    body("problemId").notEmpty(),
]
resultRouter.post(routes.ROOT, resultInfoValid, validErrorChecker, resultController.postResult);


module.exports = resultRouter;