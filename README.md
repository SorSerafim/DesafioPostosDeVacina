# Postos de Vacinação API

Esta é uma API para gerenciar postos de vacinação e vacinas relacionadas.

## Desafio: Sistema de Cadastro de Postos de Vacinação

### Descrição do Desafio

Desenvolver uma aplicação backend que permita o gerenciamento de postos de vacinação e as vacinas disponíveis em cada posto. O sistema deve ser capaz de lidar com a criação, edição e remoção de registros, além de garantir a integridade dos dados, atender às regras de negócio especificadas e garantir a segurança dos dados.

### Regras de Negócio

- O sistema deve impedir a duplicação de postos com o mesmo nome.
- Um posto de vacinação pode ter várias vacinas associadas.
- Postos de vacinação que possuem vacinas associadas não podem ser excluídos.
- Cada vacina deve ter um nome, fabricante, lote, quantidade e data de validade.
- A data de validade da vacina deve ser uma data futura.
- Vacinas não podem ter o mesmo lote.

# Estrutura do Projeto

## Controllers
Contém os controladores da API para manipulação de postos e vacinas.

## Services
Contém a lógica de negócios para operações relacionadas a postos e vacinas.

## Repositories
Contém a implementação do acesso a dados para postos e vacinas.

## Models
Define as entidades de dados (Posto, Vacina) e os DTOs correspondentes (CreatePostoDTO, ReadPostoDTO, CreateVacinaDTO, ReadVacinaDTO).

# Configuração Adicional

- Certifique-se de que o Entity Framework Core esteja configurado corretamente no projeto.
- Verifique se todas as dependências foram restauradas utilizando o `dotnet restore`.

# Execução do Projeto

Para executar o projeto localmente:

1. Configure seu banco de dados com as configurações fornecidas.
2. Execute o comando Docker para criar o banco de dados SQL Server:
- docker run -v ~/docker --name sqlserver -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=1q2w3e4r@#$" -p 1433:1433 -d mcr.microsoft.com/mssql/server

# Endpoints da API

## Postos de Vacinação

- `POST /api/postos`: Cria um novo posto de vacinação.
- `GET /api/postos`: Obtém a lista de todos os postos de vacinação.
- `GET /api/postos/{id}`: Obtém um posto de vacinação específico pelo ID.
- `PUT /api/postos/{id}`: Atualiza um posto de vacinação existente pelo ID.
- `DELETE /api/postos/{id}`: Deleta um posto de vacinação pelo ID.

## Vacinas

- `POST /api/vacinas`: Cria uma nova vacina associada a um posto.
- `GET /api/vacinas`: Obtém a lista de todas as vacinas cadastradas.
- `GET /api/vacinas/{id}`: Obtém uma vacina específica pelo ID.
- `PUT /api/vacinas/{id}`: Atualiza informações de uma vacina pelo ID.
- `DELETE /api/vacinas/{id}`: Deleta uma vacina pelo ID.


## Configuração do Banco de Dados

Certifique-se de ter configurado seu banco de dados com as seguintes informações de conexão:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost,1433;Database=PostosDeVacinaDb;User ID=sa;Password=1q2w3e4r@#$"
}
