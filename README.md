# ValidaSenha

Esta é uma simples API para validação de senha que responde se a string recebida atende aos critérios para considerá-la válida. 


### Regras
- Nove ou mais caracteres
- Ao menos 1 dígito
- Ao menos 1 letra minúscula
- Ao menos 1 letra maiúscula
- Ao menos 1 caractere especial (Considere como especial os seguintes caracteres: !@#$%^&*()-+)
- Não possuir caracteres repetidos dentro do conjunto

**Exemplo:**  
```
IsValid("") // false  
IsValid("aa") // false  
IsValid("ab") // false  
IsValid("AAAbbbCc") // false  
IsValid("AbTp9!foo") // false  
IsValid("AbTp9!foA") // false
IsValid("AbTp9 fok") // false
IsValid("AbTp9!fok") // true 
```

## Pré-requisitos

- Dotnet core 2.2

## Ferramentas

- Visual Studio 
- SOAPUI 
- Terminal
- Git

## Executando o projeto

Certifique-se que está com o dotnet core 2.2 Utilizando um terminal execute o seguinte comando:
```
dotnet --version
```
o resultado deve ser uma versão 5.0.xxx

### Executando os projetos de teste

Não consegui criar o projeto de testes para o projeto, será feito posteriormente.

### Consultando documentação da API(Swagger)

Com a API em execução, em um browser, acesse [https://localhost:44372](https://localhost:44372/index.html) para entra na página do Swagger onde será possivel ver informações sobre os endpoints, que neste caso é apenas um, e até fazer testes.

### Enviando uma string para teste

É possível enviar uma string para a validação dos critérios da senha através do próprio swagger, ou utilizando alguma ferramenta REST Client como [SoapUI](https://www.soapui.org/).

Utilizando o SOAPUI,, que é meu favorito, siga os seguintes passos para enviar o teste:

1)File -> New Rest Project
2)Escolher POST na área principal da Request1 que irá abrir.
3)Em Parameters colocar ?password=AbTp9!fok e executar

Caso o mesmo esteja OK, irá retornar a a resposta abaixo:

```
  <data contentType="text/plain; charset=utf-8" contentLength="7"><![CDATA[Valid]]></data>
```

### Dificuldade enfrentas

 - Toda minha carreira é voltada para ERP em especial ERP Protheus da TOTVS com sua linguagem de programação ADVPL, logo meu primeiro desafio foi recapitular processo de orientação objeto e como efetuar a montagem de um API, mas com a ajuda do GOOGLE eu espero ter alçando a qualidade esperada pela equipe e espero que caso não esteja de acordo, me enviem um feedback para que possa evoluir.
 - No problema em si não estava claro se era um GET ou POST.
