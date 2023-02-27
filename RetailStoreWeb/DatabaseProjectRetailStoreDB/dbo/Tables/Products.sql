CREATE TABLE [dbo].[Products] (
    [SKU]                UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [StoreID]            INT              NOT NULL,
    [ProductName]        VARCHAR (100)    NOT NULL,
    [Price]              NUMERIC (10, 2)  NOT NULL,
    [EffectiveStartDate] DATETIME2 (7)    NOT NULL,
    [EffectiveEndDate]   DATETIME2 (7)    NULL,
    [Active]             BIT              NOT NULL,
    PRIMARY KEY CLUSTERED ([SKU] ASC),
    CONSTRAINT [FK_Storeid] FOREIGN KEY ([StoreID]) REFERENCES [dbo].[Stores] ([StoreID])
);


GO

