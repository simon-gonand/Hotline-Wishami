using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public List<Enemy> enemies;

    public static LevelManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CheckIfEndLevel()
    {
        foreach(Enemy enemy in enemies)
        {
            if (enemy == null) enemies.Remove(enemy);
        }
        if (enemies.Count != 0) return;
        EndLevel();
    }

    private void EndLevel()
    {
        Debug.Log("level finished");
    }
}
