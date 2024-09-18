using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager_RW : MonoBehaviour
{
    public int AmountCollected = 0;
    public int TotalAmount = 4;
    public static float TimeScale = 0;

    public static GameManager_RW instance;

    [Header("UI")]
    public GameObject StartScreen;
    public GameObject GameScreen;
    public GameObject EndScreenWin;
    public GameObject EndScreenLose;
    public TextMeshProUGUI CollectedText;

    private void Awake()
    {
        instance = this;
    }

    public void StartGame()
    {
        StartScreen.SetActive(false);
        GameScreen.SetActive(true);
        TimeScale = 1.0f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void YouWon()
    {
        MultiGameManager.instance?.WonMinigame();
    }

    public void YouLost()
    {
        MultiGameManager.instance?.LostMinigame();
    }

    public void GetCollected(bool good)
    {
        if(good)
        {           
            AmountCollected++;
            CollectedText.text = "Gems Collected: " + AmountCollected + "/4";
            if (AmountCollected >= TotalAmount)
            {
                WinGame();
            }
        }
        else
        {
            LoseGame();
        }
    }

    public void WinGame()
    {
        TimeScale = 0;
        GameScreen.SetActive(false);
        EndScreenWin.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void LoseGame()
    {
        GameScreen.SetActive(false);
        EndScreenLose.SetActive(true);
        TimeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
