CREATE PROCEDURE [dbo].[spCreatePerson]
(
	@personDNI VARCHAR(MAX),
	@personFirstName VARCHAR(MAX),
	@personLastName VARCHAR(MAX),
	@personDOB DATETIME2,
	@isActive BIT,
	@resultMessage VARCHAR(MAX) OUTPUT
)
AS
BEGIN
	SET NOCOUNT ON;	
	SET @resultMessage = '';
	BEGIN TRY
		INSERT INTO dbo.Person
		(			
			PersonDNI,
			PersonFirstName,
			PersonLastName,
			PersonDOB,
			IsActive
		)
		VALUES
		(
			@personDNI,
			@personFirstName,
			@personLastName,
			@personDOB,
			@isActive		
		)
	END TRY
	BEGIN CATCH		
		SET @resultMessage = FORMATMESSAGE('Error al intentar crear registro. %s', CAST(ERROR_MESSAGE() AS VARCHAR(MAX)));	
	END CATCH
END