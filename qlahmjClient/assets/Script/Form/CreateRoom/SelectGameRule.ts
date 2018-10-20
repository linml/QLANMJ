import UIBase from "../Base/UIBase";
import { UIName } from "../../Global/UIName";
import Global from "../../Global/Global";
import { QL_Common } from "../../CommonSrc/QL_Common";
import { GameIcon } from "./GameIcon";
import { Action } from "../../CustomType/Action";
import Dictionary from "../../CustomType/Dictionary";
import { CreateRoomSettingBase } from "../../gameplug/base/CreateRoomSettingBase";
import { GameCachePool } from "../../Global/GameCachePool";
import { ReportError, Debug } from "../../Tools/Function";
import SettingItem from "./SettingItem";
import { AttrParam }  from "./RuleItemType/RuleItemToggleBase";
import RuleItemToggleBase  from "./RuleItemType/RuleItemToggleBase";
import { LocalStorage } from "../../CustomType/LocalStorage";
import FriendCircleWebHandle from "../FriendsCircle/FriendCircleWebHandle";
import FriendCircleDataCache from "../FriendsCircle/FriendCircleDataCache";
import { FriendCircleRule } from "../../CustomType/FriendCircleInfo";
import CreateRoomDataCache from "./CreateRoomDataCache";
import { ObjectToString, StrToObject} from "../../Tools/Function";
const { ccclass, property } = cc._decorator;

/**
 * 游戏规则数据结构
 */
export class GameRuleData {
    public GameData: any;
    public TableCost: number;
}

/**
 * 服务器需要的游戏规则数据结构
 */
export class CreateRoomStruct {
    CheckMoneyNum: number;
    CurrencyType: QL_Common.CurrencyType;
    RoomData: any;
    GroupId: number; 
}

@ccclass
export class SelectGameRule extends UIBase<any>{
    @property(cc.Prefab)
    settingItem: cc.Prefab = null;

    /*
     *  创建房间按钮面板
     */
    @property(cc.Node)
    node_Rule: cc.Node = null;

    /*
     *  钻石面板
     */
    @property(cc.Node)
    node_diamond: cc.Node = null;

    /*
     *  房费数量
     */
    @property(cc.Label)
    lab_diamond: cc.Label = null;

    /*
     *  房费图标
     */
    @property(cc.SpriteFrame)
    frame_payIcon: cc.SpriteFrame = null;

    /*
     *  房费图标数组
     */
    // @property([cc.SpriteFrame])
    // frameArray: cc.SpriteFrame[] = null;

    /*
     *  玩法介绍面板
     */
    @property(cc.Node)
    node_Desc: cc.Node = null;

    /*
     *  游戏标签选中状态
     */
    @property(cc.Node)
    node_gameLab: cc.Node = null;

    /*
     *  玩法标签选中状态
     */
    @property(cc.Node)
    node_DescLab: cc.Node = null;

    @property(cc.Layout)
    layout_item: cc.Layout = null;

    /**
     * 标签切换选中状态游戏名称
     */
    @property(cc.Label)
    lab_tabNamel_selected: cc.Label = null;

    /**
     * 标签切换未选中状态游戏名称
     */
    @property(cc.Label)
    lab_tabNamel_unSelected: cc.Label = null;

    /**
     * 左边选项Item游戏名称选项
     */
    @property(cc.Label)
    lab_gameName: cc.Label = null;

    /**
     * 游戏玩法介绍
     */
    @property(cc.RichText)
    text:cc.RichText = null;

    /**
     * 游戏房费配置
     */
    private payConfig: any = {};

    /**
     * 规则面板节点数组
     */
    private _ruleNodeDict: Dictionary<string,SettingItem>;

    public get RuleNodeDict() : Dictionary<string,SettingItem>{
        if (!this._ruleNodeDict) {
            this._ruleNodeDict = new Dictionary<string,SettingItem>();
        }

        return this._ruleNodeDict;
    }

    public get UIname(): string {
        return UIName.SelectRule;
    }

    public IsEventHandler: boolean = true;
    public IsKeyHandler: boolean = true;

    private nowGameInfo: QL_Common.GameInfo;
    private isFriendCircle: boolean = false; // 是否是从亲友圈进来的

