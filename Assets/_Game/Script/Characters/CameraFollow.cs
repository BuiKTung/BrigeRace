using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]CinemachineVirtualCamera camera;   
    void Start()
    {
        camera.Follow = GameObject.FindGameObjectWithTag("Player").transform;
        camera.LookAt = GameObject.FindGameObjectWithTag("Player").transform;
    }

    
}
