using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WTCProject.Interaction
{
    public interface IInteractable
    {
        bool IsInteractable { get;  }
        bool IsHoldInteract { get;  }
        float HoldDuration { get;  }

        void OnInteract();
    }
}
