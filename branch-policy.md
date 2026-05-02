# Team Workflow & Branch Policy

---

## Branches

### `main`
- Stable and releasable at all times
- Protected
- No direct pushes
- Changes only enter through Pull Requests

### `develop`
- Integration branch for ongoing work
- Protected
- Used for combining completed feature work before release


### Working branches
Create short-lived branches from `develop` using one of these prefixes:

- `feature/<name>`
- `bugfix/<name>`
- `hotfix/<name>`
- `refactor/<name>`
- `docs/<name>`
- `test/<name>`
- `chore/<name>`

Examples:
```text
feature/player-movement
feature/enemy-ai
bugfix/camera-jitter
hotfix/crash-on-start
refactor/render-loop
docs/setup-guide

```
---

## Workflow

### Normal development
text
feature/* -> develop -> main

1. Create a branch from `develop`
2. Make your changes
3. Push your branch
4. Open a Pull Request into `develop`
5. After review and checks, merge into `develop`
6. When ready for release, open a Pull Request from `develop` into `main`


### Hotfixes
text
hotfix/* -> main

1. Create a `hotfix/*` branch from `main`
2. Implement the fix
3. Open a Pull Request into `main`
4. After merge, back-merge the fix into `develop`

---

## Branch Protection Rules

### `main`
The `main` branch is protected with the following rules:

- Pull Request required before merging
- 2 approvals required
- Dismiss stale approvals when new commits are pushed
- All review conversations must be resolved
- Required status checks must pass
- Force pushes are blocked
- Deletion is blocked

### `develop`
The `develop` branch is protected with the following rules:

- Pull Request required before merging
- 1 approval required
- Dismiss stale approvals when new commits are pushed
- All review conversations must be resolved
- Required status checks must pass
- Force pushes are blocked
- Deletion is blocked

---

## Pull Request Guidelines

Each Pull Request should:

- Focus on one logical change
- Have a clear and descriptive title
- Include a short summary of what changed
- Reference the related issue if applicable
- Pass all required checks before merge
- Resolve all review comments before merge

Example PR titles:

text
feat(player): add jump handling
fix(enemy): correct patrol direction logic
refactor(renderer): separate Vulkan init stage

---

## Commit Message Guidelines

Use clear commit messages.

Recommended format:

text
feat: add player movement controller
fix: resolve enemy patrol null reference
refactor: split renderer setup from game loop
docs: update local setup instructions
test: add input manager unit tests
chore: clean unused assets

Try to keep commits:
- small
- focused
- readable

---

## Merge Strategy

Preferred merge strategy:

- Squash merge into `develop`
- Squash merge or rebase merge into `main`

This keeps history clean and easier to read.

---

## Review Policy

### For PRs into `develop`
- At least 1 approval is required

### For PRs into `main`
- At least 2 approvals are required

Reviewers should check:

- correctness
- readability
- consistency with project architecture
- test/build impact
- possible regressions

---

## CI / Required Checks

Before merging into `develop` or `main`, the following must pass:

- build
- test
- lint (if configured)

If CI is still minimal, at least the build must pass.

---

## Branch Cleanup

After a branch is merged:

- Delete the working branch
- Keep `main` and `develop`
- Never delete protected branches

---

## Quick Start

### Start a new feature
bash
git checkout develop
git pull
git checkout -b feature/my-feature

### Push your branch
bash
git push -u origin feature/my-feature

### Keep your branch updated
bash
git checkout develop
git pull
git checkout feature/my-feature
git merge develop
