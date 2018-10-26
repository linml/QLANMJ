using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MahjongAlgorithmForMGMJ;
namespace M_MGMJ
{
    public class CPlayerInfo
    {
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="Gameserver"></param>
        public CPlayerInfo(GameServer Gameserver)
        {
            _gameServer = Gameserver;
            _status = enUserStatus.userStatus_normal;
            _isReady = false;
            //_saveMoney = 0;
        }

        #region 属性访问

        #region 玩家属性信息

        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }

        private bool _bIsBanker;
        /// <summary>
        /// 是否庄家
        /// </summary>
        public bool IsBanker { get { return _bIsBanker; } set { _bIsBanker = value; } }

        private int _lianBanker;
        /// <summary>
        /// 连庄数
        /// </summary>
        public int LianBanker { get { return _lianBanker; } set { _lianBanker = value; } }

        /// <summary>
        /// 玩家椅子号
        /// </summary>
        public ushort PlayerChair { get; set; }

        private uint _plyaerID;
        /// <summary>
        /// 玩家ID
        /// </summary>
        public uint PlayerID { get { return _plyaerID; } set { _plyaerID = value; } }

        private bool _bIsAIUser;
        /// <summary>
        /// 是否AI用户
        /// </summary>
        public bool IsAIPlayer { get { return _bIsAIUser; } set { _bIsAIUser = value; } }

        //是否强退离开中
        private bool _isForceLefting;
        /// <summary>
        /// 是否强退离开中
        /// </summary>
        public bool isForceLefting { get { return this._isForceLefting; } set { this._isForceLefting = value; } }

        #endregion

        #region 玩家状态信息

        private int _paoNum = 0;
        /// <summary>
        /// 跑点
        /// </summary>
        public int PaoNum { get { return this._paoNum; } set { this._paoNum = value; } }

        private int _laNum = 0;
        /// <summary>
        /// 拉点
        /// </summary>
        public int LaNum { get { return this._laNum; } set { this._laNum = value; } }

        private bool _isReady;
        /// <summary>
        /// 是否准备
        /// </summary>
        public bool IsReady { get { return _isReady; } set { _isReady = value; } }
        private bool _isTing = false;
        public bool IsTing { get { return _isTing; } set { _isTing = value; } }

        private bool _isJustGang;
        /// <summary>
        /// 是否刚刚杠过
        /// </summary>
        public bool IsJustGang
        {
            get { return _isJustGang; }
            set
            {
                _isJustGang = value;
                if (!_isJustGang)
                {
                    _dianGangPlayer = MahjongDef.gInvalidChar;
                }

            }
        }

        private bool _isHasGang;
        /// <summary>
        /// 是否连杠
        /// </summary>
        public bool IsHasGang { get { return _isHasGang; } set { _isHasGang = value; } }


        public byte _dianGangPlayer;
        /// <summary>
        /// 点杠玩家
        /// </summary>
        public byte DianGangPlayer { get { return _dianGangPlayer; } set { _dianGangPlayer = value; } }
        public byte _fanggang1;
        /// <summary>
        /// 点杠玩家列表
        /// </summary>
        public byte fanggang1 { get { return _fanggang1; } set { _fanggang1 = value; } }
        public byte _fanggang2;
        /// <summary>
        /// 点杠玩家列表
        /// </summary>
        public byte fanggang2 { get { return _fanggang2; } set { _fanggang2 = value; } }
        public byte _fanggang3;
        /// <summary>
        /// 点杠玩家列表
        /// </summary>
        public byte fanggang3 { get { return _fanggang3; } set { _fanggang3 = value; } }
        public byte _fanggang4;
        /// <summary>
        /// 点杠玩家列表
        /// </summary>
        public byte fanggang4 { get { return _fanggang4; } set { _fanggang4 = value; } }


        public List<byte> _fangpeng1 = new List<byte>();
        /// <summary>
        /// 点碰玩家列表
        /// </summary>
        public List<byte> fangpeng1 { get { return this._fangpeng1; } }


        public  List<byte> _fangpeng2=new List<byte>();
        /// <summary>
        /// 点碰玩家列表
        /// </summary>
        public List<byte> fangpeng2 { get { return this._fangpeng2; } }


        public List<byte> _fangpeng3=new List<byte>();
        /// <summary>
        /// 点碰玩家列表
        /// </summary>
        public List<byte> fangpeng3 { get { return this._fangpeng3; } }



        public List<byte> _fangpeng4=new List<byte>();
        /// <summary>
        /// 点碰玩家列表
        /// </summary>
        public List<byte> fangpeng4 { get { return this._fangpeng4; } }

        private bool _isJustPeng;
        /// <summary>
        /// 是否刚刚碰过
        /// </summary>
        public bool IsJustPeng { get { return _isJustPeng; } }

        public bool _isBaoTing;
        /// <summary>
        /// 玩家是否豹听
        /// </summary>
        public bool IsBaoTing { get { return _isBaoTing; } }

        private bool _bIfCanOp;
        /// <summary>
        /// 是否可以操作
        /// </summary>
        public bool IfCanOp { get { return _bIfCanOp; } set { _bIfCanOp = value; } }
        private bool _bIfOutOp;
        /// <summary>
        /// 是否可以超时操作
        /// </summary>
        public bool IfOutOp { get { return _bIfOutOp; } set { _bIfOutOp = value; } }
        public bool _isFangPao;
        /// <summary>
        /// 是否放炮
        /// </summary>
        public bool IsFangPao { get { return _isFangPao; } set { _isFangPao = value; } }
        public String _vecType;
        /// <summary>
        /// 牌型分字段
        /// </summary>
        public String VecType { get { return _vecType; } set { _vecType = value; } }
        /// <summary>
        /// 是否已经胡牌
        /// </summary>
        public bool IsAlreadyHu { get { return _huCardType != enHuCardType.HuCardType_Null; } }

        private bool _isVoteQiangGang;
        /// <summary>
        /// 是否投票抢杠
        /// </summary>
        public bool IsVoteQiangGang { get { return _isVoteQiangGang; } set { _isVoteQiangGang = value; } }

        #endregion

        private byte _cbHoldCard;
        /// <summary>
        /// 抓到的牌
        /// </summary>
        public byte HoldCard { get { return _cbHoldCard; } set { _cbHoldCard = value; _giveupHuMultiple = 0; _giveupPeng.Clear(); } }

        private byte _cbHuCard;
        /// <summary>
        /// 胡的牌
        /// </summary>
        public byte HuCard { get { return _cbHuCard; } }


        private List<byte> _jieSuan;
        /// <summary>
        /// 结算
        /// </summary>
        public List<byte> JieSuan { get { return this._jieSuan; } }

        private byte _voteRight;
        /// <summary>
        /// 投票权限
        /// </summary>
        public byte VoteRight { get { return _voteRight; } set { _voteRight = value; } }

        private byte _voteResult;
        /// <summary>
        /// 投票结果
        /// </summary>
        public byte VoteResult { get { return _voteResult; } set { _voteResult = value; } }

        private int _sleepSecond;
        /// <summary>
        /// 休息时间
        /// </summary>
        public int WaitSeconds { get { return _sleepSecond > 0 ? _sleepSecond-- : 0; } set { _sleepSecond = value; } }

        private enHuCardType _huCardType;
        /// <summary>
        /// 胡牌类型
        /// </summary>
        public enHuCardType HuCardType { get { return _huCardType; } }

        private enUserStatus _status;
        /// <summary>
        /// 玩家当前状态
        /// </summary>
        public enUserStatus Status { get { return _status; } set { _status = value; } }

        /// <summary>
        /// 玩家是否已经断线
        /// </summary>
        public bool IsOffline { get { return _status == enUserStatus.userStatus_offLine; } }

        //玩家牌
        private clsPlayerCard _playerCard = new clsPlayerCard();
        /// <summary>
        /// 玩家牌组
        /// </summary>
        public clsPlayerCard PlayerCard { get { return _playerCard; } }



        private clsPlayerScore _playerScore = new clsPlayerScore();
        /// <summary>
        /// 玩家分数
        /// </summary>
        public clsPlayerScore PlayerScore { get { return _playerScore; } }

        private clsAIPlay _aiOperatorResult = new clsAIPlay();
        /// <summary>
        /// AI操作结果
        /// </summary>
        public clsAIPlay AIOperatorResult { get { return _aiOperatorResult; } }

        /// <summary>
        /// 最后一张有效的牌
        /// </summary>
        public byte LastInvalidCard
        {
            get
            {
                if (MahjongDef.gInvalidMahjongValue != HoldCard)
                {
                    return HoldCard;
                }
                return PlayerCard.activeCard.LastInvalidCard;
            }
        }

        /// <summary>
        /// 本局游戏总分
        /// </summary>
        public int TotalGameScore
        {
            get
            {

                //杠分+胡牌分
                return _playerScore.TotalScore;

            }
        }

        /// <summary>
        /// 游戏服务
        /// </summary>
        private GameServer _gameServer;

        #endregion

        #region 私有属性

        /// <summary>
        /// AI操作辅助
        /// </summary>
        private clsAIOPHelper _aiOPHelper = new clsAIOPHelper();

        /// <summary>
        /// 弃胡
        /// </summary>
        //private List<byte> _giveupHuMultiple = new List<byte>();
        private byte _giveupHuMultiple;

        private List<byte> _giveupPeng = new List<byte>();

        #endregion

        #region 打牌

        /// <summary>
        /// 玩家自动打牌逻辑
        /// </summary>
        /// <param name="aiPlayResult"></param>
        public void AutoOutCard()
        {
            //本次AI的操作
            _aiOperatorResult.Clear();

            //随机对象
            Random randObj = MahjongGeneralAlgorithm.GetRandomObject();
            //待打出的牌
            List<byte> waitOutCardAry = new List<byte>();
            //手牌
            List<byte> handCard = CopyActiveCard();

            #region 自摸

            //2、检查是否可以自摸
            if (this.CheckIfCanHuACard(_cbHoldCard))
            {
                _aiOperatorResult.cOpCard = _cbHoldCard;
                _aiOperatorResult.enPlayResult = enPlayerOperator.PlayerOperator_ZiMo;
                return;
            }

            #endregion


            List<byte> gangCard = new List<byte>();
            if (_gameServer._cardPackage.leftCardNum > 14 && !_isJustPeng)
            {
                #region 暗杠

                //3、检查暗杠
                for (int i = 0; i < handCard.Count; i++)
                {
                    if ((handCard.Count > 3) && (i < handCard.Count - 3))
                    {
                        if (handCard[i] == handCard[i + 3])
                        {
                            gangCard.Add(handCard[i]);
                            i += 3;
                            continue;
                        }
                    }
                }
                //有暗杠
                if (gangCard.Count > 0)
                {
                    _aiOperatorResult.cOpCard = gangCard[randObj.Next(0, gangCard.Count)];
                    _aiOperatorResult.enPlayResult = enPlayerOperator.PlayerOperator_AGang;
                    return;
                }

                #endregion

                #region 补杠

                //4、找补杠
                foreach (var fixedCard in _playerCard.fixedCard.fixedCard)
                {
                    if ((fixedCard.fixedType == enFixedCardType.FixedCardType_Peng) && !fixedCard.isGiveUpGang2Peng)
                    {
                        if (_cbHoldCard == fixedCard.card)
                        {
                            gangCard.Add(_cbHoldCard);
                        }
                        else if (_playerCard.activeCard.Find(fixedCard.card))
                        {
                            gangCard.Add(fixedCard.card);
                        }
                    }
                }
                //有补杠
                if (gangCard.Count > 0)
                {
                    _aiOperatorResult.cOpCard = gangCard[randObj.Next(0, gangCard.Count)];
                    _aiOperatorResult.enPlayResult = enPlayerOperator.PlayerOperator_BGang;
                    return;
                }

                #endregion
            }
            //
            //到此为止,排除了AI自摸，暗杠，补杠的情况,剩下的只能是打牌了
            //

            #region 打出一张牌之后听牌

            //5检查是否打出某一张牌之后可以听牌并且听的牌还有
            byte cbOutCard = SelACardOutThenTing();
            if (MahjongDef.gInvalidMahjongValue != cbOutCard)
            {
                //正常打,能听牌就听牌
                if (!_aiOPHelper.isOp2QYS)
                {
                    _aiOperatorResult.cOpCard = cbOutCard;
                    _aiOperatorResult.enPlayResult = enPlayerOperator.PlayerOperator_OutCard;
                    return;
                }

                //
                //往清一色方向打
                //

                //先把要打出的牌删除
                handCard.Remove(cbOutCard);

                //
                //如果已经听清一色或者牌包中剩余的牌不多了,就能听牌就听牌
                //
                if ((handCard.FindIndex(p => { return _aiOPHelper.QYSColor != MahjongGeneralAlgorithm.GetMahjongColor(p); }) < 0) ||
                   (_gameServer._cardPackage.leftCardNum < randObj.Next(20, 31)))
                {
                    _aiOperatorResult.cOpCard = cbOutCard;
                    _aiOperatorResult.enPlayResult = enPlayerOperator.PlayerOperator_OutCard;
                    return;
                }

                //把刚才删除的要打出的牌重新添加到手牌牌阵中
                handCard.Add(cbOutCard);
                handCard.Sort();
            }

            #endregion

            #region 打孤张

            //去顺去刻，取孤张
            List<byte> guCard = new List<byte>();

            //如果是往清一色方向打牌,非清一色花色牌均为孤张
            if (_aiOPHelper.isOp2QYS)
            {
                guCard.AddRange(handCard.FindAll(p => { return _aiOPHelper.QYSColor != MahjongGeneralAlgorithm.GetMahjongColor(p); }));
            }

            //如果已经全是清一色牌,再从清一色牌中找孤张；或不打清一色
            if (0 == guCard.Count)
            {
                if (handCard.Count < 3)
                {
                    guCard.AddRange(handCard);
                }
                else
                {
                    //正常打法
                    MahjongGeneralAlgorithm.GetCardListGuCardsForWHMJ(handCard, PlayerCard.fixedCard, guCard, true);
                }
            }

            cbOutCard = GetOutCardFromGuCard(guCard);
            if (MahjongDef.gInvalidMahjongValue == cbOutCard)
            {
                cbOutCard = LastInvalidCard;
            }
            _aiOperatorResult.cOpCard = cbOutCard;
            _aiOperatorResult.enPlayResult = enPlayerOperator.PlayerOperator_OutCard;

            #endregion
        }

