using UnityEngine;
namespace Assets.Scripts
{
    public enum InputMethod
    {
        KeyboardInput,
        MouseInput,
        TouchInput
    }

    public class PlayerInputManager : MonoBehaviour
    {
        public bool isActive;
        public InputMethod inputType;

        void Awake()
        {

        }

        void Update()
        {
            if (isActive)
            {
                if (inputType == InputMethod.KeyboardInput)
                    KeyboardInput();
                else if (inputType == InputMethod.MouseInput)
                    MouseInput();
                else if (inputType == InputMethod.TouchInput)
                    TouchInput();
            }
        }

        #region KEYBOARD
        void KeyboardInput()
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.UpArrow))
                Managers.GameManager.CurrentTetromino.MovementController.RotateClockWise(false);
            else if (Input.GetKeyDown(KeyCode.D))
                Managers.GameManager.CurrentTetromino.MovementController.RotateClockWise(true);

            if (Input.GetKeyDown(KeyCode.LeftArrow))
                Managers.GameManager.CurrentTetromino.MovementController.MoveHorizontal(Vector2.left);
            else if (Input.GetKeyDown(KeyCode.RightArrow))
                Managers.GameManager.CurrentTetromino.MovementController.MoveHorizontal(Vector2.right);
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (Managers.GameManager.CurrentTetromino != null)
                {
                    isActive = false;
                    Managers.GameManager.CurrentTetromino.MovementController.InstantFall();
                }
            }
        }
        #endregion

        #region MOUSE
        Vector2 _startPressPosition;
        Vector2 _endPressPosition;
        Vector2 _currentSwipe;
        float _buttonDownPhaseStart;
        public float tapInterval;

        void MouseInput()
        {
            if (Input.GetMouseButtonDown(0))
            {
                //save began touch 2d point
                _startPressPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                _buttonDownPhaseStart = Time.time;
            }

            if (Input.GetMouseButtonUp(0))
            {
                if (Time.time - _buttonDownPhaseStart > tapInterval)
                {
                    //save ended touch 2d point
                    _endPressPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

                    //create vector from the two points
                    _currentSwipe = new Vector2(_endPressPosition.x - _startPressPosition.x, _endPressPosition.y - _startPressPosition.y);

                    //normalize the 2d vector
                    _currentSwipe.Normalize();

                    //swipe left
                    if (_currentSwipe.x < 0 && _currentSwipe.y > -0.5f && _currentSwipe.y < 0.5f)
                    {
                        Managers.GameManager.CurrentTetromino.MovementController.MoveHorizontal(Vector2.left);
                    }
                    //swipe right
                    if (_currentSwipe.x > 0 && _currentSwipe.y > -0.5f && _currentSwipe.y < 0.5f)
                    {
                        Managers.GameManager.CurrentTetromino.MovementController.MoveHorizontal(Vector2.right);
                    }

                    //swipe down
                    if (_currentSwipe.y < 0 && _currentSwipe.x > -0.5f && _currentSwipe.x < 0.5f)
                    {
                        if (Managers.GameManager.CurrentTetromino != null)
                        {
                            isActive = false;
                            Managers.GameManager.CurrentTetromino.MovementController.InstantFall();
                        }
                    }
                }
                else
                {
                    if (_startPressPosition.x < Screen.width / 2)
                        Managers.GameManager.CurrentTetromino.MovementController.RotateClockWise(false);
                    else
                        Managers.GameManager.CurrentTetromino.MovementController.RotateClockWise(true);
                }
            }
        }
        #endregion

        #region TOUCH
        void TouchInput()
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    _startPressPosition = touch.position;
                    _endPressPosition = touch.position;
                    _buttonDownPhaseStart = Time.time;
                }
                if (touch.phase == TouchPhase.Moved)
                {
                    _endPressPosition = touch.position;

                }
                if (touch.phase == TouchPhase.Ended)
                {
                    if (Time.time - _buttonDownPhaseStart > tapInterval)
                    {
                        //save ended touch 2d point
                        _endPressPosition = new Vector2(touch.position.x, touch.position.y);

                        //create vector from the two points
                        _currentSwipe = new Vector2(_endPressPosition.x - _startPressPosition.x, _endPressPosition.y - _startPressPosition.y);

                        //normalize the 2d vector
                        _currentSwipe.Normalize();

                        //swipe left
                        if (_currentSwipe.x < 0 && _currentSwipe.y > -0.5f && _currentSwipe.y < 0.5f)
                        {
                            Managers.GameManager.CurrentTetromino.MovementController.MoveHorizontal(Vector2.left);
                        }
                        //swipe right
                        if (_currentSwipe.x > 0 && _currentSwipe.y > -0.5f && _currentSwipe.y < 0.5f)
                        {
                            Managers.GameManager.CurrentTetromino.MovementController.MoveHorizontal(Vector2.right);
                        }

                        //swipe down
                        if (_currentSwipe.y < 0 && _currentSwipe.x > -0.5f && _currentSwipe.x < 0.5f)
                        {
                            if (Managers.GameManager.CurrentTetromino != null)
                            {
                                isActive = false;
                                Managers.GameManager.CurrentTetromino.MovementController.InstantFall();
                            }
                        }
                    }
                    else /*if (_currentSwipe.x + _currentSwipe.y< 0.5f */
                    {
                        if (_startPressPosition.x < Screen.width / 2)
                            Managers.GameManager.CurrentTetromino.MovementController.RotateClockWise(false);
                        else
                            Managers.GameManager.CurrentTetromino.MovementController.RotateClockWise(true);
                    }
                }
            }

        }
        #endregion
    }
}
