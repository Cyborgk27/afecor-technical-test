CREATE TABLE [Clients] (
    [Id] int NOT NULL IDENTITY,
    [FirstName] nvarchar(max) NOT NULL,
    [LastName] nvarchar(max) NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [Phone] nvarchar(max) NOT NULL,
    [Address] nvarchar(max) NOT NULL,
    [AuditCreateUser] nvarchar(max) NOT NULL,
    [AuditCreateDate] datetime2 NOT NULL,
    [AuditUpdateUser] nvarchar(max) NULL,
    [AuditUpdateDate] datetime2 NULL,
    [AuditDeleteUser] nvarchar(max) NULL,
    [AuditDeleteDate] datetime2 NULL,
    [State] int NOT NULL,
    CONSTRAINT [PK_Clients] PRIMARY KEY ([Id])
);
GO


CREATE TABLE [Orders] (
    [Id] int NOT NULL IDENTITY,
    [OrderDate] datetime2 NOT NULL,
    [ClientId] int NOT NULL,
    [Total] decimal(18,2) NOT NULL,
    [AuditCreateUser] nvarchar(max) NOT NULL,
    [AuditCreateDate] datetime2 NOT NULL,
    [AuditUpdateUser] nvarchar(max) NULL,
    [AuditUpdateDate] datetime2 NULL,
    [AuditDeleteUser] nvarchar(max) NULL,
    [AuditDeleteDate] datetime2 NULL,
    [State] int NOT NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY ([Id])
);
GO


CREATE TABLE [Products] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Cost] decimal(18,2) NOT NULL,
    [Price] decimal(18,2) NOT NULL,
    [AuditCreateUser] nvarchar(max) NOT NULL,
    [AuditCreateDate] datetime2 NOT NULL,
    [AuditUpdateUser] nvarchar(max) NULL,
    [AuditUpdateDate] datetime2 NULL,
    [AuditDeleteUser] nvarchar(max) NULL,
    [AuditDeleteDate] datetime2 NULL,
    [State] int NOT NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY ([Id])
);
GO


CREATE TABLE [OrderDetails] (
    [Id] int NOT NULL IDENTITY,
    [OrderId] int NOT NULL,
    [ProductId] int NOT NULL,
    [Price] decimal(18,2) NOT NULL,
    [Quantity] int NOT NULL,
    [SubTotal] decimal(18,2) NOT NULL,
    [AuditCreateUser] nvarchar(max) NOT NULL,
    [AuditCreateDate] datetime2 NOT NULL,
    [AuditUpdateUser] nvarchar(max) NULL,
    [AuditUpdateDate] datetime2 NULL,
    [AuditDeleteUser] nvarchar(max) NULL,
    [AuditDeleteDate] datetime2 NULL,
    [State] int NOT NULL,
    CONSTRAINT [PK_OrderDetails] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_OrderDetails_Orders_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [Orders] ([Id]) ON DELETE CASCADE
);
GO


CREATE INDEX [IX_OrderDetails_OrderId] ON [OrderDetails] ([OrderId]);
GO

-- Insertar clientes
INSERT INTO [Clients] ([FirstName], [LastName], [Email], [Phone], [Address], [AuditCreateUser], [AuditCreateDate], [State])
VALUES 
('Juan', 'Pérez', 'juan.perez@email.com', '0991234567', 'Av. Siempre Viva 123', 'system', GETDATE(), 1),
('María', 'Gómez', 'maria.gomez@email.com', '0987654321', 'Calle Falsa 456', 'system', GETDATE(), 1),
('Carlos', 'Rodríguez', 'carlos.rodriguez@email.com', '0971122334', 'Av. Central 789', 'system', GETDATE(), 1);
GO

-- Insertar productos
INSERT INTO [Products] ([Name], [Cost], [Price], [AuditCreateUser], [AuditCreateDate], [State])
VALUES
('Producto A', 10.00, 15.00, 'system', GETDATE(), 1),
('Producto B', 20.00, 30.00, 'system', GETDATE(), 1),
('Producto C', 5.00, 8.00, 'system', GETDATE(), 1);
GO

-- Insertar órdenes
INSERT INTO [Orders] ([OrderDate], [ClientId], [Total], [AuditCreateUser], [AuditCreateDate], [State])
VALUES
(GETDATE(), 1, 45.00, 'system', GETDATE(), 1),
(GETDATE(), 2, 38.00, 'system', GETDATE(), 1);
GO

-- Insertar detalles de órdenes
INSERT INTO [OrderDetails] ([OrderId], [ProductId], [Price], [Quantity], [SubTotal], [AuditCreateUser], [AuditCreateDate], [State])
VALUES
(1, 1, 15.00, 2, 30.00, 'system', GETDATE(), 1),
(1, 3, 15.00, 1, 15.00, 'system', GETDATE(), 1),
(2, 2, 30.00, 1, 30.00, 'system', GETDATE(), 1),
(2, 3, 8.00, 1, 8.00, 'system', GETDATE(), 1);
GO


