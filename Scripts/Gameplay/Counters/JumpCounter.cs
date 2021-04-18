using UnityEngine;
using TMPro;

namespace WTCProject.Gameplay.Counters
{
    public class JumpCounter : MonoBehaviour
    {
        [SerializeField]private TextMeshProUGUI text;
        private int jumpQuantity;

        private void Awake()
        {
            text.text = "The number of jumps: " + jumpQuantity.ToString();
        }

        public void AddJump(int quantity)
        {
            jumpQuantity += quantity;
            text.text = "The number of jumps: " + jumpQuantity.ToString();
        }

        public void ResetQuantity()
        {
            jumpQuantity = 0;
            text.text = "The number of jumps: " + jumpQuantity.ToString();
        }
    }
}
