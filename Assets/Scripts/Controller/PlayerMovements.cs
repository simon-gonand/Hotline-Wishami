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
    public Animator bodyAnimator;
    public Animator legsAnimator;

    private Vector2 movementInputs;

    public void OnMove(InputAction.CallbackContext context)
    {
        movementInputs = context.ReadValue<Vector2>();
    }

    private void Start()
    {
        bodyAnimator.SetBool("Aiming", true);
        legsAnimator.SetBool("Aiming", true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = Vector2.zero;
        Vector3 movement = rb.position + movementInputs * preset.speed * Time.fixedDeltaTime;
        if (movementInputs != Vector2.zero)
        {
            bodyAnimator.SetFloat("Speed", 1);
            legsAnimator.SetFloat("Speed", 1);
        }
        else
        {
            bodyAnimator.SetFloat("Speed", 0);
            legsAnimator.SetFloat("Speed", 0);
        }
        rb.MovePosition(movement);

        Vector3 cameraPos = self.position;
        cameraPos.z = Camera.main.transform.position.z;
        Camera.main.transform.position = cameraPos;
    }
}
