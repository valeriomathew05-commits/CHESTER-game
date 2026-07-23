using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 2;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D (Collider2D hitInfo)
    {
        // Print the name of whatever object the bullet just touched!
        Debug.Log("Bullet hit: " + hitInfo.gameObject.name);

        if (hitInfo.CompareTag("Player"))
        {
            return;
        }

        EnemyScript enemy = hitInfo.GetComponent<EnemyScript>();
        if(enemy != null)
        {
            enemy.takeDamage(damage);
        }
        Destroy(gameObject);
    }
}
