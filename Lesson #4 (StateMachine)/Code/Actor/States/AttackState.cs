using UnityEngine;

[RequireComponent(typeof(AttackAbility))]
public class AttackState : State
{
	[SerializeField] private State _winStateTarget;
	[SerializeField] private Transform _target;
	private AttackAbility _attackAbility;

    protected override void Awake()
    {
		base.Awake();
		_attackAbility = GetComponent<AttackAbility>();
	}

    private void Start()
    {
		if( _target == null)
        {
			_target = FindObjectOfType<Health>().transform;
		}

		_attackAbility.SelectTarget(_target);
    }

    private void Update()
	{
		if (_attackAbility.IsTargetExist() == true 
			&& _attackAbility.TryGetTargetHealth(out Health health) 
			&& health.CurrentHealth > 0)
			_attackAbility.Attack();
		else
			ChangeState(_winStateTarget);
	}
}
