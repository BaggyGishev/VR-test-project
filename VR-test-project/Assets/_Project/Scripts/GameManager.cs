using UnityEngine;
using UnityEngine.XR;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        XRSettings.gameViewRenderMode = GameViewRenderMode.LeftEye;
    }
}