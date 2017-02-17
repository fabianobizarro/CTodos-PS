/*
* Criar 4 procedures dos CRUD: Insert, Update, Delete e Select do Usuário: 
* (Apenas os scripts de banco de dados não sendo necessário coloca-los para rodar na aplicação,  
*    esses scripts deverão ser capaz de rodar sem erros  executá-lo via banco de dados).
*/


-- CREATE
CREATE PROCEDURE CRIAR_USUARIO
	@NOME VARCHAR(100),
	@LOGIN VARCHAR(50),
	@EMAIL VARCHAR(70),
	@SENHA VARCHAR(256),
	@ATIVO BIT = 1
AS 
 INSERT INTO USUARIO (NOME, LOGIN, EMAIL, SENHA, ATIVO, DT_INCLUSAO)
 VALUES (@NOME, @LOGIN, @EMAIL, @SENHA, @ATIVO, GETDATE());