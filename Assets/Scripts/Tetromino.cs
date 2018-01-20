using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Tetromino : MonoBehaviour
    {
        private enum MovementDirection
        {
            Left,
            Up,
            Right,
            Down
        }


        #region private properties

        private float _fall = 0;

        #endregion

        #region public properties
        
        public float FallSpeed = 1;

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
        }

        private void SwipeUp()
        {
            transform.Rotate(0, 0, 90);
        }

        private void SwipeLeft()
        {
            transform.position += Vector3.left;
            ControlPosition(MovementDirection.Left);
        }

        #endregion



        private void ControlPosition(MovementDirection lastMovement)
        {
            if (CheckIsValidPosition()) return;

            switch (lastMovement)
            {
                case MovementDirection.Right:
                    transform.position += Vector3.left;
                    break;
                case MovementDirection.Left:
                    transform.position += Vector3.right;
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
            }

            return true;
        }
    }
}
