## Architecture
- Define project architecture and dependency direction @mohammad.1387.kavian
- Create base folder structure and namespaces @mohammad.1387.kavian
- Write architecture documentation (`ARCHITECTURE.md`) @mohammad.1387.kavian
- Define coding conventions and code style rules @mohammad.1387.kavian

## Core Game Flow
- Implement `GameManager` @mohammad.1387.kavian
- Implement `GameStateMachine` @mohammad.1387.kavian
- Define core game states (Main Menu, Playing, Paused, Wave In Progress, Victory, Defeat) @mohammad.1387.kavian
- Implement major gameplay events (`GameStarted`, `WaveStarted`, `WaveCompleted`, `EnemyReachedBase`, `BaseDestroyed`, `TowerPlaced`) @mohammad.1387.kavian
- Implement `SceneBootstrapper` @mohammad.1387.kavian
- Connect pause and resume flow to the state system @mohammad.1387.kavian

## Data Architecture
- Design shared ScriptableObject data model (`EnemyData`, `TowerData`, `ProjectileData`, `WaveData`) @mohammad.1387.kavian
- Separate static config from runtime state @mohammad.1387.kavian
- Create initial enemy data assets @yktashr419
- Create initial tower data assets @yktashr419
- Create initial wave data assets @yktashr419
- Connect data assets to prefabs @yktashr419

## Object Pooling
- Implement generic `ObjectPool<T>` foundation @mohammad.1387.kavian
- Implement `PoolableObject` base behavior @mohammad.1387.kavian
- Implement `PoolManager` @mohammad.1387.kavian
- Integrate enemy pooling hooks @sanyamasoudi9
- Integrate projectile pooling hooks @sanyamasoudi9
- Create simple pooled VFX prefabs if needed @yktashr419

## Scene Setup
- Create playable test scene layout @sanyamasoudi9
- Set up enemy path waypoints @sanyamasoudi9
- Place tower build spots in the scene @sanyamasoudi9
- Set up base position @sanyamasoudi9
- Set up camera and lighting @sanyamasoudi9
- Create placeholder environment and gameplay prefabs @yktashr419

## Base System
- Implement `BaseHealth` @sanyamasoudi9
- Implement base damage receiving logic @sanyamasoudi9
- Notify `GameManager` on base destruction @sanyamasoudi9
- Create base HUD display for HP @yktashr419

## Enemy System
- Implement enemy movement along path @sanyamasoudi9
- Implement `EnemyPathFollower` @sanyamasoudi9
- Implement enemy health system @sanyamasoudi9
- Implement enemy death behavior @sanyamasoudi9
- Implement enemy reach-base behavior @sanyamasoudi9
- Connect enemies to object pool @sanyamasoudi9
- Create `Enemy_Normal.prefab` @yktashr419
- Create `Enemy_Fast.prefab` @yktashr419
- Create `Enemy_Heavy.prefab` @yktashr419
- Add colliders, renderers, and required enemy components to prefabs @yktashr419