# API de Controle Financeiro em .NET 6 🚀

Bem-vindo à API de Controle Financeiro em .NET 6! Este projeto é uma iniciativa pessoal, desenvolvida com o propósito de aprimorar os conhecimentos em .NET, especialmente explorando os padrões Repository e a arquitetura Domain-Driven Design (DDD) em uma API RESTful para controle financeiro. Abaixo, apresentamos os detalhes do projeto e como começar.

## Funcionalidades Principais

1. **Gestão de Transações**: Execute operações CRUD para gerenciar suas transações financeiras.
2. **Padrão Repository**: Utiliza o Repository Pattern para uma abstração eficaz do acesso aos dados.
3. **Domain-Driven Design (DDD)**: Organização modular e centrada no domínio para um código mais claro e escalável.
4. **Autenticação e Autorização**: Proteja suas transações com autenticação e autorização, garantindo segurança.

## Estrutura do Projeto

- **App**: Código-fonte da aplicação.
  - **Application**: Lógica de aplicação, mapeamento de DTOs e serviços de aplicação.
  - **Domain**: Definição das entidades de domínio, agregados e interfaces de repositório.
  - **Infrastructure**: Implementação concreta do repositório, contexto de banco de dados e configuração.
  - **Presentation**: Controladores, modelos de exibição e configuração da API.
- **Tests**: Testes unitários para garantir a qualidade do código.

## Tecnologias Utilizadas

- **.NET 6**: Aproveita as últimas funcionalidades e melhorias do framework.
- **Entity Framework Core**: Para interação com o banco de dados utilizando o padrão Repository.
- **Swagger**: Documentação interativa da API para facilitar o entendimento e teste.
- **Autenticação JWT**: Garante segurança nas operações com autenticação baseada em token JWT.

## Como Iniciar

1. **Pré-requisitos**: Instale o .NET 6 SDK em sua máquina.
2. **Clone o Repositório**: `git clone https://github.com/seu-usuario/api-controle-financeiro.git`
3. **Acesse o Diretório**: `cd api-controle-financeiro/App/Presentation`
4. **Configuração do Banco de Dados**: Abra o arquivo `appsettings.json` e ajuste a conexão do banco de dados.
5. **Aplicar Migrações**: Execute `dotnet ef database update` para aplicar as migrações.
6. **Execute a API**: `dotnet run`

Acesse [http://localhost:5000/swagger](http://localhost:5000/swagger) para explorar a documentação interativa da API.

## Contribuições

Contribuições são bem-vindas! Sinta-se à vontade para abrir issues, propor melhorias ou enviar pull requests.

## Licença

Este projeto é distribuído sob a licença [MIT](LICENSE). Sinta-se livre para utilizar e modificar conforme necessário.

Este projeto é uma jornada pessoal de aprendizado. Espero que seja útil para aprimorar seus conhecimentos em Repository Pattern, DDD e desenvolvimento em .NET 6. Boa jornada de estudos! 🚀
