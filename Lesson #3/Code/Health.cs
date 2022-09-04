using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    private float _health;
    [SerializeField] private float _maxHealth;

    public event Action<float> OnHealthChanhed;

    public float CurrentHealth { get => _health; }
    public float MaxHealth { get => _maxHealth; }

    public void Start()
    {
        TakeAmount(_maxHealth);
    }

    private void TakeAmount(float amount)
    {
        const float MinHealth = 0f;

        _health = Mathf.Clamp(_health + amount, MinHealth,_maxHealth);
        OnHealthChanhed?.Invoke(_health);
    }

    public void Heal(float restoreAmount) => TakeAmount(restoreAmount);

    public void Damage(float damageAmount) => TakeAmount(damageAmount * -1);
}
