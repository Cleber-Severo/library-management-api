# 📚 Library Management API

Uma API REST simples desenvolvida em **ASP.NET Core** para gerenciamento de livros. O projeto foi criado com fins de estudo, aplicando conceitos como Controllers, Use Cases, Repository Pattern, Injeção de Dependência e tratamento global de exceções.

## Funcionalidades

- Cadastrar um livro
- Listar todos os livros
- Buscar um livro por ID
- Atualizar um livro
- Remover um livro

> Atualmente os dados são armazenados em memória, ou seja, são perdidos ao encerrar a aplicação.

---

## Tecnologias

- .NET 8
- ASP.NET Core Web API
- Swagger / OpenAPI
- FluentValidation
- Injeção de Dependência (Dependency Injection)

---

## Rotas

| Método | Endpoint | Descrição |
|---------|----------|-----------|
| GET | `/api/books` | Lista todos os livros |
| GET | `/api/books/{id}` | Busca um livro pelo ID |
| POST | `/api/books` | Cadastra um novo livro |
| PUT | `/api/books/{id}` | Atualiza um livro existente |
| DELETE | `/api/books/{id}` | Remove um livro |

---

## Como executar o projeto

### 1. Clone o repositório

```bash
git clone https://github.com/Cleber-Severo/library-management-api.git
```

Entre na pasta do projeto:

```bash
cd LibraryManagementApi
```

---

### 2. Restaurar os pacotes NuGet

```bash
dotnet restore
```

Ou utilize a opção **Restore NuGet Packages** pelo Visual Studio.

---

### 3. Executar a aplicação

```bash
dotnet run
```

Caso utilize o Visual Studio, basta definir o projeto como Startup Project e pressionar **F5** ou **Ctrl + F5**.

---

## Swagger

Após iniciar a aplicação, acesse:

```
https://localhost:7003/swagger
```

> A porta pode variar conforme a configuração do projeto.

O Swagger permite visualizar e testar todos os endpoints da API.

---

## Estrutura do projeto

```
LibraryManagementApi
│
├── Controllers
├── Entities
├── Enums
├── ExceptionBase
├── Filters
├── Repositories
│   ├── Interfaces
│   └── InMemory
├── Requests
├── Responses
├── UseCases
└── Program.cs
```

---

## Observações

- Os dados são mantidos apenas em memória.
- Não há persistência em banco de dados.
- O projeto tem como objetivo demonstrar uma arquitetura simples baseada em Use Cases e Repository Pattern.