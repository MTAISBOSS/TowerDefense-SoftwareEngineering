## Architecture
- Define project architecture and dependency direction @MTAISBOSS
- Create base folder structure and namespaces @MTAISBOSS
- Write architecture documentation (`ARCHITECTURE.md`) @MTAISBOSS
- Define coding conventions and code style rules @MTAISBOSS

## Core Game Flow
- Implement `GameManager` @MTAISBOSS
- Implement `GameStateMachine` @MTAISBOSS
- Define core game states (Main Menu, Playing, Paused, Wave In Progress, Victory, Defeat) @MTAISBOSS
- Implement major gameplay events (`GameStarted`, `WaveStarted`, `WaveCompleted`, `EnemyReachedBase`, `BaseDestroyed`, `TowerPlaced`) @MTAISBOSS
- Implement `SceneBootstrapper` @MTAISBOSS
- Connect pause and resume flow to the state system @MTAISBOSS

## Data Architecture
- Design shared ScriptableObject data model (`EnemyData`, `TowerData`, `ProjectileData`, `WaveData`) @MTAISBOSS
- Separate static config from runtime state @MTAISBOSS
- Create initial enemy data assets @yektasharifpour
- Create initial tower data assets @yektasharifpour
- Create initial wave data assets @yektasharifpour
- Connect data assets to prefabs @yektasharifpour

## Object Pooling
- Implement generic `ObjectPool<T>` foundation @MTAISBOSS
- Implement `PoolableObject` base behavior @MTAISBOSS
- Implement `PoolManager` @MTAISBOSS
- Integrate enemy pooling hooks @sanyamasoudi
- Integrate projectile pooling hooks @sanyamasoudi
- Create simple pooled VFX prefabs if needed @yektasharifpour

## Scene Setup
- Create playable test scene layout @sanyamasoudi
- Set up enemy path waypoints @sanyamasoudi
- Place tower build spots in the scene @sanyamasoudi
- Set up base position @sanyamasoudi
- Set up camera and lighting @sanyamasoudi
- Create placeholder environment and gameplay prefabs @yektasharifpour

## Base System
- Implement `BaseHealth` @sanyamasoudi
- Implement base damage receiving logic @sanyamasoudi
- Notify `GameManager` on base destruction @sanyamasoudi
- Create base HUD display for HP @yektasharifpour

## Enemy System
- Implement enemy movement along path @sanyamasoudi
- Implement `EnemyPathFollower` @sanyamasoudi
- Implement enemy health system @sanyamasoudi
- Implement enemy death behavior @sanyamasoudi
- Implement enemy reach-base behavior @sanyamasoudi
- Connect enemies to object pool @sanyamasoudi
- Create `Enemy_Normal.prefab` @yektasharifpour
- Create `Enemy_Fast.prefab` @yektasharifpour
- Create `Enemy_Heavy.prefab` @yektasharifpour
- Add colliders, renderers, and required enemy components to prefabs @yektasharifpour