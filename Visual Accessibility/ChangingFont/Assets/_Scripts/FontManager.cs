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
    }

    public void ChangeFont(int fontNum)
    {
        foreach(TextMeshProUGUI textProElement in textProElements)
        {
            textProElement.font = fontsPro[fontNum];
        }
        foreach(Text textElement in textElements)
        {
            textElement.font = fonts[fontNum];
        }
    }
}
