using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreCollision(this.GetComponent<CircleCollider2D>(), BossAttacks.instance.GetComponent<BoxCollider2D>());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * 10 * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("BossAttack"))
        {
            Physics2D.IgnoreCollision(other.collider, this.GetComponent<Collider2D>());
        }
        if(other.gameObject.CompareTag("Player"))
        {
            PlayerHealth.instance.TakeDamage(.5f);
        }
        if(!other.gameObject.CompareTag("PlayerAttack"))
        {
            Destroy(gameObject);
        }
        
    }
}
