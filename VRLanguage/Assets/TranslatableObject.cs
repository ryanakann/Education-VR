using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniLang;

public class TranslatableObject : MonoBehaviour
{
    public string originalName;
    public string translatedName;
    public TranslatedTextPair pair;

    // Start is called before the first frame update
    void Start()
    {
        originalName = gameObject.name;

        SessionManager.translator.Run(originalName, results => {
            foreach (var result in results)
                translatedName += result.translated;
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
