# Sistema de Cadastro de Postos de Vacinação

## Descrição

Este projeto é um sistema backend para o gerenciamento de postos de vacinação e vacinas disponíveis em cada posto. Ele permite a criação, edição e remoção de registros, garantindo a integridade dos dados e seguindo as regras de negócio especificadas.

## Requisitos de Tecnologia

- C#
- .NET Core
- Banco de dados relacional (SQL Server)

## Funcionalidades

- Cadastro de postos de vacinação
- Cadastro de vacinas
- Associação de vacinas a postos de vacinação
- Validações de integridade dos dados

## Regras de Negócio

- O sistema deve impedir a duplicação de postos com o mesmo nome.
- Um posto de vacinação pode ter várias vacinas associadas.
- Postos de vacinação que possuem vacinas associadas não podem ser excluídos.
- Cada vacina deve ter um nome, fabricante, lote, quantidade e data de validade.
- A data de validade da vacina deve ser uma data futura.
- Vacinas não podem ter o mesmo lote.

## Estrutura do Projeto

### Modelos

- `Posto`
- `Vacina`

### DTOs

- `PostoDTO`
- `VacinaDTO`

### Serviços

- `PostoService`
- `VacinaService`

### Repositórios

- `IRepository<TEntity>`
- `PostoRepository`
- `VacinaRepository`

### Controllers

- `PostoController`
- `VacinaController`

### Configuração do AutoMapper

- `MappingProfile`

## Configuração do Projeto

### Dependências

- AutoMapper
- Entity Framework Core

##Criando o Banco de Dados no Docker

Você pode criar o banco de dados no Docker utilizando o seguinte comando:

- docker run -v ~/docker --name sqlserver -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=1q2w3e4r@#$" -p 1433:1433 -d mcr.microsoft.com/mssql/server

### Configuração do Banco de Dados

No arquivo `appsettings.json`, configure a string de conexão com seu banco de dados SQL Server:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost,1433;Database=PostosDeVacinaDb;User ID=sa;Password=1q2w3e4r@#$"
  }
}
