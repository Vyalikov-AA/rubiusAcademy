using UnityEngine.SceneManagement;

namespace Assets.Scripts.Scene2
{
    internal class ActionsWithScene2
    {
        public void RestartLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        public void StartLevel1()
        {
            SceneManager.LoadScene("Scene #1");
        }
        public void StartLevel2()
        {
            SceneManager.LoadScene("Scene #2");
        }
        public void StartLevel3()
        {
            SceneManager.LoadScene("Scene #3");
        }
    }
}
