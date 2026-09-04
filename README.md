# Pong + Air Hockey — Projeto Unity

Projeto Unity 2D montado a partir dos slides **"2 - Pong"** e **"3 - Air Hockey"**,
usando os assets fornecidos (`Assets (1).zip` e `air_hockey (1).zip`).

## Como abrir

1. Abra o **Unity Hub**.
2. Clique em **Add** (ou **Open**) → **Add project from disk**.
3. Selecione a pasta `PongAirHockey` (a pasta que contém `Assets`, `ProjectSettings`
   e `Packages`).
4. O projeto foi montado como texto compatível com o Unity **2022.3 LTS**. Se o seu
   Unity Hub tiver uma versão diferente instalada, ele vai perguntar se quer
   "atualizar" o projeto para a sua versão — pode aceitar normalmente.
5. Depois de abrir, vá em **File > Open Scene** e escolha:
   - `Assets/Scenes/Pong.unity` — o Pong clássico (slides 8 a 30).
   - `Assets/Scenes/AirHockey.unity` — a evolução para Air Hockey (slides 6 a 11).

As duas cenas já estão registradas em **File > Build Settings**, então
**Build and Run** (slide 30 do Pong) funciona direto.

## Pong (`Pong.unity`)

Montado seguindo exatamente os passos do slide "2 - Pong":

- Raquetes com `Rigidbody2D` (Kinematic) + `BoxCollider2D`, controladas pelo
  script `PlayerControls.cs`.
  - Jogador da esquerda: **W** (cima) / **S** (baixo).
  - Jogador da direita: **seta para cima** / **seta para baixo**.
- Bola com `Rigidbody2D` (Dynamic, gravidade zerada) + `CircleCollider2D`
  usando o material `BallBounce` (sem atrito, 100% elástico), controlada por
  `BallControl.cs`.
- Quatro paredes (`TopWall`, `BottomWall`, `LeftWall`, `RightWall`); as duas
  laterais são gatilhos (`Is Trigger`) com o script `SideWalls.cs`, que chama
  `GameManager.Score(...)`.
- `GameManager.cs` desenha o placar e o botão RESTART via `OnGUI`, usando a
  fonte `ScoreSkin` (do arquivo `ScoreSkin.guiskin` fornecido). Vence quem
  chegar a 10 pontos.

**Não implementado de propósito:** o slide 31 ("Exercício") pede para você
mesmo adicionar duas bolas, uma raquete controlada por computador, efeitos
sonoros e dificuldade crescente — fica como exercício, igual o material
propõe.

## Air Hockey (`AirHockey.unity`)

Evolução do Pong descrita no slide "3 - Air Hockey", com o exercício do
slide 11 implementado:

- Mesa vertical usando `background.png` como imagem de fundo.
- Palheta azul (embaixo) controlada pelo **mouse**, script `MouseControl.cs`
  (código dos slides 7‑9: segue o mouse por velocidade, não por teleporte).
- Palheta vermelha (em cima) controlada por uma **IA básica**,
  `AIControl.cs`: persegue o disco no eixo X e avança/recua para defender o
  próprio gol.
- Ambas as palhetas são limitadas à sua própria metade da mesa (não invadem
  o campo adversário, como pede o exercício).
- Palhetas redondas (`CircleCollider2D`) usando `mallet_blue.png` e
  `mallet_red.png`.
- Gols reduzidos (não a parede inteira) nas partes de cima e de baixo, com
  cores diferentes (marcador vermelho no gol de cima, azul no de baixo),
  script `GoalTrigger.cs` chamando `AirHockeyGameManager.Score(...)`.
- Som de colisão do disco via `CollisionSound.cs` (código do slide 10) — veja
  a observação sobre o áudio abaixo.
- Placar por `OnGUI`, igual ao Pong. Vence quem fizer 9 pontos (referência ao
  "9 goals" mencionado no próprio slide 4).

**Sobre o eixo do jogo:** como os gols do Air Hockey ficam em cima/embaixo
(e não nas laterais, como no Pong), os scripts `PuckControl.cs` e
`GoalTrigger.cs` são versões do `BallControl.cs`/`SideWalls.cs` do Pong com
os eixos X/Y invertidos.

## Observação sobre o som

Nenhum arquivo de áudio veio nos `.zip` enviados (o slide 10 só mostra o
código, sem indicar qual som usar: *"Adicione o som escolhido..."*). Para o
projeto já funcionar direto, gerei um som curto de "toc" sintetizado
(`Assets/Audio/hit.wav`) e associei ao `AudioSource` do disco. Fique à
vontade para trocar esse clipe por outro som de sua preferência — basta
arrastar o novo arquivo de áudio para o campo **Audio Clip** do componente
`Audio Source` do objeto `Puck`.

## Ideias para ir além (slide 12 do Air Hockey)

Não implementadas — ficam como sugestão de continuação, como o próprio slide
propõe ("Vá além!"):
- Perspectiva com o adversário mais distante da câmera.
- Obstáculos destrutíveis no meio da mesa.
- Multiplayer cooperativo / entrada de novos jogadores por tecla.

## Estrutura de pastas

```
PongAirHockey/
  Assets/
    Scenes/    Pong.unity, AirHockey.unity
    Scripts/   os 10 scripts C# (ver lista acima)
    Sprites/   PongPaddle.jpg, Ball.png, mallet_red.png, mallet_blue.png,
               puck.png, background.png
    Fonts/     6809 chargen.ttf
    GUI/       ScoreSkin.guiskin
    Physics/   BallBounce.physicsMaterial2D
    Audio/     hit.wav (som de colisão placeholder)
  ProjectSettings/
  Packages/
```
