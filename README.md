

USE UserAuthDB;
GO

CREATE TABLE tbblogin (
    id INT IDENTITY(1,1) PRIMARY KEY,
    name NVARCHAR(100) NOT NULL,
    contact NVARCHAR(15) NOT NULL UNIQUE,
    password NVARCHAR(255) NOT NULL
);
GO
# Asp_Api_With_Vue
