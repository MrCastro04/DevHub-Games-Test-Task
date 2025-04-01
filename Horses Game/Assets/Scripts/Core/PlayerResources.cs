using Core.Saves;
using UnityEngine;

namespace Core
{
    public class PlayerResources : MonoBehaviour
    {
        public static PlayerResources Instance { get; private set; }
        public int Money { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;

            InitializeFromSave(SaveSystem.GetData());

            DontDestroyOnLoad(gameObject);
        }

        private void InitializeFromSave(SaveData saveData)
        {
            Money = saveData.Money;

            EventManager.RaiseOnPlayerGetMoney(Money);
        }

        public void EarnMoney(int moneyAmount)
        {
            Money += moneyAmount;

            EventManager.RaiseOnPlayerGetMoney(Money);
        }
    }
}