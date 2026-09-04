using UnityEngine;
using System.Collections;

// Detecta quando o disco entra em um dos gols (em cima ou embaixo) - Air Hockey.
// Adaptado do SideWalls.cs do Pong.
public class GoalTrigger : MonoBehaviour {

    void OnTriggerEnter2D (Collider2D hitInfo) {
        if (hitInfo.tag == "Ball")
        {
            string goalName = transform.name; // "TopGoal" ou "BottomGoal"
            AirHockeyGameManager.Score(goalName);
            hitInfo.gameObject.SendMessage("RestartGame", null, SendMessageOptions.RequireReceiver);
        }
    }
}
