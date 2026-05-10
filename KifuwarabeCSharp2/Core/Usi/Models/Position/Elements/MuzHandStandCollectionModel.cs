namespace KifuwarabeShogiCSharp.Core.Usi.Models.Position.Elements;
/// <summary>
///     <pre>
/// 両駒台の持ち駒の枚数だぜ（＾～＾）！
///     </pre>
/// </summary>
public class MuzHandStandCollectionModel
{


    // ========================================
    // 生成／破棄
    // ========================================


    public MuzHandStandCollectionModel()
    {

    }


    public MuzHandStandCollectionModel(
        byte noboriFu,
        byte noboriKyo,
        byte noboriKei,
        byte noboriGin,
        byte noboriKin,
        byte noboriKaku,
        byte noboriHisya,
        byte kudariFu,
        byte kudariKyo,
        byte kudariKei,
        byte kudariGin,
        byte kudariKin,
        byte kudariKaku,
        byte kudariHisya)
    {
        this.NoboriFu = noboriFu;
        this.NoboriKyo = noboriKyo;
        this.NoboriKei = noboriKei;
        this.NoboriGin = noboriGin;
        this.NoboriKin = noboriKin;
        this.NoboriKaku = noboriKaku;
        this.NoboriHisya = noboriHisya;
        this.KudariFu = kudariFu;
        this.KudariKyo = kudariKyo;
        this.KudariKei = kudariKei;
        this.KudariGin = kudariGin;
        this.KudariKin = kudariKin;
        this.KudariKaku = kudariKaku;
        this.KudariHisya = kudariHisya;
    }


    // ========================================
    // 窓口データメンバー
    // ========================================


    /// <summary>
    /// ［▲歩］の枚数。
    /// </summary>
    public byte NoboriFu { get; set; }


    /// <summary>
    /// ［▲香］の枚数。
    /// </summary>
    public byte NoboriKyo { get; set; }


    /// <summary>
    /// ［▲桂］の枚数。
    /// </summary>
    public byte NoboriKei { get; set; }


    /// <summary>
    /// ［▲銀］の枚数。
    /// </summary>
    public byte NoboriGin { get; set; }


    /// <summary>
    /// ［▲金］の枚数。
    /// </summary>
    public byte NoboriKin { get; set; }


    /// <summary>
    /// ［▲角］の枚数。
    /// </summary>
    public byte NoboriKaku { get; set; }


    /// <summary>
    /// ［▲飛］の枚数。
    /// </summary>
    public byte NoboriHisya { get; set; }


    /// <summary>
    /// ［▽歩］の枚数。
    /// </summary>
    public byte KudariFu { get; set; }


    /// <summary>
    /// ［▽香］の枚数。
    /// </summary>
    public byte KudariKyo { get; set; }


    /// <summary>
    /// ［▽桂］の枚数。
    /// </summary>
    public byte KudariKei { get; set; }


    /// <summary>
    /// ［▽銀］の枚数。
    /// </summary>
    public byte KudariGin { get; set; }


    /// <summary>
    /// ［▽金］の枚数。
    /// </summary>
    public byte KudariKin { get; set; }


    /// <summary>
    /// ［▽角］の枚数。
    /// </summary>
    public byte KudariKaku { get; set; }


    /// <summary>
    /// ［▽飛］の枚数。
    /// </summary>
    public byte KudariHisya { get; set; }


    // ========================================
    // 窓口メソッド
    // ========================================


    public override string ToString()
    {
        return $"▲歩 = {this.NoboriFu}, ▲香 = {this.NoboriKyo}, ▲桂 = {this.NoboriKei}, ▲銀 = {this.NoboriGin}, ▲金 = {this.NoboriKin}, ▲角 = {this.NoboriKaku}, ▲飛 = {this.NoboriHisya}, ▽歩 = {this.KudariFu}, ▽香 = {this.KudariKyo}, ▽桂 = {this.KudariKei}, ▽銀 = {this.KudariGin}, ▽金 = {this.KudariKin}, ▽角 = {this.KudariKaku}, ▽飛 = {this.KudariHisya}";
    }
}
