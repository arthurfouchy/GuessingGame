# Guessing Game

Jogo interativo de adivinhação baseado em uma **árvore binária de decisão com 11 animais**, replicando a lógica do projeto em C# em uma interface web minimalista com visualização em tempo real do percurso.

🔗 **Jogar online (GitHub Pages):** [https://arthurfouchy.github.io/GuessingGame/](https://arthurfouchy.github.io/GuessingGame/)

---

## Como funciona

* **Navegação pela árvore:** cada pergunta divide o caminho em dois ramos — **Não (`N`)** desce para a **esquerda** e **Sim (`S`)** desce para a **direita**.
* **Palpite e confirmação:** ao chegar a um nó folha, o jogo exibe o animal e pergunta se acertou.
* **Em caso de erro:** você pode optar por tentar outro palpite na rodada ou iniciar uma nova partida.
* **Mapa em tempo real:** exibe o caminho percorrido, o nó atual e permite alternar entre exibir apenas o caminho atual ou a árvore completa.

---

## Atalhos e controles

| Ação | Tecla / Botão |
| :--- | :--- |
| Responder **Sim** | `S` ou botão **Sim (S)** |
| Responder **Não** | `N` ou botão **Não (N)** |
| Reiniciar partida | `R` ou botão **Reiniciar (R)** |
| Alternar visualização | Botão **Mostrar árvore inteira** / **Ocultar não visitados** |

---

## Estrutura do projeto

* `index.html` — interface web, lógica da árvore de decisão e renderização SVG.
* `GuessGame.slnx` (e pasta do projeto C#) — solução original de referência em C#.
* `README.md` — documentação do projeto.

---

## Como rodar ou publicar

1. Abra o arquivo `index.html` diretamente no navegador para jogar local.
2. Para publicar ou atualizar no **GitHub Pages**, envie o `index.html` e o `README.md` para o branch `main` (`/` root):
   ```bash
   git add index.html README.md
   git commit -m "Adiciona README com link do GitHub Pages"
   git push
   ```
