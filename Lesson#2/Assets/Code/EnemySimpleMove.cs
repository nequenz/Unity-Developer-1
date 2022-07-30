using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent( typeof( Collider ) )]
[RequireComponent( typeof( Rigidbody ) )]
public class EnemySimpleMove : MonoBehaviour
{
    private Rigidbody _rigidBody;
    private Coroutine _addForceCoroutine;
    
    private float _timeToChangeDirection = 3f;
    private bool _isMoving = true;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _addForceCoroutine = StartCoroutine( AddRandomForce() );
    }

    private IEnumerator AddRandomForce()
    {
        const float force = 100f;
        WaitForSeconds _waitSecond = new WaitForSeconds( _timeToChangeDirection );

        while( _isMoving == true )
        {
            _rigidBody.AddForce(Random.insideUnitCircle * force);

            yield return _waitSecond;
        }
    }
}
