const { statusCode, responseMessage } = require('../globals');
const { resFormatter } = require('../utils');
const logger = require('../utils/logger');
const errors = require('../utils/errors/commonError');

// 상세 페이지 API
module.exports.getResults = async(req, res, next) => {
    try {
        const { trialId } = req.params;

        if (trialId === undefined) throw new ValidationError();

        const trial = await trialService.readTrial(trialId);

        if (!trial) throw new EntityNotExistError();

        return res
            .status(statusCode.OK)
            .send(resFormatter.success(responseMessage.READ_SUCCESS, trial));
    } catch (err) {
        next(err);
    }
};