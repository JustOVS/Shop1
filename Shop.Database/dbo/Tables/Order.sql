CREATE TABLE [dbo].[Order] (
    [id]         BIGINT        IDENTITY (1, 1) NOT NULL,
    [Time]       DATETIME2 (7) NOT NULL,
    [Address]    NVARCHAR (50) NOT NULL,
    [CustomerId] INT           NOT NULL,
    [IsDeleted]  BIT           DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_ORDER] PRIMARY KEY CLUSTERED ([id] ASC)
);

