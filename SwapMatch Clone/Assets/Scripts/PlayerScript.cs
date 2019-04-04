using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public static PlayerScript Instance;
    //private int[,] _Gems = new int[7,5];
    public GameObject _playerPrefab;
    public int xposition = 2;
    public int yposition = 3;
    public int oldxposition = 2;
    public int oldyposition = 3;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        //GameObject.Find("GridManager").GetComponent<GridManager>();
        //GridManager.Instance._gems[3, 2] = Instantiate(_playerPrefab);
        GameObject Player = Instantiate(_playerPrefab);
        //Player.transform.position = GridManager.Instance._gems[2,3];
        //GridManager.Instance._gems[3, 2] = Player;
        Player.transform.position = new Vector3(xposition,yposition);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            oldxposition = xposition;
            xposition--;
            GameObject Player = Instantiate(_playerPrefab);
            Player.transform.position = new Vector3(xposition ,yposition);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            oldxposition = xposition;
            xposition++;
            GameObject Player = Instantiate(_playerPrefab);
            Player.transform.position = new Vector3(xposition ,yposition);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            oldyposition = yposition;
            yposition++;
            GameObject Player = Instantiate(_playerPrefab);
            Player.transform.position = new Vector3(xposition, yposition);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            oldyposition = yposition;
            yposition--;
            GameObject Player = Instantiate(_playerPrefab);
            Player.transform.position = new Vector3(xposition, yposition + 1);
        }
    }
}