        /// <summary>
        /// 断线真人自动出牌
        /// </summary>
        /// <param name="op"></param>
        public void TMAutoOutCard(ref clsAIPlay op)
        {
            //本次AI的操作
            op.Clear();

            //随机对象
            Random randObj = MahjongGeneralAlgorithm.GetRandomObject();
            //待打出的牌
            List<byte> waitOutCardAry = new List<byte>();


            List<byte> handCard = CopyActiveCard();
            List<byte> gangCard = new List<byte>();

            //if (_gameServer._cardPackage.haveCard)
            //{
            //    #region 暗杠

            //    //3、检查暗杠
            //    for (int i = 0; i < handCard.Count; i++)
            //    {
            //        if ((handCard.Count > 3) && (i < handCard.Count - 3))
            //        {
            //            if (handCard[i] == handCard[i + 3])
            //            {
            //                gangCard.Add(handCard[i]);
            //                i += 3;
            //                continue;
            //            }
            //        }
            //    }
            //    //有暗杠
            //    if (gangCard.Count > 0)
            //    {
            //        op.cOpCard = gangCard[randObj.Next(0, gangCard.Count)];
            //        op.enPlayResult = enPlayerOperator.PlayerOperator_AGang;
            //        return;
            //    }

            //    #endregion

            //    #region 补杠

            //    //4、找补杠
            //    foreach (var fixedCard in _playerCard.fixedCard.fixedCard)
            //    {
            //        if ((fixedCard.fixedType == enFixedCardType.FixedCardType_Peng) && !fixedCard.isGiveUpGang2Peng)
            //        {
            //            if (_cbHoldCard == fixedCard.card)
            //            {
            //                gangCard.Add(fixedCard.card);
            //            }
            //            else if (_playerCard.activeCard.Find(fixedCard.card))
            //            {
            //                gangCard.Add(fixedCard.card);
            //            }
            //        }
            //    }
            //    //有补杠
            //    if (gangCard.Count > 0)
            //    {
            //        op.cOpCard = gangCard[randObj.Next(0, gangCard.Count)];
            //        op.enPlayResult = enPlayerOperator.PlayerOperator_BGang;
            //        return;
            //    }

            //    #endregion
            //}

            #region 自摸

            //2、检查是否可以自摸
            if (this.CheckIfCanHuACard(_cbHoldCard))
            {
                op.cOpCard = _cbHoldCard;
                op.enPlayResult = enPlayerOperator.PlayerOperator_ZiMo;
                return;
            }

            #endregion

            op.cOpCard = this.LastInvalidCard;
            op.enPlayResult = enPlayerOperator.PlayerOperator_OutCard;
        }

        #endregion

        #region 投票

        /// <summary>
        /// 检查玩家本局是否可以投票
        /// </summary>
        /// <param name="cbOutCard"></param>
        /// <returns></returns>
        public bool CheckIfCanVote(byte cbOutCard, enHuCardType huType, ushort outcardchair, bool canChi, bool isBaoTing,bool isDianPao)
        {
            ClearVote();
            if (MahjongDef.gInvalidMahjongValue == cbOutCard)
            {
                return false;
            }

            if (IsAlreadyHu)
            {
                return false;
            }

            bool bIfCanVote = false;

            _gameServer.PrintLog("检查" + this.PlayerChair.ToString() + "号玩家投票权限");
            /*
            //吃 (checxBox选项)
            if (canChi && !isBaoTing && (int)this.PlayerChair == (int)((outcardchair + 1)%4) && CheckIfCanChiACard(_playerCard.activeCard.handCard,cbOutCard).Count > 0)
            {
                List<int> list = new List<int>();
                list = CheckIfCanChiACard(_playerCard.activeCard.handCard, cbOutCard);//可进行吃牌操作的选择list
                _giveupHuMultiple = 0;
                bIfCanVote = true;
                _voteRight |= MahjongDef.gVoteRightMask_Chi;
                _gameServer.PrintLog("有吃权限");
            }*/
            //碰
            if (!isBaoTing && _playerCard.activeCard.Find(cbOutCard, 2) && !_giveupPeng.Contains(cbOutCard))
            {
                _giveupHuMultiple = 0;
                bIfCanVote = true;
                _voteRight |= MahjongDef.gVoteRightMask_Peng;
                _gameServer.PrintLog("有碰权限");
            }
            //杠
            if (!isBaoTing && _gameServer._cardPackage.leftCardNum > 0 && _playerCard.activeCard.Find(cbOutCard, 3))
            {
                bIfCanVote = true;
                _voteRight |= MahjongDef.gVoteRightMask_Gang;
                _gameServer.PrintLog("有杠权限");
            }
            
            //点炮胡
            if (CheckIfCanHuACard(cbOutCard) && !(_giveupHuMultiple > 0)&& isDianPao)
            {
                bIfCanVote = true;
                _voteRight |= MahjongDef.gVoteRightMask_Hu;
                _gameServer.PrintLog("有胡权限");
                _gameServer.CanHuNum++;
            }

            return bIfCanVote;
        }
        /// <summary>
        /// 是否胡边张
        /// </summary>
        /// <param name="vSrc">可以胡的一副牌</param>
        /// <param name="huCard">胡的牌</param>
        /// <returns></returns>
        public static bool IsHuBianZhang(List<byte> vSrc, byte huCard)
        {

            List<byte> dfs = new List<byte>(vSrc);

            bool isddh = false;
            dfs.Add(huCard);
            dfs.Sort();
            if (dfs == null)
            {
                return isddh;
            }
            if (dfs.Count % 3 != 2)
            {
                return isddh;
            }
            if (dfs.Count < 5)//胡边张至少是1对加3个
            {
                return isddh;
            }
            if (huCard == MahjongDef.gInvalidMahjongValue)
            {
                return isddh;
            }
            if (!dfs.Contains(huCard))
            {
                return isddh;
            }


            List<byte> cardAry = new List<byte>(dfs);
            cardAry.Remove(huCard);
            List<byte> TingAry = new List<byte>();
            MahjongGeneralAlgorithm.CheckIfCanTingCardArray(cardAry, TingAry);
            if (TingAry == null || TingAry.Count != 1)
            {
                return isddh;
            }
            /////////听一张牌是胡边张的必要条件////////////

            if (MahjongGeneralAlgorithm.GetMahjongColor(TingAry[0]) >= 3)//胡边张必须非字牌
            {
                return isddh;
            }
            if (MahjongGeneralAlgorithm.GetMahjongValue(TingAry[0]) != 3 &&
                MahjongGeneralAlgorithm.GetMahjongValue(TingAry[0]) != 7)//胡3和7之外的不能为边张
            {
                return isddh;
            }

            if (MahjongGeneralAlgorithm.GetMahjongValue(TingAry[0]) == 3)
            {
                if (!cardAry.Contains((byte)(TingAry[0] - 2)))
                {
                    return isddh;
                }
                if (!cardAry.Contains((byte)(TingAry[0] - 1)))
                {
                    return isddh;
                }

                cardAry.Remove((byte)(TingAry[0] - 2));
                cardAry.Remove((byte)(TingAry[0] - 1));

                ////////至此1,2,3都去掉了

                byte cd = cardAry[0];

                cardAry.RemoveAt(0);

                List<byte> sTing = new List<byte>();
                MahjongGeneralAlgorithm.CheckIfCanTingCardArray(cardAry, sTing);

                if (!sTing.Contains(cd))
                {
                    return isddh;
                }

                isddh = true;

                cardAry.Add(cd);
                cardAry.Add((byte)(TingAry[0] - 2));
                cardAry.Add((byte)(TingAry[0] - 1));
                cardAry.Sort();
            }
            else if (MahjongGeneralAlgorithm.GetMahjongValue(TingAry[0]) == 7)
            {
                if (!cardAry.Contains((byte)(TingAry[0] + 2)))
                {
                    return isddh;
                }
                if (!cardAry.Contains((byte)(TingAry[0] + 1)))
                {
                    return isddh;
                }

                cardAry.Remove((byte)(TingAry[0] + 2));
                cardAry.Remove((byte)(TingAry[0] + 1));

                ////////至此7,8,9都去掉了

                byte cd = cardAry[0];

                cardAry.RemoveAt(0);

                List<byte> sTing = new List<byte>();
                MahjongGeneralAlgorithm.CheckIfCanTingCardArray(cardAry, sTing);

                if (!sTing.Contains(cd))
                {
                    return isddh;
                }

                isddh = true;

                cardAry.Add(cd);
                cardAry.Add((byte)(TingAry[0] + 2));
                cardAry.Add((byte)(TingAry[0] + 1));
                cardAry.Sort();
            }

            return isddh;
        }


        /// <summary>
        /// 是否胡卡张(卡胡)
        /// </summary>
        /// <param name="Ary">胡牌列表(记住这个列表里面的牌一定是已经胡了的牌)</param>
        /// <param name="huCard">胡的牌</param>
        /// <returns></returns>
        public static bool IsHuKaZhang(List<byte> Ary, byte huCard)
        {
            bool ishudandiao = false;

            List<byte> dfs = new List<byte>(Ary);


            dfs.Add(huCard);
            dfs.Sort();
            if (dfs == null || dfs.Count < 5 || huCard == MahjongDef.gInvalidMahjongValue || MahjongGeneralAlgorithm.GetMahjongColor(huCard) >= 3
                || MahjongGeneralAlgorithm.GetMahjongValue(huCard) == 1 || MahjongGeneralAlgorithm.GetMahjongValue(huCard) == 9)
            {
                return ishudandiao;
            }




            List<byte> TingAry = new List<byte>();
            MahjongGeneralAlgorithm.CheckIfCanTingCardArray(Ary, TingAry);
            if (TingAry == null || TingAry.Count != 1)
            {
                return ishudandiao;
            }
            if (TingAry[0] != huCard)
            {
                return ishudandiao;
            }




            List<byte> byary = new List<byte>(dfs);

            if (!byary.Contains((byte)(huCard - 1)) || !byary.Contains((byte)(huCard + 1)))
            {
                return ishudandiao;
            }

            //下面的逻辑很仓促写出来的，严密性需要检验

            byary.Remove((byte)(huCard - 1));
            byary.Remove(huCard);
            byary.Remove((byte)(huCard + 1));

            if (MahjongGeneralAlgorithm.CheckIfCanHuCardArray(byary))
            {
                ishudandiao = true;
            }

            return ishudandiao;
        }

        /// <summary>
        /// 是否单调胡(6、7、8、9万胡9万不算单调，这是之前忽略的)
        /// </summary>
        /// <param name="Ary">胡牌列表(记住这个列表里面的牌一定是已经胡了的牌)</param>
        /// <param name="huCard">胡的牌</param>
        /// <param name="isContains7">7对胡是否算单调(默认不算7对)</param>
        /// <returns></returns>
        public static bool IsHuDanDiao(List<byte> Ary, byte huCard, bool isContains7 = false)
        {
            bool ishudandiao = false;
            List<byte> dfs = new List<byte>(Ary);
            dfs.Add(huCard);

            if (dfs == null || dfs.Count < 2 || huCard == MahjongDef.gInvalidMahjongValue)
            {
                return ishudandiao;
            }
            Ary.Sort();



            List<byte> cardAry = new List<byte>(dfs);
            cardAry.Remove(huCard);
            List<byte> TingAry = new List<byte>();
            CheckIfCanTingCardArrayNormalLhh(cardAry, TingAry, false);
            if (TingAry == null || TingAry.Count != 1)
            {
                return ishudandiao;
            }

            if (GetCardNumInCardAry(dfs, huCard) >= 2)//这逻辑貌似不严密(现在严密了)
            {
                List<byte> byary = new List<byte>(dfs);

                RemoveZhiDingNumMemberInAry(byary, huCard, 2);

                List<clsParseTriple> vTriple = new List<clsParseTriple>();

                Parse3ModelToTripleListAllColor(byary, vTriple);

                if (vTriple.Count * 3 == byary.Count)
                {
                    ishudandiao = true;//满足此处条件就可以认为胡单调了，下面是去掉特殊情况，就是上面的函数说明里面的6、7、8、9万的特例

                    if (byary.Contains(huCard))
                    {
                        ishudandiao = false;
                    }
                    #region ///////////////////////////0x25,0x25,0x25,0x26,0x29,0x29,0x29 huCard:0x26/////////////////解决这副牌会被判断为单调

                    AddZhiDingNumMemberInAry(byary, huCard, 2);

                    RemoveZhiDingNumMemberInAry(byary, huCard, 1);
                    if (huCard != 0x01)
                    {
                        byte huCardMin = (byte)(huCard - 1);
                        byte huCardMax = (byte)(huCard + 1);

                        if (byary.Contains(huCardMin))
                        {
                            RemoveZhiDingNumMemberInAry(byary, huCard, 1);
                            RemoveZhiDingNumMemberInAry(byary, huCardMin, 1);

                            if (MahjongGeneralAlgorithm.CheckIfCanHuCardArray(byary))
                            {
                                ishudandiao = false;
                            }
                            AddZhiDingNumMemberInAry(byary, huCard, 1);
                            AddZhiDingNumMemberInAry(byary, huCardMin, 1);

                        }
                        if (byary.Contains(huCardMax))
                        {
                            RemoveZhiDingNumMemberInAry(byary, huCard, 1);
                            RemoveZhiDingNumMemberInAry(byary, huCardMax, 1);

                            if (MahjongGeneralAlgorithm.CheckIfCanHuCardArray(byary))
                            {
                                ishudandiao = false;
                            }
                            AddZhiDingNumMemberInAry(byary, huCard, 1);
                            AddZhiDingNumMemberInAry(byary, huCardMax, 1);
                        }
                    }


                    #endregion

                    for (int i = 0; i < vTriple.Count; i++)
                    {
                        if (vTriple[i].enTripleType != enTripleType.TripleType_Flash)//不是顺子跳过
                        {
                            continue;
                        }
                        for (int j = 0; j < vTriple[i].cCardAry.Length; j++)
                        {
                            if (huCard == (vTriple[i].cCardAry[vTriple[i].cCardAry.Length - 1] + 1) ||
                                huCard == (vTriple[i].cCardAry[0] - 1))
                            {
                                ishudandiao = false;
                            }
                        }
                    }
                }
            }

            //if(isContains7)//如果7对算单调
            //{
            //    if (GetCardNumInCardAry(Ary, huCard) >= 2)//这逻辑貌似不严密(现在严密了)
            //    {
            //        List<byte> byary = new List<byte>(Ary);

            //        if(IsHuSevenPairStruct(Ary))
            //        {
            //            ishudandiao = true;
            //        }
            //    }
            //}

            return ishudandiao;
        }

