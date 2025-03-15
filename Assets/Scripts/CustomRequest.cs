using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

// UnityWebRequest.Get example

// Access a website and use UnityWebRequest.Get to download a page.
// Also try to download a non-existing page. Display the error.

public class CustomRequest : MonoBehaviour
{
    public string url = "";
    void Start()
    {
        // A correct website page.
        StartCoroutine(GetRequest(url));
    }

    IEnumerator GetRequest(string url)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = url.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:

                    //string jsonString = webRequest.downloadHandler.text;
                    //PostInfo postInfo = JsonUtility.FromJson<PostInfo>(jsonString);
                    //Debug.Log("Title: " + postInfo.title);

                    string jsonString = webRequest.downloadHandler.text;
                    PostsInfo postsInfo = JsonUtility.FromJson<PostsInfo>(webRequest.downloadHandler.text);
                    Debug.Log("Title: " + postsInfo.posts[0].title);
                    break;
            }
        }
    }
}