    //霍邱麻将规则
    private M_HQMJ_desc = "<color=#FC811F><b>一、基本玩法</b></color><color=#BB8A5A><size=22>"+    
    "\n1、牌    数：包含条、筒、万108张、字牌28张共计136张"+
    "\n2、可行操作：可碰杠 "+
    "\n3、庄家选择：第一局房主当庄，之后胡牌者当庄，黄庄不下庄"+
    "\n4、可一炮多响"+
    "\n5、七对不可胡牌"+
    "\n6、过胡不胡，即在能胡牌却不胡牌的时候，若该玩家没有行动前，其他玩家"+
    "再打同样的牌不可胡牌"+
    "\n7、抢杠算自摸</size></color>"+
    "\n<color=#FC811F><b>二、特殊规则</b></color><color=#BB8A5A><size=22>  "+
    "\n1、全幺九包分"+
    "\n当玩家碰杠达到三对及以上时且胡牌类型为全幺九，则此时谁点炮由谁来包赔"+
    "其余两家所付的分值（仅在赢倒三家有中出现）"+
    "\n2、清一色包分"+
    "当玩家吃碰杠达到三对及以上时且胡牌类型为清一色，则此时谁点炮由谁来包"+
    "赔其余两家所付的分值（仅在赢倒三家有中出现）</size></color>"+
    "\n<color=#FC811F><b>三、名词解释</b></color><color=#BB8A5A><size=22>"+
    "\n谁打谁出分：即仅点炮者付给赢家双倍分数即可"+
    "\n赢倒三家有：即只要有玩家胡牌，其他三位玩家都需要赔付给玩家相应的分数"+
    "\n占庄：即连庄加分，每连一次庄多加1分"+
    "\n带大牌：即胡牌时计算相对应的牌型分（如四归一、冲天、混一色、对对胡、"+
    "清一色、全幺九等）"+
    "\n明杠暗杠：即胡牌时计算明杠以及暗杠的分值"+
    "\n四归一：某种牌有四张且做为一个刻子及与另两张牌构成一个顺子的胡牌（四"+
    "核时，其中2张不能作为将牌）"+
    "\n冲天：某种花色有1-9的顺子（将1-9去掉以后还能组成胡牌类型）"+
    "\n对对胡：手中只有刻子、碰、杠以及一对将牌组成的胡牌"+
    "\n混一色：由一种序数牌和字牌组成的胡牌"+
    "\n清一色：由一种序数牌组成的胡牌"+
    "\n全幺九：即全部由序数牌的1和9以及字牌组成的胡牌</size></color>"+
    "\n<color=#FC811F><b>四、分值计算</b></color><color=#BB8A5A><size=22>"+
    "\n平胡：1分"+
    "\n明杠/补杠：1分"+
    "\n暗杠：2分"+
    "\n自摸：X2"+
    "\n四归一：1分"+
    "\n冲天：2分"+
    "\n混一色：3分"+
    "\n对对胡：4分"+
    "\n清一色：5分"+
    "\n全幺九：15分（此牌型不与任何其他牌型叠加）"+
    "\n杠后开花：X4</size></color>";

