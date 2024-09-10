using UnityEngine;

public class SpriteEffect : MonoBehaviour
{
    private ParticleSystem lightningSpeed; // Renamed from particleSystem
    private bool isMoving = false;
    public float offset = 1f;

    void Start()
    {
        lightningSpeed = GetComponentInChildren<ParticleSystem>();
        if (lightningSpeed == null)
        {
            Debug.LogError("No ParticleSystem found in children.");
        }
    }

    void Update()
    {
        // adjust particle direction based on which way player moves
        Vector3 newPos = transform.position;
        float horizontal = Input.GetAxis("Horizontal");
        if (horizontal < 0)
        {
            newPos.x = transform.position.x + offset;
            lightningSpeed.transform.position = newPos;
            lightningSpeed.Play();
            isMoving = true;
        }
        else if (horizontal > 0)
        {   
            newPos.x = transform.position.x - offset;
            lightningSpeed.transform.position = newPos;
            lightningSpeed.Play();
            isMoving = true;
        }
        else {
            lightningSpeed.Pause();
            lightningSpeed.Clear();
            isMoving = false;
        }
        // if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) ||
        //     Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        // {
        //     if (!isMoving)
        //     {
        //         lightningSpeed.Play();
        //         isMoving = true;
        //     }
        // }
        // else
        // {
        //     if (isMoving)
        //     {
        //         lightningSpeed.Stop();
        //         isMoving = false;
        //     }
        // }
    }
}
