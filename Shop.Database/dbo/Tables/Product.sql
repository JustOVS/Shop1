CREATE TABLE [dbo].[Product] (
    [id]                   BIGINT        IDENTITY (1, 1) NOT NULL,
    [Price]                MONEY         NOT NULL,
    [Manufacturer]         NVARCHAR (30) NULL,
    [Model]                NVARCHAR (30) NOT NULL,
    [YearOfManufacture]    INT           NULL,
    [Length]               INT           NULL,
    [Width]                INT           NULL,
    [Height]               INT           NULL,
    [AirSpeed]             INT           NULL,
    [DryingMode]           BIT           NULL,
    [NumberOfRecipes]      INT           NULL,
    [NumberOfNozzles]      INT           NULL,
    [Power]                INT           NULL,
    [Volume]               INT           NULL,
    [DescalingProtection]  BIT           NULL,
    [NoiseLevel]           INT           NULL,
    [NumberOfCompartments] INT           NULL,
    [NumberOfModes]        INT           NULL,
    [IsDeleted]            BIT           CONSTRAINT [DF_Product_IsDeleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_PRODUCT] PRIMARY KEY CLUSTERED ([id] ASC)
);

