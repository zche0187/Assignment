CREATE TABLE [dbo].[BookingSet] (
    [BookingId] int IDENTITY(1,1) NOT NULL,
    [BookingRestaurant] nvarchar(max)  NOT NULL,
    [SeatsNumber] nvarchar(max)  NOT NULL,
    [Requirements] nvarchar(max)  ,
    [BookingDate] nvarchar(max)  NOT NULL,
    [UserId] nvarchar(max)  NOT NULL,
    [Date] nvarchar(max)  NOT NULL
);