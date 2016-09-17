using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour {
    
    public Image healthBar;
    public Text textePv;

    public Transform dialogue;

    public float totalPv;
    public float actualPv;
    public float damage;
    public Color colorHightHpLevel;
    public Color colorMidHpLevel;
    public Color colorLowHpLevel;

    void Start () {
        ActualPv = TotalPv;
        updateBar();
        
    }

    public void updateBar()
    {
        if(healthBar != null && textePv != null)
        {
            if (getPourcentagePv() >= 0.5f)
            {
                healthBar.color = colorHightHpLevel;
            }
            else if (getPourcentagePv() < 0.5f && getPourcentagePv() >= 0.15f)
            {
                healthBar.color = colorMidHpLevel;
            }
            else
            {
                healthBar.color = colorLowHpLevel;
            }

            healthBar.fillAmount = getPourcentagePv();
            textePv.text = ActualPv + "/" + TotalPv;
        }
    }

    public void setDamages(float damage)
    {
        if (!GetComponent<EffectsManager>().effets[GetComponent<EffectsManager>().Invincible].actif)
        {
            ActualPv -= damage;

            afficherFluctuationLife(false, damage);

            updateBar();

            if (actualPv <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetSceneAt(0).buildIndex);
            }
        }
    }

    public float getPourcentagePv()
    {
        return (ActualPv / TotalPv);
    }

    public void setHeal(float pvHeal)
    {

        ActualPv += pvHeal;

        afficherFluctuationLife(true, pvHeal);

        if (ActualPv > TotalPv)
        {
            ActualPv = TotalPv;
        }

        updateBar();

    }

    public void upgradeTotalHp()
    {
        TotalPv += 3;
        ActualPv = TotalPv;
        updateBar();
    }

    public float TotalPv
    {
        get
        {
            return totalPv;
        }

        set
        {
            totalPv = value;
        }
    }

    public float ActualPv
    {
        get
        {
            return actualPv;
        }

        set
        {
            actualPv = value;
        }
    }

    public void afficherFluctuationLife(bool isHeal, float value)
    {
        if (dialogue != null)
        {
            // Création d'un objet copie du prefab
            var dialogueTransform = Instantiate(dialogue) as Transform;
            dialogueTransform.transform.SetParent(healthBar.transform);


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
