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


