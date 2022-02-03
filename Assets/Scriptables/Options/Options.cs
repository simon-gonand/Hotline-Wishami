using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
[CreateAssetMenu(fileName = "Options", menuName = "Options", order = 1)]
public class Options : ScriptableObject
{
    public float sensibility = .5f;
    public int ResolutionX = 1920;
    public int ResolutionY = 1080;
    public bool isFullScreen = true;
}

