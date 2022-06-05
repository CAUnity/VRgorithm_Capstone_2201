using UnityEngine;
using UnityEngine.SceneManagement;

namespace VRInteract
{
    public class ClearUI : MonoBehaviour
    {
        public void SetActive(bool on)
        {
            gameObject.SetActive(on);
        }

        public void ReLoadScene()
        {
            SceneManager.LoadScene(SceneId.InGame);
        }
        public void ToMainMenu()
        {
            SceneManager.LoadScene(SceneId.Title);
        }
    }
}