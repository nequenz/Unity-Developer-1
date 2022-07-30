using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SpawnerNotification
{
    Spawn
}

public class Spawner : MonoBehaviour
{
    [SerializeField] private EnemyStupidMove _enemy;


    public void OnNotify(SpawnerNotification spawnerNotification)
    {
        if( spawnerNotification == SpawnerNotification.Spawn )
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        if( _enemy )
        {
            Instantiate( _enemy, transform.position , Quaternion.identity );
        }
    }
}
