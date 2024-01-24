using UnityEngine;

public class TriggerCutscene : MonoBehaviour
{
    [SerializeField]
    public GameObject _cutscene; 

    public void TriggerCutsceneButton()
    {

        _cutscene.SetActive(true); 

    }



}
