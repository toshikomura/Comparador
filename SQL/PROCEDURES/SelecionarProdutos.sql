IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SelecionarProdutos]') AND type in (N'P', N'PC'))
    EXEC('CREATE PROCEDURE SelecionarProdutos AS')    
GO
ALTER PROCEDURE [dbo].[SelecionarProdutos]
AS
SELECT * FROM Produto
GO;