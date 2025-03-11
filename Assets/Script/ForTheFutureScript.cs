using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForTheFutureScript : MonoBehaviour
{
    public GameManager gameManager;

    public void OnPushedButton()
    {
        // 移動フェーズに移行
        gameManager.phase = 1;
    }

    private void Update()
    {
        // 一度押したら消える(移動フェーズからは不可逆)
        if(gameManager.phase == 1)
        {
            this.gameObject.SetActive(false);
        }
    }
}
