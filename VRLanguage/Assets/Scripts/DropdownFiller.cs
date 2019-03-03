using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DropdownFiller : MonoBehaviour
{
    TMP_Dropdown dropdown;

    // Start is called before the first frame update
    void Start()
    {
        dropdown = GetComponent<TMP_Dropdown>();
        dropdown.ClearOptions();
        dropdown.AddOptions(new List<string>(SessionManager.languageMap.Keys));
        dropdown.RefreshShownValue();
    }

    // Update is called once per frame
    void Update()
    {
        SessionManager.language = dropdown.options[dropdown.value].text;
        SessionManager.langCode = SessionManager.languageMap[SessionManager.language];
    }
}
