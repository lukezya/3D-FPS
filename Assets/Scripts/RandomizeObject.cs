using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeObject : MonoBehaviour {

    //no of objects to spawn into world
    public int noObjects;

    //prefabs of different possible spawning objects
    public GameObject[] prefabs;

    //possible materials to assign to spawned prefabs
    public Material[] materials;

    //y values of spawning object transforms
    private float[] yvalues;

    //keep track of instantiated objects to change material
    private GameObject[] instantiated;

	// Use this for initialization
	void Start () {
        //create empty array for instantiated objects
        instantiated = new GameObject[noObjects];

        //instantiate yvalues
        yvalues = new float[5];
        yvalues[0] = 0.5f;
        yvalues[1] = 1f;
        yvalues[2] = 0.5f;
        yvalues[3] = 0.5f;
        yvalues[4] = 0.5f;
        
        //spawn random objects with random materials
        for (int i = 0; i < noObjects; i++)
        {
            //random chosen prefab and material at random position
            int prefabChosen = Random.Range(0,prefabs.Length);
            int materialChosen = Random.Range(0, materials.Length);
            Vector3 position;
            do
            {
                position = new Vector3(Random.Range(-49, 49), yvalues[prefabChosen], Random.Range(-49, 49));
            } while (Physics.OverlapSphere(position, 0.49f).Length > 0);

            instantiated[i]=Instantiate(prefabs[prefabChosen]) as GameObject;
            instantiated[i].transform.position = position;
            Renderer rend = instantiated[i].GetComponent<Renderer>();
            rend.enabled = true;
            rend.sharedMaterial = materials[materialChosen];
            
        }
	}
}
