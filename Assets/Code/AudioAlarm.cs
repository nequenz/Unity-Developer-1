using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent( typeof (AudioSource) ) ]
public class AudioAlarm : MonoBehaviour
{
    private const float VolumePerStep = 0.01f;
    private const float MinVolume = 0f;
    private const float MaxVolume = 1f;
    private const float WaitSeconds = .5f;
    private const float IncreaseVolumeTarget = 1f;
    private const float DecreaseVolumeTarget = -1f;

    private AudioSource _audioSource;
    private Coroutine _signalCoroutine;
    private float _volumeTarget = 1f;

    private void Awake()
    {
        const float StartVolume = 0.01f;
        
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = StartVolume;
    }

    private void SignalWithSmoothVolume( float volumeDirection )
    {
        if (_signalCoroutine != null)
        {
            StopCoroutine( _signalCoroutine );
        }

        _volumeTarget = Mathf.Clamp( volumeDirection, MinVolume, MaxVolume );
        _signalCoroutine = StartCoroutine( TuneSignalVolumeCoroutine() );
    }

    private IEnumerator TuneSignalVolumeCoroutine()
    {
        WaitForSeconds _secondsWaiter = new WaitForSeconds(WaitSeconds);

        while ( _audioSource.volume > MinVolume && _audioSource.volume < MaxVolume )
        {
            if ( _audioSource.isPlaying == false )
            {
                _audioSource.Play();
            }

            _audioSource.volume = Mathf.MoveTowards( _audioSource.volume, _volumeTarget, VolumePerStep );

            yield return _secondsWaiter;
        }
    }

    public void Play() => SignalWithSmoothVolume( IncreaseVolumeTarget );

    public void Finish() => SignalWithSmoothVolume( DecreaseVolumeTarget );
}
