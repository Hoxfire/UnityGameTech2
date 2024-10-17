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

    public static Spawner_JarCO instance;

    private void Awake()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            Spawners.Add(gameObject.transform.GetChild(i).gameObject);
        }
        if (instance == null)
        {
            instance = this;
        }
        //StartCoroutine(SpawnCounter(spawnTime));
    }

    public IEnumerator SpawnCounter() 
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);
            Instantiate(Spawnable, Spawners[Random.Range(0, Spawners.Count)].transform);
            Debug.Log("coconut spawned");
        }
    }
}
