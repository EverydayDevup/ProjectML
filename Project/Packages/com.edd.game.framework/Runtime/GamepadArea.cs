using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.OnScreen;

namespace EDD
{
    public class GamepadArea : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        [SerializeField] private OnScreenStick screenStick;
        [SerializeField] private RectTransform gamepadRect;

        public void OnPointerDown(PointerEventData eventData)
        {
            if (eventData == null)
                throw new System.ArgumentNullException(nameof(eventData));
            
            RectTransformUtility.ScreenPointToLocalPointInRectangle(gamepadRect, eventData.position, eventData.pressEventCamera,
                out var pointerDown);
            
            gamepadRect.anchoredPosition = pointerDown;
            screenStick.OnPointerDown(eventData);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            screenStick.OnPointerUp(eventData);
            gamepadRect.anchoredPosition = Vector2.zero;
            
            EventMessenger.Broadcast((int)EEventType.GamepadOnRelease);
        }

        public void OnDrag(PointerEventData eventData)
        {
            screenStick.OnDrag(eventData);
        }
    }
}
