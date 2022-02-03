using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UI.PlainButton;
using UnityEngine.InputSystem;
public class MainMenu : MonoBehaviour
{
    UIDocument m_UIDocument;
    [SerializeField] Options s_options;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnEnable()
    {
        m_UIDocument = GetComponent<UIDocument>();
        var root = m_UIDocument.rootVisualElement;
        PlainButton play = root.Q<PlainButton>("Play");
        PlainButton options = root.Q<PlainButton>("Options");
        PlainButton quit = root.Q<PlainButton>("Quit");
        PlainButton returnToMainMenu = root.Q<PlainButton>("ReturnToMainMenu");
        
        play.clicked += Play;
        options.clicked += Options;
        quit.clicked += Quit;
        
        returnToMainMenu.clicked += Return;
        VisualElement MainMenu = root.Q<VisualElement>("MainMenu");
        VisualElement OptionsMenu = root.Q<VisualElement>("OptionsMenu");
        MainMenu.style.display = DisplayStyle.Flex;
        OptionsMenu.style.display = DisplayStyle.None;

        Toggle toggle = root.Q<Toggle>("FullScreen");
        toggle.value = s_options.isFullScreen;
        toggle.RegisterValueChangedCallback<bool>(v =>
        {
            s_options.isFullScreen = v.newValue;
        });

        DropdownField dropdown = root.Q<DropdownField>("Resolution");
        dropdown.value = (s_options.ResolutionX).ToString()+ "x" + (s_options.ResolutionY).ToString();
        dropdown.RegisterValueChangedCallback<string>(v =>
        {
            s_options.ResolutionX = int.Parse(v.newValue.Split('x')[0]);
            s_options.ResolutionY = int.Parse(v.newValue.Split('x')[1]);
            Debug.Log(s_options.ResolutionX);
            Debug.Log(s_options.ResolutionY);
        });

        Slider slide = root.Q<Slider>("Sensibilite");
        slide.value = s_options.sensibility*100;
        slide.RegisterValueChangedCallback<float>(v =>
        {
            s_options.sensibility = v.newValue / 100;
            Debug.Log(s_options.sensibility);
        });
    }


    void Play()
    {
        Debug.Log("Play");
        // Change Level
    }
    void Options()
    {
        var root = m_UIDocument.rootVisualElement;
        Debug.Log("Options");
        VisualElement MainMenu = root.Q<VisualElement>("MainMenu");
        VisualElement OptionsMenu = root.Q<VisualElement>("OptionsMenu");
        MainMenu.style.display = DisplayStyle.None;
        OptionsMenu.style.display = DisplayStyle.Flex;
    }
    void Return()
    {
        var root = m_UIDocument.rootVisualElement;
        Debug.Log("Return");
        VisualElement MainMenu = root.Q<VisualElement>("MainMenu");
        VisualElement OptionsMenu = root.Q<VisualElement>("OptionsMenu");
        OptionsMenu.style.display = DisplayStyle.None;
        MainMenu.style.display = DisplayStyle.Flex;
    }
    void Quit()
    {
        Application.Quit();
    }
}
