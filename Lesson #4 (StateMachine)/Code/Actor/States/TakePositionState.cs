using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Actor))]
public class TakePositionState : State
{
    [SerializeField] private State _nextAttackState;
    private Vector3 _positonToTake;
    private Actor _actor;
    private Rigidbody _rigidbody;

    protected override void Awake()
    {
        base.Awake();
        _actor = GetComponent<Actor>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        const float distanceZ = 3.0f;
        const float frontWidth = 8.0f;

        _positonToTake = transform.position;
        _positonToTake.z = distanceZ;
        _positonToTake.x = Random.Range(-frontWidth, frontWidth);
    }

    private void FixedUpdate()
    {
        const float MinDistanceToReach = 0.4f;

        _rigidbody.MovePosition(transform.position + (_positonToTake - transform.position).normalized * Time.deltaTime * _actor.MoveSpeed);

        if (Vector3.Distance(transform.position, _positonToTake) < MinDistanceToReach)
            ChangeState(_nextAttackState);
    }
}
