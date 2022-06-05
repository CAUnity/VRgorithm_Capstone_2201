const dotenv = require('dotenv');
dotenv.config();

module.exports = {
    secret: process.env.SESSION_SECRET,
};