using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pizzaMannager : MonoBehaviour
{
    public List<Transform> stops;
    [SerializeField] private Transform marker;

    public int score;

    pizzaState state;

    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            stops.Insert(i, transform.GetChild(i));
        }
    }

    private int nextStop;
    public void NextStop() 
    {
        nextStop = Random.Range(0, transform.childCount);
        marker.position = stops[nextStop].position + new Vector3(0,5);
        state = pizzaState.Out;
    }

    public void FinishedStop() 
    {
        score++;
        Destroy(stops[nextStop].gameObject);
        stops.RemoveAt(nextStop);
        state = pizzaState.Delivered;
    }
}

public enum pizzaState 
{
    Baking,
    Ready,
    Out,
    Delivered
}
