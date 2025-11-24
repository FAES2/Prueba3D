using UnityEngine;
using UnityEngine.Android;

public class AOSPExecute : MonoBehaviour
{
    void Start()
    {
        using (AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        {
            AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
            AndroidJavaObject packageManager = currentActivity.Call<AndroidJavaObject>("getPackageManager");
            AndroidJavaObject intent = packageManager.Call<AndroidJavaObject>(
                "getLaunchIntentForPackage", "com.android.settings");

            if (intent != null)
                currentActivity.Call("startActivity", intent);
        }
    }
}
