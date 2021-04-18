using UnityEngine;
using WTCProject.Controller;
using TMPro;

namespace WTCProject.Gameplay.Counters
{

    public class FloorCounter : MonoBehaviour
    {

        [SerializeField]private TextMeshProUGUI text;
        [SerializeField]private GameObject engGameImage;

        private Vector3 startPosition;
        private Player player;
        private TimeCounter timeCounter;
        private JumpCounter jumpCounter;

        private void Awake()
        {
            player = FindObjectOfType<Player>();
            timeCounter = FindObjectOfType<TimeCounter>();
            jumpCounter = FindObjectOfType<JumpCounter>();
            startPosition = player.transform.position; 
        }

        private void Update()
        {
            if (CheckFloor1())
                SetFloorText(1);
            else if (CheckFloor2())
                SetFloorText(2);
            else if (CheckFloor3())
                SetFloorText(3);
            else if (CheckPlayerDeath())
                SetPlayerDeath();

        }

        private void SetFloorText(int floor)
        {
            text.text = "Current floor: " + floor.ToString();
            player.enabled = true;
        }

        private void SetPlayerDeath()
        {
            engGameImage.SetActive(true);
            player.transform.position = startPosition;
            player.enabled = false;
            timeCounter.ResetTime();
            jumpCounter.ResetQuantity ();
        }


        private bool CheckFloor1()
        {
            return player.transform.position.y > 15 && player.transform.position.y < 50;
        }

        private bool CheckFloor2()
        {
            return player.transform.position.y > 50 && player.transform.position.y < 90;
        }

        private bool CheckFloor3()
        {
            return player.transform.position.y > 90;
        }

        private bool CheckPlayerDeath()
        {
            return player.transform.position.y < 15;
        }

    }
}
