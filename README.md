# Unity RPG Game Project

A basic Unity RPG game project structure with core systems and components.

## Project Structure

```
stub-game/
├── Assets/
│   ├── Scenes/              # Game scenes
│   │   └── MainScene.unity  # Main game scene
│   ├── Scripts/             # C# scripts
│   │   ├── Player/          # Player-related scripts
│   │   │   ├── PlayerController.cs    # Player movement and input
│   │   │   └── CharacterStats.cs      # Character stats (HP, MP, etc.)
│   │   ├── Enemy/           # Enemy AI and behavior
│   │   │   └── EnemyAI.cs             # Basic enemy AI
│   │   ├── Combat/          # Combat system
│   │   │   └── CombatSystem.cs        # Damage calculation and combat
│   │   ├── Inventory/       # Inventory system
│   │   │   └── InventorySystem.cs     # Item management
│   │   ├── Items/           # Item definitions
│   │   │   ├── Item.cs                # Base item class
│   │   │   └── Potion.cs              # Consumable items
│   │   ├── Managers/        # Game managers
│   │   │   ├── GameManager.cs         # Main game manager
│   │   │   └── Quest.cs               # Quest system
│   │   └── UI/              # UI scripts
│   │       └── HealthManaUI.cs        # Health/Mana display
│   ├── Prefabs/             # Reusable game objects
│   ├── Materials/           # Materials and shaders
│   ├── Textures/            # Sprites and textures
│   ├── Audio/               # Sound effects and music
│   └── UI/                  # UI assets
├── ProjectSettings/         # Unity project settings
│   ├── ProjectSettings.asset
│   ├── TagManager.asset
│   └── InputManager.asset
├── .gitignore              # Git ignore file
└── README.md               # This file
```

## Core Systems

### 1. Player System
- **PlayerController.cs**: Handles player movement using WASD/Arrow keys
  - Basic movement with walk/run (hold Shift)
  - Animator integration for character animations
  - Rigidbody2D-based physics movement

- **CharacterStats.cs**: Manages character statistics
  - Health, Mana, Attack, Defense, Magic Power
  - Level and experience system
  - Heal, damage, and level-up mechanics

### 2. Enemy System
- **EnemyAI.cs**: Basic enemy artificial intelligence
  - State machine (Idle, Patrol, Chase, Attack)
  - Detection and attack range
  - Automatic player detection and pursuit

### 3. Combat System
- **CombatSystem.cs**: Combat calculations and logic
  - Damage calculation with attack and defense
  - Hit chance and critical hit mechanics
  - Singleton pattern for global access

### 4. Inventory System
- **InventorySystem.cs**: Item management
  - Add/remove items
  - Stack system for multiple items
  - Item usage interface

- **Item.cs**: Base class for all items
  - ScriptableObject-based item system
  - Item types: Consumable, Weapon, Armor, Quest, Misc

- **Potion.cs**: Consumable items
  - Health and mana restoration
  - Automatic player stat modification

### 5. Quest System
- **Quest.cs**: Quest tracking and rewards
  - Quest goals and progress tracking
  - Experience and item rewards
  - Automatic completion detection

### 6. UI System
- **HealthManaUI.cs**: Display player stats
  - Health and mana bars
  - Text display for current/max values
  - Automatic player tracking

### 7. Game Manager
- **GameManager.cs**: Core game management
  - Pause/unpause functionality (ESC key)
  - Scene management
  - Singleton pattern

## Getting Started

### Prerequisites
- Unity 2019.4 LTS or later
- Basic knowledge of C# and Unity

### Setup Instructions
1. Clone this repository
2. Open the project in Unity
3. Open the `MainScene` in `Assets/Scenes/`
4. Create your player GameObject and attach:
   - `PlayerController`
   - `CharacterStats`
   - `InventorySystem`
   - `Rigidbody2D` component
5. Create enemy GameObjects and attach:
   - `EnemyAI`
   - `CharacterStats`
6. Tag your player GameObject as "Player"
7. Tag your enemies as "Enemy"

### Controls
- **WASD / Arrow Keys**: Move character
- **Left Shift**: Run (hold while moving)
- **ESC**: Pause/Unpause game

## Creating Items

To create new items:
1. Right-click in Project window
2. Select `Create > RPG > Item` (or `Create > RPG > Items > Potion`)
3. Configure item properties in Inspector
4. Add to inventory via script: `inventory.AddItem(itemReference);`

## Creating Quests

To create new quests:
1. Right-click in Project window
2. Select `Create > RPG > Quest`
3. Configure quest name, description, goals, and rewards
4. Assign to quest manager or NPC

## Extending the Project

### Adding New Item Types
1. Create a new class inheriting from `Item`
2. Override the `Use()` method
3. Add custom properties for your item type

### Adding New Enemy Behaviors
1. Extend `EnemyAI` class
2. Add new states to the state machine
3. Implement custom attack patterns

### Adding Skills/Abilities
1. Create a new `Skill` ScriptableObject class
2. Add mana cost and effects
3. Integrate with `CharacterStats` for skill usage

## Unity Tags Required
- **Player**: For player GameObject
- **Enemy**: For enemy GameObjects
- **NPC**: For non-player characters
- **Item**: For item pickups
- **Weapon**: For weapon items
- **Potion**: For potion items

## Unity Layers
- **Layer 8**: Player
- **Layer 9**: Enemy
- **Layer 10**: Ground
- **Layer 11**: Interactable

## License
This is a basic template project for educational purposes.

## Contributing
Feel free to fork and extend this project with additional features!

## Future Enhancements
- [ ] Dialogue system
- [ ] Save/Load system
- [ ] More enemy types with varied AI
- [ ] Equipment system
- [ ] Skill tree
- [ ] Multiplayer support
- [ ] Sound and music integration
- [ ] Advanced UI with menus
- [ ] Minimap system
- [ ] Achievement system
