using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour {

    public GameObject HealthPowerUpPrefab;
    public GameObject SpeedPowerUpPrefab;
    public GameObject FirePowerUpPrefab;
    public float PUspeed = 5f;

    public void SpawnPU()
    {
        int rnd1 = UnityEngine.Random.Range(1, 10);
        if (rnd1 == 1)
        {
            int rnd2 = UnityEngine.Random.Range(1, 3);
            if (rnd2 == 1)
            {
                SpawnHealthPU();
            }
            if (rnd2 == 2)
            {
                SpawnSpeedPU();
            }
            if (rnd2 == 3)
            {
                SpawnFirePU();
            }
        }
    }

    void SpawnHealthPU()
    {
        GameObject HealthPU = Instantiate(HealthPowerUpPrefab, transform.position, Quaternion.identity) as GameObject;
        HealthPU.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,-PUspeed);
    }
    void SpawnSpeedPU()
    {
        GameObject SpeedPU = Instantiate(SpeedPowerUpPrefab, transform.position, Quaternion.identity) as GameObject;
        SpeedPU.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -PUspeed);
    }
    void SpawnFirePU()
    {
        GameObject FirePU = Instantiate(FirePowerUpPrefab, transform.position, Quaternion.identity) as GameObject;
        FirePU.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -PUspeed);
    }
}
