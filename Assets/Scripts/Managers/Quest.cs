using UnityEngine;

/// <summary>
/// Quest data structure
/// </summary>
[CreateAssetMenu(fileName = "New Quest", menuName = "RPG/Quest")]
public class Quest : ScriptableObject
{
    public string questName;
    [TextArea(3, 10)]
    public string description;
    
    public QuestGoal[] goals;
    public int experienceReward;
    public Item[] itemRewards;
    
    public bool isCompleted;
    
    [System.Serializable]
    public class QuestGoal
    {
        public string description;
        public int requiredAmount;
        public int currentAmount;
        
        public bool IsComplete()
        {
            return currentAmount >= requiredAmount;
        }
    }
    
    public void CheckCompletion()
    {
        foreach (var goal in goals)
        {
            if (!goal.IsComplete())
            {
                return;
            }
        }
        
        CompleteQuest();
    }
    
    private void CompleteQuest()
    {
        if (!isCompleted)
        {
            isCompleted = true;
            Debug.Log($"Quest '{questName}' completed!");
            
            // Give rewards
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                CharacterStats stats = player.GetComponent<CharacterStats>();
                if (stats != null)
                {
                    stats.GainExperience(experienceReward);
                }
                
                InventorySystem inventory = player.GetComponent<InventorySystem>();
                if (inventory != null)
                {
                    foreach (var item in itemRewards)
                    {
                        inventory.AddItem(item);
                    }
                }
            }
        }
    }
}
