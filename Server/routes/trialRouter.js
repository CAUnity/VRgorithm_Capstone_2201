const express = require("express");
const routes = require('../globals/routes');

const trialController = require('../controllers/trialController.js');

const trialRouter = express.Router();

//목록조회
trialRouter.get(routes.root, trialController.getTrials);

//상세조회
trialRouter.get(routes.trialDetail, trialController.getTrialDetail);

//검색
trialRouter.get(routes.search, trialController.searchTrials);

module.exports = trialRouter;