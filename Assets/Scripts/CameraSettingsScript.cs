using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraSettingsScript : MonoBehaviour {

    //showing/hiding menu
    private CanvasGroup settings;
    //scripts to disable movement of mouse when on camera settings menu
    public PlayerLook playerLookScript;
    public RayCastForward rayCastForwardScript;

    //input fields for height and distance of cameras
    public InputField ThirdDistance;
    public InputField ThirdHeight;
    public InputField OrbitDistance;
    public InputField OrbitHeight;

    //transforms to change height and distance of camera
    public Transform ThirdPivot;
    public Camera ThirdRadius;
    public Transform OrbitPivot;
    public Camera OrbitRadius;

    // Use this for initialization
    void Start () {
        //set camera settings menu transparent
        settings = GetComponent<CanvasGroup>();
        settings.alpha = 0;

        //get current height and distance values for cameras
        ThirdDistance.text = ThirdRadius.transform.position.z.ToString();
        ThirdHeight.text = ThirdPivot.position.y.ToString();
        OrbitDistance.text = OrbitRadius.transform.position.z.ToString();
        OrbitHeight.text = OrbitPivot.position.y.ToString();

	}
	
	// Update is called once per frame
	void Update () {
        //open camera settings menu
		if (Input.GetKeyDown(KeyCode.P))
        {
            //show menu and cursor and disable mouse movement in game world
            settings.alpha = 1;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            playerLookScript.enabled = false;
            rayCastForwardScript.enabled = false;
        }
    }

    public void ButtonOkPress()
    {
        //hide menu and cursor and enable scripts
        settings.alpha = 0;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        playerLookScript.enabled = true;
        rayCastForwardScript.enabled = true;

        //set new camera values
        changeThirdDistance(ThirdDistance.text);
        changeThirdHeight(ThirdHeight.text);
        changeOrbitDistance(OrbitDistance.text);
        changeOrbitHeight(OrbitHeight.text);
    }
    
    public void changeThirdHeight(string thirdHeight)
    {
        //change height of third person camera
        float fThirdHeight = float.Parse(thirdHeight);
        ThirdPivot.position = new Vector3(ThirdPivot.position.x,fThirdHeight, ThirdPivot.position.z);
    }

    public void changeThirdDistance(string thirdDistance)
    {
        //change distance from model (radius)
        float fThirdDistance = float.Parse(thirdDistance);
        ThirdRadius.transform.position = new Vector3(ThirdRadius.transform.position.x, ThirdRadius.transform.position.y, fThirdDistance);
    }

    public void changeOrbitHeight(string orbitHeight)
    {
        //change height of orbiting camera of third person camera
        float fOrbitHeight = float.Parse(orbitHeight);
        OrbitPivot.position = new Vector3(OrbitPivot.position.x, fOrbitHeight, OrbitPivot.position.z);
    }

    public void changeOrbitDistance(string orbitDistance)
    {
        //change distance from model (radius) of orbiting camera
        float fOrbitDistance = float.Parse(orbitDistance);
        OrbitRadius.transform.position = new Vector3(OrbitRadius.transform.position.x, OrbitRadius.transform.position.y, fOrbitDistance);
    }

}
