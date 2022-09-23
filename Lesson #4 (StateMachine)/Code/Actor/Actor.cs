using UnityEngine;

public class Actor : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 2.0f;

    public float MoveSpeed => _moveSpeed;

    protected virtual void Start()
    {
        IgnoreCollisionEachOther();
    }

    private void IgnoreCollisionEachOther()
    {
        const int DefaultLayer = 2;

        gameObject.layer = DefaultLayer;

        if(Physics.GetIgnoreLayerCollision(DefaultLayer,DefaultLayer) == false)
            Physics.IgnoreLayerCollision(DefaultLayer, DefaultLayer, true);
    }
}
