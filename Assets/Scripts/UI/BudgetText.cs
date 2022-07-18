using System;
using UnityEngine;
using TMPro;

namespace LOK1game.UI
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class BudgetText : MonoBehaviour
    {
        private TextMeshProUGUI _text;

        private void Awake()
        {
            _text = GetComponent<TextMeshProUGUI>();
        }

        public void SetBudget(int value)
        {
            _text.text = $"Бюджет: <color=yellow>{value}</color>";
        }
    }
}