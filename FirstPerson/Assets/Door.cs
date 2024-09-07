using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] int EventID = 0;

    // Start is called before the first frame update
    void Start()
    {
        EventManager.OpenDoorEvent += OpenDoor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OpenDoor(int id) 
    {
        if (EventID == id) 
        {
            gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        EventManager.OpenDoorEvent -= OpenDoor;
    }
}
