using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "weapon-stat", menuName = "Common/Weapon Stat")]
public class WeaponStat : ScriptableObject
{
    public float fireRate = 1f;
    public float damage = 0f;
    public float cooldownTime = 1f;
}
