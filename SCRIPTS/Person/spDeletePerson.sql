CREATE PROCEDURE dbo.spDeletePerson
(
	@personId INT,
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
			DELETE FROM dbo.Person WHERE PersonId = @personId;
		END
	END TRY
	BEGIN CATCH		
		SET @resultMessage = FORMATMESSAGE('Error al intentar eliminar registro. %s', CAST(ERROR_MESSAGE() AS VARCHAR(MAX)));	
	END CATCH
END