using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FontManager : MonoBehaviour
{
    //List of all text and text mesh pro elements present in all loaded scenes
    private List<TextMeshProUGUI> textProElements;
    private List<Text> textElements;

    //The array of fonts that you will input in the editor
    [SerializeField]
    private TMP_FontAsset[] fontsPro;
    [SerializeField]
    private Font[] fonts;

    //The index of the chosen font
    private int chosenFont;

    private void Awake()
    {
        //Initialize the chosen font to an index of 0
        chosenFont = 0;

        SceneChange();
    }

    public void SceneChange()
    {
        //Make new lists because the scene has changed
        textProElements = new List<TextMeshProUGUI>();
        textElements = new List<Text>();

        //For each scene
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            //Get all root game objects
            GameObject[] parentObjects = SceneManager.GetSceneAt(i).GetRootGameObjects();

            //For each root game object 
            foreach (GameObject parent in parentObjects)
            {
                //Get all text and text mesh pro child components, even those that are inactive
                textProElements.AddRange(parent.GetComponentsInChildren<TextMeshProUGUI>(true));
                textElements.AddRange(parent.GetComponentsInChildren<Text>(true));
            }
        }

        //Change the font to the chosen font for all text and text mesh pro elements
        ChangeFont(chosenFont);
    }

    //This function is called by the dropdown to change the font
    public void ChangeFont(int fontNum)
    {
        //Store the new font in chosenFont
        chosenFont = fontNum;

        //For each text mesh pro element in all loaded scenes
        foreach(TextMeshProUGUI textProElement in textProElements)
        {
            if(textProElement != null)
            {
                textProElement.font = fontsPro[fontNum];
            }
           
        }

        //For each text element in all loaded scenes
        foreach(Text textElement in textElements)
        {
            if(textElement != null)
            {
                textElement.font = fonts[fontNum];
            }
            
        }
    }

    //This function is called when an object containing text or text mesh pro is spawned into a loaded scene
    public void Register(GameObject gameObject)
    {
        //For each text mesh pro child components, even those that are inactive
        foreach (TextMeshProUGUI textMeshPro in gameObject.GetComponentsInChildren<TextMeshProUGUI>(true))
        {
            //Change the font to the chosen font
            textMeshPro.font = fontsPro[chosenFont];
        }

        //For each text child components, even those that are inactive
        foreach (Text text in gameObject.GetComponentsInChildren<Text>(true))
        {
            //Change the font to the chosen font
            text.font = fonts[chosenFont];
        }

        //Add all of the text and text mesh pro elements to the list
        textProElements.AddRange(gameObject.GetComponentsInChildren<TextMeshProUGUI>(true));
        textElements.AddRange(gameObject.GetComponentsInChildren<Text>(true));
    }

}
