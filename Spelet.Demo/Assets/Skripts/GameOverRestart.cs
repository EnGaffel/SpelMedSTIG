using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverRestart : MonoBehaviour {

    private bool enableRestart = false;

    void Start()
    {
        Debug.Log("Restart set to false");
        enableRestart = false;
    }

    void OnEnable()
    {
        StartCoroutine(WaitForRestart());
    }

	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
          SceneManager.LoadScene("SampleScene");
         }

        if (enableRestart && Input.anyKey)
        {
            SceneManager.LoadScene("SampleScene");
        }
	}
    
    IEnumerator WaitForRestart()
    {
        yield return new WaitForSeconds(3);
        enableRestart = true;
    }
}
