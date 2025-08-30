# 🎮 GameSystem BackEnd

## 📌 Sobre o Projeto
O **GameSystem BackEnd** é uma aplicação desenvolvida em **.NET 8** com foco em arquitetura limpa e boas práticas de desenvolvimento.  
O sistema foi projetado para gerenciar jogos e usuários, servindo como base de estudos em **DDD (Domain-Driven Design)**, **Clean Architecture** e **Testes Unitários**.

---

## 🏗️ Arquitetura
O projeto segue os princípios da **Clean Architecture**, garantindo separação de responsabilidades e alta manutenibilidade.

- **Domain** → Contém as entidades e interfaces de negócio.
- **Application** → Serviços de aplicação, DTOs e casos de uso.
- **Infrastructure** → Implementação de repositórios, persistência e dependências externas.
- **Presentation** → Exposição de endpoints (API).
- **Tests** → Testes unitários com **xUnit**.

📂 Estrutura básica:
```
/GamesSystemBackEnd
│── Application
│── Domain
│── Infrastructure
│── Presentation
│── Tests
```

---

## 🛠️ Tecnologias & Bibliotecas
- **.NET 8**
- **Entity Framework Core** → ORM para persistência de dados
- **xUnit** → Testes unitários
- **FluentAssertions** → Asserções mais legíveis
- **Moq** → Criação de mocks para testes
- **Dependency Injection** → Injeção de dependência nativa do .NET

---

## ✅ Testes
O projeto inclui testes unitários cobrindo casos de uso principais:
- `GetAllGamesServiceTests`
- `GetGameByIdServiceTests`
- `CreateGameServiceTests`

Para rodar os testes:
```bash
dotnet test
```

---

## 🚀 Como Executar
1. Clone o repositório:
```bash
git clone https://github.com/seu-usuario/GameSystem.git
```

2. Acesse a pasta do projeto:
```bash
cd GameSystem
```

3. Restaure as dependências:
```bash
dotnet restore
```

4. Execute a aplicação:
```bash
dotnet run --project Presentation
```

---

## 🧪 Como Rodar os Testes
```bash
dotnet test
```

---

## 📖 Contribuição
- Fork este repositório
- Crie uma branch: `git checkout -b minha-feature`
- Faça commit: `git commit -m 'Minha nova feature'`
- Push: `git push origin minha-feature`
- Abra um **Pull Request** 🎉

---

## 👨‍💻 Autor Rangel Pedro Monteiro
Desenvolvido como parte de estudos avançados em **.NET, Arquitetura Limpa e Testes Automatizados**.

