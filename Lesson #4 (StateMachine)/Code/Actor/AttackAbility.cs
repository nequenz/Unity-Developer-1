using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAbility : MonoBehaviour
{
	[SerializeField] Bullet _currentBullet;
    [SerializeField] private float _maxDelayAttack = 2.5f;
    private float _delayAttack = 0f;
    private Transform _target;

    public bool IsTargetExist() => _target != null;

    public void SelectTarget( Transform transform ) => _target = transform;

	public void Attack()
	{
		if (_delayAttack <= 0.0f && _target != null)
		{
			CreateBullet();
			_delayAttack = _maxDelayAttack;
		}
	}

	private void Update()
	{
		if (_delayAttack > 0.0f)
			_delayAttack -= Time.deltaTime;
	}

	private void CreateBullet()
	{
		Bullet bullet = Instantiate(_currentBullet,transform.position, Quaternion.identity);

		bullet.SetAttacker(this);
		bullet.SetTarget(_target);
	}

	public bool TryGetTargetHealth(out Health health)
    {
		health = null;

		return (_target != null && _target.TryGetComponent(out health));
	}

}
