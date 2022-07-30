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
        _sendSpawnEventCoroutine = StartCoroutine( SendSpawnEventCoroutine() );
    }

    private IEnumerator SendSpawnEventCoroutine()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds( _spawnTime );
        int nextSpawnerId = 0;

        while( _isSpawning == true && _spawners.Count > 0)
        {
            if( _spawners[nextSpawnerId]  )
            {
                _spawners[nextSpawnerId].OnNotify(SpawnerNotification.Spawn);
            }

            nextSpawnerId = (nextSpawnerId + 1) % _spawners.Count;

            yield return waitForSeconds;
        }
    }
}
