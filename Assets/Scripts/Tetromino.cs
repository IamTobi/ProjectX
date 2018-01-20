using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Tetromino : MonoBehaviour
    {

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
        }

        #endregion


        #region helpers

        private void MoveBlockDown()
        {
            transform.position += Vector3.down;
        }

        #endregion
    }
}
