using System.Collections.Generic;
using UnityEngine;

public class PatrolState:State
{

    public override string Description()
    {
        return "Patrol State";
    }

    public PatrolState(GameObject myGameObject)
        : base(myGameObject)
    {
    }

    public override void Enter()
    {
        myGameObject.GetComponent<SteeringBehaviours>().FollowPathEnabled = true;
    }
    public override void Exit()
    {
        myGameObject.GetComponent<SteeringBehaviours>().FollowPathEnabled = false;
    }

    public override void Update()
    {
        float range = 5.0f;

        GameObject[] others = GameObject.FindGameObjectsWithTag("team1");
        for (int i = 0; i < others.Length; i++)
        {
            if (others[i] != myGameObject)
            {
                // Check to see if I can see the other guy
                float angle;
                float fov = Mathf.PI / 4.0f;
                Vector3 toEnemy = (others[i].transform.position - myGameObject.transform.position);
                toEnemy.Normalize();
                angle = (float)Mathf.Acos(Vector3.Dot(toEnemy, myGameObject.transform.forward));
                if (angle < fov)
                {
                    myGameObject.GetComponent<StateMachine>().SwitchState(new AttackingState(myGameObject, others[i]));
                }
            }
        }
    }
}
