CREATE PROCEDURE [dbo].[P_Cadastar_Usuarios] 
	@usuario CHAR(10), 
	@senha CHAR(10), 
	@nome VARCHAR(20), 
	@u_atualizacao CHAR(10),
	@result varchar(50) OUTPUT
AS
IF EXISTS(SELECT 1 FROM [dbo].[TREINA_USUARIOS] WHERE NOME = @nome)
BEGIN
	SET @result = 'Nome já cadastrado'
	RETURN SELECT @result
END ELSE
IF ISNULL (@nome, '') = '' OR @nome LIKE '%[^a-z ]%'
	BEGIN
		SET @result = 'Nome Inválido'
		RETURN SELECT @result
	END
BEGIN
	INSERT INTO [dbo].[TREINA_USUARIOS]
	(USUARIO, SENHA, NOME, USUARIO_ATUALIZACAO, DATA_ATUALIZACAO, DATA_VALIDADE)
	VALUES
	(@usuario, @senha, @nome, @u_atualizacao, GETDATE(), GETDATE() + 30)
	SET @result = 'Cadastrado'
	RETURN SELECT @result
END
