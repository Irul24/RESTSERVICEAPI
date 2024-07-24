USE [mydb]
GO

/****** Object: Table [dbo].[produk] Script Date: 7/24/2024 2:08:28 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[produk] (
    [id]        INT            IDENTITY (1, 1) NOT NULL,
    [nama]      NVARCHAR (50)  NULL,
    [deskripsi] NVARCHAR (MAX) NULL,
    [harga]     INT            NULL,
    [stok]      INT            NULL
);


