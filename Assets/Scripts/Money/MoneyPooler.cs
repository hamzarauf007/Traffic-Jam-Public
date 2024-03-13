using System.Collections.Generic;
using UnityEngine;

namespace Cash
{
    public class MoneyPooler : MonoBehaviour
    {
        public List<MoneyType> moneyTypes;
        
        private Dictionary<string, Queue<GameObject>> poolDictionary;

        private void OnEnable()
        {
            GameEvents.OnMoneyCollected += ReturnMoneyToPool;
        }
        
        private void OnDisable()
        {
            GameEvents.OnMoneyCollected -= ReturnMoneyToPool;
        }

        private void Awake()
        {
            InitializePools();
        }

        private void InitializePools()
        {
            poolDictionary = new Dictionary<string, Queue<GameObject>>();
        
            foreach (var item in moneyTypes)
            {
                Queue<GameObject> objectQueue = new Queue<GameObject>();
                poolDictionary.Add(item.tag, objectQueue);
            }
        }

        public GameObject GetMoney(string tag)
        {
            if (!poolDictionary.ContainsKey(tag) || poolDictionary[tag].Count == 0)
            {
                AddMoney(tag, 1);
            }

            GameObject moneyToSpawn = poolDictionary[tag].Dequeue();
            return moneyToSpawn;
        }

        private void AddMoney(string tag, int count)
        {
            var moneyType = moneyTypes.Find(type => type.tag == tag);
            if (moneyType != null)
            {
                for (int i = 0; i < count; i++)
                {
                    var newMoney = Instantiate(moneyType.prefab, this.transform);
                    newMoney.SetActive(false);
                    poolDictionary[tag].Enqueue(newMoney);
                }
            }
            else
            {
                Debug.LogWarning("Money type with tag " + tag + " not found.");
            }
        }

        private void ReturnMoneyToPool(string tag, GameObject money)
        {
            money.SetActive(false);
            if (poolDictionary.ContainsKey(tag))
            {
                poolDictionary[tag].Enqueue(money);
            }
            else
            {
                Debug.LogWarning("Returning to a non-existent pool with tag: " + tag);
            }
        }
    }
}
