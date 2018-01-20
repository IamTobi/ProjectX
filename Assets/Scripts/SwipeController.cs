using UnityEngine;

namespace Assets.Scripts
{
    public class SwipeController : MonoBehaviour
    {
        private Vector2 _currentSwipe;

        private Vector2 _firstPressPosition;
        private Vector2 _secondPressPosition;
        
        private void Update()
        {
            GetTouchSwipe();
            GetMouseSwipe();

        }

        private void GetMouseSwipe()
        {
            if (Input.GetMouseButtonDown(0))
            {
                //save began touch 2d point
                _firstPressPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            }
            if (Input.GetMouseButtonUp(0))
            {
                //save ended touch 2d point
                _secondPressPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

                GetSwipeDirection();
                
            }
        }
        
        private void GetTouchSwipe()
        {
            if (Input.touches.Length <= 1) return;

            var t = Input.GetTouch(0);

            if (t.phase == TouchPhase.Began)
                _firstPressPosition = new Vector2(t.position.x, t.position.y);

            if (t.phase == TouchPhase.Ended)
            {
                _secondPressPosition = new Vector2(t.position.x, t.position.y);

               GetSwipeDirection();
            }
        }

        private void GetSwipeDirection()
        {
            //create vector from the two points
            _currentSwipe = new Vector2(_secondPressPosition.x - _firstPressPosition.x, _secondPressPosition.y - _firstPressPosition.y);

            //normalize the 2d vector
            _currentSwipe.Normalize();

            //swipe up
            if (_currentSwipe.y > 0 && _currentSwipe.x > -0.5f && _currentSwipe.x < 0.5f)
            {
                Debug.Log("up swipe");
                EventManager.TriggerEvent(Constants.SwipeEvents.SwipeDown);
            }
            // swipe down
            if (_currentSwipe.y < 0 && _currentSwipe.x > -0.5f && _currentSwipe.x < 0.5f)
            {
                Debug.Log("down swipe");
                EventManager.TriggerEvent(Constants.SwipeEvents.SwipeUp);
            }
            // swipe left
            if (_currentSwipe.x < 0 && _currentSwipe.y > -0.5f && _currentSwipe.y < 0.5f)
            {
                Debug.Log("left swipe");
                EventManager.TriggerEvent(Constants.SwipeEvents.SwipeLeft);
            }
            // swipe right
            if (_currentSwipe.x > 0 && _currentSwipe.y > -0.5f && _currentSwipe.y < 0.5f)
            {
                Debug.Log("right swipe");
                EventManager.TriggerEvent(Constants.SwipeEvents.SwipeRight);
            }
        }
    }
}