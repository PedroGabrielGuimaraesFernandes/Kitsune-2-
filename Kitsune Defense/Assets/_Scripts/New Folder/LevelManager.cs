﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	

    public void ChangeLevel(string level)
    {
        MainData.NextScene = level;

        SceneManager.LoadScene("loading");
    }

    public void DelayedChangeLevel(string level)
    {
        MainData.NextScene = level;
        
        Invoke("LoadLoading",0.3f);
    }

    public void LoadLoading()
    {
        SceneManager.LoadScene("Loading");
    }

    public void ResetLevel()
    {
        string level = SceneManager.GetActiveScene().name.ToString();
        MainData.NextScene = level;
        Time.timeScale = 1;
        SceneManager.LoadScene("Loading");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ResetProgress()
    {
        MainData.ResetLevels();
    }
}
