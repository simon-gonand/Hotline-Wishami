using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAiming : MonoBehaviour
{
    [SerializeField]
    private Transform self;
    [SerializeField]
    private BulletPoolManager bulletsPool;
    [SerializeField]
    private PlayerPresets preset;

    private bool allowShoot = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Fire(InputAction.CallbackContext context)
    {
        if (context.performed && allowShoot)
        {
            foreach (Bullets bullet in bulletsPool.bullets)
            {
                if (bullet.gameObject.activeSelf) continue;
                bullet.StartBehaviour();
                StartCoroutine(FireRateCooldown());
                return;
            }
        }
    }

    IEnumerator FireRateCooldown()
    {
        allowShoot = false;
        yield return new WaitForSeconds(preset.fireRate);
        allowShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(self.position);
        Vector3 direction = new Vector3(Mouse.current.position.ReadValue().x, Mouse.current.position.ReadValue().y, 0.0f) - pos;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        self.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
