using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


class DeadState:State
{
    public DeadState(GameObject myGameObject)
        : base(myGameObject)
    {

    }

    public override string Description()
    {
        return "Dead State";
    }

    public override void Enter()
    {
        myGameObject.GetComponent<Renderer>().material.color = Color.gray;
        myGameObject.GetComponent<SteeringBehaviours>().TurnOffAll();
    }

    public override void Exit()
    {
    }

    public override void Update()
    {
        
    }
}
