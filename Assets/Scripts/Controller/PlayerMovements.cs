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
    public Animator animator;

    private Vector2 movementInputs;

    public void OnMove(InputAction.CallbackContext context)
    {
        movementInputs = context.ReadValue<Vector2>();
    }

    private void Start()
    {
        animator.SetBool("Aiming", true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 movement = rb.position + movementInputs * preset.speed * Time.fixedDeltaTime;
        if (movement != Vector3.zero)
            animator.SetFloat("Speed", 1);
        rb.MovePosition(movement);

        Vector3 cameraPos = self.position;
        cameraPos.z = Camera.main.transform.position.z;
        Camera.main.transform.position = cameraPos;
    }
}
