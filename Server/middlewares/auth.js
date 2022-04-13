const jwt = require('../utils/jwt');
const MSG = require('../modules/responseMessage');
const CODE = require('../modules/statusCode');
const util = require('../modules/util');
const TOKEN_EXPIRED = -3;
const TOKEN_INVALID = -2;

const authUtil = {
    checkToken: async(req, res, next) => {
        var token = req.headers.token;
        // 토큰 없음
        if (!token)
            return res.render("unauthrized");
        // decode
        const user = await jwt.verify(token);
        // 유효기간 만료
        if (user === TOKEN_EXPIRED)
            return res.render("unauthrized");
        // 유효하지 않는 토큰
        if (user === TOKEN_INVALID)
            return res.render("unauthrized");
        if (user.idx === undefined)
            return res.render("unauthrized");
        req.teacherId = user.teacherId;
        next();
    }
}

module.exports = authUtil;