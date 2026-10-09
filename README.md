# 🕵️ Missão README — Desafio Lógica (Verificador de Palíndromos)

![Linguagem](https://img.shields.io/badge/linguagem-Python%203-blue?logo=python&logoColor=white)
![Licença](https://img.shields.io/badge/licença-MIT-green)
![Status](https://img.shields.io/badge/status-concluído-brightgreen)
![Disciplina](https://img.shields.io/badge/disciplina-GQS-orange)

> Fork do repositório original [`danhpaiva/gqs-algoritmo-01-py`](https://github.com/danhpaiva/gqs-algoritmo-01-py), documentado como atividade da disciplina **Garantia da Qualidade de Software (GQS)**.

> ⚠️ **Observação importante:** o enunciado da atividade faz referência a uma versão em **Java** do desafio (classe `DesafioLogica`, comandos `javac`/`java`, uso de `StringBuilder`). Este repositório, no entanto, contém a versão em **Python** do mesmo exercício (`DesafioLogica.py`). A documentação abaixo foi adaptada para refletir fielmente o código realmente presente no repositório, mantendo o mesmo raciocínio lógico pedido no roteiro.

---

## 📌 Nível 1 — O Básico da Investigação

### O que o código faz?

O script implementa um **verificador de palíndromos** em Python. Um palíndromo é uma palavra, frase ou sequência de caracteres que se lê da mesma forma de trás para frente, desde que sejam ignorados espaços, pontuação e diferenças entre maiúsculas/minúsculas (ex.: *"Socorram-me, subi no ônibus em Marrocos"*).

A função principal, `analisar(entrada)`, recebe um texto, faz uma "limpeza" nele (removendo tudo que não seja letra ou número e padronizando para minúsculas) e verifica se o resultado é igual ao seu próprio reverso. O bloco principal do script (`if __name__ == "__main__":`) usa essa função para testar duas frases de exemplo e imprime o resultado no console.

### Como executar?

O projeto não possui dependências externas — usa apenas a biblioteca padrão do Python (`re`).

1. **Clone o repositório forkado:**
   ```bash
   git clone https://github.com/luizfelp74/gqs-algoritmo-01-py.git
   cd gqs-algoritmo-01-py
   ```

2. **Verifique se o Python 3 está instalado:**
   ```bash
   python3 --version
   ```

3. **Execute o script diretamente** (não é necessário compilar, pois Python é uma linguagem interpretada):
   ```bash
   python3 DesafioLogica.py
   ```
   > Em ambientes Windows, o comando pode ser apenas `python DesafioLogica.py`.

### Exemplo de saída

Ao rodar o comando acima, o console exibe exatamente:

```
Teste 1: False
Teste 2: True
```

---

## 🔬 Nível 2 — Engenharia Reversa e Análise de Comportamento

### O papel do bloco `if __name__ == "__main__":`

Esse bloco é o **ponto de entrada** do script — o equivalente Python ao método `main` de outras linguagens (como Java ou C). Ele só é executado quando o arquivo é rodado diretamente (`python3 DesafioLogica.py`), e não quando o arquivo é importado como módulo por outro script. É responsável por:

1. Declarar as duas strings de teste (`texto1` e `texto2`);
2. Chamar a função `analisar()` para cada uma delas;
3. Imprimir o resultado formatado no console usando *f-strings*.

### Desvendando o método `analisar(entrada)` linha por linha

```python
def analisar(entrada):
    if entrada is None:
        return False

    limpa = re.sub(r'[^a-zA-Z0-9]', '', entrada).lower()

    invertida = limpa[::-1]

    return limpa == invertida
```

| Linha | O que faz |
|---|---|
| `if entrada is None: return False` | Guarda de segurança: se nenhum texto for passado (`None`), a função retorna `False` imediatamente, evitando erros ao tentar processar um valor inexistente. |
| `re.sub(r'[^a-zA-Z0-9]', '', entrada)` | Usa expressão regular para **substituir por nada (remover)** qualquer caractere que **não** seja letra de `a-z`, `A-Z` ou número `0-9`. O `^` dentro dos colchetes nega o conjunto, ou seja, o padrão significa "tudo que não for letra/número". Isso elimina espaços, vírgulas, hífens e também **caracteres acentuados** (como `ô`, `ã`, `ç`), já que eles não pertencem à faixa ASCII `a-zA-Z`. |
| `.lower()` | Converte toda a string resultante para minúsculas, garantindo que a comparação não diferencie maiúsculas de minúsculas (ex.: `S` e `s` são tratados como iguais). |
| `invertida = limpa[::-1]` | Usa o recurso de **slicing** (fatiamento) do Python. A sintaxe `[início:fim:passo]` com passo `-1` percorre a string de trás para frente, criando uma cópia invertida — é o jeito "pythônico" de inverter uma string, dispensando um `StringBuilder` como se faria em Java. |
| `return limpa == invertida` | Compara a string limpa com sua versão invertida. Se forem idênticas, o texto é um palíndromo (`True`); caso contrário, não é (`False`). |

### O mistério dos testes: por que `Teste 1: False` e `Teste 2: True`?

**Teste 1 — `"A sacada da casa de cadasa"` → `False`**

À primeira vista a frase parece ter "cara" de palíndromo (repete sílabas como "casa", "cada", "sacada"), mas não é uma construída de fato para ser simétrica. Depois da limpeza (remoção de espaços e caixa baixa), o texto vira:

```
asacadadacasadecadasa
```

Comparando essa string com seu reverso, a partir do 4º caractere elas já divergem (`c` vira `d`), então `limpa != invertida` e a função retorna `False`. É uma frase "pega-ratão": soa como um palíndromo por causa da repetição de sons parecidos, mas a ordem exata das letras não é espelhada.

**Teste 2 — `"Socorram-me, subi no ônibus em Marrocos"` → `True`**

Esta é uma frase clássica da língua portuguesa, conhecida justamente por ser um palíndromo perfeito. Após a limpeza da pontuação, do hífen, dos espaços e da conversão para minúsculas, restam apenas as letras — inclusive o `ô` de "ônibus" é **descartado** pela regex (pois não está no intervalo `a-zA-Z0-9`), resultando em:

```
socorrammesubinonibusemmarrocos
```

Ao ler essa sequência de trás para frente, ela é exatamente igual à original, caractere por caractere. Por isso `limpa == invertida` é verdadeiro e a função retorna `True`.

---

## ✨ Nível 3 — Toque Profissional

### Resumo técnico

| Item | Detalhe |
|---|---|
| Linguagem | Python 3 |
| Bibliotecas usadas | `re` (biblioteca padrão) |
| Paradigma | Procedural / funcional simples |
| Entrada | Nenhuma (strings fixas no código) |
| Saída | Impressão no console (`print`) |
| Dependências externas | Nenhuma |

### 👤 Sobre o Autor

Fork e documentação realizados como parte da atividade **"Missão README"** da disciplina **Garantia da Qualidade de Software (GQS)**, ministrada pelo Prof. Daniel Henrique Matos de Paiva.

> Sinta-se à vontade para abrir uma *issue* ou *pull request* com sugestões de melhoria neste README ou no código analisado. 🚀
