# フォルダー再編 TODO

このメモは、`4_フォルダー構成案.md` を実際の作業順に落としたものです。  
学習用プロジェクトなので、**一度に全部変えず、読める状態を保ちながら進める**方針にします。


## ゴール

次の状態に近づけることを目標にします。

- 将棋そのものの概念は `Domain`
- USI の規約は `Protocols\Usi`
- アプリの処理の流れは `Application`
- 表示は `Presentation` または `Views`
- 設定やログは `Infrastructure`


## 方針

この再編では、次の 3 つを守るのが大事です。

1. **名前変更だけの回**と**処理変更の回**を混ぜない
2. 毎段階で**ビルドが通る状態**を保つ
3. 一度に広く触らず、**小さな単位で完了**させる


## おすすめの作業順

### STEP 0. 先にドキュメントを置く

- [x] `4_フォルダー構成案.md` を作る
- [x] この `5_フォルダー再編TODO.md` を作る
- [ ] README からも辿れるようにするか決める

目的:

- 先に言葉を決めておく
- 後から見て「なぜその変更をしたか」が分かるようにする


### STEP 1. `Core` の中で、USI ではないものを見分ける

まずは**移動せずに分類だけする**のが安全です。

候補:

- 将棋そのもの
    - `MuzPositionModel`
    - `MuzBoardModel`
    - `MuzHandStandCollectionModel`
    - `MuzKomaType`
    - `MuzMasuType`
    - `MuzSujiType`
    - `MuzDanType`
    - `MuzColorType`
- USI 寄り
    - `ProgramCommands.cs` 内の `usi`、`isready`、`go`、`position`

TODO:

- [ ] `Core\Usi\...` 配下のファイルを一覧で分類する
- [ ] 「将棋そのもの」と「USI依存」をメモに書く


### STEP 2. `Domain` フォルダーを作る

この段階では、まだ全部は移しません。  
まずは行き先だけ作ります。

候補:

```text
Domain/
└─ Shogi/
   ├─ Coordinates/
   ├─ Turns/
   ├─ Position/
   ├─ Board/
   ├─ Hands/
   └─ Pieces/
```

TODO:

- [ ] `Domain\Shogi` の下位フォルダー案を確定する
- [ ] namespace 方針を決める

namespace 例:

- `KifuwarabeShogiCSharp.Domain.Shogi.Position`
- `KifuwarabeShogiCSharp.Domain.Shogi.Board`
- `KifuwarabeShogiCSharp.Domain.Shogi.Coordinates`


### STEP 3. 一番安全な型から `Domain` へ移す

最初は依存の少ないものから動かすと追いやすいです。

おすすめ順:

1. `Suji`, `Dan`, `Masu` などの座標系
2. `Color`
3. `Koma`
4. `HandStandCollection`
5. `Board`
6. `Position`

TODO:

- [ ] `MuzSujiType.cs` を `Domain` 側へ移す
- [ ] `MuzDanType.cs` を `Domain` 側へ移す
- [ ] `MuzMasuType.cs` を `Domain` 側へ移す
- [ ] `MuzSujiHelper.cs` を `Domain` 側へ移す
- [ ] `MuzDanHelper.cs` を `Domain` 側へ移す
- [ ] using / namespace を更新する
- [ ] ビルド確認する
- [ ] テスト確認する

メモ:

- 1 回の変更で 1～3 ファイル程度に抑えると追いやすい
- まとめて全部やらない方がよい


### STEP 4. `Board` と `Position` を `Domain` へ移す

ここからは依存が少し増えます。  
なので 1 セット終わるごとにビルド確認を入れます。

TODO:

- [ ] `MuzHandStandCollectionModel.cs` を移す
- [ ] `MuzHandStandCollectionModelReadonly.cs` を移す
- [ ] `MuzBoardModel.cs` を移す
- [ ] `MuzBoardModelReadonly.cs` を移す
- [ ] `MuzPositionModel.cs` を移す
- [ ] `MuzPositionModelReadonly.cs` を移す
- [ ] using / namespace を更新する
- [ ] ビルド確認する
- [ ] テスト確認する


