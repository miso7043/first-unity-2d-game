## Overview

This is a simple **Unity 2D project** built to help beginners (in this case, my son 😊) learn the basics of game development.
It introduces the following concepts:

* **Observer Pattern** for handling keyboard input
* **Separation of Concerns** (input handling vs. movement logic)
* **Physics-based movement** using `Rigidbody2D`
* **Jumping mechanics** with a grounded check
* **Left/Right movement** with configurable speed
* **Clean code structure** with short, focused scripts for better readability and maintainability

The project demonstrates how to keep code modular and clean while making a simple player controller.

---

## Design Philosophy

When teaching beginners, one of the most important lessons is **clarity and maintainability**:

* **Keep scripts short** → Each script should do only one thing (Single Responsibility Principle).
* **Class per feature** → Input, player logic, and movement are separated into their own classes.
* **Error isolation** → When an error occurs, it’s easier to locate the source because functionality is modular.
* **Scalability** → As the project grows, this structure prevents a single "God script" that becomes hard to debug.

This way, even as the project grows into a larger game, errors can be tracked and fixed quickly.

---

## Project Structure

### 1. `KeyChecker.cs`

* Acts as the **subject** in the Observer Pattern.
* Keeps a list of registered observers (`IKeyObserver`).
* On every `Update()`, it checks the keys requested by each observer and notifies them when the key is pressed.

---

### 2. `IKeyObserver`

* An interface that any class can implement if it wants to receive key input events.
* Requires:

  ```csharp
  List<KeyCode> Keys { get; }
  void OnKeyPressed(KeyCode key);
  ```

---

### 3. `BananaPlayer.cs`

* Implements `IKeyObserver`.
* Subscribes to `KeyChecker` and listens for the keys:

  * **Space** → Jump
  * **A** or **LeftArrow** → Move Left
  * **D** or **RightArrow** → Move Right
* Delegates all actual movement to the `MoveMgr` component.
* Keeps input handling and movement separate for cleaner code.

---

### 4. `MoveMgr.cs`

* Handles **player physics movement**.
* Requires a `Rigidbody2D` component.
* Provides methods:

  * `StartJump()` → Jumps only if grounded
  * `MoveLeft()` → Moves left
  * `MoveRight()` → Moves right
* Uses collision detection to reset `isGrounded` when touching the ground.
* Public fields:

  * `jumpForce` → How high the player jumps
  * `moveSpeed` → How fast the player moves

---

## How It Works

1. The `KeyChecker` runs every frame and detects registered keys.
2. When a key is pressed, it notifies `BananaPlayer`.
3. `BananaPlayer` interprets the key and calls the appropriate method in `MoveMgr`.
4. `MoveMgr` updates the `Rigidbody2D` to apply movement or jumping.
5. Collision detection ensures that the player can only jump when grounded.

---

## Lessons Learned

* **Observer Pattern** is useful for decoupling input handling from gameplay logic.
* **Unity Physics** (`Rigidbody2D`, `Collider2D`) can simplify movement and collision detection.
* **Modularity** makes debugging easier:

  * If jumping fails → check `MoveMgr.StartJump()`
  * If input isn’t detected → check `KeyChecker` or `BananaPlayer`
* **Scalable structure** → By keeping each class small and dedicated, the codebase remains easy to expand and maintain.

---

## Next Steps

* Add animations for walking and jumping.
* Implement double-jump or dash mechanics.
* Add enemies, collectibles, and scoring.
* Explore Unity’s **Input System** package for more advanced input handling.

---

✨ With this foundation, a beginner can start experimenting and building their own 2D platformer step by step, while learning **good coding practices** from the start.
