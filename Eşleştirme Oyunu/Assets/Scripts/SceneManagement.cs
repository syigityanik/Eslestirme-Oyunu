using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public void BolumYukle(string yukleBolum)
    {
        SceneManager.LoadScene(yukleBolum);
    }






    public void QuitGame()
    {
        Debug.Log("Çıktınız");
        Application.Quit();

    }






}
