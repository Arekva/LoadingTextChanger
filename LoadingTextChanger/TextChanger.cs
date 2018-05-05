using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        void Awake()
        {
            List<String> texts = new List<String>();
            foreach (ConfigNode node in GameDatabase.Instance.GetConfigs("LoadingTextChanger").Select(c => c.config))
            {
                foreach (String text in node.GetValues("text"))
                {
                    texts.Add(text);
                }
            }
            
            if (texts.Count > 0)
            {
                string LoadingText = texts[new System.Random().Next(0, texts.Count)];
                        
                GameObject loadingGO = GameObject.Find("Text");
                TextMeshPro t = loadingGO.GetComponent<TMPro.TextMeshPro>();
                t.text = LoadingText;
            }
        }
    }
}
