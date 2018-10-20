const {ccclass, property} = cc._decorator;

@ccclass
export default class LHZMJ_HelpView extends cc.Component {

    @property(cc.RichText)
    label: cc.RichText=null;

    @property(cc.Button)
    btn_close: cc.Button=null;

    @property(cc.Label)
    SV: cc.Label=null;
 
    onLoad() {
        this.node.active = false;
        var str = "<color=#561414><size=30>基本介绍：</size></color>\n";
        str += "1、宿州麻将包含条、筒、万108张，字牌28张，花牌8张共计144张\n";
       // str +="吃炮费用由放炮者一人承担，如果自摸胡牌将收三家分数，无一炮多响\n";
        str += "2、规则介绍：\n";
        // str += "拉：闲家可以下拉，结算为庄闲有效（每局1次选择；1分2分两个选择）\n";
        // str += "跑：玩家可以下跑，可以4家下跑，结算全部有效。（跑4局选择1次，1分2分两个选择，中途不可添加或者撤销）\n";
        // str += "坐：庄家可以下坐，结算为庄闲有效（每局1次选择，1分2分两个选择）\n";
        str += "选庄：胡牌、荒庄继续当庄，否则轮庄\n";
        str +="可碰杠，不可吃\n"
       
        str += "只可自摸胡牌\n";
        str += "剩20张牌荒庄，每杠一次加一张\n";
        str += "过碰不碰\n";
        str += "中发白为花牌，抓到直接补花（只有在摸牌阶段补花），风牌也为花牌（仅在打什么风圈时什么风牌为花牌），花牌仅仅在摸牌阶段被补花\n";
        str += "杠随胡走，荒庄不计杠分，无抢杠胡\n"
        str += "4会玩法:翻起的牌顺位加1即为该局癞子（中发白为一个循环、东南西北为一个循环），翻起花牌则要重新翻牌\n";
        str += "7会玩法:翻起的牌以及顺位加1都为该局癞子（中发白为一个循环、东南西北为一个循环），翻起花牌则要重新翻牌（花牌恢复原位）\n";
        str += "癞子可以被打出，对打出者没有影响，并且他们也不能碰杠,翻出的癞子不能被抓走（可放在桌面中央）\n";
        str += "4会可碰杠、7会只可暗杠";
        str += "算分：自摸+2,庄+2,风牌碰 +1,明杠 +1,暗杠 +2,杠后开花翻倍,报听翻倍,天胡 4倍,一花一分,出一个会加一番\n";
        // str += "点炮胡的时候闲家与闲家只能胡边、卡、单吊点炮胡的时候庄家与闲家无限制\n";
        // str += "杠开算自摸（正常结算后X2）\n";
        // str += "抢杠胡可以胡（胡牌按自摸结算由被抢人包三家）\n";
        // str += "漏胡：如果胡牌一方，在别人打出牌胡家没有胡，只有过了自己后才能胡牌。\n";
       

        this.label.string = str;
        this.label.node.parent.height = this.label.node.height;
        this.btn_close.node.on("click", this.OnButtonClose, this);
    }
    public init(){
        this.node.active=false;
    }
    public Destroy(){
        
    }
    public Show() {
        this.node.active = true;
    }
    private OnButtonClose() {
        this.node.active = false;
    }
}
