using UnityEngine;

public class CameraAdjuster : MonoBehaviour
{
    private SpriteRenderer templateSprite; 
    private Camera Camera;

    //private void Start()
    //{

    //    AdjustCameraToBackground();
    //}

    [ContextMenu("Set camera's size")]
    public void AdjustCameraToBackground()
    {
        Camera = Camera.main;
        templateSprite = Resources.Load<GameObject>("TemplateSprite").GetComponent<SpriteRenderer>();

        float spriteHeight = templateSprite.bounds.size.y;
        Camera.orthographicSize = spriteHeight / 2;
         
        Camera.transform.position = new Vector3(templateSprite.transform.position.x,
                    templateSprite.transform.position.y, Camera.transform.position.z); 
    }
}
