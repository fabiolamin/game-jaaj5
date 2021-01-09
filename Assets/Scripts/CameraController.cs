using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float speedMovement;
    [SerializeField] Transform _camera;
    [SerializeField] Transform maxY, minY;

    Vector3 pos;

    private void Start()
    {
        _camera.position = new Vector3(_camera.position.x, PlayerManager.Instance.transform.position.y, _camera.position.z);
    }
    private void Update()
    {

        Move();

    }
    private void LateUpdate()
    {


    }

    private void Move()
    {
        pos = new Vector3(_camera.position.x, GetCameraYPosition(), _camera.position.z);
        _camera.position = Vector3.MoveTowards(_camera.position, pos, speedMovement * Time.deltaTime);
    }

    float GetCameraYPosition()
    {
        return Mathf.Clamp(PlayerManager.Instance.transform.position.y, minY.position.y, maxY.position.y);
    }
}
