using UnityEngine;

public class LivingActor : MonoBehaviour
{
    private void Start()
    {
        IgnoreOwnLayerCollisions();
    }

    private void Update()
    {
        
    }

    private void IgnoreOwnLayerCollisions()
    {
        const int RaycastLayer = 2;

        if (Physics.GetIgnoreLayerCollision(RaycastLayer, RaycastLayer) == false)
            Physics.IgnoreLayerCollision(RaycastLayer, RaycastLayer,true);

    }
}
