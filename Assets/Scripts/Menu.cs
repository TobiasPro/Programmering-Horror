using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
   public void Quit()
   {
       Application.Quit();
   }

    public void LoadLevel(int scene)
    {
        SceneManager.LoadScene(scene);
    }

}