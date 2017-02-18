/*
* Criar um trigger que a cada alteração de um usuário, inserir informações de log de operação na tabela OPERACAO_USUARIO 
* (rodar pela aplicação)
* 
*/

CREATE TRIGGER TRG_UPDATE_USUARIO
ON USUARIO
FOR UPDATE
AS
	INSERT INTO OPERACAO_USUARIO (DT_LOG, ID_USUARIO)
	VALUES (GETDATE(), (SELECT ID_USUARIO FROM inserted))