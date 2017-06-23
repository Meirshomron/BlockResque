using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Menu : MonoBehaviour {


    void OnGUI()
    {
        GUIStyle scoreStyle = new GUIStyle("Button");
        scoreStyle.fontSize = 22;
        scoreStyle.alignment = TextAnchor.MiddleCenter;
        if (GUI.Button(new Rect(Screen.width / 2-150, 50, 200, 75), "Play", scoreStyle))
        {
            PlayerPrefs.SetInt("Level Score", 0);
            PlayerPrefs.SetInt("Level Completed", 0);
            PlayerPrefs.SetFloat("Level Time", 60);
            PlayerPrefs.SetInt("Lives", 5);
            PlayerPrefs.SetInt("in_bonus_lvl", 0);

            Application.LoadLevel(1);
        }
        if (GUI.Button(new Rect(Screen.width / 2-150, 135, 200, 75), "High Score", scoreStyle))
        {
            Application.LoadLevel(7);
        }
        if (GUI.Button(new Rect(Screen.width / 2 - 150, 220, 200, 75), "About", scoreStyle))
        {
            Application.LoadLevel(8);
        }
        if (GUI.Button(new Rect(Screen.width / 2-150, 305, 200, 75), "Quit", scoreStyle))
        {
            Application.Quit();
        }
    }


}
