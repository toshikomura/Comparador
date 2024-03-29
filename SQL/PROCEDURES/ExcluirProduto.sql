IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ExcluirProduto]') AND type in (N'P', N'PC'))
    EXEC('CREATE PROCEDURE ExcluirProduto AS')    
GO
ALTER PROCEDURE [dbo].[ExcluirProduto]
	@ID int
AS
BEGIN
	if exists(select * from Produto where ID = @ID)
	begin
		delete	Produto
		where	ID = @ID
	end
END