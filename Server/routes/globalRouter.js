const express = require('express');
const routes = require('../globals/routes.js');

const globalRouter = express.Router();

globalRouter.get(routes.ROOT, function(req, res, next) {
    res.render("index");
});

module.exports = globalRouter;