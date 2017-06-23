using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class About : MonoBehaviour {

	// Use this for initialization
	void Start () {
        PlayerPrefs.SetInt("Level Completed", 0);
        PlayerPrefs.SetFloat("Level Time", 60);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnGUI()
    {
        Rect box = new Rect(Screen.width / 2 - 150, 150, 200, 175);
        GUI.Label(box, "Description:");
        GUI.Label(new Rect(Screen.width / 2 - 150, 165, 200, 175), "Help the blue reach the yellow block. be careful! don't fall of the board or get hit by the red enemies. don't pass on the coins  ");
        GUI.Label(new Rect(Screen.width / 2 - 150, 230, 200, 175), "Keys: Arrows and P for pause ");

        if (GUI.Button(new Rect(Screen.width / 2 - 150, 550, 200, 75), "Main Menu"))
        {
            PlayerPrefs.SetInt("Level Score", 0);
            PlayerPrefs.SetInt("Lives", 5);
            Application.LoadLevel(0);
        }
    }
}
