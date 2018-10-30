using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Collections;
using AOT;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class ScreenShotAtsumaru {
  #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void Resolve(string dataUrl);

    [DllImport("__Internal")]
    private static extern void SetPtr(Action ptr);

    [DllImport("__Internal")]
    private static extern void OpenSSA();

    [DllImport("__Internal")]
    private static extern void RegisterSSA();
  #endif

  public static int quality = 90;

  private static string MakeScreenShotDataUrl() {
    Texture2D tex = new Texture2D(Screen.width, Screen.height);
    tex.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
    tex.Apply();
    byte[] jpg = ImageConversion.EncodeToJPG(tex, quality);
    string dataUrl = "data:image/jpeg;base64," + Convert.ToBase64String(jpg);
    MonoBehaviour.Destroy(tex);
    return dataUrl;
  }

  public static string fallbackDataUrl = "data:image/jpeg;base64,/9j/4QB1RXhpZgAATU0AKgAAAAgABAEaAAUAAAABAAAATAEbAAUAAAABAAAAVAEoAAMAAAABAAIAAIdpAAQAAAABAAAAPgAAAAAAAZJ8AAcAAAARAAAAXEgAAAABAAAASAAAAAEAAABDTElQIFNUVURJTyBQQUlOVP/tACxQaG90b3Nob3AgMy4wADhCSU0D7QAAAAAAEABIAAAAAQACAEgAAAABAAL/2wBDAP//////////////////////////////////////////////////////////////////////////////////////2wBDAf//////////////////////////////////////////////////////////////////////////////////////wAARCAAQABADAREAAhEBAxEB/8QAFQABAQAAAAAAAAAAAAAAAAAAAAP/xAAUEAEAAAAAAAAAAAAAAAAAAAAA/8QAFAEBAAAAAAAAAAAAAAAAAAAAAP/EABQRAQAAAAAAAAAAAAAAAAAAAAD/2gAMAwEAAhEDEQA/AJgAAA//2Q==";

  static IEnumerator TakeScreenShot() {
    yield return new WaitForEndOfFrame();
    string dataUrl = MakeScreenShotDataUrl();
    #if UNITY_WEBGL && !UNITY_EDITOR
    Resolve(dataUrl);
    #else
    Debug.Log(dataUrl);
    #endif
  }

  class ScreenShotCoroutine : MonoBehaviour {
  }

  [MonoPInvokeCallback(typeof(Action))]
  public static void GenerateDataUrlLater() {
    GameObject[] gos = SceneManager.GetActiveScene().GetRootGameObjects();
    if (0 == gos.Length) {
      #if UNITY_WEBGL && !UNITY_EDITOR
      Resolve(fallbackDataUrl);
      #else
      Debug.Log(fallbackDataUrl);
      #endif
    }
    else {
      ScreenShotCoroutine ssc = gos[0].GetComponent<ScreenShotCoroutine>();
      if (ssc == null) {
        ssc = gos[0].AddComponent<ScreenShotCoroutine>();
      }
      ssc.StartCoroutine(TakeScreenShot());
    }
  }

  // TODO: これを起動直後なるべく早く自動実行するようにしたい
  public static void Install() {
    #if UNITY_WEBGL && !UNITY_EDITOR
    SetPtr(GenerateDataUrlLater);
    RegisterSSA();
    #endif
  }

  public static void Snap() {
    #if UNITY_WEBGL && !UNITY_EDITOR
    Install();
    OpenSSA();
    #else
    GenerateDataUrlLater();
    #endif
  }
}
