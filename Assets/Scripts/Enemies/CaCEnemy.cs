using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaCEnemy : Enemy
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            bodyAnim.SetTrigger("attack");
            Debug.Log("attack");
        }
    }
}
