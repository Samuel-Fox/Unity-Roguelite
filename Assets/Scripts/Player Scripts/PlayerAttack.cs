using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject attack;
    [SerializeField] private Transform player;
    private float attackCooldown;
    // Start is called before the first frame update

    private void Awake() 
    {
        attackCooldown = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(0f, 0f, rotZ);

        if(Input.GetMouseButton(0) && Time.time > attackCooldown)
        {
            attackCooldown = Time.time + (1/PlayerController.instance.attackSpeed);
            GameObject scale = Instantiate(attack, player.position, Quaternion.Euler(0f, 0f, rotZ));
            scale.transform.localScale = new Vector3(PlayerController.instance.shotSize, PlayerController.instance.shotSize, 0);
        }
    }
}
