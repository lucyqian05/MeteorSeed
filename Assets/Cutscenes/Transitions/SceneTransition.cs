using UnityEngine;
using UnityEngine.SceneManagement; 

public class SceneTransition : MonoBehaviour
{
    public Animator animator; 

    void Start()
    {
        animator = gameObject.GetComponent<Animator>(); 
    }

    public void FadeInTransition()
    {
        
        animator.SetTrigger("FadeIn");
        

    }

    public void FadeOutTransition()
    {
        
        animator.SetTrigger("FadeOut");
        

    }

    public void LoadNextScene()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

}
