using UnityEngine;
/// <summary>
/// Beavhior that drives in a straight line toward the player.
/// </summary>
public class MoveTowardPlayer : BehaviorTreeNode
{
    public override bool Tick (AITankControl tank)
    {

        if (!WallBetween(tank.transform.position, Player.position))
        {
            tank.MoveTowards(Player.position);
            return true;
        }

        else
            return false;
    }
}
