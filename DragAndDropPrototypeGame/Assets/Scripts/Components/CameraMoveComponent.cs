using Scripts.Interfaces;
using UnityEngine;

namespace Scripts.Components
{
    public class CameraMoveComponent : MonoBehaviour, IInteractable
    {
        [SerializeField] private float _speed = 5f;

        private Vector3 _lastCameraPosition;
        private Camera _camera;
        private void Start()
        {
            _camera = Camera.main;
        }

        public void OnBeginInteract(Vector2 mousePosition)
        {
            _lastCameraPosition = mousePosition;
        }

        public void OnInteract(Vector2 mousePosition)
        {
            var delta = mousePosition.x - _lastCameraPosition.x;
            var translation = new Vector3(-delta * _speed, 0, 0);

            _camera.transform.Translate(translation, Space.World);
        }

        public void OnEndInteract(Vector2 mousePosition)
        {
        }

    }
}

