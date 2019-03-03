using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

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
            if (selectedObj.CompareTag("Button"))
            {
                SceneController.SetScene(1);
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
            if (seen.collider.CompareTag("Button"))
            {
                line.material.color = Color.green;
                if (selectedObj != null && selectedObj != seen.transform.gameObject)
                {
                    GameObject hitObject = seen.transform.gameObject;
                    MoveMenuButton(hitObject);
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