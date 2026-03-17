# Funcionario-WebAPI

API REST para gerenciamento de funcionários construída com **.NET 10** e **ASP.NET Core**. Implementa operações CRUD completas com padrão de serviço, respostas padronizadas e documentação via Swagger.

## Tecnologias

| Tecnologia            | Versão | Finalidade                        |
| --------------------- | ------ | --------------------------------- |
| .NET / ASP.NET Core   | 10     | Framework principal               |
| Entity Framework Core | latest | ORM para acesso ao banco de dados |
| SQL Server            | -      | Banco de dados relacional         |
| Swagger / OpenAPI     | -      | Documentação interativa da API    |

## Arquitetura

O projeto segue uma arquitetura em camadas com separação de responsabilidades:

```text
WebApi_video/
├── Controllers/
│   └── FuncionarioController.cs     # Camada de apresentação — expõe os endpoints HTTP
├── Service/
│   └── FuncionarioService/
│       ├── IFuncionarioInterface.cs  # Contrato (interface) do serviço
│       └── FuncionarioService.cs    # Implementação da lógica de negócio
├── Models/
│   ├── FuncionarioModels.cs         # Entidade / DTO principal
│   └── ServiceResponse.cs          # Wrapper genérico de resposta da API
├── Enums/
│   ├── DepartamentoEnum.cs          # Enum de departamentos
│   └── TurnoEnum.cs                 # Enum de turnos de trabalho
├── DataContext/
│   └── ApplicationDbContext.cs      # Contexto do Entity Framework Core
├── Migrations/                      # Migrações geradas pelo EF Core
└── Program.cs                       # Configuração e inicialização da aplicação
```

## Modelo de Dados

### FuncionarioModels

| Campo         | Tipo             | Descrição                                         |
| ------------- | ---------------- | ------------------------------------------------- |
| Id            | int              | Identificador único (chave primária)              |
| Nome          | string           | Nome do funcionário                               |
| Sobrenome     | string           | Sobrenome do funcionário                          |
| Departamento  | DepartamentoEnum | Departamento ao qual pertence                     |
| Turno         | TurnoEnum        | Turno de trabalho                                 |
| Ativo         | bool             | Status ativo (`true`) / inativo (`false`)         |
| DataCriacao   | DateTime         | Data e hora de criação do registro                |
| DataAlteracao | DateTime         | Data e hora da última alteração                   |

### ServiceResponse\<T\>

Todas as respostas da API são encapsuladas neste wrapper genérico:

```json
{
  "dados": { },
  "mensagem": "string",
  "sucesso": true
}
```

| Campo    | Tipo   | Descrição                                    |
| -------- | ------ | -------------------------------------------- |
| Dados    | T?     | Dados retornados pela operação               |
| Mensagem | string | Mensagem descritiva (erros, avisos, etc.)    |
| Sucesso  | bool   | Indica se a operação foi executada com êxito |

## Enums

### DepartamentoEnum

| Valor | Nome        | Descrição                                 |
| ----- | ----------- | ----------------------------------------- |
| 1     | Rh          | Recursos Humanos — gestão de pessoal      |
| 2     | Financeiro  | Financeiro — gestão financeira            |
| 3     | Compras     | Compras — aquisições                      |
| 4     | Atendimento | Atendimento — relacionamento com clientes |
| 5     | Zeladoria   | Zeladoria — limpeza e manutenção          |

### TurnoEnum

| Valor | Nome  | Horário    |
| ----- | ----- | ---------- |
| 1     | Manha | 06h às 14h |
| 2     | Tarde | 14h às 22h |
| 3     | Noite | 22h às 06h |

## Endpoints

Base URL: `/api/Funcionario`

| Método     | Rota                          | Descrição                                       | Retorno                              |
| ---------- | ----------------------------- | ----------------------------------------------- | ------------------------------------ |
| `GET`      | `/`                           | Lista todos os funcionários cadastrados         | `ServiceResponse<List<Funcionario>>` |
| `GET`      | `/{id}`                       | Busca um funcionário pelo ID                    | `ServiceResponse<Funcionario>`       |
| `POST`     | `/`                           | Cadastra um novo funcionário                    | `ServiceResponse<List<Funcionario>>` |
| `PUT`      | `/`                           | Atualiza os dados de um funcionário existente   | `ServiceResponse<List<Funcionario>>` |
| `PUT`      | `/inativaFuncionario?id={id}` | Inativa um funcionário (define `Ativo = false`) | `ServiceResponse<List<Funcionario>>` |
| `DELETE`   | `/{id}`                       | Remove um funcionário pelo ID                   | `ServiceResponse<List<Funcionario>>` |

### Exemplo de requisição — Criar funcionário

```http
POST /api/Funcionario
Content-Type: application/json

{
  "nome": "João",
  "sobrenome": "Silva",
  "departamento": "Financeiro",
  "turno": "Manha",
  "ativo": true
}
```

### Exemplo de resposta

```json
{
  "dados": [
    {
      "id": 1,
      "nome": "João",
      "sobrenome": "Silva",
      "departamento": "Financeiro",
      "turno": "Manha",
      "ativo": true,
      "dataCriacao": "2026-03-17T10:00:00",
      "dataAlteracao": "2026-03-17T10:00:00"
    }
  ],
  "mensagem": "",
  "sucesso": true
}
```

## Como Executar

### Pré-requisitos

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- SQL Server (local ou remoto)

### Passo a passo

1. Clone o repositório:

   ```bash
   git clone https://github.com/GabrielPedrosoFerreira/Funcionario-WebAPI.git
   cd Funcionario-WebAPI/WebApi_video
   ```

2. Configure a connection string em `appsettings.json`:

   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=SEU_SERVIDOR;Database=FuncionarioDB;Trusted_Connection=True;TrustServerCertificate=True;"
     }
   }
   ```

3. Execute as migrações para criar o banco de dados:

   ```bash
   dotnet ef database update
   ```

4. Inicie a aplicação:

   ```bash
   dotnet run
   ```

5. Acesse a documentação interativa no Swagger:

   ```text
   https://localhost:{porta}/swagger
   ```

   > A rota raiz `/` redireciona automaticamente para o Swagger em ambiente de desenvolvimento.

## Injeção de Dependência

O serviço é registrado com tempo de vida **Scoped** no `Program.cs`:

```csharp
builder.Services.AddScoped<IFuncionarioInterface, FuncionarioService>();
```

Isso garante que uma nova instância do serviço seja criada por requisição HTTP.
