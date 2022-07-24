using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent( typeof ( AudioSource ) )]
[RequireComponent( typeof( Collider ) )]
public class TriggerZone : MonoBehaviour
{
    private const float VolumePerStep = 0.01f;

    private AudioSource _audioSource;
    private float _volumeTarget = 1f;

    private void Awake()
    {
        const float StartVolume = 0.01f;

        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = StartVolume;
    }

    private void OnTriggerEnter( Collider other )
    {
        if( other.TryGetComponent(out RogueBehavior rogueBehavior) == true )
        {
            rogueBehavior.OnEnterAntiRogueZone();

            StartSignalCoroutine(1f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out RogueBehavior rogueBehavior) == true)
        {
            rogueBehavior.OnLeaveAntiRogueZone();

            StartSignalCoroutine(-1f);
        }
    }

    private void StartSignalCoroutine(float volumeTarget)
    {
        StopCoroutine( TuneSignalVolumeCoroutine() );

        _volumeTarget = Mathf.Clamp(volumeTarget, 0f, 1f);

        StartCoroutine( TuneSignalVolumeCoroutine() );  
    }

    private IEnumerator TuneSignalVolumeCoroutine()
    {
        const float WaitSeconds = 0.5f;

        while( _audioSource.volume > 0f && _audioSource.volume < 1f )
        {
            if( _audioSource.isPlaying == false )
            {
                _audioSource.Play();
            }

            _audioSource.volume = Mathf.MoveTowards( _audioSource.volume, _volumeTarget, VolumePerStep );

            yield return new WaitForSeconds( WaitSeconds );
        }
    }
}
