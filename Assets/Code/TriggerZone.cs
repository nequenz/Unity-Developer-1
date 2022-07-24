using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent( typeof( AudioAlarm ) )]
[RequireComponent( typeof( Collider ) )]
public class TriggerZone : MonoBehaviour
{
    private AudioAlarm _zoneAudioAlarm;

    private void Awake()
    {
        _zoneAudioAlarm = GetComponent<AudioAlarm>();
    }

    private void OnTriggerEnter( Collider other )
    {
        if( other.TryGetComponent(out Rogue rogue) )
        {
            rogue.OnEnterAntiRogueZone();
            _zoneAudioAlarm.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if ( other.TryGetComponent(out Rogue rogue) )
        {
            rogue.OnLeaveAntiRogueZone();
            _zoneAudioAlarm.Finish();
        }
    }
}
