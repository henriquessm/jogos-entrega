using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject EndGamePanel;
    public GameObject SuccessPanel;
    public TextMeshProUGUI FinalTimeText;
    public GameTimer GameTimer;

    private bool painelAtivado = false;

    void FixedUpdate()
    {
        if (GameController.GameOver && !painelAtivado)
        {
            painelAtivado = true;
            EndGamePanel.SetActive(true);

            if (GameTimer != null && FinalTimeText != null)
            {
                GameTimer.PararTimer();

                int segundos = Mathf.FloorToInt(GameTimer.TempoAtual % 60);
                int pontuacao = GameController.Coletaveis * 100 - segundos * 10;
                pontuacao = Mathf.Max(pontuacao, 0); 

                FinalTimeText.text = $"Pontuação final: {pontuacao}";
            }
        }
        if(!GameController.IsRodando && GameController.isWin && !painelAtivado)
        {
            if (GameTimer != null && FinalTimeText != null)
            {
                GameTimer.PararTimer();
                SuccessPanel.SetActive(true);

                int segundos = Mathf.FloorToInt(GameTimer.TempoAtual % 60);
                int pontuacao = GameController.Coletaveis * 100 - segundos * 10;
                pontuacao = Mathf.Max(pontuacao, 0); 

                FinalTimeText.text = $"Pontuação final: {pontuacao}";
            }
        }
    
        
    }
}
