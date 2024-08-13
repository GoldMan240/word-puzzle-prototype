using UnityEngine;

namespace Code.Gameplay.UI
{
    public class WindowBase : MonoBehaviour
    {
        public void Open() => 
            gameObject.SetActive(true);

        public void Close() => 
            gameObject.SetActive(false);
    }
}