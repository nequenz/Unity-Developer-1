using UnityEngine;

public struct WorldMousePositionInfo
{
    public Collider HittedCollider { get; private set; }
    public Vector3 Position { get; private set; }

    public WorldMousePositionInfo(Collider collider, Vector3 position)
    {
        HittedCollider = collider;
        Position = position;
    }
}

[RequireComponent(typeof(Camera))]
public class MouseRaycastInput : MonoBehaviour
{
    [SerializeField] private float AdditinalTargetZ = 0.20f;
    [SerializeField] private UnityEngine.GameObject _target;
    [SerializeField] private Camera _currentCamera;

    public WorldMousePositionInfo GetMousePositionInWorld()
    {
        Vector3 mousePosition = Vector3.zero;

        if (_currentCamera == null)
            return new WorldMousePositionInfo(null, Vector3.zero);

        if( Physics.Raycast( _currentCamera.ScreenPointToRay(Input.mousePosition), out RaycastHit raycastHit) )
        {
            mousePosition = raycastHit.point;
            mousePosition.y += AdditinalTargetZ;
        }

        return new WorldMousePositionInfo( raycastHit.collider, mousePosition );
    }
}
