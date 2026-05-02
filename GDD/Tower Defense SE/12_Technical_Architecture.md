# Technical Architecture

## Engine
Unity

## Architecture Goals
- Modular systems
- Easy balancing
- Reusable enemy and tower components
- Support for design patterns
- Clear separation of responsibilities

## Proposed Architectural Style
Component-based Unity architecture with manager systems and data-driven configuration using ScriptableObjects.

## Main Runtime Managers
- GameManager
- WaveManager
- ResourceManager
- UIManager
- LevelManager

## Core Gameplay Components
- Tower
- TowerTargeting
- TowerAttack
- Projectile
- Enemy
- EnemyMovement
- EnemyHealth
- PathFollower
- BuildNode

## Data Objects
- TowerData
- EnemyData
- WaveData
- LevelData

## Suggested Design Patterns
- State Pattern for game states
- Factory Pattern for spawning enemies/towers
- Observer/Event Pattern for UI updates
- Strategy Pattern for targeting or attack behavior
- Object Pooling for projectiles and enemies if needed

## Proposal Reference
- Use of design patterns: **proposal 2.pdf, page 1, line 17**
- Systems for towers and enemies: **proposal 2.pdf, page 1, lines 18–19**

## Links
- [[Systems/Game_State_System]]
- [[Systems/Wave_System]]
- [[Systems/Combat_System]]
- [[14_UML]]
