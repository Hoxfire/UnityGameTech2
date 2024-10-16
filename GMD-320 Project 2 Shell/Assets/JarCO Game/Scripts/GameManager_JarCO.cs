using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum GameState
{
    Title,
    Game,
    Win,
    Lose,
    Over
}

public class GameManager_JarCO : MonoBehaviour
{
    public static GameManager_JarCO instance;
    private static EventManager_JarCO EventManager;

    public int Score = 0;

    public int ScoreToBeat = 5;

    public GameState state = GameState.Title;

    [SerializeField] TMP_Text Timer;

    private void Awake()
    {
        if (instance == null) 
        {
            instance = this;
        }
        //StartCoroutine(StartTimer(1));
        EventManager = EventManager_JarCO.instance;
    }

    public void changeState(GameState newState) 
    {
        state = newState;
        switch (state)
        {
            case GameState.Title:
                EventManager.TitleScreen();
                break;
            case GameState.Game:
                StartCoroutine(Spawner_JarCO.instance.SpawnCounter());
                StartCoroutine(StartTimer(1));
                EventManager_JarCO.instance.Score.text = Score.ToString();
                break;
            case GameState.Win:
                EventManager.WinScreen();
                break;
            case GameState.Lose:
                EventManager.LoseScreen();
                break;
            case GameState.Over:
                if (Score>=ScoreToBeat)
                {
                    changeState(GameState.Win);
                }
                else
                {
                    changeState(GameState.Lose);
                }
                break;
            default:
                break;
        }

    }

    public void ScoreUP() 
    {
        Score = Score + 1;
        EventManager_JarCO.instance.Score.text = Score.ToString();
    }

    public float timer = 30;

    

    IEnumerator StartTimer(int startWait) 
    {
        
        while (timer!=0) 
        {
            yield return new WaitForSeconds(startWait);
            timer -=  startWait;
            Timer.text = timer.ToString();
        }
        changeState(GameState.Over);
    }
}

