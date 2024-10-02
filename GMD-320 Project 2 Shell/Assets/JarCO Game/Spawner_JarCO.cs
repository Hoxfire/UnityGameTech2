using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Spawner_JarCO : MonoBehaviour
{
    [SerializeField] List<GameObject> Spawners = new List<GameObject>();

    [SerializeField] GameObject Spawnable;

    [SerializeField] float spawnTime;

    private void Awake()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            Spawners.Add(gameObject.transform.GetChild(i).gameObject);
        }
        StartCoroutine(SpawnCounter(spawnTime));
    }

    private void FixedUpdate()
    {
    }

    IEnumerator SpawnCounter(float st) 
    {
        while (true)
        {
            yield return new WaitForSeconds(st);
            Instantiate(Spawnable, Spawners[Random.Range(0, Spawners.Count)].transform);
            Debug.Log("coconut spawned");
        }
    }
}
