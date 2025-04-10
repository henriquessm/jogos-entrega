using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public TextMeshProUGUI ScoreTexto;
    public TextMeshProUGUI TimerTexto;

    public float TempoAtual { get; private set; } = 0f;
    private bool rodando = true;

    void Update()
    {
        if (rodando)
        {
            TempoAtual += Time.deltaTime;
            AtualizarUI();
        }
    }

    void AtualizarUI()
    {
        int segundos = Mathf.FloorToInt(TempoAtual % 60);
        int minutos = Mathf.FloorToInt(TempoAtual / 60 % 60);

        if (TimerTexto != null)
            TimerTexto.text = string.Format("{0:00}:{1:00}", minutos, segundos);

        if (ScoreTexto != null)
        {
            int coletaveis = GameController.Coletaveis;
            int total = coletaveis * 100;
            ScoreTexto.text = "Pontuação: " + total;
        }
    }

    public void PararTimer()
    {
        rodando = false;
    }
}
