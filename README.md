# ContasAPagar
Projeto Contas a Pagar

## Descrição do Projeto
<p align="justify"> Este projeto visa controlar as contas a pagar </p>

### 🛠 Tecnologias

- Asp.Net Core 3.1.12
- Entity Framework Core
- DDD
- SQL Server

### 🎲 Para testar o projeto

<ol>
  <li>Compilar o projeto</li>
  <li>Realizar o migration para criar o banco de dados - Ex.: add-migration Initial_Base -StartUpProject ContasApagar -project Infrastructure -v</li>
  <li>Chamar as rotas de criar conta "controller{api/v1/CriarConta}" e listar contas "controller{api/v1/ListarContas}"</li>
</ol>

### Swagger

- http://localhost:<port>/swagger
