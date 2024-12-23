using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public PlayerHealth pHealth;
    public float damage;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //pHealth.health -= damage;

            //incase of many enemys
            other.gameObject.GetComponent<PlayerHealth>().health -= damage;

            /*if(pHealth <= 0)
            {
                Destroy(gameObject);
            }*/
        }
    }
}
