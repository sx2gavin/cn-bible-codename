using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTextureDownloader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DownloadRenderTexture()
    {
        RenderTexture rt = GetComponent<Camera>().targetTexture;
        Texture2D texture = new Texture2D(1920, 1080, TextureFormat.RGB24, false);

        RenderTexture.active = rt;
        texture.ReadPixels(new Rect(0, 0, texture.width, texture.height), 0, 0);

        byte[] bytes = texture.EncodeToPNG();

        string cardPath = Application.dataPath + "/../card.png";
        System.IO.File.WriteAllBytes(cardPath, bytes);

    }
}
