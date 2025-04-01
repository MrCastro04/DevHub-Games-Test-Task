using UnityEngine;

namespace Core
{
    public class PlayerResources : MonoBehaviour
    {
        public static PlayerResources Instance { get; private set; }

        public int Money { get; private set; }

        private void Awake()
        {
            Instance = this;
        }

        public void GetMoneyFromSave(Saves.SaveData save)
        {
            Money = save.Money;

            EventManager.RaiseOnPlayerGetMoney(Money);
        }

        public void EarnMoney(int amount)
        {
            Money += amount;
            
            EventManager.RaiseOnPlayerGetMoney(Money);
        }
    }
}