using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager Instance;
    const int ROWS = 7;
    const int COLUMNS = 5;
    public int[,] _gems = new int[COLUMNS, ROWS];
    Color[] _colors = new Color[6];
    public GameObject _gemPrefab;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        SetColors();
        InstantiateGems();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void InstantiateGems()
    {
        for (int x = 0; x < COLUMNS; x++)
        {
            for (int y = 0; y < ROWS; y++)
            {
                GameObject gem = Instantiate(_gemPrefab);
                gem.transform.position = new Vector3(x, y);
                gem.GetComponent<SpriteRenderer>().material.color = _colors[Random.Range(0,6)];
            }
        }
    }
    public void SetColors()
    {
        _colors[0] = Color.red;
        _colors[1] = Color.blue;
        _colors[2] = Color.green;
        _colors[3] = Color.yellow;
        _colors[4] = new Color(0,0,0);
        _colors[5] = new Color(128, 0, 128);
    }
}
