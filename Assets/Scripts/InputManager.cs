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
    public GameObject socket;
    public GameObject[] tabObjets;

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
        
        if(isToggled){
            canvas.SetActive(false);
            isToggled = false;
            foreach(GameObject objet in tabObjets){
                if(objet.transform.position == socket.transform.position)
                objet.SetActive(false);
            }
        }

        else{
            canvas.SetActive(true);
            isToggled = true;
            foreach(GameObject objet in tabObjets){
                objet.SetActive(true);
            }
        }

    }

    private void OnDisable(){
        menuToggle.action.performed -= ToggleMenu;
    }
}
