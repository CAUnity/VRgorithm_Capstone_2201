const jwt = require('../utils/jwt');
const TOKEN_EXPIRED = -3;
const TOKEN_INVALID = -2;

const authUtil = {
    checkToken: async(req, res, next) => {
        var token = req.headers.token;
        // 토큰 없음
        if (!token)
            return res.render("unauthrized");
        // decode
        const user = await decodeToken(token);

        // 유효기간 만료
        if (user === false)
            return res.render("unauthrized");
        req.teacherId = user.teacherId;
        next();
    },
    decodeToken: async(token) => {
        // 토큰 없음
        if (!token)
            return res.render("unauthrized");
        // decode
        const user = await jwt.verify(token);
        // 유효기간 만료
        if (user === TOKEN_EXPIRED)
            return false;
        // 유효하지 않는 토큰
        if (user === TOKEN_INVALID)
            return false;
        if (user.teacherId === undefined)
            return false;
        return user;
    },
    checkLogin: async(req, res, next) => {
        try {
            if (req.session.user) {
                next();
            } else {
                res.redirect("/login");
            }
        } catch (err) {
            next(err);
        }
    }
}

module.exports = authUtil;