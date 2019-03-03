using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SessionManager : MonoBehaviour
{
    public static SessionManager instance;

    public static string language;
    public static string langCode;

    public static Dictionary<string, string> languageMap;
    public string[] languages;
    public string[] langCodes;

    // Start is called before the first frame update
    void Awake()
    {
        language = "English";
        langCode = "en";

        if (instance == null)
        {
            instance = this;
        } else
        {
            Destroy(this);
        }

        DontDestroyOnLoad(gameObject);


        languageMap = new Dictionary<string, string>
             {
                 { "English", "en" },
                 { "French", "fr" },
                 { "German", "de" },
                 { "Dutch", "nl" },
                 { "Greek", "el" },
                 { "Hebrew", "iw" },
                 { "Hindi", "hi" },
                 { "Indonesian", "id" },
                 { "Italian", "it" },
                 { "Japanese", "ja" },
                 { "Korean", "ko" },
                 { "Chinese", "zh-CN" },
                 { "Latin", "la" },
                 { "Polish", "pl" },
                 { "Portuguese", "pt" },
                 { "Russian", "ru" },
                 { "Spanish", "sv" },
                 { "Urdu", "ur" },
             };
    }

    // Update is called once per frame
    void Update()
    {
        print(language + "\t" + langCode);
    }
}
