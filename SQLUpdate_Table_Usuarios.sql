ALTER TABLE [dbo].[TREINA_USUARIOS]
ADD DATA_VALIDADE DATETIME;

UPDATE [dbo].[TREINA_USUARIOS]
SET DATA_VALIDADE = GETDATE()+ 30;