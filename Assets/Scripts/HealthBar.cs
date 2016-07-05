using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour {

    public GameObject healthBar;
    private float pourcentageDom;
    private float pourcentageHeal;
    public float TotalPv;
    public float ActualPv;
    public float damage;
    public Color colorHightHpLevel;
    public Color colorMidHpLevel;
    public Color colorLowHpLevel;

    // Use this for initialization
    void Start () {
        setColor(healthBar.GetComponent<Scrollbar>().size);
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    public void setColor(float pourcentBarHp)
    {

        Image CouleurBarre = healthBar.transform.FindChild("Mask").FindChild("sprit").GetComponent<Image>();

        if (pourcentBarHp >= 0.5f)
        {
            CouleurBarre.color = colorHightHpLevel;
        } else if (pourcentBarHp < 0.5f && pourcentBarHp >= 0.15f)
        {
            CouleurBarre.color = colorMidHpLevel;
        } else {
            CouleurBarre.color = colorLowHpLevel;
        }

    }

    public void setDamages(float damage)
    {
        pourcentageDom = damage / TotalPv;
        //Debug.Log("total hp :"+ TotalPv);
        healthBar.GetComponent<Scrollbar>().size -= pourcentageDom;

        setColor(healthBar.GetComponent<Scrollbar>().size);

        if (healthBar.GetComponent<Scrollbar>().size <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetSceneAt(0).buildIndex);
        }
    }

    public float getPv()
    {
        return TotalPv;
    }

    public void setHeal(float pvHeal)
    {
        pourcentageHeal = pvHeal / TotalPv;
        //Debug.Log("total hp :" + TotalPv);
        float lifeBar = healthBar.GetComponent<Scrollbar>().size;
        float result = lifeBar + pourcentageHeal;

        if (result > 1)
        {
            healthBar.GetComponent<Scrollbar>().size = 1;
        } else {
            healthBar.GetComponent<Scrollbar>().size = result;
        }

        setColor(healthBar.GetComponent<Scrollbar>().size);

    }

    public void upgradeTotalHp()
    {
        TotalPv += 3;
        Debug.Log(TotalPv);
        healthBar.GetComponent<Scrollbar>().size = 1;
        setColor(healthBar.GetComponent<Scrollbar>().size);
    }
}
