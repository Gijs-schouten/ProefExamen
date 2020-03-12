using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public  GameObject player;
    public GameObject _nextSpace;
    public Animator anim;

    private float _elapsedTime;
    private float _waitTime = 1.5f;
    private Vector3 _nextSpaceVector;
    private int _diceRoll;
    private bool _isMoving = false;
    private int sharting;

    void Start()
    {
        _diceRoll = 4;
        anim.GetComponent<Animator>();
        _nextSpaceVector = new Vector3(_nextSpace.transform.position.x, _nextSpace.transform.position.y + .5f, _nextSpace.transform.position.z);
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
       if(sharting <= _diceRoll && !_isMoving)
        {
                sharting += 1;
                anim.SetBool("isJumping", true);
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
