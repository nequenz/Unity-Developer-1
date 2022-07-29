using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent( typeof( AudioAlarm ) )]
[RequireComponent( typeof( Collider ) )]
public class TriggerZone : MonoBehaviour
{
    private AudioAlarm _zoneAudioAlarm;
    [SerializeField] private UnityEvent _entered;
    [SerializeField] private UnityEvent _leaved;

    private void Awake()
    {
        _zoneAudioAlarm = GetComponent<AudioAlarm>();
    }

    private void OnTriggerEnter( Collider other )
    {
        if( other.TryGetComponent(out RogueMove rogue) )
        {
            rogue.OnEnterAntiRogueZone();
            _entered?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if ( other.TryGetComponent(out RogueMove rogue) )
        {
            rogue.OnLeaveAntiRogueZone();
            _leaved?.Invoke();
        }
    }
}
