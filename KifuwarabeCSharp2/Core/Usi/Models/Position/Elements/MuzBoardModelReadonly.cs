namespace KifuwarabeShogiCSharp.Core.Usi.Models.Position.Elements;

internal class MuzBoardModelReadonly
{


    // ========================================
    // 生成／破棄
    // ========================================

    public MuzBoardModelReadonly(
        MuzBoardModel content)
    {
        this._content = content;
    }


    // ========================================
    // 窓口データメンバー
    // ========================================


    public MuzKomaType GetPieceAt(MuzMasuType masu)
    {
        return this._content.Pieces[masu.AsInt()];
    }


    // ========================================
    // 内部データメンバー
    // ========================================


    private MuzBoardModel _content;
}
