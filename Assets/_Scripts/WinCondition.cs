using UnityEngine;
using TMPro;
using System.Collections;

public class WinCondition : MonoBehaviour
{ 
    public TextMeshProUGUI WinConditionText;

    public GameObject exitDoor; 

    private bool painelAtivado = false;

    void FixedUpdate()
    {
        if (GameController.Coletaveis >= 10 && !painelAtivado)
        {
            painelAtivado = true;

            if (WinConditionText != null)
            {
                WinConditionText.gameObject.SetActive(true);
                exitDoor.SetActive(true);

                StartCoroutine(DesativarPainelAposTempo(5f)); 
                

            }
        }
       
    }
    IEnumerator DesativarPainelAposTempo(float tempo)
    {
        yield return new WaitForSeconds(tempo);
        WinConditionText.gameObject.SetActive(false);
    }
}
