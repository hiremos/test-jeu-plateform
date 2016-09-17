using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AirBar : MonoBehaviour {

    public Image airBar;
    public Text texteAir;
    
    public float totalAir;
    public float actualAir;
    public Color colorAir;

    // Use this for initialization
    void Start () {
        actualAir = totalAir;
        airBar.color = colorAir;
        updateBar();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void updateBar()
    {
        if (airBar != null && texteAir != null)
        {
            airBar.fillAmount = getPourcentageAir();
            texteAir.text = actualAir + "/" + totalAir;
        }
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

    public void loseOxygen(int quantity)
    {
        actualAir -= quantity;
        updateBar();
    }
}
