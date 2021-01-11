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
- Postman 
- Terminal
- Git

## Executando o projeto

Certifique-se que está com o dotnet core 2.2 Utilizando um terminal execute o seguinte comando:
```
dotnet --version
```
o resultado deve ser uma versão 2.2.xxx

### Executando os projetos de teste

Na Solution há dois projetos de teste, um de unidade e outro de integração. Para executá-los, utilizando um termnal, navegue até o diretório raiz do projeto e execute o seguinte comando:
```
dotnet test
```
Um saída semelhante a seguinte deverá aparecer no terminal com os resultados dos testes

```console
...
Starting test execution, please wait...

A total of 1 test files matched the specified pattern.
Starting test execution, please wait...

A total of 1 test files matched the specified pattern.

Test Run Successful.
Total tests: 6
     Passed: 6
 Total time: 1.0125 Seconds

Test Run Successful.
Total tests: 11
     Passed: 11
 Total time: 1.2782 Seconds
```

### Executando o projeto da API

Para execução do projeto da API, utilizando um terminal, navegue até o diretório raiz do projeto e execute o seguinte comando:
```
dotnet run --project ./src/ValidaSenha.csproj
```
A seguinte informação deverá aparecer no terminal:
```console
info: Microsoft.Hosting.Lifetime[0]
      Now listening on: https://localhost:5001
info: Microsoft.Hosting.Lifetime[0]
      Now listening on: http://localhost:5000
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Development
info: Microsoft.Hosting.Lifetime[0]
```

### Consultando documentação da API(Swagger)

Com a API em execução, em um browser, acesse [https://localhost:44372](https://localhost:44372/index.html) para entra na página do Swagger onde será possivel ver informações sobre os endpoints, que neste caso é apenas um, e até fazer testes.

### Enviando uma string para teste

É possível enviar uma string para a validação dos critérios da senha através do próprio swagger, ou utilizando alguma ferramenta REST Client como [Postman](https://www.postman.com/).

Utilizando o Postman, que é meu favorito, siga os seguintes passos para enviar o teste:
1) Vá em **Preferences**, na guia **General** e desabilite a opção **SSL Certificate verification**. Isso é necessário pois não estamos utilizando um certificado e o postman não fará a requisição se estiver levando isso em conta.
2) Na área principal crie uma nova aba e no método onde está **GET**, altere para **POST**
3) No campo para URL insira `https://localhost:5001/api/validasenha`
4) Nas guias abaixo selecione **Body** e nas opções que aparecerão abaixo selecione **raw**. No combo no final desta linha de opções onde está **Text** altere para **JSON**
5) No campo de seguinte insira a estrutura com a string que deseja testar
```
{
  "input": "AbTp9!fok"
}
```
6) Clique no botão **Send**. A resposta da requisição surgirá em um campo abaixo
```
{
  "output": Valid
}
```
O retorno do output será **true** quando a senha atender às [regras](#regras) e **false** quando não atender a uma ou mais regras.    

### Dificuldade enfrentadas.

 - Toda minha carreira é voltada para ERP em especial ERP Protheus da TOTVS com sua linguagem de programação ADVPL, logo meu primeiro desafio foi recapitular processo de orientação objeto e como efetuar a montagem de um API, mas com a ajuda do GOOGLE eu espero ter alçando a qualidade esperada pela equipe e espero que caso não esteja de acordo, me enviem um feedback para que possa evoluir.
 - No problema em si não estava claro se era um GET ou POST.
