using UnityEngine;

namespace WTCProject.Controller
{
    public class MouseLook : MonoBehaviour
    {
        [SerializeField] private float mouseSensitivity = 90f;

        private float xRotation = 0f;
        private Player player;

        private void Awake()
        {
            player = GetComponentInParent<Player>();

            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Update()
        {
            Look();
        }

        private void Look()
        {
            transform.localRotation = Quaternion.Euler(GetXRotation(), 0f, 0f);
            player.transform.Rotate(Vector3.up * GetAxisX());
        }

        private float GetAxisX()
        {
            return Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        }

        private float GetAxisY()
        {
            return Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        }

        private float GetXRotation()
        {
            xRotation -= GetAxisY();
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            return xRotation;
        }

    }
}
