using Core;
using UnityEngine;
using Utility;

namespace Horses.States
{
    public class AIPatrolState : AIBaseState
    {
        public override void EnterState(HorseContoller horseContoller)
        {
            EventManager.RaiseOnHorsesStartRun();

            WinHorseManager winHorseManager =
                GameObject.FindGameObjectWithTag(Constants.WIN_HORSE_MANAGER_TAG)
                    .GetComponent<WinHorseManager>();

            winHorseManager.MarkRandomHorseWinHorse();

            if (horseContoller.IsWinHorse)
            {
                horseContoller.SwitchState(horseContoller.WinHorseState);
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