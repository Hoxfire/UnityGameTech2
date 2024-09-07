using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSize : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventManager.BiggerEvent += MakeBigger;
        EventManager.SmallerEvent += MakeSmaller;
    }

    void MakeBigger()
    {
        transform.localScale *= 1.1f;
    }

    void MakeSmaller()
    {
        transform.localScale *= 0.9f;
    }

    private void OnDisable()
    {
        EventManager.BiggerEvent -= MakeBigger;
        EventManager.SmallerEvent -= MakeSmaller;
    }
}
