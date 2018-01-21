using UnityEngine;

namespace Assets.Scripts
{
    public class VectorExtension : MonoBehaviour
    {
        public static Vector2 RoundVector2(Vector2 vector)
        {
            return new Vector2(Mathf.Round(vector.x), Mathf.Round(vector.y));
        }
    }
}
