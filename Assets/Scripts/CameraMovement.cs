using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject target;
    public GameObject playerTarget;
    public float _elapsedTime;
    private IEnumerator _coroutineTopDown;
    private IEnumerator _coroutinePlayer;
    private float _waitTime = 2;
    private bool followPlayer = false;


    void Start()
    {
        _coroutineTopDown = TopDownView();
        _coroutinePlayer = GoToPlayer();
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            StopCoroutine(_coroutineTopDown);
            StartCoroutine(TopDownView());
        }
        if (Input.GetKeyDown("w"))
        {
            StopCoroutine(_coroutinePlayer);
            StartCoroutine(GoToPlayer());
        }
        if (followPlayer)
        {
            transform.position = playerTarget.transform.position;
        }
    }

    void GoToTop()
    {
        StartCoroutine(_coroutineTopDown);
    }

    private IEnumerator TopDownView()
    {
        followPlayer = false;
        while (_elapsedTime < _waitTime)
        {
            yield return null; 
            _elapsedTime += Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, target.transform.position, .1f);
            Quaternion rotation = Quaternion.Euler(90, 0, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 8);       
        }
        _elapsedTime = 0;
        transform.position = target.transform.position;
    }

    private IEnumerator GoToPlayer()
    {
        while (_elapsedTime < _waitTime)
        {
            yield return null;
            _elapsedTime += Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, playerTarget.transform.position, .1f);
            Quaternion rotationPlayer = Quaternion.Euler(45, -90, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotationPlayer, Time.deltaTime * 5);
        }
        transform.position = playerTarget.transform.position;
        followPlayer = true;
        _elapsedTime = 0;
    }
}
