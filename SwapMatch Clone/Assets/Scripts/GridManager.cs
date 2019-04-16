using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GridManager : MonoBehaviour
{
    public static GridManager Instance;
    const int ROWS = 7;
    const int COLUMNS = 5;
    //public int[,] _gems = new int[COLUMNS, ROWS];
    public GameObject[,] _gems = new GameObject[COLUMNS, ROWS];
    Color[] _colors = new Color[6];
    public GameObject _gemPrefab;
    Color tempColor;
    int _playerScore = 0;
    public GameObject DestructionParticle;
    public TextMeshProUGUI _ScoreDisplay;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        SetColors();
        InstantiateGems();
        MatchCheck();
        GemReplacement();
    }

    // Update is called once per frame
    void Update()
    {
        GemReplacement();
        _ScoreDisplay.text = _playerScore.ToString();
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
        _colors[4] = new Color(0, 0, 0);
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
            _gems[(int)PlayerScript.Instance.oldposition.x, (int)PlayerScript.Instance.oldposition.y] = gem;
            gem.GetComponent<SpriteRenderer>().material.color = tempColor;
            Debug.Log("Gem isn't null");
            MatchCheck();
            GemReplacement();
        }
        else
        {
            Debug.Log("Gem is null");
        }
    }
    public void MatchCheck()
    {
        for (int x = 0; x < COLUMNS; x++)
        {
            for (int y = 0; y < ROWS; y++)
            {
                //Checking for matches on the right
                if (x < COLUMNS - 2)
                {
                    if (_gems[x, y] && _gems[x + 1, y] != null)
                    {
                        if (_gems[x, y].GetComponent<SpriteRenderer>().material.color == _gems[x + 1, y].GetComponent<SpriteRenderer>().material.color)
                        {
                            if (_gems[x + 2, y] != null)
                            {
                                if (_gems[x + 1, y].GetComponent<SpriteRenderer>().material.color == _gems[x + 2, y].GetComponent<SpriteRenderer>().material.color &&
                                    _gems[x, y].GetComponent<SpriteRenderer>().material.color == _gems[x + 2, y].GetComponent<SpriteRenderer>().material.color
                                    && _gems[x,y].GetComponent<SpriteRenderer>().material.color == _gems[x + 1,y].GetComponent<SpriteRenderer>().material.color)
                                {
                                    Debug.Log("3MatchH");
                                    _playerScore = _playerScore + 1;
                                    PlayerScript.Instance._playerMoveCount = 6;
                                    //_gems[x, y].GetComponent<SpriteRenderer>().material.color = Color.gray;
                                    //_gems[x + 1, y].GetComponent<SpriteRenderer>().material.color = Color.gray;
                                    //_gems[x + 2, y].GetComponent<SpriteRenderer>().material.color = Color.gray;
                                    Destroy(_gems[x, y]);
                                    Destroy(_gems[x + 1, y]);
                                    Destroy(_gems[x + 2, y]);
                                }
                            }
                        }
                    }
                }              
                if (y < ROWS - 2)
                {
                    if (_gems[x, y] && _gems[x, y + 1] != null)
                    {
                        if (_gems[x, y].GetComponent<SpriteRenderer>().material.color == _gems[x, y + 1].GetComponent<SpriteRenderer>().material.color)
                        {
                            if (_gems[x, y + 2] != null)
                            {
                                if (_gems[x, y + 1].GetComponent<SpriteRenderer>().material.color == _gems[x, y + 2].GetComponent<SpriteRenderer>().material.color 
                                    && _gems[x, y].GetComponent<SpriteRenderer>().material.color == _gems[x, y + 2].GetComponent<SpriteRenderer>().material.color
                                    && _gems[x,y].GetComponent<SpriteRenderer>().material.color == _gems[x, y + 1].GetComponent<SpriteRenderer>().material.color)
                                {
                                    _playerScore = _playerScore + 1;
                                    Debug.Log("3MatchV");
                                    PlayerScript.Instance._playerMoveCount = 6;
                                    //_gems[x, y].GetComponent<SpriteRenderer>().material.color = Color.gray;
                                    //_gems[x, y + 1].GetComponent<SpriteRenderer>().material.color = Color.gray;
                                    //_gems[x, y + 2].GetComponent<SpriteRenderer>().material.color = Color.gray;
                                    Destroy(_gems[x, y]);
                                    Destroy(_gems[x, y + 1]);
                                    Destroy(_gems[x, y + 2]);
                                    Instantiate(DestructionParticle,_gems[x,y].transform.position,Quaternion.identity);
                                }
                            }
                        }
                    }
                }
                
                //if (_gems[x, y - 1] != null)
                //{

                //}
            }
        }
    }
    public void GemReplacement()
    {
        for (int x = 0; x < COLUMNS; x++)
        {
            for (int y = 0; y < ROWS; y++)
            {
                if (_gems[x, y] == null)
                {
                    if (PlayerScript.Instance.xposition == x && PlayerScript.Instance.yposition == y)
                    {
                        continue;
                    }
                    GameObject gem = Instantiate(_gemPrefab);
                    _gems[x, y] = gem;
                    gem.transform.position = new Vector3(x, y);
                    gem.GetComponent<SpriteRenderer>().material.color = _colors[Random.Range(0, 6)];
                }
            }
        }
        MatchCheck();
    }
}
