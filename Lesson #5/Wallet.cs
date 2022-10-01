using System;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private int _currentValue = 0;
    [SerializeField] private string _valueName = "default value wallet";

    public string ValueName => _valueName;

    public event Action ValueChanged;

    public int CurrentValue => _currentValue;

    private void Start()
    {
        ValueChanged?.Invoke();
    }

    public bool CanTransit(int value) => _currentValue - value >= 0;

    public void Transit(int value) => AddValue(-value);

    public void Transit(int value, Wallet otherWallet)
    {
        AddValue(-value);
        otherWallet.AddValue(value);
    }

    public void SetValue( int value )
    {
        _currentValue = value;
        ValueChanged?.Invoke();
    }

    public void AddValue(int value)
    {
        _currentValue += value;
        ValueChanged?.Invoke();
    }
}
