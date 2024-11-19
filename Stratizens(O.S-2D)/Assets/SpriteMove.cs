using UnityEngine;

public class SpriteMover : MonoBehaviour
{
    private float speed;

    private void Update()
    {
        // Move the sprite to the right
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the sprite collides with a wall (you can tag your wall objects accordingly)
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject); // Destroy the sprite on collision
        }
    }
}