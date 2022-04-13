module.exports = (sequelize, DataTypes) => {
    const result = sequelize.define('result', {
        id: { // 
            type: DataTypes.INTEGER,
            autoincrement: true,
            primaryKey: true,
            allowNull: false
        },
        studentId: {
            type: DataTypes.STRING,
            allowNull: false
        },
        isCorrect: { // 
            type: DataTypes.BOOLEAN,
        },
    }, { timestamps: true });
    result.associate = function(models) {
        models.result.belongsTo(models.problem, {
            foreignKey: "problemId",
            onUpdate: "cascade"
        })
    }
    return result;
}