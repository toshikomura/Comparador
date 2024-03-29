IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EditarProduto]') AND type in (N'P', N'PC'))
    EXEC('CREATE PROCEDURE EditarProduto AS')    
GO
ALTER PROCEDURE [dbo].[EditarProduto]
	@ID int,
	@Nome varchar(255),
	@Valor int,
	@Garantia int,
	@GastoEnergiaHora int
AS
BEGIN
	update	Produto
	set		Nome = @Nome,
			Valor = @Valor,
			Garantia = @Garantia,
			GastoEnergiaHora = @GastoEnergiaHora
	where	ID = @ID
END
