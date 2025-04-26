using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Characters
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private FixedJoystick joystick;
    [SerializeField] private float speed;
    void FixedUpdate()
    {
        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;

        Vector3 direction = new Vector3(horizontal,0, vertical).normalized * speed * Time.fixedDeltaTime;
        
        if(CheckGround(rb.position + new Vector3(horizontal, 0, vertical).normalized) && CanMove(rb.position + new Vector3(horizontal, 0, vertical).normalized))
        {
            rb.MovePosition(rb.position + direction);
        }
            
        
        if(isWin == false)
        {
             if (joystick.Horizontal != 0 || joystick.Vertical != 0)
                 {
                     transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
                     ChangeAnim("Run");
                 }
             else
                 {
                    ChangeAnim("Idle");
                 }
        }
    }
    public override void OnInit()
    {
        base.OnInit();
    }
}
