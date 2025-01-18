


using UnityEngine;

public class BackgroundDragComponent : MonoBehaviour, IInteractable
{
    private Camera mainCamera;
    private float lastCameraPositionX;

    private void Start()
    {
        mainCamera = Camera.main;
    }
    public void OnBeginInteract()
    {
        lastCameraPositionX = mainCamera.transform.position.x; 
        //Debug.Log(lastCameraPositionX);

    }
    public void OnInteract(Vector2 mousePosition)
    {
        //Debug.Log(mousePosition);
        float delta = mousePosition.x - lastCameraPositionX;
        mainCamera.transform.position = new Vector3(-delta  , mainCamera.transform.position.y, mainCamera.transform.position.z);
        //Debug.Log(delta);
    }
    public void OnEndInteract(Vector2 mousePosition)
    {

    }
}

