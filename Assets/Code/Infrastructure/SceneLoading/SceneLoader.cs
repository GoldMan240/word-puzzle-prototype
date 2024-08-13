using UnityEngine.SceneManagement;

namespace Code.Infrastructure.SceneLoading
{
    public class SceneLoader
    {
        public static void LoadScene(Scene scene)
        {
            SceneManager.LoadScene(scene.ToString());
        }
    }
}