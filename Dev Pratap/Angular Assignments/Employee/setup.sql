USE taskManagement;
GO


-- 1. Safe Drop Sequence (Reverse order of dependencies)
IF OBJECT_ID('dbo.RefreshTokens', 'U') IS NOT NULL DROP TABLE dbo.RefreshTokens;
IF OBJECT_ID('dbo.Tasks', 'U') IS NOT NULL DROP TABLE dbo.Tasks;
IF OBJECT_ID('dbo.UserRoles', 'U') IS NOT NULL DROP TABLE dbo.UserRoles;
IF OBJECT_ID('dbo.Roles', 'U') IS NOT NULL DROP TABLE dbo.Roles;
IF OBJECT_ID('dbo.Users', 'U') IS NOT NULL DROP TABLE dbo.Users;

-- 2. Core Users Table (UserID is now INT AUTO-INCREMENT)
CREATE TABLE Users (
    UserID INT IDENTITY(1,1) PRIMARY KEY, -- Automatically starts at 1, increments by 1
    FullName VARCHAR(50) NOT NULL,
    Email VARCHAR(100) NOT NULL UNIQUE,
    PasswordHash VARCHAR(255) NOT NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
    UpdatedAt DATETIME NULL
);

-- 3. Roles Table
CREATE TABLE Roles (
    RoleID INT IDENTITY(1,1) PRIMARY KEY,
    RoleName VARCHAR(50) NOT NULL UNIQUE
);

-- 4. Assigned Roles Junction Table (UserRoles)
CREATE TABLE UserRoles (
    UserRoleID INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT NOT NULL, -- Matched to INT
    RoleId INT NOT NULL,
    AssignedAt DATETIME NOT NULL DEFAULT GETDATE(),
    CONSTRAINT FK_UserRoles_Users FOREIGN KEY (UserId) REFERENCES Users(UserID) ON DELETE CASCADE,
    CONSTRAINT FK_UserRoles_Roles FOREIGN KEY (RoleId) REFERENCES Roles(RoleID) ON DELETE CASCADE,
    CONSTRAINT UQ_User_Role UNIQUE (UserId, RoleId)
);

-- 5. Tasks Table
CREATE TABLE Tasks (
    TaskID INT IDENTITY(1,1) PRIMARY KEY,
    Title VARCHAR(255) NOT NULL,
    Description TEXT NULL,
    AssignedToUserId INT NOT NULL, -- Matched to INT
    AssignedByUserId INT NOT NULL, -- Matched to INT
    Status VARCHAR(20) NOT NULL DEFAULT 'Pending',
    DueDate DATETIME NULL,
    CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
    UpdatedDate DATETIME NULL,
    CONSTRAINT FK_Tasks_AssignedTo FOREIGN KEY (AssignedToUserId) REFERENCES Users(UserID) ON DELETE NO ACTION,
    CONSTRAINT FK_Tasks_AssignedBy FOREIGN KEY (AssignedByUserId) REFERENCES Users(UserID) ON DELETE NO ACTION,
    CONSTRAINT CHK_TaskStatus CHECK (Status IN ('Pending', 'In Progress', 'Completed'))
);

-- 6. Refresh Tokens Table
CREATE TABLE RefreshTokens (
    TokenID INT IDENTITY(1,1) PRIMARY KEY,
    Token VARCHAR(MAX) NOT NULL,
    UserId INT NOT NULL, -- Matched to INT
    ExpiresAt DATETIME NOT NULL,
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
    CONSTRAINT FK_RefreshTokens_Users FOREIGN KEY (UserId) REFERENCES Users(UserID) ON DELETE CASCADE
);

