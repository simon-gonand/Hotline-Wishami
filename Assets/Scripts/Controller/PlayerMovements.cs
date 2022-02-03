using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovements : MonoBehaviour
{
    public Transform self;
    public PlayerPresets preset;
    [SerializeField]
    private Rigidbody2D rb;

    private Vector2 movementInputs;

    public void OnMove(InputAction.CallbackContext context)
    {
        movementInputs = context.ReadValue<Vector2>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movementInputs * preset.speed * Time.fixedDeltaTime);
    }
}
