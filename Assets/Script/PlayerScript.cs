using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameManager gameManager;

    SpriteRenderer playerSpriteRenderer;

    // プレイヤーの画像8種類を格納する変数
    public Sprite front;
    public Sprite back;
    public Sprite left;
    public Sprite right;
    public Sprite front_nega;
    public Sprite back_nega;
    public Sprite left_nega;
    public Sprite right_nega;

    private void Start()
    {
        playerSpriteRenderer= gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(GameManager.phase == 0)
        {
            // 世界の状態によって見た目変更
            if (GameManager.worldState == 0)
            {
                playerSpriteRenderer.sprite = front;
            }
            else if (GameManager.worldState == 1)
            {
                playerSpriteRenderer.sprite = front_nega;
            }
        }
        else if(GameManager.phase == 1)
        {
            // 左に移動
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                // 世界の状態によって見た目変更
                if(GameManager.worldState == 0)
                {
                    playerSpriteRenderer.sprite = left;
                }
                else if(GameManager.worldState == 1)
                {
                    playerSpriteRenderer.sprite = left_nega;
                }
                this.transform.Translate(-0.005f, 0.0f, 0.0f);
            }

            // 右に移動
            if (Input.GetKey(KeyCode.RightArrow))
            {
                // 世界の状態によって見た目変更
                if (GameManager.worldState == 0)
                {
                    playerSpriteRenderer.sprite = right;
                }
                else if (GameManager.worldState == 1)
                {
                    playerSpriteRenderer.sprite = right_nega;
                }
                this.transform.Translate(0.005f, 0.0f, 0.0f);
            }

            // 上に移動
            if (Input.GetKey(KeyCode.UpArrow))
            {
                // 世界の状態によって見た目変更
                if (GameManager.worldState == 0)
                {
                    playerSpriteRenderer.sprite = back;
                }
                else if (GameManager.worldState == 1)
                {
                    playerSpriteRenderer.sprite = back_nega;
                }
                this.transform.Translate(0.0f, 0.005f, 0.0f);
            }

            // 下に移動
            if (Input.GetKey(KeyCode.DownArrow))
            {
                // 世界の状態によって見た目変更
                if (GameManager.worldState == 0)
                {
                    playerSpriteRenderer.sprite = front;
                }
                else if (GameManager.worldState == 1)
                {
                    playerSpriteRenderer.sprite = front_nega;
                }
                this.transform.Translate(0.0f, -0.005f, 0.0f);
            }
        }
    }
}
