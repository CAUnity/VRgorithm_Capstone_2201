const dotenv = require('dotenv');
dotenv.config();

module.exports = {
  openApiSecretKey: process.env.OPEN_API_SECRET,
};
