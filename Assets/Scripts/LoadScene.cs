using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{

    [SerializeField] public GameObject instructionWindow;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void LoadJeu(){
        SceneManager.LoadScene("Jeu");
    }

    public void InstructionToggle(){
        if(instructionWindow.activeSelf){
            instructionWindow.SetActive(false);
        }

        else
        {
            instructionWindow.SetActive(true);
        }
    }
}
