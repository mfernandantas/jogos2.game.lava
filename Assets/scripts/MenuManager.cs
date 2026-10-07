using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("Como Jogar")]
    [SerializeField] private GameObject painelComoJogar;

    public void Jogar()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void AbrirComoJogar()
    {
        painelComoJogar.SetActive(true);
    }

    public void FecharComoJogar()
    {
        painelComoJogar.SetActive(false);
    }

    public void VoltarMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}