# ScreenShotAtsumaru

unityからアツマールのスクショ機能を使うためのunityプラグインです。

***このプラグインは Unity 2021 以降向けです。 Unity 2020 以前で利用する場合は [ScreenShotAtsumaru-0.1.3](https://github.com/ayamada/ScreenShotAtsumaru/releases/tag/v0.1.3) を利用してください***

# 動作サンプル

- https://game.nicovideo.jp/atsumaru/games/gm8662?key=59c32b96956b

「ロードが完全に完了して」から、右上のカメラボタンを押したり、ゲーム内のスクショボタンを押したりしてみてください。

この動作サンプルは、このgithubリポジトリに保存されています。
丸ごと持っていけばunityから開く事ができます。


# つかいかた

1. githubのページの [releases](https://github.com/ayamada/ScreenShotAtsumaru/releases) のところからunitypackageをダウンロードして自分のプロジェクトに導入してください。

2. 可能な限り早い段階で `ScreenShotAtsumaru.Install();` を実行してください(タイトル画面のAwake内とかが望ましいです)。
    - これでスクショボタン回りの処理がインストールされ、右上のカメラボタンが機能するようになります。
    - なおInstall()実行前にカメラボタンを押されるとエラー判定が残ってしまうらしく、そうなるとInstall()実行後も動かなくなるようです。

3. ゲーム内からスクショを取得してスクショサブウィンドウを開きたい時は `ScreenShotAtsumaru.Snap();` を実行してください(※0.1.0から引数なしに変更されました)。
    - 実行してから1フレーム経過後にスクショを取得してツイート用サブウィンドウが開きます(即座ではないので注意してください)。


# 注意点

- このプラグインはアツマール側のアップデートに伴い、動かなくなる可能性が常にあります。ご了承ください。


# ライセンス

- `ScreenShotAtsumaru` 本体のライセンスはzlibライセンスとします。
    - 当ライブラリの利用時にcopyright文等を表示させる義務はありません。無表示で使えます。
    - zlibライセンスの日本語での解説は https://ja.wikipedia.org/wiki/Zlib_License 等で確認してください。
    - `ScreenShotAtsumaru` 本体以外のサンプルプロジェクト一式には外部から持ち込まれた色々が含まれています。これらについては元々のライセンスを参照してください。


# 更新情報

- v1.0.0 (2022/02/17)
    - Unity 2021.2.11f1 でのWebGLビルド実行が可能なように、dynCall回りを新しい呼び出し方法に変更
        - ※この対応によりUnity 2020以前の環境では動かなくなります。Unity 2020以前の環境で利用したい場合は↓のv0.1.3を利用してください

- v0.1.3 (2022/02/16)
    - Unity 2020.3.28f1 でWebGLビルドし実行すると `The JavaScript function 'Pointer_stringify(ptrToSomeCString)' is obsoleted and will be removed in a future Unity version. Please call 'UTF8ToString(ptrToSomeCString)' instead.` のエラーが出てスクショが取れなくなっていた問題を修正
    - サンプルプロジェクトが古い為 Unity 2020.3.28f1 で開くとあちこちおかしくなっていたのを修正(ライブラリ本体には影響なし)

- v0.1.2 (2020/02/14)
    - アツマール側の更新により、古いAPIを叩くと例外が出るようになっていたので、新しいAPIを叩くよう変更
    - API実行時に例外が出た場合も処理を続行できるようtryで囲む

- v0.1.1 (2018/11/02)
    - 非アクティブなGameObjectからコルーチンを起動しようとして失敗する事がある不具合を修正

- v0.1.0 (2018/10/31)
    - 初回リリース

- (2018/10/28)
    - とりあえずgithubに保存だけしておく。リリースではない…


