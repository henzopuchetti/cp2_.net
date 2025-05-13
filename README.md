# 💊 API de Lembretes de Medicamentos para Idosos - Henzo Boschiero Puchetti - Rm555179

## 📌 Descrição

Este projeto tem como objetivo fornecer uma API RESTful para o gerenciamento de lembretes de medicamentos voltados para idosos. A aplicação permite o cadastro, edição e exclusão de **Idosos**, **Medicamentos** e **Lembretes**, além de consultar todos os dados via HTTP, com suporte ao banco de dados **Oracle** usando **Entity Framework Core**.

A estrutura do projeto é dividida em múltiplas camadas, promovendo uma arquitetura limpa e escalável:

- `LembreteMedicamentos.API`: Camada de apresentação (Web API)
- `LembreteMedicamentos.Domain`: Camada de entidades do domínio
- `LembreteMedicamentos.Services`: Camada de lógica de negócio
- `LembreteMedicamentos.Data`: Camada de contexto e acesso a dados (EF Core)

---

## 📦 Rotas da API (Medicamentos)

| Método | Endpoint                | Descrição                               | Código de Resposta Esperado       |
|--------|-------------------------|-----------------------------------------|-----------------------------------|
| GET    | `/api/medicamentos`     | Retorna todos os medicamentos           | `200 OK`                          |
| GET    | `/api/medicamentos/{id}`| Retorna um medicamento por ID           | `200 OK`, `404 Not Found`         |
| POST   | `/api/medicamentos`     | Cria um novo medicamento                | `201 Created`, `400 Bad Request`  |
| PUT    | `/api/medicamentos/{id}`| Atualiza um medicamento existente       | `204 No Content`, `400`, `404`    |
| DELETE | `/api/medicamentos/{id}`| Exclui um medicamento por ID            | `204 No Content`, `404 Not Found` |

> Endpoints semelhantes estarão disponíveis para as entidades `Idoso` e `Lembrete`.

---

## 🚀 Instalação e Execução

### ✅ Pré-requisitos

- .NET 8 SDK
- Oracle Database (instância local ou remota)
- Visual Studio 2022 ou superior

### 🔧 Configuração do Banco de Dados

1. No `appsettings.json` da API, configure a string de conexão Oracle:
   ```json
   "ConnectionStrings": {
     "OracleConnection": "User Id=seu_usuario;Password=sua_senha;Data Source=seu_host:porta/servico"
   }


▶️ Executando a Aplicação
Abra a solução no Visual Studio (.sln).

Defina LembreteMedicamentos.API como projeto de inicialização.

Execute com Ctrl + F5 ou clique em Iniciar sem Depuração.

A API será iniciada em https://localhost:5001 ou http://localhost:5000.

