using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public float speed = 10f; // Movement speed
    private Transform target; // Target to follow (player)

    private Animator animator;

    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
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
    Vector3 direction = (target.position - transform.position).normalized;

    // Move towards the target
    if (direction.magnitude > 0.1f) // Check if there is significant movement
    {
        animator.SetBool("isMoving", true); // Enable running animation
        transform.position += direction * speed * Time.deltaTime;
    }
    else
    {
        animator.SetBool("isMoving", false); // Stop running animation
    }

    // Optional: Flip the sprite for 2D games
    if (direction.x < 0)
        transform.localScale = new Vector3(-1, 1, 1); // Flip horizontally
    else
        transform.localScale = new Vector3(1, 1, 1);  // Default orientation
}



    public void TakeDamage(int damage)
    {
        if (currentHealth <= 0) return;

        currentHealth -= damage;

        if (currentHealth > 0)
        {
            animator.SetTrigger("Hurt");
        }
        else
        {
            Die();
        }
    }

    void Die()
    {
        animator.SetTrigger("Death");
        speed = 0;
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        Destroy(gameObject, 0.3f);
    }
}
