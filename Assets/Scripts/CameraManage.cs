using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Cameras;

//class to manage cameras
public class CameraManage : MonoBehaviour {

    //camera game objects
    public GameObject Third;
    public GameObject First;
    public GameObject Orbit;

    /*public FreeLookCam freeLookCam;
    public PlayerLook playerLook;*/
    //cameras
    public Camera ThirdPersonCamera;
    public Camera OrbitingCamera;
    public Camera FirstPersonCamera;

    //cameras' audiolisteners
    private AudioListener ThirdPersonAudio;
    private AudioListener OrbitingAudio;
    private AudioListener FirstPersonAudio;

    //model gun parts
    public SkinnedMeshRenderer boya;
    public MeshRenderer boyaGunBody;
    public MeshRenderer boyaGunMag;
    public MeshRenderer boyaGunCube;

    //first person model gun parts
    public MeshRenderer FirstGunBody;
    public MeshRenderer FirstGunMag;
    public MeshRenderer FirstGunCube;

    // Use this for initialization
    void Start () {
        //get audio listeners
        ThirdPersonAudio = ThirdPersonCamera.GetComponent<AudioListener>();
        OrbitingAudio = OrbitingCamera.GetComponent<AudioListener>();
        FirstPersonAudio = FirstPersonCamera.GetComponent<AudioListener>();

        //set third person camera with its properties enabled
        First.SetActive(true);
        Orbit.SetActive(false);
        Third.SetActive(true);

        boya.enabled = true;
        boyaGunBody.enabled = true;
        boyaGunMag.enabled = true;
        boyaGunCube.enabled = true;
        FirstGunBody.enabled = false;
        FirstGunMag.enabled = false;
        FirstGunCube.enabled = false;
        ThirdPersonCamera.enabled = true;
        ThirdPersonAudio.enabled = true;
        OrbitingCamera.enabled = false;
        OrbitingAudio.enabled = false;
        //freeLookCam.enabled = false;
        FirstPersonCamera.enabled = false;
        FirstPersonAudio.enabled = false;
        //playerLook.enabled = false;
        
        
       
    }
	
	// Update is called once per frame
	void Update () {
        //switch to first person camera with its correct properties enabled
		if (Input.GetKeyDown(KeyCode.Alpha1) == true)
        {
            First.SetActive(true);
            Orbit.SetActive(false);
            Third.SetActive(true);
            boya.enabled = false;
            boyaGunBody.enabled = false;
            boyaGunMag.enabled = false;
            boyaGunCube.enabled = false;
            FirstGunBody.enabled = true;
            FirstGunMag.enabled = true;
            FirstGunCube.enabled = true;
            FirstPersonCamera.enabled = true;
            FirstPersonAudio.enabled = true;
            //playerLook.enabled = true;
            ThirdPersonCamera.enabled = false;
            ThirdPersonAudio.enabled = false;
            OrbitingCamera.enabled = false;
            OrbitingAudio.enabled = false;
            //freeLookCam.enabled = false;

        }
        //switch to orbiting camera with its correct properties enabled
        if (Input.GetKeyDown(KeyCode.Alpha2) == true)
        {
            Orbit.SetActive(true);
            First.SetActive(true);
            Third.SetActive(true);
            boya.enabled = true;
            boyaGunBody.enabled = true;
            boyaGunMag.enabled = true;
            boyaGunCube.enabled = true;
            FirstGunBody.enabled = false;
            FirstGunMag.enabled = false;
            FirstGunCube.enabled = false;
            OrbitingCamera.enabled = true;
            OrbitingAudio.enabled = true;
            //freeLookCam.enabled = true;
            ThirdPersonCamera.enabled = false;
            ThirdPersonAudio.enabled = false;
            FirstPersonCamera.enabled = false;
            FirstPersonAudio.enabled = false;
            //playerLook.enabled = false;
        }
        //switch to third person camera with its correct properties enabled
        if (Input.GetKeyDown(KeyCode.Alpha3) == true)
        {
            
            First.SetActive(true);
            Orbit.SetActive(false);
            Third.SetActive(true);
            boya.enabled = true;
            boyaGunBody.enabled = true;
            boyaGunMag.enabled = true;
            boyaGunCube.enabled = true;
            FirstGunBody.enabled = false;
            FirstGunMag.enabled = false;
            FirstGunCube.enabled = false;
            ThirdPersonCamera.enabled = true;
            ThirdPersonAudio.enabled = true;
            OrbitingCamera.enabled = false;
            OrbitingAudio.enabled = false;
            FirstPersonCamera.enabled = false;
            FirstPersonAudio.enabled = false;
            //freeLookCam.enabled = false;
            //playerLook.enabled = false;
        }
    }
}
