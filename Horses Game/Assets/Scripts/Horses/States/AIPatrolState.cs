using Core;
using UnityEngine;

namespace Horses.States
{
    public class AIPatrolState : AIBaseState
    {
        public override void EnterState(HorseContoller horseContoller)
        {
            EventManager.RaiseOnHorsesStartRun();
        }

        public override void UpdateState(HorseContoller horseContoller)
        {
            float currentPercent = horseContoller.Patrol.SplineCurrentPosition;

            if (currentPercent >= horseContoller.NextBuffPercent)
            {
                horseContoller.ApplySpeedBuff();

                horseContoller.NextBuffPercent += 0.1f;

                horseContoller.NextBuffPercent = Mathf.Clamp01(horseContoller.NextBuffPercent);
            }

            horseContoller.Patrol.CalculateNextPosition();

            Vector3 currentPosition = horseContoller.transform.position;

            Vector3 newPosition = horseContoller.Patrol.GetNextPosition();

            Vector3 offset = newPosition - currentPosition;

            horseContoller.Movement.MoveAgentByMoveOffset(offset);
        }
    }
}