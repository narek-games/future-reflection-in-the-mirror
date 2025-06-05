using UnityEngine;

public class EndMirrorScript : MonoBehaviour
{
    GameObject TrueEndEvent;

    private void Start()
    {
        TrueEndEvent = GameObject.Find("TrueEndEvent");
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        TrueEndEvent.GetComponent<TrueEndScript>().clear = true;
    }
}
