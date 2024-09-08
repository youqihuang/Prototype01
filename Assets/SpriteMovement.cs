using UnityEngine;

public class SpriteMovement : MonoBehaviour
{
    public float speed = 5.0f; 
    private float screenWidth;
    private float spriteWidth;
    private float extraMovement = 0.0508f; // 2 inches in meters

    void Start()
    {
        screenWidth = Camera.main.orthographicSize * Camera.main.aspect;
        spriteWidth = GetComponent<SpriteRenderer>().bounds.extents.x;
    }

    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        float moveAmount = moveInput * speed * Time.deltaTime;
        float newX = transform.position.x + moveAmount;

        // Add extra movement space to the boundaries
        float minBoundary = -screenWidth + spriteWidth - extraMovement;
        float maxBoundary = screenWidth - spriteWidth + extraMovement;

        newX = Mathf.Clamp(newX, minBoundary, maxBoundary);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }
}