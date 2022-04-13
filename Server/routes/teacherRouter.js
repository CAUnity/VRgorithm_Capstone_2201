const express = require('express');
const routes = require('../globals/routes.js');
const teacherController = require("../controllers/teacherController")

const teacherRouter = express.Router();

teacherRouter.post(routes.ROOT, teacherController.postRegister);

teacherRouter.get(routes.TOKEN, teacherController.getToken);



module.exports = teacherRouter;