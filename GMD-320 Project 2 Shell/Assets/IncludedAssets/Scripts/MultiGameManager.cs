using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MultiGameManager : MonoBehaviour
{


    public static MultiGameManager instance;

    [Header("Working Variables")]
    [SerializeField] bool inMinigame = false;
    public int amountWon = 0;
    public int amountLost = 0;

    [Header("Transition Variables")]
    [SerializeField] Animator mAnim;
    bool isOpen = true;
    string currentMinigame = "";

    [Header("PUT YOUR START SCENE HERE")]
    public List<string> StartMinigameScenes;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        SceneManager.sceneLoaded += HandleSceneLoaded;
        mAnim = GetComponent<Animator>();
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= HandleSceneLoaded;
    }

    public void CloseCurtain()
    {
        if (isOpen)
        {
            mAnim.SetTrigger("Close");
            isOpen = false;
        }
    }

    public void OpenCurtain()
    {
        if (isOpen == false)
        {
            isOpen = true;
            mAnim.SetTrigger("Open");
        }
    }

    public void HandleSceneLoaded(Scene _scene, LoadSceneMode _mode)
    {
        if(_scene.name == currentMinigame || _scene.name == "StartScene")
        {
            OpenCurtain();
        }
    }

    public void StartRandom()
    {
        int randInt = Random.Range(0, StartMinigameScenes.Count);

        currentMinigame = StartMinigameScenes[randInt];
        SceneManager.LoadScene(currentMinigame);
    }

    public void TryTransition()
    {
        if (inMinigame)
        {
            SceneManager.LoadScene("StartScene");
            inMinigame = false;
        }
        else
        {
            StartRandom();
            inMinigame = true;
        }
    }

    public void WonMinigame()
    {
        if (inMinigame)
        {
            CloseCurtain();
            amountWon++;
        }
    }

    public void LostMinigame()
    {
        if (inMinigame)
        {
            CloseCurtain();
            amountLost++;

        }
    }

}
