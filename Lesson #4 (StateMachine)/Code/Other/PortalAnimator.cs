using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PortalAnimator : MonoBehaviour
{
    [SerializeField] private UnityEvent _onClosed;
    [SerializeField] private UnityEvent _onOpened;
    private Coroutine _animateCoroutine;
    private float _startHeight;
    private float _currentHeight;
    private bool _isOpened = false;

    protected virtual void Awake()
    {
        _startHeight = transform.localScale.y;
    }

    protected virtual void Start()
    {
        FastClose();
        Open();
    }

    private IEnumerator Animate()
    {
        const float AdditinalHeight = 0.1f;

        float target = (_isOpened == false) ? (_startHeight + AdditinalHeight) : -AdditinalHeight;
        float _animationSpeed = 0.75f;
        Vector3 size = transform.localScale;

        while( _currentHeight <= _startHeight && _currentHeight >= 0 )
        {
            _currentHeight = Mathf.MoveTowards(_currentHeight,target, _animationSpeed * Time.deltaTime);
            size.y = _currentHeight;
            transform.localScale = size;

            yield return null;
        }

        if (_isOpened == false)
            _onOpened?.Invoke();
        else
            _onClosed?.Invoke();

        _isOpened = !_isOpened;
        _animateCoroutine = null;
    }

    private void StartAnimate()
    {
        if (_animateCoroutine == null)
            _animateCoroutine = StartCoroutine(Animate());
    }

    protected void FastClose()
    {
        Vector3 scale = transform.localScale;

        _isOpened = false;
        scale.y = 0f;
        transform.localScale = scale;
        _onClosed?.Invoke();
    }

    public void Open() => StartAnimate();

    public void Close() => StartAnimate();

}
