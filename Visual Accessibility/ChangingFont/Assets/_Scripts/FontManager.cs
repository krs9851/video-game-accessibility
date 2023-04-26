using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FontManager : MonoBehaviour
{
    private List<TextMeshProUGUI> textProElements;
    private List<Text> textElements;

    [SerializeField]
    private TMP_FontAsset[] fontsPro;
    [SerializeField]
    private Font[] fonts;

    private int chosenFont;

    private void Awake()
    {
        textProElements = new List<TextMeshProUGUI>();
        textElements = new List<Text>();
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            GameObject[] parentObjects = SceneManager.GetSceneAt(i).GetRootGameObjects();
            foreach(GameObject parent in parentObjects)
            {
                textProElements.AddRange(parent.GetComponentsInChildren<TextMeshProUGUI>(true));
                textElements.AddRange(parent.GetComponentsInChildren<Text>(true));
            }
        }

        ChangeFont(0);
    }

    public void ChangeFont(int fontNum)
    {
        chosenFont = fontNum;
        foreach(TextMeshProUGUI textProElement in textProElements)
        {
            textProElement.font = fontsPro[fontNum];
        }
        foreach(Text textElement in textElements)
        {
            textElement.font = fonts[fontNum];
        }
    }

    public void Register(GameObject gameObject)
    {
        foreach (TextMeshProUGUI textMeshPro in gameObject.GetComponentsInChildren<TextMeshProUGUI>(true))
        {
            textMeshPro.font = fontsPro[chosenFont];
        }
        foreach(Text text in gameObject.GetComponentsInChildren<Text>(true))
        {
            text.font = fonts[chosenFont];
        }

        textProElements.AddRange(gameObject.GetComponentsInChildren<TextMeshProUGUI>(true));
        textElements.AddRange(gameObject.GetComponentsInChildren<Text>(true));
    }

}
