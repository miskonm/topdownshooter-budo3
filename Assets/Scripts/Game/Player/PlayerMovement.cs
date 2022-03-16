using TDS.Game.Input;
using TDS.Infrastructure.Services;
using UnityEngine;

namespace TDS.Game.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private float _speed;

        private IInputService _inputService;
        private Camera _camera;

        private void Start()
        {
            _camera = Camera.main;
            _inputService = Services.Container.Get<IInputService>();
        }

        private void Update()
        {
            Move();
            Rotate();
        }

        private void Move()
        {
            _rb.velocity = _inputService.Axis.normalized * _speed;
        }

        private void Rotate()
        {
            Vector3 mousePosition = _inputService.MousePosition;
            Vector3 worldPoint = _camera.ScreenToWorldPoint(mousePosition);
            worldPoint.z = 0;

            Vector3 up = worldPoint - transform.position;
            transform.up = up;
        }
    }
}