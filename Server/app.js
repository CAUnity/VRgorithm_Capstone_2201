const express = require('express');
const path = require('path');
const helmet = require('helmet');
const morgan = require('morgan');
const createError = require('http-errors');
const cookieParser = require('cookie-parser');
const expressSession = require('express-session');
const { logger, resFormatter } = require('./utils');
const { statusCode, routes, responseMessage } = require('./globals');
const configs = require('./configs');
const models = require("./models");

const routers = require('./routes');

const { NoPageError } = require('./utils/errors/commonError');

//서버 사전작업
const app = express();


//뷰 엔진 및 에셋 위치 설정
app.set('views', path.join(__dirname, 'public'));
app.set('view engine', 'ejs');
app.engine('html', require('ejs').renderFile);
app.use(express.static(path.join(__dirname, 'public')));


//미들웨어 설정
app.use(helmet({
    contentSecurityPolicy: false
}));
app.use(morgan('dev'));
app.use(express.json());
app.use(express.urlencoded({ extended: false }));
app.use(cookieParser());
app.use(expressSession({
    secret: configs.session.secret,
    resave: true,
    saveUninitialized: true,
}))


//라우터 설정
app.use(routes.ROOT, routers.globalRouter);
app.use(routes.PROBLEM, routers.problemRouter);
app.use(routes.TEACHER, routers.teacherRouter);
app.use(routes.RESULT, routers.resultRouter);


// 아래는 에러 핸들링 함수들
app.use(function(req, res, next) {
    throw new NoPageError();
});

app.use(function(err, req, res, next) {
    let errCode = err.status || statusCode.INTERNAL_SERVER_ERROR;

    if (req.app.get('env') == "development") {
        logger.err(err);

        return res.status(errCode)
            .send(resFormatter.fail(err.message));

    }

    return res.status(statusCode.INTERNAL_SERVER_ERROR)
        .send(resFormatter.fail(responseMessage.INTERNAL_SERVER_ERROR));
});

module.exports = app;