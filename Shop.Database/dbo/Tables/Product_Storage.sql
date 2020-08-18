CREATE TABLE [dbo].[Product_Storage] (
    [id]        BIGINT IDENTITY (1, 1) NOT NULL,
    [ProductId] BIGINT NOT NULL,
    [StorageId] INT    NOT NULL,
    [Quantity]  INT    NOT NULL,
    CONSTRAINT [PK_PRODUCT_STORAGE] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [Product_Storage_fk0] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([id]),
    CONSTRAINT [Product_Storage_fk1] FOREIGN KEY ([StorageId]) REFERENCES [dbo].[Storage] ([id])
);

