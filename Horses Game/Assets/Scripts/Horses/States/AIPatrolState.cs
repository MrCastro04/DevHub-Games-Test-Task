using UnityEngine;

namespace Horses.States
{
    public class AIPatrolState : AIBaseState
    {
        public override void EnterState(HorseContoller horseContoller)
        {

        }

        public override void UpdateState(HorseContoller horseContoller)
        {
            horseContoller.Patrol.CalculateNextPosition();

            Vector3 currentPosition = horseContoller.transform.position;

            Vector3 newPosition = horseContoller.Patrol.GetNextPosition();

            Vector3 offset = newPosition - currentPosition;

            horseContoller.Movement.MoveAgentByMoveOffset(offset);
        }
    }
}