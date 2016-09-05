using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Gestion des points de vie et des dégâts
/// </summary>
public class EnemyManager : MonoBehaviour
{
    public Transform dialogue;

    private GameObject m_Player;

    public float totalPv;

    public bool invincibilityODT;

    public float damagesOnHit;
    /*
    public bool isBoss = false;
    public float[] bossPhases;
    */

    private float actualPv;

    void Start()
    {
        actualPv = totalPv;
    }

    public void takeDamage(int damages)
    {
        actualPv -= damages;
        afficherFluctuationLife(false, damages);
        if (actualPv <= 0)
        {
            Destroy(gameObject);
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            other.GetComponent<HealthBar>().setDamages(damagesOnHit, invincibilityODT);
        }
    }

    public void afficherFluctuationLife(bool isHeal, float value)
    {
        if (dialogue != null)
        {
            // Création d'un objet copie du prefab
            var dialogueTransform = Instantiate(dialogue) as Transform;
            dialogueTransform.transform.SetParent(null);


            float x = gameObject.transform.position.x;
            float y = gameObject.transform.position.y;
            dialogueTransform.transform.position = new Vector2(x, y);

            if (isHeal)
            {
                dialogueTransform.GetComponent<Text>().color = Color.green;
                dialogueTransform.GetComponent<Text>().text = "+" + value;
            }
            else
            {
                dialogueTransform.GetComponent<Text>().color = Color.red;
                dialogueTransform.GetComponent<Text>().text = "-" + value;
            }
        }
    }
}