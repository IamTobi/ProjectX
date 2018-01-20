using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Tetromino : MonoBehaviour
    {
        #region properties / attributes
        public float FallSpeed = 1;
        public bool AllowRotation = true;
        public bool LimitRotation = false;


        private Vector3 _limitedRotationVector => transform.rotation.eulerAngles.z >= 90 ? new Vector3(0, 0, -90) : new Vector3(0, 0, 90);
        private float _fall = 0;
        private enum MovementDirection
        {
            Left,
            Up,
            Right,
            Down
        }
        #endregion
        
        #region init

        private void Awake()
        {
        }

        private void Start()
        {

        }

        private void OnEnable()
        {
            EventManager.StartListening(Constants.SwipeEvents.SwipeRight, SwipeRight);
            EventManager.StartListening(Constants.SwipeEvents.SwipeLeft, SwipeLeft);
            EventManager.StartListening(Constants.SwipeEvents.SwipeDown, SwipeUp);
            EventManager.StartListening(Constants.SwipeEvents.SwipeUp, SwipeDown);
        }

        private void OnDisable()
        {
            EventManager.StopListening(Constants.SwipeEvents.SwipeRight, SwipeRight);
            EventManager.StopListening(Constants.SwipeEvents.SwipeLeft, SwipeLeft);
            EventManager.StopListening(Constants.SwipeEvents.SwipeDown, SwipeUp);
            EventManager.StopListening(Constants.SwipeEvents.SwipeUp, SwipeDown);
        }

        #endregion
        
        #region update

        private void Update()
        {
            if(Time.time - _fall >=FallSpeed)
            {
                transform.position += Vector3.down;
                
                ControlPosition(MovementDirection.Down);

                _fall = Time.time;
            }
        }

        #endregion
        
        #region events

        private void SwipeRight()
        {
            transform.position += Vector3.right;

            ControlPosition(MovementDirection.Right);
            
        }

        private void SwipeDown()
        {
            transform.position += Vector3.down;

            ControlPosition(MovementDirection.Down);
        }

        private void SwipeUp()
        {
            if(AllowRotation)
            {
                if (LimitRotation)
                {
                    transform.Rotate(_limitedRotationVector);
                }
                else
                {
                    transform.Rotate(0,0,90);
                }

                if (CheckIsValidPosition())
                {
                    GridController.Instance.UpdateGrid(this);
                }
                else
                {
                    if (LimitRotation)
                    {
                        transform.Rotate(_limitedRotationVector);
                    }
                    else
                    {
                        transform.Rotate(0, 0, -90);
                    }
                }
                
            }
        }

        private void SwipeLeft()
        {
            transform.position += Vector3.left;
            ControlPosition(MovementDirection.Left);
        }

        #endregion
        
        private void ControlPosition(MovementDirection lastMovement)
        {
            if (CheckIsValidPosition())
            {
                GridController.Instance.UpdateGrid(this);
                return;
            }

            switch (lastMovement)
            {
                case MovementDirection.Right:
                    transform.position += Vector3.left;
                    break;
                case MovementDirection.Left:
                    transform.position += Vector3.right;
                    break;
                case MovementDirection.Down:
                    transform.position += Vector3.up;
                    enabled = false;
                    GameManager.Instance.SpawnNextTetromino();
                    break;
                default:
                    break;
            }
        }

        private bool CheckIsValidPosition()
        {
            foreach (Transform mino in transform)
            {
                var pos = GridController.Instance.Round(mino.position);

                if(!GridController.Instance.CheckIsInsideGrid(pos))
                {
                    return false;
                }
                try
                {

                    if (GridController.Instance.GetTransformAtGridPosition(mino.position) != null
                        && GridController.Instance.GetTransformAtGridPosition(pos).parent != transform)
                    {
                        return false;
                    }
                }
                catch (Exception)
                {

                    throw;
                }

            }
            
            return true;
        }
    }
}
