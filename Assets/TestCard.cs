using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Networking;
using UnityEngine.UI;

public class TestCard : MonoBehaviour
{
    public string uri;
    public InputActionReference uiQuit;
    public RawImage image;

    private IEnumerator Start()
    {
        var getTexture = UnityWebRequestTexture.GetTexture(uri);
        yield return getTexture.SendWebRequest();
        if (getTexture.result == UnityWebRequest.Result.Success && getTexture.downloadHandler is DownloadHandlerTexture handler)
        {
            image.texture = handler.texture;
        }
        else
        {
            Debug.LogError(getTexture.error);
            Debug.LogError(getTexture.downloadHandler.error);
        }
    }
    
    private void OnEnable()
    {
        uiQuit.action.performed += Quit;
    }

    private void OnDisable()
    {
        uiQuit.action.performed -= Quit;
    }

    private static void Quit(InputAction.CallbackContext ctx) => Application.Quit();
}
