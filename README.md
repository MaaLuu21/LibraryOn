# LibraryOn
O **LibraryOn** é uma API desenvolvida em **C# / .NET 8** que simula o funcionamento de uma biblioteca online.  
O projeto foi estruturado para representar um fluxo real de biblioteca, com controle de usuários, funcionários, livros e empréstimos, utilizando uma arquitetura em camadas bem definida.

A aplicação foi pensada para ser facilmente integrada a outros clientes (WPF, aplicações web ou outros sistemas).

<p align="center">
  <img src="https://img.shields.io/badge/Status-%20concluído-brightgreen?style=for-the-badge"/>
  <img src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white"/>
  <img src="https://img.shields.io/badge/.NET-8%2B-512BD4?style=for-the-badge&logo=dotnet&logoColor=white"/>
  <img src="https://img.shields.io/badge/Contribuições-Bem%20vindas-brightgreen?style=for-the-badge"/>
</p>

---

## 🧠 Objetivo do projeto

- Consolidar conhecimentos em desenvolvimento backend com .NET
- Aplicar princípios de organização de código e separação de responsabilidades
- Demonstrar uso prático de EF Core com banco de dados relacional
- Aplicar padrões de projeto como Repository, Unit of Work e DTO
- Servir como projeto de portfólio profissional

---

## 📌 Visão geral da arquitetura

A solução implementa uma arquitetura em camadas para uma Web API:

- **API**  
  Responsável por receber as requisições HTTP, aplicar filtros, autenticação e encaminhar para os casos de uso.

- **Application**  
  Contém os casos de uso da aplicação, validações (FluentValidation) e mapeamentos (AutoMapper).

- **Domain**  
  Contém as entidades, enums e contratos (interfaces de repositório e unidade de trabalho).

- **Infrastructure**  
  Contém a implementação de acesso a dados, DbContext, repositórios, migrações, seed e serviços de infraestrutura.

- **Communication**  
  Contém os DTOs de entrada e saída (requests e responses).

- **Exception**  
  Contém exceções e mensagens de erro centralizadas.

A organização indica uma abordagem de arquitetura em camadas (clean-ish architecture).

---

## 🚀 Fluxo principal da aplicação

1. A aplicação inicia em `Program.cs` (projeto `LibraryOn.Api`).
2. As dependências são registradas através de:
   - `AddInfrastructure(...)`
   - `AddApplication()`
3. O fluxo de uma requisição segue:
```
  Controller (API)
  → Use Case (Application)
  → Interfaces de Repositório (Domain)
  → Implementações (Infrastructure)
  → DbContext (EF Core)
```
4. No startup da aplicação:
   - As migrations são aplicadas automaticamente.
   - Um usuário administrador inicial é criado (seed).

---

## ⚙️ Padrões e práticas adotadas

- Injeção de dependência (Microsoft DI)
- Repository Pattern
- Unit of Work
- DTOs para entrada e saída
- AutoMapper
- FluentValidation
- Autenticação com JWT
- Filtro global de exceções

---

## 📄 Status do projeto

O projeto encontra-se em **fase final de desenvolvimento**.

A arquitetura, os principais fluxos de negócio e a estrutura geral da aplicação já estão consolidados.  
Neste momento, o objetivo do repositório é servir como **projeto de portfólio**, demonstrando domínio de organização de código, arquitetura em camadas, uso de padrões e integração com banco de dados.

Novas funcionalidades não estão previstas, sendo realizados apenas eventuais ajustes ou correções finais.

---

## ✅ Funcionalidades já implementadas

- API REST desenvolvida com ASP.NET Core (.NET 8)
- Arquitetura em camadas (API, Application, Domain, Infrastructure, Communication e Exception)
- Casos de uso organizados por domínio
- CRUD das principais entidades do sistema
- Persistência de dados com Entity Framework Core
- Banco de dados MySQL (Pomelo)
- Migrations configuradas e aplicadas automaticamente no startup
- Seed automático de usuário administrador
- Autenticação baseada em JWT
- Uso de DTOs para entrada e saída de dados
- Validações com FluentValidation
- Mapeamentos com AutoMapper
- Repository Pattern e Unit of Work
- Tratamento global de exceções
- Swagger habilitado em ambiente de desenvolvimento

Essas funcionalidades atendem ao escopo proposto inicialmente para o projeto e representam o conjunto final de entregas do LibraryOn.

---


## 🔄 Em desenvolvimento / próximos passos

Não há novos desenvolvimentos planejados.  
O projeto encontra-se em fase de encerramento, mantendo-se apenas correções pontuais, caso necessárias.

