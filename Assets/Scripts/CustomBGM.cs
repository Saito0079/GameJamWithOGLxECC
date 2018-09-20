using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomBGM : MonoBehaviour
{
    public AudioClip clip;
    GameObject gameManager;
    AudioSource[] audioSources;
    bool flag = false;
    bool flag2 = false;
    // Use this for initialization
    void Start()
    {
        audioSources = GetComponents<AudioSource>();
        gameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        if (flag2)
        {
            return;
        }

        if (gameManager)
        {
            if (gameManager.GetComponent<GameManager>().doorsPassed > 100)
            {
                flag = true;
            }
            if (Input.GetKey(KeyCode.F8) && Input.GetKey(KeyCode.F10))
            {
                flag = true;
            }
            if (flag)
            {
                audioSources[0].Stop();
                audioSources[1].Stop();
                audioSources[0].volume = 1.0f;
                audioSources[0].clip = clip;
                audioSources[0].Play();
                flag2 = true;
            }
        }
    }
}
