using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Wave
{
    [SerializeField] private Actor _actorToSpawn;
    [SerializeField] private int _actorCountToSpawn;

    public Actor ActorToSpawn => _actorToSpawn;
    public int ActorCountToSpawn => _actorCountToSpawn;

    public void DeascreaseAmount() => _actorCountToSpawn--;

    public bool IsAmountOver() => _actorCountToSpawn <= 0;
}

public class WaveSpawner : Spawner
{
    [SerializeField] Transform _targetToAttack;
    [SerializeField] private List<Wave> _waves = new List<Wave>();
    
    private int _currentWaveIndex = 0;

    public event Action<Wave> OnWaveChanged;

    protected override void Start()
    {
        SetTargetOfAttackAbility();
        SetActorToSpawn(_waves[_currentWaveIndex].ActorToSpawn);
        base.Start();
    }

    protected override void Update() => base.Update();

    private bool IsNextWaveExist() => (_currentWaveIndex + 1) < _waves.Count;

    private void NextWave() => _currentWaveIndex++;

    private void OnWaveChange(Wave nextWave) => Debug.Log("Wave has been changed on:" + nextWave.ActorToSpawn.name);

    private void SetTargetOfAttackAbility()
    {
        if (_waves[_currentWaveIndex].ActorToSpawn.TryGetComponent(out AttackAbility attackAbility))
            attackAbility.SelectTarget(_targetToAttack);
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
            SetTargetOfAttackAbility();
            SetActorToSpawn(wave.ActorToSpawn);
        }
        else if ( wave.IsAmountOver() )
            DisableSpawning();
    }

}
