
import { CreateRoomSettingBase, CreateRoomStruct } from "../base/CreateRoomSettingBase";
import { QL_Common } from "../../CommonSrc/QL_Common";
import M_SZMJClass from "./M_LHZMJClass";

const { ccclass, property } = cc._decorator;

export class M_LHZMJ_GameData{        
        public SetGameNum:number=1;//= this._juarr[this._payka];
        public TableCost:number=1;// this.tableCost;
        public tableCreatorPay:number=0;//this._cbx_payType.isSel?0:1;
        public IfCanHu7Dui:boolean = true;
        public GangLeJiuYou:boolean = true;
        public CheckGps:boolean = true;
        public PeopleNum:number = 4;
        public MaShu:number = 2;
        public OutCardTime:number = 0;
        public GuoHuBuHu:boolean = true;
        public RulePeng:number = 0;
        public ifcansameip:number=0;        
        public GangKaiJia:number = 1;
        public IsRecordScoreRoom:boolean = true;
        public isGangJiuYou:boolean = true
        public isOutTimeOp:number = 0;
        public isYiPaoDuoXiang:boolean = false;



    }
export class GameRuleData {
    public GameData: any;
    public TableCost: number;
}
@ccclass
export default class M_SZMJSetting extends CreateRoomSettingBase {
    public GetSetting() {
        return this.onCreateTable();
    }
      
    PointCardCPay:string[]=["4_2","8_3","16_6","0_0"];
    PointCardAAPay:string[]=["4_1","8_2","16_2","0_0"];

    @property(cc.ToggleGroup)
    GameCount: cc.ToggleGroup=null;

    @property([cc.Toggle])
    toggle_Jushu: cc.Toggle[]=[];
    @property([cc.Toggle])
    toggle_other: cc.Toggle[]=[];

    @property([cc.Toggle])
    toggle_pay:cc.Toggle[]=[];

    //游戏配置选项
    @property([cc.Toggle])
    toggle_select:cc.Toggle[]=[];
    //会数的选择
    @property([cc.Toggle])
    toggle_selhui:cc.Toggle[]=[];

    /**
     * 杠分选择
     */
    @property([cc.Toggle])
    toggle_selgangscore:cc.Toggle[]=[];


    

    @property(cc.Label)
    label_tableCost: cc.Label=null;


    // @property(cc.Toggle)
    // cbx_outtime: cc.Toggle;
    // @property(cc.Toggle)
    // cbx_paytype: cc.Toggle;

    @property(cc.Toggle)
    cbx_agreIpsame:cc.Toggle=null;
   

    private _index:number=0;
    private _gamecount: number = 0;
    private _tablecost: number = 0;

    private _difen:number=2;
    private _zhamacount:number=0;

    private _showItem:number=3;

    private _isAgreIpXT=true;

    onLoad() {
        // init logic
        //this.Init();
    }

