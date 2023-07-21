CREATE  PROCEDURE [dbo].[spDeleteProduct]
@ProductId int
AS
BEGIN
	DELETE FROM dbo.Product where ProductId = @ProductId
END