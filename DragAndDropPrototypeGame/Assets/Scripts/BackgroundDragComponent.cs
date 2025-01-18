


using UnityEngine;

public class BackgroundDragComponent : MonoBehaviour, IInteractable
{
    [SerializeField] private float _speed = 5f;

    private float lastCameraPositionX;
    private float cameraXPos;
    private Camera _camera;

    public void OnBeginInteract()
    {
        //Debug.Log(lastCameraPositionX);
        _camera = Camera.main;
    }
    public void OnInteract(Vector2 mousePosition)
    {
        var direction = mousePosition.normalized;
        Debug.Log(direction);
        cameraXPos = _camera.transform.position.x + direction.x * _speed * Time.deltaTime;
        _camera.transform.position = new Vector3(cameraXPos, 0, -10);
        Debug.Log(cameraXPos);
    }
    public void OnEndInteract(Vector2 mousePosition)
    {
    }
}

