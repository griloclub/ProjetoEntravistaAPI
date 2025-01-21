# **ProjetoTesteDev**

Este projeto é uma API desenvolvida em **.NET 8** para gerenciar mesas e comandas em um sistema de restaurante. Ele inclui autenticação JWT, integração com banco de dados SQL Server usando Entity Framework Core, e foi projetado com boas práticas de Clean Code e SOLID.

---

## **Pré-requisitos**

Certifique-se de que você tem os seguintes softwares instalados:

- [SDK .NET 8](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/pt-br/sql-server)
- [Git](https://git-scm.com/)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) ou [VS Code](https://code.visualstudio.com/)

---

## **Configuração do Ambiente**

1. **Clone o repositório**:
   ```bash
   git clone https://github.com/seu-usuario/ProjetoTesteDev.git
   cd ProjetoTesteDev
   ```

2. **Configurar o Banco de Dados**:
   - No arquivo `appsettings.json`, atualize a string de conexão para apontar para o seu servidor SQL Server:
     ```json
     "ConnectionStrings": {
       "DefaultConnection": "Server=SEU_SERVIDOR;Database=ProjetoTesteDev;Trusted_Connection=True;MultipleActiveResultSets=true"
     }
     ```

3. **Restaurar os pacotes NuGet**:
   - Execute o comando no diretório do projeto:
     ```bash
     dotnet restore
     ```

4. **Aplicar as migrações**:
   - Crie o banco de dados e aplique as migrações:
     ```bash
     dotnet ef database update
     ```
5. **Ao aplicar as migrações, o banco será criado e populado automaticamente com dados iniciais para testes. **
    - Esses dados são configurados no método OnModelCreating da classe SqlServerDbContext, localizada na pasta DataContext.
    - Você pode verificar essas informações realizando um SELECT diretamente no banco de dados ou revisando a configuração do seed na classe mencionada.
    - O seed foi projetado para fornecer informações essenciais, permitindo que você teste os principais recursos da API sem necessidade de inserção manual de dados.
  
6. **Executar o projeto**:
   - No diretório do projeto principal, execute:
     ```bash
     dotnet run
     ```

---

## **Testando o Projeto**

1. **Configurar o Swagger**:
   - Utilize os endpoints disponíveis para testar os recursos da API.

2. **Autenticação JWT**:
   - Use o endpoint `/api/Auth/login` para obter um token JWT.
   - Inclua o token na autorização para acessar os endpoints protegidos (clique em "Authorize" no Swagger).

3. **Executar os testes unitários**:
   - Navegue até o diretório do projeto de testes:
     ```bash
     cd ProjetoTesteDev.Tests
     ```
   - Execute os testes com:
     ```bash
     dotnet test
     ```

---

## **Estrutura do Projeto**

```plaintext
ProjetoTesteDev/
│
├── Controllers/
│   ├── AuthController.cs
│   ├── MesaController.cs
│
├── Dtos/
│   ├── LoginRequestDto.cs
│   ├── LoginResponseDto.cs
│   ├── MesaResumoDto.cs
│   ├── MesaDetalhesDto.cs
│
├── Models/
│   ├── UsuarioModel.cs
│   ├── MesaModel.cs
│   ├── ItemConsumidoModel.cs
│
├── Repository/
│   ├── Usuario/
│   │   ├── IUsuarioRepository.cs
│   │   ├── UsuarioRepository.cs
│   ├── Mesa/
│       ├── IMesaRepository.cs
│       ├── MesaRepository.cs
│
├── Service/
│   ├── Token/
│       ├── ITokenService.cs
│       ├── TokenService.cs
│
├── appsettings.json
├── Program.cs
└── Startup.cs
```

---

## **Endpoints Disponíveis**

### **Autenticação**
- `POST /api/Auth/login`: Realizar login e obter o token JWT.

### **Mesas**
- `GET /api/Mesa/abertas`: Lista todas as mesas abertas.
- `GET /api/Mesa/Detalhes?id={id}`: Detalhes de uma mesa específica.

---

## **Contribuindo**

Se quiser contribuir com este projeto:

1. Faça um fork do repositório.
2. Crie uma branch para a sua feature:
   ```bash
   git checkout -b minha-feature
   ```
3. Realize as alterações e faça commit:
   ```bash
   git commit -m "Adiciona nova feature"
   ```
4. Envie as alterações:
   ```bash
   git push origin minha-feature
   ```
5. Abra um Pull Request.

---

## **Licença**

Este projeto é licenciado sob a [MIT License](LICENSE).
