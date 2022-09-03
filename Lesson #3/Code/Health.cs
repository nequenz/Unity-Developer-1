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
        _barView?.SetMaxValue(_maxHealth);
        _barView?.SetMinValue(0f);
        _barView?.SetValue(_health);
    }

    public void TakeAmount( float amount )
    {
        _barView?.TakeValue( amount );
    }

}
