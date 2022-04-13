const express = require('express');
const routes = require('../globals/routes.js');
const problemContoller = require('../controllers/problemController')

const problemRouter = express.Router();

problemRouter.get(routes.ROOT, problemContoller.getProblems);

problemRouter.post(routes.ROOT, problemContoller.postProblem);

problemRouter.get(routes.ID, problemContoller.getProblemDetail);



module.exports = problemRouter;