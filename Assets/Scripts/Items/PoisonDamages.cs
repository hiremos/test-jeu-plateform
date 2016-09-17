using UnityEngine;
using System.Collections;

public class PoisonDamages : MonoBehaviour
{

    public int damages = 2;
    public float delaiDeReaplicationDuPoison = 1.0f;
    public float timerApplication;
    public float dureePoisonApplique;

    void Start()
    {
        timerApplication = 0f;
        Destroy(gameObject, 20);
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void setDamages(int nDamages)
    {
        damages = nDamages;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<EffectsManager>() != null)
        {
            other.GetComponent<EffectsManager>().ableEffect(other.GetComponent<EffectsManager>().Poison, dureePoisonApplique);
            timerApplication = delaiDeReaplicationDuPoison;

            other.GetComponent<EffectsManager>().effets[other.GetComponent<EffectsManager>().Poison].degatsDeLEffet = damages;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.GetComponent<EffectsManager>() != null)
        {
            if (timerApplication > 0)
            {
                timerApplication -= Time.deltaTime;
            }
            if (timerApplication <= 0)
            {
                other.GetComponent<EffectsManager>().ableEffect(other.GetComponent<EffectsManager>().Poison, dureePoisonApplique);
                timerApplication = delaiDeReaplicationDuPoison;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<EffectsManager>() != null)
        {
            timerApplication = 0f;
        }
    }
}
