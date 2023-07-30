using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebOpener : MonoBehaviour
{
    private const string _uRL = "https://doc-hosting.flycricket.io/neon-ping-pong-privacy-policy/4eeb8007-98fe-4b5f-bbc8-60578e7b6c6b/privacy";

    public void OpenUrl()
    {
        Application.OpenURL(_uRL);
    }
}
