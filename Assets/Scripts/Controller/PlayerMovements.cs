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

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 movement = rb.position + movementInputs * preset.speed * Time.fixedDeltaTime;
        rb.MovePosition(movement);

        Vector3 cameraPos = self.position;
        cameraPos.z = Camera.main.transform.position.z;
        Camera.main.transform.position = cameraPos;
    }
}
