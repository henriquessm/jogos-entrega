using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuActions : MonoBehaviour
{

    private GameObject endGameMenu;
    public void IniciaJogo(){
        GameController.Init();
        SceneManager.LoadScene(1);

    }

    public void Menu(){
        SceneManager.LoadScene(0);
    }
}
