using TMPro;
using UnityEngine;

public class CounterTextScript : MonoBehaviour
{
    TextMeshProUGUI thisText;
    void Start()
    {
        thisText = this.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (this.gameObject.tag.Equals("VMirror"))
        {
            thisText.text = "×" + GameObject.FindGameObjectWithTag("VMCounter").GetComponent<MirrorCounterScript>().maxMirror;
        }
        else if (this.gameObject.tag.Equals("HMirror"))
        {
            thisText.text = "×" + GameObject.FindGameObjectWithTag("HMCounter").GetComponent<MirrorCounterScript>().maxMirror;
        }
        else if (this.gameObject.tag.Equals("LDRUMirror"))
        {
            thisText.text = "×" + GameObject.FindGameObjectWithTag("LDRUMCounter").GetComponent<MirrorCounterScript>().maxMirror;
        }
        else if (this.gameObject.tag.Equals("LURDMirror"))
        {
            thisText.text = "×" + GameObject.FindGameObjectWithTag("LURDMCounter").GetComponent<MirrorCounterScript>().maxMirror;
        }
    }
}
