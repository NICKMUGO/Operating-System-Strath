using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public float speed = 10f; // Movement speed
    private Transform target; // Target to follow (player)

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (target != null)
        {
            MoveTowardsTarget();
        }
    }

    public void SetTarget(Transform playerTarget)
    {
        target = playerTarget; // Set the player as the target
    }

    void MoveTowardsTarget()
    {
        // Move the enemy towards the player's position
        Vector3 direction = (target.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;

        // Optional: Rotate the enemy to face the player
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Damage Taken");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy Died");
        Destroy(gameObject);
    }
}
