using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Characters
{
    IState currentState;
    public NavMeshAgent agent;
    public Transform endPoint;
    public Rigidbody rb;
    private Vector3 destination;
    public bool isDestination => Vector3.Distance(destination, transform.position) < 0.1f;
    private void Start()
    {
        OnInit();
    }
    private void Update()
    {
        //Ray ray = new Ray(transform.position, transform.forward);
        //RaycastHit hit;

        //// S? d?ng SphereCast ð? ki?m tra va ch?m
        //bool isHit = Physics.SphereCast(ray, sphereRadius, out hit, maxDistance, layerMask);

        //// V? tia ray và h?nh c?u ð? debug
        //Debug.DrawRay(ray.origin, ray.direction * maxDistance, Color.red, 1.0f);

        //if (isHit)
        //{
        //    // V? h?nh c?u t?i ði?m va ch?m
        //    Debug.DrawLine(ray.origin, hit.point, Color.green, 1.0f);
        //    Debug.DrawRay(hit.point, Vector3.up * sphereRadius, Color.green, 1.0f);
        //    Debug.DrawRay(hit.point, Vector3.down * sphereRadius, Color.green, 1.0f);
        //    Debug.DrawRay(hit.point, Vector3.left * sphereRadius, Color.green, 1.0f);
        //    Debug.DrawRay(hit.point, Vector3.right * sphereRadius, Color.green, 1.0f);
        //    Debug.DrawRay(hit.point, Vector3.forward * sphereRadius, Color.green, 1.0f);
        //    Debug.DrawRay(hit.point, Vector3.back * sphereRadius, Color.green, 1.0f);

        //    Debug.Log("Hit object: " + hit.collider.gameObject.name);
        //}
        //else
        //{
        //    Debug.Log("No hit detected");
        //}
        if (currentState != null)
        {
            currentState.OnExcute(this);
            CanMove(transform.position);
            
        }
            
    }
    public override void OnInit()
    {
        base.OnInit();
        //ChangeAnim("Idle");
        ChangeState(new IdlesState());
    }
    public void ChangeState(IState newState)
    {
        if (currentState != null)
        {
            currentState.OnExit(this);
        }
        currentState = newState;
        if (currentState != null)
        {
            currentState.OnEnter(this);
        }
    }
   public void SetDestination(Vector3 position)
   {
        agent.enabled = true;
        destination = position;
        agent.SetDestination(destination);
   }
    internal void Idle()
    {
        agent.enabled = false;
    }
    public void FindBrickPosition()
    {
        if(stage != null)
        {
            BrickGround brick = stage.FindBrickColor(colorType);

            if (brick == null)
            {
                ChangeState(new BuildState());
            }
            else
            {
                SetDestination(brick.transform.position);
            }
        }   
    }
    
}   
