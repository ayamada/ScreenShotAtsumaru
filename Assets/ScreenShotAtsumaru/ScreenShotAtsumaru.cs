using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Collections;
using AOT;
using UnityEngine;

public static class ScreenShotAtsumaru {
  #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void SetDataUrl(string url);

    [DllImport("__Internal")]
    private static extern void SetPtr(Action ptr);

    [DllImport("__Internal")]
    private static extern void OpenSSA();

    [DllImport("__Internal")]
    private static extern void RegisterSSA();
  #endif

  public static int quality = 90;

  /* TODO: どうもunityのスクリーンショットを「即座に」返せる方法はないらしい。
   *       (なのでコルーチンを使ってスクショを取るものしかない)
   *       しかしアツマールのスクショAPIは「即座に」返せる事を前提としており、
   *       今のところはどうしようもない…
   */
  [MonoPInvokeCallback(typeof(Action))]
  public static void GenerateDataUrl() {
    // yield return new WaitForEndOfFrame();
    // TODO: ここはコルーチンではないので、yieldはできない。
    //       そしてWaitForEndOfFrameのタイミング以外では、
    //       スクショは真っ黒にしかならないようだ…どうする？
    #if UNITY_WEBGL && !UNITY_EDITOR
    Texture2D tex = new Texture2D(Screen.width, Screen.height);
    tex.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
    tex.Apply();
    byte[] jpg = ImageConversion.EncodeToJPG(tex, quality);
    string dataUrl = "data:image/jpeg;base64," + Convert.ToBase64String(jpg);
    MonoBehaviour.Destroy(tex);
    SetDataUrl(dataUrl);
    #endif
  }

  // TODO: これを起動直後なるべく早く自動実行するようにしたい
  public static void Install() {
    #if UNITY_WEBGL && !UNITY_EDITOR
    SetPtr(GenerateDataUrl);
    RegisterSSA();
    #endif
  }

  public static void Snap(MonoBehaviour caller) {
    #if UNITY_WEBGL && !UNITY_EDITOR
    Install();
    OpenSSA();
    #endif
  }
}
