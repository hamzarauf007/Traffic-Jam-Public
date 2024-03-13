using UnityEngine;

namespace Cash
{ 
    public class Money : MonoBehaviour, ICollectable
    {
        [SerializeField] 
        private int value;

        public int Value
        {
            get => value;
            set { }
        }

        public void Collect()
       {
           GameEvents.MoneyCollected(Value.ToString(), gameObject);
       }
   }  
}

