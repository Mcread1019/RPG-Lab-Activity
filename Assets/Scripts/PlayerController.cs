using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement variables")]
    public int moveSpeed;
    public Rigidbody2D rb;
    public Vector2 moveInput;

    [Header("Interact Variables")]
    public bool interactInput;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (interactInput)
        {
            interactInput = false;
            TryInteract();
        }
    }

    private void FixedUpdate()
    {
        //New velocity code for Unity 6
        rb.linearVelocity = moveInput.normalized * moveSpeed;
    }

    //InputActions parameters
    public void OnMoveInput(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    //InputActions parameters needs to be held down
    public void OnInteractInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            interactInput = true;
        }
    }

    private void TryInteract()
    {
        Debug.Log("Pressed interact button");
    }
}
