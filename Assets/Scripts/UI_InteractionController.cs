using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using System;
/*
 * Description générale
 * Script simple qui permet de gérer deux contrôleurs sur une même main. Un contrôleur de base et un controleur pour les UI.
 * Mathieu Dionne
 * Dernière modifications : 16 septembre 2021
 */
public class UI_InteractionController : MonoBehaviour
{
    // Le controleur pour les UI
    [SerializeField]
    GameObject UIControleur;
    // Le controleur de base
    [SerializeField]
    GameObject BaseControleur;

    // L'action qui déclence le switch de controleur
    [SerializeField]
    InputActionReference inputActionSwitch;

    // Permet de savoir le canvas est actif ou non
    bool canvasActif = false;

    // Le canvas
    [SerializeField]
    GameObject leCanvas;

  
    // À l'activation du script, ajout de la fonction ActiveControleurUI lorsque l'action est faite
    private void OnEnable()
    {
        inputActionSwitch.action.performed += ActiveControleurUI;
    }

    // À la désactivation du script, on retire la fonction ActiveControleurUI lorsque l'action est faite
    private void OnDisable()
    {
        inputActionSwitch.action.performed -= ActiveControleurUI;
    }

    private void Start()
    {
        //Désactivation du canvas au départ
        if (leCanvas !=null)
        {
            leCanvas.SetActive(false);
        }

        //Désactivation des components du controleur UI
        UIControleur.GetComponent<XRRayInteractor>().enabled = false;
        UIControleur.GetComponent<XRInteractorLineVisual>().enabled = false;
    }

    // Lorsque l'action associée au controlleur UI est faite par le joueur (bouton par exemple)
    private void ActiveControleurUI(InputAction.CallbackContext obj)
    {
        // Si canvas inactif, on l'active ainsi que les composants du controleur de UI.
        // On désactive le composant du controleur de base
        if (!canvasActif)
        {
            canvasActif = true;

            UIControleur.GetComponent<XRRayInteractor>().enabled = true;
            UIControleur.GetComponent<XRInteractorLineVisual>().enabled = true;

            if (BaseControleur.GetComponent<XRDirectInteractor>() != null)
            {
                BaseControleur.GetComponent<XRDirectInteractor>().enabled = false;
            }

            leCanvas.SetActive(true);
        }
        else
        // Si canvas actif, on le désactive ainsi que les composants du controleur de UI.
        // On active le composant du controleur de base
        {
            canvasActif = false;

            UIControleur.GetComponent<XRRayInteractor>().enabled = false;
            UIControleur.GetComponent<XRInteractorLineVisual>().enabled = false;

            if(BaseControleur.GetComponent<XRDirectInteractor>() != null)
            {
                BaseControleur.GetComponent<XRDirectInteractor>().enabled = true;
            }
            

            leCanvas.SetActive(false);
        }

    }
}
