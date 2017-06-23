using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScores : MonoBehaviour
{
    //public static int[]arr=new int[10];
    //private int index=0;
    private int score;
    private int[] arr;
    public static bool updated = false;
    private void Start()
    {

        updated = false;
        PlayerPrefs.SetInt("Level Completed", 0);
        PlayerPrefs.SetFloat("Level Time", 60);
        PlayerPrefs.SetInt("in_bonus_lvl", 0);

    }
    private void OnGUI()
    {

        GUIStyle scoreStyle = new GUIStyle("Button");
        scoreStyle.fontSize = 22;
        scoreStyle.alignment = TextAnchor.MiddleCenter;

        GUIStyle Label2 = new GUIStyle(GUI.skin.GetStyle("label"));
        Label2.fontSize = 17;

        score = PlayerPrefs.GetInt("Level Score");
        if (!updated)
        {
            arr = getArrayOfScores(score);
            updated = true;
        }
        if (GUI.Button(new Rect(Screen.width / 2 - 150, 50, 200, 75), "New Game", scoreStyle))
        {
            PlayerPrefs.SetInt("Level Score", 0);
            PlayerPrefs.SetInt("Lives", 5);
            Application.LoadLevel(1);
        }

        if (GUI.Button(new Rect(Screen.width / 2 - 150, 580, 200, 75), "Quit", scoreStyle))
        {
            Application.Quit();
        }

        GUI.Label(new Rect(Screen.width / 2 - 180, 150, 250, 175), "      Score of last round: " + score, Label2);

        int hieght = 180;
        for(int i =0; i < arr.Length; i++)
        {
            if(arr[i]!=0)
            GUI.Label(new Rect(Screen.width / 2 - 180, hieght + i*30, 250, 175), (i+1)+":         " + arr[i], Label2);
        }
       
    }
    /*update highscores in memory and returns an array of the highscores*/
    int[] getArrayOfScores(int curr)
    {
        int[] arr;
        int numOfHS = 0;
        /*number of scores in highscore memory*/
        
            int temp = PlayerPrefs.GetInt("HS0");
            if (temp != 0)
                numOfHS++;
         temp = PlayerPrefs.GetInt("HS1");
        if (temp != 0)
            numOfHS++;
         temp = PlayerPrefs.GetInt("HS2");
        if (temp != 0)
            numOfHS++;
         temp = PlayerPrefs.GetInt("HS3");
        if (temp != 0)
            numOfHS++;
         temp = PlayerPrefs.GetInt("HS4");
        if (temp != 0)
            numOfHS++;

        if (numOfHS <5)
            numOfHS++;
        arr = new int[numOfHS];
        int j = 0;
        /*update the arr array of highscores*/
        
        int temp2 = PlayerPrefs.GetInt("HS0");
        if (temp2 != 0)
        {
            arr[j] = temp2;
            j++;
        }
        temp2 = PlayerPrefs.GetInt("HS1");
        if (temp2 != 0)
        {
            arr[j] = temp2;
            j++;
        }
        temp2 = PlayerPrefs.GetInt("HS2");
        if (temp2 != 0)
        {
            arr[j] = temp2;
            j++;
        }
        temp2 = PlayerPrefs.GetInt("HS3");
        if (temp2 != 0)
        {
            arr[j] = temp2;
            j++;
        }
        temp2 = PlayerPrefs.GetInt("HS4");
        if (temp2 != 0)
        {
            arr[j] = temp2;
            j++;
        }
        if (numOfHS < 5)
            arr[numOfHS - 1] = curr;
        else
        {
            Array.Sort(arr);
            if (arr[0] < curr)
                arr[0] = curr;
        }
        Array.Sort(arr);

        /*update the highscores in memorey*/
        PlayerPrefs.SetInt("HS0", arr[0]);
        if(1<numOfHS)
            PlayerPrefs.SetInt("HS1", arr[1]);
        else
            PlayerPrefs.SetInt("HS1", 0);
        if (2 < numOfHS)
            PlayerPrefs.SetInt("HS2", arr[2]);
        else
            PlayerPrefs.SetInt("HS2", 0);
        if (3 < numOfHS)
            PlayerPrefs.SetInt("HS3", arr[3]);
        else
            PlayerPrefs.SetInt("HS3", 0);
        if (4 < numOfHS)
            PlayerPrefs.SetInt("HS4", arr[4]);
        else
            PlayerPrefs.SetInt("HS4", 0); 

        return arr;
    }

}