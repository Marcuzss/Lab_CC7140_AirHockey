using UnityEngine;
using System.Collections;

// IA básica que controla a palheta de cima, pedida no exercício do
// slide 11 do material "3 - Air Hockey" ("IA básica controlando o
// player de cima"). Ela persegue o disco no eixo X e avança/recua
// no eixo Y para defender o próprio gol, sem invadir o campo do
// jogador (mesma regra do slide 11 aplicada à IA).
public class AIControl : MonoBehaviour {

    public float speed = 6.0f;     // Velocidade de reação da IA
    public float minX = -3.5f;     // Limite esquerdo da mesa
    public float maxX = 3.5f;      // Limite direito da mesa
    public float minY = 0.3f;      // Linha central - não pode invadir o campo do jogador
    public float maxY = 5.7f;      // Limite perto do próprio gol

    private Rigidbody2D rb2d;
    private Transform puck;

    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        GameObject ball = GameObject.FindGameObjectWithTag("Ball");
        if (ball != null) {
            puck = ball.transform;
        }
    }

    void Update () {
        if (puck == null) return;

        // Alvo: acompanha o X do disco; só avança para perto do centro
        // quando o disco está do lado da IA, senão recua para defender o gol.
        Vector3 targetPos = transform.position;
        targetPos.x = puck.position.x;
        targetPos.y = (puck.position.y > 0f) ? minY + 0.6f : maxY - 0.6f;

        Vector3 dir = targetPos - transform.position;
        dir.Normalize();

        Vector3 speedVec = dir * speed;

        var vel = rb2d.linearVelocity;
        vel.x = speedVec.x;
        vel.y = speedVec.y;
        rb2d.linearVelocity = vel;

        // Impede que a IA invada o campo do jogador ou saia da mesa
        var pos = transform.position;
        if (pos.x > maxX) pos.x = maxX;
        if (pos.x < minX) pos.x = minX;
        if (pos.y > maxY) pos.y = maxY;
        if (pos.y < minY) pos.y = minY;
        transform.position = pos;
    }
}
