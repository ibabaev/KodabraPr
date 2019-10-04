﻿using UnityEngine;

public class PlayerPhysicalThird : MonoBehaviour
{
    public float Speed = 1;

    public Rigidbody PlayerRb;

    private const float _jumpForce = 200;

    void Start()
    {
        if (PlayerRb == null)
        {
            PlayerRb = GetComponent<Rigidbody>();
        }
    }

    void Update()
    {
        int multiplayer = 0;

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            multiplayer = -1;
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            multiplayer = 1;
        }

        Move(multiplayer);

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    public void Move(int multiplayer)
    {
        PlayerRb.velocity = new Vector3(multiplayer * Speed, PlayerRb.velocity.y, PlayerRb.velocity.z);
    }

    public void Jump()
    {
        PlayerRb.AddForce(new Vector3(0, _jumpForce, 0));
    }
}