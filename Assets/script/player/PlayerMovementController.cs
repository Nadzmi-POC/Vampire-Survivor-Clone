using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    private PlayerController player;
    private new Rigidbody2D rigidbody;

    private Stat stat;
    private Vector2 moveAxis;

    private void Start()
    {
        player = GetComponent<PlayerController>();
        rigidbody = GetComponent<Rigidbody2D>();

        // TODO: validation

        stat = player.GetStat();
    }

    private void Update()
    {
        // movement
        moveAxis = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private void FixedUpdate()
    {
        // movement
        rigidbody.MovePosition(rigidbody.position + moveAxis * stat.moveSpeed * Time.fixedDeltaTime);
    }
}
