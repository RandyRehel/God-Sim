using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR.Interaction.Toolkit.Utilities;
using UnityEngine.XR.Interaction.Toolkit.Utilities.Pooling;

namespace UnityEngine.XR.Interaction.Toolkit
{
public class Inventaire_UI_Gestion : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject env;
    public GameObject vivant;
    public GameObject reccomencer;
    public GameObject objet;
    
    public List<GameObject> despawnList = new List<GameObject>();
    public List<GameObject> respawnList = new List<GameObject>();

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonEnv()
    {
        
        
        
        env.SetActive(true);
        vivant.SetActive(false);
        reccomencer.SetActive(false);
        objet.SetActive(false);


        List<GameObject> envList = new List<GameObject>();
        envList.AddRange(GameObject.FindGameObjectsWithTag("env"));
        List<GameObject> vivantList = new List<GameObject>();
        vivantList.AddRange(GameObject.FindGameObjectsWithTag("vivant"));
        List<GameObject> objList = new List<GameObject>();
        objList.AddRange(GameObject.FindGameObjectsWithTag("objet"));
        List<GameObject> reccomencerList = new List<GameObject>();
        reccomencerList.AddRange(GameObject.FindGameObjectsWithTag("reccomencer"));

        
        respawnList.AddRange(envList);
        despawnList.AddRange(vivantList);
        despawnList.AddRange(objList);
        despawnList.AddRange(reccomencerList);
        
        buttonEffect(despawnList, respawnList);

        objList.Clear();
        envList.Clear();
        vivantList.Clear();
        reccomencerList.Clear();
        despawnList.Clear();
        respawnList.Clear();
        
    }

    public void ButtonVivant()
    {
        env.SetActive(false);
        vivant.SetActive(true);
        reccomencer.SetActive(false);
        objet.SetActive(false);

        List<GameObject> envList = new List<GameObject>();
        envList.AddRange(GameObject.FindGameObjectsWithTag("env"));
        List<GameObject> vivantList = new List<GameObject>();
        vivantList.AddRange(GameObject.FindGameObjectsWithTag("vivant"));
        List<GameObject> objList = new List<GameObject>();
        objList.AddRange(GameObject.FindGameObjectsWithTag("objet"));
        List<GameObject> reccomencerList = new List<GameObject>();
        reccomencerList.AddRange(GameObject.FindGameObjectsWithTag("reccomencer"));

        despawnList.AddRange(envList);
        respawnList.AddRange(vivantList);
        despawnList.AddRange(objList);
        despawnList.AddRange(reccomencerList);
        
        buttonEffect(despawnList, respawnList);

        objList.Clear();
        envList.Clear();
        vivantList.Clear();
        reccomencerList.Clear();
        despawnList.Clear();
        respawnList.Clear();
    }

    public void ButtonReccomencer()
    {
        env.SetActive(false);
        vivant.SetActive(false);
        reccomencer.SetActive(true);
        objet.SetActive(false);

        List<GameObject> envList = new List<GameObject>();
        envList.AddRange(GameObject.FindGameObjectsWithTag("env"));
        List<GameObject> vivantList = new List<GameObject>();
        vivantList.AddRange(GameObject.FindGameObjectsWithTag("vivant"));
        List<GameObject> objList = new List<GameObject>();
        objList.AddRange(GameObject.FindGameObjectsWithTag("objet"));
        List<GameObject> reccomencerList = new List<GameObject>();
        reccomencerList.AddRange(GameObject.FindGameObjectsWithTag("reccomencer"));

        despawnList.AddRange(envList);
        despawnList.AddRange(vivantList);
        despawnList.AddRange(objList);
        respawnList.AddRange(reccomencerList);
        
        buttonEffect(despawnList, respawnList);

        objList.Clear();
        envList.Clear();
        vivantList.Clear();
        reccomencerList.Clear();
        despawnList.Clear();
        respawnList.Clear();

    }

    public void ButtonObjet()
    {
        env.SetActive(false);
        vivant.SetActive(false);
        reccomencer.SetActive(false);
        objet.SetActive(true);
        
        List<GameObject> envList = new List<GameObject>();
        envList.AddRange(GameObject.FindGameObjectsWithTag("env"));
        List<GameObject> vivantList = new List<GameObject>();
        vivantList.AddRange(GameObject.FindGameObjectsWithTag("vivant"));
        List<GameObject> objList = new List<GameObject>();
        objList.AddRange(GameObject.FindGameObjectsWithTag("objet"));
        List<GameObject> reccomencerList = new List<GameObject>();
        reccomencerList.AddRange(GameObject.FindGameObjectsWithTag("reccomencer"));

        respawnList.AddRange(objList);
        despawnList.AddRange(vivantList);
        despawnList.AddRange(envList);
        despawnList.AddRange(reccomencerList);
        
        buttonEffect(despawnList, respawnList);

        objList.Clear();
        envList.Clear();
        vivantList.Clear();
        reccomencerList.Clear();
        despawnList.Clear();
        respawnList.Clear();
    }

    public void buttonEffect(List<GameObject> despawnList, List<GameObject> respawnList)
    {
        foreach(GameObject despawn in despawnList)
        {
            
            
            if(despawn.GetComponent<variables>().isSocketed)
            {
                despawn.GetComponent<XRGrabInteractable>().enabled = false;
                if(despawn.GetComponent<MeshRenderer>() != null)
                {
                    Renderer mesh = despawn.GetComponent<MeshRenderer>();
                    mesh.enabled = false;
                }

                if(despawn.GetComponentsInChildren<MeshRenderer>() != null)
                {

                
                    List<Renderer> childrenMesh = new List<Renderer>();
                    childrenMesh.AddRange(despawn.GetComponentsInChildren<MeshRenderer>());
                   
                    foreach(Renderer childMesh in childrenMesh)
                    {
                        childMesh.enabled = false;
                    }
                }
                
            }
        }

        foreach(GameObject respawn in respawnList)
        {
            respawn.GetComponent<XRGrabInteractable>().enabled = true;
            if(respawn.GetComponent<MeshRenderer>() != null)
            {
                Renderer mesh = respawn.GetComponent<MeshRenderer>();
                mesh.enabled = true;
            }
            List<Renderer> childrenMesh = new List<Renderer>();
            if(respawn.GetComponentsInChildren<MeshRenderer>() != null)
            {
                childrenMesh.AddRange(respawn.GetComponentsInChildren<MeshRenderer>());
                foreach(Renderer childMesh in childrenMesh)
                {
                        childMesh.enabled = true;
                }
            }
            
        }
    }
}
}