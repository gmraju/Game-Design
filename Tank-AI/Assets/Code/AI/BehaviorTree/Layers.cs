﻿using System;

/// <summary>
/// Definitions for collision layers for forming layer masks
/// It's crazy that this isn't auto-generated by Unity.
/// </summary>
[Flags]
public enum Layers
{
    Mines = 1 << 8,
    Projectiles = 1 << 9,
    Walls = 1 << 10
}
