using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotFix_JarCO : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("OuterGround"))
        {
            Debug.Log("penits" + gameObject.name);
            gameObject.transform.parent.GetComponent<BoxCollider>().isTrigger = true;
        }
    }



    private void OnTriggerExit(Collider other)
    {
        gameObject.transform.parent.GetComponent<BoxCollider>().isTrigger = false;
    }
}
