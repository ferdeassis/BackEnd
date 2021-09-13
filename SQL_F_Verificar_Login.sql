CREATE FUNCTION [dbo].[F_Verificar_Login] (@user varchar(10), @password varchar(10))
RETURNS varchar(100)

BEGIN
	DECLARE @result varchar(100);
	DECLARE @data_vencimento DATETIME;
	
	IF NOT EXISTS(SELECT 1 FROM TREINA_USUARIOS WHERE USUARIO = @user AND SENHA = @password)
	BEGIN
		SET @result = 'LOGIN OU SENHA INVALIDOS';
		RETURN @result;
	END ELSE (SELECT @data_vencimento = DATA_VALIDADE FROM TREINA_USUARIOS WHERE USUARIO = @user)
		BEGIN
			IF(CONVERT(DATE, GETDATE()) > @data_vencimento)
			BEGIN
				SET @result = 'SENHA EXPIROU';
			END	ELSE
		BEGIN
			SET @result = 'LOGADO';
		END
		RETURN @result;
	END
END