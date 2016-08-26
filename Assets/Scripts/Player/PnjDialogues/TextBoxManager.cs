using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets._2D;

public class TextBoxManager : MonoBehaviour {

    public GameObject textBox;

    public Text theText;
    public Image theImage;
    
    public TextAsset textFile;
    public Sprite imageFile;

    public string[] textLines;

    public int currentLine;
    public int endAtLine;

    public Platformer2DUserControl player;

    public bool isActive;

    public bool stopPlayerMovement;

    private bool activationButton = false;

    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<Platformer2DUserControl>();

        if (textFile != null)
        {
            textLines = (textFile.text.Split('\n'));
        }

        if(endAtLine == 0)
        {
            endAtLine = textLines.Length - 1;
        }
        if(isActive)
        {
            enableTextBox();
        }
        else
        {
            disableTextBox();
        }
    }

    void Update()
    {
        if(!isActive)
        {
            return;
        }
        theText.text = textLines[currentLine];

        if (Input.GetKeyDown(KeyCode.A) && activationButton)
        {
            currentLine+=1;
        }

        if(!activationButton)
        {
            activationButton = true;
        }
        if(currentLine > endAtLine)
        {
            disableTextBox();
        }
    }

    public void enableTextBox()
    {
        textBox.SetActive(true);
        isActive = true;
        if(stopPlayerMovement)
        {
            player.canMove = false;
        }
        activationButton = false;
    }

    public void disableTextBox()
    {
        isActive = false;
        textBox.SetActive(false);
        player.canMove = true;
    }

    public void ReloadScript(TextAsset theFile,Sprite theFace)
    {
        if(theFile != null && theFace != null)
        {
            textLines = new string[1];
            textLines = (theFile.text.Split('\n'));
            theImage.sprite = theFace;
        }
    }
}
