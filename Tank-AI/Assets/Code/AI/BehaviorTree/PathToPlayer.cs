﻿using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Behavior that plans and follows path to player
/// </summary>
public class PathToPlayer : BehaviorTreeNode
{
    /// <summary>
    /// Path we are trying to execute
    /// </summary>
    private List<Waypoint> currentPath;

    /// <summary>
    /// Distance from waypoint at which we move on to the next waypoint
    /// </summary>
    const float ReachedWaypointThreshold = 1;

    /// <summary>
    /// Move toward the next waypoint
    /// </summary>
    /// <param name="tank">Tank being controlled</param>
    /// <returns>True if we aren't there yet</returns>
    public override bool Tick (AITankControl tank)
    {
        if (currentPath == null || currentPath.Count == 0)   
            currentPath = Waypoint.FindPath(tank.transform.position, Player.position);
        
        if (Vector3.Distance(currentPath[0].transform.position, tank.transform.position) < 1)
        {
            currentPath.RemoveAt(0);
            return false;
        }

        tank.MoveTowards(currentPath[0].transform.position);

        return true; 
    }

    #region Debug visualization

    public override void OnDrawBTGizmos(AITankControl tank)
    {
        if (currentPath == null || currentPath.Count == 0)
            return;

        Gizmos.color = Color.green;
        Gizmos.DrawLine(currentPath[0].transform.position + Vector3.right,
                        tank.transform.position + Vector3.right);
        Gizmos.DrawLine(currentPath[0].transform.position + Vector3.up,
                        tank.transform.position + Vector3.up);
        for (int i = 1; i < currentPath.Count; i++)
        {
            Gizmos.DrawLine(currentPath[i].transform.position + Vector3.right,
                            currentPath[i - 1].transform.position + Vector3.right);
            Gizmos.DrawLine(currentPath[i].transform.position + Vector3.up,
                            currentPath[i - 1].transform.position + Vector3.up);
        }
    }
    #endregion
}
