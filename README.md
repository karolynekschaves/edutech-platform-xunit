# 🎓 EduTechPlatform

O **EduTechPlatform** é uma solução desenvolvida em .NET criada para gerenciar e validar regras de negócio essenciais nos âmbitos acadêmico e financeiro de uma instituição de ensino. O projeto foi projetado com separação clara de responsabilidades entre a camada de aplicação/domínio e a suíte de testes unitários automatizados.

## 📋 Sumário

* [Visão Geral](#-visão-geral)
* [Requisitos do Ambiente](#-requisitos-do-ambiente)
* [Arquitetura e Serviços](#-arquitetura-e-serviços)
* [Padronização de Commits](#-padronização-de-commits)
* [Guia de Execução (CLI)](#-guia-de-execução-cli)
* [Estratégia e Cobertura de Testes](#-estratégia-e-cobertura-de-testes)

## 🚀 Visão Geral

A plataforma provê serviços centrais para:

1. Cálculo de médias ponderadas e determinação de situação acadêmica dos alunos.
2. Monitoramento e validação de frequência escolar mínima.
3. Aplicação de regras financeiras para desconto de mensalidade e elegibilidade de rematrícula.

## 🛠️ Requisitos do Ambiente

Para compilar e executar o projeto localmente, certifique-se de ter instalado em sua máquina:

* **.NET 10.0 SDK** (ou superior)
* Um terminal/prompt de comando de sua preferência (PowerShell, Bash, CMD)
* IDE ou Editor Recomendado: Visual Studio/ VS Code

Para verificar se o SDK do .NET 10 está instalado corretamente, execute:

```bash
dotnet --version
```

## 🧱 Arquitetura e Serviços

O projeto principal (`EduTechPlatform.App`) é composto por três classes de serviço, cada uma responsável por um domínio específico:

### 1. `NotaDesempenhoService`

Responsável pela avaliação das notas e desempenho acadêmico dos alunos.

* **`CalcularMediaPonderada(decimal nota1, decimal nota2, decimal notaProjeto)`**: Calcula a média ponderada com os pesos 3 (Nota 1), 3 (Nota 2) e 4 (Nota do Projeto).
* **`ObterSituacaoAcademica(decimal mediaFinal)`**: Classifica o aluno em `APROVADO` (média $\ge 7.0$), `RECUPERACAO` (média entre $5.0$ e $6.99$) ou `REPROVADO` (média $< 5.0$).

### 2. `FrequenciaService`

Responsável pela gestão de presenças e assiduidade.

* **`CalcularPorcentagemPresenca(int aulasTotais, int faltas)`**: Retorna o percentual de presenças do aluno com base no total de aulas ministradas.
* **`AprovadoPorFrequencia(int aulasTotais, int faltas)`**: Determina se o aluno cumpriu o requisito mínimo de **75% de presença** para aprovação.

### 3. `MatriculaFinanceiraService`

Responsável pelo cálculo de valores de mensalidade e permissão de matrícula.

* **`CalcularValorMensalidade(decimal valorBase, int diaPagamento, bool eBolsista)`**: Aplica 50% de desconto para bolsistas ou 10% de desconto por pontualidade para não bolsistas que pagarem até o dia 5.
* **`PodeRealizarRematricula(bool possuiPendenciaFinanceira, string situacaoAcademica)`**: Avalia se o aluno está apto a renovar a matrícula (necessário não possuir pendências financeiras e não estar com situação `REPROVADO`).

## 📌 Padronização de Commits

Para manter o histórico do repositório limpo, auditável e granular, adotou-se a estratégia de **commits separados por classes/funcionalidades**. 

Cada classe desenvolvida ou atualizada (seja de serviço ou de teste) teve suas alterações enviadas ao repositório através de um commit dedicado.

### Exemplos do Padrão de Commits Utilizado:

* **Configuração da estrutura:**
  `feat: setup inicial da solução e projetos da EduTechPlatform`
* **Implementação de Serviços (Dev 1):**
  `feat(service): adiciona classe NotaDesempenhoService`
  `feat(service): adiciona classe FrequenciaService`
  `feat(service): adiciona classe MatriculaFinanceiraService`
* **Implementação de Testes (Dev 2):**
  `test(qa): adiciona testes parametrizados para NotaDesempenhoService`
  `test(qa): adiciona testes parametrizados para FrequenciaService`
  `test(qa): adiciona testes parametrizados para MatriculaFinanceiraService`

## 💻 Guia de Execução (Comandos .NET CLI)

Siga as etapas abaixo a partir do diretório raiz da solução para restaurar, compilar e testar a aplicação:

### 1. Restaurar as Dependências

Restaura os pacotes necessários especificados nos arquivos de projeto:

```bash
dotnet restore
```

### 2. Compilar a Solução

Compila todos os projetos (`EduTechPlatform.App` e `EduTechPlatform.Tests`):

```bash
dotnet build
```

### 3. Executar a Suíte de Testes

Roda todos os testes unitários com detalhamento no terminal:

```bash
dotnet test
```

Para uma saída mais detalhada dos testes aprovados:

```bash
dotnet test --logger "console;verbosity=detailed"
```

## 🧪 Estratégia e Cobertura de Testes

Os testes da aplicação foram construídos no projeto `EduTechPlatform.Tests` utilizando o framework **xUnit**.

### Testes Parametrizados com `[Theory]` e `[InlineData]`

A validação das regras de negócio utiliza o recurso de **testes parametrizados** do xUnit via as anotações `[Theory]` e `[InlineData]`. Essa abordagem permite executar o mesmo método de teste com múltiplos conjuntos de dados de entrada e saídas esperadas, garantindo alta cobertura e legibilidade no código de testes.

#### Exemplo de Cobertura nos Testes:

* **Notas e Médias:**

  ```csharp
  [Theory]
  [InlineData(7.0, 7.0, 7.0, 7.0)]
  [InlineData(10.0, 10.0, 5.0, 8.0)]
  public void CalcularMediaPonderada_DeveRetornarMediaCorreta(...);
  ```

* **Frequência e Assiduidade:**

  ```csharp
  [Theory]
  [InlineData(80, 20, true)]   // 75% -> Aprovado
  [InlineData(80, 21, false)]  // < 75% -> Reprovado
  public void AprovadoPorFrequencia_DeveValidarPresencaMinima(...);
  ```

* **Regras Financeiras:**

  ```csharp
  [Theory]
  [InlineData(1000.00, 10, true, 500.00)]   // Bolsista (50% off)
  [InlineData(1000.00, 4, false, 900.00)]   // Pontualidade (10% off)
  [InlineData(1000.00, 10, false, 1000.00)] // Sem desconto
  public void CalcularValorMensalidade_DeveCalcularValorCorreto(...);
  ```

---
*EduTechPlatform - Módulo de Serviços Core e Qualidade de Software.*


```
Anna Vitória Rocha Dias - 325118421  - Dev Backend / Core    
Maycon Gomes - 325125878 - QA / Testes Unitários    
Karolyne Silva - 32517941 - Documentação e DevOps / Versionamento. 
