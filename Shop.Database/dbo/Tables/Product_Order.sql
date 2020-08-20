CREATE TABLE [dbo].[Product_Order] (
    [id]        BIGINT IDENTITY (1, 1) NOT NULL,
    [ProductId] BIGINT NOT NULL,
    [OrderId]   BIGINT NOT NULL,
    [Quantity]  INT    NOT NULL,
    CONSTRAINT [Product_Order_fk0] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([id]),
    CONSTRAINT [Product_Order_fk1] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Order] ([id])
);

