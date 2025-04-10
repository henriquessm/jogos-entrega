using UnityEngine;

public static class GameController
{
    private static int _collectableCount;
    private static int _hp;
    private static bool _rodando;
    private static bool _win;
    public static bool isWin => _win;

    public static bool IsRodando => _rodando;
    public static bool GameOver =>  _hp <= 0;

    public static int Coletaveis => _collectableCount;
    public static int Vida => _hp;

    public static void Init()
    {
        _rodando = true;
        _win = false;
        _collectableCount = 0;
        _hp = 5;
    }

    public static void Win()
    {
        _rodando = false;
        _win = true;
    }

    public static void PararJogo()
    {
        _rodando = false;
    }

    public static void VerificarEstado()
    {
        if (GameOver)
        {
            _rodando = false;
        }
    }

    public static void ColetarItem()
    {
        _collectableCount++;
        VerificarEstado();
    }

    public static void TomarDano()
    {
        _hp--;
        VerificarEstado();
    }
}
