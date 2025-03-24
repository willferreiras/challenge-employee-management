Employee Management System
Este projeto consiste em duas partes: um Backend construído com .NET e um Frontend com React. O sistema permite a gestão de funcionários, com funcionalidades de login, cadastro e edição.

Estrutura do Projeto
Backend: EmployeeManagement.API (Usando .NET)

Frontend: employee-management-frontend (Usando React)

Passos para Execução
1. Backend - .NET
1.1. Preparação do Banco de Dados
Acesse a pasta do projeto EmployeeManagement.API.

Execute o comando abaixo para criar o banco de dados utilizando o Docker (certifique-se de que o Docker esteja em execução):

docker run --name employee-db -e POSTGRES_USER=admin -e POSTGRES_PASSWORD=admin -e POSTGRES_DB=EmployeeDB -p 5432:5432 -d postgres

##############################################

Atualize o banco de dados com o comando:

dotnet ef database update

##############################################

Inicie o projeto com o comando:

dotnet run
O Backend estará rodando na URL http://localhost:5168.
O Swagger estará rodando na URL http://localhost:5168/index.html

##############################################

2. Frontend - React
2.1. Instalação das Dependências
Acesse a pasta employee-management-frontend.

Instale as dependências do projeto:

npm install

##############################################

Para rodar o frontend, execute o comando:

npm run dev
O Frontend estará rodando na URL http://localhost:3000.

##############################################

Passos para Teste
Após a instalação e com o Backend rodando, acesse o frontend em http://localhost:3000/login.

##############################################

Usuário para teste:

Username: JohnDoe

Password: 123456

##############################################

Após o login, você será redirecionado para a listagem de funcionários (inicialmente vazia).

Na tela de listagem, você pode:

Cadastrar novos funcionários.

Editar dados dos funcionários.

Fazer logout.

Tecnologias Utilizadas
Backend
.NET (ASP.NET Core)

PostgreSQL (Usando Docker)

JWT para autenticação e validação de tokens

Frontend
React

React Query para gerenciamento de dados

Styled Components para estilização

Observações
Certifique-se de que o Docker está rodando corretamente para criar e acessar o banco de dados.

O Frontend faz chamadas para a API do Backend que está rodando localmente.

#########################################
Explicações sobre a Arquitetura e Implementação
Experiência prévia com as tecnologias exigidas:
.NET: Este foi meu primeiro projeto utilizando .NET. Reconheço que houve algumas dificuldades iniciais, já que não tinha experiência com a plataforma. No entanto, consegui superar esses desafios com bastante pesquisa e aprendizado ao longo do caminho. Peço que relevem qualquer erro grosseiro que tenha ocorrido, pois foi uma curva de aprendizado considerável.

PostgreSQL: Tenho mais de 10 anos de experiência com bancos de dados relacionais, principalmente com PostgreSQL. Esta foi a tecnologia que usei para o armazenamento dos dados.

JWT: Já utilizo JWT há mais de 5 anos para autenticação e segurança de APIs.

Docker: Com mais de 5 anos de experiência, Docker foi uma das partes mais fáceis de configurar e integrar para garantir que a aplicação fosse portável e escalável.

React: Como minha área de atuação, React foi a tecnologia de escolha para o frontend, e não tive dificuldades significativas ao implementá-lo neste projeto.

Detalhes sobre a Segurança da Senha
A segurança das senhas foi implementada utilizando hashing com o algoritmo bcrypt. As senhas não são armazenadas de forma alguma em texto simples. Quando um usuário cria ou atualiza sua senha, ela é primeiramente criptografada antes de ser salva no banco de dados. Para a autenticação de usuários, utilizamos JWT para gerar tokens de acesso seguros.

Estrutura da API
A API foi construída utilizando os seguintes padrões e melhores práticas:

REST: A API segue os princípios REST, com endpoints que permitem as operações CRUD: GET, POST, PUT, DELETE.

Métodos Assíncronos: Todos os métodos que interagem com o banco de dados ou outros serviços externos foram implementados de forma assíncrona para garantir uma melhor performance e evitar bloqueios na aplicação.

Swagger: A documentação da API foi gerada automaticamente utilizando o Swagger, permitindo uma interação fácil e intuitiva com a API para testes e consumo.

Desafios Enfrentados
Durante o desenvolvimento do projeto, enfrentei alguns desafios técnicos, como:

Dificuldades com o Backend em .NET: Como mencionei anteriormente, este foi meu primeiro contato com o .NET. Tive dificuldades iniciais para configurar corretamente a estrutura do projeto, especialmente com relação ao gerenciamento de dependências e à arquitetura de camadas (API, lógica de negócios, repositório).

Integração do Docker e Banco de Dados PostgreSQL: Embora eu tenha experiência com Docker, a integração do PostgreSQL com Docker exigiu atenção extra para configurar corretamente o banco de dados dentro de um container, além de garantir que as conexões fossem feitas adequadamente com a aplicação .NET.

Segurança e JWT: A implementação de segurança com JWT também apresentou desafios, principalmente na criação de um mecanismo adequado de autorização, que validasse as permissões do usuário corretamente e garantisse que senhas fossem armazenadas de forma segura.

No frontend, como já tenho experiência com React, não enfrentei grandes dificuldades. Utilizeis alguns patterns que já estou acostumado a usar, como componentes reutilizáveis e gerenciamento de estado com hooks, o que facilitou a entrega do projeto.

Conclusão
Esse projeto foi uma excelente oportunidade de aprendizado, principalmente pela minha falta de experiência com .NET. No entanto, consegui superar os desafios com bastante pesquisa e dedicação. No frontend, pude aplicar meu conhecimento em React sem dificuldades. Acredito que, com as implementações de segurança e as boas práticas que segui, a aplicação está robusta e pronta para ser utilizada.