        /// <summary>
        /// 检查听普通牌的列表
        /// </summary>
        /// <param name="srcAry"></param>
        /// <param name="vectorTingCard"></param>
        /// <param name="isCheckSpecail"></param>
        /// <returns></returns>
        public static bool CheckIfCanTingCardArrayNormalLhh(List<byte> srcAry, List<byte> vectorTingCard = null, bool isCheckSpecail = true)
        {

            if (null != vectorTingCard)
            {
                vectorTingCard.Clear();
            }

            List<byte> vSrc = new List<byte>(srcAry);
            vSrc.RemoveAll(delegate(byte checkCard) { return checkCard == MahjongDef.gInvalidMahjongValue; });
            vSrc.Sort();

            //扑克复制
            List<byte> vTingSpecial = new List<byte>();
            List<byte> vTingNormal = new List<byte>();
            bool bTing = false;

            //1、判断是否特殊听牌
            if (isCheckSpecail)
            {
                if (MahjongGeneralAlgorithm.CheckIfCanSpecialTing(vSrc))
                {
                    bTing = true;
                    if (null != vectorTingCard)
                    {
                        //获取特殊听牌
                        vTingSpecial.Clear();
                        //获取特殊所听之牌
                        MahjongGeneralAlgorithm.GetSpecialTingCard(vSrc, ref vTingSpecial);
                    }
                    else//如果外面不需要获取听牌集合，能够听牌即可返回
                    {
                        return true;
                    }
                }
            }

            //2、判断是否普通听牌
            if (MahjongGeneralAlgorithm.CheckIfCanNormalTing(vSrc))
            {
                bTing = true;
                if (null != vectorTingCard)
                {
                    //获取普通听牌
                    vTingNormal.Clear();
                    //获取普通所听之牌
                    MahjongGeneralAlgorithm.GetNormalTingCard(vSrc, ref vTingNormal);
                }
                else//如果外面不需要获取听牌集合，能够听牌即可返回
                {
                    return true;
                }
            }
            if (null == vectorTingCard)
            {
                return bTing;
            }
            if ((vTingSpecial.Count == 0) && (vTingNormal.Count == 0))
            {
                return false;
            }
            //合并两个听牌集并剔除重复
            //合并两个听牌集
            vTingNormal = MahjongGeneralAlgorithm.MergeVector(vTingNormal, vTingSpecial);
            //去除重复项
            vTingNormal = MahjongGeneralAlgorithm.RemoveRepeat(vTingNormal);

            vectorTingCard.AddRange(vTingNormal);

            return vectorTingCard.Count > 0;

        }


        /// <summary>
        /// 移除列表里的指定元素的指定个数
        /// </summary>
        /// <param name="Ary"></param>
        /// <param name="card"></param>
        /// <param name="num"></param>
        public static void RemoveZhiDingNumMemberInAry(List<byte> Ary, byte card, int num)
        {
            if (Ary == null || Ary.Count < 1)
            {
                return;
            }
            if (!Ary.Contains(card))
            {
                return;
            }

            for (int i = 0; i < num; i++)
            {
                Ary.Remove(card);
            }
            Ary.Sort();
        }

        /// <summary>
        /// 将牌解析成3模式(所有颜色)
        /// </summary>
        /// <param name="vSingleCard"></param>
        /// <param name="vTriple"></param>
        public static void Parse3ModelToTripleListAllColor(List<byte> vSingleCard, List<clsParseTriple> vTriple)
        {
            vTriple.Clear();

            //1、如果不是3模式或没有牌
            if (((vSingleCard.Count % 3) != 0) || (vSingleCard.Count == 0))
            {
                return;
            }

            //2、进行一次排序
            vSingleCard.Sort();


            //1、按花色分拣牌
            List<byte> vectorWan = new List<byte>();
            List<byte> vectorTong = new List<byte>();
            List<byte> vectorTiao = new List<byte>();
            List<byte> vectorZhi = new List<byte>();
            MahjongGeneralAlgorithm.SpiltHandCardByCardColor(vSingleCard, vectorWan, vectorTong, vectorTiao, vectorZhi);

            List<clsParseTriple> tripleWan = new List<clsParseTriple>();
            List<clsParseTriple> tripleTong = new List<clsParseTriple>();
            List<clsParseTriple> tripleTiao = new List<clsParseTriple>();
            List<clsParseTriple> tripleZi = new List<clsParseTriple>();

            MahjongGeneralAlgorithm.Parse3ModelToTripleList(vectorWan, tripleWan);
            MahjongGeneralAlgorithm.Parse3ModelToTripleList(vectorTong, tripleTong);
            MahjongGeneralAlgorithm.Parse3ModelToTripleList(vectorTiao, tripleTiao);
            MahjongGeneralAlgorithm.Parse3ModelToTripleList(vectorZhi, tripleZi);

            for (int i = 0; i < tripleWan.Count; i++)
            {
                vTriple.Add(tripleWan[i]);
            }

            for (int i = 0; i < tripleTong.Count; i++)
            {
                vTriple.Add(tripleTong[i]);
            }

            for (int i = 0; i < tripleTiao.Count; i++)
            {
                vTriple.Add(tripleTiao[i]);
            }

            for (int i = 0; i < tripleZi.Count; i++)
            {
                vTriple.Add(tripleZi[i]);
            }
        }

        /// <summary>
        /// 获取一副牌阵中某张牌的数量
        /// </summary>
        /// <param name="cardAry">牌阵</param>
        /// <param name="card">需要获取数量的牌值</param>
        /// <returns>返回数量</returns>
        public static int GetCardNumInCardAry(List<byte> cardAry, byte card)
        {
            int num = 0;
            if (cardAry == null || cardAry.Count == 0 || card == MahjongDef.gInvalidMahjongValue)
            {
                return num;
            }
            num = cardAry.FindAll(delegate(byte cardFind) { return cardFind == card; }).Count;
            return num;
        }


        /// <summary>
        /// 向列表里添加指定元素的指定个数
        /// </summary>
        /// <param name="Ary"></param>
        /// <param name="card"></param>
        /// <param name="num"></param>
        public static void AddZhiDingNumMemberInAry(List<byte> Ary, byte card, int num)
        {
            if (Ary == null)
            {
                return;
            }

            for (int i = 0; i < num; i++)
            {
                Ary.Add(card);
            }
        }


        /// <summary>
        /// 是否有定牌型杠
        /// </summary>
        /// <returns></returns>
        public bool HasGang()
        {
            bool ishavegang = false;
            for (int i = 0; i < this._playerCard.fixedCard.fixedCard.Count; i++)
            {
                if (this._playerCard.fixedCard.fixedCard[i].fixedType == enFixedCardType.FixedCardType_AGang ||
                    this._playerCard.fixedCard.fixedCard[i].fixedType == enFixedCardType.FixedCardType_BGang ||
                    this._playerCard.fixedCard.fixedCard[i].fixedType == enFixedCardType.FixedCardType_MGang)
                {
                    ishavegang = true;
                }
            }
            return ishavegang;
        }


        /// <summary>
        /// 获取我的投票选择
        /// </summary>
        /// <param name="cbOutCard"></param>
        /// <returns></returns>
        public void CheckAIVoteResult(byte cbVoteCard, byte cbChair, byte i)
        {
            this._voteResult = MahjongDef.gVoteResult_GiveUp;
            List<byte> activeCard = CopyActiveCard();

            Random randObj = MahjongGeneralAlgorithm.GetRandomObject();
            //if (this._gameServer._playerAry[i].IsBanker || this._gameServer._playerAry[cbChair].IsBanker)
            //{
            //1、能胡就胡
            if (CheckIfCanHuACard(cbVoteCard))
            {
                this._voteResult = MahjongDef.gVoteResult_Hu;

                if (_aiOPHelper.isOp2QYS)
                {
                    if ((_aiOPHelper.QYSColor != MahjongGeneralAlgorithm.GetMahjongColor(cbVoteCard)) || (_playerCard.activeCard.handCard.FindIndex(p => { return _aiOPHelper.QYSColor != MahjongGeneralAlgorithm.GetMahjongColor(p); }) >= 0))
                    {
                        //如果牌还有很多，就80%放弃
                        if ((_gameServer._cardPackage.leftCardNum >= randObj.Next(24, 35)) && (randObj.Next(1, 101) > 80))
                        {
                            this._voteResult = MahjongDef.gVoteResult_GiveUp;
                        }
                    }
                }
            }
            // }
            //else
            //{
            //    if (this.HasGang())//玩家有定牌杠的情况
            //    {

            //        //1、能胡就胡
            //        if (CheckIfCanHuACard(cbVoteCard))
            //        {
            //            this._voteResult = MahjongDef.gVoteResult_Hu;

            //            if (_aiOPHelper.isOp2QYS)
            //            {
            //                if ((_aiOPHelper.QYSColor != MahjongGeneralAlgorithm.GetMahjongColor(cbVoteCard)) || (_playerCard.activeCard.handCard.FindIndex(p => { return _aiOPHelper.QYSColor != MahjongGeneralAlgorithm.GetMahjongColor(p); }) >= 0))
            //                {
            //                    //如果牌还有很多，就80%放弃
            //                    if ((_gameServer._cardPackage.leftCardNum >= randObj.Next(24, 35)) && (randObj.Next(1, 101) > 80))
            //                    {
            //                        this._voteResult = MahjongDef.gVoteResult_GiveUp;
            //                    }
            //                }
            //            }



            //        }
            //        else//玩家没有杠牌的情况
            //        {
            //            if (_gameServer.lianzhuang < 3)
            //            {


            //                if (IsHuKaZhang(activeCard, cbVoteCard) || IsHuDanDiao(activeCard, cbVoteCard) || IsHuBianZhang(activeCard, cbVoteCard))
            //                {
            //                    //1、能胡就胡
            //                    if (CheckIfCanHuACard(cbVoteCard))
            //                    {
            //                        this._voteResult = MahjongDef.gVoteResult_Hu;

            //                        if (_aiOPHelper.isOp2QYS)
            //                        {
            //                            if ((_aiOPHelper.QYSColor != MahjongGeneralAlgorithm.GetMahjongColor(cbVoteCard)) || (_playerCard.activeCard.handCard.FindIndex(p => { return _aiOPHelper.QYSColor != MahjongGeneralAlgorithm.GetMahjongColor(p); }) >= 0))
            //                            {
            //                                //如果牌还有很多，就80%放弃
            //                                if ((_gameServer._cardPackage.leftCardNum >= randObj.Next(24, 35)) && (randObj.Next(1, 101) > 80))
            //                                {
            //                                    this._voteResult = MahjongDef.gVoteResult_GiveUp;
            //                                }
            //                            }
            //                        }



            //                    }

            //                }
            //            }
            //        }



            //    }
            //}
            if (this._voteResult == MahjongDef.gVoteResult_Hu)
            {
                return;
            }

            //2、能杠就杠
            if (_gameServer._cardPackage.leftCardNum > 14 && _playerCard.activeCard.Find(cbVoteCard, 3))
            {
                this._voteResult = MahjongDef.gVoteResult_Gang;
                return;
            }

            if (!_playerCard.activeCard.Find(cbVoteCard, 2) || !MahjongGeneralAlgorithm.CheckVoteRight_Peng(_voteRight))
            {
                return;
            }

            //3、碰的情况下什么时候碰什么时候不碰
            /*
            如果已经听牌：
                如果碰过之后还可以听牌，且听的番比现在大且听的牌还有，就碰，否则不碰
	
            如果还未听牌：
                如果碰过之后打出一张牌之后可以听牌肯定碰
                如果碰过之后的孤张比现在少，也碰，否则不碰
            */

            //当我的孤张很多时，也就是牌比较烂时，当然是能杠就杠，能碰就碰，能吃就吃喽

            //3、检查碰
            List<byte> handCard = CopyActiveCard();
            List<byte> guCards = new List<byte>();

            //如果正在做清一色牌型
            if (_aiOPHelper.isOp2QYS)
            {
                //如果要碰的牌就是做清一色花色的牌
                if (_aiOPHelper.QYSColor == MahjongGeneralAlgorithm.GetMahjongColor(cbVoteCard))
                {
                    if (handCard.FindIndex(p => { return _aiOPHelper.QYSColor != MahjongGeneralAlgorithm.GetMahjongColor(p); }) >= 0)
                    {
                        _voteResult = MahjongDef.gVoteResult_Peng;
                        return;
                    }
                }
                else
                {
                    //如果现在在做清一色,需要投票碰的牌并不是清一色化色的牌:碰完之后听牌,并且牌包里的牌不多了
                    if ((this._playerCard.tingCard.Count <= 0) && (_gameServer._cardPackage.leftCardNum < randObj.Next(20, 31)))
                    {
                        handCard.Remove(cbVoteCard);
                        handCard.Remove(cbVoteCard);

                        //如果碰过之后可以听牌,就去碰
                        if (MahjongGeneralAlgorithm.CheckIfCanTingCardArrayForWHMJ(handCard, new List<byte>()))
                        {
                            _voteResult = MahjongDef.gVoteResult_Peng;
                            return;
                        }
                    }
                    //放弃,不碰
                    return;
                }
            }

            MahjongGeneralAlgorithm.GetCardListGuCards(handCard, guCards);

            if ((guCards.Count + MahjongGeneralAlgorithm.GetRandomObject().Next(1, 3)) >= handCard.Count)
            {
                _voteResult = MahjongDef.gVoteResult_Peng;
                return;
            }

            /*
             
             1、检查投票后的听牌情况
             
             */

            //最大的倍数
            int vote_type_max_multiple = 0;
            //最大的剩余张数
            int vote_type_max_leftcount = 0;

            //先备份
            List<byte> active_counterpart = new List<byte>();
            List<byte> ting_counterpart = new List<byte>();

            clsFixedCard fixed_counterpart = new clsFixedCard();
            _playerCard.CopyACounterpart(active_counterpart, ref fixed_counterpart, ting_counterpart);

            //默认放弃状态
            VoteCompareByTing(active_counterpart, ref fixed_counterpart, MahjongDef.gVoteResult_GiveUp, ref vote_type_max_leftcount, ref vote_type_max_multiple);

            //如果可以碰
            if (MahjongGeneralAlgorithm.CheckVoteRight_Peng(_voteRight))
            {
                _playerCard.CopyACounterpart(active_counterpart, ref fixed_counterpart, ting_counterpart);

                active_counterpart.Remove(cbVoteCard);
                active_counterpart.Remove(cbVoteCard);
                
                fixed_counterpart.Add(cbVoteCard, cbChair, enFixedCardType.FixedCardType_Peng);

                VoteCompareByTing(active_counterpart, ref fixed_counterpart, MahjongDef.gVoteResult_Peng, ref vote_type_max_leftcount, ref vote_type_max_multiple);
            }
            if ((MahjongDef.gVoteResult_GiveUp != _voteResult) || ((MahjongDef.gVoteResult_GiveUp == _voteResult) && (_playerCard.tingCard.Count > 0)))
            {
                return;
            }

            /*
             
             2、检查投票后的孤张情况
            
             */

            int minGuCardCount = MahjongDef.gCardCount_Active;

            //先备份
            _playerCard.CopyACounterpart(active_counterpart, ref fixed_counterpart, ting_counterpart);

            //默认放弃状态
            VoteCompareByGuCard(active_counterpart, MahjongDef.gVoteResult_GiveUp, ref minGuCardCount);

            //如果可以碰
            if (MahjongGeneralAlgorithm.CheckVoteRight_Peng(_voteRight))
            {
                _playerCard.CopyACounterpart(active_counterpart, ref fixed_counterpart, ting_counterpart);

                active_counterpart.Remove(cbVoteCard);
                active_counterpart.Remove(cbVoteCard);
                fixed_counterpart.Add(cbVoteCard, cbChair, enFixedCardType.FixedCardType_Peng);
                VoteCompareByGuCard(active_counterpart, MahjongDef.gVoteResult_Peng, ref minGuCardCount);
            }
            if (MahjongDef.gVoteResult_GiveUp != _voteResult)
            {
                return;
            }

            /*
             
             3、投放弃
             
             */
            this._voteResult = MahjongDef.gVoteResult_GiveUp;
        }

