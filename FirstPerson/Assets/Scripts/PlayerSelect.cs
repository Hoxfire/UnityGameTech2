using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelect : MonoBehaviour
{

    public RaycastHit hit;
    // Start is called before the first frame update
    void FixedUpdate()
    {

        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;

        Physics.Raycast(transform.position + new Vector3(0, 2, 0), Camera.main.transform.forward, out hit, Mathf.Infinity,layerMask);

        

        // Does the ray intersect any objects excluding the player layer
        /*
        if (Physics.Raycast(transform.position + new Vector3(0,2,0),Camera.main.transform.forward, out hit, Mathf.Infinity) && hit.distance<0.5f && hit.collider.tag == "Selectable")
        {
            Debug.DrawRay(transform.position + new Vector3(0, 2, 0),Camera.main.transform.forward * hit.distance, Color.yellow);
            //Debug.Log(hit.collider.name);
        }
        else
        {
            Debug.DrawRay(transform.position + new Vector3(0, 2, 0), Camera.main.transform.forward * 1000, Color.white);
            Debug.Log("Did not Hit");
        
        }
        */
    }

    
}
