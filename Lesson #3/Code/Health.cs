using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private BarView _barView;
    private float _health;

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
        _barView?.SetValue(_health);
    }

    public void TakeAmount( float amount )
    {
        _barView?.TakeValue( amount );
    }
}
