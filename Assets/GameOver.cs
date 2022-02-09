using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UI.PlainButton;
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour
{
    UIDocument m_UIDocument;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnEnable()
    {
       
        m_UIDocument = GetComponent<UIDocument>();
        var root = m_UIDocument.rootVisualElement;
        PlainButton play = root.Q<PlainButton>("RetryButton");
        PlainButton quit = root.Q<PlainButton>("QuitButton");
        
        play.clicked += Play;
        quit.clicked += Quit;
    }


    void Play()
    {
        SceneManager.LoadScene(1);
        // Change Level
    }

    void Quit()
    {
        Application.Quit();
    }

    void ChangeScore(int score)
    {
        var root = m_UIDocument.rootVisualElement;
        Label lab = root.Q<Label>("Score");
        lab.text = "Score : 0" + score;
    }

}
