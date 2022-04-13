const express = require('express');
const routes = require('../globals/routes.js');
const problemContoller = require('../controllers/problemController');
const { body } = require('express-validator');
const { validErrorChecker } = require('../middlewares/validator.js');
const problemRouter = express.Router();

const problemInfoValid = [
    body("name").notEmpty(),
    body("input").notEmpty(),
    body("output").notEmpty(),
    body("description").notEmpty(),
    body("teacherId").notEmpty(),
]
problemRouter.get(routes.ROOT, problemContoller.getProblems);

problemRouter.post(routes.ROOT, problemInfoValid, validErrorChecker, problemContoller.postProblem);

problemRouter.get(routes.ID, body("id").isNumeric(), validErrorChecker, problemContoller.getProblemDetail);



module.exports = problemRouter;