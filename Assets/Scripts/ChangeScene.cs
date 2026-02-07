using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string _sceneNameLevel;

    [SerializeField]
    private string _tagOnTrigger = "Player";

    public void ChangeSceneButton(string sceneNameLevel) => OnChangeScene(sceneNameLevel);

    private void OnTriggerEnter(Collider other)
    {
        if (_tagOnTrigger != null && other.tag == _tagOnTrigger)
            OnChangeScene(_sceneNameLevel);
    }

    private void OnChangeScene(string sceneNameLevel)
    {
        SceneManager.LoadScene(sceneNameLevel);
    }
}
