using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent( typeof (AudioSource) ) ]
public class AudioAlarm : MonoBehaviour
{
    private const float VolumePerStep = 0.01f;

    private AudioSource _audioSource;
    private Coroutine _signalCoroutine;
    private float _volumeTarget = 1f;
    private float _waitSeconds = .5f;

    private void Awake()
    {
        const float StartVolume = 0.01f;

        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = StartVolume;
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
        WaitForSeconds _seconds = new WaitForSeconds( _waitSeconds );
        
        while (_audioSource.volume > 0f && _audioSource.volume < 1f)
        {
            if (_audioSource.isPlaying == false)
            {
                _audioSource.Play();
            }

            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _volumeTarget, VolumePerStep);

            yield return _seconds;
        }
    }

    public void Play() => SignalWithSmoothVolume(1f);

    public void Finish() => SignalWithSmoothVolume(-1f);
}
