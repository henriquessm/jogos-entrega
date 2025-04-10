using UnityEngine;
using TMPro;

public class HpBar : MonoBehaviour
{
    public TextMeshProUGUI hpTexto;

    void Update()
    {
        if (hpTexto != null)
        {
            int hp = Mathf.Max(GameController.Vida, 0);
            hpTexto.text = "Vida: " + hp.ToString("00");
        }
    }
}
