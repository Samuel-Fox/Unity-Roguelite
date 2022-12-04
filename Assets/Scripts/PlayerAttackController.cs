using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreCollision(this.GetComponent<CircleCollider2D>(), PlayerController.instance.GetComponent<BoxCollider2D>());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * 20 * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Boss"))
        {
            EnemyController enemy = other.gameObject.GetComponent<EnemyController>();
            enemy.TakeDamage(PlayerController.instance.damage);
        }
        if(!other.gameObject.CompareTag("BossAttack"))
        {
            Destroy(gameObject);
        }
    }

}
