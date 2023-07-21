ALTER PROCEDURE [dbo].[spUpdatePerson]
(
	@personId INT,
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
		IF NOT EXISTS (SELECT PersonId FROM dbo.Person WHERE PersonId = @personId)
		BEGIN
			SET @resultMessage = 'Registro no existe.';
		END		
		ELSE
		BEGIN
			UPDATE dbo.Person
			SET
				PersonDNI = @personDNI,
				PersonFirstName = @personFirstName,
				PersonLastName = @personLastName,
				PersonDOB = @personDOB,
				IsActive = @isActive
			WHERE PersonId = @personId
		END
	END TRY
	BEGIN CATCH		
		SET @resultMessage = FORMATMESSAGE('Error al intentar actualizar registro. %s', CAST(ERROR_MESSAGE() AS VARCHAR(MAX)));	
	END CATCH
END