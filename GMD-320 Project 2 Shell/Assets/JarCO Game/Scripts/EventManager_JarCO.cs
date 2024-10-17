using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Playables;

public class EventManager_JarCO : MonoBehaviour
{
    public TMP_Text Score;
    public static EventManager_JarCO instance;

    [SerializeField] GameObject TitleScreenGO;
    [SerializeField] GameObject GameScreenGO;

    PlayerMove_JarCO PlayerMove;

    [SerializeField] PlayableDirector timeLine;

    [SerializeField] List<GameObject> numbers;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        PlayerMove = GameObject.Find("Player").GetComponent<PlayerMove_JarCO>();
    }


    public void TitleScreen() 
    {
        TitleScreenGO.SetActive(false);
        timeLine.Play();
    }

    public void GameScreen() 
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        GameManager_JarCO.instance.changeState(GameState.Game);
        GameScreenGO.SetActive(true);
    }

    public void WinScreen() 
    {

    }

    public void LoseScreen()
    {
        
    }

    private int cNum = 0;
    public void changeNumber() 
    {
        switch (cNum)
        {
            case 0:
                numbers[0].SetActive(true); 
                break;
            case 1:
                numbers[0].SetActive(false);
                numbers[1].SetActive(true);
                break;
            case 2:
                numbers[1].SetActive(false);
                numbers[2].SetActive(true);
                break;
            case 3:
                numbers[2].SetActive(false);
                numbers[3].SetActive(true);
                Destroy(numbers[3], 1);
                break;
            default:
                break;
        }
        cNum++;
    }
}
