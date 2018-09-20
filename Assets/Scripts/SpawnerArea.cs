using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerArea : MonoBehaviour {

    public GameObject slidingDoor;
    GameObject gameManager;

    public float intervalTimer;
    float staticSpawningInterval = 1.5f; // Spawning interval should be given in seconds
    float intervalChangeBetweenLevels = 0.2f;

    float maxInterval { get; set; }
    float minInterval { get; set; }

    public bool canSpawn;

    // Use this for initialization
    void Start () {
        gameManager = GameObject.Find("GameManager");

        maxInterval = staticSpawningInterval + 2;
        minInterval = staticSpawningInterval;

        resetIntervalTimer();
	}
	
	// Update is called once per frame
	void Update () {
        if (canSpawn)
        {
            //createDoorsWithInterval();
            createDoorsWithRandomInterval();
        }
	}

    void createDoorsWithInterval()
    {
        intervalTimer -= Time.deltaTime;

        if (intervalTimer <= 0)
        {
            // Timer ran out, create new door
            Instantiate(slidingDoor, transform, false);
            resetIntervalTimer();
        }
    }

    void createDoorsWithRandomInterval()
    {
        intervalTimer -= Time.deltaTime;

        if (intervalTimer <= 0)
        {
            Instantiate(slidingDoor, transform, false);
            gameManager.GetComponent<GameManager>().updateDoorsList();
            resetIntervalTimerRandom();
        }
    }

    void resetIntervalTimer()
    {
        intervalTimer = staticSpawningInterval;
    }

    void resetIntervalTimerRandom()
    {
        intervalTimer = Random.Range(minInterval, maxInterval);
    }

    public void changeMinInterval()
    {
        if (minInterval > 0.3f)
        {
            minInterval = minInterval - intervalChangeBetweenLevels;

            if (maxInterval < 0.3f)
            {
                maxInterval = 0.3f;
            }
        }
    }

    public void changeMaxInterval()
    {
        if (maxInterval > 0.5f)
        {
            maxInterval = maxInterval - intervalChangeBetweenLevels;

            if (maxInterval < 0.5f)
            {
                    maxInterval = 0.5f;
            }
        }
    }
}
