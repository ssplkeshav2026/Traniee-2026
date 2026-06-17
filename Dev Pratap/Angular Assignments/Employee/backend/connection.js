const { Sequelize } = require('sequelize');
require('dotenv').config()

const sequelize = new Sequelize(process.env.DATABASENAME, process.env.DBUSERNAME, process.env.DBPASS, {
  host: process.env.DB_HOST,
  dialect: 'mssql',
  logging: false, 
  dialectOptions: {
    options: {
      encrypt: true, 
      trustServerCertificate: true 
    }
  }
});

const testConnection = async () => {
  try {
    await sequelize.authenticate();
    console.log('Successfully connected to the MSSQL database!');
  } catch (error) {
    console.error('Unable to connect to the database:', error);
  }
};

module.exports = { sequelize,testConnection };