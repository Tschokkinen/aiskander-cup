using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField]private Button restart;
    [SerializeField]private string currentScene;

    // Start is called before the first frame update
    void Start()
    {
        restart = GameObject.Find("Restart").GetComponent<Button>();

        restart.onClick.AddListener(delegate{Button(0);});

        currentScene = SceneManager.GetActiveScene().name;
        Debug.Log(currentScene);
    }

    // Update is called once per frame
    void Button(int idx)
    {
        switch (idx)
        {
            case 0:
                Debug.Log("Restart");
                SceneManager.LoadScene(currentScene);
            break;
        }
    }
}
