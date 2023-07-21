CREATE PROCEDURE [dbo].[spGetProductById]
@ProductId int
AS
BEGIN
	SELECT
		ProductId,
		ProductName,
		ProductDescription,
		ProductPrice,
		ProductStock
	FROM dbo.Product where ProductId = @ProductId
END