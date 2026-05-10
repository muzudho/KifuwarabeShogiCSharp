// See https://aka.ms/new-console-template for more information

using HelloConsoleAppCSharp.Core.Infrastructure;
using KifuwarabeShogiCSharp;
using KifuwarabeShogiCSharp.Domain.Shogi.Position;
using KifuwarabeShogiCSharp.Infrastructure.Configuration;
using KifuwarabeShogiCSharp.Infrastructure.Logging;

try
{
    //Console.WriteLine("Hello, World!");

    // ホストビルドするぜ（＾～＾）！
    // ［ホスト］ってのは［汎用ホスト］のことで、いろいろ［サービス］っていう便利機能を付け加えることができるフレームワークみたいなもんだぜ（＾～＾）
    // それを［ビルド］するぜ（＾▽＾）
    await MuzHostHelper.RunAsync(
        commandLineArgs: args,
        beforeHostBuild: async (builder, executeBeforeBuild) =>
        {
            // お前のアプリケーションに合わせて、［サービス］を追加していってくれだぜ（＾～＾）！

            MuzAppSettingsHelper.SetupBeforeHostBuild(builder);   // ［アプリケーション設定ファイル］を読み書きできるようにするための準備をするぜ（＾～＾）！

            await MuzLogging.SetupBeforeHostBuildAsync( // ［ロギング］するための準備をするぜ（＾～＾）！
                builder: builder,
                onBootstrapLoggingEnabled: async (bootstrapLogger) =>
                {
                    // ここから `bootstrapLogger` を使った［ロギング］できる（＾～＾）！
                    //bootstrapLogger.LogInformation("ホストビルド前だが、ブートストラップ・ログは出せるぜ（＾～＾）！");


                    // 📍 NOTE:
                    //
                    //      （あとで）ここへサービスを追加していくぜ（＾～＾）
                    //
                    await executeBeforeBuild(builder.Services);


                });
        },
        executeBeforeBuild: async (services) =>
        {


            // 📍 NOTE:
            //
            //      ここで、あとで［サービスの登録］とかやるぜ（＾▽＾）！
            //


            // TODO
            await Task.CompletedTask;
        },
        afterHostBuild: async (builder, services, executeAfterHostBuild) =>
        {
            //await onHostEnabled(host);  // ホストは有効になっているぜ（＾▽＾）！

            await MuzLogging.SetupAfterHostBuildAsync(
                configurationMgr: builder.Configuration,
                onLoggingServiceEnabled: async () =>
                {
                    // ここから、以下のようにして、ロガー（ILogger）を使えるようになったぜ（＾▽＾）！
                    //var logger = host.Services.GetRequiredService<ILogger<Program>>();

                    await executeAfterHostBuild(services);
                });
        },
        executeAfterHostBuild: async (services) =>
        {
            // ここからビルドされた［汎用ホスト］（host）が使えるぜ（＾▽＾）！

            //// ［アプリケーション設定ファイル］を動作確認してみようぜ（＾～＾）
            //var appSettings = services.GetRequiredService<IOptions<MuzAppSettings>>().Value;
            //Console.WriteLine($"AppName: {appSettings.AppName}");
            //Console.WriteLine($"ShogiEngineName: {appSettings.ShogiEngineName}");

            // ［ロガー］を動作確認してみようぜ（＾～＾）
            //var logger = services.GetRequiredService<ILogger<Program>>();
            //logger.LogInformation("デフォルトのログを書き込むぜ～（＾～＾）！");

            //// ［ロガー別のログ］を動作確認してみようぜ（＾～＾）
            //var loggingSvc = services.GetRequiredService<IMuzLoggingService>();
            //loggingSvc.Others.LogInformation("その他のログだぜ（＾～＾）");
            //loggingSvc.Verbose.LogInformation("大量のログだぜ（＾～＾）");

            // または IHostedService で長時間動かすアプリなら
            // await host.RunAsync();

            var pos = new MuzPositionModel();

            await MuzREPL.RunAsync(
                printPromptAsync: async () =>
                {
                    // プロンプトは表示しないぜ（＾～＾）
                    await Task.CompletedTask;
                },
                evalAsync: async (command) => await ProgramCommands.ExecuteAsync(services, pos, command)
            );

            //Console.WriteLine("アプリ終了！ Enter押してね");
            //Console.ReadLine();

            //Console.WriteLine("どやさ（＾～＾）！");
        });


}
catch (Exception ex)
{
    Console.WriteLine($"アプリが死んだ... ログも取れない、むずでょ泣く。{ex}");
}
finally
{
    Console.WriteLine("アプリが終了するぜ（＾～＾）！");

    // お前のアプリケーションに合わせて、［片付け］コードを追加していってくれだぜ（＾～＾）！
    MuzLogging.Cleanup(); // ロガーのクリーンアップ（＾～＾）
}

// Program.cs を最後まで実行しても、必ずしもアプリケーションが終了するわけじゃないぜ（＾～＾）！
// ［汎用ホスト］が動いている限りは、アプリケーションは終了しないぜ（＾～＾）！