    /**
     * 比鸡规则
     */
    private M_BiJi_desc = "<color=#FC811F><b>一、玩法说明</b></color><color=#BB8A5A><size=22>"+
    "\n1、一副牌去掉大小王，共计52张，支持2-5名玩家"+
    "\n2、开局每人发9张牌，玩家需要将九张牌配成头道、中道、尾道三副牌型，"+
    "\n每副三张，且需满足头道＜中道＜尾道。"+
    "\n3、当玩家都点击我已配好之后，所有玩家开始互相比较三道牌型大小，"+
    "\n先比头道，再比中道，最后比尾道，判定每道输赢，结算每道得分，汇总计算每家得分。"+
    "\n4、比牌阶段，玩家可选择弃牌，弃牌的玩家三道牌型默认最后一名，弃牌玩家只输基础分，"+
    "\n不输喜钱，若多个玩家同时弃牌，则按弃牌先后顺序判断名次，最后弃牌的玩家为最后一名。</size></color>"+
    "\n<color=#FC811F><b>二、比牌规则</b></color><color=#BB8A5A><size=22>"+
    "\n1、先比较牌型，三条＞同花顺＞同花＞顺子＞对子＞单张(即乌龙)。若牌型相同，则比较点数。"+
    "\n2、点数按大小比较，A＞K＞Q＞J＞10＞9＞8＞7＞6＞5＞4＞3＞2,若点数大小相同，在比较花色。"+
    "\n3、花色大小按照黑桃＞红桃＞梅花＞方块的方式进行比较。"+
    "\n注：炸弹配成1、1、2形式则不算炸弹的喜分，必须组成3、1形式才行"+
    "\n三条配成2、1形式则不算三条的喜分，必须三张在一起的形式才行</size></color>"+
    "\n<color=#FC811F><b>三、喜分计分规则</b></color><color=#BB8A5A><size=22>"+
    "\n经典玩法:（此为每个人应付喜分）"+
    "\n三青、双顺青、双三条、炸弹、全红、全黑、通关的喜分为(人数-1)X1倍X底分"+
    "\n三顺青、连顺的喜分为(人数-1)X2倍X底分"+
    "\n连顺青、全三条、双炸弹的喜分为(人数-1)X3倍X底分"+
    "\n<b>注：底分即为喜分的倍数</b></size></color>";

    /**
     * 游戏规则数据结构
     */
    private _gameRuleData: GameRuleData = null;

    private static setting = new Dictionary<number, cc.Node>();

    public onLoad() {
    }
    
    InitShow() {
        this.RuleNodeDict.Clear();
        this.nowGameInfo = this.ShowParam.gameInfo;
        this.isFriendCircle = this.ShowParam.isFriendCircle;

        this.initPayConfig();

        // 显示游戏昵称
        if (this.lab_gameName) {
            this.lab_gameName.string = this.nowGameInfo.GameName;
        }

        if (this.lab_tabNamel_selected) {
            this.lab_tabNamel_selected.string = this.nowGameInfo.GameName;
        }

        if (this.lab_tabNamel_unSelected) {
            this.lab_tabNamel_unSelected.string = this.nowGameInfo.GameName;
        }

        // 加载游戏配置表
        let act = new Action(this,(res)=>{
            if (!res) {
                if (this.node_diamond) {
                    this.node_diamond.active = false;
                }
                // 先清空
                this.layout_item.node.removeAllChildren();
                this.UiManager.ShowTip("游戏暂未开放，请联系客服！");
            }else{
                if (this.node_diamond) {
                    this.node_diamond.active = true;
                }

                this.loadDefaultAttr(res.defaultAttr);
                this.createRuleItemByConfig(res);

                // 加载本地保存的玩法 亲友圈进来的不做记忆功能
                if (!this.isFriendCircle) {
                    this.loadLocalSettingConfig();
                }
                
                // 判断是从亲友圈进来的则显示圈主支付
                let item = this.RuleNodeDict.GetValue('房费');
                let itemDict = item.ItemNodeArray;

                // 圈主支付
                let circleOwnerPayNode = itemDict.GetValue('tableCreatorPay:3');
                // 房主支付
                let fzPayNode = itemDict.GetValue('tableCreatorPay:2');

                if (fzPayNode && circleOwnerPayNode) {
                    if (this.isFriendCircle) {
                        fzPayNode.removeFromParent();
                    }else{
                        circleOwnerPayNode.removeFromParent();
                    }    
                }
            }
        });

        CreateRoomDataCache.Instance.getRuleJson(this.nowGameInfo.ModuleName,act);

        // 默认显示游戏规则面板
        this.ruleDescChanageClick(null,"RULE");
    }

