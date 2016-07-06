using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour {
    
    public GameObject healthBar;
    private GameObject m_player;
    public Transform dialogue;
    public GameObject UI;

    public float totalPv;
    public float actualPv;
    public float damage;
    public Color colorHightHpLevel;
    public Color colorMidHpLevel;
    public Color colorLowHpLevel;

    public float maxInvincibleDelay = 1f;

    //--------------------------------
    // 2 - Rechargement
    //--------------------------------

    private float invincibleStateDelay;
    

    // Use this for initialization
    void Start () {
        ActualPv = TotalPv;
        updateBar();
        invincibleStateDelay = 0f;
        m_player = GameObject.FindGameObjectWithTag("Player");
        UI = GameObject.FindGameObjectWithTag("Interface");
    }
	
	// Update is called once per frame
	void Update () {
        if (invincibleStateDelay > 0)
        {
            invincibleStateDelay -= Time.deltaTime;
        }

    }

    public void updateBar()
    {

        Image CouleurBarre = healthBar.transform.FindChild("Mask").FindChild("sprit").GetComponent<Image>();

        if (getPourcentagePv() >= 0.5f)
        {
            CouleurBarre.color = colorHightHpLevel;
        } else if (getPourcentagePv() < 0.5f && getPourcentagePv() >= 0.15f)
        {
            CouleurBarre.color = colorMidHpLevel;
        } else {
            CouleurBarre.color = colorLowHpLevel;
        }

        healthBar.GetComponent<Scrollbar>().size = getPourcentagePv();

        healthBar.transform.FindChild("Text").GetComponent<Text>().text = ActualPv+"/"+TotalPv;

    }

    public void setDamages(float damage)
    {
        if (!isNoob)
        {
            invincibleStateDelay = maxInvincibleDelay;

            ActualPv -= damage;

            afficherFluctuationLife(false, damage);

            updateBar();

            if (healthBar.GetComponent<Scrollbar>().size <= 0)
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
        healthBar.GetComponent<Scrollbar>().size = 1;
        updateBar();
    }

    public bool isNoob
    {
        get
        {
            return !(invincibleStateDelay <= 0f);
        }
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
        // Création d'un objet copie du prefab
        var dialogueTransform = Instantiate(dialogue) as Transform;
        dialogueTransform.transform.parent = UI.transform;

        if (isHeal)
        {
            dialogueTransform.GetComponent<Text>().color = Color.green;
            dialogueTransform.GetComponent<Text>().text = "+" + value;
        } else
        {
            dialogueTransform.GetComponent<Text>().color = Color.red;
            dialogueTransform.GetComponent<Text>().text = "-" + value;
        }

        
    }
}
