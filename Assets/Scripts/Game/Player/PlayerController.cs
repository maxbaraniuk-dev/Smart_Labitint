using Events;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 1f;
        [SerializeField] private ParticleSystem finishAnimation;
        private Rigidbody2D _character;
        private SpriteRenderer _spriteRenderer;
        private Vector2 _moveInput;
        private InputAction _moveAction;
        private Vector3 _playerPosition;
        private float _passedDistance;

        private void Awake()
        {
            _character = GetComponent<Rigidbody2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _moveAction = InputSystem.actions.FindAction("Move");
            _playerPosition = transform.position;
        }

        private void FixedUpdate()
        {
            Vector2 moveValue = _moveAction.ReadValue<Vector2>();
            _character.linearVelocity = moveValue * moveSpeed;
            
            if (moveValue.x != 0 ) 
                _spriteRenderer.flipX = moveValue.x > 0;
            
            var distance = Vector3.Distance(_playerPosition, transform.position);
            if (!(distance >= 0.1f)) 
                return;
            
            _passedDistance += distance;
            EventsMap.Dispatch(GameEvents.OnPlayerDistanceUpdated, _passedDistance);
            _playerPosition = transform.position;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Finish"))
                EventsMap.Dispatch(GameEvents.OnTargetReached);
        }
        
        public float GetPassedDistance() => _passedDistance;

        public void PlayFinishAnimation()
        {
            finishAnimation.Play();
        }
    }
}