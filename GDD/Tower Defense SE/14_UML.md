# UML

## 1. High-Level Class Diagram
```mermaid
classDiagram
class GameManager
class WaveManager
class ResourceManager
class UIManager
class LevelManager
class Tower
class Projectile
class Enemy
class BuildNode
class PathFollower

GameManager --> WaveManager
GameManager --> ResourceManager
GameManager --> UIManager
GameManager --> LevelManager

Tower --> Projectile
Tower --> Enemy
Enemy --> PathFollower
BuildNode --> Tower

## 2. Tower System Diagram

mermaid
classDiagram
class Tower {
+int level
+float range
+float damage
+float fireRate
+SelectTarget()
+Attack()
+Upgrade()
}

class ArrowTower
class CannonTower
class FrostTower
class SupportTower

Tower <|-- ArrowTower
Tower <|-- CannonTower
Tower <|-- FrostTower
Tower <|-- SupportTower

## 3. Enemy System Diagram

mermaid
classDiagram
class Enemy {
+float health
+float speed
+int reward
+Move()
+TakeDamage()
+Die()
}

class RunnerEnemy
class BruteEnemy
class SwarmEnemy
class BossEnemy

Enemy <|-- RunnerEnemy
Enemy <|-- BruteEnemy
Enemy <|-- SwarmEnemy
Enemy <|-- BossEnemy

## 4. Game Flow Diagram

mermaid
flowchart TD
A[Main Menu] --> B[Level Start]
B --> C[Build Phase]
C --> D[Start Wave]
D --> E[Enemies Spawn]
E --> F[Towers Attack]
F --> G{Wave Complete?}
G -- No --> E
G -- Yes --> H{All Waves Cleared?}
H -- No --> C
H -- Yes --> I[Victory]

F --> J{Base Health <= 0?}
J -- Yes --> K[Defeat]

## 5. State Diagram

mermaid
stateDiagram-v2
[*] --> MainMenu
MainMenu --> LevelLoading
LevelLoading --> BuildPhase
BuildPhase --> CombatPhase
CombatPhase --> BuildPhase
CombatPhase --> Victory
CombatPhase --> Defeat
Victory --> [*]
Defeat --> [*]

## Links
- [[12_Technical_Architecture]]
- [[13_Development_View]]


---

# 3) Tower Files

---

## `Towers/Tower_System.md`

```md
# Tower System

## System Purpose
The tower system allows players to place, manage, and upgrade defensive structures that automatically attack enemies.

## System Responsibilities
- Validate tower placement
- Track range and targeting
- Attack enemies automatically
- Upgrade stats and behavior
- Communicate with UI and economy systems

## Core Tower Attributes
- Cost
- Damage
- Range
- Fire rate
- Damage type
- Target priority
- Upgrade levels

## Tower Roles
- Single-target damage
- Area damage
- Crowd control
- Support / buff

## Proposal Reference
- Tower placement: **proposal 2.pdf, page 1, lines 5–11**
- Tower upgrades: **proposal 2.pdf, page 1, lines 7–9, 26–27**
- Different tower types: **proposal 2.pdf, page 1, line 31**
- Resource-managed building/upgrading: **proposal 2.pdf, page 1, line 33**

## Links
- [[Towers/Arrow_Tower]]
- [[Towers/Cannon_Tower]]
- [[Towers/Frost_Tower]]
- [[Towers/Support_Tower]]
- [[Systems/Placement_System]]
- [[Systems/Upgrade_System]]
- [[Systems/Combat_System]]
