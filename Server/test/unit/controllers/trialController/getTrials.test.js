const httpMocks = require('node-mocks-http');

const trialController = require('../../../../controllers/trialController');
const trialService = require('../../../../services/trialService');
const trialsData = require('../../../data/trialsData.json');
const { ValidationError } = require('../../../../utils/errors/commonError');

const statusCode = require('../../../../globals/statusCode');
const day = require('../../../../utils/day');

trialService.readTrialList = jest.fn();

let req, res, next;

beforeEach(() => {
  req = httpMocks.createRequest();
  res = httpMocks.createResponse();
  next = jest.fn();
})

describe('getTrials 단위 테스트', () => {
  beforeEach(() => {
    req.query = trialsData;
  })

  it("trialController에 getTrials가 존재하는가?", () => {
    expect(typeof trialController.getTrials).toBe("function")
  })

  it("trialController의 getTrials에서 page 입력값이 제대로 들어오지 않는 경우 에러를 호출하는가?", async () => {
    const errorMessage = new ValidationError();
    req.query = {"page": -1};
    await trialController.getTrials(req, res, next);
    expect(next).toBeCalledWith(errorMessage);
  })

  it("trialController의 getTrials에서 day 모듈의 beforeOneWeek 메서드를 호출하는가?", async () => {
    const spy = jest.spyOn(day, 'beforeOneWeek');
    await trialController.getTrials(req, res, next);
    expect(spy).toBeCalled();
    spy.mockRestore();
  })

  it("trialController의 getTrials에서 service의 readTrialList를 호출하는가?", async () => {
    await trialController.getTrials(req, res, next);
    expect(trialService.readTrialList).toBeCalled();
  })

  it("trialController의 getTrials에서 service의 readTrialList에 인자값을 넣어서 호출하는가?", async () => {
    const spy = jest.spyOn(day, 'beforeOneWeek');
    trialsData.beforeOneWeek = spy();
    trialsData.page = 0;
    await trialController.getTrials(req, res, next);
    expect(trialService.readTrialList).toBeCalledWith(trialsData);
  })

  it("trialController의 getTrials에서 상태 코드를 200을 넘겨주는가?", async() => {
    await trialController.getTrials(req, res, next);
    expect(res.statusCode).toBe(statusCode.OK);
  })
})
