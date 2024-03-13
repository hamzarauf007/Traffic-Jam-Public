using UnityEngine;

namespace Cash
{
    public class MoneyFactory : MonoBehaviour
    {
        [SerializeField]
        private Vector3 moneyRotation;

        [SerializeField] 
        private MoneyPooler moneyPooler;
        
        public GameObject SpawnMoney(string moneyType, Vector3 position)
        {
            var money = moneyPooler.GetMoney(moneyType);
            money.SetActive(true);
            money.transform.position = position;
            money.transform.rotation = Quaternion.Euler(moneyRotation);
            
            return money;
        }
    }
}
