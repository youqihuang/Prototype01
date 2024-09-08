using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] GameObject[] ballPrefab; 
    [SerializeField] float secondSpawn = 2f;
    [SerializeField] float increaseFactor = 0.75f;
    [SerializeField] float minTras;
    [SerializeField] float maxTras;
    [SerializeField] public LogicScript logicManager;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BallSpawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Kick()
    {
        logicManager.addScore();
        // increase speed
        if (logicManager.playerScore % 5 == 0){
            secondSpawn *= increaseFactor;
        }
    }

    IEnumerator BallSpawn() {
        while(true){
            var wanted = Random.Range(minTras, maxTras);
            var position = new Vector3(wanted, transform.position.y);
            GameObject gameObject = Instantiate(ballPrefab[Random.Range(0, ballPrefab.Length)], position, Quaternion.identity);
            yield return new WaitForSeconds(secondSpawn);
            Destroy(gameObject, 5f);
        }
    }
}
