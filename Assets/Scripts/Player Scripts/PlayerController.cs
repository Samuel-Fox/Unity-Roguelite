using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 4;
    public float damage = 3;
    public float attackSpeed = 1;
    public float currentHealth;
    public float maxHealth = 3;
    public float shotSize = 1;
    public int equipped = 0;
    public static PlayerController instance = null;
    public List<PassiveItems> pItems = new List<PassiveItems>();
    public List<ActiveItems> aItems = new List<ActiveItems>();
    public int currentLevel = 1;
    public bool checkStats = false;
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if(!instance)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        currentHealth = maxHealth;
        checkStats = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(checkStats)
        {
            aItems[equipped].Equip(aItems[equipped]);
            RefreshStats();
        }
        if(currentHealth <= 0) 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            ResetStatic.ResetData();
            transform.position = new Vector3(0, 0, 0);
            PlayerMovement.instance.playerPos.x = 0;
            PlayerMovement.instance.playerPos.y = 0;
        }
        if(Input.GetAxisRaw("Mouse ScrollWheel") != 0)
        {
            if(Input.GetAxisRaw("Mouse ScrollWheel") > 0)
            {
                equipped += 1;
                if(equipped > aItems.Count-1)
                {
                    equipped = 0;
                }
            }
            else 
            {
                equipped -= 1;
                if(equipped < 0)
                {
                    equipped = aItems.Count-1;
                }
            }
            aItems[equipped].Equip(aItems[equipped]);
            RefreshStats();
        }
    }

    private void OnTriggerStay2D(Collider2D other) 
    {
        if(other.tag == "Item")
        {
            SpawnItem.instance.pickUpItem();
        }
    }

    public void OnCollisionStay2D(Collision2D other)
    {
        if(Time.time > PlayerHealth.instance.immunityOver && other.gameObject.CompareTag("Enemy")) 
        {
            PlayerHealth.instance.TakeDamage(1f);
        }
    }

    public void RefreshStats() 
    {
        foreach(PassiveItems item in pItems)
        {
            item.Equip(this);
        }
    }
}
