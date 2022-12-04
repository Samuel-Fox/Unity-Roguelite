using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttacks : MonoBehaviour
{
    [SerializeField] private Rigidbody2D boss;
    [SerializeField] private Transform player;
    [SerializeField] private GameObject bossShot;
    [SerializeField] private float attackCooldown;
    private float attackCooldownOver;
    private bool attacking;
    private int whichAttack;
    private bool active = false;
    public static BossAttacks instance;
    void Start() 
    {
        Random.InitState(System.DateTime.Now.Millisecond);
    }
    void Awake()
    {
        instance = this;
        attacking = false;
        whichAttack = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > attackCooldownOver && attacking == false && active) {
            int whichAttackMax = PlayerController.instance.currentLevel+1;
            if(whichAttackMax > 4)
            {
                whichAttack = 4;
            }
            whichAttack = Random.Range(1, whichAttackMax+1);
            if (whichAttack == 1) {
                attacking = true;
                StartCoroutine(UniqueAttack1());
            }
            else if (whichAttack == 2) {
                attacking = true;
                StartCoroutine(UniqueAttack2());
            }
            else if (whichAttack == 3) {
                attacking = true;
                StartCoroutine(UniqueAttack3());
            }
            else if (whichAttack == 4) {
                attacking = true;
                StartCoroutine(UniqueAttack4());
            }
        }
    }

    private IEnumerator UniqueAttack1() 
    {
        attackCooldownOver = Time.time + attackCooldown + 3f;
        for(int i = 0; i < 7; i++)
        {
            Instantiate(bossShot, boss.position, Quaternion.Euler(new Vector3(0, 0, 0+(i*15))));
            Instantiate(bossShot, boss.position, Quaternion.Euler(new Vector3(0, 0, 90+(i*15))));
            Instantiate(bossShot, boss.position, Quaternion.Euler(new Vector3(0, 0, 180+(i*15))));
            Instantiate(bossShot, boss.position, Quaternion.Euler(new Vector3(0, 0, 270+(i*15))));
            yield return new WaitForSeconds(.5f);
        }
        attacking = false;
    }
    private IEnumerator UniqueAttack2() 
    {
        attackCooldownOver = Time.time + attackCooldown + 4f;
        for(int i = 0; i < 20; i++)
        {
            Instantiate(bossShot, boss.position, Quaternion.Euler(new Vector3(0, 0, 0+(i*25))));
            Instantiate(bossShot, boss.position, Quaternion.Euler(new Vector3(0, 0, 180-(i*25))));
            yield return new WaitForSeconds(.2f);
        }
        attacking = false;
    }
    private IEnumerator UniqueAttack3() 
    {
        attackCooldownOver = Time.time + attackCooldown + 6f;
        for(int i = 0; i < 5; i++)
        {
            for(int j = 0; j < 8; j++)
            {
                Instantiate(bossShot, boss.position, Quaternion.Euler(new Vector3(0, 0, (float)(45*j+(i*22.5)))));
            }
            yield return new WaitForSeconds(.5f);
        }
        yield return new WaitForSeconds(3f);
        attacking = false;
    }

    private IEnumerator UniqueAttack4() 
    {
        attackCooldownOver = Time.time + attackCooldown + 4f;
        for(int i = 0; i < 8; i++)
        {
            Instantiate(bossShot, boss.position, Quaternion.Euler(new Vector3(0, 0, 0+(i*5))));
            Instantiate(bossShot, boss.position, Quaternion.Euler(new Vector3(0, 0, 180-(i*5))));
            Instantiate(bossShot, boss.position, Quaternion.Euler(new Vector3(0, 0, 0-(i*5))));
            Instantiate(bossShot, boss.position, Quaternion.Euler(new Vector3(0, 0, 180+(i*5))));
            Instantiate(bossShot, boss.position, Quaternion.Euler(new Vector3(0, 0, 90-(i*5))));
            Instantiate(bossShot, boss.position, Quaternion.Euler(new Vector3(0, 0, 270+(i*5))));
            Instantiate(bossShot, boss.position, Quaternion.Euler(new Vector3(0, 0, 90+(i*5))));
            Instantiate(bossShot, boss.position, Quaternion.Euler(new Vector3(0, 0, 270-(i*5))));
            yield return new WaitForSeconds(.5f); 
        }
        attacking = false;
    }

    private void OnBecameVisible() 
    {
        active = true;
    }

    private void OnBecameInvisible()
    {
        active = false;
    }
}
