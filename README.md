- Açussena Mautone - 552568 
- Fabrício Saavedra - 97631 
- Guilherme Akio – 98582 
- Guilherme Morais – 551981 

# Bet_on_You

Projeto **Bet_on_You**, desenvolvido para gerenciamento de questionários, depoimentos e rede de apoio, com funcionalidades de autenticação, histórico e simulações financeiras.  
O projeto está hospedado no Render: https://sprint4-csharp-k62y.onrender.com/Swagger/index.html

---

## Tecnologias utilizadas

- **Backend:** C# / ASP.NET Web API  
- **Frontend:** Angular 
- **Banco de dados:** Postgres  
- **Gerenciador de pacotes:** npm (frontend)  
- **Controle de versão:** Git / GitHub  

---

## Estrutura do Projeto

### Backend

- **Controllers:**  
  - `AuthController` – autenticação e login de usuários  
  - `ConscientizacaoController` – gerenciamento de conscientizações  
  - `DepoimentosController` – CRUD de depoimentos  
  - `QuestionarioController` – envio e consulta de questionários  
  - `RedeApoioController` – gerenciamento da rede de apoio  
  - `SelicController` – consulta à API Selic  

- **Data:**  
  - `AppDbContext` – contexto do banco de dados  

- **Models:**  
  - `BCData`, `Usuario`, `Conscientizacao`, `Depoimento`, `Questionario`, `RedeApoio`, `SelicData`  

- **Repositories:**  
  - Repositórios específicos para cada modelo, responsáveis pelas operações CRUD  

### Frontend

- Estrutura baseada em **páginas** (`src/app/pages`)   
- Telas principais:  
  - Login  
  - Questionários 
  - Histórico de questionários  
  - Depoimentos  
  - Rede de apoio
  - Conscientização

---

## Funcionalidades

- Autenticação de usuários com validação de credenciais  
- Envio de questionários e registro de respostas  
- Cadastro, edição e exclusão de depoimentos  
- Consulta e filtro de rede de apoio  
- Simulações financeiras com base em dados da Selic  
- Integração com banco Postgres  
- **Hospedagem online no Render** https://sprint4-csharp-k62y.onrender.com/Swagger/index.html

---

## Como rodar o projeto localmente no visual studio code
- Dotnet run

## Como rodar o projeto localmente no visual studio 
1. Abrir a solução `backend.sln` 
2. Restaurar pacotes NuGet:  
- dotnet restore
