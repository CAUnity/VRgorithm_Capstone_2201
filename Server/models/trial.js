module.exports = (sequelize, DataTypes) => {
  const trial = sequelize.define('trial', {
    id: { // 과제번호
      type: DataTypes.STRING,
      primaryKey: true,
      allowNull: false
    },
    name: { // 과제명
      type: DataTypes.STRING,
      allowNull: false
    },
    term: { // 연구기간
      type: DataTypes.STRING,
    },
    domain: { // 연구범위
      type: DataTypes.STRING,
    },
    type: { // 연구종류
      type: DataTypes.STRING,
    },
    host: { // 연구책임기관
      type: DataTypes.STRING,
    },
    model: { // 임상시험단계(연구모형)
      type: DataTypes.STRING,
    },
    subjectCount: { // 전체목표연구대상자수
      type: DataTypes.INTEGER,
    },
    department: { // 진료과
      type: DataTypes.STRING,
    },
    hash: { //(md5?)
      type: DataTypes.STRING,  //(INTEGER 가능, 아마 BIGINT)
      allowNull: false
    }
  }, { timestamps: true });

  return trial;
}