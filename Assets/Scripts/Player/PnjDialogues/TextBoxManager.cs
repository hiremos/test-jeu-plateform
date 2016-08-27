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

    private bool firstActivation = true;

    private bool isTyping = false;
    private bool cancelTyping = false;

    public float typeSpeed;


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

        //theText.text = textLines[currentLine];



        if (Input.GetKeyDown(KeyCode.A) && !firstActivation)
        {
            if (!isTyping)
            {
                currentLine += 1;
                if (currentLine > endAtLine)
                {
                    disableTextBox();
                }
                else
                {
                    StartCoroutine(TextScroll(textLines[currentLine]));
                }
            }
            else if(isTyping && !cancelTyping)
            {
                cancelTyping = true;
            }
        }

        if(firstActivation)
        {
            firstActivation = false;
        }
        
    }

    private IEnumerator TextScroll(string lineOfText)
    {
        int letter = 0;

        theText.text = "";

        isTyping = true;
        cancelTyping = false;

        while (isTyping && !cancelTyping && (letter < lineOfText.Length - 1))
        {
            theText.text += lineOfText[letter];
            letter++;
            yield return new WaitForSeconds(typeSpeed);
        }
        theText.text = lineOfText;
        isTyping = false;
        cancelTyping = false;
    }

    public void enableTextBox()
    {
        textBox.SetActive(true);
        isActive = true;
        if(stopPlayerMovement)
        {
            player.canMove = false;
        }
        firstActivation = true;


        StartCoroutine(TextScroll(textLines[currentLine]));
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
