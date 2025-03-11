using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameManager gameManager;

    void Update()
    {
        if(gameManager.phase == 1)
        {
            // 左に移動
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                this.transform.Translate(-0.01f, 0.0f, 0.0f);
            }

            // 右に移動
            if (Input.GetKey(KeyCode.RightArrow))
            {
                this.transform.Translate(0.01f, 0.0f, 0.0f);
            }

            // 上に移動
            if (Input.GetKey(KeyCode.UpArrow))
            {
                this.transform.Translate(0.0f, 0.01f, 0.0f);
            }

            // 下に移動
            if (Input.GetKey(KeyCode.DownArrow))
            {
                this.transform.Translate(0.0f, -0.01f, 0.0f);
            }
        }
    }
}