        /// <summary>
        /// 投票检查孤张情况
        /// </summary>
        /// <param name="voteResult"></param>
        /// <param name="minGuCardCount"></param>
        /// <returns></returns>
        private bool VoteCompareByGuCard(List<byte> activeCard, byte voteResult, ref int minGuCardCount)
        {
            List<byte> guCards = new List<byte>();

            MahjongGeneralAlgorithm.GetCardListGuCards(activeCard, guCards);
            if (guCards.Count < minGuCardCount)
            {
                _voteResult = voteResult;
                minGuCardCount = guCards.Count;
                return true;
            }

            //如果是可以打一张牌的情况，那么再去掉一张孤张再比较
            if ((guCards.Count > 0) && ((activeCard.Count % 3) == 2))
            {
                guCards.RemoveAt(0);
            }

            if (guCards.Count < minGuCardCount)
            {
                _voteResult = voteResult;
                minGuCardCount = guCards.Count;
                return true;
            }

            return false;
        }
        /// <summary>
        /// 投票检查听牌情况
        /// </summary>
        /// <param name="voteResult"></param>
        /// <param name="vote_type_max_leftcount"></param>
        /// <param name="vote_type_max_multiple"></param>
        /// <returns></returns>
        private bool VoteCompareByTing(List<byte> activeCard, ref clsFixedCard fixedCard, byte voteResult, ref int vote_type_max_leftcount, ref int vote_type_max_multiple)
        {
            int maxleftCount = 0;
            int maxmultiple = 0;
            int max = 0;

            Random rand = MahjongGeneralAlgorithm.GetRandomObject();

            //找出剩余听牌最多张数
            maxleftCount = GetMeTingCardLeftCount(activeCard);

            List<byte> tingCard = new List<byte>();
            List<byte> handcard = new List<byte>();
            //找出可以胡的最大番数
            if ((activeCard.Count % 3) == 1)
            {
                if (MahjongGeneralAlgorithm.CheckIfCanTingCardArrayForWHMJ(activeCard, tingCard))
                {
                    for (int i = 0; i < tingCard.Count; i++)
                    {
                        handcard.Clear();
                        handcard.AddRange(activeCard);
                        //max = AnalysisHuCardListMultiple(0,tingCard[i], enHuCardType.HuCardType_ZiMo, handcard, ref fixedCard);
                        //if (max > maxmultiple)
                        //{
                        //    maxmultiple = max;
                        //}
                    }
                }
            }
            else
            {
                byte cbOutCard = MahjongDef.gInvalidMahjongValue;
                for (int i = 0; i < activeCard.Count; i++)
                {
                    cbOutCard = activeCard[i];
                    activeCard[i] = MahjongDef.gInvalidMahjongValue;

                    if (MahjongGeneralAlgorithm.CheckIfCanTingCardArrayForWHMJ(activeCard, tingCard))
                    {
                        //activeCard[i] = cbOutCard;
                        handcard.Clear();

                        for (int j = 0; j < activeCard.Count; j++)
                        {
                            if (activeCard[j] != MahjongDef.gInvalidMahjongValue)
                                handcard.Add(activeCard[j]);
                        }
                        //for (int j = 0; j < tingCard.Count; j++)
                        //{
                        //    max = AnalysisHuCardListMultiple(0,tingCard[j], enHuCardType.HuCardType_ZiMo, handcard, ref fixedCard);
                        //    if (max > maxmultiple)
                        //    {
                        //        maxmultiple = max;
                        //    }
                        //}
                    }

                    activeCard[i] = cbOutCard;
                }
            }

            //比较
            //if ((maxmultiple >= _gameServer._tableConfig.MaxFanNum) && (maxleftCount > 0) && ((vote_type_max_multiple < _gameServer._tableConfig.MaxFanNum) || ((vote_type_max_multiple >= _gameServer._tableConfig.MaxFanNum) && (maxleftCount > vote_type_max_leftcount))))//如果可以胡役满
            //{
            //    _voteResult = voteResult;
            //    vote_type_max_leftcount = maxleftCount;
            //    vote_type_max_multiple = maxmultiple;
            //    return true;
            //}
            //else 
            if ((maxleftCount > vote_type_max_leftcount) && (maxmultiple >= vote_type_max_multiple))//两个指标都优，肯定打这张
            {
                _voteResult = voteResult;
                vote_type_max_leftcount = maxleftCount;
                vote_type_max_multiple = maxmultiple;
                return true;
            }
            else if ((maxleftCount < vote_type_max_leftcount) && ((maxmultiple - vote_type_max_multiple) > rand.Next(1, 3)))//剩余张数少，但是牌型大了一些,就打这张
            {
                _voteResult = voteResult;
                vote_type_max_leftcount = maxleftCount;
                vote_type_max_multiple = maxmultiple;
                return true;
            }
            else if (((maxleftCount - vote_type_max_leftcount) >= rand.Next(2, 5)) && ((maxmultiple - vote_type_max_multiple) > rand.Next(-2, 0)))//剩余张数多,牌型小了没多少
            {
                _voteResult = voteResult;
                vote_type_max_leftcount = maxleftCount;
                vote_type_max_multiple = maxmultiple;
                return true;
            }

            return false;
        }

        #endregion

        #region 外部操作

        /// <summary>
        /// 清除
        /// </summary>
        public void Clear()
        {
            _bIsBanker = false;
            _bIsAIUser = false;
            _plyaerID = 0;
            _giveupHuMultiple = 0;
            _giveupPeng.Clear();

            _bIfCanOp = false;
            _bIfOutOp = false;
            _isFangPao = false;
            _vecType = "";
            _isJustGang = false;
            _isHasGang = false;
            _isVoteQiangGang = false;
            _isTing = false;
            _dianGangPlayer = MahjongDef.gInvalidChar;
            //_baoJing = false;
            //_baoChair = MahjongDef.gInvalidChar;

            _cbHoldCard = MahjongDef.gInvalidMahjongValue;
            _cbHuCard = MahjongDef.gInvalidMahjongValue;
            _voteRight = MahjongDef.gVoteRightMask_Null;
            _voteResult = MahjongDef.gVoteResult_Null;
            _jieSuan = new List<byte>();
            _huCardType = enHuCardType.HuCardType_Null;
            _status = enUserStatus.userStatus_normal;
            _sleepSecond = 0;

            //_baoJingCards.Clear();
            _playerCard.Clear();
            _aiOperatorResult.Clear();
            _playerScore.Clear();
            _aiOPHelper.clear();
            _fanggang1 = 0;
            _fanggang2 = 0;
            _fanggang3 = 0;
            _fanggang4 = 0;
            _fangpeng1.Clear();
            _fangpeng2.Clear();
            _fangpeng3 .Clear();
            _fangpeng4.Clear();

        }
        /// <summary>
        /// 检查是否可以打出某张牌
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        public bool CheckIfCanOutACard(byte card)
        {
            if (MahjongDef.gInvalidMahjongValue == card)
            {
                return false;
            }
            if (this.HoldCard == card)
            {
                return true;
            }

            return _playerCard.activeCard.handCard.Contains(card);
        }
        /// <summary>
        /// 检查抢杠
        /// </summary>
        /// <param name="card"></param>
        /// <param name="huType"></param>
        /// <returns></returns>
        public bool CheckQiangGang(byte card, enHuCardType huType)
        {
            if (CheckIfCanHuACard(card))
            {
                //检查过门不胡
                //if (_giveupHuMultiple > 0)
                //{
                //    //List<byte> handCard = CopyActiveCard();

                //    //clsFixedCard fixedCard = new clsFixedCard();
                //    //_playerCard.CopyACounterpartForFixedCard(ref fixedCard);

                //    //if (AnalysisHuCardListMultiple(card, huType, handCard, ref fixedCard) > this._giveupHuMultiple)
                //    //{
                //    //    return true;
                //    //}

                //    return false;
                //}

                return true;
            }

            return false;
        }

        /// <summary>
        /// 查找所有可以杠的牌
        /// </summary>
        /// <param name="gangCard"></param>
        public bool FindGangCard(List<byte> gangCard)
        {
            gangCard.Clear();
            if (_gameServer._cardPackage.leftCardNum < 1)
            {
                return false;
            }
            List<byte> activeCard = CopyActiveCard();

            clsFixedCard fixed_counterpart = new clsFixedCard();
            _playerCard.CopyACounterpartForFixedCard(ref fixed_counterpart);

            //找暗杠
            if (activeCard.Count > 3)
            {
                for (int i = 0; i < activeCard.Count - 3; i++)
                {
                    if (activeCard[i] == activeCard[i + 3])
                    {
                        gangCard.Add(activeCard[i]);
                        i += 3;
                        continue;
                    }
                }
            }

            //找补杠
            if (fixed_counterpart.fixedCard.Count > 0)
            {
                foreach (var fixedCard in fixed_counterpart.fixedCard)
                {
                    if (fixedCard.fixedType == enFixedCardType.FixedCardType_Peng && !fixedCard.isGiveUpGang2Peng && activeCard.Contains(fixedCard.card))
                    {
                        gangCard.Add(fixedCard.card);
                    }
                }
            }

            return gangCard.Count > 0;
        }

        /// <summary>
        /// 听牌检查,如果听牌就把听的牌放入听牌阵中
        /// </summary>
        public bool TingCheck()
        {
            _playerCard.tingCard.Clear();

            List<byte> activeCard = CopyActiveCard();
            List<byte> hunCard = new List<byte>();
            hunCard.Add((byte)_gameServer._tableConfig.SetPeiZi);

            if (1 != activeCard.Count % 3)
            {
                return false;
            }
            //return MahjongGeneralAlgorithm.CheckIfCanTingCardArrayForWHMJ(activeCard, _playerCard.tingCard);
            return MahjongGeneralAlgorithm.CheckIfCanTingCardArrayHaveHun(activeCard, hunCard, _playerCard.tingCard);
        }



        /// <summary>
        /// 打牌后的处理
        /// </summary>
        /// <param name="cCard"></param>
        public void HandleByAfterOutCard(byte cCard)
        {
            if (cCard != HoldCard)
            {
                //从手中删除打出的这张牌
                _playerCard.activeCard.Remove(cCard);
                //将抓到的这张牌塞入活动牌阵中
                _playerCard.activeCard.Add(_cbHoldCard);
            }

            //记录已经打过牌
            //_isJustGang = false;
            _isJustPeng = false;
            _cbHoldCard = MahjongDef.gInvalidMahjongValue;
            _dianGangPlayer = MahjongDef.gInvalidChar;

            //打完一张牌之后马上进行听牌检查
            TingCheck();

            if (CheckIfCanHuACard(cCard))
            {
                _giveupHuMultiple = 1;
            }
        }

        /// <summary>
        /// 吃牌后的处理
        /// </summary>
        /// <param name="cCard"></param>
        public void HandleByAfterChi(byte cbCard, byte cbChair, byte chiType)
        {
            //1、添加一个定牌
            _playerCard.fixedCard.Add(cbCard, cbChair, enFixedCardType.FixedCardType_Chi, false, chiType);//_playerCard.activeCard.Find(cbCard, 3));

            //2、从活动牌阵中减去2张
            if (chiType == 0)
            {
                _playerCard.activeCard.Remove((byte)((int)cbCard - 1), 1);
                _playerCard.activeCard.Remove((byte)((int)cbCard - 2), 1);
            }
            if (chiType == 1)
            {
                _playerCard.activeCard.Remove((byte)((int)cbCard - 1), 1);
                _playerCard.activeCard.Remove((byte)((int)cbCard + 1), 1);
            }
            if (chiType == 2)
            {
                _playerCard.activeCard.Remove((byte)((int)cbCard + 1), 1);
                _playerCard.activeCard.Remove((byte)((int)cbCard + 2), 1);
            }

            //3、清除投票
            this.ClearVote();
            if (_aiOPHelper.isOp2QYS && (_aiOPHelper.QYSColor != MahjongGeneralAlgorithm.GetMahjongColor(cbCard)))
            {
                _aiOPHelper.clear();
            }
            //_isJustPeng = true;
            _cbHoldCard = MahjongDef.gInvalidMahjongValue;

            if (cbChair == 0)
            {
                fangpeng1.Add(cbCard);
            }
            if (cbChair == 1)
            {
                fangpeng2.Add(cbCard);
            }
            if (cbChair == 2)
            {
                fangpeng3.Add(cbCard);
            }
            if (cbChair == 3)
            {
                fangpeng4.Add(cbCard);
            }

            //4、吃牌后需要打出一张之后才听牌
            _playerCard.tingCard.Clear();
        }

