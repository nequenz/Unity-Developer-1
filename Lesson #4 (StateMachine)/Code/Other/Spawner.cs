using System;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Actor _actorToSpawn;
    [SerializeField] private Transform _positionToSpawn;
    [SerializeField] private float _spawnSecDelay = 3f;
    [SerializeField] private bool _isSpawning = true;
    private float _delay = 0f;

    public event Action<Actor> OnSpawned;

    public float SpawnDelay => _spawnSecDelay;

    protected virtual void Start()
    {
        _delay = _spawnSecDelay;
    }

    protected virtual void Update()
    {
        Spawning();
    }

    private void Spawning()
    {
        if (_isSpawning == true && _delay > 0f)
        {
            _delay -= Time.deltaTime;

            if (_delay <= 0f)
            {
                Spawn();
                OnSpawn();
                OnSpawned?.Invoke(_actorToSpawn);
                Debug.Log(_actorToSpawn.name + " has been spawned!");
                _delay = _spawnSecDelay;
            }
        }
    }

    private void Spawn()
    {
        if (_actorToSpawn != null && _positionToSpawn != null)
            Instantiate(_actorToSpawn, _positionToSpawn.position, Quaternion.identity);
        else
            DisableSpawning();
    }

    protected virtual void OnSpawn()
    {
        
    }

    public void DisableSpawning() => _isSpawning = false;

    public void EnableSpawning() => _isSpawning = true;

    public void SetActorToSpawn(Actor newActorToSpawn) => _actorToSpawn = newActorToSpawn;
}
