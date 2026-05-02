# Development View

## Development Goals
Build a playable, understandable Unity Tower Defense game with modular systems and core genre features.

## Milestone Plan

### Milestone 1: Core Prototype
- Create map with path and build nodes
- Spawn one enemy type
- Create one basic tower
- Implement gold and health
- Implement win/lose basics

### Milestone 2: Core Systems
- Add multiple tower types
- Add multiple enemy types
- Add wave spawning system
- Add upgrade system
- Add UI for health, gold, wave, score

### Milestone 3: Progression
- Add multiple levels
- Add difficulty scaling
- Add stronger enemies and vulnerabilities
- Add balancing pass

### Milestone 4: Polish
- Better UX for placement
- VFX/SFX integration
- Better feedback
- Performance optimization
- Bug fixing

## Suggested Team Roles
- Game Designer
- Unity Programmer
- UI/UX Designer
- Technical Designer
- Artist
- Sound Designer

## Task Breakdown by System
- [[Systems/Game_State_System]]
- [[Systems/Wave_System]]
- [[Systems/Placement_System]]
- [[Systems/Upgrade_System]]
- [[Systems/Combat_System]]
- [[Systems/Resource_System]]
- [[Systems/UI_System]]

## Risks
- Poor difficulty curve
- Overcomplicated tower balancing
- Unclear player feedback
- Pathing and placement bugs
- Wave pacing problems

## Mitigations
- Keep tower count limited at first
- Test each enemy role independently
- Build debug UI for values
- Use data-driven balancing
- Playtest frequently

## Links
- [[12_Technical_Architecture]]
- [[14_UML]]
