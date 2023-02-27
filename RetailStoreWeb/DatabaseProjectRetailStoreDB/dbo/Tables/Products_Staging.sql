CREATE TABLE [dbo].[Products_Staging] (
    [SKU]                UNIQUEIDENTIFIER DEFAULT (newid()) NULL,
    [StoreID]            INT              NULL,
    [ProductName]        VARCHAR (100)    NULL,
    [Price]              NUMERIC (10, 2)  NULL,
    [EffectiveStartDate] DATETIME2 (7)    NULL,
    [EffectiveEndDate]   DATETIME2 (7)    NULL,
    [Active]             BIT              NULL
);


GO

