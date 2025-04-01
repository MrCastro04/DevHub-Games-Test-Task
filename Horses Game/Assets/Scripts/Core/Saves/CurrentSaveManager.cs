using UnityEngine;

namespace Core.Saves
{
    public class CurrentSaveManager : MonoBehaviour
    {
        public static CurrentSaveManager Instance { get; private set; }
        public SaveData CurrentSave { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);

                return;
            }

            Instance = this;

            DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            GetLastSave(SaveSystem.GetData());
        }

        private void OnEnable()
        {
            EventManager.OnPlayerGetMoney += HandleOnPlayerGetMoney;
        }

        private void OnDisable()
        {
            EventManager.OnPlayerGetMoney -= HandleOnPlayerGetMoney;
        }

        private void GetLastSave(SaveData data)
        {
            CurrentSave = data;

            PlayerResources.Instance.GetMoneyFromSave(CurrentSave);
        }

        private void HandleOnPlayerGetMoney(int playerCurrentMoneyAmount)
        {
            CurrentSave.Money = playerCurrentMoneyAmount;

            SaveSystem.SetData(CurrentSave);
        }
    }
}