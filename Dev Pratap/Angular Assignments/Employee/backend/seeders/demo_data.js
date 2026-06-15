'use strict';
const bcrypt = require('bcrypt');

module.exports = {
  async up (queryInterface, Sequelize) {

    const salt = await bcrypt.genSalt(10);
    const hashedSecurePassword = await bcrypt.hash('SecurePassword123', salt);

    const [roles] = await queryInterface.sequelize.query(
      `SELECT RoleID, RoleName FROM dbo.Roles;`
    );

    const adminRole = roles.find(r => r.RoleName === 'Admin');
    const managerRole = roles.find(r => r.RoleName === 'Manager');
    const employeeRole = roles.find(r => r.RoleName === 'Employee');

    if (!adminRole || !managerRole || !employeeRole) {
      throw new Error("Seeding Failed: Please populate your master Roles table before running this demo seeder.");
    }

    const [insertedUsers] = await queryInterface.sequelize.query(`
      INSERT INTO dbo.Users (FullName, Email, PasswordHash, IsActive, CreatedAt, UpdatedAt)
      OUTPUT INSERTED.UserID, INSERTED.Email
      VALUES 
      ('Dev Admin', 'admin@company.com', '${hashedSecurePassword}', 1, GETDATE(), GETDATE()),
      ('Alice Manager', 'manager@company.com', '${hashedSecurePassword}', 1, GETDATE(), GETDATE()),
      ('John Employee', 'john@company.com', '${hashedSecurePassword}', 1, GETDATE(), GETDATE()),
      ('Sarah Employee', 'sarah@company.com', '${hashedSecurePassword}', 1, GETDATE(), GETDATE());
    `);

    const adminId = insertedUsers.find(u => u.Email === 'admin@company.com').UserID;
    const managerId = insertedUsers.find(u => u.Email === 'manager@company.com').UserID;
    const johnId = insertedUsers.find(u => u.Email === 'john@company.com').UserID;
    const sarahId = insertedUsers.find(u => u.Email === 'sarah@company.com').UserID;

    await queryInterface.bulkInsert({ tableName: 'UserRoles', schema: 'dbo' }, [
      { UserId: adminId, RoleId: adminRole.RoleID, AssignedAt: new Date() },
      { UserId: managerId, RoleId: managerRole.RoleID, AssignedAt: new Date() },
      { UserId: johnId, RoleId: employeeRole.RoleID, AssignedAt: new Date() },
      { UserId: sarahId, RoleId: employeeRole.RoleID, AssignedAt: new Date() }
    ]);

    await queryInterface.bulkInsert({ tableName: 'Tasks', schema: 'dbo' }, [
      {
        Title: 'Configure Production Firewalls',
        Description: 'Review whitelist IP arrays and set secure routing parameters.',
        Status: 'Pending',
        AssignedToUserId: johnId,     
        AssignedByUserId: adminId,    
        DueDate: new Date(new Date().setDate(new Date().getDate() + 5)), 
        CreatedDate: new Date()
      },
      {
        Title: 'Audit API Token Performance Mismatch',
        Description: 'Analyze database execution latency profiling caused by previous DATETIME parsing logic.',
        Status: 'In Progress',
        AssignedToUserId: johnId,     
        AssignedByUserId: managerId,  
        DueDate: new Date(new Date().setDate(new Date().getDate() + 2)),
        CreatedDate: new Date()
      },
      {
        Title: 'Design Q3 Sprint Architecture UI Mockups',
        Description: 'Draft wireframes for the user administration dashboard access portal.',
        Status: 'Pending',
        AssignedToUserId: sarahId,    
        AssignedByUserId: managerId,  
        DueDate: new Date(new Date().setDate(new Date().getDate() + 10)),
        CreatedDate: new Date()
      },
      {
        Title: 'Patch Core Repository Security Flaws',
        Description: 'Address outstanding dependency alerts identified inside node_modules structures.',
        Status: 'Completed',
        AssignedToUserId: sarahId,    
        AssignedByUserId: adminId,    
        DueDate: new Date(),
        CreatedDate: new Date()
      },
      {
        Title: 'Review Corporate Client Feedback Data',
        Description: 'Compile user interaction telemetry spreadsheets for review next Tuesday.',
        Status: 'Pending',
        AssignedToUserId: johnId,     
        AssignedByUserId: managerId,  
        DueDate: new Date(new Date().setDate(new Date().getDate() + 4)),
        CreatedDate: new Date()
      }
    ]);
  },

  async down (queryInterface, Sequelize) {
    await queryInterface.sequelize.query('DELETE FROM dbo.Tasks;');
    await queryInterface.sequelize.query('DELETE FROM dbo.UserRoles;');
    await queryInterface.sequelize.query("DELETE FROM dbo.Users WHERE Email IN ('admin@company.com', 'manager@company.com', 'john@company.com', 'sarah@company.com');");
  }
};