        /// <summary>
        /// 碰牌后的处理
        /// </summary>
        /// <param name="cCard"></param>
        public void HandleByAfterPeng(byte cbCard, byte cbChair)
        {




            //1、添加一个定牌
            _playerCard.fixedCard.Add(cbCard, cbChair, enFixedCardType.FixedCardType_Peng, false);//_playerCard.activeCard.Find(cbCard, 3));

            //2、从活动牌阵中减去2张
            _playerCard.activeCard.Remove(cbCard, 2);

            //3、清除投票
            this.ClearVote();
            if (_aiOPHelper.isOp2QYS && (_aiOPHelper.QYSColor != MahjongGeneralAlgorithm.GetMahjongColor(cbCard)))
            {
                _aiOPHelper.clear();
            }
            _isJustPeng = true;
            _cbHoldCard = MahjongDef.gInvalidMahjongValue;

            if (cbChair == 0)
            {
                fangpeng1.Add(cbCard);
            }
            if (cbChair == 1)
            {
                fangpeng2.Add(cbCard);
            }
            if (cbChair == 2)
            {
                fangpeng3.Add(cbCard);
            }
            if (cbChair == 3)
            {
                fangpeng4.Add(cbCard);
            }

            //4、碰牌后需要打出一张之后才听牌
            _playerCard.tingCard.Clear();
        }

        /// <summary>
        /// 暗杠后的处理
        /// </summary>
        /// <param name="cCard"></param>
        public void HandleByAfterAGang(byte cbCard)
        {
            //1、添加一个定牌
            _playerCard.fixedCard.Add(cbCard, (byte)PlayerChair, enFixedCardType.FixedCardType_AGang);

            //2、从活动牌阵中减去3张
            if (_cbHoldCard == cbCard)
            {
                _playerCard.activeCard.Remove(cbCard, 3);
            }
            else
            {
                _playerCard.activeCard.Remove(cbCard, 4);
                _playerCard.activeCard.Add(_cbHoldCard);
            }

            //4、设置抓到的牌为无效
            _cbHoldCard = MahjongDef.gInvalidMahjongValue;
            _isHasGang = true;
            _isJustGang = true;
            for (int i = 0; i < 4; i++)
            {
                if (PlayerChair != i)
                {
                    if (PlayerChair == 0)
                    {
                        fanggang2++;
                        fanggang3++;
                        fanggang4++;

                    }
                    if (PlayerChair == 1)
                    {
                        fanggang1++;
                        fanggang3++;
                        fanggang4++;
                    }
                    if (PlayerChair == 2)
                    {
                        fanggang1++;
                        fanggang2++;
                        fanggang4++;
                    }
                    if (PlayerChair == 3)
                    {
                        fanggang1++;
                        fanggang2++;
                        fanggang3++;
                    }
                    break;
                }
            }
                //5、杠后可以听牌,如果抓到听的牌就是杠上花
                TingCheck();
        }

        /// <summary>
        /// 补杠处理
        /// </summary>
        /// <param name="cbCard"></param>
        /// <returns>如果本次补杠需要收取玩家补杠分,返回true,反之返回false</returns>
        public bool HandleByAfterBGang(byte cbCard)
        {
            //1、指定碰转杠
            bool needScore = _playerCard.fixedCard.ChangePengToGang(cbCard);

            //2、从活动牌或抓到的牌中删除补杠的牌
            if (_cbHoldCard != cbCard)
            {
                _playerCard.activeCard.Remove(cbCard);
                _playerCard.activeCard.Add(_cbHoldCard);
            }

            //3、设置抓到的牌为无效
            _cbHoldCard = MahjongDef.gInvalidMahjongValue;
            _isHasGang = true;
            _isJustGang = true;

            //4、听牌检查
            TingCheck();

            return needScore;
        }

        /// <summary>
        /// 明杠后的处理
        /// </summary>
        /// <param name="cCard"></param>
        public void HandleByAfterMGang(byte cbCard, byte cbChair)
        {
            //1、添加一个定牌
            _playerCard.fixedCard.Add(cbCard, cbChair, enFixedCardType.FixedCardType_MGang);

            //2、从活动牌阵中减去3张
            _playerCard.activeCard.Remove(cbCard, 3);

            //3、清理投票
            this.ClearVote();
            if (_aiOPHelper.isOp2QYS && (_aiOPHelper.QYSColor != MahjongGeneralAlgorithm.GetMahjongColor(cbCard)))
            {
                _aiOPHelper.clear();
            }
            _isHasGang = true;
            _isJustGang = true;
            if (cbChair == 0)
            {
                _fanggang1++;
            }
            if (cbChair == 1)
            {
                _fanggang2++;
            }
            if (cbChair == 2)
            {
                _fanggang3++;
            }
            if (cbChair == 3)
            {
                _fanggang4++;
            }

            //4、听牌检查
            TingCheck();
        }

        /// <summary>
        /// 胡牌处理
        /// </summary>
        /// <param name="huCard"></param>
        /// <param name="huType"></param>
        /// <returns></returns>
        public int[] HandleByHu(byte chair,byte huCard, enHuCardType huType, List<byte> list,int countOutMj)
        {
            _cbHuCard = huCard;
            _huCardType = huType;

            List<byte> handCard = new List<byte>();
            _playerCard.CopyACounterpartForActiveCard(handCard);

            clsFixedCard fixedCard = new clsFixedCard();
            _playerCard.CopyACounterpartForFixedCard(ref fixedCard);

            return AnalysisHuCardListMultiple(chair, huCard, huType, handCard, ref fixedCard,list, countOutMj);
        }

        /// <summary>
        /// 获取杠牌的类型
        /// </summary>
        /// <param name="cCard"></param>
        /// <returns></returns>
        public enGangType CheckGangType(byte cbCard)
        {
            if (MahjongDef.gInvalidMahjongValue == cbCard)
            {
                return enGangType.Unknown;
            }
            List<byte> activeCard = CopyActiveCard();

            //是否是暗杠
            if (activeCard.FindAll(delegate(byte checkCard) { return checkCard == cbCard; }).Count >= 4)
            {
                return enGangType.AnGang;
            }

            clsFixedCard fixed_counterpart = new clsFixedCard();
            _playerCard.CopyACounterpartForFixedCard(ref fixed_counterpart);

            if (fixed_counterpart.fixedCard.Count > 0)//找补杠
            {
                foreach (var fixedCard in fixed_counterpart.fixedCard)
                {
                    if ((fixedCard.fixedType == enFixedCardType.FixedCardType_Peng) && (cbCard == fixedCard.card))
                    {
                        return enGangType.BuGang;
                    }
                }
            }
            return enGangType.Unknown;
        }

        /// <summary>
        /// 获取我当前紧需的牌
        /// </summary>
        /// <param name="vNeedCard"></param>
        public void GetMeNeedCard(List<byte> vNeedCard, bool isContainsHuCard)
        {
            vNeedCard.Clear();

            if (isContainsHuCard && (_playerCard.tingCard.Count() > 0))//如果已经听牌,就需要听的牌
            {
                vNeedCard.AddRange(_playerCard.tingCard);
            }

            ConfigCategoryToNormal(vNeedCard);
        }

        /// <summary>
        /// 取该玩家打出哪些牌之后可以听牌
        /// </summary>
        /// <param name="pOutCard"></param>
        public void GetTingAfterOutCardAry(List<byte> outAry)
        {
            if (null == outAry)
            {
                return;
            }
            outAry.Clear();

            List<byte> activeCard = CopyActiveCard();
            if ((activeCard.Count() % 3) != 2)
            {
                return;
            }

            byte tempCard = MahjongDef.gInvalidMahjongValue;

            for (int i = 0; i < activeCard.Count(); i++)
            {
                tempCard = activeCard[i];
                activeCard[i] = MahjongDef.gInvalidMahjongValue;

                if (MahjongGeneralAlgorithm.CheckIfCanTingCardArrayForWHMJ(activeCard, new List<byte>()))
                {
                    outAry.Add(tempCard);
                }

                activeCard[i] = tempCard;
            }
        }

        /// <summary>
        /// 是否可以胡某张牌
        /// </summary>
        /// <param name="cbCard"></param>
        /// <returns></returns>
        public bool CheckIfCanHuACard(byte cbCard)
        {
            if (MahjongDef.gInvalidMahjongValue == cbCard)
            {
                return false;
            }

            if (_playerCard.tingCard.Count() < 1)
            {
                return false;
            }
            //7对不能胡
            if (MahjongGeneralAlgorithm.IsHuSevenPairStruct(new List<byte>(cbCard)))
            {
                return false;
            }

            return _playerCard.tingCard.Contains(cbCard);
        }
        /// <summary>
        /// 检查独一
        /// </summary>
        /// <param name="cbCard"></param>
        /// <returns></returns>
        public bool CheckHuIsSingleOne(byte cbCard) {
            if (MahjongDef.gInvalidMahjongValue == cbCard)
            {
                return false;
            }

            if (_playerCard.tingCard.Count() < 1)
            {
                return false;
            }

            return _playerCard.tingCard.Count == 1&& _playerCard.tingCard.Contains(cbCard);
        }

        /// <summary>
        /// 是否可以吃某张牌
        /// 返回值为list 包括可吃的选择 0位左 1为中 2为右
        /// </summary>
        /// <param name="cbCard"></param>
        /// <returns></returns>
        public List<int> CheckIfCanChiACard(List<byte> list,byte cbCard)
        {
            List<int> list1 = new List<int>();
            if (MahjongDef.gInvalidMahjongValue == cbCard)
            {
                return list1;//空list
            }
            if(cbCard >= 0x31)
            {
                return list1;//空list
            }
            int canChi = 0;
            if(list.Contains((byte)((int)cbCard-1)) && list.Contains((byte)((int)cbCard + 1)))
            {
                canChi++;
                list1.Add(1);//中间
            }
            if (list.Contains((byte)((int)cbCard - 1)) && list.Contains((byte)((int)cbCard - 2)))
            {
                canChi++;
                list1.Add(0);//左边
            }
            if (list.Contains((byte)((int)cbCard + 2)) && list.Contains((byte)((int)cbCard + 1)))
            {
                canChi++;
                list1.Add(2);//右边
            }
            return list1;//list长度为可吃选择数
            
        }

        /// <summary>
        /// 检查该家打出某张牌之后，是否可以听牌
        /// </summary>
        /// <param name="cCard">打出的这张牌</param>
        /// <returns>是否听牌</returns>
        public bool CheckIfCanTingAfterOutACard(byte cbCard)
        {
            if (MahjongDef.gInvalidMahjongValue == cbCard)
            {
                return false;
            }

            List<byte> activeCard = CopyActiveCard();

            if (activeCard.Remove(cbCard))
            {
                return MahjongGeneralAlgorithm.CheckIfCanTingCardArrayForWHMJ(activeCard, new List<byte>());
            }
            return false;
        }

        /// <summary>
        /// 清空投票相关
        /// </summary>
        public void ClearVote()
        {
            _voteResult = MahjongDef.gVoteResult_Null;
            _voteRight = MahjongDef.gVoteRightMask_Null;
        }


        #endregion

        #region 牌型解析

