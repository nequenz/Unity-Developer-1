using System;
using UnityEngine;


public class Spawner : MonoBehaviour
{
    [SerializeField] private LivingActor _objectToSpawn;
    [SerializeField] private Transform _positionToSpawn;
    [SerializeField] private float _spawnDelay = 1.0f;
    private bool _isSpawning = true;

    protected float SpawnTime = 0.0f;

    private event Action<LivingActor> OnSpawned;

    protected virtual void OnEnable()
    {
        SpawnTime = _spawnDelay;

        if (_positionToSpawn == null)
        {
            _positionToSpawn = transform;
        }
    }

    protected virtual void Update()
    {
        SpawnByDelay();
    }

    protected virtual void OnSpawn( LivingActor gameObject )
    {
        
    }

    private void SpawnByDelay()
    {
        LivingActor livingActor;

        if (_isSpawning && SpawnTime > 0)
        {
            SpawnTime -= Time.deltaTime;

            if (SpawnTime <= 0)
            {
                livingActor = Spawn();

                OnSpawn(livingActor);
                OnSpawned?.Invoke(livingActor);
            }  
        }
    }

    private LivingActor Spawn()
    {
        SpawnTime = _spawnDelay;

        if (_objectToSpawn == null)
            return null;

        return Instantiate(_objectToSpawn, _positionToSpawn.position, Quaternion.identity); 
    }

    public void SetSpawnDelay(float delay) => _spawnDelay = delay;

    public void SetObjectToSpawn( LivingActor objectToSpawn ) => _objectToSpawn = objectToSpawn;

    public void StopSpawn() => _isSpawning = false;

    public void ResumeSpawn() => _isSpawning = true;
}
