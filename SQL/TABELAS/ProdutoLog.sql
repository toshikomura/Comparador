CREATE TABLE [dbo].[ProdutoLog](
	[IDLog] [int] IDENTITY(1,1) NOT NULL,
	[ID] [int] NOT NULL,
	[Nome] [varchar](255) NOT NULL,
	[Valor] [int] NOT NULL,
	[Garantia] [int] NOT NULL,
	[GastoEnergiaHora] [int] NOT NULL,
	[DataAlteracao] [datetime] NOT NULL,
	[Operacao] [varchar](1) NOT NULL
) ON [PRIMARY]
GO