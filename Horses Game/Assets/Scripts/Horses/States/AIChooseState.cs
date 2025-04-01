using Core;

namespace Horses.States
{
    public class AIChooseState : AIBaseState
    {
        public override void EnterState(HorseContoller horseContoller) { }

        public override void UpdateState(HorseContoller horseContoller)
        {
            if (horseContoller.IsChosenByPlayer)
                ConfirmChoose();
        }

        private void ConfirmChoose()
        {
            EventManager.RaiseOnPlayerConfirmChoose();
        }
    }
}