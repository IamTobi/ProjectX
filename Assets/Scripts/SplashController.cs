using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class SplashController : MonoBehaviour
    {

        public int WaitForSeconds = 3;
        public int StartLevelIndex = 1;

        void Start()
        {
            StartCoroutine(LoadStart());
        }


        private IEnumerator LoadStart()
        {
            yield return new WaitForSeconds(WaitForSeconds);

            LevelManager.Instance.LoadScene("01_start");
        }
    }
}
