using UnityEngine;

/// <summary>
/// Base enemy AI controller
/// Handles enemy behavior, patrol, chase, and attack
/// </summary>
public class EnemyAI : MonoBehaviour
{
    [Header("AI Settings")]
    [SerializeField] private float detectionRange = 5f;
    [SerializeField] private float attackRange = 1.5f;
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float patrolRadius = 5f;
    
    [Header("Components")]
    private Transform player;
    private CharacterStats stats;
    private Vector3 startPosition;
    
    private enum EnemyState { Idle, Patrol, Chase, Attack }
    private EnemyState currentState = EnemyState.Idle;
    
    void Start()
    {
        stats = GetComponent<CharacterStats>();
        startPosition = transform.position;
        
        // Find player in scene
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
    }
    
    void Update()
    {
        if (player == null) return;
        
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        
        switch (currentState)
        {
            case EnemyState.Idle:
                if (distanceToPlayer <= detectionRange)
                {
                    currentState = EnemyState.Chase;
                }
                break;
                
            case EnemyState.Chase:
                if (distanceToPlayer <= attackRange)
                {
                    currentState = EnemyState.Attack;
                }
                else if (distanceToPlayer > detectionRange)
                {
                    currentState = EnemyState.Idle;
                }
                else
                {
                    ChasePlayer();
                }
                break;
                
            case EnemyState.Attack:
                if (distanceToPlayer > attackRange)
                {
                    currentState = EnemyState.Chase;
                }
                else
                {
                    AttackPlayer();
                }
                break;
        }
    }
    
    private void ChasePlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;
    }
    
    private void AttackPlayer()
    {
        // Simple attack logic
        // In a real game, you'd use an attack cooldown timer
        Debug.Log($"{gameObject.name} attacking player!");
    }
    
    void OnDrawGizmosSelected()
    {
        // Visualize detection and attack ranges
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
        
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
