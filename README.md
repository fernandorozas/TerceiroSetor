# Projeto Terceiro Setor

Este projeto foi criado com o objetivo de dar transparência as relações de contrato e parceria entre as entidades do terceiro setor e o poder público, de acordo com o Marco Regulatório das Organizações da Sociedade Civil – MROSC, que foi regulamentado pela Lei nº 13.019, de 31 de julho de 2014.

Este sistema permite o cadastramento de entidades do terceiro setor, a apresentação de planos de ação, instrumentos de convocação e formalização, apresentação de termos de ajustes e prestação de contas de recursos repassados.

## Documentação

A documentação do projeto inclue todas as informações de negócio, requistos funcionais e não funcionais, e diagramas de eventos e classes.
O documento pode ser encontrado nas versões:
* [Word](https://github.com/fernandorozas/TerceiroSetor/blob/master/docs/TerceiroSetor.docx)
* [PDF](https://github.com/fernandorozas/TerceiroSetor/blob/master/docs/TerceiroSetor.pdf)

# Execução Local

Este projeto foi desenvolvido completamente utilizando C# na versão .NET Core 8, e para a sua execução recomendamos a utilização do Visual Studio 2022. As instruções de execução deste projeto abaixo levam em conta que você tenha uma instalação local do Visual Studio 2022.

## Emulador do CosmosDB

Este projeto utiliza o Microsoft Azure CosmosDB como banco de dados. Existem duas opções para execução: a utilização de uma instância do CosmosDB na Azure, ou a utilização do Emulador do CosmosDB.

Recomendamos que seja feita a instalação do Emulador do CosmosDB no computador local. Caso você esteja utilizando o sistema operacional Windows, a instalação do emulador irá configurar tudo automaticamente. 

[Sobre o Emulador CosmosDB](https://learn.microsoft.com/pt-br/azure/cosmos-db/emulator)

[Download do Emulador CosmosDB](https://aka.ms/cosmosdb-emulator&ved=2ahUKEwi67sv_06mHAxW3pZUCHZtMAY4QFnoECBUQAQ&usg=AOvVaw1H7seF5vYwbuQ7vPdB_e3n)

Você também pode utilizar o winget para baixar o emulador:

    winget install -e --id Microsoft.Azure.CosmosEmulator

## Rodando a aplicação no Visual Studio

Após realizar o download do código fonte, abra o arquivo de solução, *TerceiroSetor.sln*
Vá até as propriedades da Solução, e na opção *Startup Project* Marque os seguintes projetos com a **Action** *Start*
* TerceiroSetor.API
* TerceiroSetor.WebApp

![enter image description here](https://github.com/fernandorozas/TerceiroSetor/blob/master/docs/Configuracoes.png)

Pronto, agora você poderá executar a partir do Visual Studio diretamente a partir do comando *Run*

O seu navegador padrão será aberto com duas janelas: uma para o swagger da aplicação, e uma contendo o frontend da aplicação.




