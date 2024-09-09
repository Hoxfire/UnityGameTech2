using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selected : MonoBehaviour
{
    GameObject script;
    MeshRenderer renderer;
    [SerializeField] Material material;

    private void Awake()
    {
        script = GameObject.Find("Player"); 
        renderer = gameObject.GetComponent<MeshRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log(script.GetComponent<PlayerSelect>().hit.transform.name);
        if (script.GetComponent<PlayerSelect>().hit.transform == transform)
        {
            renderer.materials[1] = material;
            Debug.Log("hit");
        }
        else
        {
            renderer.materials[1] = null;
        }
    }
}
