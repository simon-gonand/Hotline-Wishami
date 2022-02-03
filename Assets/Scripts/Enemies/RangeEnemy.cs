using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class RangeEnemy : Enemy
{
    public Transform self;
    public AIPath path;
    public AIDestinationSetter destination;
    public BulletPoolManager pool;
    public LayerMask layers;

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
    void Update()
    {
        Vector3 direction = destination.target.position - self.position;
        RaycastHit2D raycast = Physics2D.Raycast(self.position, direction, direction.magnitude, layers);
        if (!raycast.collider.CompareTag("Player"))
        {
            path.enableRotation = true;
            return;
        }
        path.enableRotation = false;
        direction.Normalize();
        float rot_z = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        self.rotation = Quaternion.Euler(0.0f, 0.0f, rot_z - 90);
        Fire();
    }
}
