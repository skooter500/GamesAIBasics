using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class BotGlobalState:State
{
    public BotGlobalState(GameObject myGameObject)
        : base(myGameObject)
    {
    }

    public override string Description()
    {
        return "Bot Global State";
    }

    public override void Enter()
    {
        
    }

    public override void Exit()
    {
        
    }

    public override void Update()
    {
    }

    public override bool HandleCollisionWith(GameObject other)
    {
        // Dont do anything if i'm dead
        if (myGameObject.GetComponent<Bot>().health == 0)
        {
            return false;
        }
        if (other.tag == "lazer")
        {
            myGameObject.GetComponent<Bot>().health--;

            if (myGameObject.GetComponent<Bot>().health == 0)
            {
                myGameObject.GetComponent<StateMachine>().SwitchState(new DeadState(myGameObject));
                return true;
            }

            if (myGameObject.GetComponent<Bot>().health < 3)
            {
                myGameObject.GetComponent<StateMachine>().SwitchState(new FindHealthState(myGameObject));
            }
            return true;
        }

        if (other.tag == "health")
        {
            myGameObject.GetComponent<Bot>().health +=
                other.GetComponent<Health>().quantity;
            other.GetComponent<Health>().Spawn(false);
        }

        if (other.tag == "ammo")
        {
            myGameObject.GetComponent<Bot>().ammo +=
                other.GetComponent<Ammo>().quantity;
            other.GetComponent<Ammo>().Spawn(false);
        }

        return base.HandleCollisionWith(other);
    }


}
