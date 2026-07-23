using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamagesPlayer : MonoBehaviour
{
    public int damage;
    public PlayerHealth playerHealth;

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerHealth.TakeDamage(damage);
        }
    }
}