    public InitWithData(): boolean {
        //特殊属性1
        let att1 = this.RoomInfo.CSpareAttrib.Attribute1;
        //att1="4_1_2:8-2-3:16-3-6:0-0-0:16";/////////////////////////此行代码用于测试，正式时需要去掉
        //let check:number=0;
        //att1="4|1|2_8|2|3_16|3|6_8,";
        console.log(att1);
        if (att1 != null && att1 != "") {
            let strAll = att1.split(',');
            this._showItem=0;
             
            //最多4个
            let str1=strAll[0].split('_');
            for (let i = 0; i < str1.length - 1; i++){
                let str11=str1[i].split('|');
                this.PointCardAAPay[i]=str11[0]+"_"+str11[1];
                this.PointCardCPay[i]=str11[0]+"_"+str11[2];
                if(str11[0]==str1[str1.length-1])
                {
                    this._index=i;
                }
            }   
        }else{
            return false;
        }

        
        
        
        this.Init();
        return true;
    }
    private Init(): void {
        const tempdata=new M_LHZMJ_GameData();

        let stridx:string=this.GetItem("idx");
        let idx=parseInt(stridx);
        if(stridx!=null &&!isNaN(idx) && idx>=0 &&idx<=2){
            
            console.log(`有缓存`);

            this._index=idx;
            console.log(`索引：${this._index}`);
            if(this._index<3){
                for(var i=0;i<this.toggle_Jushu.length;i++){
                    this.toggle_Jushu[i].node.getChildByName("Label").color=cc.color().fromHEX("#561414");
                    this.toggle_Jushu[i].node.active=false;
                    this.toggle_Jushu[i].node.active=true;
                }
                // for(var i=0;i<this.toggle_Jushu.length;i++){
                //     if(i==this._index){
                //         this.toggle_Jushu[this._index].check();
                //     }
                //     else{
                //         this.toggle_Jushu[i].isChecked=false;
                //         this.toggle_Jushu[i].node.getChildByName("Label").color=cc.color().fromHEX("#561414");
                //     }
                // }
               this.shezhiXuanZe(this.toggle_Jushu,this._index);
            }
            let creatpay=this.GetItem("creatorpay");
            console.log(`AA制：${creatpay}`);
            if(creatpay!=null&&creatpay=="1"){
                this.toggle_pay[0].check();
            }





            let ipsame=this.GetItem("ipsame");
            console.log(`IP相同：${ipsame}`);
            if(ipsame!=null&&ipsame=="1"){
                this.cbx_agreIpsame.check();
            }
            if(ipsame!=null&&ipsame=="0"){
                this.cbx_agreIpsame.isChecked=false;
                this.cbx_agreIpsame.node.getChildByName("New Label").color=cc.color().fromHEX("#561414");
            }


            let baoting=this.GetItem("baoting");
            if(baoting!=null&&baoting=="1"){
                this.toggle_select[this.toggle_select.length-1].check();
            }
            if(baoting!=null&&baoting=="0"){
                this.toggle_select[this.toggle_select.length-1].isChecked=false;
            }

            let m1a2=this.GetItem("m1a2");
            if(m1a2!=null&&m1a2=="1"){
                this.shezhiXuanZe(this.toggle_selgangscore,0);
                this.refreshselgangscore();
            }
            let m3a4=this.GetItem("m3a4");
            if(m3a4!=null&&m3a4=="1"){
                this.shezhiXuanZe(this.toggle_selgangscore,1);
                this.refreshselgangscore();
            }

            let is4hui=this.GetItem("4hui");
            if(is4hui!=null&&is4hui=="1"){
                this.shezhiXuanZe(this.toggle_selhui,0);
                this.refreshselhui();
            }
            let is7hui=this.GetItem("7hui");
            if(is7hui!=null&&is7hui=="1"){
                this.shezhiXuanZe(this.toggle_selhui,1);
                this.refreshselhui();
            }

            let chuhunjiafan=this.GetItem("chuhunjiafan");
            if(chuhunjiafan!=null&&chuhunjiafan=="1"){
                this.toggle_select[this.toggle_select.length-1].check();
            }

            let ifcanhu7dui=this.GetItem("ifcanhu7dui");
            if(ifcanhu7dui!=null&&ifcanhu7dui=="1"){
                this.toggle_select[0].check();
            }

            let ifcantianhu=this.GetItem("ifcantianhu");
            if(ifcantianhu!=null&&ifcantianhu=="1"){
                this.toggle_select[1].check();
            }
            
        }
        
        else{
            console.log(`没有缓存`);

            if(this._index<3){
                this.toggle_Jushu[this._index].check();
            }


            if(tempdata.ifcansameip){
                this.cbx_agreIpsame.check();
            }




            if(tempdata.IfCanHu7Dui){
                this.toggle_select[0].check();
            }
            else if(!tempdata.IfCanHu7Dui){
                this.toggle_select[0].isChecked=false;
            }





            //if(tempdata)
           
        }






        this.label_tableCost.string = "";

        //this.refreshCheckBox();
        this.refreshTableCostConfig();
    }




private shezhiXuanZe(Ary:cc.Toggle[],index:number):void{
        if(Ary==null){
            return;
        }
        if(index<0||index>Ary.length){
            return;
        }
        for(var i=0;i<Ary.length;i++){
            if(i==index){
                Ary[i].check();
                continue;
            }
            Ary[i].isChecked=false;
        }
    }


