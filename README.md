# Sistema de Seguros


## Descrição
Projeto desenvolvido para mostrar minhas habilidades de backend

### Requisitos funcionais
Cadastro de Proposta: permitir o cadastro de novas propostas.
Consulta de Consultar Propostas: Implementar uma funcionalidade para consultar e visualizar as propostas cadastrados e visualizar o status;
Consultar Contratos: Implementar uma funcionalidade para consultar e visualizar os contratos cadastrados.

## Tecnologias utilizadas
- .Net 8
- Entity Framework Core
- Swagger
- RabbitMQ
- xUnit
- FluentValidation
- Docker
 
 ## Arquitetura
 Foi utilizado o padrão de arquitetura Hexagonal para a organização do projeto. 

## Qualidade de Software
- Testes: Camada de testes, responsável por implementar os testes de unidade.


## Configuração

### Ambiente

- Enquanto o projeto estiver em ambiente de desenvolvimento os valores abaixo deverão permanecer como foram previamente configurados

- **Caso esteja utilizando o Visual Studio**

  > Clicando com o botão direito no projeto EABR.QualityService.Apis e selecionando a opção propriedades, será aberto o menu de propriedades do projeto em questão, selecionando a opção depurar é possível encontrar as variáveis do ambiente.  

  
## Criar a estrutura da base
Para acessar a base deve colocar o IP local da máquina como servidor exemplo Nome Servidor : 192.168.10.1, 1433. A senha está na conectionString. 
Vá até o diretório Indt.sistema.seguros\local\compose\sqlserver e execute os dois scripts:
1 - createdatabase
2 - criandotabelas

## Execução

O projeto Sistema Seguros API está dividido em módulos é o projeto que contém os testes. Assim deve selecionar no visiual studio na parte de execução o valor Docker-Compose 

**Atenção**

- **Caso esteja utilizando o Visual Studio**

> Neste momento o seu Visual Studio já deve estar configurado com o .NET Core.

1. Clone o projeto para sua máquina local.

2. Abra o arquivo _Indt.Sistema.Seguros_ com o Visual Studio.

3. Execute a aplicação a partir da seleção do Docker-Compose , utilizando o menu que se encontra no topo da tela clicando no botão play.

> No navegador padrão da máquina será aberto uma página no endereço `https://localhost:5020`, o endpoint apresentará uma página com o `erro 404`, basta mudar a url para `https://localhost:5020/swagger` 


