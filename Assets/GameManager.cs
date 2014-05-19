using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public GameObject ammoPrefab;
    public GameObject botPrefab;

	// Use this for initialization
	void Start () {

        // Create some random health pickups and some random ammo pickups
        for (int i = 0; i < 10; i++)
        {            
            GameObject ammo = (GameObject)Instantiate(ammoPrefab);
            ammo.renderer.material.color = Color.red;
            Vector3 pos = Random.insideUnitSphere * 20;
            pos.y = 0;
            ammo.transform.position = pos;
            ammo.tag = "ammo";
        }

        // Create a random team
        // Create some random bots
        for (int i = 0; i < 6; i++)
        {
            GameObject bot = (GameObject)Instantiate(botPrefab);
            bot.renderer.material.color = Color.blue;
            Vector3 pos = Random.insideUnitSphere * 20;
            pos.y = 0;
            bot.transform.position = pos;
            bot.tag = "team1";
            bot.GetComponent<StateMachine>().SwitchState(new PatrolState(bot));
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
