const express = require('express');
const routes = require('../globals/routes.js');
const problemContoller = require('../controllers/problemController');
const { body, param } = require('express-validator');
const { validErrorChecker } = require('../middlewares/validator.js');
const { checkLogin } = require('../middlewares/auth.js');
const problemRouter = express.Router();

const problemInfoValid = [
    body("name").notEmpty(),
    body("input").notEmpty(),
    body("output").notEmpty(),
    body("description").notEmpty(),
    body("teacherId").notEmpty(),
]
problemRouter.get(routes.ROOT, checkLogin, problemContoller.getProblems);

problemRouter.post(routes.ROOT, problemInfoValid, validErrorChecker, problemContoller.postProblem);

problemRouter.get(routes.VIEW, checkLogin, problemContoller.viewProblems);

problemRouter.get(routes.MAKE, checkLogin, problemContoller.makeProblem);

problemRouter.get(routes.ID, param("id").isNumeric(), validErrorChecker, problemContoller.getProblemDetail);



module.exports = problemRouter;