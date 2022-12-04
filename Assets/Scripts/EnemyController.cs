using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float damage = 0.5f;
    public float health;
    public bool bossFlag = false;
    public GameObject ladder;
    // Start is called before the first frame update
    void Start()
    {
        health = 9 + (PlayerController.instance.currentLevel*3);
        if(this.gameObject.tag == "Boss")
        {
            bossFlag = true;
            health = 100 + (PlayerController.instance.currentLevel*25);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            RoomController.instance.ReduceEnemyCount(PlayerMovement.instance.playerPos.x, PlayerMovement.instance.playerPos.y);
            Destroy(gameObject);
            if(bossFlag)
            {
                Instantiate(ladder, new Vector3(PlayerMovement.instance.playerPos.x * 430, PlayerMovement.instance.playerPos.y * 200, 0), Quaternion.identity);
            }
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }
}
