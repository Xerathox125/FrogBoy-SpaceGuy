using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class NinjaFrogMovement : MonoBehaviour
{
    private Rigidbody2D FrogRigidbody;
    private Animator FrogAnimator;
    private PlayerInput FrogPlayerInput;
    private InputAction FrogMove, FrogJump;

    public float velocidad, fuerzaSalto;
    private float groundedDistance = 0.52f;
    private bool isGrounded;

    void Awake()
    {
        FrogPlayerInput = GetComponent<PlayerInput>();
        FrogAnimator = GetComponent<Animator>();
        FrogRigidbody = GetComponent<Rigidbody2D>();

        FrogMove = FrogPlayerInput.actions["FrogMove"];
        FrogJump = FrogPlayerInput.actions["FrogJump"];

    }

    private void OnEnable()
    {
        FrogJump.started += FrogJumping;
    }

    private void OnDisable()
    {
        FrogJump.started -= FrogJumping;
    }

    void Update()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundedDistance);

        if (isGrounded)
        {
            FrogAnimator.SetBool("IsGrounded", true);
        }
        else
        {
            FrogAnimator.SetBool("IsGrounded", false);
        }

        FrogMoving();

    }

    private void FrogMoving()
    {
        Vector2 direccion = FrogMove.ReadValue<Vector2>();

        if(isGrounded && direccion.x != 0)
        {
            FrogAnimator.SetBool("IsRunning", true);
        }
        else FrogAnimator.SetBool("IsRunning", false);

        if(direccion.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (direccion.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        FrogRigidbody.linearVelocity = new Vector2(direccion.x * velocidad, FrogRigidbody.linearVelocityY);

    }

    private void FrogJumping(InputAction.CallbackContext context)
    {
        if(isGrounded)
        {
            FrogRigidbody.AddForce(Vector2.up * fuerzaSalto);

        }
    }


}
