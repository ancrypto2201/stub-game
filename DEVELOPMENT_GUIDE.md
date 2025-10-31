# RPG Game Development Guide

## Overview
This document provides guidance for developing your RPG game using this project structure.

## Core Game Loop

### 1. Player Actions
- Movement and exploration
- Combat with enemies
- Item collection and usage
- Quest completion
- Character progression

### 2. Enemy Behavior
- Patrol areas
- Detect and chase player
- Attack when in range
- Drop items/rewards on defeat

### 3. Progression System
- Gain experience from combat
- Level up to increase stats
- Unlock new abilities
- Complete quests for rewards

## Script Usage Examples

### Player Setup
```csharp
// Attach to Player GameObject
public class PlayerSetup : MonoBehaviour 
{
    void Start() 
    {
        // Components are automatically added
        // PlayerController handles movement
        // CharacterStats manages HP/MP/Stats
        // InventorySystem manages items
    }
}
```

### Enemy Setup
```csharp
// Attach to Enemy GameObject
public class EnemySetup : MonoBehaviour 
{
    void Start() 
    {
        // EnemyAI handles behavior
        // CharacterStats manages HP/MP/Stats
        // Configure detection and attack ranges in Inspector
    }
}
```

### Combat Example
```csharp
// In your attack script
void AttackEnemy(GameObject enemy) 
{
    CharacterStats playerStats = GetComponent<CharacterStats>();
    CharacterStats enemyStats = enemy.GetComponent<CharacterStats>();
    
    if (CombatSystem.Instance.CheckHit()) 
    {
        CombatSystem.Instance.PerformAttack(playerStats, enemyStats);
    }
}
```

### Inventory Usage
```csharp
// Add item to inventory
InventorySystem inventory = GetComponent<InventorySystem>();
inventory.AddItem(healthPotion, 1);

// Use item from inventory
inventory.UseItem(0); // Use item in slot 0
```

### Quest Example
```csharp
// Update quest progress
Quest currentQuest; // Assign in Inspector
currentQuest.goals[0].currentAmount++;
currentQuest.CheckCompletion();
```

## Design Patterns Used

### Singleton Pattern
- `GameManager`: One instance manages game state
- `CombatSystem`: One instance handles all combat

### ScriptableObject Pattern
- `Item`: Reusable item definitions
- `Quest`: Reusable quest data
- Benefits: Data-driven design, no code changes needed for new items/quests

### Component Pattern
- Each system is a separate component
- Attach only what you need to GameObjects
- Promotes modularity and reusability

## Performance Tips

1. **Object Pooling**: For frequently spawned objects (projectiles, effects)
2. **Layer-based Collision**: Use Physics2D layers to optimize collision detection
3. **LOD System**: Reduce detail for distant objects
4. **Occlusion Culling**: Don't render what player can't see
5. **Optimize Enemy AI**: Limit update frequency for distant enemies

## Testing Checklist

### Basic Functionality
- [ ] Player moves smoothly in all directions
- [ ] Player can run with Shift key
- [ ] Enemy detects and chases player
- [ ] Enemy attacks when in range
- [ ] Damage calculation works correctly
- [ ] Health/Mana UI updates properly
- [ ] Items can be added to inventory
- [ ] Items can be used from inventory
- [ ] Level up increases stats
- [ ] Quest completion gives rewards
- [ ] Pause/unpause works

### Advanced Testing
- [ ] Multiple enemies work simultaneously
- [ ] Inventory handles full slots correctly
- [ ] Quest system tracks multiple quests
- [ ] Scene transitions work properly
- [ ] Game persists across pause

## Common Issues and Solutions

### Issue: Player not moving
**Solution**: 
- Check Rigidbody2D is attached
- Verify Input settings in ProjectSettings
- Check collision layers aren't blocking movement

### Issue: Enemy not detecting player
**Solution**:
- Verify player has "Player" tag
- Check detection range is large enough
- Ensure enemy has line of sight

### Issue: UI not updating
**Solution**:
- Verify UI references are assigned in Inspector
- Check target CharacterStats is assigned
- Ensure Canvas is properly set up

### Issue: Items not working
**Solution**:
- Verify Item ScriptableObjects are created
- Check inventory size isn't full
- Ensure item Use() method is implemented

## Recommended Unity Packages

1. **Cinemachine**: Advanced camera controls
2. **Post Processing**: Visual effects
3. **TextMesh Pro**: Better text rendering
4. **Addressables**: Asset management
5. **Input System**: New input handling

## Next Steps

1. **Art and Animation**
   - Create character sprites
   - Add animations for movement, attack, idle
   - Design UI elements

2. **Audio**
   - Background music for different areas
   - Sound effects for actions
   - Voice acting for dialogues

3. **Level Design**
   - Create multiple scenes/levels
   - Design enemy encounters
   - Place collectibles and secrets

4. **Polish**
   - Add particle effects
   - Implement screen shake
   - Create smooth transitions
   - Add tutorial system

5. **Testing and Balancing**
   - Playtest regularly
   - Balance difficulty curve
   - Fix bugs and optimize
   - Get player feedback
