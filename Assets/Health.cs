using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
    public bool isSpawned;
    public float elapsed;
    public float timeToSpawn = 10;

    public int quantity;

    public Health()
    {
        quantity = Random.Range(5, 20);
    }
    // Use this for initialization

    void Start()
    {
        isSpawned = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isSpawned)
        {
            elapsed += Time.deltaTime;
            if (elapsed > timeToSpawn)
            {
                Spawn(true);
            }
        }
    }

    public void Spawn(bool toSpawn)
    {
        isSpawned = toSpawn;
        if (isSpawned)
        {
            renderer.enabled = true;
        }
        else
        {
            elapsed = 0.0f;
            renderer.enabled = false;
        }
    }
}
