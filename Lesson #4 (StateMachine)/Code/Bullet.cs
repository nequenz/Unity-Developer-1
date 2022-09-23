using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	[SerializeField] private float _speed = 4.0f;
	[SerializeField] private float _damage = 15.0f;
	private AttackAbility _attacker;
	private Transform _target;
	
	private void Update()
	{
		const float distanceToReach = 0.1f;

		if (_target == null)
			Destroy(this);

		transform.position = Vector3.MoveTowards(transform.position,_target.position,_speed * Time.deltaTime);

		if (Vector3.Distance(transform.position, _target.position) < distanceToReach)
		{
			if( _target.TryGetComponent(out Health health) )
				health.Damage(_damage);

			Destroy(gameObject);
		}
	}

	public void SetAttacker( AttackAbility attacker ) => _attacker = attacker;

	public void SetTarget( Transform target ) => _target = target;
}
