using UnityEngine.UI;
using UnityEngine;
using System;

[RequireComponent(typeof(Slider))]
public class BarView : MonoBehaviour
{
    private Slider _sliderView;
    private float _value = 0f;
    private float _changeSpeed = 5f;
    [SerializeField] private Health _health;

    private void Awake()
    {
        _sliderView = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        if(_health)
        {
            InitValues();
            _health.OnHealthChanged += OnHealthChanged;
        }
    }

    private void OnDisable()
    {
        if (_health)
        {
            _health.OnHealthChanged -= OnHealthChanged;
        }
    }

    private void Update()
    {
        AnimateBar();
    }

    private void InitValues()
    {
        const float MinHealth = 0f;

        _sliderView.maxValue = _health.MaxHealth;
        _sliderView.minValue = MinHealth;
        _sliderView.value = _health.CurrentHealth;
        _value = _health.CurrentHealth;
    }

    private void AnimateBar()
    {
        const float DifferenceFactor = 0.1f;

        if (Mathf.Abs(_value - _sliderView.value) > DifferenceFactor)
        {
            _value = Mathf.Clamp(_value, _sliderView.minValue, _sliderView.maxValue);
            _sliderView.value = Mathf.Lerp(_sliderView.value, _value, Time.deltaTime * _changeSpeed);
        }
    }

    private void OnHealthChanged(float health)
    {
        _value = health;
    }
}
