using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickGround : ColorObject
{
    public Stage stage;

    public void OnDespawn()
    {
        stage.RemoveBricks(this);
        //gameObject.SetActive(false);
    }
}
