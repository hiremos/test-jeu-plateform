using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets._2D;

public class ActivateTextAtLine : MonoBehaviour {

    public GameObject button;
    public TextAsset theText;
    public Sprite theFace;

    public int startLine;
    public int endLine;

    public TextBoxManager textBox;

    public bool requireButtonPress;
    private bool waitForPress;
    


    public bool destroyWhenActivated;

    // Use this for initialization
    void Start () {
        textBox = FindObjectOfType<TextBoxManager>();
	}
	
	// Update is called once per frame
	void Update () {
	    if(waitForPress && Input.GetKeyDown(KeyCode.A) && !textBox.isActive)
        {
            textBox.ReloadScript(theText,theFace);
            textBox.currentLine = startLine;
            textBox.endAtLine = endLine;
            textBox.enableTextBox();
            if (destroyWhenActivated)
            {
                Destroy(gameObject);
            }
        }
        if(waitForPress)
        {
            button.SetActive(!textBox.isActive);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Player")
        {
            if(requireButtonPress)
            {
                button.SetActive(true);
                waitForPress = true;
                return;
            }
            textBox.ReloadScript(theText, theFace);
            textBox.currentLine = startLine;
            textBox.endAtLine = endLine;
            textBox.enableTextBox();
            if(destroyWhenActivated)
            {
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            button.SetActive(false);
            waitForPress = false;
        }
    }
}
