using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int currentScore, highScore, currentLevel = 1, unlockedLevel;
    public float startTime;
    private float saveStartTime;
    private string currentTime;
    private bool displayMessage1 = true;
    private bool displayMessage2 = true;
    public int coin_start_bonus = 0;
    public Rect timerRect;
    public GUISkin skin;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }
        currentScore = PlayerPrefs.GetInt("Level Score");
        startTime -= Time.deltaTime;
        currentTime = string.Format("{0:0.0}", startTime);
        if (startTime <= 0)
        {
            PlayerPrefs.SetInt("Lives", PlayerPrefs.GetInt("Lives") - 1);
            if (PlayerPrefs.GetInt("Lives") > 0)
            {
                startTime = 60f;
            }
            else
            {
                PlayerPrefs.SetInt("in_bonus_lvl", 0);
                Application.LoadLevel(7);
            }
        }
    }

    public void completeLevel()
    {
        if (currentLevel < 6)
        {
            currentLevel = PlayerPrefs.GetInt("Level Completed") + 1;
            PlayerPrefs.SetInt("Level Completed", currentLevel);
            PlayerPrefs.SetFloat("Level Time", startTime);
            Application.LoadLevel(currentLevel + 1);
        }
        else /*finished last level*/
        {
            Destroy(this);
            PlayerPrefs.SetInt("in_bonus_lvl", 0);
            Application.LoadLevel(7);
        }
    }

    private void Start()
    {
        currentScore = PlayerPrefs.GetInt("Level Score");
        currentLevel = PlayerPrefs.GetInt("Level Completed");
        startTime = 60f;
    }

    private void OnGUI()
    {
        GUI.skin = skin;
        GUI.Label(timerRect, "Time: " + currentTime);
        GUI.Label(new Rect(50, 120, 200, 800), "Score: " + currentScore);
        GUI.Label(new Rect(50, 175, 200, 800), "Lives: ");
        if (displayMessage1 && currentLevel == 0 && PlayerPrefs.GetInt("in_bonus_lvl") == 0)
        {
            if (startTime > 57f)
            {
                GUIStyle scoreStyle = new GUIStyle("box");
                scoreStyle.fontSize = 22;
                scoreStyle.alignment = TextAnchor.MiddleCenter;
                //GUI.Label(new Rect(Screen.width/5, Screen.height/3, 1000, 50), "Guide: Avoid the red enemy! Reach the Yellow with the arrows! Collect the Coins!");
                GUI.Box(new Rect(Screen.width / 5, Screen.height / 3, 1000, 250), "Guide: Avoid the red enemy! Reach the Yellow with the arrows! Collect the Coins!", scoreStyle);
            }
            else
            {
                displayMessage1 = false;
            }
        }
        if (displayMessage2 && currentLevel == 4 && PlayerPrefs.GetInt("in_bonus_lvl") == 0)
        {
            if (startTime > 58f)
            {
                GUIStyle scoreStyle = new GUIStyle("box");
                scoreStyle.fontSize = 22;
                scoreStyle.alignment = TextAnchor.MiddleCenter;
                //GUI.Label(new Rect(Screen.width/5, Screen.height/3, 1000, 50), "Guide: Avoid the red enemy! Reach the Yellow with the arrows! Collect the Coins!");
                GUI.Box(new Rect(Screen.width / 5, Screen.height / 2, 800, 50), "Guide: Jump with the Space bar or with your Mouse!", scoreStyle);
            }
            else
            {
                displayMessage2 = false;
            }
        }
        if (PlayerPrefs.GetInt("in_bonus_lvl") == 1)
        {
            if (startTime > 58f)
            {
                GUIStyle scoreStyle = new GUIStyle("box");
                scoreStyle.fontSize = 22;
                scoreStyle.alignment = TextAnchor.MiddleCenter;
                //GUI.Label(new Rect(Screen.width/5, Screen.height/3, 1000, 50), "Guide: Avoid the red enemy! Reach the Yellow with the arrows! Collect the Coins!");
                GUI.Box(new Rect(Screen.width / 5, Screen.height / 2, 800, 50), "Guide: Collect ALL coins!", scoreStyle);
            }
        }
    }
}
