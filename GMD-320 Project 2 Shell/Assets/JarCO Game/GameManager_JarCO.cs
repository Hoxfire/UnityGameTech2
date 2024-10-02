using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_JarCO : MonoBehaviour
{
    public static GameManager_JarCO instance;

    public int Score=0;

    private void Awake()
    {
        if (instance == null) 
        {
            instance = new GameManager_JarCO();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
