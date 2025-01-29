# 🎭 MisteryDoors  

Projeto final da disciplina de **Técnicas de Programação**, desenvolvido por **Mariana Pereira, Andriel Henrique e Brunno Bocardo**.  
Trata-se de um jogo simples, mas seguindo todos os requisitos do projeto.  

![image](https://github.com/user-attachments/assets/2f99b2a2-514a-4744-bdbd-2616079b187f)
![image](https://github.com/user-attachments/assets/1388ed20-3bec-4fff-8384-a5df05923511)


## 📌 Roadmap  

### 📖 1. Introdução  
Breve descrição do projeto, mencionando que se trata de um jogo simples desenvolvido como projeto final da disciplina de Técnicas de Programação.  

### ⚙️ 2. Tecnologias Utilizadas  
- C#  
- .NET  
- MySQL  
- MySQL Workbench  
- Entity Framework (se aplicável)  

---

## 🚀 3. Como Configurar o Projeto  

### 🔹 3.1 Clonando o Repositório  
```sh
git clone https://github.com/seu-usuario/misterydoors.git
```
### 3.2 Configurando o Banco de Dados
1. Instale o MySQL e o MySQL Workbench, caso ainda não estejam instalados.
2. Crie o banco de dados (schema) no MySQL: `CREATE DATABASE mistery_doors;`
3. Configure a string de conexão no arquivo Program.cs
4. Localize a linha onde a conexão é configurada e substitua com seus dados: `string connectionString = "server=localhost;uid=root;pwd=admin;database=mistery_doors";`
5. Mude para todas as ocorrencias no projeto.

### 3.3 Possível complicação
Se houver erros ao conectar ao banco de dados, tente as seguintes soluções:
- Desinstale a extenção nuGet chamada mysql.data e instale-a novamente


