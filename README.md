# CTodos-PS

## Processo Seletivo - Cartão de Todos

Projeto parte do processo seletivo para vaga.

## Estrutura do projeto

- Presentation
    - CartaoTodos.Angular *(Este projeto não será listado no Visual Studio)
    - CartaoTodos.Mvc
    - CartaoTodos.WebForms
- Service
    - CartaoTodos.REST
    - CartaoTodos.REST.Common
    - CartaoTodos.WebAPI
- Application
    - CartaoTodos.Application
- Domain
    - CartaoTodos.Domain
- Data
    - CartaoTodos.Data
- IoC
    - CartaoTodos.IoC

## Executando os projetos

Instruções para execução.

### Web API

A Web API utiliza diretamente a camade de Infraestrutura, que realiza o acesso ao banco de dados; esta camada está configurada para utilizar uma string de conexão chamada `AppConnection`;

Para configurar a string de conexão no projeto. basta adicionar a chave abaixo no `Web.config`:

```
<connectionStrings>
    <add name="AppConnection" connectionString="Sua string de conexão aqui" providerName="System.Data.SqlClient" />
</connectionStrings>
```

A API está publicada na porta 55751.

### Web Forms e MVC

As aplicações Web Forms e MVC se conectam diretamente com a API através da biblioteca [CartaoTodos.REST](https://github.com/fabianobizarro/CTodos-PS/tree/master/CartaoTodos/CartaoTodos.REST),
que é a biblioteca responsável por fazer as requisições para a API.

Para ter acesso, basta configurar um chave com nome de `API_ENDPOINT` na seção `appSettings` no `Web.config` da aplicação:

```
  <appSettings>
    <add key="API_ENDPOINT" value="http://localhost:55751/api/" />
  </appSettings>
```

### Angular

Requisitos:
 - Node.js v9.6.5 (Última versão LTS)

Para executar projeto CartaoTodos.Angular é necessário ter instalado no Node.js, pois ele é utilizado para hospedar a aplicação.

A Url da API  está localizado no arquivo de variáveis de ambiente, em `/src/environments/environment.ts` ou `/src/environments/environment.prod.ts` dependendo do ambiente que for executar.

```
export const environment = {
  ...
  api_endpoint: 'http://localhost:55751/api'
};
```

Com o Node.js instalado, basta fazer o downloade das dependência do projeto e executá-lo:
```
$ cd CartaoTodos.Angular
$ npm install
$ npm start
$ Aplicação rodando em http://localhost:8000
```
