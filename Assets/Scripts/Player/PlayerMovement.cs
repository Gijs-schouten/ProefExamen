using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject player;
    public Animator anim;
    public event Action FinalSpace;

    private GameObject _nextSpace;
    private GameObject[] _spaces;

    private Game _game;

    private bool _isMoving = false;
    private float _elapsedTime;
    private float _waitTime = 1.5f;
    private int _stepCounter;
    private int _amount;
    private int _currentSpace = 0;
    private Vector3 _nextSpaceVector;

    Coroutine lastRoutine = null;

    void Start()
    {
        _game = GetComponent<Game>();
        _spaces = _game.tiles;        
        anim.GetComponent<Animator>();
        FinalSpace += Reset;
    }

   public void GoToNextSpace(int steps)
    {
        _amount = steps;
       if(_stepCounter < steps && !_isMoving)
        {
            _stepCounter += 1;
            anim.SetBool("isJumping", true);
            _nextSpace = _spaces[_currentSpace +=1];
            _nextSpaceVector = new Vector3(_nextSpace.transform.position.x, _nextSpace.transform.position.y + .5f, _nextSpace.transform.position.z);
            lastRoutine = StartCoroutine(MoveToNextSpace());          
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
     
        if (_stepCounter < _amount)
        {
            GoToNextSpace(_amount);
        }
        else
        {
            FinalSpace?.Invoke();
        }
    }

    private void Reset()
    {
        StopCoroutine(lastRoutine);
        _stepCounter = 0;
    }
}
