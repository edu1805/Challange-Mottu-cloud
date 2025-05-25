# 🛵 MotoMap

Este projeto foi desenvolvido como parte do desafio da faculdade, com o objetivo de criar uma **API REST** que representa digitalmente um pátio de motos da empresa **Mottu**, exibindo a localização e status de cada moto em tempo real, utilizando sensores RFID e tecnologias modernas de backend.

### Integrantes
- **Eduardo do Nascimento Barriviera - RM555309**
- **Thiago Lima de Freitas - RM556795**
- **Bruno centurion Fernandes - RM556531**
---

## 🚀 Funcionalidades

- Cadastro de motos com validações de negócio
- Atualização de posição e status em tempo real
- API RESTful com endpoints organizados
- Documentação Swagger integrada
- Acesso e persistência de dados em banco Oracle via EF Core

---

## 🛠️ Tecnologias utilizadas

- [.NET 8](https://dotnet.microsoft.com/)
- **ASP.NET Core Web API**
- **Entity Framework Core** + `Oracle.EntityFrameworkCore`
- **AutoMapper** para mapeamento entre entidades e DTOs
- **Swagger / Swashbuckle** para documentação da API
- **Oracle Database** como banco de dados relacional

---

## ⚙️ Como rodar o projeto

### ✅ Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- Banco de dados Oracle acessível
- Visual Studio 2022 ou superior (recomendado)

---

### 📦 1. Clonar o repositório

```bash
git clone https://github.com/seu-usuario/Cp2WebApplication.git
cd Cp2WebApplication
```

---

### 🔧 2. Configurar o banco de dados Oracle
No arquivo appsettings.json, configure a sua string de conexão:
```bash
"ConnectionStrings": {
  "Oracle": "Data Source=oracle.fiap.com.br:1521/orcl;User ID=SEU_ID;Password=SUA_PASSWORD"
}
```

---

### 🧱 3. Gerar as Migrations (se necessário)
```bash
dotnet tool install --global dotnet-ef
dotnet ef migrations add Inicial --context Cp2Context
dotnet ef database update --context Cp2Context
```

---

### ▶️ 4. Executar a aplicação
```bash
dotnet run
```
Ou direto pelo Visual Studio com F5.

---

#### Acesse a documentação da API em:
```bash
https://localhost:port/swagger
```
