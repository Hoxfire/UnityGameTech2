using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    public static event Action BiggerEvent;
    public static event Action SmallerEvent;

    public static event Action<int> OpenDoorEvent;

    public static event Action<pizzaState> pizzaEvent;

    public static void OpenDoor(int id) 
    {
        OpenDoorEvent?.Invoke(id);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public static void pizza(pizzaState pizza) 
    {
        pizzaEvent?.Invoke(pizza);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (BiggerEvent != null)
            {
                BiggerEvent();
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            SmallerEvent?.Invoke();
        }
    }
}
