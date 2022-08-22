using UnityEngine;

public struct Damage
{
    private float _damage;

    public Damage( float damage )
    {
        _damage = damage;
    }
}

[RequireComponent( typeof( Collider2D ) ) ]
public class AttackAbility : MonoBehaviour
{
    private Collider2D _collider;
    private Damage _hitDamage = new Damage(25f);
    private Vector3 _attackRay = Vector3.right;
    private float _attackTimeMax = 1f;
    private float _attackTime = 0f;

    public float CurrentAttackTime { get => _attackTime; }
    public bool IsAttacking { get => ( _attackTime > 0.0f ); }

    protected virtual void Awake()
    {
        _collider = GetComponent<Collider2D>();
    }

    protected virtual void Update()
    {
        if( _attackTime > 0f )
        {
            _attackTime -= Time.deltaTime;

            OnAttackStay();

            if( _attackTime <= 0.0f )
            {
                OnAttackEnd();
            }
        }
    }

    public void SetAttackRay( Vector3 attackRay ) => _attackRay = attackRay;

    public void CustomAttack( Vector3 attackRayEnd, Damage damage , bool isMultiAttack = false)
    {
        RaycastHit2D[] hits;

        if ( IsAttacking == false )
        {
            _attackTime = _attackTimeMax;
            OnAttackStart();

            hits = Physics2D.LinecastAll(_collider.bounds.center, _collider.bounds.center + attackRayEnd);

            if( hits == null )
            {
                return;
            }

            for(int i = 0; i < hits.Length; i++)
            {
                if( hits[i].collider != _collider )
                {
                    if( hits[i].collider.TryGetComponent(out AttackAbility otherAttackAbility) )
                    {
                        otherAttackAbility.OnTakeDamage( _hitDamage );
                    }

                    OnHit( hits[i].collider );
                    
                    if( isMultiAttack == false )
                    {
                        break;
                    }
                }
            }
        }
    }

    public void DefaultAttack( float directionNormal = 1f ) => CustomAttack( _attackRay * directionNormal, _hitDamage);

    public virtual void OnAttackStart()
    {
    }

    public virtual void OnAttackStay()
    {
    }

    public virtual void OnAttackEnd()
    {
    }

    public virtual void OnHit(Collider2D collider2D)
    {
    }

    public virtual void OnTakeDamage(Damage damage)
    {
    }
}
