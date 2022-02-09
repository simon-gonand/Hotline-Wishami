using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    private int _score = 0;
    public int score { get { return _score; } }
    private float currentMultiplicator = 1.0f;

    Coroutine comboCoroutine;

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

    private IEnumerator ComboCoroutine()
    {
        currentMultiplicator += 0.1f;
        yield return new WaitForSeconds(5.0f);
        currentMultiplicator = 1.0f;
        comboCoroutine = null;
    }
    
    public void AddScore(int scoreToAdd)
    {
        _score += Mathf.RoundToInt(scoreToAdd * currentMultiplicator);
        if (comboCoroutine != null)
            StopCoroutine(comboCoroutine);
        comboCoroutine = StartCoroutine(ComboCoroutine());
    }

}
