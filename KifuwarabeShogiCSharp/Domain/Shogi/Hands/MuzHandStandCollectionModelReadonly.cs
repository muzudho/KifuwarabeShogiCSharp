namespace KifuwarabeShogiCSharp.Domain.Shogi.Hands;

/// <summary>
///     <pre>
/// 両駒台の持ち駒の枚数だぜ（＾～＾）！
///     </pre>
/// </summary>
public class MuzHandStandCollectionModelReadonly
{


    // ========================================
    // 生成／破棄
    // ========================================


    public MuzHandStandCollectionModelReadonly(MuzHandStandCollectionModel content)
    {
        this._content = content;
    }


    // ========================================
    // 窓口データメンバー
    // ========================================


    /// <summary>
    /// ［▲歩］の枚数。
    /// </summary>
    public byte NoboriFu => this._content.NoboriFu;


    /// <summary>
    /// ［▲香］の枚数。
    /// </summary>
    public byte NoboriKyo => this._content.NoboriKyo;


    /// <summary>
    /// ［▲桂］の枚数。
    /// </summary>
    public byte NoboriKei => this._content.NoboriKei;


    /// <summary>
    /// ［▲銀］の枚数。
    /// </summary>
    public byte NoboriGin => this._content.NoboriGin;


    /// <summary>
    /// ［▲金］の枚数。
    /// </summary>
    public byte NoboriKin => this._content.NoboriKin;


    /// <summary>
    /// ［▲角］の枚数。
    /// </summary>
    public byte NoboriKaku => this._content.NoboriKaku;


    /// <summary>
    /// ［▲飛］の枚数。
    /// </summary>
    public byte NoboriHisya => this._content.NoboriHisya;


    /// <summary>
    /// ［▽歩］の枚数。
    /// </summary>
    public byte KudariFu => this._content.KudariFu;


    /// <summary>
    /// ［▽香］の枚数。
    /// </summary>
    public byte KudariKyo => this._content.KudariKyo;


    /// <summary>
    /// ［▽桂］の枚数。
    /// </summary>
    public byte KudariKei => this._content.KudariKei;


    /// <summary>
    /// ［▽銀］の枚数。
    /// </summary>
    public byte KudariGin => this._content.KudariGin;


    /// <summary>
    /// ［▽金］の枚数。
    /// </summary>
    public byte KudariKin => this._content.KudariKin;


    /// <summary>
    /// ［▽角］の枚数。
    /// </summary>
    public byte KudariKaku => this._content.KudariKaku;


    /// <summary>
    /// ［▽飛］の枚数。
    /// </summary>
    public byte KudariHisya => this._content.KudariHisya;


    // ========================================
    // 内部データメンバー
    // ========================================


    private MuzHandStandCollectionModel _content;


    // ========================================
    // 窓口メソッド
    // ========================================


    public override string ToString()
    {
        return $"▲歩 = {this.NoboriFu}, ▲香 = {this.NoboriKyo}, ▲桂 = {this.NoboriKei}, ▲銀 = {this.NoboriGin}, ▲金 = {this.NoboriKin}, ▲角 = {this.NoboriKaku}, ▲飛 = {this.NoboriHisya}, ▽歩 = {this.KudariFu}, ▽香 = {this.KudariKyo}, ▽桂 = {this.KudariKei}, ▽銀 = {this.KudariGin}, ▽金 = {this.KudariKin}, ▽角 = {this.KudariKaku}, ▽飛 = {this.KudariHisya}";
    }
}
