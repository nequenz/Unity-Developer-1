using UnityEngine;

public class Health : MonoBehaviour
{
    private float _health;
    [SerializeField] private float _maxHealth;
    [SerializeField] private BarView _barView;

    public void Start()
    {
        _health = _maxHealth;
        InitBarView();
    }

    private void InitBarView()
    {
        const float MinValue = 0f;

        _barView?.SetMaxValue(_maxHealth);
        _barView?.SetMinValue(MinValue);
        _barView?.UpdateValue(_health);
    }

    private void TakeAmount(float amount)
    {
        const float MinHealth = 0f;

        _health = Mathf.Clamp(_health + amount, MinHealth,_maxHealth);
        _barView?.UpdateValue(_health);
    }


    public void Restore(float restoreAmount) => TakeAmount(restoreAmount);

    public void Damage(float damageAmount) => TakeAmount(damageAmount * -1);
}
