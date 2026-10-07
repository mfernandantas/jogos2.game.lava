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
    }

    private void Start()
    {
        AtualizarTexto();

        // Garante que a tela de vitória começa escondida
        if (painelVitoria != null)
        {
            painelVitoria.SetActive(false);
        }
    }

    public void ColetarMoeda()
    {
        if (venceu)
            return;

        moedasColetadas++;

        AtualizarTexto();

        // Chegou em 10 moedas
        if (moedasColetadas >= totalMoedas)
        {
            Vitoria();
        }
    }

    private void AtualizarTexto()
    {
        if (textoMoedas != null)
        {
            textoMoedas.text = "MOEDAS: " + moedasColetadas + "/" + totalMoedas;
        }
    }

    private void Vitoria()
    {
        venceu = true;

        if (painelVitoria != null)
        {
            painelVitoria.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Painel_Vitoria não foi colocado no CoinManager!");
        }
    }
}