const dayjs = require('dayjs');

module.exports = {
  beforeOneWeek: () => dayjs().subtract(7, 'day').format('YYYY-MM-DD')
}    