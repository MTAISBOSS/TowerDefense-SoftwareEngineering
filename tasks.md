## Wave System
- Design `WaveManager` API and sequencing flow @MTAISBOSS
- Implement asynchronous wave spawning with pause/resume/cancel support @MTAISBOSS
- Implement `WaveProgressTracker` @MTAISBOSS
- Implement `IEnemySpawner` and `EnemySpawner` contract @MTAISBOSS
- Connect wave events to game flow @MTAISBOSS
- Integrate enemy spawning into scene gameplay @sanyamasoudi
- Author playable wave data assets for test progression @yektasharifpour

## Tower Placement
- Implement `TowerPlacementManager` @sanyamasoudi
- Implement `TowerBuildSpot` validation @sanyamasoudi
- Implement tower cost deduction on build @sanyamasoudi
- Prevent multiple towers on the same spot @sanyamasoudi
- Implement optional tower preview system @sanyamasoudi
- Create build spot prefab/setup helpers @yektasharifpour
- Create basic tower selection UI buttons @yektasharifpour

## Tower Combat
- Design `IAttackStrategy` abstraction @MTAISBOSS
- Implement `SingleTargetAttackStrategy` @MTAISBOSS
- Implement `SplashAttackStrategy` @MTAISBOSS
- Implement `SlowAttackStrategy` @MTAISBOSS
- Implement tower target detection @sanyamasoudi
- Implement tower fire rate timing @sanyamasoudi
- Connect towers to attack strategies @sanyamasoudi
- Connect towers to `TowerData` @sanyamasoudi
- Create `Tower_SingleTarget.prefab` @yektasharifpour
- Create `Tower_Splash.prefab` @yektasharifpour
- Create `Tower_Slow.prefab` @yektasharifpour
- Add colliders, visuals, and required tower components to prefabs @yektasharifpour

## Projectile System
- Implement projectile movement @sanyamasoudi
- Implement projectile hit detection @sanyamasoudi
- Implement projectile damage/effect delivery @sanyamasoudi
- Return projectile to pool on hit or timeout @sanyamasoudi
- Ensure projectile reset works correctly on reuse @sanyamasoudi
- Create `Projectile_Basic.prefab` @yektasharifpour
- Add projectile visuals and collider setup @yektasharifpour

## Upgrade System
- Design `ITowerStats` abstraction @MTAISBOSS
- Implement `BaseTowerStats` @MTAISBOSS
- Implement `DamageUpgradeDecorator` @MTAISBOSS
- Implement `RangeUpgradeDecorator` @MTAISBOSS
- Implement `FireRateUpgradeDecorator` @MTAISBOSS
- Implement optional slow-strength decorator @MTAISBOSS
- Integrate upgrade application into tower runtime @sanyamasoudi
- Add upgrade UI hooks if included in scope @yektasharifpour

## UI
- Create basic HUD layout @yektasharifpour
- Display currency text @yektasharifpour
- Display base HP text @yektasharifpour
- Display current wave number @yektasharifpour
- Add tower selection buttons @yektasharifpour
- Add start wave button @yektasharifpour
- Add pause button @yektasharifpour
- Add victory panel @yektasharifpour
- Add defeat panel @yektasharifpour
- Connect UI to gameplay events @yektasharifpour

## Audio and VFX
- Add tower shooting feedback @yektasharifpour
- Add projectile hit effect @yektasharifpour
- Add enemy death effect @yektasharifpour
- Add base damage feedback @yektasharifpour
- Add simple sound effects if available @yektasharifpour

## Testing
- Write unit tests for wave sequencing logic @MTAISBOSS
- Write unit tests for pool reset behavior @MTAISBOSS
- Write unit tests for upgrade decorator logic @MTAISBOSS
- Create Play Mode test scene for gameplay verification @sanyamasoudi
- Test enemy spawn behavior @yektasharifpour
- Test tower placement flow @yektasharifpour
- Test base damage flow @yektasharifpour
- Report bugs with reproduction steps @yektasharifpour

## Documentation
- Write `README.md` setup instructions @yektasharifpour
- Document controls and how to run the project @yektasharifpour
- Add project screenshots @yektasharifpour
- Maintain task checklist support @yektasharifpour
- Write technical notes for architecture decisions @MTAISBOSS
- Review pull requests and suggest refactors @MTAISBOSS

## CI / Workflow
- Define Git workflow and branch rules @MTAISBOSS
- Set up CI pipeline for tests/build validation @MTAISBOSS
- Review feature branches before merge @MTAISBOSS
- Prepare stable integration flow for final build @MTAISBOSS
