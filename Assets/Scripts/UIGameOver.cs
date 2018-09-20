using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIGameOver : MonoBehaviour
{
    GameObject gameManager;
    GameObject gameOverMaskObject;
    GameObject gameOverTextObject;
    GameObject gameOverButtonObject;
    GameObject gameOverButtonObject2;
    GameObject fadeObject;
    bool isGameOver = false;

    // Use this for initialization
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        gameOverMaskObject = GameObject.Find("ImageGameOverMask");
        gameOverTextObject = GameObject.Find("TextGameOver");
        gameOverButtonObject = GameObject.Find("ButtonReStart");
        gameOverButtonObject2 = GameObject.Find("ButtonReturnToTitle");
        fadeObject = GameObject.Find("Fade");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            isGameOver = true;
        }

        if (gameManager)
        {
            isGameOver = gameManager.GetComponent<GameManager>().isGameOver;
        }

        if (isGameOver)
        {
            // update mask size
            Vector2 size = gameOverMaskObject.GetComponent<RectTransform>().sizeDelta;
            size.y += 30;
            if (size.y >= 720)
            {
                size.y = 720;
            }
            gameOverMaskObject.GetComponent<RectTransform>().sizeDelta = size;

            if (size.y >= 360)
            {
                // update text alpha
                Color color = gameOverTextObject.GetComponent<Text>().color;
                color.a += 0.1f;
                if (color.a >= 1.0f)
                {
                    color.a = 1.0f;
                }
                gameOverTextObject.GetComponent<Text>().color = color;

                // update button size
                size = gameOverButtonObject.GetComponent<RectTransform>().sizeDelta;
                size.y += 10;
                if (size.y >= 100)
                {
                    size.y = 100;
                }
                gameOverButtonObject.GetComponent<RectTransform>().sizeDelta = size;
                gameOverButtonObject2.GetComponent<RectTransform>().sizeDelta = size;
            }
        }
    }

    IEnumerator SceneChange(string nextScene)
    {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(nextScene);
    }

    public void OnClickReStartButton()
    {
        fadeObject.GetComponent<UIFadeManager>().fadeOut = true;
        StartCoroutine("SceneChange", "GameScene");
    }

    public void OnClickReturnToTitleButton()
    {
        fadeObject.GetComponent<UIFadeManager>().fadeOut = true;
        StartCoroutine("SceneChange", "TitleScene");
    }
}
