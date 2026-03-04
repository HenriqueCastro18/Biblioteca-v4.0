# 📚 Sistema de Gestão de Biblioteca v4.0

Bem-vindo ao meu projeto de **Gerenciamento de Biblioteca**. Desenvolvi este software em C# com o objetivo de criar uma ferramenta robusta, modular e profissional para o controle de acervos, alunos e fluxos de empréstimos, utilizando o que há de melhor em padrões de projeto (**Design Patterns**) e integração com APIs externas.

---

## 🚀 Funcionalidades Principais

Neste sistema, implementei as seguintes capacidades:
- **Gestão de Alunos**: Cadastro completo com Nome e RA único, garantindo integridade nos registros.
- **Controle de Acervo**: Adição manual de livros e busca automatizada via **Google Books API**.
- **Sistema de Empréstimos**: Lógica de negócio que impede um aluno de retirar mais de um livro simultaneamente e valida a disponibilidade do exemplar.
- **Monitoramento de Atrasos**: Sistema que calcula o tempo de posse e sinaliza devoluções pendentes em tempo real.
- **Administração**: Área restrita com login e função de Reset Total do Banco de Dados para manutenção rápida.

---

## 🛠️ Tecnologias Utilizadas

- **Linguagem**: C# (.NET Core)
- **Banco de Dados**: MySQL (Persistência de dados segura)
- **Biblioteca Externa**: `Newtonsoft.Json` (Para processamento dos dados JSON da API do Google)
- **Interface**: Console Application com design ASCII otimizado para máxima compatibilidade com o CMD/Terminal.

---

## 📐 Padrões de Projeto (Design Patterns)

Apliquei padrões de projeto clássicos para garantir que o código seja fácil de manter, testar e expandir:

1.  **Command Pattern**: Cada ação (adicionar, listar, excluir) é um objeto independente. Isso permitiu a implementação do **Undo (Desfazer)**, revertendo a última ação no banco de dados.
2.  **Singleton Pattern**: O `Menu_Singleton` centraliza o desenho da interface, garantindo que apenas uma instância gerencie a tela, economizando recursos.
3.  **Template Method**: Padronizei a execução dos serviços (Secretaria, Biblioteca, Empréstimos), garantindo que todos sigam o mesmo fluxo de processamento de entrada.

---

## ⚙️ Como Configurar e Rodar

1.  **Banco de Dados**: Execute o script SQL (disponível na pasta `/Database`) no seu MySQL Workbench ou XAMPP.
2.  **Configuração**: Verifique a string de conexão no arquivo `Repositorio.cs` (Server, Database, Uid, Pwd).
3.  **Dependências**: Certifique-se de restaurar os pacotes NuGet (especialmente o `Newtonsoft.Json` e `MySql.Data`).
4.  **Acesso Padrão**:
    - **Usuário**: `admin`
    - **Senha**: `1234`

---

## 💡 Aprendizados Técnicos

Desenvolver este projeto me permitiu consolidar conhecimentos críticos em:
- Consumo de **APIs REST** e tratamento de dados JSON.
- Gerenciamento de integridade referencial (`FOREIGN KEYS` e `CASCADE`) em bancos relacionais.
- Criação de interfaces de usuário (UX) em modo texto, priorizando a clareza e o fluxo didático.

---

### Autor
**Henrique Castro / HenriqueCastro18** <br>
GitHub: https://github.com/HenriqueCastro18 <br>
Linkedin: https://www.linkedin.com/in/henrique-castro-b13798345/
