namespace KifuwarabeCSharp.Core.Usi.Models.Position;

using KifuwarabeCSharp.Core.Usi.Models.Position.Elements;

internal class MuzPositionModelReadonly
{


    // ========================================
    // 生成／破棄
    // ========================================


    public MuzPositionModelReadonly(MuzPositionModel content)
    {
        this._content = content;
    }


    // ========================================
    // 窓口データメンバー
    // ========================================


    public MuzHandStandCollectionModelReadonly HandStandCollection
    {
        get
        {
            if (this._handStandCollection == null)
            {
                this._handStandCollection = new MuzHandStandCollectionModelReadonly(this._content.HandStandCollection);
            }
            return this._handStandCollection;
        }
    }
    private MuzHandStandCollectionModelReadonly? _handStandCollection;


    // ========================================
    // 内部データメンバー
    // ========================================


    private MuzPositionModel _content;
}
