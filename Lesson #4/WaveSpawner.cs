using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct Wave
{
    [SerializeField] private LivingActor _objectToSpawn;
    [SerializeField] private int _amount;

    public LivingActor SpawnObject => _objectToSpawn;
    public int Amount => _amount;

    public void SetAmount(int amount) => _amount = amount;

    public bool TryMoveAmount(int amount )
    {
       _amount += amount;

        if( _amount < 0  )
        {
            _amount = 0;

            return false;
        }

        return true;
    }
}

public class WaveSpawner : Spawner
{
    [SerializeField] private List<Wave> _waves = new List<Wave>();
    [SerializeField] private int _currentWaveNumber = 0;
    private Wave _currentWave;

    public event Action OnWaveFinished;
    public event Action OnAllWavesFinished;

    protected virtual void Start()
    {
        TrySetWave(_currentWaveNumber);
    }

    protected override void OnSpawn(LivingActor livingEntity)
    {
        const int amountToDecrease = -1;

        bool _isNextWaveExist;

        if( _currentWave.TryMoveAmount(amountToDecrease) == false )
        {
            OnWaveFinished?.Invoke();
            _isNextWaveExist = NextWave();

            if(_isNextWaveExist == false)
            {
                OnAllWavesFinished?.Invoke();
                StopSpawn();
            }
        }
    }

    public bool TrySetWave(int number)
    {
        if( number >= _waves.Count )
        {
            _currentWaveNumber = _waves.Count - 1;

            return false;
        }

        _currentWaveNumber = number;
        _currentWave = _waves[_currentWaveNumber];
        SetObjectToSpawn( _currentWave.SpawnObject );

        return true;
    }

    public bool NextWave() => TrySetWave(_currentWaveNumber + 1);

}
