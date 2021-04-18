using UnityEngine;
using TMPro;

namespace WTCProject.Gameplay.Counters
{
    public class TimeCounter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text;
        private float time;

        void Update()
        {
            time += Time.deltaTime;
            text.text = "Time: " + time.ToString("0#.00");
        }

        public void ResetTime()
        {
            time = 0;
        }
    }
}
