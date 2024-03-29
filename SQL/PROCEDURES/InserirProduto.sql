IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InserirProduto]') AND type in (N'P', N'PC'))
    EXEC('CREATE PROCEDURE InserirProduto AS')    
GO
ALTER PROCEDURE [dbo].[InserirProduto]
	@Nome varchar(255),
	@Valor int,
	@Garantia int,
	@GastoEnergiaHora int
AS
BEGIN
insert into Produto
values (@Nome, @Valor, @Garantia, @GastoEnergiaHora)
END
