using UnityEngine;

namespace Assets.Scripts
{
    public class GridController : MonoBehaviour
    {
        #region singleton implementation
        private static GridController _instance;

        public static GridController Instance
        {
            get { return _instance; }
        }
        #endregion

        #region properties / attributes
        public static int GridHeight = 20;
        public static int GridWidth = 10;
        #endregion


        #region start

        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                _instance = this;
            }
        }

        private void Start()
        {

        }
        #endregion
        #region update

        #endregion
        
        public bool CheckIsInsideGrid(Vector2 pos)
        {
            return ((int)pos.x >= 0 && (int)pos.x < GridWidth && (int)pos.y >= 0);
        }

        public Vector2 Round(Vector2 pos)
        {
            return new Vector2(Mathf.Round(pos.x), Mathf.Round(pos.y));
        }

    }
}
