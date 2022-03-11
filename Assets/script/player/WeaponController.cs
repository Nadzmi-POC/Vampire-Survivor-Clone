using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public List<WeaponBase> weapons;

    private void Start()
    {
        weapons = new List<WeaponBase>(GetComponentsInChildren<WeaponBase>());
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
