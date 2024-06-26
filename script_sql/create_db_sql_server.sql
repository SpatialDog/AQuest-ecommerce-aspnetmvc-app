CREATE TABLE [Coupons] (
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](10) NOT NULL,
	[Active] [bit] NOT NULL,
	[MinPrice] [decimal](18, 2) NOT NULL,
	[MaxPrice] [decimal](18, 2) NULL,
	[AssociatedProductIds] [nvarchar](max) NULL,
 	CONSTRAINT [PK_Coupons] PRIMARY KEY 
	(
		[Id] ASC
	)
)

CREATE TABLE [Products] (
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[StockQty] [int] NOT NULL,
	[Active] [bit] NOT NULL,
 	CONSTRAINT [PK_Products] PRIMARY KEY
	(
		[Id] ASC
	)
)

CREATE UNIQUE NONCLUSTERED INDEX [IX_UniqueCode_Coupons] ON [Coupons]
(
	[Code] ASC
)

ALTER TABLE [Coupons] ADD  CONSTRAINT [DF_Coupons_Active]  DEFAULT ((1)) FOR [Active]

ALTER TABLE [Coupons] ADD  CONSTRAINT [DF_Coupons_MinPrice]  DEFAULT ((0)) FOR [MinPrice]

ALTER TABLE [Products] ADD  CONSTRAINT [DF_Products_StockQty]  DEFAULT ((0)) FOR [StockQty]

ALTER TABLE [Products] ADD  CONSTRAINT [DF_Products_Active]  DEFAULT ((1)) FOR [Active]
