using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastForward : MonoBehaviour {
    //particle effects for gun fire and object destroy
    public Transform fireEffect;
    public Transform destroyEffect;

    //3d text for score
    public TextMesh scoreText;

    //score keep track variable
    private int score;

    //sound effects for gun fire and object destroy
    private AudioSource fireSound;
    private AudioSource oophSound;

	// Use this for initialization
	void Start () {
        //instantiate score
        score = 0;
        //assign correct sounds to variables
        var sounds = GetComponents<AudioSource>();
        fireSound = sounds[0];
        oophSound = sounds[1];
	}
	
	// Update is called once per frame
	void Update () {
        //see ray of gun the whole time - outside if statement
        Debug.DrawRay(new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z), new Vector3(transform.forward.x, transform.forward.y - 0.07f, transform.forward.z) * 100, Color.green);

        //shoot gun
        if (Input.GetMouseButtonDown(0))
        {
            //fire particle emit and play sound
            var fire = Instantiate(fireEffect,transform.position, transform.rotation);
            Destroy(fire.gameObject, 1f);

            //check if ray hits any objects
            RaycastHit hit;
            Ray landingRay = new Ray(new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z), new Vector3(transform.forward.x, transform.forward.y - 0.07f, transform.forward.z));
            fireSound.Play();
            

            if (Physics.Raycast(landingRay, out hit, Mathf.Infinity))
            {
                //check if object hit is a destroyable object
                if (hit.collider.gameObject.tag == "Playground")
                {
                    //show die particle effect, play sound and destroy both particle effect and object
                    var dieEffect = Instantiate(destroyEffect, hit.collider.transform.position, hit.collider.transform.rotation);
                    Destroy(hit.collider.gameObject);
                    Destroy(dieEffect.gameObject, 3);
                    score++;
                    scoreText.text = "Score: "+score;
                    oophSound.Play();
                    
                }
            }
        }
        
	}
}
