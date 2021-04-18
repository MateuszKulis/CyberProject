using UnityEngine;
using WTCProject.Gameplay.Counters;

namespace WTCProject.Controller
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float speed = 15f;
        [SerializeField] private float gravityForce = 15f;
        [SerializeField] private float jumpHeight = 15f;

        [SerializeField] private Transform groundCheck;
        [SerializeField] private float groundDistance = 0.4f;


        [HideInInspector]public bool isPlatform;
        private bool isJump;

        private Vector3 velocity;
        private CharacterController controller;
        private JumpCounter jumpCounter;

        private void Awake()
        {
            controller = GetComponent<CharacterController>();
            jumpCounter = FindObjectOfType<JumpCounter>();
        }

        void Update()
        {  
            Movment();
            Gravity();
            Jump();
        }

        private void Movment()
        {

            float x = Input.GetAxisRaw("Horizontal");
            float z = Input.GetAxisRaw("Vertical");

            groundCheck.localPosition = new Vector3(x, 0, z);
            Debug.DrawRay(groundCheck.position, Vector3.down, Color.green, groundDistance);

            if (IsGround() || isJump)
            {
                Vector3 move = transform.right * x + transform.forward * z;
                if (x != 0 || z != 0) controller.Move(move * speed * Time.deltaTime);
            }
        }

        private void Gravity()
        {
            velocity.y += -gravityForce * Time.deltaTime;

            if (!isPlatform || isJump)controller.Move(velocity * Time.deltaTime);
        }

        private void Jump()
        {
            if (CanJump())
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * -gravityForce);
                jumpCounter.AddJump(1);
                isJump = true;
            }

            if (IsGround() && velocity.y <= -2f)
            {
                isJump = false;
            }
        }

        private bool IsGround()
        {
            return Physics.Raycast(groundCheck.position, Vector3.down, groundDistance);
        }

        private bool CanJump()
        {
            return Input.GetButtonDown("Jump") && IsGround() && !isJump;
        }

    }
}
