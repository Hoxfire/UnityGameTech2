using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager_RW : MonoBehaviour
{
    public static AudioManager_RW instance;
    public AudioSource Pickup;

    private void Awake()
    {
        instance = this;
    }

    public void PlayCollect()
    {
        Pickup.pitch = Random.Range(1f, 1.2f);
        Pickup.Play();
    }
}
