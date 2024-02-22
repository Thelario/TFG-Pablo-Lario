using TMPro;
using UnityEngine;

namespace _Project.COMMON.Scripts.UI
{
    public class BuildingsAmountText : MonoBehaviour
    {
        [SerializeField] private int initialBuildingsAmount;
        [SerializeField] private TMP_Text buildingsAmountText;

        private int _buildingsAmount;

        private void Awake()
        {
            _buildingsAmount = initialBuildingsAmount;
        }

        private void Update()
        {
            if (!Input.GetKeyDown(KeyCode.Q))
                return;
            
            UpdateText();
        }

        private void UpdateText()
        {
            buildingsAmountText.text = "Buildings: " + _buildingsAmount * _buildingsAmount;

            _buildingsAmount += 5;
        }
    }
}