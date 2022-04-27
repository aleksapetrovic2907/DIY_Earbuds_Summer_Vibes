using UnityEngine;
using UnityEngine.EventSystems;

public enum Swipes
{ Up, Down, Left, Right }

namespace Aezakmi
{
    public class InputManager : MonoBehaviour
    {
        public static InputManager current;

        private void Awake()
        {
            if (current != this)
                current = this;
        }

        [HideInInspector] public bool IsTouching { get { return Input.touchCount > 0; } }
        [HideInInspector] public bool IsClickingUI;
        // [HideInInspector] public bool IsTouchingRotateArea;
        [HideInInspector] public Touch Touch;

        [HideInInspector] public Vector2 StartPosition;
        [HideInInspector] public Vector2 EndPosition;
        [HideInInspector] public Vector2 MoveDelta; // the amount the finger has moved since last frame

        // [SerializeField] private RectTransform _rotateArea;

        [SerializeField] public Swipes? SwipeDirection = null;

        private void Update()
        {
            if (IsTouching)
            {
                Touch = Input.touches[0];
                IsClickingUI = EventSystem.current.IsPointerOverGameObject(Touch.fingerId) && Touch.phase == TouchPhase.Began;

                if (!IsClickingUI)
                {
                    DetectTouchPositions();
                    DetectFingerMove();
                }
            }
        }

        private void DetectTouchPositions()
        {
            if (Touch.phase == TouchPhase.Began)
                StartPosition = Touch.position;

            if (Touch.phase == TouchPhase.Ended)
            {
                EndPosition = Touch.position;
                DetectSwipes();
                MoveDelta = Vector2.zero;
            }
        }

        private void DetectFingerMove()
        {
            if (Touch.phase == TouchPhase.Moved)
                MoveDelta = Touch.deltaPosition;
        }

        private void DetectSwipes()
        {
            Vector2 swipeDirection = (EndPosition - StartPosition).normalized;

            float positiveX = Mathf.Abs(swipeDirection.x);
            float positiveY = Mathf.Abs(swipeDirection.y);

            if (positiveX > positiveY)
            {
                SwipeDirection = (swipeDirection.x > 0) ? Swipes.Right : Swipes.Left;
            }
            else
            {
                SwipeDirection = (swipeDirection.y > 0) ? Swipes.Up : Swipes.Down;
            }
        }
    }
}
