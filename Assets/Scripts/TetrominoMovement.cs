using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class TetrominoMovement : MonoBehaviour
    {

        public float Delay = 0;
        public float StepTime = 1;


        private IEnumerator Start()
        {
            while (isActiveAndEnabled && transform.position.y >1)
            {
                yield return new WaitForSeconds(1f);
                MoveBlockDown();
            }
        }

        private void Update()
        {
           
        }

        private void OnEnable()
        {
            
        }


        private void MoveBlockDown()
        {
            transform.position += Vector3.down;
        }
    }
}
