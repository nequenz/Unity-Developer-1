using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rogue : MonoBehaviour
{
    private float _additinalSpeed = 3f;
    [SerializeField] private float _moveSpeed = 1.0f;
    [SerializeField] private Transform _moveTarget;

    private void Update()
    {
        MoveToItem();
    }

    private void MoveToItem()
    {
        if (_moveTarget != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, _moveTarget.transform.position, Time.deltaTime * _moveSpeed);
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
        _moveTarget = GameObject.Find("ExitTarget").transform;
    }
}
