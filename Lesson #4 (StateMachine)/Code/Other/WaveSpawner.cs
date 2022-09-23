using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Wave
{
    [SerializeField] Actor _actorToSpawn;
    [SerializeField] int _actorCountToSpawn;

    public Actor ActorToSpawn => _actorToSpawn;
    public int ActorCountToSpawn => _actorCountToSpawn;

    public void DeascreaseAmount() => _actorCountToSpawn--;

    public bool IsAmountOver() => _actorCountToSpawn <= 0;
}

public class WaveSpawner : Spawner
{
    [SerializeField] private List<Wave> _waves = new List<Wave>();
    private int _currentWaveIndex = 0;

    public event Action<Wave> OnWaveChanged;

    protected override void Start()
    {
        SetActorToSpawn(_waves[_currentWaveIndex].ActorToSpawn);
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }

    private bool IsNextWaveExist() => (_currentWaveIndex + 1) < _waves.Count;

    private void NextWave() => _currentWaveIndex++;

    private void OnWaveChange(Wave nextWave)
    {
        Debug.Log("Wave has been chacnaged on:" + nextWave.ActorToSpawn.name);
    }

    protected override void OnSpawn()
    {
        Wave wave = _waves[_currentWaveIndex];

        wave.DeascreaseAmount();
        _waves[_currentWaveIndex] = wave;

        if (wave.IsAmountOver() && IsNextWaveExist())
        {
            NextWave();
            wave = _waves[_currentWaveIndex];
            OnWaveChange(wave);
            OnWaveChanged?.Invoke(wave);
            SetActorToSpawn(wave.ActorToSpawn);
        }
        else if ( wave.IsAmountOver() )
            DisableSpawning();
    }

}
