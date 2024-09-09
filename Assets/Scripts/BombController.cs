using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    //public CinemachineImpulseSource source;
    public GameObject particles;
    // Start is called before the first frame update
    void Start()
    {
        //source = GetComponent<CinemachineImpulseSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            //source.GenerateImpulse();
            Instantiate(particles, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
