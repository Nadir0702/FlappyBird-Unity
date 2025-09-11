# 🐦 Flappy Bird Clone

A faithful recreation of the classic Flappy Bird game built with **Unity 6.0**. This project features smooth gameplay, persistent leaderboards, beautiful animations, and immersive audio effects.

![Unity](https://img.shields.io/badge/Unity-6000.0.54f1-blue.svg)
![C#](https://img.shields.io/badge/C%23-239120.svg?logo=c-sharp&logoColor=white)
![License](https://img.shields.io/badge/License-MIT-green.svg)

## 🎮 Game Features

### Core Gameplay

-   **Classic Flappy Bird mechanics** - Navigate through pipes by timing your jumps perfectly
-   **Dual input support** - Play using either the **Space bar** or **Left Mouse Button**
-   **Physics-based movement** - Realistic gravity and jump mechanics using Unity's 2D physics
-   **Collision detection** - Precise collision system for pipes, ground, and scoring zones

### Visual & Audio

-   **Smooth bird flying animation** - Three-frame wing flap animation (upflap, midflap, downflap)
-   **Comprehensive audio system**:
    -   🎵 Wing flap sound effects
    -   🎯 Point scoring audio
    -   💥 Collision/hit sounds
    -   💀 Death sound effects

### Advanced Features

-   **Persistent Leaderboard** - Top 5 scores saved between game sessions using PlayerPrefs
-   **Smart Object Pooling** - Efficient pipe management using Unity's ObjectPool system
-   **Coroutine-based Game Over** - 1.5-second delay before showing menu screen for better UX
-   **Singleton Architecture** - Clean, maintainable code structure
-   **State Management** - Proper game state handling (NotStarted, InProgress, GameOver)

## 🏗️ Technical Architecture

### Core Systems

-   **GameManager** - Central game logic, scoring, and state management
-   **PlayerController** - Input handling and bird movement
-   **CanvasManager** - UI management and leaderboard display
-   **Pipe System** - Dynamic pipe spawning and movement
-   **Object Pooling** - Memory-efficient pipe management

### Key Components

```
Assets/Scripts/
├── GameManager.cs          # Core game logic and state management
├── PlayerController.cs     # Input handling and bird control
├── CanvasManager.cs        # UI management and leaderboard
├── Bird.cs                 # Bird physics and collision
├── Pipe.cs                 # Pipe movement and scoring
├── Singleton.cs            # Singleton pattern implementation
├── BestObjectPool.cs       # Object pooling system
├── GameState.cs            # Game state enumeration
└── Constants.cs            # Game configuration constants
```

### Assets Structure

```
Assets/
├── Scripts/                # C# game scripts
├── sprites/               # Game sprites (birds, pipes, backgrounds)
├── audio/                 # Sound effects (WAV & OGG formats)
├── Animation/             # Bird flying animation controller
├── Prefabs/               # Game object prefabs
└── Scenes/                # Game scenes
```

## 🚀 Getting Started

### Prerequisites

-   **Unity 6.0** or later (tested with 6000.0.54f1)
-   **Windows 10/11** (project configured for Windows)

### Installation

1. **Clone the repository**

    ```bash
    git clone https://github.com/yourusername/flappy-bird-clone.git
    cd flappy-bird-clone
    ```

2. **Open in Unity**

    - Launch Unity Hub
    - Click "Add" and select the project folder
    - Open the project with Unity 6.0+

3. **Build and Run**
    - Go to `File > Build Settings`
    - Select your target platform
    - Click "Build and Run"

### Controls

-   **Space Bar** - Make the bird jump
-   **Left Mouse Button** - Alternative jump control
-   **UI Buttons** - Start, Restart, and Exit game

## 🎯 Game Mechanics

### Scoring System

-   Score increases by 1 for each pipe successfully passed
-   Top 5 scores are automatically saved and displayed
-   Leaderboard persists between game sessions

### Physics

-   **Gravity Scale**: 2.0 (configurable in Constants.cs)
-   **Jump Force**: Customizable per bird
-   **Pipe Speed**: Adjustable movement speed
-   **Collision Detection**: 2D physics-based collision system

### Object Pooling

-   Efficient memory management for pipe objects
-   Pre-populated pool of 2 pipes (configurable)
-   Automatic cleanup of off-screen objects

## 🛠️ Customization

### Easy Modifications

-   **Pipe Speed**: Adjust `m_PipeSpeed` in GameManager
-   **Jump Force**: Modify `m_JumpForce` in PlayerController
-   **Gravity**: Change `GravityScale` in Constants.cs
-   **Leaderboard Size**: Update `LeaderBoardSize` in Constants.cs
-   **Game Over Delay**: Modify `m_Timeout` in GameManager

## 📱 Build Information

### Supported Platforms

-   **Windows** (Primary target)
-   **Mac** (Compatible)
-   **Linux** (Compatible)
-   **WebGL** (Compatible with minor adjustments)

### Build Settings

-   **Graphics API**: DirectX 11/12 (Windows)
-   **Rendering Pipeline**: Universal Render Pipeline (URP)
-   **Input System**: New Unity Input System
-   **Audio**: Unity Audio System with multiple AudioSources

## 🎨 Asset Credits

This project uses classic Flappy Bird-inspired assets from [flappy-bird-assets](https://github.com/samuelcust/flappy-bird-assets):

-   **Sprites**: Custom bird animations and pipe designs
-   **Audio**: Classic arcade-style sound effects
-   **UI**: Clean, minimalist interface design

## 🙏 Acknowledgments

-   Inspired by the original Flappy Bird game by Dong Nguyen
-   Built with Unity 6.0 and C#
-   Uses Unity's Universal Render Pipeline for modern graphics
-   Implements best practices for 2D game development

## 📞 Contact

**Project Maintainer**: Nadir Elmakias

-   **GitHub**: [@Nadir0702](https://github.com/Nadir0702)
---

⭐ **Star this repository** if you found it helpful!

💡 **Have a feature request?** We'd love to hear your ideas!
