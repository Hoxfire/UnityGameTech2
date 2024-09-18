using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_RW : MonoBehaviour
{
    public float RotateSpeed = 360f;
    
    public bool isBadGem = false;
    public GameObject GemParticle;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, RotateSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        GameManager_RW.instance.GetCollected(!isBadGem);
        AudioManager_RW.instance.PlayCollect();
        GameObject.Instantiate(GemParticle, transform.position, transform.rotation);

        Destroy(this.gameObject);
    }
}
