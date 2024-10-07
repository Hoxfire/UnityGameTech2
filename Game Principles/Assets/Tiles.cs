using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiles : MonoBehaviour
{
    [SerializeField] GameObject preFav;

    [SerializeField] List<GameObject> tiles = new List<GameObject>();

    public int row = 10;
    public int col = 10;

    [SerializeField] float tileDis;

    private void Awake()
    {
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                GameObject newTile = Instantiate(preFav,new Vector3(-j,0,i)*tileDis, Quaternion.identity,transform);
                tiles.Add(newTile);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0;i < tiles.Count; i++) 
        {
            tiles[i].GetComponent<Renderer>().material.color = Random.ColorHSV();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
