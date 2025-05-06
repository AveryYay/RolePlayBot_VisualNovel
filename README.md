# RolePlayBot_VisualNovel

This is a Unity-based visual novel game featuring Sheldon Cooper as the central character, powered by the RolePlayBot backend. The game is built using [Naninovel](https://naninovel.com/), a toolkit for creating visual novel games inside Unity.

## Overview

Players interact with Sheldon through classic visual novel dialogue choices. Behind the scenes, the game tracks player interactions and logs all dialogue exchanges.
A **Sync** button in the printer's nav bar allows the game to send these logs to the RolePlayBot server, which stores them as long-term memory (in interactive_vector_db). 
This enables continuity across sessions and ensures that Sheldon “remembers” past conversations.

## Features
- Built with Unity and Naninovel
- Dialogue-based gameplay featuring a custom Sheldon persona
- Sync system that communicates with the RolePlayBot server
- Logging system that captures and transmits player interaction history

## How Sync Works
1. During gameplay, all dialogue is logged automatically.
2. When the player finishes a session, clicking the **Sync** button sends this log to the backend (`/add_interaction` endpoint of the RolePlayBot server).
3. The server summarizes and stores the interaction, updating the bot’s memory.

## Requirements
- Unity 2021.3 LTS or newer
- Naninovel plugin installed
- RolePlayBot backend running and reachable (see [RolePlayBot repo](https://github.com/AveryYay/RolePlayBot))

## Getting Started

1. Clone this repo.
2. Open the project in Unity.
3. Make sure Naninovel is properly set up.
4. In your game, configure the sync button to call the correct server endpoint.
5. Run the game and try syncing after a playthrough.

## Related
- Backend repo: [RolePlayBot](https://github.com/AveryYay/RolePlayBot)
