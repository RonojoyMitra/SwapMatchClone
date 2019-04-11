using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager Instance;
    const int ROWS = 7;
    const int COLUMNS = 5;
    //public int[,] _gems = new int[COLUMNS, ROWS];
    public GameObject[,] _gems = new GameObject[COLUMNS,ROWS];
    Color[] _colors = new Color[6];
    public GameObject _gemPrefab;
    Color tempColor;
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
        //for (int x = 0; x < COLUMNS; x++)
        //{
        //    for (int y = 0; y < ROWS; y++)
        //    {
        //        if (x == PlayerScript.Instance.xposition && y == PlayerScript.Instance.yposition && _gems[x,y] != null)
        //        {
        //           tempColor = _gems[x, y].GetComponent<SpriteRenderer>().material.color;
        //           Destroy(_gems[x, y]);
        //           GameObject gem = Instantiate(_gemPrefab);
        //            gem.transform.position = PlayerScript.Instance.oldposition;
        //           gem.GetComponent<SpriteRenderer>().material.color = tempColor;
        //        }
        //    }
        //}
    }
    public void InstantiateGems()
    {
        for (int x = 0; x < COLUMNS; x++)
        {
            for (int y = 0; y < ROWS; y++)
            {
                if (PlayerScript.Instance.xposition == x && PlayerScript.Instance.yposition == y)
                {
                    continue;
                    //GameObject gem = Instantiate(_gemPrefab);
                    //gem.transform.position = new Vector3(x, y);
                    //gem.GetComponent<SpriteRenderer>().material.color = _colors[Random.Range(0, 6)];
                }
                GameObject gem = Instantiate(_gemPrefab);
                _gems[x, y] = gem;
                gem.transform.position = new Vector3(x, y);
                gem.GetComponent<SpriteRenderer>().material.color = _colors[Random.Range(0, 6)];
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
    public void PlayerMovement()
    {
        if (_gems[PlayerScript.Instance.xposition, PlayerScript.Instance.yposition] != null)
        {
            tempColor = _gems[PlayerScript.Instance.xposition, PlayerScript.Instance.yposition].GetComponent<SpriteRenderer>().material.color;
            Destroy(_gems[PlayerScript.Instance.xposition, PlayerScript.Instance.yposition]);
            GameObject gem = Instantiate(_gemPrefab);
            gem.transform.position = PlayerScript.Instance.oldposition;
            _gems[(int)PlayerScript.Instance.oldposition.x,(int)PlayerScript.Instance.oldposition.y] = gem;
            gem.GetComponent<SpriteRenderer>().material.color = tempColor;
            Debug.Log("Gem isn't null");
        }
        else
        {
            Debug.Log("Gem is null");
        }
    }
}
