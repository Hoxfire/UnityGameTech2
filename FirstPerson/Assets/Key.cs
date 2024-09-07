using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] int EventID = 0;

    private void OnMouseDown()
    {
        EventManager.OpenDoor(EventID);
    }
}