    /**
     * 加载本地保存设置
     */
    private loadLocalSettingConfig() {
        let ruleStr = LocalStorage.GetItem('CreateRoomRuleConfig');

        if (!ruleStr) {
            return;
        }

        let tmpArray = ruleStr.split('#');
        let gameInfo = StrToObject(tmpArray[0]);

        if (gameInfo['GameID'] + '' != this.nowGameInfo.GameID + '') {
            return;
        }

        ruleStr = tmpArray[1];

        // 本地保存的规则
        let localRule = StrToObject(ruleStr);
        let nodeDict = this.RuleNodeDict;

        // 根据本地保存值设置选中状态和值
        for (let idx = 0; idx < nodeDict.Values.length; ++idx) {
            let childNode = nodeDict.Values[idx];
            let childNodeDict = childNode.ItemNodeArray;

            for (let childIndex = 0; childIndex < childNodeDict.Keys.length; ++childIndex) {
                let rule = childNodeDict.Keys[childIndex].split(':');
                let node = childNodeDict.GetValue(childNodeDict.Keys[childIndex]);
                let ruleItemBase: RuleItemToggleBase = node.getComponent(RuleItemToggleBase);

                if (!node || !ruleItemBase) {
                    continue;
                }

                if (-1 != Object.keys(localRule).indexOf(rule[0]) && rule[1] == localRule[rule[0]]) {
                    ruleItemBase.setSelectValue({selected: true,value: rule[1]});
                }else{
                    ruleItemBase.setSelectValue({selected: false});
                }
            }
        }
    }

    /**
     * 保存规则到本地
     */
    private saveLocalSettingConfig() {
        let ruleStr = ObjectToString(this._gameRuleData.GameData);
        cc.info('--- saveRuleConfig ', ruleStr);
        // 保存到本地
        LocalStorage.SetItem('CreateRoomRuleConfig','GameID:' + this.nowGameInfo.GameID + '#' + ruleStr);
    }

    /**
     * 初始化房费配置
     */
    public initPayConfig() {
        this.payConfig = {};

        let roomInfo = this.DataCache.RoomList.GetCreateRoom(this.nowGameInfo.GameID);
        let config = roomInfo.CSpareAttrib.Attribute1
        // config = '8|32_16|64,8|8_16|16,8|32_16|64'; 
        let payTypeArray = config.split(',');

        let AAPayArray: any;   // AA支付
        let FZPayArray: any;   // 房主支付
        let GroupPayArray: any; // 圈主支付

        //  ["10|6", "20|12", "24|18", "32|24"]
        FZPayArray = payTypeArray[0].split('_');
        AAPayArray = payTypeArray[1].split('_');
        GroupPayArray = payTypeArray[2].split('_');

        // 进一步解析成 ["10", "6"]
        let AAPayInfo = {}
        for (let idx = 0; idx < AAPayArray.length; ++idx) {
            let arr = AAPayArray[idx].split('|');
            AAPayInfo[idx + ''] = arr[1];
        }

        let FZPayInfo = {}
        for (let idx = 0; idx < FZPayArray.length; ++idx) {
            let arr = FZPayArray[idx].split('|');
            FZPayInfo['' + idx] = arr[1];
        }

        let GroupPayInfo = {}
        for (let idx = 0; idx < GroupPayArray.length; ++idx) {
            let arr = GroupPayArray[idx].split('|');
            GroupPayInfo['' + idx] = arr[1];
        }

        this.payConfig.AAPay = AAPayInfo;
        this.payConfig.FZPay = FZPayInfo;
        this.payConfig.GroupPay = GroupPayInfo;

        cc.info('--- pay config',this.payConfig);
    }

    /**
     * 显示房费 
     */
    public updateRoomPayShow(roundIdx: number,payWay: number){
        // 显示房费币种图标
        // let roomInfo = this.DataCache.RoomList.GetCreateRoom(this.nowGameInfo.GameID);
        let costNum = 0;
        if (1 == payWay) {
            // AA 支付
            costNum = this.payConfig.AAPay[roundIdx + ''];
        }else if(2 == payWay){
            // 房主支付
            costNum = this.payConfig.FZPay[roundIdx + ''];
        }else if(3 == payWay){
            // 圈主支付
            costNum = this.payConfig.GroupPay[roundIdx + ''];
        }

        if (this.lab_diamond) {
            this.lab_diamond.string = 'x' + costNum; 
        }
        
        this._gameRuleData.TableCost = costNum;
    }

