const bcrypt = require("bcrypt");

const {
    Role,
    User,
    Task
} = require("../models");

const seedDatabase = async () => {

    try {

        await Role.findOrCreate({
            where: { id: 1 },
            defaults: {
                name: "Admin"
            }
        });

        await Role.findOrCreate({
            where: { id: 2 },
            defaults: {
                name: "Manager"
            }
        });

        await Role.findOrCreate({
            where: { id: 3 },
            defaults: {
                name: "Employee"
            }
        });

        console.log("Roles Seeded");

        const adminPassword =
            await bcrypt.hash(
                "Admin@123",
                10
            );

        const managerPassword =
            await bcrypt.hash(
                "Manager@123",
                10
            );

        const employeePassword =
            await bcrypt.hash(
                "Employee@123",
                10
            );

        await User.findOrCreate({
            where: {
                email: "admin@example.com"
            },
            defaults: {
                username: "admin",
                password: adminPassword,
                roleId: 1
            }
        });

        await User.findOrCreate({
            where: {
                email: "manager@example.com"
            },
            defaults: {
                username: "manager",
                password: managerPassword,
                roleId: 2
            }
        });

        await User.findOrCreate({
            where: {
                email: "employee1@example.com"
            },
            defaults: {
                username: "employee1",
                password: employeePassword,
                roleId: 3
            }
        });

        await User.findOrCreate({
            where: {
                email: "employee2@example.com"
            },
            defaults: {
                username: "employee2",
                password: employeePassword,
                roleId: 3
            }
        });

        console.log("Users Seeded");

        

        const taskCount =
            await Task.count();

        if (taskCount === 0) {

            await Task.bulkCreate([
                {
                    title: "Design Login Page",
                    description:
                        "Create login page UI",
                    status: "Pending",
                    dueDate: new Date(),
                    assignedToUserId: 3,
                    assignedByUserId: 2
                },
                {
                    title: "Implement JWT",
                    description:
                        "Add JWT Authentication",
                    status: "In Progress",
                    dueDate: new Date(),
                    assignedToUserId: 4,
                    assignedByUserId: 1
                }
            ]);

            console.log("Tasks Seeded");
        }

        console.log(
            "Database Seeding Completed"
        );

    } catch (error) {

        console.error(
            "Seeder Error:",
            error
        );

    }
};

module.exports = seedDatabase;