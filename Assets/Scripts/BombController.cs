using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class BombController : MonoBehaviour
{
    public CinemachineImpulseSource source;
    public GameObject particles;
    // Start is called before the first frame update
    private AudioSource audioSource;
    private LogicScript logicScript;

    void Start()
    {
        source = GetComponent<CinemachineImpulseSource>();
        audioSource = GameObject.FindGameObjectWithTag("BombAudio").GetComponent<AudioSource>();
        logicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            source.GenerateImpulse();
            Instantiate(particles, transform.position, Quaternion.identity);
            audioSource.Play();
            logicScript.StartHitstop();
            Destroy(gameObject);
        }
    }
}
