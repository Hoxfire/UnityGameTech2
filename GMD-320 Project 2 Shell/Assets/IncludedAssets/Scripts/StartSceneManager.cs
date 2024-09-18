using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartSceneManager : MonoBehaviour
{
    public TextMeshProUGUI WonText;
    public TextMeshProUGUI LostText;

    private void Start()
    {
        WonText.text = "Amount Won: " + MultiGameManager.instance.amountWon;
        LostText.text = "Amount Lost: " + MultiGameManager.instance.amountLost;
    }

    public void StartRandom()
    {
        MultiGameManager.instance.CloseCurtain();
    }
}
