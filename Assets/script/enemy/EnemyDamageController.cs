using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageController : MonoBehaviour
{
    private Stat stat;

    private void Start()
    {
        Enemy enemy = GetComponentInParent<Enemy>();

        stat = enemy?.stat;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if (player != null)
        {
            Debug.Log(JsonUtility.ToJson(player, true));
            HPController hpController = collision.GetComponent<HPController>();
            hpController?.Damage(stat.attack);
        }
    }
}
