using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = System.Random;

public class Stage : MonoBehaviour
{
    public Transform[] brickPoints; //list diem brickPoint

    public List<Vector3> emptyPoint = new List<Vector3>(); //list vi tri emptyPoint

    public  List<BrickGround> listBrickGrounds = new List<BrickGround>();
    [SerializeField] BrickGround brickPrefab;

    private void Start()
    {
        OnInnit();
    }
    public void OnInnit()
    {
        for(int i = 0; i < brickPoints.Length; i++)
        {
            emptyPoint.Add(brickPoints[i].position);
        }
        //InitColor(ColorType.Green, 5);
        
    }
    public void InitColor(ColorType colorType, int amount)
    {
        for(int i = 0;i < amount; i++)
        {
            NewBrick(colorType);
        }
    }
    public void NewBrick(ColorType colorType)
    {
        if(emptyPoint.Count > 0)
        {
            Random random = new Random();
            int numRandom = random.Next(0, emptyPoint.Count - 1);
            BrickGround brickGround = Instantiate(brickPrefab, emptyPoint[numRandom], Quaternion.identity);
            brickGround.ChangeColor(colorType);
            emptyPoint.RemoveAt(numRandom);
            brickGround.stage = this;
            listBrickGrounds.Add(brickGround);
        }
    }

    internal void RemoveBricks(BrickGround brick)
    {
        emptyPoint.Add(brick.transform.position);
        listBrickGrounds.Remove(brick);
    }

    internal BrickGround FindBrickColor(ColorType colorType)
    {
        BrickGround brick;
        for (int i = 0; i < listBrickGrounds.Count; i++)
        {
            if (listBrickGrounds[i].colorType == colorType)
            {
                brick = listBrickGrounds[i];
                return brick;
            }
        }

        return null;
    }
}
