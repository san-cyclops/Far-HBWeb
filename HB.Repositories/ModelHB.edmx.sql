
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/05/2020 23:25:33
-- Generated from EDMX file: D:\DEVOLOPMENT\HotelBeds\FARHOLIDAYS WEB\Far-HBWeb\HB.Repositories\ModelHB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [FARHBNEWAGENT_TEST];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_dbo_ZoneReps_dbo_Contents_Description_ContentID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ZoneReps] DROP CONSTRAINT [FK_dbo_ZoneReps_dbo_Contents_Description_ContentID];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[__MigrationHistory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[__MigrationHistory];
GO
IF OBJECT_ID(N'[dbo].[AccommodationReps]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AccommodationReps];
GO
IF OBJECT_ID(N'[dbo].[BoardReps]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BoardReps];
GO
IF OBJECT_ID(N'[dbo].[CategoryReps]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CategoryReps];
GO
IF OBJECT_ID(N'[dbo].[ChainReps]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ChainReps];
GO
IF OBJECT_ID(N'[dbo].[Contents]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Contents];
GO
IF OBJECT_ID(N'[dbo].[CountryReps]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CountryReps];
GO
IF OBJECT_ID(N'[dbo].[CurrencyReps]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CurrencyReps];
GO
IF OBJECT_ID(N'[dbo].[DestinationsReps]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DestinationsReps];
GO
IF OBJECT_ID(N'[dbo].[DocumentReps]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DocumentReps];
GO
IF OBJECT_ID(N'[dbo].[FacilityGroupReps]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FacilityGroupReps];
GO
IF OBJECT_ID(N'[dbo].[FacilityReps]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FacilityReps];
GO
IF OBJECT_ID(N'[dbo].[FacilityTypeReps]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FacilityTypeReps];
GO
IF OBJECT_ID(N'[dbo].[GeoLocationReps]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GeoLocationReps];
GO
IF OBJECT_ID(N'[dbo].[GroupCategoryReps]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GroupCategoryReps];
GO
IF OBJECT_ID(N'[dbo].[GroupZoneReps]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GroupZoneReps];
GO
IF OBJECT_ID(N'[dbo].[HotelBoardCodesReps]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HotelBoardCodesReps];
GO
IF OBJECT_ID(N'[dbo].[HotelFacilityReps]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HotelFacilityReps];
GO
IF OBJECT_ID(N'[dbo].[HotelPaymentDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HotelPaymentDetails];
GO
IF OBJECT_ID(N'[dbo].[HotelPhoneReps]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HotelPhoneReps];
GO
IF OBJECT_ID(N'[dbo].[HotelReps]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HotelReps];
GO
IF OBJECT_ID(N'[dbo].[HotelRoomFacilityReps]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HotelRoomFacilityReps];
GO
IF OBJECT_ID(N'[dbo].[HotelRoomReps]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HotelRoomReps];
GO
IF OBJECT_ID(N'[dbo].[HotelRoomStayFacilityReps]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HotelRoomStayFacilityReps];
GO
IF OBJECT_ID(N'[dbo].[HotelRoomStayReps]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HotelRoomStayReps];
GO
IF OBJECT_ID(N'[dbo].[HotelSegmentReps]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HotelSegmentReps];
GO
IF OBJECT_ID(N'[dbo].[HotelTerminalReps]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HotelTerminalReps];
GO
IF OBJECT_ID(N'[dbo].[HRZAminity]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HRZAminity];
GO
IF OBJECT_ID(N'[dbo].[HRZHotelImage]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HRZHotelImage];
GO
IF OBJECT_ID(N'[dbo].[HRZHotelSupplier]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HRZHotelSupplier];
GO
IF OBJECT_ID(N'[dbo].[HRZLanguage]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HRZLanguage];
GO
IF OBJECT_ID(N'[dbo].[HRZNearbyPlaces]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HRZNearbyPlaces];
GO
IF OBJECT_ID(N'[dbo].[HRZPayment]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HRZPayment];
GO
IF OBJECT_ID(N'[dbo].[HRZPromotion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HRZPromotion];
GO
IF OBJECT_ID(N'[dbo].[HRZRoomBooking]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HRZRoomBooking];
GO
IF OBJECT_ID(N'[dbo].[HRZRoomMaster]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HRZRoomMaster];
GO
IF OBJECT_ID(N'[dbo].[HRZRoomUnavailable]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HRZRoomUnavailable];
GO
IF OBJECT_ID(N'[dbo].[HRZUser]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HRZUser];
GO
IF OBJECT_ID(N'[dbo].[ImageReps]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ImageReps];
GO
IF OBJECT_ID(N'[dbo].[ImageTypeReps]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ImageTypeReps];
GO
IF OBJECT_ID(N'[dbo].[IssueReps]', 'U') IS NOT NULL
    DROP TABLE [dbo].[IssueReps];
GO
IF OBJECT_ID(N'[dbo].[LanguageReps]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LanguageReps];
GO
IF OBJECT_ID(N'[dbo].[PromotionReps]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PromotionReps];
GO
IF OBJECT_ID(N'[dbo].[RateCommentReps]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RateCommentReps];
GO
IF OBJECT_ID(N'[dbo].[RoomReps]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RoomReps];
GO
IF OBJECT_ID(N'[dbo].[SegmentReps]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SegmentReps];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[TerminalReps]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TerminalReps];
GO
IF OBJECT_ID(N'[dbo].[ZoneReps]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ZoneReps];
GO
IF OBJECT_ID(N'[HBNEWModelStoreContainer].[AgentLogin]', 'U') IS NOT NULL
    DROP TABLE [HBNEWModelStoreContainer].[AgentLogin];
GO
IF OBJECT_ID(N'[HBNEWModelStoreContainer].[AgentMarkup]', 'U') IS NOT NULL
    DROP TABLE [HBNEWModelStoreContainer].[AgentMarkup];
GO
IF OBJECT_ID(N'[HBNEWModelStoreContainer].[CurrencyRate]', 'U') IS NOT NULL
    DROP TABLE [HBNEWModelStoreContainer].[CurrencyRate];
GO
IF OBJECT_ID(N'[HBNEWModelStoreContainer].[FacilitySumReps]', 'U') IS NOT NULL
    DROP TABLE [HBNEWModelStoreContainer].[FacilitySumReps];
GO
IF OBJECT_ID(N'[HBNEWModelStoreContainer].[FacilitySumReps_back]', 'U') IS NOT NULL
    DROP TABLE [HBNEWModelStoreContainer].[FacilitySumReps_back];
GO
IF OBJECT_ID(N'[HBNEWModelStoreContainer].[FacilitySumRepsBackup]', 'U') IS NOT NULL
    DROP TABLE [HBNEWModelStoreContainer].[FacilitySumRepsBackup];
GO
IF OBJECT_ID(N'[HBNEWModelStoreContainer].[HRZUserPrivileges]', 'U') IS NOT NULL
    DROP TABLE [HBNEWModelStoreContainer].[HRZUserPrivileges];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'C__MigrationHistory'
CREATE TABLE [dbo].[C__MigrationHistory] (
    [MigrationId] nvarchar(150)  NOT NULL,
    [ContextKey] nvarchar(300)  NOT NULL,
    [Model] varbinary(max)  NOT NULL,
    [ProductVersion] nvarchar(32)  NOT NULL
);
GO

-- Creating table 'AccommodationReps'
CREATE TABLE [dbo].[AccommodationReps] (
    [AccommodationRepID] bigint IDENTITY(1,1) NOT NULL,
    [code] nvarchar(max)  NULL,
    [typeMultiDescription] nvarchar(max)  NULL,
    [typeDescription] nvarchar(max)  NULL
);
GO

-- Creating table 'BoardReps'
CREATE TABLE [dbo].[BoardReps] (
    [BoardRepID] bigint IDENTITY(1,1) NOT NULL,
    [Hotelcode] int  NOT NULL,
    [code] nvarchar(max)  NULL,
    [description] nvarchar(max)  NULL,
    [multiLingualCode] nvarchar(max)  NULL
);
GO

-- Creating table 'CategoryReps'
CREATE TABLE [dbo].[CategoryReps] (
    [CategoryRepID] bigint IDENTITY(1,1) NOT NULL,
    [code] nvarchar(max)  NULL,
    [simpleCode] int  NOT NULL,
    [accommodationType] nvarchar(max)  NULL,
    [group] nvarchar(max)  NULL,
    [description] nvarchar(max)  NULL
);
GO

-- Creating table 'ChainReps'
CREATE TABLE [dbo].[ChainReps] (
    [ChainRepID] bigint IDENTITY(1,1) NOT NULL,
    [code] nvarchar(max)  NULL,
    [description] nvarchar(max)  NULL
);
GO

-- Creating table 'Contents'
CREATE TABLE [dbo].[Contents] (
    [ContentID] bigint IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'CountryReps'
CREATE TABLE [dbo].[CountryReps] (
    [CountryRepID] bigint IDENTITY(1,1) NOT NULL,
    [code] nvarchar(max)  NULL,
    [isoCode] nvarchar(max)  NULL,
    [description] nvarchar(max)  NULL
);
GO

-- Creating table 'CurrencyReps'
CREATE TABLE [dbo].[CurrencyReps] (
    [CurrencyRepID] bigint IDENTITY(1,1) NOT NULL,
    [code] nvarchar(max)  NULL,
    [description] nvarchar(max)  NULL,
    [currencyType] nvarchar(max)  NULL,
    [Value] decimal(18,2)  NULL
);
GO

-- Creating table 'DestinationsReps'
CREATE TABLE [dbo].[DestinationsReps] (
    [DestinationsRepID] bigint IDENTITY(1,1) NOT NULL,
    [code] nvarchar(max)  NULL,
    [name] nvarchar(max)  NULL,
    [countryCode] nvarchar(max)  NULL,
    [isoCode] nvarchar(max)  NULL
);
GO

-- Creating table 'DocumentReps'
CREATE TABLE [dbo].[DocumentReps] (
    [DocumentRepID] bigint IDENTITY(1,1) NOT NULL,
    [DocumentID] bigint  NULL,
    [DocumentNo] bigint  NULL,
    [DocumentType] varchar(50)  NULL
);
GO

-- Creating table 'FacilityGroupReps'
CREATE TABLE [dbo].[FacilityGroupReps] (
    [FacilityGroupRepID] bigint IDENTITY(1,1) NOT NULL,
    [code] int  NOT NULL,
    [description] nvarchar(max)  NULL
);
GO

-- Creating table 'FacilityReps'
CREATE TABLE [dbo].[FacilityReps] (
    [FacilityRepID] bigint IDENTITY(1,1) NOT NULL,
    [HotelCode] int  NOT NULL,
    [code] int  NOT NULL,
    [facilityGroupCode] int  NOT NULL,
    [facilityTypologyCode] int  NOT NULL,
    [description] nvarchar(max)  NULL
);
GO

-- Creating table 'FacilityTypeReps'
CREATE TABLE [dbo].[FacilityTypeReps] (
    [FacilityTypeRepID] bigint IDENTITY(1,1) NOT NULL,
    [code] int  NOT NULL,
    [conceptFlag] bit  NOT NULL,
    [numberFlag] bit  NOT NULL,
    [logicFlag] bit  NOT NULL,
    [feeFlag] bit  NOT NULL,
    [distanceFlag] bit  NOT NULL,
    [ageFromFlag] bit  NOT NULL,
    [ageToFlag] bit  NOT NULL,
    [dateFromFlag] bit  NOT NULL,
    [dateToFlag] bit  NOT NULL,
    [timeFromFlag] bit  NOT NULL,
    [timeToFlag] bit  NOT NULL,
    [indYesOrNoFlag] bit  NOT NULL,
    [amountFlag] bit  NOT NULL,
    [currencyFlag] bit  NOT NULL,
    [appTypeFlag] bit  NOT NULL
);
GO

-- Creating table 'GeoLocationReps'
CREATE TABLE [dbo].[GeoLocationReps] (
    [GeoLocationRepID] bigint IDENTITY(1,1) NOT NULL,
    [HotelCode] int  NOT NULL,
    [longitude] float  NULL,
    [latitude] float  NULL,
    [radius] decimal(18,2)  NULL,
    [unit] int  NULL,
    [secondaryLatitude] float  NOT NULL,
    [secondaryLongitude] float  NOT NULL
);
GO

-- Creating table 'GroupCategoryReps'
CREATE TABLE [dbo].[GroupCategoryReps] (
    [GroupCategoryRepID] bigint IDENTITY(1,1) NOT NULL,
    [code] nvarchar(max)  NULL,
    [order] int  NOT NULL,
    [name] nvarchar(max)  NULL,
    [description] nvarchar(max)  NULL
);
GO

-- Creating table 'GroupZoneReps'
CREATE TABLE [dbo].[GroupZoneReps] (
    [GroupZoneRepID] bigint IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'HotelBoardCodesReps'
CREATE TABLE [dbo].[HotelBoardCodesReps] (
    [HotelBoardCodesRepID] bigint IDENTITY(1,1) NOT NULL,
    [HotelCode] int  NOT NULL,
    [code] int  NOT NULL,
    [BoardCode] nvarchar(max)  NULL
);
GO

-- Creating table 'HotelFacilityReps'
CREATE TABLE [dbo].[HotelFacilityReps] (
    [HotelFacilityRepID] bigint IDENTITY(1,1) NOT NULL,
    [HotelCode] int  NOT NULL,
    [facilityCode] int  NOT NULL,
    [facilityGroupCode] int  NOT NULL,
    [description] nvarchar(max)  NULL,
    [order] int  NOT NULL,
    [indLogic] bit  NOT NULL,
    [indFee] bit  NOT NULL,
    [indYesOrNo] bit  NOT NULL,
    [facilityName] nvarchar(max)  NULL,
    [number] int  NOT NULL,
    [distance] int  NOT NULL,
    [ageFrom] int  NOT NULL,
    [ageTo] int  NOT NULL,
    [currency] nvarchar(max)  NULL,
    [applicationType] nvarchar(max)  NULL
);
GO

-- Creating table 'HotelPaymentDetails'
CREATE TABLE [dbo].[HotelPaymentDetails] (
    [clientID] varchar(50)  NOT NULL,
    [currency] varchar(50)  NOT NULL,
    [holderName] varchar(50)  NOT NULL,
    [number] varchar(50)  NOT NULL,
    [paymentAmount] decimal(18,0)  NOT NULL,
    [responseCode] varchar(50)  NOT NULL,
    [responseText] varchar(50)  NOT NULL,
    [txnReference] varchar(50)  NOT NULL,
    [type] varchar(50)  NOT NULL
);
GO

-- Creating table 'HotelPhoneReps'
CREATE TABLE [dbo].[HotelPhoneReps] (
    [HotelPhoneRepID] bigint IDENTITY(1,1) NOT NULL,
    [HotelCode] int  NOT NULL,
    [phoneNumber] nvarchar(max)  NULL,
    [phoneType] nvarchar(max)  NULL
);
GO

-- Creating table 'HotelReps'
CREATE TABLE [dbo].[HotelReps] (
    [HotelRepID] bigint IDENTITY(1,1) NOT NULL,
    [code] int  NOT NULL,
    [name] nvarchar(max)  NULL,
    [description] nvarchar(max)  NULL,
    [countryCode] nvarchar(max)  NULL,
    [destinationCode] nvarchar(max)  NULL,
    [zoneCode] smallint  NOT NULL,
    [categoryCode] nvarchar(max)  NULL,
    [categoryGroupCode] nvarchar(max)  NULL,
    [chainCode] nvarchar(max)  NULL,
    [accommodationTypeCode] nvarchar(max)  NULL,
    [address] nvarchar(max)  NULL,
    [postalCode] nvarchar(max)  NULL,
    [city] nvarchar(max)  NULL,
    [email] nvarchar(max)  NULL,
    [license] nvarchar(max)  NULL,
    [giataCode] int  NOT NULL,
    [hotelstar] int  NOT NULL,
    [imagepath] nvarchar(max)  NULL,
    [destinationName] nvarchar(max)  NULL,
    [categoryName] nvarchar(max)  NULL,
    [hotel_board_basis] nvarchar(max)  NULL,
    [phoneNumber] varchar(50)  NULL
);
GO

-- Creating table 'HotelRoomFacilityReps'
CREATE TABLE [dbo].[HotelRoomFacilityReps] (
    [HotelRoomFacilityRepID] bigint IDENTITY(1,1) NOT NULL,
    [HotelCode] int  NOT NULL,
    [roomCode] nvarchar(max)  NULL,
    [facilityCode] int  NOT NULL,
    [facilityGroupCode] int  NOT NULL,
    [description] nvarchar(max)  NULL,
    [indLogic] bit  NOT NULL,
    [indFee] bit  NOT NULL,
    [number] int  NOT NULL,
    [order] int  NOT NULL,
    [indYesOrNo] bit  NOT NULL
);
GO

-- Creating table 'HotelRoomReps'
CREATE TABLE [dbo].[HotelRoomReps] (
    [HotelRoomRepID] bigint IDENTITY(1,1) NOT NULL,
    [HotelCode] int  NOT NULL,
    [roomCode] nvarchar(max)  NULL,
    [description] nvarchar(max)  NULL,
    [roomType] nvarchar(max)  NULL,
    [characteristicCode] nvarchar(max)  NULL
);
GO

-- Creating table 'HotelRoomStayFacilityReps'
CREATE TABLE [dbo].[HotelRoomStayFacilityReps] (
    [HotelRoomStayFacilityRepID] bigint IDENTITY(1,1) NOT NULL,
    [HotelCode] int  NOT NULL,
    [facilityCode] int  NOT NULL,
    [facilityGroupCode] int  NOT NULL,
    [description] nvarchar(max)  NULL,
    [number] int  NOT NULL
);
GO

-- Creating table 'HotelRoomStayReps'
CREATE TABLE [dbo].[HotelRoomStayReps] (
    [HotelRoomStayRepID] bigint IDENTITY(1,1) NOT NULL,
    [HotelCode] int  NOT NULL,
    [roomCode] nvarchar(max)  NULL,
    [stayType] nvarchar(max)  NULL,
    [order] nvarchar(max)  NULL,
    [description] nvarchar(max)  NULL
);
GO

-- Creating table 'HotelSegmentReps'
CREATE TABLE [dbo].[HotelSegmentReps] (
    [HotelSegmentRepID] bigint IDENTITY(1,1) NOT NULL,
    [HotelCode] int  NOT NULL,
    [code] int  NOT NULL,
    [description] nvarchar(max)  NULL
);
GO

-- Creating table 'HotelTerminalReps'
CREATE TABLE [dbo].[HotelTerminalReps] (
    [HotelTerminalRepID] bigint IDENTITY(1,1) NOT NULL,
    [code] nvarchar(max)  NULL,
    [type] nvarchar(max)  NULL,
    [country] nvarchar(max)  NULL,
    [name] nvarchar(max)  NULL,
    [description] nvarchar(max)  NULL,
    [hotelcode] int  NOT NULL,
    [distance] int  NOT NULL
);
GO

-- Creating table 'HRZAminities'
CREATE TABLE [dbo].[HRZAminities] (
    [AminityID] bigint IDENTITY(1,1) NOT NULL,
    [RoomID] nvarchar(50)  NOT NULL,
    [Name] nvarchar(50)  NULL,
    [Type] nvarchar(10)  NULL,
    [HotelCode] nvarchar(50)  NULL
);
GO

-- Creating table 'HRZHotelImages'
CREATE TABLE [dbo].[HRZHotelImages] (
    [HotelImageID] bigint IDENTITY(1,1) NOT NULL,
    [HotelCode] nvarchar(50)  NULL,
    [HotelImage] varbinary(max)  NULL
);
GO

-- Creating table 'HRZHotelSuppliers'
CREATE TABLE [dbo].[HRZHotelSuppliers] (
    [HotelSupplierID] bigint IDENTITY(1,1) NOT NULL,
    [HotelCode] nvarchar(50)  NULL,
    [Address] nvarchar(50)  NULL,
    [HotelName] nvarchar(max)  NULL,
    [StarRating] nvarchar(50)  NULL,
    [ContactPerson] nvarchar(50)  NULL,
    [Owner] nvarchar(max)  NULL,
    [Email] nvarchar(50)  NULL,
    [Telephone] nvarchar(50)  NULL,
    [Longitude] nvarchar(50)  NULL,
    [Latitude] nvarchar(50)  NULL,
    [Description] nvarchar(50)  NULL,
    [IsInternetAvailable] nvarchar(50)  NULL,
    [TypeOfInternet] nvarchar(50)  NULL,
    [WhereIsInternet] nvarchar(50)  NULL,
    [IsParkingAvailable] nvarchar(50)  NULL,
    [ParkingPrivateOrOnSite] nvarchar(50)  NULL,
    [ReservationNeedForParking] nvarchar(50)  NULL,
    [PriceForParking] nvarchar(50)  NULL,
    [AccomodateChildren] nvarchar(50)  NULL,
    [PetsAllowed] nvarchar(50)  NULL,
    [SpeakingLanguage] nvarchar(50)  NULL,
    [CheckInTime] nvarchar(50)  NULL,
    [CheckOutTime] nvarchar(50)  NULL,
    [IsLocal] nvarchar(50)  NULL
);
GO

-- Creating table 'HRZLanguages'
CREATE TABLE [dbo].[HRZLanguages] (
    [LanguageID] bigint IDENTITY(1,1) NOT NULL,
    [HotelCode] nvarchar(50)  NULL,
    [Language] nvarchar(50)  NULL
);
GO

-- Creating table 'HRZNearbyPlaces'
CREATE TABLE [dbo].[HRZNearbyPlaces] (
    [NearbyPlacesID] bigint IDENTITY(1,1) NOT NULL,
    [RoomID] nvarchar(50)  NOT NULL,
    [NearbyName] nvarchar(50)  NULL,
    [NearbyDistance] nvarchar(50)  NULL,
    [HotelCode] nvarchar(50)  NULL
);
GO

-- Creating table 'HRZPayments'
CREATE TABLE [dbo].[HRZPayments] (
    [PaymentID] bigint IDENTITY(1,1) NOT NULL,
    [BookingNo] nvarchar(50)  NULL,
    [Amount] decimal(18,0)  NOT NULL,
    [Tax] decimal(18,0)  NOT NULL,
    [TotalAmount] decimal(18,0)  NOT NULL,
    [RoomId] nvarchar(50)  NULL,
    [TelephoneNo] int  NOT NULL,
    [Name] nvarchar(50)  NULL,
    [Email] nvarchar(50)  NULL,
    [RoomNo] nvarchar(50)  NULL,
    [CreditCardNo] nvarchar(50)  NULL
);
GO

-- Creating table 'HRZPromotions'
CREATE TABLE [dbo].[HRZPromotions] (
    [PromotionID] bigint IDENTITY(1,1) NOT NULL,
    [PromotionType] nvarchar(50)  NULL,
    [DateFrom] nvarchar(50)  NULL,
    [DateTo] nvarchar(50)  NULL,
    [DiscountValue] nvarchar(50)  NULL,
    [DiscountPercentage] nvarchar(50)  NULL,
    [RoomID] nvarchar(50)  NULL,
    [HotelCode] nvarchar(50)  NULL,
    [Hours] nvarchar(50)  NULL
);
GO

-- Creating table 'HRZRoomBookings'
CREATE TABLE [dbo].[HRZRoomBookings] (
    [RoomBookingID] bigint IDENTITY(1,1) NOT NULL,
    [BookingNo] nvarchar(50)  NOT NULL,
    [RoomID] nvarchar(50)  NOT NULL,
    [DateFrom] nvarchar(50)  NULL,
    [DateTo] nvarchar(50)  NULL,
    [Adult1FirstName] nvarchar(max)  NULL,
    [Adult1LastName] nvarchar(max)  NULL,
    [Adult1Telephone] nvarchar(50)  NULL,
    [Adult1Email] nvarchar(max)  NULL,
    [Adult1NICNo] nvarchar(50)  NULL,
    [Adult1Address] nvarchar(50)  NULL,
    [Adult2FirstName] nvarchar(max)  NULL,
    [Adult2LastName] nvarchar(max)  NULL,
    [Adult2Telephone] nvarchar(max)  NULL,
    [Adult2Email] nvarchar(50)  NULL,
    [Adult2NICNo] nvarchar(50)  NULL,
    [Adult2Address] nvarchar(50)  NULL,
    [Adult3FirstName] nvarchar(max)  NULL,
    [Adult3LastName] nvarchar(max)  NULL,
    [Adult3Telephone] nvarchar(50)  NULL,
    [Adult3Email] nvarchar(50)  NULL,
    [Adult3NICNo] nvarchar(50)  NULL,
    [Adult3Address] nvarchar(max)  NULL,
    [Adult4FirstName] nvarchar(max)  NULL,
    [Adult4LastName] nvarchar(max)  NULL,
    [Adult4Telephone] nvarchar(50)  NULL,
    [Adult4Email] nvarchar(50)  NULL,
    [Adult4NICNo] nvarchar(50)  NULL,
    [Adult4Address] nvarchar(50)  NULL,
    [Child1Name] nvarchar(max)  NULL,
    [Child1Age] nvarchar(50)  NULL,
    [Chil21Name] nvarchar(max)  NULL,
    [child2Age] nvarchar(50)  NULL,
    [Chidl3Name] nvarchar(50)  NULL,
    [Child3Age] nvarchar(50)  NULL,
    [IsActive] bit  NULL,
    [Price] nvarchar(50)  NULL,
    [HotelCode] nvarchar(50)  NULL,
    [Ispaid] int  NOT NULL
);
GO

-- Creating table 'HRZRoomMasters'
CREATE TABLE [dbo].[HRZRoomMasters] (
    [RoomMasterID] bigint IDENTITY(1,1) NOT NULL,
    [HotelName] nvarchar(50)  NULL,
    [Address] nvarchar(50)  NULL,
    [RoomID] nvarchar(50)  NOT NULL,
    [Refference] nvarchar(50)  NULL,
    [BoardType] nvarchar(50)  NULL,
    [RoomType] nvarchar(50)  NULL,
    [Price] nvarchar(50)  NULL,
    [HotelCode] nvarchar(50)  NULL
);
GO

-- Creating table 'HRZRoomUnavailables'
CREATE TABLE [dbo].[HRZRoomUnavailables] (
    [RoomUnavailableID] bigint IDENTITY(1,1) NOT NULL,
    [RoomID] nvarchar(50)  NULL,
    [Date] nvarchar(50)  NULL,
    [HotelCode] nvarchar(50)  NULL
);
GO

-- Creating table 'HRZUsers'
CREATE TABLE [dbo].[HRZUsers] (
    [UserID] bigint IDENTITY(1,1) NOT NULL,
    [UserName] nvarchar(50)  NOT NULL,
    [PassWord] nvarchar(50)  NOT NULL,
    [UserType] int  NULL,
    [HotelCode] nvarchar(50)  NULL,
    [CountryCode] nvarchar(50)  NULL,
    [CityCode] nvarchar(50)  NULL
);
GO

-- Creating table 'ImageReps'
CREATE TABLE [dbo].[ImageReps] (
    [ImageRepID] bigint IDENTITY(1,1) NOT NULL,
    [HotelCode] int  NOT NULL,
    [imageTypeCode] nvarchar(max)  NULL,
    [hotel] nvarchar(max)  NULL,
    [path] nvarchar(max)  NULL,
    [roomCode] nvarchar(max)  NULL,
    [roomType] nvarchar(max)  NULL,
    [characteristicCode] nvarchar(max)  NULL,
    [order] int  NOT NULL
);
GO

-- Creating table 'ImageTypeReps'
CREATE TABLE [dbo].[ImageTypeReps] (
    [ImageTypeRepID] bigint IDENTITY(1,1) NOT NULL,
    [code] nvarchar(max)  NULL,
    [description] nvarchar(max)  NULL
);
GO

-- Creating table 'IssueReps'
CREATE TABLE [dbo].[IssueReps] (
    [IssueRepID] bigint IDENTITY(1,1) NOT NULL,
    [code] nvarchar(max)  NULL,
    [type] nvarchar(max)  NULL,
    [description] nvarchar(max)  NULL,
    [name] nvarchar(max)  NULL,
    [alternative] bit  NOT NULL
);
GO

-- Creating table 'LanguageReps'
CREATE TABLE [dbo].[LanguageReps] (
    [LanguageRepID] bigint IDENTITY(1,1) NOT NULL,
    [code] nvarchar(max)  NULL,
    [name] nvarchar(max)  NULL,
    [description] nvarchar(max)  NULL
);
GO

-- Creating table 'PromotionReps'
CREATE TABLE [dbo].[PromotionReps] (
    [PromotionRepID] bigint IDENTITY(1,1) NOT NULL,
    [code] nvarchar(max)  NULL,
    [description] nvarchar(max)  NULL,
    [name] nvarchar(max)  NULL
);
GO

-- Creating table 'RateCommentReps'
CREATE TABLE [dbo].[RateCommentReps] (
    [RateCommentRepID] bigint IDENTITY(1,1) NOT NULL,
    [HotelCode] int  NOT NULL,
    [dateEnd] datetime  NOT NULL,
    [dateStart] datetime  NOT NULL,
    [description] nvarchar(max)  NULL
);
GO

-- Creating table 'RoomReps'
CREATE TABLE [dbo].[RoomReps] (
    [RoomRepID] bigint IDENTITY(1,1) NOT NULL,
    [code] nvarchar(max)  NULL,
    [HotelCode] int  NOT NULL,
    [type] nvarchar(max)  NULL,
    [characteristic] nvarchar(max)  NULL,
    [minPax] int  NOT NULL,
    [maxPax] int  NOT NULL,
    [maxAdults] int  NOT NULL,
    [maxChildren] int  NOT NULL,
    [minAdults] int  NOT NULL,
    [description] nvarchar(max)  NULL,
    [typeDescription] nvarchar(max)  NULL,
    [characteristicDescription] nvarchar(max)  NULL
);
GO

-- Creating table 'SegmentReps'
CREATE TABLE [dbo].[SegmentReps] (
    [SegmentRepID] bigint IDENTITY(1,1) NOT NULL,
    [HotelCode] int  NOT NULL,
    [code] int  NOT NULL,
    [description] nvarchar(max)  NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'TerminalReps'
CREATE TABLE [dbo].[TerminalReps] (
    [TerminalRepID] bigint IDENTITY(1,1) NOT NULL,
    [code] nvarchar(max)  NULL,
    [type] nvarchar(max)  NULL,
    [country] nvarchar(max)  NULL,
    [name] nvarchar(max)  NULL,
    [description] nvarchar(max)  NULL
);
GO

-- Creating table 'ZoneReps'
CREATE TABLE [dbo].[ZoneReps] (
    [ZoneRepID] bigint IDENTITY(1,1) NOT NULL,
    [zoneCode] int  NOT NULL,
    [name] nvarchar(max)  NULL,
    [Description_ContentID] bigint  NULL
);
GO

-- Creating table 'AgentLogins'
CREATE TABLE [dbo].[AgentLogins] (
    [UserID] varchar(50)  NULL,
    [Name] varchar(255)  NULL,
    [Mobile] varchar(255)  NULL,
    [Email] varchar(255)  NULL,
    [AgentLoginID] bigint IDENTITY(1,1) NOT NULL,
    [Password] varchar(255)  NULL,
    [UserType] decimal(18,0)  NULL
);
GO

-- Creating table 'AgentMarkups'
CREATE TABLE [dbo].[AgentMarkups] (
    [UserID] varchar(50)  NULL,
    [Amount] decimal(18,0)  NULL,
    [Presentage] decimal(18,0)  NULL,
    [AgentMarkupID] bigint IDENTITY(1,1) NOT NULL,
    [Email] varchar(50)  NULL,
    [password] varchar(50)  NULL
);
GO

-- Creating table 'CurrencyRates'
CREATE TABLE [dbo].[CurrencyRates] (
    [Currency] nvarchar(max)  NULL,
    [Value] decimal(18,0)  NULL,
    [CurrencyRateID] bigint IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'FacilitySumReps'
CREATE TABLE [dbo].[FacilitySumReps] (
    [HotelCode] int  NOT NULL,
    [facilityCode] int  NULL,
    [DESCRIPTION] nvarchar(max)  NULL,
    [facilityGroupCode] int  NULL,
    [fgdescription] nvarchar(max)  NULL,
    [IDX] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'FacilitySumReps_back'
CREATE TABLE [dbo].[FacilitySumReps_back] (
    [HotelCode] int  NOT NULL,
    [facilityCode] int  NULL,
    [DESCRIPTION] nvarchar(max)  NULL,
    [facilityGroupCode] int  NULL,
    [fgdescription] nvarchar(max)  NULL,
    [IDX] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'FacilitySumRepsBackups'
CREATE TABLE [dbo].[FacilitySumRepsBackups] (
    [HotelCode] int  NOT NULL,
    [facilityCode] int  NULL,
    [DESCRIPTION] nvarchar(max)  NULL,
    [facilityGroupCode] int  NULL,
    [fgdescription] nvarchar(max)  NULL,
    [IDX] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'HRZUserPrivileges'
CREATE TABLE [dbo].[HRZUserPrivileges] (
    [HRZUserPrivilegesID] bigint  NULL,
    [UserType] int  NOT NULL,
    [FormID] bigint  NOT NULL,
    [IsAccess] bigint  NOT NULL,
    [IsDelete] bigint  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [MigrationId], [ContextKey] in table 'C__MigrationHistory'
ALTER TABLE [dbo].[C__MigrationHistory]
ADD CONSTRAINT [PK_C__MigrationHistory]
    PRIMARY KEY CLUSTERED ([MigrationId], [ContextKey] ASC);
GO

-- Creating primary key on [AccommodationRepID] in table 'AccommodationReps'
ALTER TABLE [dbo].[AccommodationReps]
ADD CONSTRAINT [PK_AccommodationReps]
    PRIMARY KEY CLUSTERED ([AccommodationRepID] ASC);
GO

-- Creating primary key on [BoardRepID] in table 'BoardReps'
ALTER TABLE [dbo].[BoardReps]
ADD CONSTRAINT [PK_BoardReps]
    PRIMARY KEY CLUSTERED ([BoardRepID] ASC);
GO

-- Creating primary key on [CategoryRepID] in table 'CategoryReps'
ALTER TABLE [dbo].[CategoryReps]
ADD CONSTRAINT [PK_CategoryReps]
    PRIMARY KEY CLUSTERED ([CategoryRepID] ASC);
GO

-- Creating primary key on [ChainRepID] in table 'ChainReps'
ALTER TABLE [dbo].[ChainReps]
ADD CONSTRAINT [PK_ChainReps]
    PRIMARY KEY CLUSTERED ([ChainRepID] ASC);
GO

-- Creating primary key on [ContentID] in table 'Contents'
ALTER TABLE [dbo].[Contents]
ADD CONSTRAINT [PK_Contents]
    PRIMARY KEY CLUSTERED ([ContentID] ASC);
GO

-- Creating primary key on [CountryRepID] in table 'CountryReps'
ALTER TABLE [dbo].[CountryReps]
ADD CONSTRAINT [PK_CountryReps]
    PRIMARY KEY CLUSTERED ([CountryRepID] ASC);
GO

-- Creating primary key on [CurrencyRepID] in table 'CurrencyReps'
ALTER TABLE [dbo].[CurrencyReps]
ADD CONSTRAINT [PK_CurrencyReps]
    PRIMARY KEY CLUSTERED ([CurrencyRepID] ASC);
GO

-- Creating primary key on [DestinationsRepID] in table 'DestinationsReps'
ALTER TABLE [dbo].[DestinationsReps]
ADD CONSTRAINT [PK_DestinationsReps]
    PRIMARY KEY CLUSTERED ([DestinationsRepID] ASC);
GO

-- Creating primary key on [DocumentRepID] in table 'DocumentReps'
ALTER TABLE [dbo].[DocumentReps]
ADD CONSTRAINT [PK_DocumentReps]
    PRIMARY KEY CLUSTERED ([DocumentRepID] ASC);
GO

-- Creating primary key on [FacilityGroupRepID] in table 'FacilityGroupReps'
ALTER TABLE [dbo].[FacilityGroupReps]
ADD CONSTRAINT [PK_FacilityGroupReps]
    PRIMARY KEY CLUSTERED ([FacilityGroupRepID] ASC);
GO

-- Creating primary key on [FacilityRepID] in table 'FacilityReps'
ALTER TABLE [dbo].[FacilityReps]
ADD CONSTRAINT [PK_FacilityReps]
    PRIMARY KEY CLUSTERED ([FacilityRepID] ASC);
GO

-- Creating primary key on [FacilityTypeRepID] in table 'FacilityTypeReps'
ALTER TABLE [dbo].[FacilityTypeReps]
ADD CONSTRAINT [PK_FacilityTypeReps]
    PRIMARY KEY CLUSTERED ([FacilityTypeRepID] ASC);
GO

-- Creating primary key on [GeoLocationRepID] in table 'GeoLocationReps'
ALTER TABLE [dbo].[GeoLocationReps]
ADD CONSTRAINT [PK_GeoLocationReps]
    PRIMARY KEY CLUSTERED ([GeoLocationRepID] ASC);
GO

-- Creating primary key on [GroupCategoryRepID] in table 'GroupCategoryReps'
ALTER TABLE [dbo].[GroupCategoryReps]
ADD CONSTRAINT [PK_GroupCategoryReps]
    PRIMARY KEY CLUSTERED ([GroupCategoryRepID] ASC);
GO

-- Creating primary key on [GroupZoneRepID] in table 'GroupZoneReps'
ALTER TABLE [dbo].[GroupZoneReps]
ADD CONSTRAINT [PK_GroupZoneReps]
    PRIMARY KEY CLUSTERED ([GroupZoneRepID] ASC);
GO

-- Creating primary key on [HotelBoardCodesRepID] in table 'HotelBoardCodesReps'
ALTER TABLE [dbo].[HotelBoardCodesReps]
ADD CONSTRAINT [PK_HotelBoardCodesReps]
    PRIMARY KEY CLUSTERED ([HotelBoardCodesRepID] ASC);
GO

-- Creating primary key on [HotelFacilityRepID] in table 'HotelFacilityReps'
ALTER TABLE [dbo].[HotelFacilityReps]
ADD CONSTRAINT [PK_HotelFacilityReps]
    PRIMARY KEY CLUSTERED ([HotelFacilityRepID] ASC);
GO

-- Creating primary key on [clientID] in table 'HotelPaymentDetails'
ALTER TABLE [dbo].[HotelPaymentDetails]
ADD CONSTRAINT [PK_HotelPaymentDetails]
    PRIMARY KEY CLUSTERED ([clientID] ASC);
GO

-- Creating primary key on [HotelPhoneRepID] in table 'HotelPhoneReps'
ALTER TABLE [dbo].[HotelPhoneReps]
ADD CONSTRAINT [PK_HotelPhoneReps]
    PRIMARY KEY CLUSTERED ([HotelPhoneRepID] ASC);
GO

-- Creating primary key on [HotelRepID] in table 'HotelReps'
ALTER TABLE [dbo].[HotelReps]
ADD CONSTRAINT [PK_HotelReps]
    PRIMARY KEY CLUSTERED ([HotelRepID] ASC);
GO

-- Creating primary key on [HotelRoomFacilityRepID] in table 'HotelRoomFacilityReps'
ALTER TABLE [dbo].[HotelRoomFacilityReps]
ADD CONSTRAINT [PK_HotelRoomFacilityReps]
    PRIMARY KEY CLUSTERED ([HotelRoomFacilityRepID] ASC);
GO

-- Creating primary key on [HotelRoomRepID] in table 'HotelRoomReps'
ALTER TABLE [dbo].[HotelRoomReps]
ADD CONSTRAINT [PK_HotelRoomReps]
    PRIMARY KEY CLUSTERED ([HotelRoomRepID] ASC);
GO

-- Creating primary key on [HotelRoomStayFacilityRepID] in table 'HotelRoomStayFacilityReps'
ALTER TABLE [dbo].[HotelRoomStayFacilityReps]
ADD CONSTRAINT [PK_HotelRoomStayFacilityReps]
    PRIMARY KEY CLUSTERED ([HotelRoomStayFacilityRepID] ASC);
GO

-- Creating primary key on [HotelRoomStayRepID] in table 'HotelRoomStayReps'
ALTER TABLE [dbo].[HotelRoomStayReps]
ADD CONSTRAINT [PK_HotelRoomStayReps]
    PRIMARY KEY CLUSTERED ([HotelRoomStayRepID] ASC);
GO

-- Creating primary key on [HotelSegmentRepID] in table 'HotelSegmentReps'
ALTER TABLE [dbo].[HotelSegmentReps]
ADD CONSTRAINT [PK_HotelSegmentReps]
    PRIMARY KEY CLUSTERED ([HotelSegmentRepID] ASC);
GO

-- Creating primary key on [HotelTerminalRepID] in table 'HotelTerminalReps'
ALTER TABLE [dbo].[HotelTerminalReps]
ADD CONSTRAINT [PK_HotelTerminalReps]
    PRIMARY KEY CLUSTERED ([HotelTerminalRepID] ASC);
GO

-- Creating primary key on [AminityID] in table 'HRZAminities'
ALTER TABLE [dbo].[HRZAminities]
ADD CONSTRAINT [PK_HRZAminities]
    PRIMARY KEY CLUSTERED ([AminityID] ASC);
GO

-- Creating primary key on [HotelImageID] in table 'HRZHotelImages'
ALTER TABLE [dbo].[HRZHotelImages]
ADD CONSTRAINT [PK_HRZHotelImages]
    PRIMARY KEY CLUSTERED ([HotelImageID] ASC);
GO

-- Creating primary key on [HotelSupplierID] in table 'HRZHotelSuppliers'
ALTER TABLE [dbo].[HRZHotelSuppliers]
ADD CONSTRAINT [PK_HRZHotelSuppliers]
    PRIMARY KEY CLUSTERED ([HotelSupplierID] ASC);
GO

-- Creating primary key on [LanguageID] in table 'HRZLanguages'
ALTER TABLE [dbo].[HRZLanguages]
ADD CONSTRAINT [PK_HRZLanguages]
    PRIMARY KEY CLUSTERED ([LanguageID] ASC);
GO

-- Creating primary key on [NearbyPlacesID] in table 'HRZNearbyPlaces'
ALTER TABLE [dbo].[HRZNearbyPlaces]
ADD CONSTRAINT [PK_HRZNearbyPlaces]
    PRIMARY KEY CLUSTERED ([NearbyPlacesID] ASC);
GO

-- Creating primary key on [PaymentID] in table 'HRZPayments'
ALTER TABLE [dbo].[HRZPayments]
ADD CONSTRAINT [PK_HRZPayments]
    PRIMARY KEY CLUSTERED ([PaymentID] ASC);
GO

-- Creating primary key on [PromotionID] in table 'HRZPromotions'
ALTER TABLE [dbo].[HRZPromotions]
ADD CONSTRAINT [PK_HRZPromotions]
    PRIMARY KEY CLUSTERED ([PromotionID] ASC);
GO

-- Creating primary key on [RoomBookingID] in table 'HRZRoomBookings'
ALTER TABLE [dbo].[HRZRoomBookings]
ADD CONSTRAINT [PK_HRZRoomBookings]
    PRIMARY KEY CLUSTERED ([RoomBookingID] ASC);
GO

-- Creating primary key on [RoomMasterID] in table 'HRZRoomMasters'
ALTER TABLE [dbo].[HRZRoomMasters]
ADD CONSTRAINT [PK_HRZRoomMasters]
    PRIMARY KEY CLUSTERED ([RoomMasterID] ASC);
GO

-- Creating primary key on [RoomUnavailableID] in table 'HRZRoomUnavailables'
ALTER TABLE [dbo].[HRZRoomUnavailables]
ADD CONSTRAINT [PK_HRZRoomUnavailables]
    PRIMARY KEY CLUSTERED ([RoomUnavailableID] ASC);
GO

-- Creating primary key on [UserID] in table 'HRZUsers'
ALTER TABLE [dbo].[HRZUsers]
ADD CONSTRAINT [PK_HRZUsers]
    PRIMARY KEY CLUSTERED ([UserID] ASC);
GO

-- Creating primary key on [ImageRepID] in table 'ImageReps'
ALTER TABLE [dbo].[ImageReps]
ADD CONSTRAINT [PK_ImageReps]
    PRIMARY KEY CLUSTERED ([ImageRepID] ASC);
GO

-- Creating primary key on [ImageTypeRepID] in table 'ImageTypeReps'
ALTER TABLE [dbo].[ImageTypeReps]
ADD CONSTRAINT [PK_ImageTypeReps]
    PRIMARY KEY CLUSTERED ([ImageTypeRepID] ASC);
GO

-- Creating primary key on [IssueRepID] in table 'IssueReps'
ALTER TABLE [dbo].[IssueReps]
ADD CONSTRAINT [PK_IssueReps]
    PRIMARY KEY CLUSTERED ([IssueRepID] ASC);
GO

-- Creating primary key on [LanguageRepID] in table 'LanguageReps'
ALTER TABLE [dbo].[LanguageReps]
ADD CONSTRAINT [PK_LanguageReps]
    PRIMARY KEY CLUSTERED ([LanguageRepID] ASC);
GO

-- Creating primary key on [PromotionRepID] in table 'PromotionReps'
ALTER TABLE [dbo].[PromotionReps]
ADD CONSTRAINT [PK_PromotionReps]
    PRIMARY KEY CLUSTERED ([PromotionRepID] ASC);
GO

-- Creating primary key on [RateCommentRepID] in table 'RateCommentReps'
ALTER TABLE [dbo].[RateCommentReps]
ADD CONSTRAINT [PK_RateCommentReps]
    PRIMARY KEY CLUSTERED ([RateCommentRepID] ASC);
GO

-- Creating primary key on [RoomRepID] in table 'RoomReps'
ALTER TABLE [dbo].[RoomReps]
ADD CONSTRAINT [PK_RoomReps]
    PRIMARY KEY CLUSTERED ([RoomRepID] ASC);
GO

-- Creating primary key on [SegmentRepID] in table 'SegmentReps'
ALTER TABLE [dbo].[SegmentReps]
ADD CONSTRAINT [PK_SegmentReps]
    PRIMARY KEY CLUSTERED ([SegmentRepID] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [TerminalRepID] in table 'TerminalReps'
ALTER TABLE [dbo].[TerminalReps]
ADD CONSTRAINT [PK_TerminalReps]
    PRIMARY KEY CLUSTERED ([TerminalRepID] ASC);
GO

-- Creating primary key on [ZoneRepID] in table 'ZoneReps'
ALTER TABLE [dbo].[ZoneReps]
ADD CONSTRAINT [PK_ZoneReps]
    PRIMARY KEY CLUSTERED ([ZoneRepID] ASC);
GO

-- Creating primary key on [AgentLoginID] in table 'AgentLogins'
ALTER TABLE [dbo].[AgentLogins]
ADD CONSTRAINT [PK_AgentLogins]
    PRIMARY KEY CLUSTERED ([AgentLoginID] ASC);
GO

-- Creating primary key on [AgentMarkupID] in table 'AgentMarkups'
ALTER TABLE [dbo].[AgentMarkups]
ADD CONSTRAINT [PK_AgentMarkups]
    PRIMARY KEY CLUSTERED ([AgentMarkupID] ASC);
GO

-- Creating primary key on [CurrencyRateID] in table 'CurrencyRates'
ALTER TABLE [dbo].[CurrencyRates]
ADD CONSTRAINT [PK_CurrencyRates]
    PRIMARY KEY CLUSTERED ([CurrencyRateID] ASC);
GO

-- Creating primary key on [HotelCode], [IDX] in table 'FacilitySumReps'
ALTER TABLE [dbo].[FacilitySumReps]
ADD CONSTRAINT [PK_FacilitySumReps]
    PRIMARY KEY CLUSTERED ([HotelCode], [IDX] ASC);
GO

-- Creating primary key on [HotelCode], [IDX] in table 'FacilitySumReps_back'
ALTER TABLE [dbo].[FacilitySumReps_back]
ADD CONSTRAINT [PK_FacilitySumReps_back]
    PRIMARY KEY CLUSTERED ([HotelCode], [IDX] ASC);
GO

-- Creating primary key on [HotelCode], [IDX] in table 'FacilitySumRepsBackups'
ALTER TABLE [dbo].[FacilitySumRepsBackups]
ADD CONSTRAINT [PK_FacilitySumRepsBackups]
    PRIMARY KEY CLUSTERED ([HotelCode], [IDX] ASC);
GO

-- Creating primary key on [UserType], [FormID], [IsAccess], [IsDelete] in table 'HRZUserPrivileges'
ALTER TABLE [dbo].[HRZUserPrivileges]
ADD CONSTRAINT [PK_HRZUserPrivileges]
    PRIMARY KEY CLUSTERED ([UserType], [FormID], [IsAccess], [IsDelete] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Description_ContentID] in table 'ZoneReps'
ALTER TABLE [dbo].[ZoneReps]
ADD CONSTRAINT [FK_dbo_ZoneReps_dbo_Contents_Description_ContentID]
    FOREIGN KEY ([Description_ContentID])
    REFERENCES [dbo].[Contents]
        ([ContentID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_ZoneReps_dbo_Contents_Description_ContentID'
CREATE INDEX [IX_FK_dbo_ZoneReps_dbo_Contents_Description_ContentID]
ON [dbo].[ZoneReps]
    ([Description_ContentID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------