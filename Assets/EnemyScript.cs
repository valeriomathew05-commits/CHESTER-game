using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int health = 10;

    public GameObject deathEffect;

    public void takeDamage (int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Die();
        }
    }

    // Start is called before the first frame update
    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
