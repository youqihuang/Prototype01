using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{

    public float hitStopDuration = 0.1f; 
    public float hitStopTimeScale = 0.0f;
    private bool isHitstopActive = false;

    public void StartHitstop()
    {
        if (!isHitstopActive)
        {
            StartCoroutine(Hitstop());
        }
    }

    // hitstop coroutine
    private IEnumerator Hitstop()
    {
        isHitstopActive = true;
        float originalTimeScale = Time.timeScale;
        Time.timeScale = hitStopTimeScale;
        yield return new WaitForSecondsRealtime(hitStopDuration);
        Time.timeScale = originalTimeScale;
        isHitstopActive = false;
    }
}
