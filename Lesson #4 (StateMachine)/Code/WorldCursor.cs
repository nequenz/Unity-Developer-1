using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class WorldCursor : MonoBehaviour
{
    [SerializeField] private Transform _targetAsCursor;
    private Camera _currentCamera;

    private void Awake()
    {
        const int IgnoreRaycastLayer = 2;

        _currentCamera = GetComponent<Camera>();
        _targetAsCursor.gameObject.layer = IgnoreRaycastLayer;
    }

    private void Update() => UpdateCursor();

    private void UpdateCursor()
    {
        Ray fromCameraRay = _currentCamera.ScreenPointToRay(Input.mousePosition);
        Vector3 cursorPoint;

        if ( _targetAsCursor != null && Physics.Raycast(fromCameraRay, out RaycastHit hit) )
        {
            cursorPoint = hit.point;
            cursorPoint.y += 0.1f;

            _targetAsCursor.position = cursorPoint;
        }
    }

}
