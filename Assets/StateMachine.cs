using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class StateMachine:MonoBehaviour
{
    State currentState;

    void Start()
    {
    }

    public void Update()
    {
        if (currentState != null)
        {
            currentState.Update();
        }
    }

    public void SwitchState(State newState)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }

        currentState = newState;
        Debug.Log("New bot state: " + newState.Description());
        if (newState != null)
        {
            currentState.Enter();
        }
    }

}

