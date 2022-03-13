using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingWeapon : WeaponBase
{
    private Collider2D collider;
    private SpriteRenderer spriteRenderer;

    private float elapsedTime = 0f;

    private void Start()
    {
        collider = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (collider == null)
        {
            LogHelper.ShowErrorLog(this.name, "Property 'collider' must have a value.");
        }
        if (spriteRenderer == null)
        {
            LogHelper.ShowErrorLog(this.name, "Property 'spriteRenderer' must have a value.");
        }
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= this.stat.cooldownTime)
        {
            elapsedTime = elapsedTime % 1f;
            this.isActive = !this.isActive;
        }

        collider.enabled = isActive;
        spriteRenderer.enabled = isActive;
    }

    protected override void OnHit(Collider2D collision, float baseAttack)
    {
        HPController hpController = collision.GetComponent<HPController>();
        hpController?.Damage(baseAttack + this.stat.damage);
    }
}
