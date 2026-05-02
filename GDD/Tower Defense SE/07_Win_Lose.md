# Win / Lose Conditions

## Win Condition
The player wins a level by surviving all enemy waves and protecting the destination.

## Lose Condition
The player loses when base health reaches zero.

## Optional Scoring
- Score from enemy kills
- Bonus for remaining health
- Bonus for efficient resource use
- Bonus for fast completion

## State Transitions
- Main Menu -> Level Start
- Level Start -> Build Phase
- Build Phase -> Combat Phase
- Combat Phase -> Victory or Defeat
- Victory -> Next Level / Results
- Defeat -> Retry / Main Menu

## Proposal Reference
- Win/lose logic and stage progression: **proposal 2.pdf, page 1, line 20**

## Links
- [[Systems/Game_State_System]]
- [[09_UI_UX]]
- [[14_UML]]
