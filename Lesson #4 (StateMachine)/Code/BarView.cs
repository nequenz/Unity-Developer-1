using UnityEngine.UI;
using UnityEngine;
using System;
using System.Collections;

[RequireComponent(typeof(Slider))]
public class BarView : MonoBehaviour
{
    private Coroutine _animateBarCoroutine;
    private Slider _sliderView;
    private float _target = 0f;
    private float _changeSpeed = 5f;
    [SerializeField] private Health _health;

    private void Awake()
    {
        _sliderView = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        if (_health)
        {
            InitValues();
            _health.HealthChanged += OnHealthChanged;
        }
    }

    private void OnDisable()
    {
        if (_health)
        {
            _health.HealthChanged -= OnHealthChanged;
        }
    }

    private void InitValues()
    {
        const float MinHealth = 0f;

        _sliderView.maxValue = _health.MaxHealth;
        _sliderView.minValue = MinHealth;
        _sliderView.value = _health.CurrentHealth;
        _target = _health.CurrentHealth;
    }

    private IEnumerator AnimateBar()
    {
        const float DifferenceFactor = 0.1f;

        bool isTargetReached = true;

        while (isTargetReached)
        {
            isTargetReached = Mathf.Abs(_target - _sliderView.value) > DifferenceFactor;
            _target = Mathf.Clamp(_target, _sliderView.minValue, _sliderView.maxValue);
            _sliderView.value = Mathf.Lerp(_sliderView.value, _target, Time.deltaTime * _changeSpeed);

            yield return null;
        }

        _animateBarCoroutine = null;
    }

    private void OnHealthChanged(float health)
    {
        _target = health;

        if (_animateBarCoroutine == null)
        {
            _animateBarCoroutine = StartCoroutine(AnimateBar());
        }
    }
}