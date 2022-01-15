using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using FIFA4;

public class Temp : MonoBehaviour
{
    public Image image;

    private IEnumerator Start()
    {
        yield return null;

        using (UnityWebRequest www = UnityWebRequest.Head(APIList.GetPlayerActionImageFromSpid(101000001)))
        {
            yield return www.SendWebRequest();

            Debug.Log(System.DateTime.Parse(www.GetResponseHeader("Last-Modified")));

            //Texture2D texture = DownloadHandlerTexture.GetContent(www);
            //image.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        }
    }
}
