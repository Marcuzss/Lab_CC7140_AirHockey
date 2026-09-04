using UnityEngine;
using System.Collections;

// Toca um som quando o objeto colide com algo.
// Código do slide 10 do material "3 - Air Hockey" ("Adicionando som").
public class CollisionSound : MonoBehaviour {

    public AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }
    void OnCollisionEnter2D (Collision2D coll) {
        source.Play();
    }
}
