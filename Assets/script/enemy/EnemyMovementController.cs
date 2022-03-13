using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour
{
    public Enemy enemy;

    private Transform player;
    private Stat stat;
    private Rigidbody2D rigidbody;
    private Vector2 movement;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rigidbody = GetComponentInParent<Rigidbody2D>();

        stat = enemy.GetStat();
    }

    void Update()
    {
        if (player != null)
        {
            Vector2 direction = player.position - transform.position;

            direction.Normalize();
            movement = direction;
        }
    }

    private void FixedUpdate()
    {
        if (player != null)
        {
            rigidbody.MovePosition((Vector2)transform.position + (movement * stat.moveSpeed * Time.fixedDeltaTime));
        }
    }
}
