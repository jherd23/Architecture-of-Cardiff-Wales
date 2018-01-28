﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainMenu : MonoBehaviour {

    public Text levelNameText;
    public Dictionary<string, string> levelList = new Dictionary<string, string>() {
        { "Ge-msA-eBad", "Germ_Training"}
    };

    public void FindLevel(string lvl = "") {
        string levelName = (lvl.Equals("")) ? levelNameText.text : lvl;
        Debug.Log(levelName);
        if (levelList.ContainsKey(levelName)) {
            PlayGame(levelList[levelName]);
        }
    }

    public void PlayGame(string level) {
        //TODO import other saved data
		GameObject sceneMgmr = GameObject.FindGameObjectWithTag ("SceneHandler");
		if (sceneMgmr != null)
			sceneMgmr.GetComponent<SceneHandler> ().NextLevel (level);
    }

    public void NewGame() {
        PlayGame("Germ_Training");
    }

    public void QuitGame() {
        Debug.Log("QUIT");
		#if UNITY_STANDALONE
		Application.Quit();
		#endif
		#if UNITY_EDITOR
		EditorApplication.Exit(0);
		#endif
    }
}
