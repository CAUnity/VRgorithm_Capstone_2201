const httpMocks = require('node-mocks-http');

const trialController = require('../../../../controllers/trialController');
const trialService = require('../../../../services/trialService');
const trialData = require('../../../data/trialData.json');
const { ValidationError, EntityNotExistError } = require('../../../../utils/errors/commonError');

const statusCode = require('../../../../globals/statusCode');

trialService.readTrial = jest.fn();

let req, res, next;

beforeEach(() => {
  req = httpMocks.createRequest();
  res = httpMocks.createResponse();
  next = jest.fn();
})

describe('postTrials 단위 테스트', () => {
  beforeEach(() => {
    req.params.trialId = trialData.trialId;
  })

  it("trialController에 getTrialDetail이 존재하는가?", () => {
    expect(typeof trialController.getTrialDetail).toBe("function")
  })

  it("trialController의 getTrialDetail에서 params값이 제대로 들어오지 않는 경우 에러를 호출하는가?", async () => {
    const errorMessage = new ValidationError();
    req.params.trialId = undefined;
    await trialController.getTrialDetail(req, res, next);
    expect(next).toBeCalledWith(errorMessage);
  })

  it("trialController의 getTrialDetail에서 service의 readTrial을 호출하는가?", async () => {
    await trialController.getTrialDetail(req, res, next);
    expect(trialService.readTrial).toBeCalled();
  })

  it("trialController의 getTrialDetail에서 service의 readTrial에 인자를 넣어서 호출하는가?", async () => {
    await trialController.getTrialDetail(req, res, next);
    expect(trialService.readTrial).toBeCalledWith(trialData.trialId);
  })

  it("trialController의 getTrialDetail에서 service의 readTrial 호출이 실패하는가?", async () => {
    const errorMessage = new EntityNotExistError();
    const rejectPromise = Promise.reject(errorMessage);
    trialService.readTrial.mockReturnValue(rejectPromise)
    await trialController.getTrialDetail(req, res, next);
    expect(next).toBeCalledWith(errorMessage);
  })

  it("trialController의 getTrialDetail에서 상태 코드를 200을 넘겨주는가?", async() => {
    await trialController.getTrialDetail(req, res, next);
    expect(res.statusCode).toBe(statusCode.OK);
  })
})
