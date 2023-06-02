using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ColorData", menuName = "Data/Color")]
public class ColorHolder :ScriptableObject
{
    public Material OnMaterial;
    public Material OffMaterial;
    public bool IsEnabled;
}
