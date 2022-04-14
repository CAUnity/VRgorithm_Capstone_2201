module.exports = (sequelize, DataTypes) => {
    const problem = sequelize.define('problem', {
        id: { // 과제번호
            type: DataTypes.INTEGER,
            autoIncrement: true,
            primaryKey: true
        },
        name: { // 과제명
            type: DataTypes.STRING,
            allowNull: false
        },
        input: { // 과제명
            type: DataTypes.STRING,
            allowNull: false
        },
        output: { // 과제명
            type: DataTypes.STRING,
            allowNull: false
        },
        description: { // 과제명
            type: DataTypes.STRING,
            allowNull: false
        },

    }, { timestamps: true });
    problem.associate = function(models) {
        models.problem.belongsTo(models.teacher, {
            foreignKey: "teacherId",
            onUpdate: "cascade"
        })
    }
    return problem;
}