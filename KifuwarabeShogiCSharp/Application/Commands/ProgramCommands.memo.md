# コマンド例

## USIプロトコル

👇　下記の［USIプロトコル］を実装したいんだぜ（＾▽＾）！  
📖 [将棋所　＞　USIプロトコルとは](https://shogidokoro2.stars.ne.jp/usi.html)  

標準出力は、将棋エンジンから GUI への通信に使うぜ（＾▽＾）！  
タイムスタンプなどの、余計な装飾は付けないでくれだぜ（＾▽＾）！  

標準エラー出力は使ってもいいが、仕様にないので、あんま使いたくないぜ（＾～＾）  


### 起動時

```mermaid
sequenceDiagram
    participant GUI
    participant Engine as 思考エンジン

    GUI->>Engine: usi
    Engine-->>GUI: id name きふわらぷりー
    Engine-->>GUI: id author muzudho
    Engine-->>GUI: usiok
```


### 準備確認

```mermaid
sequenceDiagram
    participant GUI
    participant Engine as 思考エンジン

    GUI->>Engine: isready
    Engine-->>GUI: readyok
```


### オプション設定（任意）

```mermaid
sequenceDiagram
    participant GUI
    participant Engine as 思考エンジン

    GUI->>Engine: setoption name USI_Ponder value true
    Note right of Engine: 詳しくは将棋所の説明を読んでくれだぜ（＾～＾）！
```


### 新しいゲームの開始

```mermaid
sequenceDiagram
    participant GUI
    participant Engine as 思考エンジン

    GUI->>Engine: usinewgame
    Note right of Engine: 前のゲームの情報をクリアする
```


### 局面を設定して指し手を求める

```mermaid
sequenceDiagram
    participant GUI
    participant Engine as 思考エンジン

    GUI->>Engine: position sfen lnsgkgsnl/9/ppppppppp/9/9/9/PPPPPPPPP/1B5R1/LNSGKGSNL b - 1
    GUI->>Engine: go
    Engine-->>GUI: bestmove resign
```


### 終了

```mermaid
sequenceDiagram
    participant GUI
    participant Engine as 思考エンジン

    GUI->>Engine: quit
```


## 独自コマンド例

USI プロトコルには無いが、学習やデバッグのために独自コマンドを追加してもいいぜ（＾～＾）  
このプロジェクトでは、今のところ次のようなコマンドがあるぜ（＾～＾）

```shell
help
```

👆　独自コマンド一覧を表示するぜ（＾▽＾）！  

```shell
show board
```

👆　現在の盤面をコンソールに表示するぜ（＾▽＾）！  
`pos` という短い名前も考えられるが、`position` と紛らわしいので、`show board` にしているぜ（＾～＾）  

```shell
clear
```

👆　コンソール画面を消すぜ（＾▽＾）！  


## 命名メモ

独自コマンド名は、次の方針で付けると読みやすいぜ（＾～＾）

- 動詞 + 対象
- USI 標準コマンドと紛らわしくしない
- 略しすぎない

詳しくは下記メモを読んでくれだぜ（＾～＾）

- [📄 ../../Docs/6_独自コマンド命名ルール案.md](../../Docs/6_独自コマンド命名ルール案.md)
