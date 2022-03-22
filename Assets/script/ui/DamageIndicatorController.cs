using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageIndicatorController : MonoBehaviour
{
    public HPController hpController;
    public GameObject damagePopupPrefab;

    private void OnEnable()
    {
        hpController.OnDamaged += Damaged;
    }

    private void OnDisable()
    {
        hpController.OnDamaged -= Damaged;
    }

    void Damaged(OnDamagedEvent eventVal)
    {
        DamagePopup damageIndicator = Instantiate(damagePopupPrefab, transform.position, transform.rotation).GetComponent<DamagePopup>();
        damageIndicator.SetDamageValue(eventVal.value);
    }
}
