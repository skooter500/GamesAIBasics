﻿using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class FindAmmoState:State
{
    GameObject nearestAmmo;

    public FindAmmoState(GameObject myGameObject)
        : base(myGameObject)
    {
    }

    public override string Description()
    {
        return "Find Ammo State";
    }

    public override void Exit()
    {
        myGameObject.GetComponent<SteeringBehaviours>().TurnOffAll();
    }

    public override void Enter()
    {
        GameObject[] ammo = GameObject.FindGameObjectsWithTag("ammo");
        int closestId = 0;
        float closestDistance = float.MaxValue;
        for (int i = 0; i < ammo.Length; i++)
        {
            if (ammo[i].GetComponent<Ammo>().isSpawned)
            {
                float dist = Vector3.Distance(ammo[i].transform.position, myGameObject.transform.position);
                if (dist < closestDistance)
                {
                    closestDistance = dist;
                    closestId = i;
                }
            }
        }
        nearestAmmo = ammo[closestId];

        myGameObject.GetComponent<SteeringBehaviours>().TurnOffAll();
        myGameObject.GetComponent<SteeringBehaviours>().SeekEnabled = true;
        myGameObject.GetComponent<SteeringBehaviours>().seekPos = nearestAmmo.transform.position;

    }

    public override void Update()
    {
        // Make sure someone else doesnt get to our ammo 
        // And if they do, find another
        if (!nearestAmmo.GetComponent<Ammo>().isSpawned)
        {
            myGameObject.GetComponent<StateMachine>().SwitchState(new FindAmmoState(myGameObject));            
        }
    }

    public override bool HandleCollisionWith(GameObject other)
    {
        if ("ammo" == other.tag)
        {
            myGameObject.GetComponent<Bot>().ammo += Random.Range(5, 20);
            myGameObject.GetComponent<StateMachine>().SwitchState(new PatrolState(myGameObject));
            other.GetComponent<Ammo>().Spawn(false);
            return true;
        }

        return false;
    }
}
