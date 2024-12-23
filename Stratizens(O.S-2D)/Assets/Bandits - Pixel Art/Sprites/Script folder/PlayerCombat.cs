using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class NewBehaviourScript : MonoBehaviour
{

public Animator animator;
public Transform attackPoint;
public float attackRange = 0.5f;
public LayerMask enemyLayers;

public int attackDamage = 40;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }

    void Attack()
    {
          animator.SetTrigger("Attack");   

          Collider2D [] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

          foreach(Collider2D enemy in hitEnemies)
          {
             enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
          }
}

public void DealDamage(EnemyTracker enemy, float damage)
    {
        if (enemy.isProcessing)
        {
            // Apply damage logic here
            enemy.health -= damage;

            if (enemy.health <= 0)
            {
                enemy.RecordDeath(); // Notify when the enemy dies
            }
        }
    }


void OnDrawGizmosSelected()
{
    if(attackPoint == null)
        return;

    Gizmos.DrawWireSphere(attackPoint.position, attackRange);
}
}
