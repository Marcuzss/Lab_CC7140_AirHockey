using UnityEngine;
using System.Collections;

// Controla a palheta do jogador (embaixo) seguindo o mouse.
// Baseado nos slides 7, 8 e 9 do material "3 - Air Hockey".
// Também limita a palheta à sua própria metade da mesa
// (os jogadores não podem invadir o campo adversário - slide 11).
public class MouseControl : MonoBehaviour
{

    public float speed = 15.0f;    // Velocidade máxima da palheta em direção ao mouse
    public float minX = -3.5f;     // Limite esquerdo da mesa
    public float maxX = 3.5f;      // Limite direito da mesa
    public float minY = -5.7f;     // Limite perto do próprio gol
    public float maxY = -0.3f;     // Linha central - não pode invadir o campo adversário

    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector3 playerPos = transform.position;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        Vector3 dir = mousePos - playerPos;
        float dist = dir.magnitude;

        Vector3 vel;
        if (dist < 0.02f)
        {
            // O mouse já está praticamente em cima da palheta: para, em vez de "tremer"
            vel = Vector3.zero;
        }
        else
        {
            dir /= dist; // normaliza sem repetir o calculo de magnitude
            // Desacelera perto do alvo, assim nao ultrapassa e volta (que causava o "piscar")
            float moveSpeed = Mathf.Min(speed, dist / Time.fixedDeltaTime);
            vel = dir * moveSpeed;
        }

        var v = rb2d.linearVelocity;
        v.x = vel.x;
        v.y = vel.y;
        rb2d.linearVelocity = v;

        // Impede que a palheta invada o campo do adversário ou saia da mesa
        var pos = transform.position;
        if (pos.x > maxX) pos.x = maxX;
        if (pos.x < minX) pos.x = minX;
        if (pos.y > maxY) pos.y = maxY;
        if (pos.y < minY) pos.y = minY;
        transform.position = pos;
    }
}