using UnityEngine;
using TMPro;

/// <summary>
/// This Plugin is under the MIT License and was made by Arthur C.
/// (@Tutur on ksp forums)
/// </summary>
namespace LoadingTextChanger
{
    [KSPAddon(KSPAddon.Startup.EveryScene, false)]
    public class TextChanger : MonoBehaviour
    {
        //Default text
        string LoadingText = "Wasting your time..";
        
        void TextReplacer(string _loadingText)
        {
            GameObject loadingGO = GameObject.Find("Text");
            TextMeshPro t = loadingGO.GetComponent<TMPro.TextMeshPro>();
            t.text = _loadingText;
        }
        
        try
        {
            void Awake()
            {
               //Check to see if any confignodes exist
               private bool ConfigExists;
               if(GameDatabase.Instance.GetConfigs("TEXTCHANGER") != null)
               {
                    LoadingText = GameDatabase.Instance.GetConfigs("TEXTCHANGER")[0].config.GetValue("text");
               }
               else if(File.Exists(KSPUtil.ApplicationRootPath + @"/GameData/LoadingTextChanger/text.txt"))
               {
                    LoadingText = File.ReadAllText(KSPUtil.ApplicationRootPath + @"/GameData/LoadingTextChanger/text.txt");
               }
               
               TextReplacer(LoadingText);
            }
        }
    }
}
