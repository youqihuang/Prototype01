using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerBallAudio : MonoBehaviour
{
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
         audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
   void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the ball collided with the sprite
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("balls");
            // Play the bounce sound
            if (audioSource != null)
            {
                Debug.Log("soccer ball hit noise");
                audioSource.Play();
            }
        }
    }
}
