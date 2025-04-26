using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorObject : MonoBehaviour
{
    [SerializeField] private ColorData colorData;
    [SerializeField] protected Renderer rd;
    
    public ColorType colorType;

    public void ChangeColor(ColorType colorType)
    {
        this.colorType = colorType;
        rd.material = colorData.GetColorMaterial(colorType);
    }
    public void SetAtiveRender()
    {
        rd.enabled = true;
    }
    public void SetDeAtiveRender()
    {
        rd.enabled = false;
    }
}
