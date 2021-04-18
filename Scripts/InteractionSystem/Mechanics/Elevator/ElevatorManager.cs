using UnityEngine;
using WTCProject.Controller;

namespace WTCProject.Interaction.Elevator
{
    public class ElevatorManager : MonoBehaviour
    {

        [SerializeField] private Material redMaterial;
        [SerializeField] private Material greenMaterial;
        [SerializeField] private Renderer[] buttonsRender;

        private bool isActive;
        private Transform target;
        private float speed;
        private Player player;

        private void Awake()
        {
            player = FindObjectOfType<Player>();
        }

        private void Update()
        {
            if (isActive)
                FloorChange();

        }

        private void FloorChange()
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime * speed);
            player.transform.SetParent(transform);
            player.isPlatform = true;

            if (transform.localPosition == target.transform.localPosition)
            {
                isActive = false;
                player.transform.SetParent(null);
                player.isPlatform = false;
            }
        }

        public void SetFloor1(Transform _target, float _speed)
        {
            isActive = true;
            target = _target;
            speed = _speed;
            SetButton(0);
        }

        public void SetFloor2(Transform _target, float _speed)
        {
            isActive = true;
            target = _target;
            speed = _speed;
            SetButton(1);
        }

        public void SetFloor3(Transform _target, float _speed)
        {
            isActive = true;
            target = _target;
            speed = _speed;
            SetButton(2);
        }

        private void SetButton(int floor)
        {
            for (int i = 0; i < buttonsRender.Length ; i++)
            {
                if(i != floor)
                {
                    buttonsRender[i].material = redMaterial;
                }
                else
                {
                    buttonsRender[i].material = greenMaterial;
                }

                if (i > buttonsRender.Length) break;
            }
        }
    }
}