using UnityEngine;
using System.Collections;

// Controla o movimento vertical de uma raquete do Pong.
// Baseado nos slides 10, 11 e 12 do material "2 - Pong".
public class PlayerControls : MonoBehaviour {

    public KeyCode moveUp = KeyCode.W;      // Move a raquete para cima
    public KeyCode moveDown = KeyCode.S;    // Move a raquete para baixo
    public float speed = 10.0f;             // Define a velocidade da raquete
    public float boundY = 2.25f;            // Define os limites em Y
    private Rigidbody2D rb2d;               // Define o corpo rigido 2D que representa a raquete

    void Start () {
        rb2d = GetComponent<Rigidbody2D>();     // Inicializa a raquete
    }

    void Update () {

        var vel = rb2d.linearVelocity;                // Acessa a velocidade da raquete
        if (Input.GetKey(moveUp)) {             // Velocidade da Raquete para ir para cima
            vel.y = speed;
        }
        else if (Input.GetKey(moveDown)) {      // Velocidade da Raquete para ir para baixo
            vel.y = -speed;
        }
        else {
            vel.y = 0;                          // Velocidade para manter a raquete parada
        }
        rb2d.linearVelocity = vel;                    // Atualiza a velocidade da raquete

        var pos = transform.position;           // Acessa a posição da raquete
        if (pos.y > boundY) {
            pos.y = boundY;                     // Corrige a posição da raquete caso ultrapasse o limite superior
        }
        else if (pos.y < -boundY) {
            pos.y = -boundY;                    // Corrige a posição da raquete caso ultrapasse o limite inferior
        }
        transform.position = pos;               // Atualiza a posição da raquete

    }
}
