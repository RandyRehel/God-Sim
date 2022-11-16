using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GestionUiInscription : MonoBehaviour
{
    public string nomDujoueur;
    public TMP_InputField inputNom ;
    
    public void ActivationBouton()
    {
        nomDujoueur = inputNom.text;
        print("Bonjour " + nomDujoueur);
    }
}