### STEP 5. 表示用モデルの置き場を決める

`Models\MuzCoreModelReadonly.cs` は、名前だけだと役割が少し分かりにくいです。  
表示向けなら、次のどちらかに寄せると読みやすいです。

- `Presentation\ViewModels`
- `Presentation\Models`

TODO:

- [ ] `MuzCoreModelReadonly` の役割を一文で書く
- [ ] View 専用モデルなら `Presentation` 側へ移す
- [ ] 名前を変えるか検討する

候補名:

- `MuzPositionScreenModelReadonly`
- `MuzPositionViewModel`


### STEP 6. `Views` を `Presentation` に寄せるか決める

今の `Views` は十分分かりやすいです。  
学習用なら、**無理に変えなくてもよい**です。

判断基準:

- シンプルさ重視 → `Views` のまま
- 層の説明を重視 → `Presentation\Views`

TODO:

- [ ] `Views` のままにするか決める
- [ ] もし寄せるなら `MuzPositionView.cs` を移す
- [ ] `MuzKomaTypeView.cs` を移す


### STEP 7. `ProgramCommands.cs` から USI を分ける

ここがいちばん「設計の勉強」になるところです。  
ただし、最初から細かく分けすぎない方がよいです。

今 `ProgramCommands.cs` にあるもの:

- REPL の入り口
- USI コマンド
- 独自コマンド
- 表示呼び出し

まずは次の 2 分割で十分です。

- `Application\Commands\ProgramCommands.cs`
- `Protocols\Usi\UsiCommandHandler.cs`

TODO:

- [ ] `usi`
- [ ] `isready`
- [ ] `setoption`
- [ ] `usinewgame`
- [ ] `position`
- [ ] `go`

上記を `UsiCommandHandler` 側へ寄せる。

補助 TODO:

- [ ] `SendOutput` の置き場を決める
- [ ] 独自コマンド `pos`, `clear` は `ProgramCommands` 側に残す
- [ ] 役割ごとに private メソッドへ切る


### STEP 8. `ApplicationService.cs` の役割を決める

今は空なので、無理に使わなくてもよいです。  
ただし、将来次のどちらかにできます。

- アプリ全体の入口サービスにする
- 使わないなら削除する

TODO:

- [ ] このクラスを使う目的があるか考える
- [ ] 無ければ削除候補にする


### STEP 9. README のフォルダー案内を更新する

実際に構成を変えたら、README の案内も追従させる必要があります。

TODO:

- [ ] `Core` の説明を見直す
- [ ] `Domain` の説明を追加する
- [ ] `Protocols` の説明を追加する
- [ ] `Presentation` を使うならその説明も追加する


## 着手しやすい最初の 1 回分

最初にやるなら、次の 1 回分がちょうどよいです。

### 1 回目の作業案

- `Domain\Shogi\Coordinates` 方針を決める
- `MuzSujiType.cs`
- `MuzDanType.cs`
- `MuzMasuType.cs`
- `MuzSujiHelper.cs`
- `MuzDanHelper.cs`

やること:

- [ ] 移動
- [ ] namespace 修正
- [ ] using 修正
- [ ] ビルド
- [ ] テスト

これなら影響範囲が比較的小さく、学習用にも追いやすいです。


## この再編で学べること

この作業は、単なる見た目の整理ではなく、次の学習に役立ちます。

- ドメインと外部規約の分離
- 命名の重要性
- 段階的リファクタリング
- namespace とフォルダー構成の関係
- 小さく直して確認する進め方


## 最後に

この TODO は、**全部一気に終わらせるためのものではありません**。  
1 回 1 回の変更を小さくして、あとで自分で読める形に育てていくためのメモです。

迷ったら、次の優先順位に戻るとよいです。

1. 将棋そのものは `Domain`
2. USI は `Protocols\Usi`
3. 画面表示は `Views` または `Presentation`
4. 設定とログは `Infrastructure`
5. 一度に全部変えない
