using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField] InputActionReference menuToggle;
    private bool isToggled = true;
    public GameObject canvas;
    public List<GameObject> socket = new List<GameObject>();
    public List<GameObject> listObjets = new List<GameObject>();

    

    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnEnable()
    {
        menuToggle.action.performed += ToggleMenu;
    }


    private void ToggleMenu(InputAction.CallbackContext obj){
        

        int i = 0;

        if(isToggled){
            canvas.SetActive(false);
            isToggled = false;
            foreach(GameObject objet in listObjets){

                
                
                if(objet.transform.position == socket[i].transform.position)
                {
                    objet.SetActive(false);
                }
                
                i++;
            }
        }

        else{
            canvas.SetActive(true);
            isToggled = true;
            foreach(GameObject objet in listObjets){
                objet.SetActive(true);
            }
        }
        

    }

    private void OnDisable(){
        menuToggle.action.performed -= ToggleMenu;
    }
}
