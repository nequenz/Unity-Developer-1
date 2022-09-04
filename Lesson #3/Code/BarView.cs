using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Slider))]
public class BarView : MonoBehaviour
{
    private Slider _sliderView;
    private float _value = 0f;
    private float _changeSpeed = 5f;

    private void Awake()
    {
        _sliderView = GetComponent<Slider>();
    }

    private void Start()
    {
        _value = _sliderView.value;
    }

    private void Update()
    {
        const float DifferenceFactor = 0.1f;

        if ( Mathf.Abs( _value - _sliderView.value ) > DifferenceFactor )
        {
            _value = Mathf.Clamp(_value, _sliderView.minValue, _sliderView.maxValue);
            _sliderView.value = Mathf.Lerp(_sliderView.value, _value, Time.deltaTime * _changeSpeed);
        }
    }

    public void SetMaxValue( float maxValue ) => _sliderView.maxValue = maxValue;

    public void SetMinValue( float minValue ) => _sliderView.minValue = minValue;

    public void SetValue( float value ) => _value = value;

    public void TakeValue( float value )  => _value += value;
}
