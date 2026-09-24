# PayFlow

API REST desenvolvida em **C# e ASP.NET Core** que simula o funcionamento básico de um gateway de pagamentos.

O projeto foi desenvolvido como forma de estudo, colocando em prática conceitos de desenvolvimento backend, APIs REST, persistência de dados, Entity Framework Core, PostgreSQL, requisições HTTP e Webhooks.

## 🚀 Funcionalidades

* Criação de pagamentos
* Geração de código Pix simulado
* Consulta de pagamento por ID
* Persistência dos pagamentos em PostgreSQL
* Confirmação de pagamento
* Controle de status do pagamento
* Envio de Webhook após a confirmação
* URL do Webhook configurável
* Operações assíncronas com `async/await`

## 🔄 Fluxo do pagamento

```text
Criar pagamento
      ↓
Status: PENDING
      ↓
Geração do PixCode
      ↓
Pagamento salvo no banco
      ↓
Confirmação do pagamento
      ↓
Status: PAID
      ↓
Envio do Webhook
      ↓
Webhook recebido
```

## 🛠️ Tecnologias utilizadas

* C#
* .NET
* ASP.NET Core Web API
* Entity Framework Core
* PostgreSQL
* HTTP / REST
* Webhooks
* `HttpClient`
* `async/await`

## 📌 Endpoints

### Criar pagamento

```http
POST /api/payments
```

Exemplo:

```json
{
  "amount": 39.90
}
```

Retorna um pagamento com ID, valor, status e um código Pix simulado.

---

### Consultar pagamento

```http
GET /api/payments/{id}
```

Exemplo:

```http
GET /api/payments/1
```

---

### Confirmar pagamento

```http
POST /api/payments/{id}/confirm
```

A confirmação altera o status de:

```text
PENDING → PAID
```

Após a confirmação, a API envia automaticamente um Webhook.

---

### Receber Webhook

```http
POST /api/webhook/payment
```

Exemplo de payload:

```json
{
  "paymentId": 1,
  "amount": 39.90,
  "status": "PAID"
}
```

## 🗄️ Banco de dados

O projeto utiliza **PostgreSQL** para armazenar os pagamentos.

O acesso ao banco é realizado utilizando **Entity Framework Core**, permitindo trabalhar com os dados através das classes C# e do `DbContext`.

As informações sensíveis de conexão são armazenadas utilizando **.NET User Secrets** durante o desenvolvimento local.

## 🔐 Segurança

Credenciais e informações sensíveis não ficam armazenadas no código-fonte ou no `appsettings.json`.

Para o ambiente de desenvolvimento, o projeto utiliza:

```text
.NET User Secrets
```

## 📚 O que pratiquei neste projeto

Durante o desenvolvimento do MiniGateway, coloquei em prática:

* Criação de APIs REST com ASP.NET Core
* Controllers e rotas HTTP
* Injeção de dependência
* Entity Framework Core
* Comunicação com PostgreSQL
* Operações CRUD
* `async/await`
* `HttpClient`
* Comunicação entre endpoints através de HTTP
* Webhooks
* Configuração através de `appsettings.json`
* Gerenciamento de informações sensíveis com User Secrets
* Controle de estados de um pagamento

## ⚠️ Observação

Este é um **projeto educacional**.

O pagamento, Pix e confirmação são totalmente simulados e o projeto **não realiza transações financeiras reais** nem possui integração com instituições financeiras.

## 👨‍💻 Autor

**Arthur Guilherme**

Estudante de Análise e Desenvolvimento de Sistemas, com foco em desenvolvimento backend.

Este projeto faz parte dos meus estudos em **C#, .NET e desenvolvimento de APIs**.
