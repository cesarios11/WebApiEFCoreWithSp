CREATE  PROCEDURE [dbo].[spCreateProduct]
@ProductName [nvarchar](max),
@ProductDescription [nvarchar](max),
@ProductPrice int,
@ProductStock int
AS
BEGIN
	INSERT INTO dbo.Product
		(
			ProductName,
			ProductDescription,
			ProductPrice,
			ProductStock
		)
    VALUES
		(
			@ProductName,
			@ProductDescription,
			@ProductPrice,
			@ProductStock
		)
END