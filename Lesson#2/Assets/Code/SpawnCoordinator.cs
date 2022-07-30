using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoordinator : MonoBehaviour
{
    private Coroutine _sendSpawnEventCoroutine;
    private bool _isSpawning = true;

    [SerializeField] private float _spawnTime = 2f;
    [SerializeField] private List<Spawner> _spawners = new List<Spawner>();

    private void Start()
    {
        _sendSpawnEventCoroutine = StartCoroutine( CoordinateSpawns() );
    }

    private IEnumerator CoordinateSpawns()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds( _spawnTime );
        int nextSpawnerId = 0;

        while( _isSpawning == true )
        {
            if( _spawners[nextSpawnerId]  )
            {
                _spawners[nextSpawnerId].Spawn();
            }

            nextSpawnerId = (nextSpawnerId + 1) % _spawners.Count;

            yield return waitForSeconds;
        }
    }
}
