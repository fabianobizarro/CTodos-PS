
CREATE PROCEDURE EXPORTAR_USUARIOS
	@CAMINHO_ARQUIVO VARCHAR(MAX)
AS
	
	-- HABILITANDO O xp_cmdshell
	EXEC sp_configure 'show advanced options', 1;  
	RECONFIGURE;  
	EXEC sp_configure 'xp_cmdshell', 1;  
	RECONFIGURE;  

	DECLARE @LOGIN VARCHAR(100);
	DECLARE @EMAIL VARCHAR(100);
    DECLARE @NOME VARCHAR(100);
	DECLARE @COMANDO VARCHAR(1000);
	DECLARE @NOMEARQUIVO VARCHAR(100) = 'export_USUARIO_' + (SELECT REPLACE(CONVERT(VARCHAR(30),GETDATE(),127), ':', '')) + '.txt';

	DECLARE cursor_export CURSOR FOR
		SELECT LOGIN, NOME, EMAIL FROM USUARIO

	OPEN cursor_export

	FETCH NEXT FROM cursor_export INTO @LOGIN, @NOME, @EMAIL

	SET @COMANDO = 'echo USUARIOS FRANQUIA > ' + @CAMINHO_ARQUIVO + '\' + @NOMEARQUIVO;
	EXEC xp_cmdshell @COMANDO;

	WHILE @@FETCH_STATUS = 0
	BEGIN
	
		SET @COMANDO = 'echo ' + @LOGIN + ' ' + @NOME + ' ' + @EMAIL + ' >> ' + @CAMINHO_ARQUIVO + '\' + @NOMEARQUIVO;
		EXEC xp_cmdshell @COMANDO;
    
		FETCH NEXT FROM cursor_export INTO @LOGIN, @NOME, @EMAIL
	END

	CLOSE cursor_export;
	DEALLOCATE cursor_export ;

	-- DESABILITANDO O xp_cmdshell
	EXEC sp_configure 'xp_cmdshell', 0;  
	RECONFIGURE;  
	EXEC sp_configure 'show advanced options', 0;  
	RECONFIGURE;  
