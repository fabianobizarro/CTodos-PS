/*
** Criar uma query que lista todos os usuário ativos: (Nome, Login e Email) que realizaram mais que 5 alterações.
*/

SELECT 
	U.NOME,
	U.LOGIN,
	U.EMAIL,
	COUNT(OP.ID_OPERACAO_ACESSO) AS OPERACOES
FROM USUARIO U
LEFT JOIN OPERACAO_USUARIO OP ON U.ID_USUARIO = OP.ID_USUARIO
GROUP BY 
	U.NOME,
	U.LOGIN,
	U.EMAIL
HAVING 
	COUNT(OP.ID_OPERACAO_ACESSO) > 5;