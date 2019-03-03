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
        print("Dropdown: " + dropdown.options.Count);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Plus) || Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            dropdown.value = (dropdown.value + 1) % dropdown.options.Count;
            dropdown.RefreshShownValue();
        }
        else if (Input.GetKeyDown(KeyCode.Minus) || Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            dropdown.value = (dropdown.value == 0 ? dropdown.options.Count - 1 : dropdown.value - 1); 
            dropdown.RefreshShownValue();
        }

        SessionManager.language = dropdown.options[dropdown.value].text;
        SessionManager.langCode = SessionManager.languageMap[SessionManager.language];
    }
}
