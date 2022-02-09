using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerPreset", menuName = "Presets/Player Preset", order = 1)]
public class PlayerPresets : ScriptableObject
{
    [Header("Player Stats")]
    public float speed;

    [Header("Fire Stats")]
    public float fireRate;
    public int ammo;
}