    /**
     * 根据配置表创建规则选项
     */
    private createRuleItemByConfig(data: any): void{
        if (!data || 0 == data.list.length) {
            this.UiManager.ShowTip("游戏暂未开放，请联系客服！");
            return;            
        }

        // 先清空
        this.layout_item.node.removeAllChildren();

        for (var idx = 0; idx < data.list.length; ++idx) {
            // 创建规则横条：属属性名文字图片和下划线
            if (cc.isValid(this.settingItem)) {
                // 配置不可用的项则不创建
                if (data.list[idx] && !data.list[idx]['enabled']) {
                    continue;
                }

                let settingItem = cc.instantiate(this.settingItem);
                let componet = settingItem.getComponent(SettingItem);
                componet.action = new Action(this,this.clickEventHandle);
                componet.createItemList(data.list[idx],this.layout_item.node);
                let nodeArray = componet.ItemNodeArray;
                this.RuleNodeDict.AddOrUpdate(data.list[idx].desc,componet);

                if (cc.isValid(this.layout_item)) {
                    this.layout_item.node.addChild(settingItem);
                    this.layout_item.updateLayout();
                }
            }
        }

        cc.info('-- rule node dict ', this.RuleNodeDict);
    }

    /**
     * 选项按钮点击事件回调
     */
    public clickEventHandle(param: any): void{
        if (!param || !param.attrParam) {
            cc.info("error: toggle clickCallback fail!");
            return;
        }

        if (!this._gameRuleData) {
            this._gameRuleData = new GameRuleData();
            this._gameRuleData.TableCost = 0;
            this._gameRuleData.GameData = {};
        }

        // 更新当前选项的子属性节点显示或隐藏
        let parentAttr = param.attrParam.parentAttr;
        let childrenAttrs = param.attrParam.childrenAttr;

        // 查找子属性节点并根据该节点是否被选中，如果未被选中则隐藏所有子节点
        if (childrenAttrs) {
           for (let idx = 0; idx < this.RuleNodeDict.Count; ++idx) {
               let settingItem = this.RuleNodeDict.Values[idx];
               let nodeArray = settingItem.ItemNodeArray;
               for (let childAttrIdx = 0; childAttrIdx < childrenAttrs.length; ++childAttrIdx) {
                   for (let nodeIdx = 0; nodeIdx < nodeArray.Count; ++nodeIdx) {
                       if (childrenAttrs[childAttrIdx] == nodeArray.Keys[nodeIdx]) {
                           let node = nodeArray.GetValue(nodeArray.Keys[nodeIdx]);
                           node.active = param.attrParam.isChecked;
                       }
                   }
               }
           }
        }

        /**
         * 如果父类隐藏则该节点也隐藏
         */
        if (parentAttr) {
            for (let idx = 0; idx < this.RuleNodeDict.Count; ++idx) {
               let settingItem = this.RuleNodeDict.Values[idx];
               let nodeArray = settingItem.ItemNodeArray;
               for (let nodeIdx = 0; nodeIdx < nodeArray.Count; ++nodeIdx) {
                    if (parentAttr == nodeArray.Keys[nodeIdx]) {
                        let node = nodeArray.GetValue(nodeArray.Keys[nodeIdx]);
                        // 隐藏
                        if (!node.active && param.attrParam.node) {
                            param.attrParam.node.active = false;
                            return;
                        }
                    }
                }
           }
        }

        // 记录当前的选择
        this._gameRuleData.GameData[param.attrParam.attrName] = param.attrParam.value;
        cc.info("-- gameRule: ",this._gameRuleData.GameData);

        // 更新扣钻显示
        if ('tableCreatorPay' == param.attrParam.attrName
            || 'SetGameNum' == param.attrParam.attrName) {
            this.updateRoomPayShow(this._gameRuleData.GameData.SetGameNum,this._gameRuleData.GameData.tableCreatorPay);
        }
    }

    /**
     * 加载默认属性值
     */
    private loadDefaultAttr(info: any): void{
        if (!info || 0 == info.length) {
            return;
        }

        if (!this._gameRuleData) {
            this._gameRuleData = new GameRuleData();
            this._gameRuleData.TableCost = 0;
            this._gameRuleData.GameData = {};
        }

        for (var idx = 0; idx < info.length; ++idx) {
            if (info[idx]) {
                this._gameRuleData.GameData[info[idx].attrName] = info[idx].value;
            }
        }
    }

