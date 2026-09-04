using UnityEngine;
using System.Collections;

// Gerencia a pontuação e o fluxo do jogo do Air Hockey.
// Adaptado do GameManager.cs do Pong.
public class AirHockeyGameManager : MonoBehaviour {

    public static int PlayerScore = 0; // Pontuação do jogador (palheta de baixo, mouse)
    public static int AIScore = 0;     // Pontuação da IA (palheta de cima)

    public GUISkin layout;             // Fonte do placar (mesma ScoreSkin do Pong)
    GameObject thePuck;                // Referência ao disco

    void Start () {
        thePuck = GameObject.FindGameObjectWithTag("Ball");
    }

    // Incrementa a pontuação. O disco entrar no gol de cima (TopGoal) é
    // ponto do jogador; entrar no gol de baixo (BottomGoal) é ponto da IA.
    public static void Score (string goalID) {
        if (goalID == "TopGoal")
        {
            PlayerScore++;
        } else
        {
            AIScore++;
        }
    }

    void OnGUI () {
        GUI.skin = layout;
        GUI.Label(new Rect(Screen.width / 2 - 150 - 12, 20, 100, 100), "" + AIScore);
        GUI.Label(new Rect(Screen.width / 2 + 150 + 12, 20, 100, 100), "" + PlayerScore);

        if (GUI.Button(new Rect(Screen.width / 2 - 60, 35, 120, 53), "RESTART"))
        {
            PlayerScore = 0;
            AIScore = 0;
            thePuck.SendMessage("RestartGame", null, SendMessageOptions.RequireReceiver);
        }
        if (PlayerScore == 9)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER WINS");
            thePuck.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
        } else if (AIScore == 9)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "COMPUTER WINS");
            thePuck.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
        }
    }
}
