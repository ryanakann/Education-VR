using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using TMPro;

public class StartHover : MonoBehaviour
{
    public float sightlength = 100f;
    public GameObject selectedObj;
    public float hoverForwardDistance = 5f;

    Ray raydirection;

    LineRenderer line;

    private void Start()
    {
        line = gameObject.AddComponent<LineRenderer>();
        line.useWorldSpace = true;
        line.startColor = Color.cyan;
        line.endColor = Color.cyan;
        line.widthMultiplier = 0.005f;
        line.numCapVertices = 32;
        line.material = new Material(Shader.Find("Unlit/Color"));
    }

    private void Update()
    {
        if (SteamVR_Input.__actions_default_in_GrabPinch.GetStateDown(SteamVR_Input_Sources.Any))
        {
            if (selectedObj.CompareTag("SubmitButton"))
            {
                SceneController.SetScene(1);
            }
            

        }
        if (SteamVR_Input.__actions_default_in_GrabGrip.GetStateDown(SteamVR_Input_Sources.Any))
        {
            if (selectedObj.CompareTag("DropDown"))
            {
                TMP_Dropdown drop = selectedObj.GetComponent<TMP_Dropdown>();
                drop.value = (drop.value + 1) % drop.options.Count;
                drop.RefreshShownValue();
            }
        }
    }
    private void FixedUpdate()
    {

        RaycastHit seen;
        raydirection = new Ray(transform.position, transform.forward);
        line.SetPositions(new Vector3[] { transform.position, transform.position + transform.forward * sightlength });

        if (Physics.Raycast(raydirection, out seen, sightlength))
        {
            line.enabled = true;
            if (seen.collider.CompareTag("SubmitButton"))
            {
                line.material.color = Color.green;
                if (selectedObj != null && selectedObj != seen.transform.gameObject)
                {
                    GameObject hitObject = seen.transform.gameObject;
                }
                selectedObj = seen.transform.gameObject;

            }
            else if (seen.collider.CompareTag("DropDown"))
            {
                line.material.color = Color.green;
                if (selectedObj != null && selectedObj != seen.transform.gameObject)
                {
                    GameObject hitObject = seen.transform.gameObject;
                }
                selectedObj = seen.transform.gameObject;

            }
            else if (seen.collider.gameObject.name.Contains("Item"))
            {
                line.material.color = Color.green;
                if (selectedObj != null && selectedObj != seen.transform.gameObject)
                {
                    GameObject hitObject = seen.transform.gameObject;
                }
                selectedObj = seen.transform.gameObject;

            }
            else
            {
                line.material.color = Color.red;
            }
        } else
        {
            line.enabled = false;
        }
    }
    private void MoveMenuButton(GameObject hitObject)
    {
        Vector3 newZ = hitObject.transform.position;
        newZ.z -= hoverForwardDistance;
        selectedObj.transform.position = newZ;

        newZ.z += hoverForwardDistance * 2;
        hitObject.transform.position = newZ;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawRay(raydirection.origin, raydirection.direction * 100);
    }
}