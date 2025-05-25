
# 🛵 MotoMap

O presente projeto foi desenvolvido como parte de um desafio proposto em ambiente acadêmico, com o propósito de criar uma **API RESTful** capaz de representar, de forma digital e em tempo real, o pátio de motocicletas da empresa **Mottu**. O sistema foi concebido para exibir a localização e o status de cada veículo por meio da integração de **sensores RFID** e tecnologias modernas de desenvolvimento **backend**.

## 👥 Integrantes do Projeto

- **Eduardo do Nascimento Barriviera** – RM555309  
- **Thiago Lima de Freitas** – RM556795  
- **Bruno Centurion Fernandes** – RM556531  

## 🛠️ Tecnologias Utilizadas

- [.NET 8](https://dotnet.microsoft.com/)  
- **ASP.NET Core Web API**  
- **Entity Framework Core** com `Oracle.EntityFrameworkCore`  
- **AutoMapper**  
- **Swagger (Swashbuckle)**  
- **Oracle Database**

## ⚙️ Execução do Projeto

### ✅ Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)  
- Banco de dados Oracle acessível  
- Visual Studio 2022 ou superior (recomendado)

### 📦 1. Clonar o Repositório

```bash
git clone https://github.com/seu-usuario/Cp2WebApplication.git
cd Cp2WebApplication
```

### 🔧 2. Configurar o Banco de Dados

No arquivo `appsettings.json`, insira:

```json
"ConnectionStrings": {
  "Oracle": "Data Source=oracle.fiap.com.br:1521/orcl;User ID=SEU_ID;Password=SUA_PASSWORD"
}
```

### 🧱 3. Gerar Migrations (se necessário)

```bash
dotnet tool install --global dotnet-ef
dotnet ef migrations add Inicial --context Cp2Context
dotnet ef database update --context Cp2Context
```

### ▶️ 4. Executar a Aplicação

```bash
dotnet run
```

Acesse via Swagger:  
```
http://{IP_PÚBLICO}:5000/swagger
       {ou localhost}
```

## 🌐 Endpoints

- `/LocalizacaoAtual/all` – Todas as localizações  
- `/api/LocalizacaoAtual/moto/{id}` – Localização da moto  
- `/api/motos` – Lista todas as motos  
- `/api/motos?status=pronta` – Motos prontas  
- `/api/motos?status=sem%20placa` – Motos sem placa  
- `/api/motos?status=revisao` – Motos em revisão  

## ☁️ Provisionamento na Azure (CLI)

### Localização

```bash
az account list-locations
```

### Criar Resource Group

```bash
az group create -l eastus -n rg-vm-challenge
```

### Criar Máquina Virtual

```bash
az vm create \
  --resource-group rg-vm-challenge \
  --name vm-challenge \
  --image Canonical:ubuntu-24_04-lts:minimal:24.04.202505020 \
  --size Standard_B2s \
  --admin-username admin_fiap \
  --admin-password admin_fiap@123
```

### Liberar Porta 5000

```bash
az network nsg rule create \
  --resource-group rg-vm-challenge \
  --nsg-name vm-challengeNSG \
  --name port_5000 \
  --protocol tcp \
  --priority 1010 \
  --destination-port-range 5000
```

## 🐳 Deploy com Docker

```bash
docker run -d -p 5000:5000 eduardo1805/motomap-api:1.0
```
