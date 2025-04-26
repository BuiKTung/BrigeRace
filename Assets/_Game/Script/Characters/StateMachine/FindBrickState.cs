using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindBrickState : IState
{
    int target;
    public void OnEnter(Enemy enemy)
    {
        enemy.ChangeAnim("Run");
        target = (int)Random.Range(1, 5);
        enemy.FindBrickPosition();
    }

    public void OnExcute(Enemy enemy)
    {
        
        if (enemy.isDestination)
        {
            if (enemy.listBrickCount >= target)
            {
                enemy.ChangeState(new BuildState());
            }
            else
            {
                enemy.FindBrickPosition();
            }
        }
    }

    public void OnExit(Enemy enemy)
    {
        
    }
}
