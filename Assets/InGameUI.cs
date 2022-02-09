
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UI.PlainButton;
using UnityEngine.InputSystem;


public class InGameUI : MonoBehaviour
{
    UIDocument m_UIDocument;
    [SerializeField] Options s_options;
    TempOptions tempOption;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void OnEnable()
    {
        m_UIDocument = GetComponent<UIDocument>();
        var root = m_UIDocument.rootVisualElement;

        PlainButton resume = root.Q<PlainButton>("Resume");
        PlainButton quit = root.Q<PlainButton>("Quit");
        PlainButton returnMenu = root.Q<PlainButton>("ReturnToMenu");
        VisualElement Paused = root.Q<VisualElement>("Paused");
        VisualElement Header = root.Q<VisualElement>("Header");
        Header.style.display = DisplayStyle.Flex;
        Paused.style.display = DisplayStyle.None;

        resume.clicked += Resume;
        quit.clicked += Quit;
        returnMenu.clicked += ReturnToMenu;


    }

    void ChangeScore(int score)
    {
        var root = m_UIDocument.rootVisualElement;
        VisualElement Paused = root.Q<Label>("ComboLabel");
    }
    

    void Resume()
    {
        // Call Game Manager to Resume Game




    }

    void ReturnToMenu()
    {

    }


    void Quit()
    {
        Application.Quit();
    }
}
