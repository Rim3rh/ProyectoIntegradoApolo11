using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeInFadeOut : MonoBehaviour
{
    //public Animator fadeAnim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance._playerHealth <= 0)
        {
            int sceneBuildIndex = SceneManager.GetActiveScene().buildIndex;

            if(sceneBuildIndex == 0)
            {
                StartCoroutine(ChangeToSceneB());
            }
            else
            {
                StartCoroutine(ChangeToSceneA());
            }
        }
    }
    
    IEnumerator ChangeToSceneB()
    {
        GameManager.Instance.fadeAnim.SetTrigger("exit");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(1);
    }

    IEnumerator ChangeToSceneA()
    {
        GameManager.Instance.fadeAnim.SetTrigger("exit");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(0);
    }
    
}
