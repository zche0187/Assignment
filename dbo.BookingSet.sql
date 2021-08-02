CREATE TABLE [dbo].[BookingSet] (
    [BookingId]         INT            IDENTITY (1, 1) NOT NULL,
    [BookingRestaurant] NVARCHAR (MAX) NOT NULL,
    [SeatsNumber]       INT            NOT NULL,
    [Requirements]      NVARCHAR (MAX) NULL,
    [BookingDate]       NVARCHAR (MAX) NOT NULL,
    [UserId]            NVARCHAR (MAX) NOT NULL,
    [Date]              NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_BookingSet] PRIMARY KEY CLUSTERED ([BookingId] ASC)
);

