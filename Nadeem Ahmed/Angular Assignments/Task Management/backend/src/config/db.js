const {Sequelize} = require('sequelize');
require('dotenv').config();

const sequelize = new Sequelize(
    process.env.DB_NAME,
    process.env.DB_USER,
    process.env.DB_PASSWORD,
    {
        host:process.env.DB_HOST,
        dialect:"mssql",
        port:process.env.DB_PORT,
        dialectOptions:{
            options:{
                instanceName:process.env.DB_INSTANCE,
                trustedServerCertificate: true
            }
        },
        logging:false
    }
);

const connectDB = async()=>{
    try {
        await sequelize.authenticate();
        console.log("Database connected Successfully!")
    } catch (error) {
        console.error("Database Connection failed!")
        console.error(error.message)
        process.exit(1)
    }
};

module.exports = {
    sequelize,
    connectDB
}