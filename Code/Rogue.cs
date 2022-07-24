using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rogue : MonoBehaviour
{
    private Vector3 _startPosition;
    private float _additinalSpeed = 3f;

    [SerializeField] private float _moveSpeed = 1.0f;
    [SerializeField] private Transform _moveTarget;

    private void Start()
    {
        _startPosition = transform.position;
    }

    private void Update()
    {
        MoveToItem();
    }

    private void MoveToItem()
    {
        float speed = Time.deltaTime * _moveSpeed;

        if (_moveTarget != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, _moveTarget.transform.position, speed);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, _startPosition, speed);
        }
    }

    public void OnEnterAntiRogueZone()
    {
        _moveSpeed += _additinalSpeed;
    }

    public void OnLeaveAntiRogueZone()
    {
        _moveSpeed -= _additinalSpeed;
    }

    public void OnTakeItem()
    {
        _moveTarget = null;
    }
}
