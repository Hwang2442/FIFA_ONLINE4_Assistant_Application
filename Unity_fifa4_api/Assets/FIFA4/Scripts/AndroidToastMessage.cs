using UnityEngine;

public class AndroidToastMessage : MonoBehaviour
{
#if UNITY_EDITOR
    private void Awake()
    {
        Destroy(gameObject);
    }
#elif UNITY_ANDROID
    public static AndroidToastMessage instance;

    AndroidJavaObject currentActivity;
    AndroidJavaClass unityPlayer;
    AndroidJavaObject context;
    AndroidJavaObject toast;

    void Awake()
    {
        if (instance == null) 
            instance = this;
        else 
            Destroy(gameObject);

        unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        context = currentActivity.Call<AndroidJavaObject>("getApplicationContext");

        DontDestroyOnLoad(gameObject);
    }

    public void ShowToast(string message)
    {
        currentActivity.Call("runOnUiThread",new AndroidJavaRunnable(() =>
        {
            AndroidJavaClass Toast = new AndroidJavaClass("android.widget.Toast");
            AndroidJavaObject javaString = new AndroidJavaObject("java.lang.String", message);

            toast = Toast.CallStatic<AndroidJavaObject>("makeText", context, javaString, Toast.GetStatic<int>("LENGTH_SHORT"));
            toast.Call("show");
        }));
    }

    public void CancelToast()
    {
        currentActivity.Call("runOnUiThread", new AndroidJavaRunnable(() => { if (toast != null) toast.Call("cancel"); }));
    }
#endif
}
