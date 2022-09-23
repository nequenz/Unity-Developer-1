using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class WinState : State
{
    [SerializeField] private float _jumpHeight = 300f;
    private Rigidbody _rigidbody;

    protected override void Awake()
    {
        base.Awake();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable() => WinJump();

    private void OnCollisionEnter(Collision collision)
    {
        if (enabled == false)
            return;

        WinJump();
    }

    private void WinJump() => _rigidbody.AddForce(Vector3.up * _jumpHeight);
}
