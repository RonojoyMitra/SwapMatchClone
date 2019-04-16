using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public static PlayerScript Instance;
    //private int[,] _Gems = new int[7,5];
    public GameObject _playerPrefab;
    GameObject _currentPlayer;
    GameObject _oldPlayer;
    public GameObject _GridManager;
    public int xposition = 2;
    public int yposition = 3;
    public Vector2 oldposition = new Vector2(2, 3);
    public int _playerMoveCount = 6;
    //public Text _playerMoveText;
    public TextMeshPro _playerMoveText;
    public TextMeshProUGUI _playerMoveText2;
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
        //GridManager.Instance._gems[xposition, yposition] = _currentPlayer;
        _currentPlayer.transform.position = new Vector3(xposition,yposition);
        _playerMoveText = _playerPrefab.GetComponentInChildren<TextMeshPro>();
        //_playerMoveText.transform.position = _currentPlayer.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        _playerMoveText.text = _playerMoveCount.ToString();
        _playerMoveText2.text = _playerMoveCount.ToString();
        //_playerPrefab.GetComponentInChildren<TextMeshPro>().text = _playerMoveCount.ToString();
        if (Input.GetKeyDown(KeyCode.LeftArrow) && xposition > 0)
        {
            oldposition = new Vector2(xposition, yposition);
            xposition--;
            _currentPlayer.transform.position = new Vector3(xposition ,yposition);
            //GridManager.Instance._gems[xposition, yposition] = _currentPlayer;
            //_playerMoveText.transform.position = _currentPlayer.transform.position;
            _playerMoveCount--;
            _GridManager.SendMessage("PlayerMovement"); 
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && xposition < 4)
        {
            //_oldPlayer = _currentPlayer;
            oldposition = new Vector2(xposition, yposition);
            xposition++;
            //_currentPlayer = Instantiate(_playerPrefab);
            _currentPlayer.transform.position = new Vector3(xposition ,yposition);
            //GridManager.Instance._gems[xposition, yposition] = _currentPlayer;
            //_playerMoveText.transform.position = _currentPlayer.transform.position;
            _playerMoveCount--;
            _GridManager.SendMessage("PlayerMovement");
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
            //GridManager.Instance._gems[xposition, yposition] = _currentPlayer;
            //_playerMoveText.transform.position = _currentPlayer.transform.position;
            _playerMoveCount--;
            _GridManager.SendMessage("PlayerMovement");
            //Destroy(_oldPlayer);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && yposition > 0)
        {
            //_oldPlayer = _currentPlayer;
            oldposition = new Vector2(xposition,yposition);
            yposition--;
            //_currentPlayer = Instantiate(_playerPrefab);
            _currentPlayer.transform.position = new Vector3(xposition, yposition);
            //GridManager.Instance._gems[xposition, yposition] = _currentPlayer;
            //_playerMoveText.transform.position = _currentPlayer.transform.position;
            _playerMoveCount--;
            _GridManager.SendMessage("PlayerMovement");
            //Destroy(_oldPlayer);
        }
        if (_playerMoveCount == 0)
        {
            SceneManager.LoadScene("EndScreen");
        }
    }
}
