using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    public float speed = 5f; // Speed of the spaceship
    public float fireRate = 0.5f; // Rate of fire
    public GameObject bulletPrefab; // Prefab of the bullet
    public Transform firePoint; // Point where bullets are instantiated

    private float maxCooldown = .2f;
    private float cooldown = 0;

    // Define boundaries for the game area
    public float minX = -6.5f;
    public float maxX = 6.5f;
    public float minY = -4.6f;
    public float maxY = 4.6f;

    void Update()
    {
        // Movement
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0f);
        transform.Translate(movement * speed * Time.deltaTime);

        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, minX, maxX);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, minY, maxY);
        transform.position = clampedPosition;

        // Firing
        if (Input.GetButton("Jump") && cooldown <= 0)
        {
            cooldown = maxCooldown;
            Fire();
        }
        cooldown -= Time.deltaTime;
    }

    void Fire()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
