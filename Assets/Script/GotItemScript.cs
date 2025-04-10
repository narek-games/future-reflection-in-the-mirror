using UnityEngine;
using UnityEngine.UI;

public class GotItemScript : MonoBehaviour
{
    public int thisNum;
    Color gotColor = new Color32(255, 255, 255, 255);

    void Start()
    {
        
    }

    void Update()
    {
        if (GameManager.gotRanunculus[thisNum - 1] == true)
        {
            this.GetComponent<SpriteRenderer>().color = gotColor;
        }
    }
}
