using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerData 
{
    public static float moveSpeed = 4;
    public static float damage = 3;
    public static float attackSpeed = 1;
    public static float currentHealth;
    public static float maxHealth = 3;
    public static float shotSize = 1;
    public static int equipped = 0;
    public static PlayerController instance;
    public static List<PassiveItems>  pItems = new List<PassiveItems>();
    public static List<ActiveItems> aItems = new List<ActiveItems>();
    public static int currentLevel = 1;
}
