# Adventure2D

A 2D action RPG built in Unity/C#, inspired by classic Zelda-style dungeon exploration. This project focuses on implementing modular gameplay systems, enemy behavior, extensible combat mechanics, and, of course, a fun, challenging game.


---

## Gameplay Features

- **Player controller singleton** designed to interact cleanly with multiple systems: hazards, enemies, level transitions, and health/weapon management.
- **Modular combat framework** built with ScriptableObjects and animation controllers, allowing new weapons to be implemented quickly with configurable parameters.
- **Enemy and environmental hazards** that react dynamically to the player's position and actions.
- **Three connected maps**, each with distinct design goals that builds off the previous.

---

## Levels

**Level 1 — Introduction**
A starting map used to establish player movement, combat, and enemy interaction. Introduces simple maze features to the player: hidden walkways, transitions, dead-ends.

**Level 2 — Forest Maze**
An expansive maze built using custom prefabs, designed for rapid iteration. The maze is explorable and testing, but players who explore will find hints of a secret path.

![Forest Maze](Media/forest_maze.gif)

**Level 3 — Dungeon (In Progress)**
Reuses and extends existing systems in new ways: projectiles now come from turrets and bottomless pits threaten the player's footing. With the introduction of healing objects and a glowing follower, the player is prepared to descend further. With perfect timing, as the torches fade and glowing eyes look out from the dark...

![Dungeon](Media/dungeon.gif)
---

## Technical Highlights

- **Extensible combat system** — weapons are swappable and each exposes tunable parameters, making balance iteration fast
- **Singleton architecture** for shared state (player object, health bar, level manager)
- **Coroutines** used for asynchronous gameplay logic such as enemy attack timing and state transitions
- **Prefab-driven level design** to accelerate iteration, especially in the forest maze
- **Unity lighting** explored for the indoor dungeon environment

---

## Built With

- Unity 6.3 LTS
- C#

---

## Status

Active personal project — core systems are functional. Level 3 and additional content are in progress.
