using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class FindHealthState:State
{
    GameObject nearestHealth;

    public FindHealthState(GameObject myGameObject)
        : base(myGameObject)
    {
    }

    public override string Description()
    {
        return "Find Health State";
    }

    public override void Enter()
    {
        GameObject[] health = GameObject.FindGameObjectsWithTag("health");
        int closestId = 0;
        float closestDistance = float.MaxValue;
        for (int i = 0; i < health.Length; i++)
        {
            if (health[i].GetComponent<Ammo>().isSpawned)
            {
                float dist = Vector3.Distance(health[i].transform.position, myGameObject.transform.position);
                if (dist < closestDistance)
                {
                    closestDistance = dist;
                    closestId = i;
                }
            }
        }
        nearestHealth = health[closestId];

        myGameObject.GetComponent<SteeringBehaviours>().TurnOffAll();
        myGameObject.GetComponent<SteeringBehaviours>().SeekEnabled = true;
        myGameObject.GetComponent<SteeringBehaviours>().seekPos = nearestHealth.transform.position;
    }

    public override void Update()
    {
        // Make sure someone else doesnt get to our health
        // And if they do, find another
        if (!nearestHealth.GetComponent<Health>().isSpawned)
        {
            myGameObject.GetComponent<StateMachine>().SwitchState(new FindHealthState(myGameObject));
        }
    }

    public override void Exit()
    {
        myGameObject.GetComponent<SteeringBehaviours>().TurnOffAll();
    }

    public override bool HandleCollisionWith(GameObject other)
    {
        if ("health" == other.tag)
        {
            myGameObject.GetComponent<Bot>().ammo += Random.Range(5, 20);
            myGameObject.GetComponent<StateMachine>().SwitchState(new PatrolState(myGameObject));
            other.GetComponent<Ammo>().Spawn(false);
            return true;
        }

        return false;
    }
}