    /**
     * [ClickStart 创建游戏房间]
     * @Author   李爽
     * @DateTime 2018-09-26T14:01:22+0800
     */
    private ClickStart() {
        if (!this.nowGameInfo) return;

        if (this.isFriendCircle) {
            let curFriendCircle = FriendCircleDataCache.Instance.CurEnterFriendCircle;
            let curRule = FriendCircleDataCache.Instance.getCurFriendCircleRule();
        
            if (!curFriendCircle) {
                return;
            }

            // 先删除当前玩法再重新设置玩法
            let deleteRule = (func: any)=>{
                let cb = func;
                let act = new Action(this,(res)=>{
                    if ('success' == res.status) {
                        if (cb) {
                            cb();
                        }
                    }
                });
                      
                FriendCircleWebHandle.deleteRule(parseInt(curFriendCircle.ID),curRule.Id,act);
            }

            // 添加玩法
            let addRule = ()=>{
                // 从亲友圈进来创建规则
                let friendCircle = FriendCircleDataCache.Instance.CurEnterFriendCircle;
                let info: FriendCircleRule = new FriendCircleRule();
                info.friendId = parseInt(friendCircle.ID);
                info.gameId = this.nowGameInfo.GameID;
                info.ruleStr = ObjectToString(this._gameRuleData.GameData);
                let gameRule = this._gameRuleData.GameData;
                let param = {};
                param['SetGameNum'] = gameRule['SetGameNum'];
                param['tableCreatorPay'] = gameRule['tableCreatorPay'];
                let ruele;
                CreateRoomDataCache.Instance.getRuleDesc(this.nowGameInfo.ModuleName,param,new Action(this,(obj)=>{
                    if (!obj) {
                        return;
                    }
                    cc.info('--- ruleDesc ',obj);
                    info.ruleDesc = obj['房费'] + '(' + obj['局数'] + ')';
                    FriendCircleWebHandle.addRule(info);
                }));         
            }

            if (!curRule) {
                // 没有玩法直接添加
                addRule();
            }else{
                deleteRule(addRule);
            }
        }else{
                const rule = new CreateRoomStruct();
                rule.CheckMoneyNum = 1;
                rule.CurrencyType = QL_Common.CurrencyType.Diamond;
                rule.RoomData = this._gameRuleData;
        
                if (!rule) {
                    this.UiManager.ShowTip("无有效的游戏规则");
                    return;
                }
        
                if (rule.CurrencyType == QL_Common.CurrencyType.Diamond) {
                    // //如果是群内创建判断群主钻石数量
                    // let diamonds_num = this.ShowParam.diamonds_num
                    // if (!cc.isValid(diamonds_num) || diamonds_num < rule.CheckMoneyNum) {
                    //     this.UiManager.ShowTip("群主钻石不足，请联系群主充值");
                    //     return;
                    // }
                }
                else {
                    if (this.UserInfo.CurrencyNum(rule.CurrencyType) < rule.CheckMoneyNum) {
                        this.UiManager.ShowTip("余额不足");
                        return;
                    }
                }
        
        
                const room = this.DataCache.RoomList.GetCreateRoom(this.nowGameInfo.GameID);
                cc.log(rule.RoomData);
                if (room) {
                    Global.Instance.GameHost.TryEnterRoom(room.ID, QL_Common.EnterRoomMethod.RoomID, rule.RoomData, this.ShowParam);
                    // 保存玩家的选择
                    this.saveLocalSettingConfig();

                    // 添加常玩游戏
                    CreateRoomDataCache.Instance.addOftenPlayGame(this.nowGameInfo.GameID);
                } else {
                    cc.warn("没有创建房间");
                }
        }
    }

    /**
     * 规则玩法面板切换
     */
    private ruleDescChanageClick(eventType,argument): void{
        if (argument == "RULE") {
            if (this.node_Desc) {
                this.node_Desc.active = false;
                this.node_DescLab.active = false;
                this.node_Rule.active = true;
                this.node_gameLab.active = true;
                this.node_diamond.active = true;
            }
        }else if(argument == "DESC"){

            this.node_Desc.active = true;
            this.node_DescLab.active = true;
            this.text.string = this[this.nowGameInfo.ModuleName + '_desc'];
            this.node_Rule.active = false;
            this.node_gameLab.active = false;
            this.node_diamond.active = false;
        }
    }
}

