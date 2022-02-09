using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barril : MonoBehaviour
{
    public Transform self;

    public void Explode()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(new Vector2(self.position.x, self.position.y), 2.0f, Vector2.up);
        foreach(RaycastHit2D hit in hits)
        {
            Enemy enemy = hit.collider.GetComponent<Enemy>();
            if (enemy != null) enemy.Die();
        }
        Camera.main.GetComponent<ShakeBehavior>().TriggerShake(0.5f);
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
