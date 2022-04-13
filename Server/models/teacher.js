module.exports = (sequelize, DataTypes) => {
    const teacher = sequelize.define('teacher', {
        id: { // 과제번호
            type: DataTypes.STRING,
            primaryKey: true,
            allowNull: false
        },
        name: { // 과제명
            type: DataTypes.STRING,
            allowNull: false
        },
        pwd: { // 연구기간
            type: DataTypes.STRING,
            allowNull: false
        },
        salt: {
            type: DataTypes.STRING,
            allowNull: false
        }
    }, { timestamps: true });

    return teacher;
}