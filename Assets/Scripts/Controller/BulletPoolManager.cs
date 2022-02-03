using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPoolManager : MonoBehaviour
{
    public GameObject prefabReference;
    public List<Bullets> bullets;
    public int poolSize;
    public Transform self;

    public PlayerMovements player;
    public Transform startPoint;

#if UNITY_EDITOR
    public bool foldoutBoolRef;
    public bool foldoutBoolPool;
#endif
}
