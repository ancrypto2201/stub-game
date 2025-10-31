# Quick Start Guide - Unity RPG Project

## Getting Your Game Running in 5 Minutes

### Step 1: Open the Project
1. Open Unity Hub
2. Click "Add" and select this project folder
3. Open the project with Unity 2019.4 or later

### Step 2: Create the Player
1. In Unity, go to `GameObject > 2D Object > Sprite`
2. Rename it to "Player"
3. Add Tag "Player" to it (Inspector > Tag > Add Tag > "Player")
4. Add Components:
   - `Rigidbody2D` (set Gravity Scale to 0 for top-down movement)
   - `Box Collider 2D`
   - `PlayerController` script
   - `CharacterStats` script
   - `InventorySystem` script

### Step 3: Create an Enemy
1. Create another Sprite GameObject
2. Rename to "Enemy"
3. Add Tag "Enemy"
4. Add Components:
   - `Rigidbody2D` (Gravity Scale = 0)
   - `Box Collider 2D`
   - `EnemyAI` script
   - `CharacterStats` script
5. Configure detection range in Inspector

### Step 4: Create the Camera Setup
1. Select Main Camera
2. Add `CameraFollow` script
3. It will automatically find and follow the player

### Step 5: Create UI (Optional)
1. `GameObject > UI > Canvas`
2. `GameObject > UI > Slider` (for Health Bar)
3. `GameObject > UI > Slider` (for Mana Bar)
4. Create an empty GameObject, add `HealthManaUI` script
5. Assign the sliders in Inspector

### Step 6: Add Game Manager
1. Create Empty GameObject called "GameManager"
2. Add `GameManager` script
3. Add `CombatSystem` script
4. Add `SaveSystem` script

### Step 7: Test Your Game
1. Press Play button in Unity
2. Use WASD to move the player
3. Enemy should detect and chase you when close
4. Press ESC to pause

## Creating Your First Item

### Health Potion Example
1. Right-click in Project window
2. `Create > RPG > Items > Potion`
3. Name it "Health Potion"
4. Set properties:
   - Item Name: "Health Potion"
   - Description: "Restores 50 HP"
   - Health Restore: 50
   - Max Stack Size: 10

### Adding Item to Scene
1. Create a Sprite GameObject for the item
2. Add `ItemPickup` script
3. Assign your Health Potion to the Item field
4. Player will auto-pickup when near (or press F)

## Creating Your First Quest

1. Right-click in Project window
2. `Create > RPG > Quest`
3. Configure:
   - Quest Name: "Kill 5 Enemies"
   - Description: "Defeat 5 enemies in the area"
   - Goals: Add goal with required amount = 5
   - Experience Reward: 100

## Common Controls Summary

| Key | Action |
|-----|--------|
| W/A/S/D or Arrow Keys | Move |
| Left Shift | Run |
| ESC | Pause/Unpause |
| E | Interact with NPC |
| F | Pick up items |

## Troubleshooting

**Player not moving?**
- Check Rigidbody2D is added
- Verify Gravity Scale is 0 for top-down
- Check collision layers

**Enemy not chasing?**
- Verify Player tag is set
- Check detection range is large enough
- Make sure enemy has Rigidbody2D

**Camera not following?**
- Check CameraFollow script is attached to Main Camera
- Verify player tag is "Player"

## Next Steps

1. **Add Graphics**: Replace default sprites with your artwork
2. **Add Animations**: Create Animator Controller with walk/idle/attack animations
3. **Design Levels**: Build out your game world with tilemaps
4. **Add Sound**: Import audio files and use AudioSource components
5. **Create More Content**: More enemies, items, quests
6. **Polish**: Particle effects, UI improvements, transitions

## Resources

- Read `README.md` for full documentation
- Check `DEVELOPMENT_GUIDE.md` for advanced topics
- See `README_VI.md` for Vietnamese documentation

## Need Help?

Common issues and solutions are documented in `DEVELOPMENT_GUIDE.md` under "Common Issues and Solutions" section.

Happy game developing! 🎮
