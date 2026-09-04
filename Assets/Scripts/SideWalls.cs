using UnityEngine;
using System.Collections;

// Detecta quando a bola ultrapassa a parede lateral (ponto) - Pong.
// Baseado no slide 29 do material "2 - Pong".
public class SideWalls : MonoBehaviour {

    // Verifica colisões da bola nas paredes
    void OnTriggerEnter2D (Collider2D hitInfo) {
        if (hitInfo.tag == "Ball")
        {
            string wallName = transform.name;
            GameManager.Score(wallName);
            hitInfo.gameObject.SendMessage("RestartGame", null, SendMessageOptions.RequireReceiver);
        }
    }
}
