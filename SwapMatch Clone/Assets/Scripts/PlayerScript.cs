using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    public static PlayerScript Instance;
    //private int[,] _Gems = new int[7,5];
    public GameObject _playerPrefab;
    GameObject _currentPlayer;
    GameObject _oldPlayer;
    public GameObject GridManager;
    public int xposition = 2;
    public int yposition = 3;
    public Vector2 oldposition = new Vector2(2, 3);
    private int _playerMoveCount = 6;
    //public Text _playerMoveText;
    public TextMeshProUGUI _playerMoveText;
    //public int oldxposition = 2;
    //public int oldyposition = 3;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        //GameObject.Find("GridManager").GetComponent<GridManager>();
        //GridManager.Instance._gems[3, 2] = Instantiate(_playerPrefab);
        _currentPlayer = Instantiate(_playerPrefab);
        //Player.transform.position = GridManager.Instance._gems[2,3];
        //GridManager.Instance._gems[3, 2] = Player;
        _currentPlayer.transform.position = new Vector3(xposition,yposition);
        //_playerMoveText.transform.position = _currentPlayer.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && xposition > 0)
        {
            oldposition = new Vector2(xposition, yposition);
            xposition--;
            _currentPlayer.transform.position = new Vector3(xposition ,yposition);
            //_playerMoveText.transform.position = _currentPlayer.transform.position;
            _playerMoveCount--;
            GridManager.SendMessage("PlayerMovement"); 
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && xposition < 4)
        {
            //_oldPlayer = _currentPlayer;
            oldposition = new Vector2(xposition, yposition);
            xposition++;
            //_currentPlayer = Instantiate(_playerPrefab);
            _currentPlayer.transform.position = new Vector3(xposition ,yposition);
            //_playerMoveText.transform.position = _currentPlayer.transform.position;
            _playerMoveCount--;
            GridManager.SendMessage("PlayerMovement");
            //Destroy(_oldPlayer);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && yposition < 6)
        {
            //_oldPlayer = _currentPlayer;
            //oldyposition = yposition;
            //oldxposition = xposition;
            oldposition = new Vector2(xposition,yposition);
            yposition++;
            //_currentPlayer = Instantiate(_playerPrefab);
            _currentPlayer.transform.position = new Vector3(xposition, yposition);
            //_playerMoveText.transform.position = _currentPlayer.transform.position;
            _playerMoveCount--;
            GridManager.SendMessage("PlayerMovement");
            //Destroy(_oldPlayer);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && yposition > 0)
        {
            //_oldPlayer = _currentPlayer;
            oldposition = new Vector2(xposition,yposition);
            yposition--;
            //_currentPlayer = Instantiate(_playerPrefab);
            _currentPlayer.transform.position = new Vector3(xposition, yposition);
            //_playerMoveText.transform.position = _currentPlayer.transform.position;
            _playerMoveCount--;
            GridManager.SendMessage("PlayerMovement");
            //Destroy(_oldPlayer);
        }
    }
}
