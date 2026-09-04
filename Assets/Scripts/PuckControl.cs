using UnityEngine;
using System.Collections;

// Controla o comportamento do disco do Air Hockey.
public class PuckControl : MonoBehaviour
{

    public float maxSpeed = 18f;   // Limite de velocidade - evita acumular velocidade demais e atravessar as paredes

    private Rigidbody2D rb2d;

    void GoBall()
    {
        float rand = Random.Range(0, 2);
        if (rand < 1)
        {
            rb2d.AddForce(new Vector2(-15, 20));
        }
        else
        {
            rb2d.AddForce(new Vector2(15, -20));
        }
    }

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Invoke("GoBall", 2);
    }

    void FixedUpdate()
    {
        // Trava a velocidade do disco no maximo, mesmo depois de varias colisoes seguidas
        if (rb2d.linearVelocity.magnitude > maxSpeed)
        {
            rb2d.linearVelocity = rb2d.linearVelocity.normalized * maxSpeed;
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Player"))
        {
            Vector2 vel;
            vel.y = rb2d.linearVelocity.y;
            vel.x = (rb2d.linearVelocity.x / 2) + (coll.collider.attachedRigidbody.linearVelocity.x / 3);
            rb2d.linearVelocity = vel;
        }
    }

    void ResetBall()
    {
        rb2d.linearVelocity = Vector2.zero;
        transform.position = Vector2.zero;
    }

    void RestartGame()
    {
        ResetBall();
        Invoke("GoBall", 1);
    }
}