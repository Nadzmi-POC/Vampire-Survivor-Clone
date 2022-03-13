using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageController : MonoBehaviour
{
    private float baseAttack = 1f;

    public void SetBaseAttack(float value)
    {
        this.baseAttack = value;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        EntityController controller = collision.GetComponent<EntityController>();

        if (controller?.type == EntityType.player)
        {
            HPController hpController = controller?.hpController;
            hpController.Damage(baseAttack);
        }
    }
}
