CREATE TABLE [dbo].[Produto](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](255) NOT NULL,
	[Valor] [int] NOT NULL,
	[Garantia] [int] NOT NULL,
	[GastoEnergiaHora] [int] NOT NULL
) ON [PRIMARY]
GO