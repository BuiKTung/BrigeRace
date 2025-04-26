using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ColorType
{
    White = 0,
    Gray = 1,
    Red = 2,
    Green = 3,
    Violet = 4,
    Blue = 5,
    Brown = 6,
}
[CreateAssetMenu(fileName = "ColorData", menuName = "ScriptableObjects/ColorData", order = 1)]
public class ColorData : ScriptableObject
{
    [SerializeField] private Material[] colorMats;

    public Material GetColorMaterial(ColorType colorType)
    {
        return colorMats[(int)colorType];
    }
}
