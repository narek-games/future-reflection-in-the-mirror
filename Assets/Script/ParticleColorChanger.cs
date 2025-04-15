using UnityEngine;

public class ParticleColorChanger : MonoBehaviour
{
    [SerializeField] ParticleSystem particle;
    [SerializeField] Color color;
    [SerializeField] Color nega_color;

    void Update()
    {
        var main = particle.main;

        if (GameManager.worldState == 0)
        {
            main.startColor = new ParticleSystem.MinMaxGradient(color);
        }
        else if (GameManager.worldState == 1)
        {
            main.startColor = new ParticleSystem.MinMaxGradient(nega_color);
        }
    }
}
