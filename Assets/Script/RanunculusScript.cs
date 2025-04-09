using UnityEngine;
using UnityEngine.SceneManagement;

public class RanunculusScript : MonoBehaviour
{
    SpriteRenderer ranunculusSpriteRenderer;
    GameManager gameManager;

    // ラナンキュラスの画像2種類を格納する変数
    public Sprite ranunculus;
    public Sprite ranunculus_nega;

    void Start()
    {
        ranunculusSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (GameManager.worldState == 0)
        {
            ranunculusSpriteRenderer.sprite = ranunculus;
        }
        else if (GameManager.worldState == 1)
        {
            ranunculusSpriteRenderer.sprite = ranunculus_nega;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // タグが"Player"のオブジェクトと衝突したとき
        if (other.CompareTag("Player"))
        {
            // アイテムを保持したことを一時的に保存
            GameManager.holdRanunculus = true;

            // 自身を消す
            this.gameObject.SetActive(false);
        }
    }
}
