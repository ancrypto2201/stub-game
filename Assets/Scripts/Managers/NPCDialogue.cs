using UnityEngine;

/// <summary>
/// NPC dialogue system
/// Simple dialogue for non-player characters
/// </summary>
public class NPCDialogue : MonoBehaviour
{
    [Header("Dialogue Settings")]
    [TextArea(3, 10)]
    [SerializeField] private string[] dialogueLines;
    [SerializeField] private string npcName = "NPC";
    [SerializeField] private float interactionRange = 2f;
    
    private Transform player;
    private int currentLineIndex = 0;
    private bool isPlayerNearby = false;
    
    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
    }
    
    void Update()
    {
        if (player == null) return;
        
        float distance = Vector3.Distance(transform.position, player.position);
        isPlayerNearby = distance <= interactionRange;
        
        // Press E to interact
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            ShowNextDialogue();
        }
    }
    
    void ShowNextDialogue()
    {
        if (dialogueLines.Length == 0) return;
        
        Debug.Log($"{npcName}: {dialogueLines[currentLineIndex]}");
        
        currentLineIndex++;
        if (currentLineIndex >= dialogueLines.Length)
        {
            currentLineIndex = 0; // Loop back to first line
        }
    }
    
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, interactionRange);
    }
}
