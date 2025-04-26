using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewStageBox : MonoBehaviour
{
    public Stage stage;
    private List<ColorType> colorTypes = new List<ColorType>();

    private void OnTriggerEnter(Collider other)
    {
        Characters character = other.GetComponent<Characters>();
        if (character != null && !colorTypes.Contains(character.colorType))
        {
            colorTypes.Add(character.colorType);
            character.stage = stage;
            stage.InitColor(character.colorType,5);
        }
    }
}
