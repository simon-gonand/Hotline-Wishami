using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy : MonoBehaviour
{
    public AIDestinationSetter destination;
    public Transform self;
    public AIPath path;
    public LayerMask layers;

    public int earnScore;

    private void Update()
    {
        Vector3 direction = destination.target.position - self.position;
        RaycastHit2D raycast = Physics2D.Raycast(self.position, direction, direction.magnitude, layers);
        if (!raycast.collider.CompareTag("Player"))
        {
            path.enableRotation = true;
            return;
        }
        PlayerSeen();
    }

    public virtual void PlayerSeen()
    {
        path.enabled = true;
    }

    public void Die()
    {
        ScoreManager.instance.AddScore(earnScore);
        Camera.main.GetComponent<ShakeBehavior>().TriggerShake(0.1f);
        LevelManager.instance.CheckIfEndLevel(this);
    }
}
