const express = require('express');
const routes = require('../globals/routes.js');
const globalController = require('../controllers/globalController');
const teacherController = require('../controllers/teacherController');
const { checkLogin } = require('../middlewares/auth.js');

const globalRouter = express.Router();

globalRouter.get(routes.ROOT, checkLogin, globalController.viewIndex);

globalRouter.get(routes.LOGIN, teacherController.getLogin);

globalRouter.post(routes.LOGIN, teacherController.postLogin);

globalRouter.get(routes.LOGOUT, teacherController.getLogout);

module.exports = globalRouter;