using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class RangeEnemy : Enemy
{
    public BulletPoolManager pool;

    private bool canFire = true;

    private void Fire()
    {
        if (!canFire) return;
        foreach (Bullets bullet in pool.bullets)
        {
            if (bullet.gameObject.activeSelf) continue;
            bullet.StartBehaviour();
            StartCoroutine(FireRateCooldown());
            return;
        }
    }

    private IEnumerator FireRateCooldown()
    {
        canFire = false;
        yield return new WaitForSeconds(1.0f);
        canFire = true;
    }

    // Update is called once per frame
    public override void PlayerSeen()
    {
        base.PlayerSeen();

        Vector3 direction = destination.target.position - self.position;
        path.enableRotation = false;
        direction.Normalize();
        float rot_z = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        self.rotation = Quaternion.Euler(0.0f, 0.0f, rot_z - 90);
        Fire();
    }
}
