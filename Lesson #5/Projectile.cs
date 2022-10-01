using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _damage = 0.0f;
    [SerializeField] private float _speed = 10.0f;
    [SerializeField] private Vector3 _point;
    [SerializeField] private Actor _attacker;

    protected virtual void Update()
    {
        const float distanceToReach = 0.5f;

        transform.position = Vector3.MoveTowards(transform.position, _point, _speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, _point) <= distanceToReach)
            Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if( collision.collider.TryGetComponent(out Actor actor) && actor != _attacker )
        {
            Destroy(gameObject);
        }
    }

    public void SetAttacker( Actor attaker ) => _attacker = attaker;

    public void SetTarget(Vector3 point) => _point = point;
}
