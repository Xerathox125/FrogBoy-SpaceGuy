using UnityEngine;
using UnityEngine.InputSystem;

public class VirtualGuyMovement : MonoBehaviour
{
    private Rigidbody2D GuyRigidbody;
    private Animator GuyAnimator;
    private PlayerInput GuyPlayerInput;
    private InputAction GuyMove, GuyJump;

    public float velocidad, fuerzaSalto;
    private float groundedDistance = 0.52f;
    private bool isGrounded;

    void Awake()
    {
        GuyPlayerInput = GetComponent<PlayerInput>();
        GuyAnimator = GetComponent<Animator>();
        GuyRigidbody = GetComponent<Rigidbody2D>();

        GuyMove = GuyPlayerInput.actions["GuyMove"];
        GuyJump = GuyPlayerInput.actions["GuyJump"];

    }

    private void OnEnable()
    {
        GuyJump.started += GuyJumping;
    }

    private void OnDisable()
    {
        GuyJump.started -= GuyJumping;
    }

    void Update()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundedDistance);

        if (isGrounded)
        {
            GuyAnimator.SetBool("IsGrounded", true);
        }
        else
        {
            GuyAnimator.SetBool("IsGrounded", false);
        }

        GuyMoving();

    }

    private void GuyMoving()
    {
        Vector2 direccion = GuyMove.ReadValue<Vector2>();

        if (isGrounded && direccion.x != 0)
        {
            GuyAnimator.SetBool("IsRunning", true);
        }
        else
        {
            GuyAnimator.SetBool("IsRunning", false);
        }


        if (direccion.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (direccion.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        GuyRigidbody.linearVelocity = new Vector2(direccion.x * velocidad, GuyRigidbody.linearVelocityY);

    }

    private void GuyJumping(InputAction.CallbackContext context)
    {
        if (isGrounded)
        {
            GuyRigidbody.AddForce(Vector2.up * fuerzaSalto);

        }
    }
}
