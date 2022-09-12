using UnityEngine;

[RequireComponent(typeof(PortalAnimator))]
public class WavePortalSpawner : WaveSpawner
{
    private PortalAnimator _portalAnimator;

    private void Awake()
    {
        _portalAnimator = GetComponent<PortalAnimator>();
    }

    protected override void Start()
    {
        base.Start();
        StopSpawn();
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        if( _portalAnimator )
        {
            _portalAnimator.OnOpened += () => ResumeSpawn();
            _portalAnimator.OnClosed += () => StopSpawn();
        }
    }

    private void OnDisable()
    {
        if (_portalAnimator)
        {
            _portalAnimator.OnOpened -= () => ResumeSpawn();
            _portalAnimator.OnClosed -= () => StopSpawn();
        }
    }
}


