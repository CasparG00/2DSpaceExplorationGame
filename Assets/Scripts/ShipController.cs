using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerInput))]
public class ShipController : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInput PlayerInput => playerInput ??= GetComponent<PlayerInput>();
    private InputAction accelerate;
    
    private Rigidbody2D rb;
    private Rigidbody2D Rb => rb ??= GetComponent<Rigidbody2D>();

    [SerializeField] private Camera shipCamera;
    [SerializeField] private float acceleration = 2f;
    
    [SerializeField] private float fuelBurnRate = 1f;
    [SerializeField] private float maxFuel = 100;
    
    private float fuel;
    public float FuelPercentage => fuel / maxFuel;

    private void Start()
    {
        accelerate = PlayerInput.actions.FindAction("Accelerate");
        fuel = maxFuel;
    }

    private void FixedUpdate()
    {
        if (fuel <= 0f) return;
        
        var input = Mouse.current.position.ReadValue();
        var mousePos = shipCamera.ScreenToWorldPoint(input);
        var dir = mousePos - transform.position;
        var angle = Vector2.SignedAngle(Vector2.right, dir);

        Rb.rotation = angle;
        
        if (accelerate.IsPressed())
        {
            Rb.AddForce(transform.right * acceleration);
            fuel -= fuelBurnRate * Time.fixedDeltaTime;
        }
    }
}