-- =========================================================================
-- POPULATE DATA (Using Ints)
-- =========================================================================
BEGIN TRANSACTION;

    -- Insert Roles
    INSERT INTO Roles (RoleName) VALUES ('Admin'), ('Manager'), ('Employee');

    -- Insert Users (Notice we DO NOT pass UserID anymore; SQL Server handles it)
    INSERT INTO Users (FullName, Email, PasswordHash, IsActive, CreatedAt) VALUES 
    ('Dev Pratap', 'dev@gmail.com', '$2b$10$Foe0cjzHzxZQbZvu9ESGgeY5AMgkvEun/XieFDwA.yR4mJ7FSFyqq', 1, '2026-06-08 10:47:42'), -- Automatically becomes ID 1
    ('Sarah Connor', 'sarah@company.com', '$2b$10$EixKaxzHzxZQbZvu9ESGgeY5AMgkvEun/XieFDwA.yR4mJ7FSFaaa', 1, GETDATE()),              -- Automatically becomes ID 2
    ('John Doe', 'john@company.com', '$2b$10$RixKaxzHzxZQbZvu9ESGgeY5AMgkvEun/XieFDwA.yR4mJ7FSFbbb', 1, GETDATE()),               -- Automatically becomes ID 3
    ('Jane Smith', 'jane@company.com', '$2b$10$TixKaxzHzxZQbZvu9ESGgeY5AMgkvEun/XieFDwA.yR4mJ7FSFccc', 1, GETDATE());              -- Automatically becomes ID 4

    -- Fetching identity IDs dynamically to link relationships safely
    DECLARE @AdminRoleID INT = (SELECT RoleID FROM Roles WHERE RoleName = 'Admin');
    DECLARE @ManagerRoleID INT = (SELECT RoleID FROM Roles WHERE RoleName = 'Manager');
    DECLARE @EmployeeRoleID INT = (SELECT RoleID FROM Roles WHERE RoleName = 'Employee');

    -- Mapping via Integer IDs
    INSERT INTO UserRoles (UserId, RoleId) VALUES 
    (1, @AdminRoleID),     -- Dev (ID 1)
    (2, @ManagerRoleID),   -- Sarah (ID 2)
    (3, @EmployeeRoleID),  -- John (ID 3)
    (4, @EmployeeRoleID);  -- Jane (ID 4)

    -- Insert Tasks
    INSERT INTO Tasks (Title, Description, AssignedToUserId, AssignedByUserId, Status, DueDate, CreatedDate) VALUES 
    ('Q2 System Performance Review', 'Compile latency data for the core API endpoints and look for database locks.', 3, 2, 'In Progress', '2026-06-20 18:00:00', GETDATE()),
    ('Update Architecture Onboarding Guide', 'Rewrite the documentation to reflect the new string based mapping migration changes.', 4, 1, 'Pending', '2026-06-25 12:00:00', GETDATE()),
    ('Database Migration Auditing', 'Audit the dbo schema setup changes made during development scaling.', 2, 1, 'Completed', '2026-06-09 17:00:00', '2026-06-08 09:00:00');

    -- Insert Refresh Tokens
    INSERT INTO RefreshTokens (Token, UserId, ExpiresAt, CreatedAt) VALUES 
    ('eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VySWQiOjEsImlhdCI6MTg... (truncated)', 1, '2026-06-17 10:47:42', '2026-06-10 10:47:42'),
    ('eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VySWQiOjIsImlhdCI6MTg... (truncated)', 2, '2026-06-17 12:00:00', GETDATE());

COMMIT TRANSACTION;

-- Verification Query
SELECT 
    t.Title AS [Task Title],
    t.Status AS [Current Status],
    assignee.FullName AS [Assigned To],
    r.RoleName AS [Employee Core Role],
    creator.FullName AS [Creator]
FROM Tasks t
JOIN Users assignee ON t.AssignedToUserId = assignee.UserID
JOIN Users creator ON t.AssignedByUserId = creator.UserID
JOIN UserRoles ur ON assignee.UserID = ur.UserId
JOIN Roles r ON ur.RoleId = r.RoleID;


DECLARE @TargetUserId INT = 1010; 

INSERT INTO dbo.UserRoles (UserId, RoleId, AssignedAt)
SELECT @TargetUserId, r.RoleID, GETDATE()
FROM dbo.Roles r
WHERE r.RoleName = 'Admin'
  AND NOT EXISTS (
      SELECT 1 
      FROM dbo.UserRoles ur 
      WHERE ur.UserId = @TargetUserId 
        AND ur.RoleId = r.RoleID
  );