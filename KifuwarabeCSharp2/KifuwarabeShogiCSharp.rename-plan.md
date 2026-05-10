# KifuwarabeShogiCSharp へのリネーム計画

このメモは、`KifuwarabeCSharp` 系の名前を `KifuwarabeShogiCSharp` へ寄せるときの手順メモです。  
Visual Studio を閉じてからやる作業も含めて整理しています。

## 今回こちらで反映したこと

コード上で先に反映した内容です。

- namespace を `KifuwarabeCSharp` → `KifuwarabeShogiCSharp` へ変更
- `using KifuwarabeCSharp...` → `using KifuwarabeShogiCSharp...` へ変更
- メインプロジェクトのアセンブリ名とルート namespace を変更
  - `AssemblyName = KifuwarabeShogiCSharp`
  - `RootNamespace = KifuwarabeShogiCSharp`
- テストプロジェクトのアセンブリ名とルート namespace を変更
  - `AssemblyName = KifuwarabeShogiCSharp.Tests`
  - `RootNamespace = KifuwarabeShogiCSharp.Tests`
- `appsettings.json` の名称を更新
  - `AppName = KifuwarabeShogiCSharp`
  - Serilog のカテゴリ上書き名 `KifuwarabeShogiCSharp`
  - Serilog の `Application` プロパティ `KifuwarabeShogiCSharp`

## まだ手でやる方が安全なこと

Visual Studio や Git の都合で、物理名の変更は手でやる方が安全です。

### 1. Visual Studio を閉じる

まず Visual Studio を閉じます。

理由:

- `.csproj` のファイル名変更
- フォルダー名変更
- ソリューションの再読み込み

で IDE が古い状態を握りやすいためです。

### 2. プロジェクト ファイル名の変更

変更候補:

- `KifuwarabeCSharp2\KifuwarabeCSharp.csproj`
  - → `KifuwarabeCSharp2\KifuwarabeShogiCSharp.csproj`
- `KifuwarabeCSharp2.Tests\KifuwarabeCSharp.Tests.csproj`
  - → `KifuwarabeCSharp2.Tests\KifuwarabeShogiCSharp.Tests.csproj`

### 3. テスト側の ProjectReference を修正

`KifuwarabeCSharp2.Tests\KifuwarabeCSharp.Tests.csproj` の中にある参照を、
リネーム後の `.csproj` ファイル名へ合わせます。

現状:

- `..\KifuwarabeCSharp2\KifuwarabeCSharp.csproj`

変更後の例:

- `..\KifuwarabeCSharp2\KifuwarabeShogiCSharp.csproj`

※ もしテスト側の `.csproj` 自体も新名にしたら、そのファイルの中身も合わせて修正します。

### 4. 必要ならフォルダー名を変更

候補:

- `KifuwarabeCSharp2`
  - → `KifuwarabeShogiCSharp`
- `KifuwarabeCSharp2.Tests`
  - → `KifuwarabeShogiCSharp.Tests`

これはやってもよいですが、影響範囲が広いです。  
まずは `.csproj` 名だけ変えて、フォルダー名は後回しでも大丈夫です。

### 5. solution ファイル名を変更

ワークスペースには solution ファイルとして `KifuwarabeCSharp.slnx` があります。  
これも名前をそろえるなら、次のように変更します。

- `KifuwarabeCSharp.slnx`
  - → `KifuwarabeShogiCSharp.slnx`

そのうえで、中のプロジェクト参照パスも物理ファイル名変更後に合わせます。

現状の記述:

- `KifuwarabeCSharp2.Tests/KifuwarabeCSharp.Tests.csproj`
- `KifuwarabeCSharp2/KifuwarabeCSharp.csproj`

変更後の例:

- `KifuwarabeCSharp2.Tests/KifuwarabeShogiCSharp.Tests.csproj`
- `KifuwarabeCSharp2/KifuwarabeShogiCSharp.csproj`

### 6. GitHub のリポジトリー名変更

現状の remote:

- `origin: https://github.com/muzudho/KifuwarabeCSharp2`

変更候補:

- `https://github.com/muzudho/KifuwarabeShogiCSharp`

GitHub 側でリポジトリー名変更後、ローカルでも remote URL を合わせます。

PowerShell 例:

- `git remote set-url origin https://github.com/muzudho/KifuwarabeShogiCSharp`

### 7. ローカルのルート フォルダー名変更は最後でよい

現状:

- `E:\github.com\muzudho\KifuwarabeCSharp\`

これは最後に変えれば十分です。  
先に変えると、IDE や各種履歴が追いにくくなります。

## 作業順のおすすめ

1. Visual Studio を閉じる
2. メイン `.csproj` 名を変更
3. テスト `.csproj` 名を変更
4. テストの `ProjectReference` を修正
5. `KifuwarabeCSharp.slnx` を `KifuwarabeShogiCSharp.slnx` に変更し、Visual Studio で開き直す
6. ビルド確認
7. GitHub の repo 名を変更
8. `git remote set-url origin ...` を更新
9. 必要ならフォルダー名も変更

## こちらでまだ触っていないもの

以下は、まだ今回の自動変更では触っていません。

- `KifuwarabeCSharp.slnx` の物理ファイル名
- `.csproj` の物理ファイル名
- プロジェクト フォルダー名
- テスト フォルダー名
- GitHub のリポジトリー名
- remote URL
- docs / memo に残っている旧名の文章

## 追加で直してもよさそうなところ

必要ならあとで見直し候補です。

- `Docs\3_企画.md` にある `KifuwarabeCSharp` の表記
- コメントや memo 内の旧名
- ログファイル名のプレフィックス付け

## 今の状態での注意

今は namespace と assembly 名だけ先に `KifuwarabeShogiCSharp` に寄せています。  
一方で、solution ファイルや `ProjectReference` はまだ旧 `.csproj` の物理ファイル名を指しています。  
そのため、次に `.csproj` の物理ファイル名を変えるときは、`KifuwarabeCSharp.slnx` の中身とテスト側の `ProjectReference` も同時に直してください。
