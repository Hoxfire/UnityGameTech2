using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    private void FixedUpdate()
    {
        RaycastHit hit;
        Physics.Raycast(Camera.main.transform.position, Vector3.zero, out hit, Mathf.Infinity, LayerMask.GetMask("Ground"));
        Debug.Log(Camera.main.WorldToViewportPoint(Input.mousePosition));
        
        Debug.DrawRay(Camera.main.transform.position, Vector3.zero * hit.distance, Color.yellow);
    }
}
