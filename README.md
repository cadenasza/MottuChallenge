# 🛵 MottuChallenge API

API RESTful desenvolvida em ASP.NET Core, com integração ao banco Oracle via Entity Framework Core, que gerencia informações de motos e ocupações em vagas. Inclui documentação via Swagger/OpenAPI.

## 📌 Descrição do Projeto

O projeto consiste em um sistema que registra motos, atualiza suas informações, e controla a ocupação de vagas por essas motos. A API permite realizar operações de cadastro, busca por diferentes parâmetros, edição e exclusão, além de atualização de vagas associadas.

---

## 🚀 Rotas da API

### 📁 MotoController (`/api/Moto`)
| Método | Rota                        | Descrição                                      |
|--------|-----------------------------|------------------------------------------------|
| GET    | `/api/Moto`                 | Retorna todas as motos                         |
| GET    | `/api/Moto/id/{id}`         | Retorna uma moto pelo ID                       |
| GET    | `/api/Moto/placa/{placa}`   | Retorna uma moto pela placa                    |
| POST   | `/api/Moto`                 | Adiciona uma nova moto                         |
| PUT    | `/api/Moto/{id}`            | Atualiza uma moto existente                    |
| PUT    | `/api/Moto/{id}/vaga`       | Atualiza a vaga associada à moto               |
| DELETE | `/api/Moto/{id}`            | Remove uma moto do sistema                     |

### 📁 OcupacaoController (`/api/Ocupacao`)
| Método | Rota               | Descrição                           |
|--------|--------------------|-------------------------------------|
| POST   | `/api/Ocupacao`    | Registra uma nova ocupação         |

---

## 🧰 Tecnologias Utilizadas

- **ASP.NET Core** 7+
- **Entity Framework Core**
- **Oracle Database**
- **Swagger/OpenAPI** para documentação
- **Migrations EF Core** para gerenciamento do banco

---
## 👥 Integrantes
- **RM557528 - Leonardo Cadena de Souza**
- **RM554890 - Davi Gonzaga Ferreira**
- **RM558785 - Julia Vasconcelos Oliveira**
- 📧 Contato: leonardocadenasza@gmail.com
