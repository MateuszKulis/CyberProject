using NaughtyAttributes;
using UnityEngine;

namespace WTCProject.Interaction.Elevator
{
    public class IElevator : InteractableBase
    {
        [HideIf(EConditionOperator.Or, "floor2", "floor3")] [SerializeField] private bool floor1;
        [HideIf(EConditionOperator.Or, "floor1", "floor3")] [SerializeField] private bool floor2;
        [HideIf(EConditionOperator.Or, "floor1", "floor2")] [SerializeField] private bool floor3;

        [ShowIf(EConditionOperator.Or, "floor1", "floor2", "floor3")] [SerializeField] private ElevatorManager elevator;
        [ShowIf(EConditionOperator.Or, "floor1", "floor2", "floor3")] [SerializeField] private Transform target;
        [ShowIf(EConditionOperator.Or, "floor1", "floor2", "floor3")] [SerializeField] private float speed;

        public override void OnInteract()
        {
            base.OnInteract();

            if (floor1)
            {
                elevator.SetFloor1(target, speed);
            }
            else if (floor2)
            {
                elevator.SetFloor2(target, speed);
            }
            else if (floor3)
            {
                elevator.SetFloor3(target, speed);
            }
        }
    }
}
