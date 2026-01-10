# 📦 Customers API

API REST desenvolvida em ASP.NET Core para gerenciamento de clientes, aplicando boas práticas de arquitetura como Repository Pattern, Injeção de Dependência (DI) e operações assíncronas com Entity Framework Core.

Este projeto foi desenvolvido com foco em organização de código, clareza arquitetural e preparação para ambientes reais, sendo ideal para estudo, e evolução futura.

---

## 🚀 Tecnologias Utilizadas

 .NET 8 / ASP.NET Core Web API
 C#
 Entity Framework Core
 SQL Server**
 Dependency Injection (DI)
 Repository Pattern
 Swagger (OpenAPI)
 Postman, para testes

---

## 🧱 Arquitetura do Projeto

O projeto segue uma separação clara de responsabilidades:


Customers API
│
├── Controllers        → Camada de entrada (endpoints HTTP)
├── Repositories       → Acesso a dados (regras de persistência)
├── Entities           → Entidades do domínio
├── CustomerModel      → Models de Request e Response (DTOs)
├── Data               → DbContext e configuração do EF Core
└── Program.cs         → Configuração da aplicação e DI


### 🔑 Principais Conceitos Aplicados

 Repository Pattern: abstrai o acesso ao banco de dados
 DTOs (Request / Response): evita exposição direta das entidades
 Async / Await: melhora performance e escalabilidade
 DI (Injeção de Dependência): reduz acoplamento e melhora testabilidade

---

## 🔌 Endpoints Disponíveis

### ➕ Criar Cliente

 POST /api/customers

  json
{
  "name": "João Silva",
  "document": "12345678900",
  "documentType": "CPF",
  "email": "joao@email.com"
}


---

### 📄 Obter Todos os Clientes

GET /api/customers/ObterTodos

🔎 Retorna uma lista de clientes utilizando um CustomerResponse, garantindo melhor controle dos dados expostos.

---

### 🔍 Obter Cliente por ID

GET /api/customers/{id}

---

### ✏️ Atualizar Cliente

 PUT /api/customers/{id}

  json
{
  "name": "João Silva Atualizado",
  "document": "12345678900",
  "email": "joao.novo@email.com"
}


---

### ❌ Deletar Cliente

 DELETE /api/customers/{id}

---

## 🗄️ Banco de Dados

 SQL Server
 Gerenciado via Entity Framework Core
 DbContex injetado via Dependency Injection
 Operações CRUD realizadas de forma assíncrona

---

## ⚙️ Configuração do Projeto

### 1️⃣ Clonar o repositório


 git clone git@github.com:jose456783/CustomersRepository.git (Chave ssh)
 git clone https://github.com/jose456783/CustomersRepository.git


### 2️⃣ Configurar a Connection String

No arquivo appsettings.json:

 
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost,1433;Database=Customers;User Id=sa;Password=Jusga9090@;TrustServerCertificate=True;"
},


---

## 🧪 Boas Práticas Aplicadas

* Separação clara de camadas
* Não exposição direta de entidades
* Métodos assíncronos em toda a cadeia
* Controle de ciclo de vida com DI
* Código organizado e legível

---

## 📌 Próximos Passos (Evolução)

* Implementar autenticação (JWT)
* Validações mais avançadas
* Paginação e filtros
* Testes unitários
* Dockerização

---

## 👨‍💻 Autor

José Francisco Silva de Oliveira
Desenvolvedor em formação focado em Back-end com .NET

🔗 LinkedIn: www.linkedin.com/in/josé-oliveira-b49883329
🔗 GitHub: https://github.com/jose456783

---

⭐ Se este projeto te ajudou ou serviu de inspiração, não esqueça de deixar uma estrela no repositório!
