using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMoveUpScore : MonoBehaviour
{
    public int addScore = 0;
    Vector3 targetPosition;

    // Use this for initialization
    void Start()
    {
        targetPosition = GameObject.Find("TextScoreNumber").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // update position
        Vector3 newPos = transform.position;
        newPos.y += 3;
        transform.position = newPos;

        if (transform.position.y > targetPosition.y - 30)
        {
            // update color alpha
            Color color = GetComponent<Text>().color;
            color.a -= 0.1f;
            GetComponent<Text>().color = color;

            if (color.a <= 0)
            {
                GameObject.Find("Score").GetComponent<UIScoreManager>().AddPlusScore(addScore);
                Destroy(gameObject);
            }
        }
    }
}
