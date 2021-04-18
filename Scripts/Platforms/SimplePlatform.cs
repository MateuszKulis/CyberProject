using WTCProject.Controller;
using UnityEngine;

namespace WTCProject.Platforms
{
    public class SimplePlatform : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            var player = other.gameObject.GetComponent<Player>();
            if (player)
            {
                player.transform.SetParent(transform);
                player.isPlatform = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            var player = other.gameObject.GetComponent<Player>();
            if (player)
            {
                player.transform.SetParent(null);
                player.isPlatform = false;
            }
        }
    }
}
