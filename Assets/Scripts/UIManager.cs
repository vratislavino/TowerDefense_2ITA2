using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject winScreen;

    [SerializeField]
    private GameObject loseScreen;

    // Start is called before the first frame update
    void Start()
    {
        Player.Instance.GameLost += OnGameLost;    
        Player.Instance.GameWon += OnGameWon;
    }

    private void OnGameWon()
    {
        winScreen.SetActive(true);
        Time.timeScale = 0;
    }

    private void OnGameLost()
    {
        loseScreen.SetActive(true);
        Time.timeScale = 0;
    }
}
