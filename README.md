# ScreenShotAtsumaru

unityからアツマールのスクショ機能を使うためのunityプラグインです。


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

- このプラグインはexperimentalなAPIを叩いています。これについては「そのうち別名の同機能APIが別に用意されて、そちらが正式版になる」という話を聞いています。その際にはこのプラグインも更新などする可能性があります。


# ライセンス

- `ScreenShotAtsumaru` 本体のライセンスはzlibライセンスとします。
    - 当ライブラリの利用時にcopyright文等を表示させる義務はありません。無表示で使えます。
    - zlibライセンスの日本語での解説は https://ja.wikipedia.org/wiki/Zlib_License 等で確認してください。
    - `ScreenShotAtsumaru` 本体以外のサンプルプロジェクト一式には外部から持ち込まれた色々が含まれています。これらについては元々のライセンスを参照してください。


# 更新情報

- v0.1.2 (2020/02/14)
    - アツマール側の更新により、古いAPIを叩くと例外が出るようになっていたので、新しいAPIを叩くよう変更
    - API実行時に例外が出た場合も処理を続行できるようtryで囲む

- v0.1.1 (2018/11/02)
    - 非アクティブなGameObjectからコルーチンを起動しようとして失敗する事がある不具合を修正

- v0.1.0 (2018/10/31)
    - 初回リリース

- (2018/10/28)
    - とりあえずgithubに保存だけしておく。リリースではない…


