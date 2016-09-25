using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class StartController : MonoBehaviour {

        public void LoadLevel(string levelToLoad)
        {
           LevelManager.Instance.LoadScene(levelToLoad);
        }
    }
}
