# KifuwarabeShogiCSharp リネーム用チェックリスト

短い作業メモです。  
Visual Studio を閉じてから進める前提です。

## 0. Visual Studio を閉じる

- Microsoft Visual Studio Community 2026 を閉じる

## 1. solution ファイル名を変更

- `E:\github.com\muzudho\KifuwarabeCSharp\KifuwarabeCSharp.slnx`
  - → `E:\github.com\muzudho\KifuwarabeCSharp\KifuwarabeShogiCSharp.slnx`

## 2. メイン project ファイル名を変更

- `E:\github.com\muzudho\KifuwarabeCSharp\KifuwarabeCSharp2\KifuwarabeCSharp.csproj`
  - → `E:\github.com\muzudho\KifuwarabeCSharp\KifuwarabeCSharp2\KifuwarabeShogiCSharp.csproj`

## 3. テスト project ファイル名を変更

- `E:\github.com\muzudho\KifuwarabeCSharp\KifuwarabeCSharp2.Tests\KifuwarabeCSharp.Tests.csproj`
  - → `E:\github.com\muzudho\KifuwarabeCSharp\KifuwarabeCSharp2.Tests\KifuwarabeShogiCSharp.Tests.csproj`

## 4. solution 内の参照を修正

ファイル:

- `E:\github.com\muzudho\KifuwarabeCSharp\KifuwarabeShogiCSharp.slnx`

修正内容:

- `KifuwarabeCSharp2.Tests/KifuwarabeCSharp.Tests.csproj`
  - → `KifuwarabeCSharp2.Tests/KifuwarabeShogiCSharp.Tests.csproj`
- `KifuwarabeCSharp2/KifuwarabeCSharp.csproj`
  - → `KifuwarabeCSharp2/KifuwarabeShogiCSharp.csproj`

## 5. テスト project の参照を修正

ファイル:

- `E:\github.com\muzudho\KifuwarabeCSharp\KifuwarabeCSharp2.Tests\KifuwarabeShogiCSharp.Tests.csproj`

修正内容:

- `..\KifuwarabeCSharp2\KifuwarabeCSharp.csproj`
  - → `..\KifuwarabeCSharp2\KifuwarabeShogiCSharp.csproj`

## 6. Visual Studio で開き直す

- `KifuwarabeShogiCSharp.slnx` を開く

## 7. ビルド確認

- ソリューションのビルド
- エラーがなければ OK

## 8. GitHub の repository 名を変更

GitHub 側で:

- `KifuwarabeCSharp2`
  - → `KifuwarabeShogiCSharp`

## 9. remote URL を変更

PowerShell 例:

- `git remote set-url origin https://github.com/muzudho/KifuwarabeShogiCSharp`

## 10. 必要ならフォルダー名を後で変更

必要なら最後にやる候補:

- `E:\github.com\muzudho\KifuwarabeCSharp\`
  - → `E:\github.com\muzudho\KifuwarabeShogiCSharp\`
- `KifuwarabeCSharp2`
  - → `KifuwarabeShogiCSharp`
- `KifuwarabeCSharp2.Tests`
  - → `KifuwarabeShogiCSharp.Tests`

## 補足

コード上の namespace や assembly 名は、すでにかなり `KifuwarabeShogiCSharp` に寄せてあります。  
なので、今の残り作業は主に「物理ファイル名」と「参照パス」の整合です。
