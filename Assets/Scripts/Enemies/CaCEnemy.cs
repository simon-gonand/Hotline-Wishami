using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaCEnemy : Enemy
{
    public Animator bodyAnim;
    public Animator legsAnim;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("attack");
        }
    }
}
