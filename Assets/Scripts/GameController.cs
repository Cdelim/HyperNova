﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public event System.Action onGameOver;
    //public event System.Action onLevelFinish;

    public static int numberOfRope;
    void Awake()
    {
        numberOfRope = (GameObject.FindGameObjectsWithTag("Rope").Length); //Minus 1 for panel 
    }

    void Update()
    {
        isGameOver();
        isLevelFinish();
    }

    void isGameOver() {
        if (MenuManager.numberOfMove <= 0) {
            if (onGameOver != null) onGameOver();
        }
    }
    void isLevelFinish() {
        if (numberOfRope <= 0)
        {
            MenuManager.numberOfMove = 7;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
    }
}
