using UnityEngine;

namespace Horses.States
{
    public class AIPatrolState : AIBaseState
    {
        public override void EnterState(HorseContoller horseContoller)
        {
            if (horseContoller.WinHorseManager.HasWinner)
                return;

            HorseContoller randomHorse = horseContoller.WinHorseManager.GetRandomHorse();

            if (!randomHorse.IsWinHorse())
            {
                randomHorse.SetThisHorseWinHorse();

                horseContoller.WinHorseManager.MarkWinnerChosen();

                randomHorse.SwitchState(randomHorse.WinHorseState);
            }
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