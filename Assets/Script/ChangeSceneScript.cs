using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneScript : MonoBehaviour
{
    public string changeScene;

    public void OnPushedButton()
    {
        // 指定シーンの読み込み
        SceneManager.LoadScene(changeScene);
    }
}