    /**
     * 选项刷新
     */
    private refreshslect():void{
        for(var i=0;i<this.toggle_select.length;i++){
            var toggle=this.toggle_select[i];
            if(toggle.isChecked){
                toggle.node.getChildByName("New Label").color=cc.color().fromHEX("#ff4301");
            }
            else{
                toggle.node.getChildByName("New Label").color=cc.color().fromHEX("#561414");
            }
        }
    }
    /**
     * 刷新会的选择
     */
    private refreshselhui():void{
        for(var i=0;i<this.toggle_selhui.length;i++){
            var toggle=this.toggle_selhui[i];
            if(toggle.isChecked){
                toggle.node.getChildByName("New Label").color=cc.color().fromHEX("#ff4301");
                if(i==1){//0是选择7会
                    this.toggle_select[this.toggle_select.length-1].isChecked=true;//选择4会的时候，取消出会加番的选项
                    this.toggle_select[this.toggle_select.length-1].node.active=true;
                }
                if(i==0){
                    this.toggle_select[this.toggle_select.length-1].isChecked=true;
                    this.toggle_select[this.toggle_select.length-1].node.active=true;
                    this.toggle_select[this.toggle_select.length-1].node.getChildByName("New Label").color=cc.color().fromHEX("#ff4301");
                }
            }
            else{
                toggle.node.getChildByName("New Label").color=cc.color().fromHEX("#561414");
            }
        }
    }

    /**
     * 杠分选择
     */
    private refreshselgangscore():void{
        for(var i=0;i<this.toggle_selgangscore.length;i++){
            var toggle=this.toggle_selgangscore[i];
            if(toggle.isChecked){
                toggle.node.getChildByName("New Label").color=cc.color().fromHEX("#ff4301");
            }
            else{
                toggle.node.getChildByName("New Label").color=cc.color().fromHEX("#561414");
            }
        }
    }





















    private refreshCheckBox():void{
        for(var i=0;i<this.toggle_other.length;i++){
            var toggle=this.toggle_other[i];//("toggle"+i).getComponent<cc.Toggle>(cc.Toggle);
            if(toggle.isChecked){
                toggle.node.getChildByName("New Label").color=cc.color().fromHEX("#ff4301");
            }
            else{
                toggle.node.getChildByName("New Label").color=cc.color().fromHEX("#561414");
            }
        }
    }
    private refreshTableCostConfig() {
        var tableCostName = "房卡";

        this._index=this.GetGameCountSelect();
        this.SetPointCard();
        
        this.refreshGameCount();
    }
    /**
     * 刷新是否允许IP相同
     */
    private refreshIPSame():void{
        if(this.cbx_agreIpsame.isChecked){
            this.cbx_agreIpsame.node.getChildByName("New Label").color=cc.color().fromHEX("#ff4301");
            this._isAgreIpXT=true;
        }
        else{
            this.cbx_agreIpsame.node.getChildByName("New Label").color=cc.color().fromHEX("#561414");
            this._isAgreIpXT=false;
        }
    }
    /**
     * 刷新AA制
     */
    private refreshAA():void{
        if(this.toggle_pay[0].isChecked){
            this.toggle_pay[0].node.getChildByName("New Label").color=cc.color().fromHEX("#ff4301");
        }
        else{
            this.toggle_pay[0].node.getChildByName("New Label").color=cc.color().fromHEX("#561414");
        }
        this.SetPointCard();
        this.refreshGameCount();
    }


    
    /**
     * 刷新付费玩家信息
     */
    private refreshPay():void{
        console.log(`点击了付费按钮`);
        for(var i=0;i<this.toggle_pay.length;i++){
            var toggle=this.toggle_pay[i];//parent.node.getChildByName("toggle"+i).getComponent<cc.Toggle>(cc.Toggle);
            if(toggle.isChecked){
                console.log(`当前选中的是：${i}`);
                toggle.node.getChildByName("New Label").color=cc.color().fromHEX("#ff4301");
            }
            else{
                toggle.node.getChildByName("New Label").color=cc.color().fromHEX("#561414");
            }
        }
        this.SetPointCard();
        this.refreshGameCount();
    }













