USE [CRM]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Customers](
    [Id]            [UNIQUEIDENTIFIER]  NOT NULL,
    [FirstName]     [NVARCHAR](50)      NOT NULL,
    [MiddleName]    [NVARCHAR](50)      NULL,
    [LastName]      [NVARCHAR](50)      NOT NULL,
    [Email]         [NVARCHAR](200)     NOT NULL UNIQUE,
    [Phone]         [NVARCHAR](20)      NOT NULL,
    CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED (
        [Id] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Customers] ADD CONSTRAINT [DF_Customers_Id]  DEFAULT (NEWID()) FOR [Id]
GO
