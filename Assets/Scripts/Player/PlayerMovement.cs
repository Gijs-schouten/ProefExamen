using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject player;
    private GameObject _nextSpace;
    public Animator anim;
    private int _currentSpace = 0;
    private Game _game;
    private GameObject[] _spaces;
    private float _elapsedTime;
    private float _waitTime = 1.5f;
    private Vector3 _nextSpaceVector;
    private int _diceRoll;
    private bool _isMoving = false;
    private int _stepCounter;

    void Start()
    {
        _diceRoll = 4;
        _game = GetComponent<Game>();
        _spaces = _game.tiles;        
        anim.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            GoToNextSpace();
        }
    }

    void GoToNextSpace()
    {
       if(_stepCounter <= _diceRoll && !_isMoving)
        {
                _stepCounter += 1;
                anim.SetBool("isJumping", true);
            _nextSpace = _spaces[_currentSpace +=1];
            _nextSpaceVector = new Vector3(_nextSpace.transform.position.x, _nextSpace.transform.position.y + .5f, _nextSpace.transform.position.z);
            StartCoroutine(MoveToNextSpace());
        }
    }

    private IEnumerator MoveToNextSpace()
    {
        _isMoving = true;
        while (_elapsedTime < _waitTime)
        {
            yield return null;
            _elapsedTime += Time.deltaTime;
            player.transform.position = Vector3.Lerp(player.transform.position,_nextSpaceVector, .06f);
            anim.SetBool("isJumping", false);
        }
        _elapsedTime = 0;
        player.transform.position = _nextSpaceVector;
        _isMoving = false;
        GoToNextSpace();
    }
}
