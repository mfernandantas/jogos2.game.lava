using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("Como Jogar")]
    [SerializeField] private GameObject painelComoJogar;

    // Botão JOGAR do menu inicial
    public void Jogar()
    {
        // Garante que o jogo não esteja pausado
        Time.timeScale = 1f;

        SceneManager.LoadScene("SampleScene");
    }

    // Abre o card COMO JOGAR
    public void AbrirComoJogar()
    {
        if (painelComoJogar != null)
        {
            painelComoJogar.SetActive(true);
        }
    }

    // Fecha o card COMO JOGAR
    public void FecharComoJogar()
    {
        if (painelComoJogar != null)
        {
            painelComoJogar.SetActive(false);
        }
    }

    // Botão JOGAR NOVAMENTE da tela de vitória
    public void VoltarMenu()
    {
        // Descongela antes de trocar de cena
        Time.timeScale = 1f;

        SceneManager.LoadScene("Menu");
    }
}