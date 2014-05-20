using System;
using UnityEngine;

public abstract class State
{
    protected GameObject myGameObject;

    public State(GameObject myGameObject)
    {
        this.myGameObject = myGameObject;
    }

    public abstract string Description();

    public abstract void Enter();
    public abstract void Exit();

    public abstract void Update();

    public virtual bool HandleCollisionWith(GameObject other)
    {
        return false;
    }
}