        /// <summary>
        /// 解析牌阵
        /// </summary>
        /// <param name="cbHuCard"></param>
        /// <param name="handCard"></param>
        /// <param name="fixedCard"></param>
        /// <returns></returns>
        public int[] AnalysisHuCardListMultiple(byte chair, byte cbHuCard, enHuCardType huType, List<byte> handCard, ref clsFixedCard fixedCard, List<byte> list, int countOutMj)
        {
            //胡牌牌阵
            handCard.Add(cbHuCard);
            handCard.RemoveAll(delegate (byte checkCard) { return checkCard == MahjongDef.gInvalidMahjongValue; });
            //底分
            int score = 1;
            bool qingyise_baofen = false;
            bool qyj_baofen = false;
            if (2 == (handCard.Count % 3))
            {
                handCard.Sort();

                JieSuan.Clear();
                //if (enHuCardType.HuCardType_PingHu == huType)
                //    _gameServer._playerAry[chair].VecType += "平牌+1 ";
                if (enHuCardType.HuCardType_ZiMo == huType)
                    _gameServer._playerAry[chair].VecType += "自摸+1 ";
                //if (enHuCardType.HuCardType_GangShangHua == huType)
                //    _gameServer._playerAry[chair].VecType += "杠后乘二倍 ";
                //if (_gameServer._playerAry[chair]._isBaoTing)
                //    _gameServer._playerAry[chair].VecType += "豹子胡x2 ";

                //解析牌阵

                //处理对对胡用的listNew
                bool duiduihu = true;
                List<byte> listNew = new List<byte>();
                for (int i = 0; i < list.Count; i++)
                {
                    listNew.Add(list[i]);
                }
                listNew.Add(cbHuCard);

                Dictionary<byte, int> table = new Dictionary<byte, int>();

                for (int i = 0; i < listNew.Count; i++)
                {

                    if (!table.ContainsKey(listNew[i]))
                    {
                        table[listNew[i]] = 1;
                    }
                    else
                    {
                        table[listNew[i]]++;
                    }
                }
                //遍历hashTable
                int countDui = 0;
                foreach (int value in table.Values)
                {
                    if (value == 4 || value == 1)
                    {
                        duiduihu = false;
                        break;
                    }
                    if (value == 2)
                    {
                        countDui++;
                    }
                    if (countDui > 1)
                    {
                        duiduihu = false;
                        break;
                    }
                }
                if (fixedCard.fixedCard.Count != 0)
                {//有吃牌 不能为对对胡
                    for (int i = 0; i < fixedCard.fixedCard.Count; i++)
                    {
                        if (fixedCard.fixedCard[i].fixedType == MahjongAlgorithmForMGMJ.enFixedCardType.FixedCardType_Chi)
                        {
                            duiduihu = false;
                        }
                    }
                }             
                
                List<byte> listCopy = new List<byte>();
                List<byte> listChongTian = new List<byte>();
                for (int i = 0; i < list.Count; i++)
                {
                    listCopy.Add(list[i]);
                    listChongTian.Add(list[i]);
                }
                //冲天 碰杠之和最大为1
                int pengGang = 0;
                
                if (fixedCard.fixedCard.Count != 0)
                {
                    for (int i = 0; i < fixedCard.fixedCard.Count; i++)
                    {
                        if (fixedCard.fixedCard[i].fixedType == MahjongAlgorithmForMGMJ.enFixedCardType.FixedCardType_MGang
                            || fixedCard.fixedCard[i].fixedType == MahjongAlgorithmForMGMJ.enFixedCardType.FixedCardType_BGang
                            || fixedCard.fixedCard[i].fixedType == MahjongAlgorithmForMGMJ.enFixedCardType.FixedCardType_AGang)
                        {//杠牌加一张 不算四归一
                            listCopy.Add(fixedCard.fixedCard[i].card);
                            pengGang++;
                        }
                        if (fixedCard.fixedCard[i].fixedType == MahjongAlgorithmForMGMJ.enFixedCardType.FixedCardType_Peng)
                        {//碰牌加三张 可能形成四归一
                            listCopy.Add(fixedCard.fixedCard[i].card);
                            listCopy.Add(fixedCard.fixedCard[i].card);
                            listCopy.Add(fixedCard.fixedCard[i].card);
                            pengGang++;
                        }
                        if (fixedCard.fixedCard[i].fixedType == MahjongAlgorithmForMGMJ.enFixedCardType.FixedCardType_Chi)
                        {//吃 根据类型 加上三张牌
                            listCopy.Add(fixedCard.fixedCard[i].card);
                            listChongTian.Add(fixedCard.fixedCard[i].card);
                            if (fixedCard.fixedCard[i].chiSel == 0)
                            {
                                listCopy.Add((byte)((int)fixedCard.fixedCard[i].card - 1));
                                listCopy.Add((byte)((int)fixedCard.fixedCard[i].card - 2));
                                listChongTian.Add((byte)((int)fixedCard.fixedCard[i].card - 1));
                                listChongTian.Add((byte)((int)fixedCard.fixedCard[i].card - 2));
                            }
                            if (fixedCard.fixedCard[i].chiSel == 1)
                            {
                                listCopy.Add((byte)((int)fixedCard.fixedCard[i].card - 1));
                                listCopy.Add((byte)((int)fixedCard.fixedCard[i].card + 1));
                                listChongTian.Add((byte)((int)fixedCard.fixedCard[i].card - 1));
                                listChongTian.Add((byte)((int)fixedCard.fixedCard[i].card + 1));
                            }
                            if (fixedCard.fixedCard[i].chiSel == 2)
                            {
                                listCopy.Add((byte)((int)fixedCard.fixedCard[i].card + 1));
                                listCopy.Add((byte)((int)fixedCard.fixedCard[i].card + 2));
                                listChongTian.Add((byte)((int)fixedCard.fixedCard[i].card + 1));
                                listChongTian.Add((byte)((int)fixedCard.fixedCard[i].card + 2));
                            }
                        }
                    }
                }
                //加上 胡的那张牌
                listCopy.Add(cbHuCard);
                listChongTian.Add(cbHuCard);
                listCopy.Sort();
                listChongTian.Sort();
                ////如果连续四张牌相同 形成四归一
                //int siguiyi = 0;
                // for (int i = 0; i <= listCopy.Count - 4; i++)
                // {
                //     if (listCopy[i] == listCopy[i + 1] && listCopy[i + 1] == listCopy[i + 2] && listCopy[i + 2] == listCopy[i + 3])
                //     {
                //         siguiyi++; ;
                //     }
                // }
                // if (_gameServer._tableConfig.daiDaPai == 1 && siguiyi>0)
                // {
                //     score += siguiyi;
                //     _gameServer._playerAry[chair].VecType += "四归一+ "+siguiyi;
                // }

                // bool chongtian = false;
                // bool chongtianWan = true;
                // bool chongtianTiao = true;
                // bool chongtianTong = true;
                // for (int i = 1; i < 10; i++)
                // {//万
                //     if (!listChongTian.Contains((byte)i))
                //     {
                //         chongtianWan = false;
                //         break;
                //     }
                // }
                // for (int i = 17; i < 26; i++)
                // {//筒
                //     if (!listChongTian.Contains((byte)i))
                //     {
                //         chongtianTong = false;
                //         break;
                //     }
                // }
                // for (int i = 33; i < 42; i++)
                // {//条
                //     if (!listChongTian.Contains((byte)i))
                //     {
                //         chongtianTiao = false;
                //         break;
                //     }
                // }
                // byte first = 0;
                // byte last = 0;
                // if (chongtianWan)
                // {
                //     first = 1;
                //     last = 9;
                // }
                // if (chongtianTong)
                // {
                //     first = 17;
                //     last = 25;
                // }
                // if (chongtianTiao)
                // {
                //     first = 33;
                //     last = 41;
                // }
                // if (chongtianWan || chongtianTiao || chongtianTong)
                // {
                //     if (pengGang > 1)
                //     {
                //         chongtian = false;
                //     }
                //     for(byte j = first; j <= last; j++)
                //     {
                //         for(byte i = 0; i < listChongTian.Count; i++)
                //         {
                //             if (listChongTian[i] == j)
                //             {
                //                 listChongTian.RemoveAt(i);
                //                 break;
                //             }                                                 
                //         }
                //     }
                //     if(pengGang == 0)
                //     {//listChongTian还有5个值
                //         if (listChongTian.Count != 5)
                //         {
                //             _gameServer.PrintLog("冲天算分出错！");
                //         }
                //         else
                //         {
                //             listChongTian.Sort();
                //             if (listChongTian[0] == listChongTian[1] && listChongTian[2] == listChongTian[3] && listChongTian[3] == listChongTian[4])
                //             {
                //                 chongtian = true;
                //             }
                //             if (listChongTian[0] == listChongTian[1] && listChongTian[0] == listChongTian[2] && listChongTian[3] == listChongTian[4])
                //             {
                //                 chongtian = true;
                //             }
                //             if (listChongTian[0] == listChongTian[1] && listChongTian[2] + 1 == listChongTian[3] && listChongTian[3] + 1 == listChongTian[4])
                //             {
                //                 chongtian = true;
                //             }
                //             if (listChongTian[0] + 1 == listChongTian[1] && listChongTian[1] + 1 == listChongTian[2] && listChongTian[3] == listChongTian[4])
                //             {
                //                 chongtian = true;
                //             }
                //         }
                //     }
                //     if(pengGang == 1)
                //     {
                //         if(listChongTian.Count != 2)
                //         {
                //             _gameServer.PrintLog("冲天算分报错！");
                //         }
                //         else
                //         { 
                //             if(listChongTian[0] == listChongTian[1])
                //             {
                //                 chongtian = true;
                //             }
                //         }
                //     }
                // }

                // if (_gameServer._tableConfig.daiDaPai == 1 && chongtian)
                // {
                //     score += 2;
                //     _gameServer._playerAry[chair].VecType += "冲天+2 ";
                // }

                //清一色 混一色
                int countWan = 0;
                int countTiao = 0;
                int countTong = 0;
                int countZhi = 0;
                bool yaoJiu = false;

                for (int i = 0; i < listCopy.Count; i++)
                {
                    if (MahjongGeneralAlgorithm.GetMahjongColor(listCopy[i]) == MahjongDef.gMahjongColor_Wan)
                    {
                        countWan++;
                    }
                    if (MahjongGeneralAlgorithm.GetMahjongColor(listCopy[i]) == MahjongDef.gMahjongColor_Tong)
                    {
                        countTong++;
                    }
                    if (MahjongGeneralAlgorithm.GetMahjongColor(listCopy[i]) == MahjongDef.gMahjongColor_Tiao)
                    {
                        countTiao++;
                    }
                    if (MahjongGeneralAlgorithm.GetMahjongColor(listCopy[i]) == MahjongDef.gMahjongColor_Zhi)
                    {
                        countZhi++;
                    }
                    else
                    {
                        if (listCopy[i]%16 != 1 && listCopy[i]%16 != 9)
                        {
                            yaoJiu = false;
                        }
                    }
                }

                if (_gameServer._tableConfig.daiDaPai == 1 && duiduihu && !yaoJiu)
                {
                    score += 4;
                    _gameServer._playerAry[chair].VecType += "对对胡+4 ";
                }

                if ( (countWan == listCopy.Count || countTong == listCopy.Count || countTiao == listCopy.Count))
                {//清一色
                    score += 4;
                    _gameServer._playerAry[chair].VecType += "清一色+4 ";

                    ////判断fixedcard是否满足清一色 全幺九
                    //if (fixedCard.fixedCard.Count >= 3)
                    //{
                    //    if (MahjongGeneralAlgorithm.GetMahjongColor(fixedCard.fixedCard[0].card) == MahjongGeneralAlgorithm.GetMahjongColor(cbHuCard))
                    //    {
                    //        //清一色包分
                    //        qingyise_baofen = true;
                    //        if(enHuCardType.HuCardType_ZiMo != huType){
                    //            _gameServer._playerAry[chair].VecType += "清一色包分 ";
                    //        }
                    //    }
                    //}
                }
                if (countZhi != 0 && !yaoJiu)
                {
                    if ( countZhi != 0 && (countWan + countTong == 0 || countWan + countTiao == 0 || countTong + countTiao
                         == 0))
                    {//混一色
                        score += 3;
                        _gameServer._playerAry[chair].VecType += "混一色+3 ";
                    }
                }
                //if (_gameServer._tableConfig.daiDaPai == 1 && yaoJiu)
                //{//全幺九
                //    score += 15;
                //    _gameServer._playerAry[chair].VecType += "全幺九+15 ";
                //    if (fixedCard.fixedCard.Count >= 3)
                //    {//全幺九包分
                //        if(MahjongGeneralAlgorithm.GetMahjongColor(cbHuCard) == MahjongDef.gMahjongColor_Zhi
                //            || MahjongGeneralAlgorithm.GetMahjongColor(cbHuCard) %10 == 1
                //            || MahjongGeneralAlgorithm.GetMahjongColor(cbHuCard) % 10 == 9)
                //        {
                //            qyj_baofen = true;
                //            //_gameServer._playerAry[chair].VecType += "全幺九包分 ";
                //        }
                //    }
                //}         

                //天胡   
                if (chair == _gameServer.BankerChair && _gameServer._playerAry[chair].PlayerCard.poolCard.Count == 0 && fixedCard.fixedCard.Count == 0 && countOutMj == 0)
                {
                    score += 5;
                    _gameServer._playerAry[chair]._vecType += "天胡+5 ";
                }

                ////地胡
                //if (chair != _gameServer.BankerChair && _gameServer._playerAry[chair].PlayerCard.poolCard.Count == 0 && fixedCard.fixedCard.Count == 0 && countOutMj == 0)
                //{
                //    score += 10;
                //    _gameServer._playerAry[chair].VecType += "地胡+10 ";

                //}

                if (MahjongPatternAlgorithm.ParseCards(handCard))
                {
                    
                    //else
                    //{
                    //    score *= 1;                      
                    //}

                    clsBalanceFan parseFan = new clsBalanceFan();
                    //胡牌类型都是平胡
                    parseFan.cardPattern = enMahjongPattern.MahjongPattern_PingHu;

                    parseFan.huType = huType;

                    //检查杠上花
                    if (enHuCardType.HuCardType_GangShangHua == huType)
                    {
                        score += 2;
                        _gameServer._playerAry[chair].VecType += "杠后开花+2 ";
                        parseFan.GangHouKaiHua = true;
                    }

                    foreach (var triply in fixedCard.fixedCard)
                    {
                        if (triply.fixedType == enFixedCardType.FixedCardType_MGang)
                        {
                            parseFan.MingGang++;
                        }
                        else if (triply.fixedType == enFixedCardType.FixedCardType_BGang)
                        {
                            parseFan.BuGang++;
                        }
                        else if (triply.fixedType == enFixedCardType.FixedCardType_AGang)
                        {
                            parseFan.AnGang++;
                        }
                    }
                    //检查抢杠
                    if (enHuCardType.HuCardType_QiangGangHu == huType)
                    {
                        parseFan.QiangGang = true;
                        _gameServer._playerAry[chair].VecType += "平胡+1 ";
                        _gameServer._playerAry[chair].VecType += "抢杠胡算自摸 ";
                    }

                    parseFan.Package(ref this._jieSuan);
                }
            }
            int[] arr = new int[3];
            arr[0] = score;
            arr[1] = qingyise_baofen == true?1:0;
            arr[2] = qyj_baofen == true ? 1 : 0;
            return arr;
        }

        #endregion

        #region 内部公共辅助方法

