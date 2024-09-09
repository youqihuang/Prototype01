using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombAudio : MonoBehaviour
{
     private AudioSource audioSource;

    void Start()
    {
        // Get the AudioSource component attached to this GameObject
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the ball collided with the sprite
        if (collision.gameObject.CompareTag("SoccerSprite"))
        {
            // Play the bounce sound
            if (audioSource != null)
            {
                audioSource.Play();
            }
        }
    }
}