    /**
     * 刷新超时托管
     */
    private refresOutTime():void{
        // if(this.cbx_outtime.isChecked){
        //     this.cbx_outtime.node.getChildByName("New Label").color=cc.color().fromHEX("#ff4301");
        // }
        // else{
        //     this.cbx_outtime.node.getChildByName("New Label").color=cc.color().fromHEX("#561414");
        // }
    }
   

    private SetToggleLabelColor(parent:cc.ToggleGroup,value:number){
        for(var i=0;i<parent.node.childrenCount;i++){
            var toggle=parent.node.getChildByName("toggle"+i).getComponent<cc.Toggle>(cc.Toggle);
            if(i==value){
                toggle.node.getChildByName("label").color=cc.color().fromHEX("#ff4301");
            }
            else{
                toggle.node.getChildByName("label").color=cc.color().fromHEX("#561414");
            }
        }
    }
    private GetGameCountSelect() {
        if (this.toggle_Jushu[1].isChecked)
            return 1;
        else if (this.toggle_Jushu[2].isChecked)
            return 2;
        else
            return 0;
    }
    private refreshGameCount(): void {
        this._index=this.GetGameCountSelect();
        this.SetPointCard();
        this._gamecount = Number(this.PointCardAAPay[Number(this._index)].split("_")[0]);//Number(this.JuGroup.selectedValue.split("_")[0]);
        this.label_tableCost.string =this.toggle_pay[0].isChecked?this.TableCost()+"/人" : this.TableCost() + "";
    }

    

    private TableCost() {
        if(this.toggle_pay[0].isChecked)
        {
            this._tablecost = Number(this.PointCardAAPay[Number(this._index)].split("_")[1]);
        }
        else{
            this._tablecost = Number(this.PointCardCPay[Number(this._index)].split("_")[1]);
        }
        //Number(this.JuGroup.selectedValue.split("_")[1]);
        return this._tablecost;
    }

    private SetPointCard(){
        console.log(`已经改变颜色`);
            for(var i=0;i<this.toggle_Jushu.length;i++){
                var toggle=this.toggle_Jushu[i];//parent.node.getChildByName("toggle"+i).getComponent<cc.Toggle>(cc.Toggle);
                if(toggle.isChecked){
                    toggle.node.getChildByName("Label").color=cc.color().fromHEX("#ff4301");
                }
                else{
                    toggle.node.getChildByName("Label").color=cc.color().fromHEX("#561414");
                }
                if(this.toggle_pay[0].isChecked){
                    toggle.node.getChildByName("Label").getComponent<cc.Label>(cc.Label).string=Number(this.PointCardAAPay[i].split("_")[0])+"局"+`（房卡X${Number(this.PointCardAAPay[i].split("_")[1])}）`;
                }else{
                    toggle.node.getChildByName("Label").getComponent<cc.Label>(cc.Label).string=Number(this.PointCardCPay[i].split("_")[0])+"局"+`（房卡X${Number(this.PointCardCPay[i].split("_")[1])}）`;
                }
        }
    }


    /**
     * 创建房间
     * */
    private onCreateTable(): CreateRoomStruct {
        
        
        const gameData:M_LHZMJ_GameData=new M_LHZMJ_GameData();
        gameData.SetGameNum=this._gamecount;
        gameData.TableCost=this.TableCost();

        gameData.ifcansameip=this.cbx_agreIpsame.isChecked?0:1;
        this.SetItem("ipsame",this.cbx_agreIpsame.isChecked?"1":"0");
        console.log(`缓存IP：${this.cbx_agreIpsame.isChecked?"1":"0"}`);
        this.SetItem("zimods",this._difen.toString());



        gameData.IfCanHu7Dui=this.toggle_select[0].isChecked?true:false;
        this.SetItem("ifcanhu7dui",this.toggle_select[0].isChecked?"1":"0");



        


        const gameRuleData:GameRuleData=new GameRuleData();
        gameRuleData.GameData=gameData;
        gameRuleData.TableCost=this.TableCost();

        let crs=new CreateRoomStruct();
        crs.CheckMoneyNum=this.TableCost();
        crs.CurrencyType=QL_Common.CurrencyType.Diamond;
        crs.RoomData=gameRuleData;
        return crs;
    }
}

