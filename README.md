# LibraryOn
O LibraryOn é um projeto de API desenvolvido em C# que tem como objetivo simular o funcionamento de uma biblioteca online. A escolha por uma API foi feita devido à sua flexibilidade e fácil adaptação a diferentes contextos, como integração com aplicações WPF, websites ou outros sistemas. O projeto busca representar o fluxo de uma biblioteca real, permitindo o cadastro de funcionários, usuários e livros, além do controle de empréstimos.

Os funcionários têm a função de cadastrar novos usuários e registrar ou atualizar os empréstimos realizados. Já a entidade Admin é responsável por gerenciar o acervo da biblioteca, podendo cadastrar novos livros, atualizar informações ou removê-los do sistema. O LibraryOn também implementa regras de negócio que garantem, por exemplo, que cada leitor possa alugar até dois livros simultaneamente e que cada livro só possa estar emprestado a um usuário por vez.

<p align="center">
  <img src="https://img.shields.io/badge/Status-%20desenvolvimento-red?style=for-the-badge"/>
  <img src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white"/>
  <img src="https://img.shields.io/badge/.NET-8%2B-512BD4?style=for-the-badge&logo=dotnet&logoColor=white"/>
  <img src="https://img.shields.io/badge/Contribuições-Bem%20vindas-brightgreen?style=for-the-badge"/>
</p>

## 🧠 Objetivo do Projeto

- Consolidar conhecimentos em desenvolvimento backend com .NET
- Aplicar princípios de organização de código e separação de responsabilidades
- Demonstrar uso prático de EF Core com banco de dados relacional
- Servir como projeto de portfólio profissional

## Status do Projeto

O projeto encontra-se em fase intermediária de desenvolvimento, com funcionalidades já implementadas e outras em evolução.

## Funcionalidades já implementadas

- API REST com ASP.NET Core
- Endpoints CRUD implementados para múltiplas entidades 
- Persistência de dados utilizando:
  - Entity Framework Core
  - MySQL
- Migrations configuradas e aplicadas via EF Core
- Organização do código em camadas
- Uso de DTOs para entrada e saída de dados
- Relacionamentos entre entidades configurados no banco de dados

## 🔄 Em desenvolvimento / Próximos passos

- Finalização do CRUD para todas as entidades do domínio
- Refinamento das regras de negócio e validações
- Implementação de testes automatizados (unitários e de integração)
- Melhoria da documentação da API via Swagger
- Padronização de respostas e tratamento global de exceções
- Implementação de autenticação e autorização
- Autenticação e autorização

---

## 🛠️ Tecnologias Utilizadas

- C#
- ASP.NET Core Web API
- Entity Framework Core
- MySQL
- Swagger / OpenAPI
- Git e GitHub

---

## 📁 Estrutura do Projeto
```
  LibraryOn/
  ├── docs/ # Documentação e diagramas
  ├── src/
  │   ├── LibraryOn.Api # Controllers e configuração da API
  │   ├── LibraryOn.Application # Serviços e casos de uso
  │   ├── LibraryOn.Communication # DTOs de Requests e Responses
  │   ├── LibraryOn.Domain # Entidades, Value Objects e regras de domínio
  │   ├── LibraryOn.Exceptions # Exceções
  │   └── LibraryOn.Infrastructure # EF Core, DbContext e persistência
  ├── LibraryOn.sln
  └── README.md
```
## 💾 Banco de Dados

- Banco de dados relacional: MySQL
- ORM: Entity Framework Core
- Estrutura criada e versionada através de migrations
- Relacionamentos configurados utilizando Fluent API

