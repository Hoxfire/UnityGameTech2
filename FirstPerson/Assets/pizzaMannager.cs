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

    private void FixedUpdate()
    {
        if (transform.childCount==0)
        {
            stateText.text = "YOU WIN";
        }
    }

    public void pizzaEvent(pizzaState pizzaEvent) 
    { 
        state= pizzaEvent;
        stateText.text = pizzaEvent.ToString();
        switch (state)
        {
            case pizzaState.Baking:
                break;
            case pizzaState.Ready:
                break;
            case pizzaState.Out:
                NextStop();
                break;
            case pizzaState.Delivered:
                if (GameObject.Find("Player").GetComponent<PlayerSelect>().hit.collider.name == stops[nextStop].name)
                {
                    FinishedStop();
                    state = pizzaState.Baking;
                }
                else {
                    StartCoroutine(PizzaCounter(1));
                }
                break;
            default:
                break;
        }
    }

    public IEnumerator PizzaCounter(float timer)
    {
            stateText.text = "WrongPlace";
            yield return new WaitForSeconds(timer);
            stateText.text = "Out"; 
        
    }
}

public enum pizzaState 
{
    Baking,
    Ready,
    Out,
    Delivered
}

