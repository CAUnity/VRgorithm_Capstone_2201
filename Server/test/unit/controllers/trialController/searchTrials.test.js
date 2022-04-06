const httpMocks = require('node-mocks-http');

const trialController = require('../../../../controllers/trialController');
const trialService = require('../../../../services/trialService');
const searchTrialsData = require('../../../data/searchTrialData.json');
const { ValidationError } = require('../../../../utils/errors/commonError');

const statusCode = require('../../../../globals/statusCode');

trialService.searchTrials = jest.fn();

let req, res, next;

beforeEach(() => {
  req = httpMocks.createRequest();
  res = httpMocks.createResponse();
  next = jest.fn();
})

describe('searchTrials 단위 테스트', () => {
  beforeEach(() => {
    req.query = searchTrialsData;
  })

  it("trialController에 searchTrials가 존재하는가?", () => {
    expect(typeof trialController.searchTrials).toBe("function")
  })

  it("trialController의 searchTrials에서 입력값이 제대로 들어오지 않는 경우 에러를 호출하는가?", async () => {
    const errorMessage = new ValidationError();
    req.query = {"page": -1};
    await trialController.searchTrials(req, res, next);
    expect(next).toBeCalledWith(errorMessage);
  })

  it("trialController의 searchTrials에서 service의 searchTrials를 호출하는가?", async () => {
    await trialController.searchTrials(req, res, next);
    expect(trialService.searchTrials).toBeCalled();
  })

  it("trialController의 searchTrials에서 service의 searchTrials에 인자값을 넣어서 호출하는가?", async () => {
    const data = searchTrialsData;
    data.page = Number(data.page) -1;
    data.limit = Number(data.limit);
    await trialController.searchTrials(req, res, next);
    expect(trialService.searchTrials).toBeCalledWith(data);
  })

  it("trialController의 searchTrials에서 상태 코드를 200을 넘겨주는가?", async() => {
    await trialController.searchTrials(req, res, next);
    expect(res.statusCode).toBe(statusCode.OK);
  })
})
