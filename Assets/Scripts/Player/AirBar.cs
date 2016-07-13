using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AirBar : MonoBehaviour {

    public GameObject airBar;
    public float totalAir;
    public float actualAir;

    private GameObject m_player;
    public GameObject UI;

    public Color colorAir;

    // Use this for initialization
    void Start () {
        actualAir = totalAir;
        updateBar();
        m_player = GameObject.FindGameObjectWithTag("Player");
        UI = GameObject.FindGameObjectWithTag("Interface");
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void updateBar()
    {

        Image CouleurBarre = airBar.transform.FindChild("Mask").FindChild("sprit").GetComponent<Image>();

        //Debug.Log(CouleurBarre);

        airBar.GetComponent<Scrollbar>().size = getPourcentageAir();

        CouleurBarre.color = colorAir;

        airBar.transform.FindChild("Air").GetComponent<Text>().text = actualAir + "/" + totalAir;

    }

    public float getPourcentageAir()
    {
        return (actualAir / totalAir);
    }

    public void resetAir()
    {
        actualAir = totalAir;
        updateBar();
    }

    public void loseOxygen()
    {
        actualAir -= 1;
        updateBar();

        if (actualAir <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetSceneAt(0).buildIndex);
        }
    }
}
