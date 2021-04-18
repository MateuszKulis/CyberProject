using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace WTCProject.Gameplay.HelpScripts
{
    public class DeactivateObject : MonoBehaviour
    {
        [SerializeField] private float time;
        private float timer;

        void Update()
        {
            timer += Time.deltaTime;
            if (timer >= time)
            {
                gameObject.SetActive(false);
                timer = 0;
            }
        }
    }
}
