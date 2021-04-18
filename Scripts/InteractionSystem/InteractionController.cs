using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace WTCProject.Interaction
{
    public class InteractionController : MonoBehaviour
    {
        [SerializeField] private KeyCode keyToInteract = KeyCode.F;

        [SerializeField] private float rayDistance = 5f;
        [SerializeField] private float rayRadius = 0.3f;
        [SerializeField] private Transform rayOrgin;

        [SerializeField] private TextMeshProUGUI interactionText;

        [SerializeField] private Image progressBar;

        private float timer;
        private RaycastHit hitInfo;

        private void Awake()
        {
            ResetText();
            ResetProgressBar();
        }

        private void Update()
        {
            CheckInteraction();
        }

        private void CheckInteraction()
        {
            if (IsHit())
            {
                if (Interactable())
                {
                    if (Interactable().isInteractable)
                    {
                        SetText();
                        StartInteraction();
                    }
                    else
                        ResetText();
                }
                else
                    ResetText();
            }
            else
                ResetText();

        }

        private void StartInteraction()
        {
            if (Interactable().isHoldInteract)
            {
                if (InteractClicked())
                {
                    StartHold();
                }

                if (InteractRelase())
                {
                    BreakHold();
                }
            }
            else
            {
                if (InteractClick())
                    Interactable().OnInteract();
            }
        }

        private void StartHold()
        {
            timer += Time.deltaTime;
            float _holdPercent = timer / Interactable().holdDuration;
            UpdateProgressBar(_holdPercent);

            if (timer >= Interactable().holdDuration)
            {
                Interactable().OnInteract();
                BreakHold();
            }
        }

        private void BreakHold()
        {
            ResetProgressBar();
        }

        private bool IsHit()
        {
            return Physics.SphereCast(DrawRay(), rayRadius, out hitInfo, rayDistance);
        }

        private Ray DrawRay()
        {
            return new Ray(rayOrgin.position, rayOrgin.forward);
        }

        private InteractableBase Interactable()
        {
            return hitInfo.transform.GetComponent<InteractableBase>();
        }

        private void SetText()
        {
            interactionText.text = "Use";
        }

        private void ResetText()
        {
            interactionText.text = "";
            ResetProgressBar();
        }

        public void UpdateProgressBar(float _fillAmount)
        {
            progressBar.fillAmount = _fillAmount;
            progressBar.gameObject.SetActive(true);
        }

        public void ResetProgressBar() {
            progressBar.fillAmount = 0;
            progressBar.gameObject.SetActive(false);
            timer = 0;
        }

        private bool InteractClick() { return Input.GetKeyDown(keyToInteract); }
        private bool InteractClicked() { return Input.GetKey(keyToInteract); }
        private bool InteractRelase() { return Input.GetKeyUp(keyToInteract); }
    }
}
