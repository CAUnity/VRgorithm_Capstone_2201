const httpMocks = require('node-mocks-http');

const statusCode = require("../../../globals/statusCode");
const {getOpenApiData} = require("../../../jobs/openApiJobs");
const {createOrUpdateTrials} = require("../../../services/trialService");

jest.mock('../../../services/trialService');

describe('openApiJobs 단위테스트', ()=>{
  beforeAll( async ()=>{
    await getOpenApiData();
  })

  test('createOrUpdateTrials를 호출하는가?', ()=>{
    expect(createOrUpdateTrials).toBeCalled();
  })

  test('createOrUpdateTrials에 넘겨준 데이터가 배열인가?', ()=>{
    createOrUpdateTrials.mock.calls.forEach(element => {
      expect(Array.isArray(element)).toBe(true);
    });
  })

})