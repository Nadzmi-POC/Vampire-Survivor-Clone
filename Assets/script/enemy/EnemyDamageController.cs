using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageController : MonoBehaviour
{
    private Stat stat;

    private void Start()
    {
        EnemyController enemy = GetComponentInParent<EnemyController>();

        stat = enemy?.stat;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        HPController hpController = collision.GetComponent<HPController>();
        hpController?.Damage(stat.attack);
    }
}
