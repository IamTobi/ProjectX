using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts
{
    /// <summary>
    /// Fade between scenes with an Image
    /// </summary>
    public class LevelManager : MonoBehaviour
    {
        #region properties
        /// <summary>
        /// Singleton Instance
        /// </summary>
        public static LevelManager Instance;

        /// <summary>
        /// Transition Time between scenes
        /// </summary>
        public float TransitionTime = 1f;

        /// <summary>
        /// Bools to test the transition manually
        /// </summary>
        public bool FadeIn;
        public bool FadeOut;

        /// <summary>
        /// The fading transitionImage
        /// </summary>
        public Image FadeImage;


        private float _time = 0f;
        #endregion


        #region init

        private void Awake()
        {
            if (Instance == null)
            {
                DontDestroyOnLoad(transform.gameObject);
                Instance = this;

                if (FadeIn)
                {
                    FadeImage.color = new Color(FadeImage.color.r,FadeImage.color.g,FadeImage.color.b,1f);

                }
                else
                {
                    Destroy(transform.gameObject);
                }
            }
        }

        private void OnEnable()
        {
            if (FadeIn)
            {
                StartCoroutine(StartScene());
            }
        }

        #endregion


        #region helpers

        public void LoadScene(string scene)
        {
            StartCoroutine(EndScene(scene));
        }

        private IEnumerator StartScene()
        {
            _time = 1f;
            yield return null;
            while (_time >= 0.0f)
            {
                FadeImage.color = new Color(FadeImage.color.r, FadeImage.color.g, FadeImage.color.b, _time);
                _time -= Time.deltaTime * (1.0f / TransitionTime);
                yield return null;
            }
            FadeImage.gameObject.SetActive(false);
        }

        private IEnumerator EndScene(string nextScene)
        {
            FadeImage.gameObject.SetActive(true);
            _time = 0.0f;
            yield return null;
            while (_time <= 1.0f)
            {
                FadeImage.color = new Color(FadeImage.color.r, FadeImage.color.g, FadeImage.color.b, _time);
                _time += Time.deltaTime * (1.0f / TransitionTime);
                yield return null;
            }
            UnityEngine.SceneManagement.SceneManager.LoadScene(nextScene, LoadSceneMode.Single);
            StartCoroutine(StartScene());
        }
        #endregion






    }
}
