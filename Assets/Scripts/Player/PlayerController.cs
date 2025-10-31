using UnityEngine;

/// <summary>
/// Main player controller for RPG game
/// Handles player movement, input, and basic interactions
/// </summary>
public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float runSpeedMultiplier = 1.5f;
    
    [Header("Components")]
    private Rigidbody2D rb;
    private Animator animator;
    
    private Vector2 movement;
    private bool isRunning;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    
    void Update()
    {
        // Get input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        
        // Check if running
        isRunning = Input.GetKey(KeyCode.LeftShift);
        
        // Update animator if available
        if (animator != null)
        {
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);
        }
    }
    
    void FixedUpdate()
    {
        // Move player
        float currentSpeed = isRunning ? moveSpeed * runSpeedMultiplier : moveSpeed;
        rb.MovePosition(rb.position + movement.normalized * currentSpeed * Time.fixedDeltaTime);
    }
}
