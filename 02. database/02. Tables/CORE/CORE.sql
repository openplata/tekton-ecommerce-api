USE [db_tekton_ecommerce]
GO

PRINT (N'Create table bst_core.CORE')
GO

IF OBJECT_ID('bst_core.CORE', 'U') IS NULL
	CREATE TABLE [bst_core].[CORE](
		[OWNER_ID] int NOT NULL,
		[COMPANY_ID] int NOT NULL,
		[CORE_ID] [int] NOT NULL,

		[CORE_NAME] [varchar](100) NULL,
		[CODE] [varchar](10) NULL,
		[ORDERING] [varchar](10) NULL,		
		
		[COLOR] VARCHAR(50),
		[ICON] VARCHAR(100),
		[DATA1] VARCHAR(100),
		[DATA2] VARCHAR(100),
		[ADDITIONAL] VARCHAR(100),
		[OBSERVATION] VARCHAR(100),		

		[PARENT_ID] [int] NOT NULL,

		[IS_ACTIVE] [bit] NULL,		
		[HOST] [varchar](50) NULL,
		[CREATION_USER_ID] [int] NULL,
		[CREATION_DATE] [datetime] NULL,
		[UPDATE_USER_ID] [int] NULL,
		[UPDATE_DATE] [datetime] NULL,
	 CONSTRAINT [PK_CORE] PRIMARY KEY CLUSTERED 
	(
		[OWNER_ID] ASC,		
		[COMPANY_ID] ASC,		
		[CORE_ID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

GO