---

## 🛠️ Tecnologias Utilizadas

- C#
- ASP.NET Core Web API (.NET 8)
- Entity Framework Core
- MySQL (Pomelo)
- Swagger / OpenAPI
- AutoMapper
- FluentValidation
- JWT
- Git e GitHub

---

## 📁 Estrutura do Projeto
```
├── src/
│ ├── LibraryOn.Api # Controllers, middlewares e configuração da API
│ ├── LibraryOn.Application # Casos de uso, validações, mapeamentos e DI
│ ├── LibraryOn.Communication # DTOs de requests e responses
│ ├── LibraryOn.Domain # Entidades, enums e contratos
│ ├── LibraryOn.Exception # Exceções e mensagens centralizadas
│ └── LibraryOn.Infrastructure # DbContext, repositórios, migrations, seed e serviços
├── tests/ # Projetos de teste (ex.: Validators.Tests)
├── LibraryOn.sln
└── README.md
```
---

## 📊 Modelo de Domínio

```mermaid
classDiagram
    class Book {
        +long Id
        +string Title
        +string Author
        +int PublishYear
        +ICollection~Genre~ Genres
        +ICollection~Loan~ Loans
    }

    class Genre {
        +long Id
        +string Name
        +ICollection~Book~ Books
    }

    class Loan {
        +long Id
        +DateTime DueDate
        +DateTime LoanDate
        +DateTime? ReturnedAt
        +LoanStatus Status
        +Book Book
        +Reader Reader
        +Employee Employee
    }

    class Reader {
        +long Id
        +string Name
        +Cpf Cpf
        +PhoneNumber PhoneNumber
        +ICollection~Loan~ Loans
    }

    class Employee {
        +long Id
        +string Name
        +string Role
        +ICollection~Loan~ Loans
    }

    Book "n" -- "n" Genre : Categorizado por
    Loan "n" -- "1" Book : Refere-se a
    Loan "n" -- "1" Reader : Realizado por
    Loan "n" -- "1" Employee : Registrado por
```
---
## 💾 Banco de Dados

- Banco relacional: **MySQL**
- ORM: **Entity Framework Core**
- Provider: **Pomelo.EntityFrameworkCore.MySql**
- Estrutura versionada por migrations
- Migrations aplicadas automaticamente no startup da aplicação
- DbContext central: `LibraryOnDbContext`

---

## 🔐 Autenticação

- Autenticação baseada em JWT Bearer.
- Geração de token feita por serviço registrado na camada Infrastructure.
- Configurações lidas via `appsettings.json` ou variáveis de ambiente.

---
## 🧪 Observabilidade e suporte ao desenvolvimento

- Swagger habilitado em ambiente de desenvolvimento
- Filtro global de exceções configurado
- Uso de `ILogger` no processo de seed do administrador

---

## ▶️ Como executar o projeto

A partir da raiz do repositório:

```bash
dotnet restore
dotnet build
dotnet run --project src/LibraryOn.Api
```
### ⚙️ Configurações obrigatórias

String de conexão

Chave obrigatória:
```bash
  ConnectionStrings:connection
```
Configurações de JWT
```bash
  Settings:Jwt:SigningKey
  Settings:Jwt:ExpiresMinutes
```
Seed do administrador (opcional, recomendado)
```bash
Variáveis de ambiente: 
INITIAL_ADMIN_EMAIL
INITIAL_ADMIN_PASSWORD
```
Essas variáveis são utilizadas para criar automaticamente o usuário administrador na primeira execução.


---
## 🔑 Exemplo de Endpoint — Login **Endpoint**
**Endpoint** 
```
http POST /api/Login
```
**Request body**
```json
{
  "email": "admin@libraryon.com",
  "password": "senhaforte123"
}
```
**Curl**
```
curl -X 'POST' \
  'http://localhost:5068/api/Login' \
  -H 'accept: text/plain' \
  -H 'Content-Type: application/json' \
  -d '{
  "email": "admin@libraryon.com",
  "password": "senhaforte123@"
}'
```
**Request URL**
```
http://localhost:5068/api/Login

```
### ✅ Response 200 (OK)

```json
{
  "name": "Administrador",
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
  "mustChangePassword": true
}
```
### ❌ Response 400 (Bad Request)

```json
{
  "errorMessages": [
    "string"
  ]
}
```

---

## 🧪 Testes

Os projetos de teste encontram-se no diretório:
```bash
tests/
```
Para executar:
```bash
dotnet test
```