using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScoreManager : MonoBehaviour
{
    public GameObject moveUpObject;

    GameObject gameManager;
    GameObject scoreObject;
    GameObject moveUpParent;
    int score = 0;
    int plusScore = 0;

    int doorPassed = 0;

    // Use this for initialization
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        scoreObject = GameObject.Find("TextScoreNumber");
        moveUpParent = GameObject.Find("TextMoveUpParent");
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager)
        {
            if (doorPassed < gameManager.GetComponent<GameManager>().doorsPassed)
            {
                doorPassed = gameManager.GetComponent<GameManager>().doorsPassed;
                InstantiateMoveUpText(100);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            InstantiateMoveUpText(500);
        }

        if (plusScore > 0)
        {
            --plusScore;
            ++score;
        }

        string str0 = "";
        for (int i = 0; i < 10 - score.ToString().Length; ++i)
        {
            str0 += "0";
        }
        scoreObject.GetComponent<Text>().text = str0 + score.ToString();
    }

    void InstantiateMoveUpText(int addScore)
    {
        int down = 0;
        if (moveUpParent.transform.childCount > 0)
        {
            Vector3 childPos = moveUpParent.transform.GetChild(moveUpParent.transform.childCount - 1).localPosition;
            down = (int)(childPos.y) / 40 - 2;
        }
        if (down > -2)
        {
            down = -2;
        }
        GameObject instObj = Instantiate<GameObject>(moveUpObject, moveUpParent.transform);
        Vector3 instPos = instObj.transform.localPosition;
        instPos.y = down * 40;
        instObj.transform.localPosition = instPos;
        instObj.GetComponent<Text>().text = "+" + addScore.ToString();
        instObj.GetComponent<UIMoveUpScore>().addScore = addScore;
    }

    public void AddPlusScore(int addScore)
    {
        plusScore += addScore;
    }
}
