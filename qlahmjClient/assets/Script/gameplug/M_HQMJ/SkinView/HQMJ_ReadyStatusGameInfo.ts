import { HQMJTableConfig, HQMJ } from "../ConstDef/HQMJMahjongDef";
const {ccclass, property} = cc._decorator;

@ccclass
export default class HQMJ_ReadyStatusGameInfo extends cc.Component {

    @property(cc.Label)
    lbl_cellscore: cc.Label=null;

    @property(cc.Node)
    lbl_ypdx: cc.Node=null;
    @property(cc.Node)
    lbl_qd: cc.Node=null;
    @property(cc.Node)
    lbl_gk: cc.Node=null;
    @property(cc.Node)
    lbl_bukao: cc.Node=null;

    onLoad() {
        // init logic
    }

    public init():void{
        this.node.active=false;
    }

    public ShowRule(tableconfig:HQMJTableConfig):void{
        this.node.active=true;
        this.lbl_cellscore.string="底分"+tableconfig.cellScore;
        this.lbl_ypdx.opacity=tableconfig.IsYiPaoDuoXiang?255:0;
        this.lbl_qd.opacity=tableconfig.IsQiDui?255:0;
        this.lbl_gk.opacity=tableconfig.IsGangKai?255:0;
        this.lbl_bukao.opacity=tableconfig.IsBuKao?255:0;
    }

    /**
     * 刷新
     * */
    public refresh():void{
        
        this.lbl_cellscore.string="底分"+HQMJ.ins.iclass.getTableConfig().cellScore;
        this.lbl_ypdx.opacity=HQMJ.ins.iclass.getTableConfig().IsYiPaoDuoXiang?255:0;
        this.lbl_qd.opacity=HQMJ.ins.iclass.getTableConfig().IsQiDui?255:0;
        this.lbl_gk.opacity=HQMJ.ins.iclass.getTableConfig().IsGangKai?255:0;
        this.lbl_bukao.opacity=HQMJ.ins.iclass.getTableConfig().IsBuKao?255:0;
    }
}
