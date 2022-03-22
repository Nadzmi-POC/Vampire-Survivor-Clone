using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public List<WeaponBase> weapons;

    private float baseAttack = 1f;

    private void Start()
    {
        weapons = new List<WeaponBase>(GetComponentsInChildren<WeaponBase>());

        foreach(WeaponBase weapon in weapons)
        {
            weapon.SetBaseAttack(this.baseAttack);
        }
    }

    public void SetBaseAttack(float value)
    {
        this.baseAttack = value;
    }

    public void ActivateAllWeapons()
    {
        foreach (WeaponBase weapon in weapons)
        {
            weapon.Activate();
        }
    }

    public void DeactivateAllWeapons()
    {
        foreach (WeaponBase weapon in weapons)
        {
            weapon.Deactivate();
        }
    }
}
