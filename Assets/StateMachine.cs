using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class StateMachine:MonoBehaviour
{
    public State currentState = null;
    public State globalState = null;
    public State previousState = null;

    void Start()
    {
    }

    public void Update()
    {
        if (globalState != null)
        {
            globalState.Update();
        }
        if (currentState != null)
        {
            currentState.Update();
        }
    }

    public void OnTriggerEnter(Collider collision)
    {
        Debug.Log(gameObject.tag + " collided with " + collision.gameObject.tag);

        // See if one of the states will handle it
        if (currentState != null && (currentState.HandleCollisionWith(collision.gameObject)))
        {
            return;
        }
        else
        {
            if (globalState != null)
            {
                globalState.HandleCollisionWith(collision.gameObject);
            }
        }
    }

    public void RevertToPreviousState()
    {
        SwitchState(previousState);
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

