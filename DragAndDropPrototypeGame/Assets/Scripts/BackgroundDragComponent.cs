


using UnityEngine;

public class BackgroundDragComponent : MonoBehaviour, IInteractable
{
    [SerializeField] private float _speed = 5f;

    private Vector3 lastCameraPosition; 
    private Camera _camera;
    private void Start()
    {
        _camera = Camera.main;

    }
    public void OnBeginInteract(Vector2 mousePosition)
    {
        lastCameraPosition = mousePosition;
    }
    public void OnInteract(Vector2 mousePosition)
    {
        var direction = mousePosition ;
        //Debug.Log(direction);
        var delta = direction.x - lastCameraPosition.x;
        //cameraXPos = _camera.transform.position.x + direction.x * _speed * Time.deltaTime;
        //_camera.transform.position = new Vector3(cameraXPos, 0, -10); 

        var newpos = new Vector3(-delta * _speed, 0, 0);
        _camera.transform.Translate(newpos, Space.World);
        lastCameraPosition = mousePosition;

    }
    public void OnEndInteract(Vector2 mousePosition)
    {
    }
}

