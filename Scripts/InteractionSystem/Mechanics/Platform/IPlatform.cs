using System.Collections;
using UnityEngine;
using NaughtyAttributes;

namespace WTCProject.Interaction.Platform
{
    public class IPlatform : InteractableBase
    {
        [SerializeField]
        [MinValue(0), MaxValue(1)]
        private int target;


        [SerializeField] private Material yellowMaterial;
        [SerializeField] private Material redMaterial;

        private Renderer buttonRender;

        [SerializeField] private PlatformManager platformManager;

        private void Awake()
        {
            buttonRender = GetComponent<Renderer>();
            buttonRender.material = redMaterial;
        }

        public override void OnInteract()
        {
            base.OnInteract();

            platformManager.SetTarget(target);
            buttonRender.material = yellowMaterial;
            StartCoroutine(WaitAndPrint(2f));
            isInteractable = false;
        }

        private IEnumerator WaitAndPrint(float waitTime)
        {
            yield return new WaitForSeconds(waitTime);
            buttonRender.material = redMaterial;
            isInteractable = true;
        }


    }
}
