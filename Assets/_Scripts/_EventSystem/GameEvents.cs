using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    private void Awake()
    {
        if (!current)
        {
            current = this;
        }
    }

    public event Action onDoorwayTriggerEnter;
    public void DoorwayTriggerEnter()
    {
        if(onDoorwayTriggerEnter != null)
        {
            onDoorwayTriggerEnter();
        }
    }

    public event Action onDoorwayTriggerExit;
    public void DoorwayTriggerExit()
    {
        if(onDoorwayTriggerExit != null)
        {
            onDoorwayTriggerExit();
        }
    }
}
