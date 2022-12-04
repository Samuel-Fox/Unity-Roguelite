using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    public List<PassiveItems> items = new List<PassiveItems>();
    public GameObject marker;
    public static SpawnItem instance;
    void Awake()
    {
        instance = this;
    }

    public void pickUpItem() 
    {
        int item = Random.Range(0, items.Count);
        items[item].Equip(PlayerController.instance);
        Destroy(marker);
        PlayerController.instance.pItems.Add(items[item]);
    }
} 
