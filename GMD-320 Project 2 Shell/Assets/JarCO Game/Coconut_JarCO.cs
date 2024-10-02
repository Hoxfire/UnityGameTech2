using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coconut_JarCO : MonoBehaviour
{
    RaycastHit hit;

    [SerializeField] GameObject shadow;

    [SerializeField] LayerMask ground;

    ParticleSystem thing;

    [SerializeField] float downVelocity;

    private void Awake()
    {
        thing = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        Physics.Raycast(transform.position, -transform.up, out hit,Mathf.Infinity,ground);
        
        shadow.transform.position = transform.position - Vector3.up * (hit.distance-0.01f);

        shadow.transform.localScale = new Vector3(hit.distance / 5,0, hit.distance / 5);

        Debug.Log(hit.distance);

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
            GameManager_JarCO.instance.Score += 1;
        }
    }

    IEnumerator particle(GameObject cocnut) 
    {
        cocnut.SetActive(false);
        thing.Play();
        yield return new WaitForSeconds(1);
        DestroyImmediate(cocnut);
    }
}
