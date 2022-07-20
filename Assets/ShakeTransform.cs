using UnityEngine;
using UnityEngine.InputSystem;

public class ShakeTransform : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInput PlayerInput => playerInput ??= FindObjectOfType<PlayerInput>();
    private InputAction accelerate;

    [SerializeField] private float amplitude;
    [SerializeField] private float frequency;
    private Vector2 targetPosition;

    private void Start()
    {
        accelerate = PlayerInput.actions.FindAction("Accelerate");
    }
    
    private void LateUpdate()
    {
        targetPosition = accelerate.IsPressed() ? Random.insideUnitCircle * amplitude : Vector2.zero;
        
        transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, frequency * Time.deltaTime);
    }
}
