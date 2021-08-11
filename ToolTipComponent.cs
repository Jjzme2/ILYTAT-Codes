using UnityEngine;
using TMPro;
using UnityEngine.Events;

namespace ILYTATTools {

    [System.Serializable]
    public class UnityTooltipEvent : UnityEvent<GameObject>
    {

    }


    [RequireComponent(typeof(TextMeshPro))]
    public class ToolTipComponent : MonoBehaviour
    {
        public float ToolTipYOffset = .25f;
        public float ToolTipXOffset = 0.0f;
        public bool ShouldDestroyOnLoadNewScene = true;
        public TextMeshPro GetTM => GetComponent<TextMeshPro>();

        public UnityTooltipEvent TooltipHoverAction;
        [SerializeField]
        private bool textEnabledOnStart = false;
        private Vector2 centeredMousePos => new Vector2(InputManager.Instance.WorldPointMousePos.x + ToolTipXOffset, InputManager.Instance.WorldPointMousePos.y + ToolTipYOffset);


        public void OnEnable()
        {
            if (!ShouldDestroyOnLoadNewScene)
            {
                DontDestroyOnLoad(gameObject);
            }
            GetComponent<TextMeshPro>().enabled = textEnabledOnStart;
        }

        public void OnDisable()
        {

        }

        private void Update()
        {
            MouseHover.CheckHover();

            if (MouseHover.GetIsHovering)
            {
                EnableToolTip();
                TooltipHoverAction.Invoke(MouseHover.GetHoveredObject);
            }
            else
            {
                DisableToolTip();
            }
        }

        private void EnableToolTip()
        {
            Vector2 toolTipPos = new Vector2(MouseHover.GetHoveredObject.transform.position.x + ToolTipXOffset, MouseHover.GetHoveredObject.transform.position.y + ToolTipYOffset);
            SetToolTipPos(toolTipPos);
            GetTM.enabled = true;
        }

        private void DisableToolTip()
        {
            GetTM.enabled = false;
        }

        public void ChangeToolTipText(string newText)
        {
            GetTM.text = newText;
        }

        public void ClearToolTip()
        {
            GetTM.text = "";
        }

        public void SetToolTipPos(Vector2 PositionRelativeToHitObj)
        {
            Vector2 shortPos = PositionRelativeToHitObj;
            GetTM.rectTransform.position = new Vector3(shortPos.x, shortPos.y);
        }

        public void WriteHoveredObjectName(GameObject HoveredObj)
        {
            GetTM.text = HoveredObj.name;
        }

        public void WriteHoveredObjectPos(GameObject HoveredObj)
        {
            string posText = "X: (" + HoveredObj.transform.position.x + ") Y: (" + HoveredObj.transform.position.y + ") Z: (" + HoveredObj.transform.position.z + ")";
            GetTM.text = posText;
        }

        public void DisplayData(GameObject HoveredObj)
        {
            string posText = "X: (" + HoveredObj.transform.position.x + ") Y: (" + HoveredObj.transform.position.y + ") Z: (" + HoveredObj.transform.position.z + ")";
            GetTM.text = HoveredObj.name + "\n" + posText;
        }
    }
}