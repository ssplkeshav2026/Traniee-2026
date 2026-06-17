const app = require("./src/app");

const {
    connectDB,
    sequelize
} = require("./src/config/db");

const seedDatabase =
require("./src/seeders/data.seeder");

const PORT =
process.env.PORT || 5000;

const startServer = async () => {

    try {

        await connectDB();

        await sequelize.sync();

        await seedDatabase();

        app.listen(PORT, () => {
            console.log(
                `Server running on port ${PORT}`
            );
        });

    } catch (error) {

        console.error(error);
    }
};

startServer();