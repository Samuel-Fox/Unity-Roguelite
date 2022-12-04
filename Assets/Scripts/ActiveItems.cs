using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ActiveItems : ScriptableObject
{
    public Sprite sprite;
    public string Name;
    public float moveSpeed;
    public float damage;
    public float attackSpeed;
    public float shotSize;

    public void Equip(ActiveItems activeItem)
    {
        PlayerController.instance.moveSpeed = moveSpeed;
        PlayerController.instance.damage = damage;
        PlayerController.instance.attackSpeed = attackSpeed;
        PlayerController.instance.shotSize = shotSize;
    }
}
