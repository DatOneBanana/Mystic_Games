using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace ButtonUtil
{

    public class ButtonPress : MonoBehaviour, IPointerClickHandler
    {

        public Action ClickFunc = null;

        public Action<PointerEventData> OnPointerClickFunc;

        public virtual void OnPointerClick(PointerEventData eventData)
        {

            if (eventData.button == PointerEventData.InputButton.Left)
            {

                if (ClickFunc != null)
                {
                    ClickFunc();
                }
            }

        }

    }
}
