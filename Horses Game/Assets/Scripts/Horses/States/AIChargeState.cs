using UnityEngine;

namespace Horses.States
{
    public class AIChargeState : AIBaseState
    {
        private float _desiredPercentage = 0.4f;
        private bool _hasCharged = false;

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

            if (!_hasCharged &&
                horseContoller.Patrol.IsCurrentWalkedPercentageEnoughThenDesired(_desiredPercentage))
            {
                _hasCharged = true;

                horseContoller.Agent.speed += 10f;
            }
        }
    }
}