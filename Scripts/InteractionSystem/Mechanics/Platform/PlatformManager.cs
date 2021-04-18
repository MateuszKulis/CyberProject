using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WTCProject.Interaction.Platform
{
    public class PlatformManager : MonoBehaviour
    {
        [SerializeField]
        private Transform target1;
        [SerializeField]
        private Transform target2;

        [SerializeField]
        private float speed;

        private int actualTarget;

        private void Update()
        {
            FollowTarget();
        }

        private void FollowTarget()
        {
            if (actualTarget == 0) transform.position = Vector3.MoveTowards(transform.position, target1.transform.position, Time.deltaTime * speed);
            if (actualTarget == 1) transform.position = Vector3.MoveTowards(transform.position, target2.transform.position, Time.deltaTime * speed);

            if (transform.localPosition == target1.localPosition) actualTarget = 1;
            if (transform.localPosition == target2.localPosition) actualTarget = 0;

            if (actualTarget > 1) actualTarget = 1;
            if (actualTarget < 0) actualTarget = 0;
        }

        public void SetTarget (int target)
        {
            actualTarget = target;
        }
    }
}