        /// <summary>
        /// 复制一份活动牌，如果抓到的牌不为空把抓到的这张牌也放进去
        /// </summary>
        /// <returns></returns>
        private List<byte> CopyActiveCard(bool bAddHoldCard = true, byte cbCard = MahjongDef.gInvalidMahjongValue)
        {
            List<byte> activeCard = new List<byte>();
            _playerCard.CopyACounterpartForActiveCard(activeCard);

            //是否需要加上抓到的这张牌
            if (bAddHoldCard && (MahjongDef.gInvalidMahjongValue != HoldCard))
            {
                activeCard.Add(HoldCard);
            }
            if (MahjongDef.gInvalidMahjongValue != cbCard)
            {
                activeCard.Add(cbCard);
            }

            //移除无效牌并排序
            activeCard.RemoveAll(delegate(byte checkCard) { return checkCard == MahjongDef.gInvalidMahjongValue; });
            activeCard.Sort();
            return activeCard;
        }
        /// <summary>
        /// 取玩家可以听的牌剩余张数
        /// </summary>
        /// <returns></returns>
        private int GetMeTingCardLeftCount(List<byte> cardList = null)
        {
            List<byte> activeCard = null;
            if (null == cardList)
            {
                return 0;
            }
            else
            {
                activeCard = new List<byte>(cardList);
            }

            //听的牌阵
            List<byte> ting = new List<byte>();

            //听的牌剩余张数
            int leftCount = 0;

            if (activeCard.Count % 3 == 1)
            {
                if (MahjongGeneralAlgorithm.CheckIfCanTingCardArrayForWHMJ(activeCard, ting))
                {
                    for (int i = 0; i < ting.Count; i++)
                    {
                        leftCount += _gameServer._rememberCard.GetCardLeftCount(ting[i], activeCard);
                    }
                }
            }
            else
            {
                int maxCount = 0;//记录最大张数
                byte cbOutCard = MahjongDef.gInvalidMahjongValue;//移除哪张牌

                for (int i = 0; i < activeCard.Count; i++)
                {
                    cbOutCard = activeCard[i];
                    activeCard[i] = MahjongDef.gInvalidMahjongValue;

                    if (MahjongGeneralAlgorithm.CheckIfCanTingCardArrayForWHMJ(activeCard, ting))
                    {
                        activeCard[i] = cbOutCard;

                        for (int j = 0; j < ting.Count; j++)
                        {
                            leftCount += _gameServer._rememberCard.GetCardLeftCount(ting[j], activeCard);
                        }

                        if (leftCount > maxCount)//记录打出这张牌之后听牌的剩余最多张数
                        {
                            maxCount = leftCount;
                        }
                    }

                    activeCard[i] = cbOutCard;
                }

                leftCount = maxCount;
            }
            return leftCount;
        }
        /// <summary>
        /// 查找打出哪些牌之后可以听牌
        /// </summary>
        /// <param name="outAry"></param>
        private void SelTingByOutCard(List<byte> outAry)
        {
            outAry.Clear();
            List<byte> activeCard = CopyActiveCard();

            byte cbCard = MahjongDef.gInvalidMahjongValue;
            for (int i = 0; i < activeCard.Count; i++)
            {
                cbCard = activeCard[i];
                activeCard[i] = MahjongDef.gInvalidMahjongValue;

                if (MahjongGeneralAlgorithm.CheckIfCanTingCardArrayForWHMJ(activeCard, new List<byte>()))
                {
                    outAry.Add(cbCard);
                }

                activeCard[i] = cbCard;
            }
        }
        /// <summary>
        /// 选择打出某张牌之后听牌
        /// </summary>
        /// <returns></returns>
        private byte SelACardOutThenTing()
        {
            byte cbCard = MahjongDef.gInvalidMahjongValue;

            List<byte> activeCard = CopyActiveCard();
            if ((activeCard.Count % 3) != 2)
            {
                return cbCard;
            }

            //1、找出打出后仍然可以报听牌
            List<byte> outAry = new List<byte>();
            SelTingByOutCard(outAry);

            if (outAry.Count == 0)
            {
                return cbCard;
            }

            //最多只有一个,那只能打这张牌
            if (outAry.Count == 1)
            {
                return outAry[0];
            }

            int maxMultiple = 0;    //可以胡的最大倍数
            int maxLeftCount = 0;   //剩余的最多张数

            int multiple = 0;
            int leftCount = 0;

            Random rand = MahjongGeneralAlgorithm.GetRandomObject();

            List<byte> activeCard_counterpart = new List<byte>();
            List<byte> ting = new List<byte>();

            List<byte> handCard = new List<byte>();
            _playerCard.CopyACounterpartForActiveCard(handCard);

            clsFixedCard fixedCard = new clsFixedCard();
            _playerCard.CopyACounterpartForFixedCard(ref fixedCard);

            for (int i = 0; i < outAry.Count; i++)//有多个的话，就需要考察打出哪些可以胡的牌最多和听的牌最多
            {
                activeCard_counterpart.Clear();
                activeCard_counterpart.AddRange(activeCard);
                activeCard_counterpart.Remove(outAry[i]);

                //检查打出这张牌之后是否可以听牌,如果可以听牌，就去收集听牌剩余张数，和可以胡的最大倍数
                if (MahjongGeneralAlgorithm.CheckIfCanTingCardArrayForWHMJ(activeCard_counterpart, ting))
                {
                    //听牌张数
                    leftCount = 0;
                    foreach (var tingcard in ting)
                    {
                        leftCount += _gameServer._rememberCard.GetCardLeftCount(tingcard, activeCard_counterpart);
                    }

                    int max = 0;
                    int mul = 0;
                    for (int j = 0; j < ting.Count; j++)
                    {
                        handCard.Clear();
                        handCard.AddRange(activeCard_counterpart);
                        //mul = AnalysisHuCardListMultiple(0,ting[j], enHuCardType.HuCardType_ZiMo, handCard, ref fixedCard);
                        //if (mul > max)
                        //{
                        //    max = mul;
                        //}
                    }

                    multiple = max;
                }

                if ((leftCount > maxLeftCount) && (multiple >= maxMultiple))//两个指标都优，肯定打这张
                {
                    cbCard = outAry[i];
                    maxMultiple = multiple;
                    maxLeftCount = leftCount;
                }
                else if (0 == leftCount)//剩余牌没了,肯定不打这张
                {
                    continue;
                }
                else if ((leftCount < maxLeftCount) && ((multiple - maxMultiple) > rand.Next(1, 3)))//剩余张数少，但是牌型大了一些,就打这张
                {
                    cbCard = outAry[i];
                    maxMultiple = multiple;
                    maxLeftCount = leftCount;
                }
                else if (((leftCount - maxLeftCount) >= rand.Next(2, 5)) && ((multiple - maxMultiple) > rand.Next(-2, 0)))//剩余张数多,牌型小了没多少
                {
                    cbCard = outAry[i];
                    maxMultiple = multiple;
                    maxLeftCount = leftCount;
                }
            }
            if (MahjongDef.gInvalidMahjongValue == cbCard)
            {
                if (outAry.Count > 0)
                {
                    cbCard = outAry[0];
                }
            }

            if (MahjongDef.gInvalidMahjongValue == cbCard)
            {
                cbCard = outAry[rand.Next(0, outAry.Count)];
            }

            return cbCard;
        }
        /// <summary>
        /// 取一个最优的孤张打出
        /// </summary>
        /// <param name="vGuColl"></param>
        /// <returns></returns>
        private byte GetGoodGuCard(List<byte> vGuColl)
        {
            if (vGuColl.Count() == 0)
            {
                return MahjongDef.gInvalidMahjongValue;
            }
            if (vGuColl.Count() == 1)
            {
                return vGuColl[0];
            }
            vGuColl.Sort();

            //分成花牌和字牌
            List<byte> vZhiCard = new List<byte>();
            List<byte> vHuaCard = new List<byte>();

            for (int i = 0; i < vGuColl.Count(); i++)
            {
                if (MahjongDef.gInvalidMahjongValue == vGuColl[i])
                {
                    continue;
                }
                if (MahjongGeneralAlgorithm.GetMahjongColor(vGuColl[i]) == MahjongDef.gMahjongColor_Zhi)
                {
                    vZhiCard.Add(vGuColl[i]);
                }
                else
                {
                    vHuaCard.Add(vGuColl[i]);
                }
            }

            Random rand = MahjongGeneralAlgorithm.GetRandomObject();

            //优先打风牌
            if (vZhiCard.Count() > 0)
            {
                if (vZhiCard.Count() == 1)
                {
                    return vZhiCard[0];
                }

                for (int i = _gameServer._outCardRecord.Count; i > 0; i--)
                {
                    if (vZhiCard.Contains(_gameServer._outCardRecord[i - 1]))
                    {
                        return _gameServer._outCardRecord[i - 1];
                    }
                }
                return vZhiCard[rand.Next(0, vZhiCard.Count)];
            }

            //再在花牌中选择
            if (vHuaCard.Count() == 1)
            {
                return vHuaCard[0];
            }

            List<byte> outAry = new List<byte>();

            for (int i = 0; i < vHuaCard.Count(); i++)
            {
                //优先打1，9
                if ((MahjongGeneralAlgorithm.GetMahjongValue(vHuaCard[i]) == 1) || (MahjongGeneralAlgorithm.GetMahjongValue(vHuaCard[i]) == 9))
                {
                    outAry.Add(vHuaCard[i]);
                }
            }

            if (outAry.Count > 0)
            {
                for (int i = _gameServer._outCardRecord.Count; i > 0; i--)
                {
                    if (outAry.Contains(_gameServer._outCardRecord[i - 1]))
                    {
                        return _gameServer._outCardRecord[i - 1];
                    }
                }
                return outAry[rand.Next(0, outAry.Count)];
            }

            for (int i = _gameServer._outCardRecord.Count; i > 0; i--)
            {
                if (vGuColl.Contains(_gameServer._outCardRecord[i - 1]))
                {
                    return _gameServer._outCardRecord[i - 1];
                }
            }

            return vGuColl[0];
        }
        /// <summary>
        /// 选择一个相邻牌拆
        /// </summary>
        /// <param name="vXL"></param>
        /// <returns></returns>
        private byte SelectXL(List<clsSpiltXLWrapper> vXL)
        {
            if (vXL.Count() == 0)
            {
                return MahjongDef.gInvalidMahjongValue;
            }
            //找1,2/8,9
            byte cRe = MahjongDef.gInvalidMahjongValue;
            List<byte> activeCard = CopyActiveCard();
            for (int i = 0; i < vXL.Count(); i++)
            {
                if (vXL[i].IsBianWrapper())
                {
                    cRe = vXL[i].GetMinCard();

                    //如果已经是绝张，就直接打出去
                    if (_gameServer._rememberCard.GetCardLeftCount(vXL[i].GetLeftValue(), activeCard) == 0)
                    {
                        return cRe;
                    }
                }
            }

            //找两边牌已经全部绝张了了的
            byte cl = MahjongDef.gInvalidMahjongValue;
            byte cr = MahjongDef.gInvalidMahjongValue;
            for (int i = 0; i < vXL.Count(); i++)
            {
                if (vXL[i].IsBianWrapper())
                {
                    continue;
                }
                cl = vXL[i].GetLeftValue();
                cr = vXL[i].GetRightValue();
                if ((_gameServer._rememberCard.GetCardLeftCount(cl, activeCard) == 0) &&
                    (_gameServer._rememberCard.GetCardLeftCount(cr, activeCard) == 0))
                {
                    return vXL[i].GetMinCard();
                }
            }

            return cRe;
        }
        /// <summary>
        /// 选择一个对子拆
        /// </summary>
        /// <param name="vPair"></param>
        /// <returns></returns>
        private byte SelectPair(List<byte> vPair)
        {
            if (vPair.Count() == 0)
            {
                return MahjongDef.gInvalidMahjongValue;
            }

            List<byte> findpair = new List<byte>();
            findpair.Clear();

            //1、找绝张对
            List<byte> activeCard = CopyActiveCard();
            for (int i = 0; i < vPair.Count(); i++)
            {
                if (_gameServer._rememberCard.GetCardLeftCount(vPair[i], activeCard) == 0)
                {
                    findpair.Add(vPair[i]);
                }
            }
            if (findpair.Count > 0)
            {
                return findpair[MahjongGeneralAlgorithm.GetRandomObject().Next(0, findpair.Count)];
            }

            //2、456对
            findpair.Clear();
            for (int i = 0; i < vPair.Count(); i++)
            {
                if ((MahjongGeneralAlgorithm.GetMahjongColor(vPair[i]) < MahjongDef.gMahjongColor_Zhi) && ((MahjongGeneralAlgorithm.GetMahjongValue(vPair[i]) > 3) || (MahjongGeneralAlgorithm.GetMahjongValue(vPair[i]) < 7)))
                {
                    findpair.Add(vPair[i]);
                }
            }
            if (findpair.Count > 0)
            {
                return findpair[MahjongGeneralAlgorithm.GetRandomObject().Next(0, findpair.Count)];
            }

            //3、238对
            findpair.Clear();
            for (int i = 0; i < vPair.Count(); i++)
            {
                if ((MahjongGeneralAlgorithm.GetMahjongColor(vPair[i]) < MahjongDef.gMahjongColor_Zhi) && ((2 == MahjongGeneralAlgorithm.GetMahjongValue(vPair[i])) || (3 == MahjongGeneralAlgorithm.GetMahjongValue(vPair[i])) || (8 == MahjongGeneralAlgorithm.GetMahjongValue(vPair[i]))))
                {
                    findpair.Add(vPair[i]);
                }
            }
            if (findpair.Count > 0)
            {
                return findpair[MahjongGeneralAlgorithm.GetRandomObject().Next(0, findpair.Count)];
            }

            //1、找1，9对
            findpair.Clear();
            for (int i = 0; i < vPair.Count(); i++)
            {
                if ((MahjongGeneralAlgorithm.GetMahjongColor(vPair[i]) < MahjongDef.gMahjongColor_Zhi) && ((1 == MahjongGeneralAlgorithm.GetMahjongValue(vPair[i])) || (9 == MahjongGeneralAlgorithm.GetMahjongValue(vPair[i]))))
                {
                    findpair.Add(vPair[i]);
                }
            }
            if (findpair.Count > 0)
            {
                return findpair[MahjongGeneralAlgorithm.GetRandomObject().Next(0, findpair.Count)];
            }

            //没有
            return MahjongDef.gInvalidMahjongValue;
        }
        /// <summary>
        /// 从孤张中选择一张较合适的牌打出
        /// </summary>
        /// <param name="vGuCard"></param>
        /// <returns></returns>
        private byte GetOutCardFromGuCard(List<byte> vGuCard)
        {
            //如果没有，返回一个非法的牌值
            if (vGuCard.Count() == 0)
            {
                return MahjongDef.gInvalidMahjongValue;
            }
            //如果只有一个就直接返回
            if (vGuCard.Count() == 1)
            {
                return vGuCard[0];
            }

            //如果大于3张的话，需要再进行一次去顺去刻操作
            List<byte> vOutCardColl = new List<byte>();
            if (vGuCard.Count() > 3)
            {
                MahjongGeneralAlgorithm.GetCardListGuCards(vGuCard, vOutCardColl);
            }
            else
            {
                vOutCardColl.AddRange(vGuCard);
            }

            if (vOutCardColl.Count() == 0)
            {
                return vGuCard[0];
            }
            if (vOutCardColl.Count() == 1)
            {
                return vOutCardColl[0];
            }
            vOutCardColl.Sort();

            /*
            去顺去刻后往下的孤张，往下的牌有以下可能的组成：
            对子、相邻牌、相隔牌、散牌

            优先去对子，再去相邻牌，再去相隔牌，最后剩下散牌，
            由于是优先去对子，所以往下的散牌中有可能会有与对子有关联的牌，所以散牌分为，绝对孤张，相隔孤张，相对孤张

            打牌优先级：
            绝对孤张中的风牌或是19牌

            相隔孤张中的19牌

            相对孤张中的19牌

            如果对子有多个的话，优先拆19对如果无19对，再拆绝张对

            相邻牌，优先打12，89这样的相邻牌，如果没有，就找两边牌都为绝张的相邻组,如果还无，就打特征数最小的相邻组中的相对小点数牌
            */

            List<byte> vXDGuCard = new List<byte>();		//相对孤张,该容器里的孤张和其他的对子有关联
            List<byte> vJDGuCard = new List<byte>();		//绝对孤张,不和任何其他有关联，优先打这里的
            List<byte> vXGGuCard = new List<byte>();		//相隔孤张
            List<byte> vPair = new List<byte>();			//对子集合
            List<clsSpiltXLWrapper> vXLWrapper = new List<clsSpiltXLWrapper>(); //相邻集合

            MahjongGeneralAlgorithm.SpiltGuCard(vOutCardColl, vJDGuCard, vXGGuCard, vXDGuCard, vPair, vXLWrapper);

            //先检查绝对孤张集:风牌和花牌
            byte cSelectCard = MahjongDef.gInvalidMahjongValue;
            byte cRe = MahjongDef.gInvalidMahjongValue;
            if (vJDGuCard.Count() > 0)
            {
                cRe = GetGoodGuCard(vJDGuCard);
                if (MahjongGeneralAlgorithm.GetMahjongColor(cRe) == MahjongDef.gMahjongColor_Zhi)
                {
                    return cRe;
                }
                //如果是456这样的牌，再检查是否有更合适的可以打出，如果没有，就打这张
                if ((MahjongGeneralAlgorithm.GetMahjongValue(cRe) > 3) && (MahjongGeneralAlgorithm.GetMahjongValue(cRe) < 7))
                {
                    //检查相隔孤张中是否有1，9，这样的牌
                    if ((vXGGuCard.Count() > 0) && (MahjongGeneralAlgorithm.GetRandomObject().Next(0, 100) > 10))
                    {
                        for (int i = 0; i < vXGGuCard.Count(); i++)
                        {
                            if ((MahjongGeneralAlgorithm.GetMahjongValue(vXGGuCard[i]) == 1) || (MahjongGeneralAlgorithm.GetMahjongValue(vXGGuCard[i]) == 9))
                            {
                                return vXGGuCard[i];
                            }
                        }
                    }
                    //检查相对孤张中是否有1，9这样的牌
                    if ((vXDGuCard.Count() > 0) && (MahjongGeneralAlgorithm.GetRandomObject().Next(0, 100) > 10))
                    {
                        for (int i = 0; i < vXDGuCard.Count(); i++)
                        {
                            if ((MahjongGeneralAlgorithm.GetMahjongValue(vXDGuCard[i]) == 1) || (MahjongGeneralAlgorithm.GetMahjongValue(vXDGuCard[i]) == 9))
                            {
                                return vXDGuCard[i];
                            }
                        }
                    }
                    if ((vXLWrapper.Count() > 0) && (MahjongGeneralAlgorithm.GetRandomObject().Next(0, 100) > 10))//如果相邻牌有12，89这样的，就打出去
                    {
                        //是否有12，89这样的相邻，如果有，就选一个打出去
                        cSelectCard = SelectXL(vXLWrapper);
                        if (MahjongDef.gInvalidMahjongValue != cSelectCard)
                        {
                            return cSelectCard;
                        }
                    }
                    if (vPair.Count() > 1)//如果对子多于一个，检查对子
                    {
                        if (MahjongGeneralAlgorithm.GetRandomObject().Next(0, 100) > 10)
                        {
                            //优先找绝对对
                            List<byte> findpair = new List<byte>();
                            findpair.Clear();

                            //1、找绝张对
                            List<byte> activeCard = CopyActiveCard();
                            for (int i = 0; i < vPair.Count(); i++)
                            {
                                if (_gameServer._rememberCard.GetCardLeftCount(vPair[i], activeCard) == 0)
                                {
                                    findpair.Add(vPair[i]);
                                }
                            }
                            if (findpair.Count > 0)
                            {
                                return findpair[MahjongGeneralAlgorithm.GetRandomObject().Next(0, findpair.Count)];
                            }
                        }

                        if (MahjongGeneralAlgorithm.GetRandomObject().Next(0, 100) > 80)
                        {
                            //是否有19对，绝张对，如果有，就拆这样的对子
                            cSelectCard = SelectPair(vPair);
                            if (MahjongDef.gInvalidMahjongValue != cSelectCard)
                            {
                                return cSelectCard;
                            }
                        }
                    }
                }
                return cRe;
            }
            if (vXGGuCard.Count() > 0)
            {
                cRe = GetGoodGuCard(vXGGuCard);
                if (MahjongGeneralAlgorithm.GetMahjongColor(cRe) == MahjongDef.gMahjongColor_Zhi)
                {
                    return cRe;
                }
                if ((MahjongGeneralAlgorithm.GetMahjongValue(cRe) > 2) && (MahjongGeneralAlgorithm.GetMahjongValue(cRe) < 8))
                {
                    //检查相对孤张中是否有1，9这样的牌
                    if (vXDGuCard.Count() > 0)
                    {
                        for (int i = 0; i < vXDGuCard.Count(); i++)
                        {
                            if ((MahjongGeneralAlgorithm.GetMahjongValue(vXDGuCard[i]) == 1) || (MahjongGeneralAlgorithm.GetMahjongValue(vXDGuCard[i]) == 9))
                            {
                                return vXDGuCard[i];
                            }
                        }
                    }
                    if (vXLWrapper.Count() > 0)//如果相邻牌有12，89这样的，就打出去
                    {
                        //是否有12，89这样的相邻，如果有，就选一个打出去
                        cSelectCard = SelectXL(vXLWrapper);
                        if (MahjongDef.gInvalidMahjongValue != cSelectCard)
                        {
                            return cSelectCard;
                        }
                    }
                    if (vPair.Count() > 1)//如果对子多于一个，检查对子
                    {
                        //是否有19对，绝张对，如果有，就拆这样的对子
                        cSelectCard = SelectPair(vPair);
                        if (MahjongDef.gInvalidMahjongValue != cSelectCard)
                        {
                            return cSelectCard;
                        }
                    }
                }
                return cRe;
            }
            //再检查相对孤张里:全部花牌，优先打老头牌
            if (vXDGuCard.Count() > 0)
            {
                cRe = GetGoodGuCard(vXDGuCard);
                if ((MahjongGeneralAlgorithm.GetMahjongValue(cRe) > 2) && (MahjongGeneralAlgorithm.GetMahjongValue(cRe) < 8))
                {
                    if (vXLWrapper.Count() > 0)
                    {
                        //是否有12，89这样的相邻，如果有，就选一个打出去
                        cSelectCard = SelectXL(vXLWrapper);
                        if (MahjongDef.gInvalidMahjongValue != cSelectCard)
                        {
                            return cSelectCard;
                        }
                    }
                    if (vPair.Count() > 1)
                    {
                        //是否有19对，绝张对，如果有，就拆这样的对子
                        cSelectCard = SelectPair(vPair);
                        if (MahjongDef.gInvalidMahjongValue != cSelectCard)
                        {
                            return cSelectCard;
                        }
                    }
                }
                return cRe;
            }

            //相邻牌:优先打12里的1,89里的9,再找特征数最小的打
            if (vXLWrapper.Count() > 0)
            {
                //是否有12，89这样的相邻，如果有，就选一个打出去
                cSelectCard = SelectXL(vXLWrapper);
                if (MahjongDef.gInvalidMahjongValue != cSelectCard)
                {
                    return cSelectCard;
                }

                if (vPair.Count() > 1)
                {
                    //是否有19对，绝张对，如果有，就拆这样的对子
                    cSelectCard = SelectPair(vPair);
                    if (MahjongDef.gInvalidMahjongValue != cSelectCard)
                    {
                        return cSelectCard;
                    }
                }

                if (vXLWrapper.Count() == 1)
                {
                    return vXLWrapper[0].GetMinCard();
                }
                int wMinIndex = 0;
                int wMinTokenNum = 20;
                for (int i = 0; i < vXLWrapper.Count(); i++)
                {
                    if (vXLWrapper[i].GetTokenNum() < wMinTokenNum)
                    {
                        wMinTokenNum = vXLWrapper[i].GetTokenNum();
                        wMinIndex = i;
                    }
                }

                return vXLWrapper[wMinIndex].GetMinCard();
            }

            //只能找对子打,拆对子，应该拆靠近中间的,这样容易成顺，边对的对子也容易碰,如11,55,如果要选其一拆，肯定拆55,如果有风对，优先拆风对
            if (vPair.Count() > 0)
            {
                if (vPair.Count() == 1)
                {
                    return vPair[0];
                }

                //是否有19对，绝张对，如果有，就拆这样的对子
                cSelectCard = SelectPair(vPair);
                if (MahjongDef.gInvalidMahjongValue != cSelectCard)
                {
                    return cSelectCard;
                }

                return GetGoodGuCard(vPair);
            }

            return vGuCard[0];
        }
        /// <summary>
        /// 配普通牌型好牌
        /// </summary>
        /// <param name="vGetCard"></param>
        private void ConfigCategoryToNormal(List<byte> vGetCard)
        {
            List<byte> vGu = new List<byte>();
            List<byte> handCard = CopyActiveCard();
            MahjongGeneralAlgorithm.GetCardListGuCards(handCard, vGu);

            List<byte> vJDGuCard = new List<byte>();
            List<byte> vXDGuCard = new List<byte>();
            List<byte> vXGGuCard = new List<byte>();
            List<byte> vPair = new List<byte>();
            List<clsSpiltXLWrapper> vXL = new List<clsSpiltXLWrapper>();
            MahjongGeneralAlgorithm.SpiltGuCard(vGu, vJDGuCard, vXGGuCard, vXDGuCard, vPair, vXL);

            if (vPair.Count() > 0)
            {
                for (int i = 0; i < vPair.Count(); i++)
                {
                    vGetCard.Add(vPair[i]);
                }
            }
            if (vXL.Count() > 0)
            {
                for (int i = 0; i < vXL.Count(); i++)
                {
                    vGetCard.Add(vXL[i].GetLeftValue());
                    vGetCard.Add(vXL[i].GetRightValue());
                }
            }
            if (vXDGuCard.Count() > 0)
            {
                for (int i = 0; i < vXDGuCard.Count(); i++)
                {
                    vGetCard.Add(vXDGuCard[i]);
                }
            }
            if (vXGGuCard.Count() > 0)
            {
                for (int i = 0; i < vXGGuCard.Count(); i++)
                {
                    if (1 == MahjongGeneralAlgorithm.GetMahjongValue(vXGGuCard[i]))
                    {
                        vGetCard.Add((byte)(vXGGuCard[i] + 1));
                        continue;
                    }
                    if (9 == MahjongGeneralAlgorithm.GetMahjongValue(vXGGuCard[i]))
                    {
                        vGetCard.Add((byte)(vXGGuCard[i] - 1));
                        continue;
                    }
                    vGetCard.Add((byte)(vXGGuCard[i] + 1));
                    vGetCard.Add((byte)(vXGGuCard[i] - 1));
                }
            }
        }

