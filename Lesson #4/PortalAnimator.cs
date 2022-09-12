using System;
using System.Collections;
using UnityEngine;

public class PortalAnimator : MonoBehaviour
{
    private Coroutine _animateOpenCoroutine;
    private float _openedPortalSize = 0.25f;
    private bool _isOpened = false;

    public event Action OnClosed;
    public event Action OnOpened;

    protected virtual void OnEnable()
    {
        FastClose();

        Open();
    }

    protected virtual void OnOpen()
    {
    }

    protected virtual void OnClose()
    {
    }

    private IEnumerator Animate()
    {
        const float AnimateTime = 0.2f;

        float targetSize = (_isOpened) ? 0f : _openedPortalSize;
        bool isOpenedSizeReached = false;
        Vector3 currentSize;

        while(!isOpenedSizeReached)
        {
            currentSize = transform.localScale;
            currentSize.z = Mathf.MoveTowards(currentSize.z, targetSize, Time.deltaTime * AnimateTime);
            transform.localScale = currentSize;
            isOpenedSizeReached = currentSize.z >= _openedPortalSize;

            yield return null;
        }

        if (_isOpened == false)
        {
            _isOpened = true;

            OnOpen();
            OnOpened?.Invoke();
        }
        else
        {
            _isOpened = false;

            OnClosed?.Invoke();
            OnClose();
        }
            

        _animateOpenCoroutine = null;
    }

    private void StartAnimation()
    {
        if (_animateOpenCoroutine == null)
        {
            _animateOpenCoroutine = StartCoroutine(Animate());
        }
    }

    private void FastClose()
    {
        Vector3 size = transform.localScale;

        _isOpened = false;
        size.z = 0.0f;
        transform.localScale = size;

        OnClose();
    }

    public void Open()
    {
        FastClose();
        StartAnimation();
    }

    public void Close()
    {
        StartAnimation();
    }
}
