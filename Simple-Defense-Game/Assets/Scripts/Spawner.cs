using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    GameManager gm;

    public GameObject monster;

    Vector3 spawnPos;

    float timer;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.Instance;

        spawnPos = gameObject.transform.position;

        timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        spawnPos.y = Random.Range(0.0f, -3.5f);

        if(gm.GetSpawnTimeDelay() <= timer)
        {
            timer = 0.0f;
            Spawn();
        }

    }

    void Spawn()
    {
        Instantiate(monster, spawnPos, Quaternion.identity);
    }
}
