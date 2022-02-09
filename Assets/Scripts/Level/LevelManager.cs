using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void CheckIfEndLevel(Enemy enemy)
    {
        enemies.Remove(enemy);
        if (enemies.Count != 0) return;
        EndLevel();
    }

    private void EndLevel()
    {
        SceneManager.LoadScene(3);
    }
}
