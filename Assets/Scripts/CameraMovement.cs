using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Boat _player;
    [SerializeField] private WorldArray _worldArray;
    [SerializeField] private float _leftBorder;
    [SerializeField] private float _rightBorder;

    private float _downBorder;
    private float _cameraUnitWight;
    private float _cameraUnitHeight;

    private void Start()
    {
        _downBorder = _worldArray.GetDeepWorld();
        _downBorder -= 0.5f;
        Vector2 cameraLeftPoint = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 cameraRightPoint = Camera.main.ViewportToWorldPoint(new Vector2(1, 0));
        Vector2 cameraUpPoint = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 cameraDownPoint = Camera.main.ViewportToWorldPoint(new Vector2(0, 1));
        _cameraUnitHeight = (cameraDownPoint.y - cameraUpPoint.y) / 2;
        _cameraUnitWight = (cameraRightPoint.x - cameraLeftPoint.x) / 2;
    }

    private void Update()
    {
        float cameraXposotion = _player.transform.position.x;
        float cameraYposotion = _player.transform.position.y;
        cameraXposotion = Mathf.Clamp(cameraXposotion, _leftBorder + _cameraUnitWight, _rightBorder - _cameraUnitWight);
        cameraYposotion = Mathf.Clamp(cameraYposotion, -_downBorder + _cameraUnitHeight, 0);
        transform.position = new Vector3(cameraXposotion, cameraYposotion, transform.position.z);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector3(_leftBorder, 3, 0), new Vector3(_leftBorder, -_downBorder, 0));
        Gizmos.DrawLine(new Vector3(_rightBorder, 3, 0), new Vector3(_rightBorder, -_downBorder, 0));
        Gizmos.DrawLine(new Vector3(_rightBorder, -_downBorder, 0), new Vector3(_leftBorder, -_downBorder, 0));
    }
}