        #endregion

        #region 清一色处理

        /// <summary>
        /// 检查手牌清一色
        /// </summary>
        private void checkHandCardQYS()
        {
            if (!this.IsAIPlayer)
            {
                return;
            }

            //检查换清一色
            List<byte> activeCard = CopyActiveCard();
            List<byte> vWan = new List<byte>();
            List<byte> vTong = new List<byte>();
            List<byte> vTiao = new List<byte>();
            List<byte> vZhi = new List<byte>();
            MahjongGeneralAlgorithm.SpiltHandCardByCardColor(activeCard, vWan, vTong, vTiao, vZhi);

            Random rand = MahjongGeneralAlgorithm.GetRandomObject();
            int checkCount = rand.Next(8, 12);

            if ((vWan.Count >= checkCount) || (vTong.Count >= checkCount) || (vTiao.Count >= checkCount))
            {
                if (vWan.Count >= checkCount)//留万，去筒条
                {
                    this._aiOPHelper.QYSColor = MahjongDef.gMahjongColor_Wan;
                }
                else if (vTong.Count >= checkCount)//留筒，去万条
                {
                    this._aiOPHelper.QYSColor = MahjongDef.gMahjongColor_Tong;
                }
                else//留条，去万筒
                {
                    this._aiOPHelper.QYSColor = MahjongDef.gMahjongColor_Tiao;
                }
                return;
            }

            checkCount = rand.Next(4, 6);

            if ((vWan.Count + vTong.Count) < checkCount)//留条
            {
                this._aiOPHelper.QYSColor = MahjongDef.gMahjongColor_Tiao;
            }
            else if ((vWan.Count + vTiao.Count) < checkCount)//留筒
            {
                this._aiOPHelper.QYSColor = MahjongDef.gMahjongColor_Tong;
            }
            else if ((vTong.Count + vTiao.Count) < checkCount)//留万
            {
                this._aiOPHelper.QYSColor = MahjongDef.gMahjongColor_Wan;
            }
            else
            {
                this._aiOPHelper.clear();
            }
        }

        #endregion

        #region 弃胡处理

        /// <summary>
        /// 检查弃胡
        /// </summary>
        public void checkGiveUpHu(byte huCard, enHuCardType huType)
        {
            //List<byte> handCard = CopyActiveCard();

            //clsFixedCard fixedCard = new clsFixedCard();
            //_playerCard.CopyACounterpartForFixedCard(ref fixedCard);

            _giveupHuMultiple = 1;// = AnalysisHuCardListMultiple(huCard, huType, handCard, ref fixedCard);
        }
        /// <summary>
        /// 过碰不碰
        /// </summary>
        /// <param name="pengCard"></param>
        public void checkGiveUpPeng(byte pengCard)
        {
            _giveupPeng.Add(pengCard);
        }

        #endregion


        # region 压单
        /// <summary>
        /// 只胡一张，且在顺中
        /// </summary>
        /// <param name="parseResult"></param>
        /// <returns></returns>
        public bool CheckYaDan(ref clsParseResult parseResult)
        {
            if (!parseResult.isValid)
            { return false; }
            //
            List<byte> handCard = new List<byte>();
            _playerCard.CopyACounterpartForActiveCard(handCard);
            List<byte> tingCard = new List<byte>();
            MahjongGeneralAlgorithm.CheckIfCanTingCardArray(handCard, tingCard);
            if ((1 == tingCard.Count) && (tingCard[0] == parseResult.huCard))
            {
                foreach (var triply in parseResult.normalParse.triplyAry)
                {
                    if (triply.enTripleType == enTripleType.TripleType_Flash)
                    {
                        //if (triply.cCardAry.Contains(parseResult.huCard))卡张不算
                        //    return true;
                        if (triply.cCardAry[1] == parseResult.huCard)
                            return true;
                    }
                }
            }
            return false;
        }

        #endregion


    }
}
