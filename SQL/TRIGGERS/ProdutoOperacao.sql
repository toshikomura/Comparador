IF OBJECT_ID ('ProdutoOperacao', 'TR') IS NOT NULL
   DROP TRIGGER ProdutoOperacao;
GO
CREATE TRIGGER [dbo].[ProdutoOperacao]
ON [dbo].[Produto]
FOR UPDATE, DELETE
AS
IF EXISTS (
	SELECT * FROM Inserted
)
	-- UPDATE
	INSERT INTO ProdutoLog (ID, Nome, Valor, Garantia, GastoEnergiaHora, DataAlteracao, Operacao)
	SELECT d.Id, d.Nome, d.Valor, d.Garantia, d.GastoEnergiaHora, GETDATE(), 'U'
	FROM Deleted d
	INNER JOIN Inserted i ON i.Id = d.Id
ELSE
  -- DELETE
	INSERT INTO ProdutoLog (ID, Nome, Valor, Garantia, GastoEnergiaHora, DataAlteracao, Operacao)
	SELECT d.Id, d.Nome, d.Valor, d.Garantia, d.GastoEnergiaHora, GETDATE(), 'D'
	FROM Deleted d