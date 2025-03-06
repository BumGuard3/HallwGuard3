using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;

    public float speed = 12f;

    Vector2 move;

    PlayerControl controls;

    private float lockedY;

    void Awake()
    {
        controls = new PlayerControl();

        controls.Player.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.Player.Move.canceled += ctx => move = Vector2.zero;
        lockedY = transform.position.y;
    }

    void Update()
    {
        Vector3 m = transform.right * move.x + transform.forward * move.y;
        controller.Move(m * Time.deltaTime * speed);
        transform.position = new Vector3(transform.position.x, lockedY, transform.position.z);
    }

    void OnEnable()
    {
        controls.Player.Enable();
    }

    void OnDisable()
    {
        controls.Player.Disable();
    }

}
