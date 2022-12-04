using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PassiveItems : ScriptableObject
{
    public Sprite sprite;
    public string Name;
    public float moveSpeed;
    public float damage;
    public float attackSpeed;
    public float health;

    public void Equip(PlayerController player)
    {
        player.moveSpeed += moveSpeed;
        player.damage += damage;
        player.attackSpeed += attackSpeed;
        player.maxHealth += health;
        player.currentHealth += health;
    }
}
