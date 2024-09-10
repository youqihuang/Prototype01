using UnityEngine;

public class SpriteEffect : MonoBehaviour
{
    private ParticleSystem lightningSpeed; // Renamed from particleSystem
    private bool isMoving = false;

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
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) ||
            Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            if (!isMoving)
            {
                lightningSpeed.Play();
                isMoving = true;
            }
        }
        else
        {
            if (isMoving)
            {
                lightningSpeed.Stop();
                isMoving = false;
            }
        }
    }
}
