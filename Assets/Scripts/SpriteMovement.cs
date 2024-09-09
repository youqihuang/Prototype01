using UnityEngine;

public class SpriteMovement : MonoBehaviour
{
    public float speed = 5.0f; 
    private float screenWidth;
    private float spriteWidth;
    private float extraMovement = 0.0508f; // 2 inches in meters
    public Sprite hitSprite;
    private bool hitFlag = false;
    public float spriteTime = 3f;
    private float spriteTimer;
    public Sprite normalSprite;

    void Start()
    {
        screenWidth = Camera.main.orthographicSize * Camera.main.aspect;
        spriteWidth = GetComponent<SpriteRenderer>().bounds.extents.x;
        spriteTimer = spriteTime;
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

        // timer for when player is hit
        if(hitFlag){
            spriteTimer -= Time.deltaTime;
            if (spriteTimer <= 0){
                hitFlag = false;
                spriteTimer = spriteTime;
                SpriteRenderer spriteRenderer = this.GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = normalSprite;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Bomb"){
            SpriteRenderer spriteRenderer = this.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = hitSprite;
            hitFlag = true;
        }

    }
}