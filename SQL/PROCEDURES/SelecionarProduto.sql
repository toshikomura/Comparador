IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SelecionarProduto]') AND type in (N'P', N'PC'))
    EXEC('CREATE PROCEDURE SelecionarProduto AS')    
GO
ALTER PROCEDURE [dbo].[SelecionarProduto]
	@ID int
AS
BEGIN
SELECT * FROM Produto WHERE ID = @ID
END