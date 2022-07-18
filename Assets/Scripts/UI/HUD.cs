using UnityEngine;

namespace LOK1game.UI
{
    public class HUD : MonoBehaviour
    {
        public static HUD Instance { get; private set; }

        public BudgetText BudgetText => _budgetText;
        
        [SerializeField] private BudgetText _budgetText;

        private void Awake()
        {
            Instance = this;
        }

        private void OnDestroy()
        {
            Instance = null;
        }
    }
}