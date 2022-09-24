using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private EnemySimpleMove _enemy;

    public void Spawn()
    {
        if( _enemy )
        {
            Instantiate( _enemy, transform.position , Quaternion.identity );
        }
    }
}