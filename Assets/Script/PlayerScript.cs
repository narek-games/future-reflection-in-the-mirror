using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameManager gameManager;

    // プレイヤーの初期色を保存する変数
    Color plaFirstColor;

    // プレイヤーの初期色の補色を保存する変数
    Color plaCompColor;

    private void Start()
    {
        plaFirstColor = this.GetComponent<SpriteRenderer>().color;
        plaCompColor = new Color(Mathf.Abs(plaFirstColor.r - 1.0f), Mathf.Abs(plaFirstColor.g - 1.0f), Mathf.Abs(plaFirstColor.b - 1.0f));
    }

    void Update()
    {
        if(GameManager.worldState == 0)
        {
            this.GetComponent<SpriteRenderer>().color = plaFirstColor;
        }
        else if(GameManager.worldState == 1)
        {
            this.GetComponent<SpriteRenderer>().color = plaCompColor;
        }

        if(gameManager.phase == 1)
        {
            // 左に移動
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                this.transform.Translate(-0.005f, 0.0f, 0.0f);
            }

            // 右に移動
            if (Input.GetKey(KeyCode.RightArrow))
            {
                this.transform.Translate(0.005f, 0.0f, 0.0f);
            }

            // 上に移動
            if (Input.GetKey(KeyCode.UpArrow))
            {
                this.transform.Translate(0.0f, 0.005f, 0.0f);
            }

            // 下に移動
            if (Input.GetKey(KeyCode.DownArrow))
            {
                this.transform.Translate(0.0f, -0.005f, 0.0f);
            }
        }
    }
}
