
## Descrição de funcionalidades

- As rotas são protegidas por autenticação. Onde o usuário precisa estar registrado e logado (como administrador, gerente ou vendedor).

Estão sendo feitas validações dos campos das ViewModels passadas nas telas, de acordo com os critérios informados na documentação.

### Fabricantes
- Listagem das Fabricantes
- Criação
- Edição
- Deleção

### Concessionária
- Listagem
- Criação
    - Ao digitar o CEP, é realizada uma requisição Ajax para API externa do [ViaCep](https://viacep.com.br/), que carrega as informações daquele CEP nos campos de endereço.
- Edição
- Deleção

### Veículos
- Listagem
- Criação
    - Ao digitar o CPF, é realizada uma requisição Ajax para consultar se o cliente já possui cadastro. Caso haja, carrega as informações. Caso o cliente não esteja cadastrado, esse cliente será criado.
- Edição
- Deleção