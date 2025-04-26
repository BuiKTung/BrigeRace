using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildState : IState
{
    public void OnEnter(Enemy enemy)
    {
        enemy.SetDestination(enemy.endPoint.position);
    }

    public void OnExcute(Enemy enemy)
    {
        if(enemy.listBrickCount == 0)
        {
            enemy.ChangeState(new FindBrickState());
        }
    }

    public void OnExit(Enemy enemy)
    {
        
    }
}

