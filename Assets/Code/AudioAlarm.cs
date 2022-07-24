using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent( typeof (AudioSource) ) ]
public class AudioAlarm : MonoBehaviour
{
    private const float VolumePerStep = 0.01f;

    private AudioSource _audioSource;
    private Coroutine _signalCoroutine;
    private WaitForSeconds _secondsWaiter;
    private float _volumeTarget = 1f;

    private void Awake()
    {
        const float StartVolume = 0.01f;
        const float WaitSeconds = .5f;

        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = StartVolume;
        _secondsWaiter = new WaitForSeconds( WaitSeconds );
    }

    private void SignalWithSmoothVolume(float volumeTarget)
    {
        if (_signalCoroutine != null)
        {
            StopCoroutine(_signalCoroutine);
        }

        _volumeTarget = Mathf.Clamp(volumeTarget, 0f, 1f);
        _signalCoroutine = StartCoroutine(TuneSignalVolumeCoroutine());
    }

    private IEnumerator TuneSignalVolumeCoroutine()
    {
        while (_audioSource.volume > 0f && _audioSource.volume < 1f)
        {
            if (_audioSource.isPlaying == false)
            {
                _audioSource.Play();
            }

            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _volumeTarget, VolumePerStep);

            yield return _secondsWaiter;
        }
    }

    public void Play() => SignalWithSmoothVolume(1f);

    public void Finish() => SignalWithSmoothVolume(-1f);
}
