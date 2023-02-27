CREATE TABLE [dbo].[Stores] (
    [StoreID]   INT           IDENTITY (1, 1) NOT NULL,
    [StoreName] VARCHAR (100) NOT NULL,
    [Active]    BIT           NOT NULL,
    PRIMARY KEY CLUSTERED ([StoreID] ASC)
);
GO

