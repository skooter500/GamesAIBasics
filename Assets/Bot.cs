using UnityEngine;
using System.Collections;

public class Bot : MonoBehaviour {
    public int ammo;
    
	// Use this for initialization
	void Start () {
        // Add 5 random waypoints
        for (int i = 0; i < 3; i++)
        {
            Vector3 pos = Random.insideUnitSphere * 20;
            pos.y = 0;
            gameObject.GetComponent<SteeringBehaviours>().path.Waypoints.Add(pos);
        }

        ammo = 10;
	}

    // Update is called once per frame
    void Update()
    {
        GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
	}
}
