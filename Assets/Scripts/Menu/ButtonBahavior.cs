using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBahavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickPlay()
    {
        SceneManager.LoadScene(1);
    }
    public void OnClickOptions()
    {
        Debug.Log("Options");
    }
    public void OnClickQuit()
    {
        Application.Quit();
    }


}
