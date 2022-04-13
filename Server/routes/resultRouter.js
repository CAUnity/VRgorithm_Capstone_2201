const express = require('express');
const routes = require('../globals/routes.js');
const resultController = require("../controllers/resultController")

const resultRouter = express.Router();

resultRouter.get(routes.ROOT, resultController.getResults);


module.exports = resultRouter;