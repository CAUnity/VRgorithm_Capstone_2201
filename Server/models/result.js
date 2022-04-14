module.exports = (sequelize, DataTypes) => {
    const result = sequelize.define('result', {
        id: { // 
            type: DataTypes.INTEGER,
            autoIncrement: true,
            primaryKey: true
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