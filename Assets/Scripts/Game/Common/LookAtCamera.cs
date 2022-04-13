using UnityEngine;

namespace TDS.Game.Common
{
    public class LookAtCamera : MonoBehaviour
    {
        [SerializeField] private Transform _rootTransform;

        private Camera _mainCamera;
        private Vector3 _startPosition;
        private float _distance;

        private void Awake()
        {
            _startPosition = transform.localPosition;
            _distance = _startPosition.magnitude;
        }

        private void Start()
        {
            _mainCamera = Camera.main;
        }

        private void LateUpdate()
        {
            Vector3 offset = Vector3.up * _distance - _rootTransform.up * _distance;
            Vector3 newPosition = new Vector3(_startPosition.x + offset.x, _startPosition.y - offset.y, 0);
            transform.localPosition = newPosition;

            Quaternion rotation = _mainCamera.transform.rotation;
            transform.LookAt(transform.position + rotation * Vector3.back, rotation * Vector3.up);
        }

        // private void OnDrawGizmosSelected()
        // {
        //     Gizmos.color = Color.magenta;
        //     float distance = transform.localPosition.magnitude;
        //     Vector3 globalUp = Vector3.up * distance;
        //     Vector3 localUp = _rootTransform.up * distance;
        //     Gizmos.DrawRay(_rootTransform.position, globalUp);
        //     Gizmos.DrawRay(_rootTransform.position, localUp);
        //
        //     Gizmos.color = Color.cyan;
        //     Vector3 offset = globalUp - localUp;
        //     Gizmos.DrawRay(_rootTransform.position + localUp, offset);
        // }
    }
}