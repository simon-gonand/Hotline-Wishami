using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    public BulletPoolManager bulletPoolManager;
    public Transform character;
    [SerializeField]
    private Transform self;

    public float speed;

    private bool isActive = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(bulletPoolManager.self.parent.tag)) return;
        if (collision.CompareTag("Player"))
        {
            // Game Over
        }
        if (collision.CompareTag("Enemy")) 
        {
            collision.GetComponent<Enemy>().Die();
        }
        EndBehaviour();
    }

    private void OnBecameInvisible()
    {
        EndBehaviour();
    }

    public void StartBehaviour()
    {
        gameObject.SetActive(true);
        self.SetParent(null);
        self.position = bulletPoolManager.startPoint.position;
        self.right = character.up;
        isActive = true;
    }

    public void EndBehaviour()
    {
        self.SetParent(bulletPoolManager.self);
        self.localPosition = Vector3.zero;
        self.localRotation = Quaternion.identity;
        gameObject.SetActive(false);
        isActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            self.position += self.right * speed * Time.deltaTime;
        }
    }
}
