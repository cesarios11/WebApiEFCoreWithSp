CREATE PROCEDURE [dbo].[spUpdateProduct]
@ProductId int,
@ProductName [nvarchar](max),
@ProductDescription [nvarchar](max),
@ProductPrice int,
@ProductStock int
AS
BEGIN
	UPDATE dbo.Product
    SET

		ProductName = @ProductName,
		ProductDescription = @ProductDescription,
		ProductPrice = @ProductPrice,
		ProductStock = @ProductStock
	WHERE ProductId = @ProductId
END