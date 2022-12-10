using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class FruitManager : MonoBehaviour
{
    int actualScene;

    public Text fruitCollected;

    private void Start()
    {
        actualScene = SceneManager.GetActiveScene().buildIndex;
    }

    private void Update()
    {
        AllFruitsCollected();
    }

    public void AllFruitsCollected()
    {
        if (transform.childCount == 0)
        {
            Debug.Log(actualScene);
            fruitCollected.gameObject.SetActive(true);
            PlayerPrefs.DeleteAll();

            Invoke("ChangeScene", 1f);

        }
    }

    public void ChangeScene()
    {
        if (actualScene <= SceneManager.sceneCount)
            {
                int nextScene = ++actualScene;
                SceneManager.LoadScene(nextScene);
            }
            else
            {
                Debug.Log("No hay mas niveles");
            }
    }
}
