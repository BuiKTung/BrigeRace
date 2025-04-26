using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdlesState : IState
{
    private float timer;
    private float randomTimer;

    public void OnEnter(Enemy enemy)
    {
        
        timer = 0;
        randomTimer = Random.Range(1f, 2f);
        enemy.Idle();
    }

    public void OnExcute(Enemy enemy)
    {
        timer += Time.deltaTime;
        if (timer > randomTimer)
        {
            enemy.ChangeState(new FindBrickState());
        }
    }

    public void OnExit(Enemy enemy)
    {

    }
}
