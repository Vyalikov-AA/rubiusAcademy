using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    internal class ActionsWithTheScene
    {
        public void RestartLevel()
        {
            SceneManager.LoadScene("SampleScene");
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
