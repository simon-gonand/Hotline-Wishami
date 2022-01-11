using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPoolManager : MonoBehaviour
{
    public GameObject prefabReference;
    public List<Bullets> bullets;
    public int poolSize;
    public Transform self;

#if UNITY_EDITOR
    public bool foldoutBoolRef;
    public bool foldoutBoolPool;
#endif

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
