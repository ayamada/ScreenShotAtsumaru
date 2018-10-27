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
    private static extern void OpenSSA();

    [DllImport("__Internal")]
    private static extern void RegisterSSA();
  #endif

  public static int quality = 90;

  /* TODO: どうもunityのスクリーンショットを「即座に」返せる方法はないらしい。
   *       (なのでコルーチンを使ってスクショを取るものしかない)
   *       しかしアツマールのスクショAPIは「即座に」返せる事を前提としており、
   *       今のところはどうしようもないので、右上のスクショボタンへの
   *       対応は諦める事にした。
   */
  static IEnumerator TakeScreenShot() {
    yield return new WaitForEndOfFrame();
    #if UNITY_WEBGL && !UNITY_EDITOR
    Texture2D tex = new Texture2D(Screen.width, Screen.height);
    tex.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
    tex.Apply();
    byte[] jpg = ImageConversion.EncodeToJPG(tex, quality);
    string dataUrl = "data:image/jpeg;base64," + Convert.ToBase64String(jpg);
    MonoBehaviour.Destroy(tex);
    SetDataUrl(dataUrl);
    OpenSSA();
    #endif
  }

  public static void Reset() {
    #if UNITY_WEBGL && !UNITY_EDITOR
    SetDataUrl("data:image/jpeg;base64,/9j/4QB1RXhpZgAATU0AKgAAAAgABAEaAAUAAAABAAAATAEbAAUAAAABAAAAVAEoAAMAAAABAAIAAIdpAAQAAAABAAAAPgAAAAAAAZJ8AAcAAAARAAAAXEgAAAABAAAASAAAAAEAAABDTElQIFNUVURJTyBQQUlOVP/tACxQaG90b3Nob3AgMy4wADhCSU0D7QAAAAAAEABIAAAAAQACAEgAAAABAAL/2wBDAP//////////////////////////////////////////////////////////////////////////////////////2wBDAf//////////////////////////////////////////////////////////////////////////////////////wAARCAAQABADAREAAhEBAxEB/8QAFQABAQAAAAAAAAAAAAAAAAAAAAP/xAAUEAEAAAAAAAAAAAAAAAAAAAAA/8QAFAEBAAAAAAAAAAAAAAAAAAAAAP/EABQRAQAAAAAAAAAAAAAAAAAAAAD/2gAMAwEAAhEDEQA/AJgAAA//2Q==");
    #endif
  }

  // TODO: これを起動直後なるべく早く自動実行するようにしたい
  public static void Install() {
    #if UNITY_WEBGL && !UNITY_EDITOR
    RegisterSSA();
    Reset();
    #endif
  }

  public static void Snap(MonoBehaviour caller) {
    #if UNITY_WEBGL && !UNITY_EDITOR
    Install();
    caller.StartCoroutine(TakeScreenShot());
    #endif
  }
}
