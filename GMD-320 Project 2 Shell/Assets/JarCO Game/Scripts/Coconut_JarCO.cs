using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coconut_JarCO : MonoBehaviour
{
    RaycastHit hit;

    [SerializeField] GameObject shadow;
    [SerializeField] GameObject modle;

    [SerializeField] LayerMask ground;

    ParticleSystem thing;

    [SerializeField] float downVelocity;

    private void Awake()
    {
        thing = GetComponent<ParticleSystem>();

        modle.GetComponent<Rigidbody>().AddTorque(Quaternion.ToEulerAngles(Random.rotation)*1000,ForceMode.Acceleration); 
    }

    private void Update()
    {

        Physics.Raycast(transform.position, -transform.up, out hit,Mathf.Infinity,ground);
        
        shadow.transform.position = transform.position - Vector3.up * (hit.distance-0.01f);

        float shadowSize = Mathf.Clamp(hit.distance/5, 0.75f, 6); ;

        

        shadow.transform.localScale = new Vector3(shadowSize,0, shadowSize);

        //Debug.Log(hit.distance);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer==8)
        {
            StartCoroutine(particle(gameObject));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Net"))
        {
            Debug.Log("Caught");
            GameManager_JarCO.instance.ScoreUP();
        }
    }

    IEnumerator particle(GameObject cocnut) 
    {
        cocnut.GetComponent<Collider>().enabled = false;
        cocnut.GetComponent<Rigidbody>().useGravity = false;
        modle.GetComponent<MeshRenderer>().material.color = Color.clear;
        thing.Play();
        yield return new WaitForSeconds(1);
        DestroyImmediate(cocnut);
    }
}
