using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] Star[] _stars;
    [SerializeField] Star[] _endStars;

    int _starLooted;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        Victory();
    }

    private void Victory()
    {
        for (int i = 0; i < _starLooted; i++)
        {
            _endStars[i].IsLooted = true;
        }
       
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void Retry()
    {
        Debug.Log("Retry");
    }

    public void Loot()
    {
        _stars[_starLooted].IsLooted = true;
        _starLooted++;
    }

   
}
