const dotenv = require('dotenv');
dotenv.config();

module.exports = {
    secretKey: process.env.JWT_SECRET,
    option: {
        algorithm: "HS256",
        expiresIn: "30m",
        issuer: "me",
    }
};