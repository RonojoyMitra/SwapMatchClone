using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    const int ROWS = 7;
    const int COLUMNS = 5;
    int[,] _gems = new int[COLUMNS, ROWS];
    public GameObject _gemPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InstantiateGems();
    }
    public void InstantiateGems()
    {
        for (int x = 0; x < COLUMNS; x++)
        {
            for (int y = 0; y < ROWS; y++)
            {
                GameObject gem = Instantiate(_gemPrefab);
                gem.transform.position = new Vector3(x, y);
            }
        }
    }
}
