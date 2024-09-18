using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class pizzaMannager : MonoBehaviour
{
    public List<Transform> stops;
    [SerializeField] private Transform marker;

    public int score;

    pizzaState state;

    [SerializeField] TextMesh stateText;

    [SerializeField] Transform timerTrans;

    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            stops.Insert(i, transform.GetChild(i));
        }

        state = pizzaState.Baking;
        pizzaEvent(pizzaState.Baking);
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

    private void pizzaEvent(pizzaState pizzaEvent) 
    {
        if (state == pizzaEvent)
        {
            stateText.text = pizzaEvent.ToString();
        }

        switch (state)
        {
            case pizzaState.Baking:
                StartCoroutine(PizzaCounter(10));
                break;
            case pizzaState.Ready:
                break;
            case pizzaState.Out:
                break;
            case pizzaState.Delivered:
                break;
            default:
                break;
        }
    }

    public IEnumerator PizzaCounter(float timer)
    {
        float timerPrime=-0.1f;
        while (timerPrime>=-360)
        {
            timerTrans.localRotation = Quaternion.Euler(0,0,timerPrime);
            yield return new WaitForSeconds(0.01f);
            timerPrime -= 1.1f;
            Debug.Log(timerPrime);
        }
        //timerPrime = 0;
        EventManager.pizza(pizzaState.Ready);
        pizzaEvent(pizzaState.Ready);
    }
}

public enum pizzaState 
{
    Baking,
    Ready,
    Out,
    Delivered
}

