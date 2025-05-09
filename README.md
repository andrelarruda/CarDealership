# Aplicação de gerenciamento de Concessionária de Veículos

_Aplicação desenvolvida para o processo seletivo da empresa Intelectah._

Para descrição das funcionalidades básicas, clique no [link](https://github.com/andrelarruda/CarDealership/blob/main/Funcionalidades.md).

## 🔧 Tecnologias Utilizadas
- ASP.NET Core MVC (.NET 8.0)
- Razor Pages
- Entity Framework Core
- ASP.NET Core Identity (Autenticação/Autorização)
- SQL Server 2022 (versão 16.0.1000.6)
- SQL Server Management Studio (SSMS 19.3.4.0)
- Bootstrap (estilização)
- jQuery (requisições Ajax)
---

## 💻 Pré-requisitos e Instalação

Antes de rodar a aplicação, é necessário instalar as seguintes ferramentas:

### 1. .NET 8.0 SDK
- Baixe e instale o SDK do .NET 8.0 em:  
	👉 https://dotnet.microsoft.com/en-us/download/dotnet/8.0

Para verificar se está instalado:
```bash
dotnet --version
```

### 2. Visual Studio 2022 (com suporte ao .NET 8.0)
- Baixe em: 👉 https://visualstudio.microsoft.com/pt-br/vs/
- Durante a instalação, marque os seguintes workloads:
- - Desenvolvimento para ASP.NET e web

### 3. SQL Server 2022 (versão 16.0.1000.6)
- Baixe e instale a versão Developer ou Express:
	👉 https://www.microsoft.com/pt-br/sql-server/sql-server-downloads
	
### 4. SQL Server Management Studio (SSMS 19.3.4.0)
- Gerenciador gráfico para o banco de dados:
	👉 https://learn.microsoft.com/pt-br/sql/ssms/download-sql-server-management-studio-ssms
	
	
## 🚀 Como Executar o Projeto Localmente

### 🔄 1. Clone o repositório
```bash
git clone https://github.com/andrelarruda/CarDealership
cd CarDealership
```

### ⚙️ 2. Configure a connection string
- No arquivo appsettings.json, edite a string de conexão com a sua connection string do SQL Server:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=CarDealershipDB;Trusted_Connection=True;TrustServerCertificate=True;"
}
```
Use localhost se estiver rodando localmente no SSMS. Caso tenha um nome de instância, substitua.

### 🧱 3. Restaure os pacotes
```bash
dotnet restore
```

### 🗃️ 4. Crie o banco de dados
- Abra o terminal na pasta do projeto e execute as migrations com:
```bash
dotnet ef database update
```
- Se dotnet ef não funcionar, instale o CLI global:
```bash
dotnet tool install --global dotnet-ef
```

### ▶️ 5. Rode a aplicação
```bash
dotnet run
```
Ou use o botão “Play” no Visual Studio para rodar em modo Debug.

---
## 🗂️ Estrutura do Projeto
- Controllers/ – Controladores MVC

- Services/ - Serviços com regras de negócio (interfaces e classes)

- Repositories/ - Interfaces e classes que interagem com o context para realizar mudanças no banco.

- Views/ – Razor Pages e Layouts

- Models/ – Classes de domínio

- ViewModels/ – Dados fortemente tipados para Views

- Data/ – Contexto EF Core e migrações

- wwwroot/ – Arquivos estáticos (CSS, JS, imagens)

--- 
## 👥 Perfis de Usuário

- Administrador – Gerencia as Concessionarias e Fabricantes

- Gerente – Gerencia os Veiculos

- Vendedor – Gerencia as vendas

--- 

## 👤 Registro de Usuário e Perfis

Assim que a aplicação estiver rodando:

1. Acesse a aplicação no navegador

2. Clique em Registrar para criar um novo usuário.

3. No formulário de registro, selecione o tipo de usuário desejado:
  	- Administrador
	- Gerente
	- Vendedor

Após o registro, o usuário será automaticamente incluído no papel escolhido e redirecionado para a área correspondente do sistema.

--- 
## 📞 Informações de Contato

Caso queira saber mais sobre o projeto, fico à disposição:

- 📧 **E-mail:** andrebass27@gmail.com  
- 💼 **LinkedIn:** [linkedin.com/in/andrearruuda](https://linkedin.com/in/andrearruuda)  
- 📱 **Telefone:** (81) 98585-1220




