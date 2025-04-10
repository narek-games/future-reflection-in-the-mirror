using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoToStageScript : MonoBehaviour
{
    public int goToStageNum = 0;
    public string changeScene;
    Color unlookedColor = new Color32(248, 181, 0, 255);

    void Start()
    {
    
    }

    void Update()
    {
        if (GameManager.unlookedStage[goToStageNum - 1] == true)
        {
            this.GetComponent<Image>().color = unlookedColor;            
        }
    }

    public void OnPushedButton()
    {
        if (GameManager.unlookedStage[goToStageNum - 1] == true)
        {
            // éwíËÉVÅ[ÉìÇÃì«Ç›çûÇ›
            SceneManager.LoadScene(changeScene);
        }      
    }
}
