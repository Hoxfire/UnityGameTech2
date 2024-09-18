using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selected : MonoBehaviour
{
    PlayerSelect script;
    MeshRenderer john;
    [SerializeField] Material material;
    [SerializeField] float distance;

    private void Awake()
    {
        script = GameObject.Find("Player").GetComponent<PlayerSelect>(); 
        john = gameObject.GetComponent<MeshRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        if (script.hit.collider != null)
        {
            if (script.hit.collider.transform == transform && script.hit.distance<=distance)
            {
                //john.materials[1] = material;
                john.material = material;
                //Debug.Log("hit");
            }
            else
            {
                john.material = john.materials[1];
            }
        }
        else
        {
            john.material = john.materials[1];
        }
        
    }

    private void OnMouseDown()
    {
        if (script.hit.collider.transform == transform && script.hit.distance <= distance)
        {
            switch (script.hit.collider.tag)
            {
                case "Bakery":
                    Debug.Log("Bakery");
                    EventManager.pizza(pizzaState.Baking);
                    break;
                case "Stop":
                    Debug.Log("Stop");
                    EventManager.pizza(pizzaState.Delivered);
                    break;
                case "Car":
                    Debug.Log("Car");
                    EventManager.pizza(pizzaState.Out);
                    break;
                default:
                    break;
            }
        }
    }
}
