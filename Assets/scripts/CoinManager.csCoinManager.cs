using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;

    [Header("Moedas")]
    [SerializeField] private TMP_Text textoMoedas;
    [SerializeField] private int totalMoedas = 10;

    [Header("Tela de Vitória")]
    [SerializeField] private GameObject painelVitoria;

    private int moedasColetadas = 0;
    private bool venceu = false;

    private void Awake()
    {
        instance = this;

        // Garante que o jogo começa rodando normalmente
        Time.timeScale = 1f;
    }

    private void Start()
    {
        AtualizarTexto();

        // Tela de vitória começa escondida
        if (painelVitoria != null)
        {
            painelVitoria.SetActive(false);
        }
    }

    public void ColetarMoeda()
    {
        // Se já venceu, não conta mais moedas
        if (venceu)
            return;

        moedasColetadas++;

        AtualizarTexto();

        // Verifica se coletou todas as moedas
        if (moedasColetadas >= totalMoedas)
        {
            Vitoria();
        }
    }

    private void AtualizarTexto()
    {
        if (textoMoedas != null)
        {
            textoMoedas.text =
                "MOEDAS: " + moedasColetadas + "/" + totalMoedas;
        }
    }

    private void Vitoria()
    {
        venceu = true;

        // Mostra a tela de vitória
        if (painelVitoria != null)
        {
            painelVitoria.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Painel_Vitoria não foi atribuído no CoinManager!");
        }

        // Congela jogador, inimigos, física etc.
        Time.timeScale = 0f;
    }
}