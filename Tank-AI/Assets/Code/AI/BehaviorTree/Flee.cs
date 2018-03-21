using UnityEngine;

/// <summary>
/// Behavior that runs to a random location
/// </summary>
public class Flee : BehaviorTreeNode
{
    /// <summary>
    /// Where we're running to
    /// </summary>
    private Vector3 goal;

    /// <summary>
    /// Run toward the goal
    /// </summary>
    /// <param name="tank">Tank being controlled</param>
    /// <returns>True if behavior wants to keep running</returns>
    public override bool Tick(AITankControl tank)
    {
        while (WallBetween(tank.transform.position, goal))     
            goal = SpawnController.FindFreeLocation(1);
        
        if (Vector3.Distance(goal, tank.transform.position) > 1)
        {
            tank.MoveTowards(goal);
            return true;
        }

        else
            return false;
    }
}
