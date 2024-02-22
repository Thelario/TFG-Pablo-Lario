using TMPro;
using UnityEngine;

namespace _Project.COMMON.Scripts.UI
{
    public class SpeedersAmountText : MonoBehaviour
    {
        [SerializeField] private int initialSpeedersAmount;
        [SerializeField] private TMP_Text speedersAmountText;

        private int _speedersAmount;

        private void Awake()
        {
            _speedersAmount = initialSpeedersAmount;
        }

        private void Update()
        {
            if (!Input.GetKeyDown(KeyCode.Q))
                return;
            
            UpdateText();
        }

        private void UpdateText()
        {
            speedersAmountText.text = "Speeders: " + _speedersAmount * _speedersAmount;

            _speedersAmount += 5;
        }
    }
}