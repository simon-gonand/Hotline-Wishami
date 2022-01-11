using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
[CreateAssetMenu(fileName = "MenuTitleShaking", menuName = "Menu Title Shaking", order = 1)]
public class MenuTitleShaking : ScriptableObject
{

    public AnimationCurve rotationOvertimeY;
    public AnimationCurve rotationOvertimeZ;
    public float timeToRotate = 5;
}
