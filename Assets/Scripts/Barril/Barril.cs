using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barril : MonoBehaviour
{
    public Transform self;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Bullet"))
        {
            Explode();
        }
    }

    private void Explode()
    {
        Physics2D.CircleCastAll(new Vector2(self.position.x, self.position.y), 5.0f, Vector2.up);
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
