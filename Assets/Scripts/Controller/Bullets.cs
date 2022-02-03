using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    public BulletPoolManager bulletPoolManager;
    [SerializeField]
    private Transform self;

    private bool isActive = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) return;
        if (collision.CompareTag("Enemy")) 
        {

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
        self.right = bulletPoolManager.player.self.right;
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
            self.position += self.right * bulletPoolManager.player.preset.bulletSpeed * Time.deltaTime;
        }
    }
}
