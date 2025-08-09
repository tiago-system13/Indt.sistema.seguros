# Sistema de Seguros


## Descri��o
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
 Foi utilizado o padr�o de arquitetura Hexagonal para a organiza��o do projeto. 

## Qualidade de Software
- Testes: Camada de testes, respons�vel por implementar os testes de unidade.


## Configura��o

### Ambiente

- Enquanto o projeto estiver em ambiente de desenvolvimento os valores abaixo dever�o permanecer como foram previamente configurados

- **Caso esteja utilizando o Visual Studio**

  > Clicando com o bot�o direito no projeto EABR.QualityService.Apis e selecionando a op��o propriedades, ser� aberto o menu de propriedades do projeto em quest�o, selecionando a op��o depurar � poss�vel encontrar as vari�veis do ambiente.  

  
## Criar a estrutura da base
Para acessar a base deve colocar o IP local da m�quina como servidor exemplo Nome Servidor : 192.168.10.1, 1433. A senha est� na conectionString. 
V� at� o diret�rio Indt.sistema.seguros\local\compose\sqlserver e execute os dois scripts:
1 - createdatabase
2 - criandotabelas

## Execu��o

O projeto Sistema Seguros API est� dividido em m�dulos � o projeto que cont�m os testes. Assim deve selecionar no visiual studio na parte de execu��o o valor Docker-Compose 

**Aten��o**

- **Caso esteja utilizando o Visual Studio**

> Neste momento o seu Visual Studio j� deve estar configurado com o .NET Core.

1. Clone o projeto para sua m�quina local.

2. Abra o arquivo _Indt.Sistema.Seguros_ com o Visual Studio.

3. Execute a aplica��o a partir da sele��o do Docker-Compose , utilizando o menu que se encontra no topo da tela clicando no bot�o play.

> No navegador padr�o da m�quina ser� aberto uma p�gina no endere�o `https://localhost:5020`, o endpoint apresentar� uma p�gina com o `erro 404`, basta mudar a url para `https://localhost:5020/swagger` 


