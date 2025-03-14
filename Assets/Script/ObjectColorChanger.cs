using UnityEngine;

public class ObjectColorChanger : MonoBehaviour
{
    public GameManager gameManager;

    // 自身の初期色を保存する変数
    Color objFirstColor;

    // 自身の初期色の補色を保存する変数
    Color objCompColor;

    void Start()
    {
        objFirstColor = this.GetComponent<SpriteRenderer>().color;
        objCompColor = new Color(Mathf.Abs(objFirstColor.r - 1.0f), Mathf.Abs(objFirstColor.g - 1.0f), Mathf.Abs(objFirstColor.b - 1.0f));
    }

    void Update()
    {
        if (GameManager.worldState == 0)
        {
            this.GetComponent<SpriteRenderer>().color = objFirstColor;
        }
        else if (GameManager.worldState == 1)
        {
            this.GetComponent<SpriteRenderer>().color = objCompColor;
        }
    }
}
