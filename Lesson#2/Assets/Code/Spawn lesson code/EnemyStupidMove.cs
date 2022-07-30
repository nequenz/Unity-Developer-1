using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent( typeof( Collider ) )]
[RequireComponent( typeof( Rigidbody ) )]
public class EnemyStupidMove : MonoBehaviour
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
            Vector3 randomForceDirection = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f));
            _rigidBody.AddForce(randomForceDirection * force);

            yield return _waitSecond;
        }
    }
}
