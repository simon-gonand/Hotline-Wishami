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

    private int ammoNumber;

    private bool allowShoot = true;
    private bool firstShot = false;

    private void Start()
    {
        ammoNumber = preset.ammo;
        InGameUI.instance.ChangeAmmo(ammoNumber);
    }

    public void Fire(InputAction.CallbackContext context)
    {
        if (ammoNumber <= 0) return;
        if (context.performed && allowShoot)
        {
            foreach (Bullets bullet in bulletsPool.bullets)
            {
                if (bullet.gameObject.activeSelf) continue;
                bullet.StartBehaviour();
                StartCoroutine(FireRateCooldown());
                --ammoNumber;
                InGameUI.instance.ChangeAmmo(ammoNumber);
                return;
            }
        }
        
        if (firstShot) return;
        firstShot = true;
        foreach(Enemy enemy in LevelManager.instance.enemies)
        {
            enemy.PlayerSeen();
        }
    }

    IEnumerator FireRateCooldown()
    {
        allowShoot = false;
        yield return new WaitForSeconds(preset.fireRate);
        allowShoot = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(self.position);
        Vector3 direction = new Vector3(Mouse.current.position.ReadValue().x, Mouse.current.position.ReadValue().y, 0.0f) - pos;
        float angle = -Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;

        self.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
