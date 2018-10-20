/*
Navicat MySQL Data Transfer

Source Server         : ql_hfmj
Source Server Version : 50536
Source Host           : 60.166.25.18:3300
Source Database       : entertainment_76

Target Server Type    : MYSQL
Target Server Version : 50536
File Encoding         : 65001

Date: 2018-09-26 17:35:04
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for agent_account
-- ----------------------------
DROP TABLE IF EXISTS `agent_account`;
CREATE TABLE `agent_account` (
  `agentid` int(11) NOT NULL,
  `rmb` double(12,2) DEFAULT '0.00' COMMENT 'RMB',
  `diamond` double(12,2) DEFAULT '0.00' COMMENT '钻石',
  `gold` double(12,2) DEFAULT '0.00' COMMENT '金币',
  `qidou` double(12,2) DEFAULT '0.00' COMMENT '七豆',
  `grift` double(12,2) DEFAULT '0.00' COMMENT '红包',
  PRIMARY KEY (`agentid`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='代理商户信息';

-- ----------------------------
-- Records of agent_account
-- ----------------------------
INSERT INTO `agent_account` VALUES ('10001', '0.00', '0.00', '0.00', '0.00', '0.00');
INSERT INTO `agent_account` VALUES ('10002', '0.00', '0.00', '0.00', '0.00', '0.00');

-- ----------------------------
-- Table structure for agent_info
-- ----------------------------
DROP TABLE IF EXISTS `agent_info`;
CREATE TABLE `agent_info` (
  `agentid` int(11) NOT NULL COMMENT '代理商ID',
  `parentid` int(11) DEFAULT '0' COMMENT '上级代理商ID',
  `userid` int(11) DEFAULT NULL COMMENT '游戏用户ID',
  `mobilenum` varchar(15) DEFAULT NULL COMMENT '手机号',
  `pw` varchar(50) DEFAULT NULL COMMENT '密码',
  `wechatnum` varchar(50) DEFAULT NULL COMMENT '微信号',
  `wechatname` varchar(100) DEFAULT NULL COMMENT '微信昵称',
  `addtime` datetime DEFAULT NULL COMMENT '注册时间',
  `logintime` datetime DEFAULT NULL COMMENT '最后次登录时间',
  `levelid` char(1) DEFAULT NULL COMMENT '级别',
  `discount` double(3,2) DEFAULT '0.00' COMMENT '折扣',
  `status` char(1) DEFAULT '1' COMMENT '状态0锁定1正常',
  `agentname` varchar(30) DEFAULT NULL COMMENT '姓名',
  `idcard` varchar(20) DEFAULT NULL COMMENT '身份证',
  `loginip` varchar(30) DEFAULT NULL COMMENT '最后次登录IP',
  `adminid` int(11) DEFAULT '0' COMMENT '管理用户ID',
  PRIMARY KEY (`agentid`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='代理用户信息';

-- ----------------------------
-- Records of agent_info
-- ----------------------------
INSERT INTO `agent_info` VALUES ('10001', '0', '210021', '15047210736', 'e10adc3949ba59abbe56e057f20f883e', 'WeChat', '游客661780', '2018-09-22 16:56:16', null, '1', '0.00', '1', '李龙', null, null, '0');
INSERT INTO `agent_info` VALUES ('10002', '10001', '210130', '18511423910', 'e10adc3949ba59abbe56e057f20f883e', 'WeChat', '游客717750', '2018-09-23 11:12:08', null, '3', '0.00', '0', '空空如也', null, null, '0');

-- ----------------------------
-- Table structure for agent_level
-- ----------------------------
DROP TABLE IF EXISTS `agent_level`;
CREATE TABLE `agent_level` (
  `levelid` char(1) NOT NULL,
  `name` varchar(50) DEFAULT NULL,
  `discount` double(3,2) DEFAULT NULL,
  PRIMARY KEY (`levelid`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of agent_level
-- ----------------------------
INSERT INTO `agent_level` VALUES ('1', '核心代理', '0.60');
INSERT INTO `agent_level` VALUES ('2', '铂金代理', '0.55');
INSERT INTO `agent_level` VALUES ('3', '金牌代理', '0.45');
INSERT INTO `agent_level` VALUES ('4', '普通代理', '0.40');

-- ----------------------------
-- Table structure for agent_log
-- ----------------------------
DROP TABLE IF EXISTS `agent_log`;
CREATE TABLE `agent_log` (
  `id` int(11) NOT NULL COMMENT 'id',
  `agentid` int(11) DEFAULT NULL COMMENT '代理ID',
  `logtype` char(1) DEFAULT NULL COMMENT '1绑定关系2解除关系3代理登陆',
  `addtime` datetime DEFAULT NULL COMMENT '添加时间',
  `remark` varchar(500) DEFAULT NULL COMMENT '备注',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='代理操作日志';

-- ----------------------------
-- Records of agent_log
-- ----------------------------

-- ----------------------------
-- Table structure for agent_return_log
-- ----------------------------
DROP TABLE IF EXISTS `agent_return_log`;
CREATE TABLE `agent_return_log` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `agentid` int(11) DEFAULT NULL COMMENT '代理id',
  `agentlevel` char(1) DEFAULT NULL COMMENT '代理级别',
  `userid` int(11) DEFAULT NULL COMMENT '用户id',
  `paynum` int(11) DEFAULT '0' COMMENT '用户充值金额',
  `returnrmb` double(10,2) DEFAULT '0.00' COMMENT '反rmb',
  `returnratio` double(10,2) DEFAULT '0.00' COMMENT '反rmb比例',
  `relationid` varchar(50) DEFAULT NULL COMMENT '关联订单号',
  `returnlevel` int(11) DEFAULT '0' COMMENT '返还层级',
  `addtime` datetime DEFAULT NULL COMMENT '添加时间',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8 COMMENT='用户充值返佣记录';

-- ----------------------------
-- Records of agent_return_log
-- ----------------------------
INSERT INTO `agent_return_log` VALUES ('1', '10001', '1', '210021', '100', '10.00', '0.45', '1', '1', '2018-09-23 10:32:59');
INSERT INTO `agent_return_log` VALUES ('2', '10001', '1', '210021', '11', '11.00', '1.00', '2', '1', '2018-09-24 14:37:28');
INSERT INTO `agent_return_log` VALUES ('3', '10001', '1', '210021', '30', '11.00', '0.15', '3', '1', '2018-08-01 16:45:10');
INSERT INTO `agent_return_log` VALUES ('4', '10001', '1', '210021', '30', '11.00', '0.15', '3', '1', '2018-09-10 16:45:10');
INSERT INTO `agent_return_log` VALUES ('5', '10002', '1', '210130', '30', '11.00', '0.15', '3', '1', '2018-09-10 16:45:10');

-- ----------------------------
-- Table structure for agent_stat_day
-- ----------------------------
DROP TABLE IF EXISTS `agent_stat_day`;
CREATE TABLE `agent_stat_day` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `agentid` int(11) NOT NULL COMMENT '代理用户ID',
  `dateid` varchar(10) DEFAULT NULL COMMENT '日期yyyy-mm-dd',
  `dayreturn` double(10,2) DEFAULT '0.00' COMMENT '今日返佣',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 COMMENT='代理商统计';

-- ----------------------------
-- Records of agent_stat_day
-- ----------------------------
INSERT INTO `agent_stat_day` VALUES ('1', '10001', '2018-09-23', '10.00');
INSERT INTO `agent_stat_day` VALUES ('2', '10001', '2018-09-24', '11.00');

-- ----------------------------
-- Table structure for agent_transfer
-- ----------------------------
DROP TABLE IF EXISTS `agent_transfer`;
CREATE TABLE `agent_transfer` (
  `id` varchar(50) NOT NULL COMMENT 'ID',
  `agentid` int(11) NOT NULL COMMENT '代理商ID',
  `auid` int(11) NOT NULL COMMENT '代理商id或userid',
  `rmb` double(12,2) DEFAULT '0.00' COMMENT 'RMB',
  `diamond` double(12,2) DEFAULT '0.00' COMMENT '钻石',
  `cashratio` double(3,2) DEFAULT '0.00' COMMENT '充钻比例，或手续费比率',
  `gift` double(12,2) DEFAULT '0.00' COMMENT '赠送钻石，或提现手续费',
  `cashtype` char(1) DEFAULT NULL COMMENT 'C提现金D提款充钻H代理商划拨U玩家充',
  `status` char(1) DEFAULT '0' COMMENT '状态0初始1成功2失败',
  `addtime` datetime DEFAULT NULL COMMENT '添加时间',
  `remark` varchar(255) DEFAULT NULL COMMENT '备注，提现微信流水号',
  `dealtime` datetime DEFAULT NULL COMMENT '处理时间',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='代理商提现、划拨、玩家充钻记录';

-- ----------------------------
-- Records of agent_transfer
-- ----------------------------

-- ----------------------------
-- Table structure for agent_upgrade
-- ----------------------------
DROP TABLE IF EXISTS `agent_upgrade`;
CREATE TABLE `agent_upgrade` (
  `id` int(11) NOT NULL COMMENT 'id',
  `userid` int(11) DEFAULT NULL COMMENT '游戏用户ID',
  `sourcelevelid` char(1) DEFAULT NULL COMMENT '源代理级别',
  `targetlevelid` char(1) DEFAULT NULL COMMENT '现代理级别',
  `addtime` datetime DEFAULT NULL COMMENT '升级时间',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='代理升级记录';

-- ----------------------------
-- Records of agent_upgrade
-- ----------------------------

-- ----------------------------
-- Table structure for friend_game
-- ----------------------------
DROP TABLE IF EXISTS `friend_game`;
CREATE TABLE `friend_game` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `friendid` int(11) NOT NULL COMMENT '亲友圈id',
  `gameid` int(11) NOT NULL COMMENT '游戏id',
  `rulestr` varchar(500) DEFAULT NULL COMMENT '规则字符串',
  `ruledesc` varchar(500) DEFAULT NULL COMMENT '规则描述',
  `status` char(1) DEFAULT NULL COMMENT '0停用1可用',
  `addtime` datetime DEFAULT NULL COMMENT '添加时间',
  `totalcnt` int(11) DEFAULT '0' COMMENT '总桌数',
  `totalamt` int(11) DEFAULT '0' COMMENT '总耗钻',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='亲友圈里游戏';

-- ----------------------------
-- Records of friend_game
-- ----------------------------

-- ----------------------------
-- Table structure for friend_info
-- ----------------------------
DROP TABLE IF EXISTS `friend_info`;
CREATE TABLE `friend_info` (
  `friendid` int(11) NOT NULL COMMENT '亲友圈Id',
  `userid` int(11) NOT NULL COMMENT '圈主',
  `friendname` varchar(30) DEFAULT NULL COMMENT '亲友圈名称',
  `friendgamennum` int(11) DEFAULT '0' COMMENT '亲友圈设定最大游戏数',
  `addtime` datetime DEFAULT NULL COMMENT '添加时间',
  `picpath` varchar(500) DEFAULT NULL COMMENT '亲友圈图标',
  `maxnum` int(11) DEFAULT NULL COMMENT '最大人数',
  `status` char(1) DEFAULT '0' COMMENT '0不可用1可用',
  `notice` varchar(500) DEFAULT NULL COMMENT '公告内容',
  PRIMARY KEY (`friendid`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='亲友圈信息';

-- ----------------------------
-- Records of friend_info
-- ----------------------------

-- ----------------------------
-- Table structure for friend_stat_day
-- ----------------------------
DROP TABLE IF EXISTS `friend_stat_day`;
CREATE TABLE `friend_stat_day` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `friendid` int(11) NOT NULL COMMENT '亲友圈id',
  `gameid` int(11) NOT NULL COMMENT '游戏id',
  `dateid` varchar(10) DEFAULT NULL COMMENT '日期yyyy-mm-dd',
  `roomcnt` int(11) DEFAULT '0' COMMENT '桌数',
  `roomamt` int(11) DEFAULT '0' COMMENT '耗钻',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COMMENT='亲友圈统计';

-- ----------------------------
-- Records of friend_stat_day
-- ----------------------------

-- ----------------------------
-- Table structure for friend_user
-- ----------------------------
DROP TABLE IF EXISTS `friend_user`;
CREATE TABLE `friend_user` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `friendid` int(11) NOT NULL COMMENT '亲友圈id',
  `userid` int(11) NOT NULL COMMENT 'userid',
  `isadmin` char(1) DEFAULT '0' COMMENT '0非管理员1管理员2圈主',
  `addtime` datetime DEFAULT NULL COMMENT '添加时间',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='亲友圈里玩家';

-- ----------------------------
-- Records of friend_user
-- ----------------------------

-- ----------------------------
-- Table structure for gameroom_info
-- ----------------------------
DROP TABLE IF EXISTS `gameroom_info`;
CREATE TABLE `gameroom_info` (
  `ID` int(11) NOT NULL COMMENT '场地编号',
  `basemoney` int(11) DEFAULT NULL COMMENT '底金',
  `name` varchar(50) DEFAULT NULL COMMENT '场地名称',
  `gameid` int(11) DEFAULT NULL COMMENT '游戏编号',
  `roomtype` int(11) DEFAULT NULL COMMENT '场地类型',
  `basemoneytype` int(11) DEFAULT NULL COMMENT '底金类型',
  `limitaicount` int(11) DEFAULT NULL COMMENT '场地AI数量上限',
  `maxcount` int(11) DEFAULT NULL COMMENT '最大开始人数',
  `mincount` int(11) DEFAULT NULL COMMENT '最小开始人数',
  `roomlv` int(11) DEFAULT NULL COMMENT '场地等级',
  `roomstate` int(11) DEFAULT NULL COMMENT '场地状态',
  `playerreadtimeout` int(11) DEFAULT NULL COMMENT '玩家准备时间',
  `maxlookcount` int(11) DEFAULT NULL COMMENT '最大旁观次数',
  `gamerule` varchar(100) DEFAULT NULL COMMENT '游戏规则',
  `attribute1` varchar(200) DEFAULT NULL,
  `attribute2` varchar(200) DEFAULT NULL,
  `attribute3` varchar(200) DEFAULT NULL,
  `attribute4` varchar(200) DEFAULT NULL,
  `attribute5` varchar(200) DEFAULT NULL,
  `attribute6` varchar(200) DEFAULT NULL,
  `mark` varchar(200) DEFAULT NULL COMMENT '备注说明',
  `serverid` int(11) DEFAULT NULL COMMENT '服务器编号',
  PRIMARY KEY (`ID`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='游戏的场地信息';

-- ----------------------------
-- Records of gameroom_info
-- ----------------------------
INSERT INTO `gameroom_info` VALUES ('1', '100', 'M_BiJi', '51', '9', '100', null, '5', '2', '9', '3', '20', '2', null, '10|50_20|100,10|10_20|20,10|50_20|100', null, null, null, null, null, null, '201');
INSERT INTO `gameroom_info` VALUES ('2', '100', 'M_LQMJ', '161', '9', '100', null, '4', '4', '9', '3', '20', '2', null, '4|1|2_8|1|3_16|2|6_8,', null, null, null, null, null, null, '201');
INSERT INTO `gameroom_info` VALUES ('3', '100', 'M_HQMJ', '100', '9', '100', null, '4', '4', '9', '3', '20', '2', null, '8|32_16|64,8|8_16|16,8|32_16|64', null, null, null, null, null, null, '201');

-- ----------------------------
-- Table structure for game_info
-- ----------------------------
DROP TABLE IF EXISTS `game_info`;
CREATE TABLE `game_info` (
  `gameid` int(11) NOT NULL COMMENT '游戏ID',
  `gamename` varchar(50) DEFAULT NULL COMMENT '游戏名称',
  `latestversion` varchar(50) DEFAULT NULL COMMENT '游戏版本号',
  `modulename` varchar(100) DEFAULT NULL COMMENT '游戏包名',
  `gametype` int(11) DEFAULT NULL COMMENT '游戏类型',
  `gamestatus` char(1) DEFAULT '1' COMMENT '游戏状态0不可用1可用',
  `sortid` int(11) DEFAULT NULL COMMENT '游戏排序Id',
  `gamecity` varchar(100) DEFAULT NULL COMMENT '游戏城市信息',
  `GameDesc` varchar(500) DEFAULT NULL,
  PRIMARY KEY (`gameid`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='游戏信息';

-- ----------------------------
-- Records of game_info
-- ----------------------------
INSERT INTO `game_info` VALUES ('51', '快乐比鸡', null, 'M_BiJi', '2', '0', null, 'LIUAN', '风靡安徽的五人比鸡,经典1-2倍,精彩刺激');
INSERT INTO `game_info` VALUES ('100', '霍邱麻将', null, 'M_HQMJ', '3', '0', null, 'LIUAN', null);
INSERT INTO `game_info` VALUES ('161', '临泉麻将', null, 'M_LQMJ', '2', '0', null, 'FUYANG', null);

-- ----------------------------
-- Table structure for log_friend_user
-- ----------------------------
DROP TABLE IF EXISTS `log_friend_user`;
CREATE TABLE `log_friend_user` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `userid` int(11) NOT NULL COMMENT 'userid',
  `friendid` int(11) NOT NULL COMMENT '亲友圈id',
  `dealuser` int(11) NOT NULL COMMENT '处理userid',
  `addtime` datetime NOT NULL COMMENT '添加时间',
  `status` char(1) DEFAULT '0' COMMENT '0初始1接受2不接受',
  `dealtime` datetime DEFAULT NULL COMMENT '处理时间',
  `remark` varchar(100) DEFAULT NULL COMMENT '备注',
  `dealtype` char(1) DEFAULT NULL COMMENT '0删除1加入',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='亲友圈邀请日志';

-- ----------------------------
-- Records of log_friend_user
-- ----------------------------

-- ----------------------------
-- Table structure for log_funds_admin
-- ----------------------------
DROP TABLE IF EXISTS `log_funds_admin`;
CREATE TABLE `log_funds_admin` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `adminid` int(11) DEFAULT NULL COMMENT 'adminid',
  `accounttype` char(2) DEFAULT NULL COMMENT '账户类型',
  `fundtype` char(2) DEFAULT NULL COMMENT '资金类型',
  `fundmoney` double(10,2) DEFAULT NULL COMMENT '资金值',
  `addtime` datetime DEFAULT NULL COMMENT '添加时间',
  `relationid` varchar(50) DEFAULT '0' COMMENT '关联',
  `agomoney` double(10,2) DEFAULT '0.00' COMMENT '交易前账户余额',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='管理员资金表';

-- ----------------------------
-- Records of log_funds_admin
-- ----------------------------

-- ----------------------------
-- Table structure for log_funds_agent
-- ----------------------------
DROP TABLE IF EXISTS `log_funds_agent`;
CREATE TABLE `log_funds_agent` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `agentid` int(11) DEFAULT NULL COMMENT 'userid',
  `accounttype` char(2) DEFAULT NULL COMMENT '账户类型',
  `fundtype` char(2) DEFAULT NULL COMMENT '资金类型',
  `fundmoney` double(10,2) DEFAULT NULL COMMENT '资金值',
  `addtime` datetime DEFAULT NULL COMMENT '添加时间',
  `relationid` varchar(50) DEFAULT '0' COMMENT '关联',
  `agomoney` double(10,2) DEFAULT NULL COMMENT '交易前金额',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8 COMMENT='代理资金表';

-- ----------------------------
-- Records of log_funds_agent
-- ----------------------------
INSERT INTO `log_funds_agent` VALUES ('1', '10001', 'VD', '81', '10.00', '2018-09-23 10:58:11', '1', '100.00');
INSERT INTO `log_funds_agent` VALUES ('2', '10001', 'VD', '81', '10.00', '2018-09-24 14:56:32', '2', '130.00');
INSERT INTO `log_funds_agent` VALUES ('3', '10001', 'VD', '81', '10.00', '2018-09-10 16:44:30', '3', '120.00');
INSERT INTO `log_funds_agent` VALUES ('4', null, null, null, null, null, '0', null);

-- ----------------------------
-- Table structure for log_funds_user
-- ----------------------------
DROP TABLE IF EXISTS `log_funds_user`;
CREATE TABLE `log_funds_user` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `userid` int(11) DEFAULT NULL COMMENT 'userid',
  `accounttype` char(2) DEFAULT NULL COMMENT '账户类型',
  `fundtype` char(2) DEFAULT NULL COMMENT '资金类型',
  `fundmoney` double(10,2) DEFAULT NULL COMMENT '资金值',
  `addtime` datetime DEFAULT NULL COMMENT '添加时间',
  `relationid` varchar(50) DEFAULT '0' COMMENT '关联',
  `agomoney` double(10,2) DEFAULT NULL COMMENT '交易前账户余额',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=129 DEFAULT CHARSET=utf8 COMMENT='用户资金表';

-- ----------------------------
-- Records of log_funds_user
-- ----------------------------
INSERT INTO `log_funds_user` VALUES ('1', '210007', 'VQ', '21', '-100.00', '2018-09-22 16:39:00', '2', '100.00');
INSERT INTO `log_funds_user` VALUES ('2', '210061', 'VQ', '21', '-100.00', '2018-09-22 17:30:06', '3', '100.00');
INSERT INTO `log_funds_user` VALUES ('3', '210052', 'VD', '20', '-1.00', '2018-09-22 17:34:39', '4', '100.00');
INSERT INTO `log_funds_user` VALUES ('4', '210065', 'VD', '20', '-1.00', '2018-09-22 17:34:39', '4', '100.00');
INSERT INTO `log_funds_user` VALUES ('5', '210068', 'VD', '20', '-1.00', '2018-09-22 17:40:53', '5', '100.00');
INSERT INTO `log_funds_user` VALUES ('6', '210067', 'VD', '20', '-1.00', '2018-09-22 17:40:53', '5', '100.00');
INSERT INTO `log_funds_user` VALUES ('7', '210266', 'VQ', '21', '-100.00', '2018-09-24 17:25:12', '21', '100.00');
INSERT INTO `log_funds_user` VALUES ('8', '210266', 'VQ', '21', '0.00', '2018-09-24 17:42:16', '23', '0.00');
INSERT INTO `log_funds_user` VALUES ('9', '210266', 'VQ', '21', '0.00', '2018-09-24 17:45:24', '24', '0.00');
INSERT INTO `log_funds_user` VALUES ('10', '210266', 'VQ', '21', '0.00', '2018-09-24 17:46:42', '25', '0.00');
INSERT INTO `log_funds_user` VALUES ('11', '210266', 'VQ', '21', '0.00', '2018-09-24 17:52:00', '26', '0.00');
INSERT INTO `log_funds_user` VALUES ('12', '210266', 'VQ', '21', '0.00', '2018-09-24 17:53:57', '27', '0.00');
INSERT INTO `log_funds_user` VALUES ('13', '210277', 'VQ', '21', '-100.00', '2018-09-24 18:12:44', '28', '100.00');
INSERT INTO `log_funds_user` VALUES ('14', '210280', 'VQ', '21', '-100.00', '2018-09-24 18:17:58', '29', '100.00');
INSERT INTO `log_funds_user` VALUES ('15', '210280', 'VQ', '21', '0.00', '2018-09-24 18:21:05', '30', '0.00');
INSERT INTO `log_funds_user` VALUES ('16', '210280', 'VQ', '21', '0.00', '2018-09-24 18:26:39', '31', '0.00');
INSERT INTO `log_funds_user` VALUES ('17', '210285', 'VQ', '21', '-100.00', '2018-09-24 18:36:23', '32', '100.00');
INSERT INTO `log_funds_user` VALUES ('18', '210283', 'VQ', '21', '-100.00', '2018-09-24 18:36:31', '33', '100.00');
INSERT INTO `log_funds_user` VALUES ('19', '210293', 'VQ', '21', '-100.00', '2018-09-24 18:40:44', '34', '100.00');
INSERT INTO `log_funds_user` VALUES ('20', '210297', 'VQ', '21', '-100.00', '2018-09-24 19:14:56', '35', '100.00');
INSERT INTO `log_funds_user` VALUES ('21', '210302', 'VQ', '21', '-100.00', '2018-09-24 19:20:27', '36', '100.00');
INSERT INTO `log_funds_user` VALUES ('22', '210307', 'VQ', '21', '-100.00', '2018-09-24 19:22:34', '37', '100.00');
INSERT INTO `log_funds_user` VALUES ('23', '210319', 'VQ', '21', '-100.00', '2018-09-24 19:39:20', '39', '100.00');
INSERT INTO `log_funds_user` VALUES ('24', '210317', 'VQ', '21', '-100.00', '2018-09-24 19:41:39', '40', '100.00');
INSERT INTO `log_funds_user` VALUES ('25', '210319', 'VQ', '21', '0.00', '2018-09-24 19:43:44', '41', '0.00');
INSERT INTO `log_funds_user` VALUES ('26', '210319', 'VQ', '21', '0.00', '2018-09-24 19:44:02', '42', '0.00');
INSERT INTO `log_funds_user` VALUES ('27', '210330', 'VQ', '21', '-100.00', '2018-09-24 20:19:12', '43', '100.00');
INSERT INTO `log_funds_user` VALUES ('28', '210364', 'VQ', '21', '-100.00', '2018-09-25 11:21:34', '44', '100.00');
INSERT INTO `log_funds_user` VALUES ('29', '210371', 'VQ', '21', '-100.00', '2018-09-25 11:31:19', '45', '100.00');
INSERT INTO `log_funds_user` VALUES ('30', '210376', 'VQ', '21', '-100.00', '2018-09-25 11:37:01', '46', '100.00');
INSERT INTO `log_funds_user` VALUES ('31', '210420', 'VQ', '21', '-100.00', '2018-09-25 13:57:44', '47', '100.00');
INSERT INTO `log_funds_user` VALUES ('32', '210435', 'VQ', '21', '-100.00', '2018-09-25 14:19:14', '48', '100.00');
INSERT INTO `log_funds_user` VALUES ('33', '210448', 'VQ', '21', '-100.00', '2018-09-25 14:36:43', '49', '100.00');
INSERT INTO `log_funds_user` VALUES ('34', '210453', 'VQ', '21', '-100.00', '2018-09-25 14:49:38', '50', '100.00');
INSERT INTO `log_funds_user` VALUES ('35', '210458', 'VQ', '21', '-100.00', '2018-09-25 14:57:32', '51', '100.00');
INSERT INTO `log_funds_user` VALUES ('36', '210515', 'VQ', '21', '-100.00', '2018-09-25 16:13:42', '52', '100.00');
INSERT INTO `log_funds_user` VALUES ('37', '210624', 'VQ', '21', '-100.00', '2018-09-25 19:38:25', '53', '100.00');
INSERT INTO `log_funds_user` VALUES ('38', '210625', 'VQ', '21', '-100.00', '2018-09-25 19:40:41', '54', '100.00');
INSERT INTO `log_funds_user` VALUES ('39', '210625', 'VQ', '21', '0.00', '2018-09-25 19:41:27', '55', '0.00');
INSERT INTO `log_funds_user` VALUES ('40', '210626', 'VQ', '21', '-100.00', '2018-09-25 19:44:40', '56', '100.00');
INSERT INTO `log_funds_user` VALUES ('41', '210626', 'VQ', '21', '0.00', '2018-09-25 19:46:30', '57', '0.00');
INSERT INTO `log_funds_user` VALUES ('42', '210626', 'VQ', '21', '0.00', '2018-09-25 19:50:33', '58', '0.00');
INSERT INTO `log_funds_user` VALUES ('43', '210635', 'VD', '20', '0.00', '2018-09-26 09:34:47', '59', '100.00');
INSERT INTO `log_funds_user` VALUES ('44', '210637', 'VD', '20', '0.00', '2018-09-26 09:34:47', '59', '100.00');
INSERT INTO `log_funds_user` VALUES ('45', '210636', 'VD', '20', '0.00', '2018-09-26 09:34:47', '59', '100.00');
INSERT INTO `log_funds_user` VALUES ('46', '210634', 'VD', '20', '0.00', '2018-09-26 09:34:47', '59', '100.00');
INSERT INTO `log_funds_user` VALUES ('47', '210635', 'VQ', '21', '-100.00', '2018-09-26 09:37:47', '60', '100.00');
INSERT INTO `log_funds_user` VALUES ('48', '210638', 'VD', '20', '-1.00', '2018-09-26 10:01:03', '61', '100.00');
INSERT INTO `log_funds_user` VALUES ('49', '210639', 'VD', '20', '-1.00', '2018-09-26 10:01:03', '61', '100.00');
INSERT INTO `log_funds_user` VALUES ('50', '210645', 'VQ', '21', '-100.00', '2018-09-26 10:20:53', '62', '100.00');
INSERT INTO `log_funds_user` VALUES ('51', '210653', 'VQ', '21', '-100.00', '2018-09-26 11:08:35', '63', '100.00');
INSERT INTO `log_funds_user` VALUES ('52', '210688', 'VD', '20', '-2.00', '2018-09-26 14:09:27', '64', '100.00');
INSERT INTO `log_funds_user` VALUES ('53', '210686', 'VD', '20', '-2.00', '2018-09-26 14:09:27', '64', '100.00');
INSERT INTO `log_funds_user` VALUES ('54', '210685', 'VD', '20', '-2.00', '2018-09-26 14:09:27', '64', '100.00');
INSERT INTO `log_funds_user` VALUES ('55', '210687', 'VD', '20', '-2.00', '2018-09-26 14:09:27', '64', '100.00');
INSERT INTO `log_funds_user` VALUES ('56', '210688', 'VQ', '21', '-100.00', '2018-09-26 14:10:25', '65', '100.00');
INSERT INTO `log_funds_user` VALUES ('57', '210685', 'VD', '20', '-48.00', '2018-09-26 14:14:03', '66', '98.00');
INSERT INTO `log_funds_user` VALUES ('58', '210685', 'VD', '20', '-48.00', '2018-09-26 14:18:45', '67', '50.00');
INSERT INTO `log_funds_user` VALUES ('59', '210691', 'VQ', '21', '-100.00', '2018-09-26 14:21:42', '68', '100.00');
INSERT INTO `log_funds_user` VALUES ('60', '210692', 'VD', '20', '-12.00', '2018-09-26 14:22:19', '69', '100.00');
INSERT INTO `log_funds_user` VALUES ('61', '210689', 'VD', '20', '-2.00', '2018-09-26 14:23:18', '70', '100.00');
INSERT INTO `log_funds_user` VALUES ('62', '210691', 'VD', '20', '-2.00', '2018-09-26 14:23:18', '70', '100.00');
INSERT INTO `log_funds_user` VALUES ('63', '210690', 'VD', '20', '-2.00', '2018-09-26 14:23:18', '70', '100.00');
INSERT INTO `log_funds_user` VALUES ('64', '210692', 'VD', '20', '-2.00', '2018-09-26 14:23:18', '70', '88.00');
INSERT INTO `log_funds_user` VALUES ('65', '210697', 'VD', '20', '-1.00', '2018-09-26 14:28:10', '71', '100.00');
INSERT INTO `log_funds_user` VALUES ('66', '210696', 'VD', '20', '-1.00', '2018-09-26 14:28:10', '71', '100.00');
INSERT INTO `log_funds_user` VALUES ('67', '210695', 'VD', '20', '-1.00', '2018-09-26 14:28:10', '71', '100.00');
INSERT INTO `log_funds_user` VALUES ('68', '210694', 'VD', '20', '-1.00', '2018-09-26 14:28:10', '71', '100.00');
INSERT INTO `log_funds_user` VALUES ('69', '210697', 'VD', '20', '-2.00', '2018-09-26 14:29:30', '72', '99.00');
INSERT INTO `log_funds_user` VALUES ('70', '210695', 'VD', '20', '-2.00', '2018-09-26 14:29:30', '72', '99.00');
INSERT INTO `log_funds_user` VALUES ('71', '210696', 'VD', '20', '-2.00', '2018-09-26 14:29:30', '72', '99.00');
INSERT INTO `log_funds_user` VALUES ('72', '210694', 'VD', '20', '-2.00', '2018-09-26 14:29:30', '72', '99.00');
INSERT INTO `log_funds_user` VALUES ('73', '210712', 'VQ', '21', '-100.00', '2018-09-26 14:58:46', '73', '100.00');
INSERT INTO `log_funds_user` VALUES ('74', '210713', 'VQ', '21', '-100.00', '2018-09-26 14:58:56', '74', '100.00');
INSERT INTO `log_funds_user` VALUES ('75', '210716', 'VD', '20', '-1.00', '2018-09-26 15:01:27', '75', '100.00');
INSERT INTO `log_funds_user` VALUES ('76', '210713', 'VD', '20', '-1.00', '2018-09-26 15:01:27', '75', '100.00');
INSERT INTO `log_funds_user` VALUES ('77', '210715', 'VD', '20', '-1.00', '2018-09-26 15:01:27', '75', '100.00');
INSERT INTO `log_funds_user` VALUES ('78', '210714', 'VD', '20', '-1.00', '2018-09-26 15:01:27', '75', '100.00');
INSERT INTO `log_funds_user` VALUES ('79', '210712', 'VQ', '21', '0.00', '2018-09-26 15:08:33', '76', '0.00');
INSERT INTO `log_funds_user` VALUES ('80', '210729', 'VD', '20', '-1.00', '2018-09-26 15:15:10', '77', '100.00');
INSERT INTO `log_funds_user` VALUES ('81', '210731', 'VD', '20', '-1.00', '2018-09-26 15:15:10', '77', '100.00');
INSERT INTO `log_funds_user` VALUES ('82', '210730', 'VD', '20', '-1.00', '2018-09-26 15:15:10', '77', '100.00');
INSERT INTO `log_funds_user` VALUES ('83', '210728', 'VD', '20', '-1.00', '2018-09-26 15:15:10', '77', '100.00');
INSERT INTO `log_funds_user` VALUES ('84', '210731', 'VD', '20', '-1.00', '2018-09-26 15:20:47', '78', '99.00');
INSERT INTO `log_funds_user` VALUES ('85', '210729', 'VD', '20', '-1.00', '2018-09-26 15:20:47', '78', '99.00');
INSERT INTO `log_funds_user` VALUES ('86', '210730', 'VD', '20', '-1.00', '2018-09-26 15:20:47', '78', '99.00');
INSERT INTO `log_funds_user` VALUES ('87', '210728', 'VD', '20', '-1.00', '2018-09-26 15:20:47', '78', '99.00');
INSERT INTO `log_funds_user` VALUES ('88', '210712', 'VQ', '21', '0.00', '2018-09-26 15:58:31', '79', '0.00');
INSERT INTO `log_funds_user` VALUES ('89', '210712', 'VQ', '21', '0.00', '2018-09-26 16:04:37', '80', '0.00');
INSERT INTO `log_funds_user` VALUES ('90', '210712', 'VQ', '21', '0.00', '2018-09-26 16:19:04', '81', '0.00');
INSERT INTO `log_funds_user` VALUES ('91', '210777', 'VD', '20', '-1.00', '2018-09-26 16:44:14', '82', '100.00');
INSERT INTO `log_funds_user` VALUES ('92', '210779', 'VD', '20', '-1.00', '2018-09-26 16:44:14', '82', '100.00');
INSERT INTO `log_funds_user` VALUES ('93', '210780', 'VD', '20', '-1.00', '2018-09-26 16:44:14', '82', '100.00');
INSERT INTO `log_funds_user` VALUES ('94', '210778', 'VD', '20', '-1.00', '2018-09-26 16:44:14', '82', '100.00');
INSERT INTO `log_funds_user` VALUES ('95', '210779', 'VD', '20', '-1.00', '2018-09-26 16:49:40', '83', '99.00');
INSERT INTO `log_funds_user` VALUES ('96', '210778', 'VD', '20', '-1.00', '2018-09-26 16:49:40', '83', '99.00');
INSERT INTO `log_funds_user` VALUES ('97', '210780', 'VD', '20', '-1.00', '2018-09-26 16:49:40', '83', '99.00');
INSERT INTO `log_funds_user` VALUES ('98', '210777', 'VD', '20', '-1.00', '2018-09-26 16:49:40', '83', '99.00');
INSERT INTO `log_funds_user` VALUES ('99', '210784', 'VD', '20', '-1.00', '2018-09-26 16:52:55', '84', '100.00');
INSERT INTO `log_funds_user` VALUES ('100', '210783', 'VD', '20', '-1.00', '2018-09-26 16:52:55', '84', '100.00');
INSERT INTO `log_funds_user` VALUES ('101', '210782', 'VD', '20', '-1.00', '2018-09-26 16:52:55', '84', '100.00');
INSERT INTO `log_funds_user` VALUES ('102', '210781', 'VD', '20', '-1.00', '2018-09-26 16:52:55', '84', '100.00');
INSERT INTO `log_funds_user` VALUES ('103', '210787', 'VD', '20', '-1.00', '2018-09-26 16:55:35', '85', '100.00');
INSERT INTO `log_funds_user` VALUES ('104', '210785', 'VD', '20', '-1.00', '2018-09-26 16:55:35', '85', '100.00');
INSERT INTO `log_funds_user` VALUES ('105', '210788', 'VD', '20', '-1.00', '2018-09-26 16:55:35', '85', '100.00');
INSERT INTO `log_funds_user` VALUES ('106', '210786', 'VD', '20', '-1.00', '2018-09-26 16:55:35', '85', '100.00');
INSERT INTO `log_funds_user` VALUES ('107', '210791', 'VD', '20', '-1.00', '2018-09-26 17:00:48', '86', '100.00');
INSERT INTO `log_funds_user` VALUES ('108', '210792', 'VD', '20', '-1.00', '2018-09-26 17:00:48', '86', '100.00');
INSERT INTO `log_funds_user` VALUES ('109', '210789', 'VD', '20', '-1.00', '2018-09-26 17:00:48', '86', '100.00');
INSERT INTO `log_funds_user` VALUES ('110', '210790', 'VD', '20', '-1.00', '2018-09-26 17:00:48', '86', '100.00');
INSERT INTO `log_funds_user` VALUES ('111', '210795', 'VD', '20', '-1.00', '2018-09-26 17:04:03', '87', '100.00');
INSERT INTO `log_funds_user` VALUES ('112', '210794', 'VD', '20', '-1.00', '2018-09-26 17:04:03', '87', '100.00');
INSERT INTO `log_funds_user` VALUES ('113', '210793', 'VD', '20', '-1.00', '2018-09-26 17:04:03', '87', '100.00');
INSERT INTO `log_funds_user` VALUES ('114', '210796', 'VD', '20', '-1.00', '2018-09-26 17:04:03', '87', '100.00');
INSERT INTO `log_funds_user` VALUES ('115', '210795', 'VD', '20', '-1.00', '2018-09-26 17:05:33', '88', '99.00');
INSERT INTO `log_funds_user` VALUES ('116', '210796', 'VD', '20', '-1.00', '2018-09-26 17:05:33', '88', '99.00');
INSERT INTO `log_funds_user` VALUES ('117', '210794', 'VD', '20', '-1.00', '2018-09-26 17:05:33', '88', '99.00');
INSERT INTO `log_funds_user` VALUES ('118', '210793', 'VD', '20', '-1.00', '2018-09-26 17:05:33', '88', '99.00');
INSERT INTO `log_funds_user` VALUES ('119', '210799', 'VQ', '21', '-100.00', '2018-09-26 17:09:06', '89', '100.00');
INSERT INTO `log_funds_user` VALUES ('120', '210800', 'VD', '20', '-1.00', '2018-09-26 17:09:29', '90', '100.00');
INSERT INTO `log_funds_user` VALUES ('121', '210797', 'VD', '20', '-1.00', '2018-09-26 17:09:29', '90', '100.00');
INSERT INTO `log_funds_user` VALUES ('122', '210798', 'VD', '20', '-1.00', '2018-09-26 17:09:29', '90', '100.00');
INSERT INTO `log_funds_user` VALUES ('123', '210799', 'VD', '20', '-1.00', '2018-09-26 17:09:29', '90', '100.00');
INSERT INTO `log_funds_user` VALUES ('124', '210803', 'VQ', '21', '-100.00', '2018-09-26 17:27:53', '91', '100.00');
INSERT INTO `log_funds_user` VALUES ('125', '210821', 'VD', '20', '-1.00', '2018-09-26 17:43:41', '92', '100.00');
INSERT INTO `log_funds_user` VALUES ('126', '210819', 'VD', '20', '-1.00', '2018-09-26 17:43:41', '92', '100.00');
INSERT INTO `log_funds_user` VALUES ('127', '210820', 'VD', '20', '-1.00', '2018-09-26 17:43:41', '92', '100.00');
INSERT INTO `log_funds_user` VALUES ('128', '210818', 'VD', '20', '-1.00', '2018-09-26 17:43:41', '92', '100.00');

-- ----------------------------
-- Table structure for log_run
-- ----------------------------
DROP TABLE IF EXISTS `log_run`;
CREATE TABLE `log_run` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `runname` varchar(20) NOT NULL COMMENT '名称',
  `begindate` datetime NOT NULL COMMENT '开始时间',
  `enddate` datetime NOT NULL COMMENT '结束时间',
  `remark` varchar(200) DEFAULT NULL COMMENT '备注',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE=MyISAM AUTO_INCREMENT=6 DEFAULT CHARSET=utf8 COMMENT='每日运行日志';

-- ----------------------------
-- Records of log_run
-- ----------------------------
INSERT INTO `log_run` VALUES ('1', 'STAT', '2018-09-22 16:40:00', '2018-09-22 16:40:00', 'sp_user_stat,sp_agent_stat,sp_friend_stat');
INSERT INTO `log_run` VALUES ('2', 'STAT', '2018-09-23 16:40:00', '2018-09-23 16:40:00', 'sp_user_stat,sp_agent_stat,sp_friend_stat');
INSERT INTO `log_run` VALUES ('3', 'STAT', '2018-09-24 16:40:00', '2018-09-24 16:40:00', 'sp_user_stat,sp_agent_stat,sp_friend_stat');
INSERT INTO `log_run` VALUES ('4', 'STAT', '2018-09-25 16:40:00', '2018-09-25 16:40:00', 'sp_user_stat,sp_agent_stat,sp_friend_stat');
INSERT INTO `log_run` VALUES ('5', 'STAT', '2018-09-26 16:40:00', '2018-09-26 16:40:00', 'sp_user_stat,sp_agent_stat,sp_friend_stat');

-- ----------------------------
-- Table structure for msg_content
-- ----------------------------
DROP TABLE IF EXISTS `msg_content`;
CREATE TABLE `msg_content` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `msgobject` char(1) DEFAULT NULL COMMENT '广播消息对象U用户A代理',
  `msgstatus` char(1) DEFAULT NULL COMMENT '广播消息状态0不可用1可用',
  `addtime` datetime DEFAULT NULL COMMENT '添加时间',
  `begintime` datetime DEFAULT NULL COMMENT '有效期开始时间',
  `endtime` datetime DEFAULT NULL COMMENT '有效期结束时间',
  `title` varchar(2000) DEFAULT NULL COMMENT '消息主题',
  `content` text COMMENT '消息内容',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of msg_content
-- ----------------------------
INSERT INTO `msg_content` VALUES ('1', 'U', '1', '2018-09-20 14:35:58', '2018-09-20 00:00:00', '2019-01-01 00:00:00', '七乐安徽麻将正式上线运营', '亲爱的玩家们：\r\n   您们好！七乐安徽麻将经过不断的完善，已正式上线啦。诚邀各位新老玩家前来体验，提出宝贵意见。\r\n\r\n新品七乐安徽麻将有以下特色：\r\n1、动态背景，画面精美\r\n2、升级3D麻将，更稳定，更流畅，更好玩\r\n3、打比赛、做任务、拉好友，各种任务活动，丰富奖品等你来拿\r\n4、多种牌种，娱乐场，比赛场，好友开房，玩法多样\r\n5、加入代理，超高收益，还有更多福利等你来拿。\r\n\r\n文明游戏，禁止赌博。\r\n七乐祝您一周七天棋牌游戏乐不停！\r\n\r\n        七乐运营团队');

-- ----------------------------
-- Table structure for msg_content_agent
-- ----------------------------
DROP TABLE IF EXISTS `msg_content_agent`;
CREATE TABLE `msg_content_agent` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `msgid` int(11) DEFAULT NULL COMMENT '广播消息ID',
  `agentid` int(11) DEFAULT NULL COMMENT 'agentID',
  `addtime` datetime DEFAULT NULL COMMENT '打开时间',
  `title` varchar(500) DEFAULT NULL COMMENT '消息主题',
  `content` text COMMENT '消息内容',
  `opentime` datetime DEFAULT NULL COMMENT '打开时间',
  `status` char(1) NOT NULL DEFAULT '0' COMMENT '0未打开1打开',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of msg_content_agent
-- ----------------------------

-- ----------------------------
-- Table structure for msg_content_user
-- ----------------------------
DROP TABLE IF EXISTS `msg_content_user`;
CREATE TABLE `msg_content_user` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `msgid` int(11) DEFAULT NULL COMMENT '广播消息ID',
  `userid` int(11) DEFAULT NULL COMMENT 'userID',
  `addtime` datetime DEFAULT NULL COMMENT '打开时间',
  `content` text COMMENT '消息内容',
  `title` varchar(500) DEFAULT NULL COMMENT '消息主题',
  `opentime` datetime DEFAULT NULL COMMENT '打开时间',
  `status` char(1) DEFAULT '0' COMMENT '0未打开1打开',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of msg_content_user
-- ----------------------------

-- ----------------------------
-- Table structure for order_pay
-- ----------------------------
DROP TABLE IF EXISTS `order_pay`;
CREATE TABLE `order_pay` (
  `id` varchar(50) NOT NULL,
  `auid` int(11) DEFAULT NULL COMMENT '用户id',
  `accounttype` char(2) DEFAULT NULL COMMENT '账户类型',
  `rmb` double(10,2) DEFAULT '0.00' COMMENT 'rmb',
  `vcoin` int(11) DEFAULT '0' COMMENT '虚拟币',
  `gift` int(11) DEFAULT '0' COMMENT '送',
  `addtime` datetime DEFAULT NULL COMMENT '添加时间',
  `userflag` char(1) DEFAULT NULL COMMENT '类型A代理充U玩家充',
  `status` char(1) DEFAULT '0' COMMENT '状态0初始1成功2失败',
  `paytime` datetime DEFAULT NULL COMMENT '处理时间',
  `realrmb` double(10,2) DEFAULT '0.00' COMMENT '实际支付金额',
  `remark` varchar(200) DEFAULT NULL COMMENT '备注，微信订单号',
  `paytype` char(1) DEFAULT NULL COMMENT '0线下支付1微信支付2支付宝',
  `gifttype` char(2) DEFAULT NULL COMMENT '送虚拟币账户类型',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='用户充值信息';

-- ----------------------------
-- Records of order_pay
-- ----------------------------

-- ----------------------------
-- Table structure for order_recorddata
-- ----------------------------
DROP TABLE IF EXISTS `order_recorddata`;
CREATE TABLE `order_recorddata` (
  `recordid` int(11) NOT NULL,
  `mid` varchar(100) DEFAULT NULL COMMENT '游戏的主局号，为了区分玩家参加的不同赛局',
  `sid` varchar(100) DEFAULT NULL COMMENT '游戏的主局号，为了区分玩家参加的不同赛局',
  `roomid` int(11) DEFAULT NULL COMMENT '本局游戏所属的场地Id',
  `gameid` int(11) DEFAULT NULL COMMENT '本局游戏所属的游戏Id',
  `recordtype` int(11) DEFAULT NULL COMMENT '保存录像类型的类别',
  `ownerid` int(11) DEFAULT NULL COMMENT '房主信息，可能为空',
  `groupid` int(11) DEFAULT NULL COMMENT '亲友圈圈Id',
  `addtime` datetime DEFAULT NULL COMMENT '添加时间',
  `friendgameid` int(11) DEFAULT NULL COMMENT '亲友圈游戏ID',
  `tableid` int(11) NOT NULL DEFAULT '0' COMMENT '分享桌号',
  PRIMARY KEY (`recordid`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='保存录像主表';

-- ----------------------------
-- Records of order_recorddata
-- ----------------------------
INSERT INTO `order_recorddata` VALUES ('2', 'hlQpAyTXb0KEXJsnSxn61Q', '5wsZx2HJM0OxrbGI_-9LHg', '1', '51', '0', '210052', '0', '2018-09-22 17:34:31', '0', '0');
INSERT INTO `order_recorddata` VALUES ('3', 'yOBDOWlSmEGUCEDOGR6ioQ', 'mMkudsuyCk2f1cexFz7kdA', '3', '100', '0', '210077', '0', '2018-09-22 18:02:32', '0', '0');
INSERT INTO `order_recorddata` VALUES ('4', 'yOBDOWlSmEGUCEDOGR6ioQ', 'r0IsaTcZ_0WbynH57RUreg', '3', '100', '0', '210077', '0', '2018-09-22 18:04:24', '0', '0');
INSERT INTO `order_recorddata` VALUES ('5', 'Qa53AqxkMUmQt_KtNC20bA', 'R04-ekqkW0GB_bI0Of5o2A', '3', '100', '0', '210083', '0', '2018-09-22 18:23:53', '0', '0');
INSERT INTO `order_recorddata` VALUES ('6', '_uGl6F2t60S75b3gt_aSXQ', 'uXfSuryMaUa4MwuGZIR6qw', '3', '100', '0', '210098', '0', '2018-09-22 19:46:48', '0', '0');
INSERT INTO `order_recorddata` VALUES ('7', '7l8TAtlvJ0-gEKAYbXE-Ng', 'GeXR6hP01kqLPvp2F8Jv7A', '3', '100', '0', '210135', '0', '2018-09-23 14:09:30', '0', '0');
INSERT INTO `order_recorddata` VALUES ('8', 'BU-7g1mPdkGQnGf9rXPxDQ', 'q7T9FbtD-U6HKH-kVVofWg', '3', '100', '0', '210139', '0', '2018-09-23 14:16:36', '0', '0');
INSERT INTO `order_recorddata` VALUES ('9', 'fGuFbIZ6OkGa0pluSPb8gg', 'VMYouvsGeUamXtCEBAjiTA', '3', '100', '0', '210159', '0', '2018-09-23 15:28:45', '0', '0');
INSERT INTO `order_recorddata` VALUES ('10', 'ENZa4Ad4TUebQ638laAAFg', 'OTnanQqRqkmGDwTqk7bIpg', '3', '100', '0', '210159', '0', '2018-09-23 15:30:07', '0', '0');
INSERT INTO `order_recorddata` VALUES ('11', 'usXRHMwohk2hQak_qU03-A', 'ell1yl482UerFbaQKbD5LA', '3', '100', '0', '210159', '0', '2018-09-23 15:32:03', '0', '0');
INSERT INTO `order_recorddata` VALUES ('12', 'sgc19XH8v0-gWI-ath36pg', 'XXdVcMhBx0G180hpVJY6_A', '3', '100', '0', '210222', '0', '2018-09-23 16:56:13', '0', '0');
INSERT INTO `order_recorddata` VALUES ('13', 'ev2bDvlz-0aHkgAeAcdFcg', 'lmFQQj9JfUaIt6cpPxck_A', '3', '100', '0', '210226', '0', '2018-09-23 16:58:39', '0', '0');
INSERT INTO `order_recorddata` VALUES ('14', 'EQiyajUen0-uxqnUtKkB4g', '3NLszbDZ4UecpfVh-xF4-Q', '3', '100', '0', '210231', '0', '2018-09-24 16:13:58', '0', '0');
INSERT INTO `order_recorddata` VALUES ('15', 'Fla2fcqmS0WTxaP_8RZlZw', 'dRYekDlkw0uwazaB9Vvkmw', '3', '100', '0', '210237', '0', '2018-09-24 16:19:16', '0', '0');
INSERT INTO `order_recorddata` VALUES ('16', 'jMmeee5GrUm59NlU13bVMw', 'FWW6VUxBv0qWbL3OMcp1lA', '3', '100', '0', '210241', '0', '2018-09-24 16:23:28', '0', '0');
INSERT INTO `order_recorddata` VALUES ('17', 'czDCwTShSEOKRQJ5t2vQBg', 'BCXKXyYNrkmjT4M8g9WOYw', '3', '100', '0', '210248', '0', '2018-09-24 16:32:33', '0', '0');
INSERT INTO `order_recorddata` VALUES ('18', '93bUruBC50-8tuF3IBMVeA', 'Bs6ag4QT5kSNwYEwQhS6Nw', '3', '100', '0', '210249', '0', '2018-09-24 16:38:45', '0', '0');
INSERT INTO `order_recorddata` VALUES ('19', 'RPmHDOyj0ky7mz-DlJ3ILw', 'QW_1osqeJUiXv-ZD4MgPKw', '3', '100', '0', '210254', '0', '2018-09-24 16:49:05', '0', '0');
INSERT INTO `order_recorddata` VALUES ('20', 'RPmHDOyj0ky7mz-DlJ3ILw', 'lZYnv4mdSUGJ-N4zhMiG_w', '3', '100', '0', '210254', '0', '2018-09-24 16:49:18', '0', '0');
INSERT INTO `order_recorddata` VALUES ('21', 'GOEGnEuImEOEoMYLr0DC2w', '-9SrsYFD502Fx67D-A1t1g', '3', '100', '0', '210256', '0', '2018-09-24 16:53:24', '0', '0');
INSERT INTO `order_recorddata` VALUES ('22', '0wKf7wAMK0mLgP0LJXI3rQ', 'w56yHqPkUkO9fi-mEMPwPg', '3', '100', '0', '210262', '0', '2018-09-24 16:57:39', '0', '0');
INSERT INTO `order_recorddata` VALUES ('23', '0wKf7wAMK0mLgP0LJXI3rQ', 'erdmFCe0yUS3rzBP9wbXKg', '3', '100', '0', '210262', '0', '2018-09-24 16:57:55', '0', '0');
INSERT INTO `order_recorddata` VALUES ('24', '5U9xEosotUy-89DjAhXkMw', '4zNQTPaT8E-xi0BXb6Q56g', '3', '100', '0', '210266', '0', '2018-09-24 17:00:17', '0', '0');
INSERT INTO `order_recorddata` VALUES ('25', 'Wg381EkiuUinBmNDbsKLBA', 'KupbK2d9xES5F7VRgjGCUQ', '3', '100', '0', '210266', '0', '2018-09-24 17:20:04', '0', '0');
INSERT INTO `order_recorddata` VALUES ('26', 'Wg381EkiuUinBmNDbsKLBA', 'bS7RPNYq20OFqqln59hFQw', '3', '100', '0', '210266', '0', '2018-09-24 17:20:21', '0', '0');
INSERT INTO `order_recorddata` VALUES ('27', 'iczdpjDfrEydJjtfMXl0Iw', 'VyWj_hj0a0e06OBRvLmznA', '3', '100', '0', '210266', '0', '2018-09-24 17:41:58', '0', '0');
INSERT INTO `order_recorddata` VALUES ('28', 'lo8bkeUv8U2q1-_v7Os_IQ', 'obIJYTQso0G7dxOSuMYdZw', '3', '100', '0', '210308', '0', '2018-09-24 19:26:55', '0', '0');
INSERT INTO `order_recorddata` VALUES ('29', 'poeOCrVTFUWJcWV_fQTgpw', 'UYGhEIriu0WTfJFXobtHbw', '3', '100', '0', '210634', '0', '2018-09-26 09:34:47', '0', '0');
INSERT INTO `order_recorddata` VALUES ('30', 'omT76X5X_UePHWnRm7gtKg', 'iCDGflrz5kK5xrQ9Ws0qAw', '1', '51', '0', '210638', '0', '2018-09-26 10:01:01', '0', '0');
INSERT INTO `order_recorddata` VALUES ('31', 'cGns4K1SAE2cmQL0L6Iq9A', 'IG84a8hYNEG75V6Hq3rXnA', '1', '51', '0', '210640', '0', '2018-09-26 10:11:16', '0', '0');
INSERT INTO `order_recorddata` VALUES ('32', '8jIHZ5zqy0SU84jrtJyj_A', 'sHA9QuMxr0CJKfki4yTbaw', '1', '51', '0', '210643', '0', '2018-09-26 10:19:52', '0', '0');
INSERT INTO `order_recorddata` VALUES ('33', 'aRFceACoMUyyytM0hlcd3w', 'yCtDe3Il0UiNZvDjxqou9w', '3', '100', '0', '210680', '0', '2018-09-26 11:50:14', '0', '0');
INSERT INTO `order_recorddata` VALUES ('34', '3-EjO0IpUEa9pyKUh3vkeg', 'U-hP4UCNQEyzxwaS1CSJsA', '1', '51', '0', '210682', '0', '2018-09-26 11:52:44', '0', '0');
INSERT INTO `order_recorddata` VALUES ('35', '3-EjO0IpUEa9pyKUh3vkeg', 'LYRVIsBqC0irxQX3DY9TVQ', '1', '51', '0', '210682', '0', '2018-09-26 11:56:10', '0', '0');
INSERT INTO `order_recorddata` VALUES ('36', 'cVE1K4l4qUmLj9QCABSm4g', 'zr4cKvevYkOazHPOHK4dJw', '3', '100', '0', '210685', '0', '2018-09-26 13:08:41', '0', '0');
INSERT INTO `order_recorddata` VALUES ('37', 'cVE1K4l4qUmLj9QCABSm4g', '9pAjFatNt0anQDHduTRuVA', '3', '100', '0', '210685', '0', '2018-09-26 13:09:24', '0', '0');
INSERT INTO `order_recorddata` VALUES ('38', '6tVDtC0HUkGlygThXKaa-A', 'eLsPqNGVOUC0QORY5RYIag', '3', '100', '0', '210685', '0', '2018-09-26 13:12:25', '0', '0');
INSERT INTO `order_recorddata` VALUES ('39', 'P8Xcqed74k2GMbRaC7FRng', '7Wf75_RHV0ug2BlsrTy5tg', '3', '100', '0', '210685', '0', '2018-09-26 13:14:57', '0', '0');
INSERT INTO `order_recorddata` VALUES ('40', 'P8Xcqed74k2GMbRaC7FRng', 'rBUbNNhVvUWbc4p2diVNiA', '3', '100', '0', '210685', '0', '2018-09-26 13:15:15', '0', '0');
INSERT INTO `order_recorddata` VALUES ('41', 'FAsIrnp-UE2JSNo9mE7hEw', 'wTu_REVKkEe_VPLO9H3xpw', '3', '100', '0', '210685', '0', '2018-09-26 14:01:21', '0', '0');
INSERT INTO `order_recorddata` VALUES ('42', 'vL1DO4dljUicUeCTwosSyQ', '2EJG31SYp0WaJqMW1IkgNw', '3', '100', '0', '210685', '0', '2018-09-26 14:07:06', '0', '0');
INSERT INTO `order_recorddata` VALUES ('43', 'vL1DO4dljUicUeCTwosSyQ', '5sz649Xw5k6O_wrwCkVJeA', '3', '100', '0', '210685', '0', '2018-09-26 14:09:19', '0', '0');
INSERT INTO `order_recorddata` VALUES ('44', 'ni7ecyC-9k-AphTFfBAMhg', 'Fh-Tb9mNe0mbXYjI1uLA2w', '3', '100', '0', '210685', '0', '2018-09-26 14:13:19', '0', '0');
INSERT INTO `order_recorddata` VALUES ('45', 'ni7ecyC-9k-AphTFfBAMhg', 'AoXZ9zwzaEKA_Gasl5g9MQ', '3', '100', '0', '210685', '0', '2018-09-26 14:13:50', '0', '0');
INSERT INTO `order_recorddata` VALUES ('46', 'ni7ecyC-9k-AphTFfBAMhg', 'xPlFiMQm4k-sOHhaAjokVw', '3', '100', '0', '210685', '0', '2018-09-26 14:14:03', '0', '0');
INSERT INTO `order_recorddata` VALUES ('47', 'NHYA436kE0OH5vzTIWBuUA', 'rb6khSwGjUqd-SeS4yHVFA', '3', '100', '0', '210685', '0', '2018-09-26 14:17:33', '0', '0');
INSERT INTO `order_recorddata` VALUES ('48', 'NHYA436kE0OH5vzTIWBuUA', 'HFXxBm_QZUmtY4tMcinnkw', '3', '100', '0', '210685', '0', '2018-09-26 14:17:45', '0', '0');
INSERT INTO `order_recorddata` VALUES ('49', 'NHYA436kE0OH5vzTIWBuUA', 'yyVMl8nxWE-PtjY9o_230Q', '3', '100', '0', '210685', '0', '2018-09-26 14:18:28', '0', '0');
INSERT INTO `order_recorddata` VALUES ('50', 'OKxWBlTltE-tya4mA_JlLw', 'Nx00FFFOKUyajAGIGjkSgQ', '3', '100', '0', '210692', '0', '2018-09-26 14:21:59', '0', '0');
INSERT INTO `order_recorddata` VALUES ('51', 'OKxWBlTltE-tya4mA_JlLw', 'FJga0TPCsk6t3Th9f_cU4A', '3', '100', '0', '210692', '0', '2018-09-26 14:22:08', '0', '0');
INSERT INTO `order_recorddata` VALUES ('52', 'OKxWBlTltE-tya4mA_JlLw', 'DcD3y87r5Uy11VC_bqlQoA', '3', '100', '0', '210692', '0', '2018-09-26 14:22:19', '0', '0');
INSERT INTO `order_recorddata` VALUES ('53', 'N3dREAoqjU2MKDDDVLg1Ew', 'a-N6La2X8kSFX9iMmnriTA', '3', '100', '0', '210692', '0', '2018-09-26 14:23:11', '0', '0');
INSERT INTO `order_recorddata` VALUES ('54', 'N3dREAoqjU2MKDDDVLg1Ew', 'BXHZTjTmq0q_lQMBC1QEKA', '3', '100', '0', '210692', '0', '2018-09-26 14:23:18', '0', '0');
INSERT INTO `order_recorddata` VALUES ('55', 'eWh5c3IQQkyBvY9yuotM3A', 'j7fH31FLyEavOKTa-CBVug', '3', '100', '0', '210692', '0', '2018-09-26 14:23:56', '0', '0');
INSERT INTO `order_recorddata` VALUES ('56', 'eWh5c3IQQkyBvY9yuotM3A', 'NFNjwQx4hUWNvcRgbWo_Dg', '3', '100', '0', '210692', '0', '2018-09-26 14:24:08', '0', '0');
INSERT INTO `order_recorddata` VALUES ('57', '4YDjs97bl0KvpGYY5B5itg', 'n2tOlOvVtUi7RfRSTBLGPQ', '3', '100', '0', '210694', '0', '2018-09-26 14:27:46', '0', '0');
INSERT INTO `order_recorddata` VALUES ('58', '4YDjs97bl0KvpGYY5B5itg', 'KYxbRjGG-EysQfX9fMSrVQ', '3', '100', '0', '210694', '0', '2018-09-26 14:28:10', '0', '0');
INSERT INTO `order_recorddata` VALUES ('59', 'jRSNUK8zOEOZxDGUI9C-Zg', 'DwC6zxHb_EOhYTXeYwDmzQ', '3', '100', '0', '210694', '0', '2018-09-26 14:28:54', '0', '0');
INSERT INTO `order_recorddata` VALUES ('60', 'jRSNUK8zOEOZxDGUI9C-Zg', 'Flyp-bdfFE2FhXFzahxGRg', '3', '100', '0', '210694', '0', '2018-09-26 14:29:08', '0', '0');
INSERT INTO `order_recorddata` VALUES ('61', 'jRSNUK8zOEOZxDGUI9C-Zg', 'fPlDjxzKdUmJKoZTaY-sqA', '3', '100', '0', '210694', '0', '2018-09-26 14:29:30', '0', '0');
INSERT INTO `order_recorddata` VALUES ('62', '25HtSq8avUWS9znYQosM0A', 'bYjrgnzTtUi1KGhCbsg--g', '3', '100', '0', '210713', '0', '2018-09-26 15:01:27', '0', '0');
INSERT INTO `order_recorddata` VALUES ('63', 'Z_gD4a-YckClCGC36qY-Lw', 'w1Da-j25ckiPJvPnBDPrKg', '1', '51', '0', '210717', '0', '2018-09-26 15:05:00', '0', '0');
INSERT INTO `order_recorddata` VALUES ('64', '68hLn_miNUqKuSJuKzYfcw', 'mhtwduGbz0uYca1vaDx9xg', '1', '51', '0', '210723', '0', '2018-09-26 15:15:07', '0', '0');
INSERT INTO `order_recorddata` VALUES ('65', 'QojVTHtykkS1SGYrWj-eHQ', 'cI9ftsfTD029dw-_nGdLbg', '3', '100', '0', '210728', '0', '2018-09-26 15:15:10', '0', '0');
INSERT INTO `order_recorddata` VALUES ('66', 'zD2cEBbm2ki0GKVa0E_2Jg', 'tZZJ6tvM70qJwCHogh8zSQ', '3', '100', '0', '210728', '0', '2018-09-26 15:20:47', '0', '0');
INSERT INTO `order_recorddata` VALUES ('67', 'fKbU-iEUGkiTrxKdd4amFw', 'yediYA3liUCT-uzKpxtKag', '3', '100', '0', '210732', '0', '2018-09-26 15:27:35', '0', '0');
INSERT INTO `order_recorddata` VALUES ('68', 'jNAPnDNMoUukau3nzZZjGQ', 'lQtIkU5bnUaWOGxQrkdsrQ', '3', '100', '0', '210737', '0', '2018-09-26 15:32:32', '0', '0');
INSERT INTO `order_recorddata` VALUES ('69', 'F1OlbeBxCEquvL3FAqBtrg', 'mlJqv6ytM0apa7n-Xr63SQ', '1', '51', '0', '210741', '0', '2018-09-26 15:42:17', '0', '0');
INSERT INTO `order_recorddata` VALUES ('70', 'dsJjWzUMbU-PXrZhgyi-xw', 'OyPs9jCjyUCPKH86kMsdTA', '1', '51', '0', '210746', '0', '2018-09-26 15:49:44', '0', '0');
INSERT INTO `order_recorddata` VALUES ('71', 'fvjDxweX20ido6LH8o0-RQ', 'piqRXUBd6EuL1kmtnxC3BQ', '1', '51', '0', '210755', '0', '2018-09-26 15:55:04', '0', '0');
INSERT INTO `order_recorddata` VALUES ('72', 'boQOPJSMUEep4HZEhA_ORw', 'dRh8gjw_dUyf_VB_V1I0yQ', '3', '100', '0', '210777', '0', '2018-09-26 16:44:14', '0', '0');
INSERT INTO `order_recorddata` VALUES ('73', 'QdcOH-v-iUaz4sPSgWI3gw', 'ys7swV47pkqOvntvtEjXNQ', '3', '100', '0', '210777', '0', '2018-09-26 16:49:40', '0', '0');
INSERT INTO `order_recorddata` VALUES ('74', 'JX9WUOvfeUSrwSXJYEhLZw', '3cIe4S01xUa_QIc5xghKmQ', '3', '100', '0', '210781', '0', '2018-09-26 16:52:56', '0', '0');
INSERT INTO `order_recorddata` VALUES ('75', 'SLnqWIRSykqXXESWIx8kkw', 'lDb3HJCbn0eVCxyP0Fu7Og', '3', '100', '0', '210785', '0', '2018-09-26 16:55:35', '0', '0');
INSERT INTO `order_recorddata` VALUES ('76', 'L-KmGouoqk6F7gSquLk5wA', '2ICWMDd-HUe0nlIEg92orw', '3', '100', '0', '210789', '0', '2018-09-26 17:00:48', '0', '0');
INSERT INTO `order_recorddata` VALUES ('77', 'uCfFImENqECJ21G3qVOsqw', 'LTglp4aWa0yIvwKMD00Cfw', '3', '100', '0', '210793', '0', '2018-09-26 17:04:03', '0', '0');
INSERT INTO `order_recorddata` VALUES ('78', 'UZ9mcZBs3E2LuBIPawLbkA', 'xETotVjuSUuDj1o1aFbcfw', '3', '100', '0', '210793', '0', '2018-09-26 17:05:33', '0', '0');
INSERT INTO `order_recorddata` VALUES ('79', 'MRE1lnRBRkKizRSmCkbzaQ', 'RBW0EpKg20-rcqsv21JxXg', '3', '100', '0', '210800', '0', '2018-09-26 17:09:29', '0', '0');
INSERT INTO `order_recorddata` VALUES ('80', 'KNDHSAVrFUenO9gawAJTUw', '4yGRtiCyCkmFuJPvf-0qVA', '3', '100', '0', '210800', '0', '2018-09-26 17:20:59', '0', '0');
INSERT INTO `order_recorddata` VALUES ('81', '982cDftEOEGxfah7HpCQOQ', 'TpeYGaFlVUy-5llWC4xZmg', '3', '100', '0', '210818', '0', '2018-09-26 17:43:41', '0', '0');

-- ----------------------------
-- Table structure for order_recorddata_detail
-- ----------------------------
DROP TABLE IF EXISTS `order_recorddata_detail`;
CREATE TABLE `order_recorddata_detail` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `recordid` int(11) NOT NULL,
  `userid` int(11) DEFAULT NULL COMMENT '结算的玩家Id',
  `moneynum` int(11) DEFAULT NULL COMMENT '结算输赢数量',
  `moneytype` int(11) DEFAULT NULL COMMENT '结算的道具类型',
  `addtime` datetime DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=314 DEFAULT CHARSET=utf8 COMMENT='保存录像子表';

-- ----------------------------
-- Records of order_recorddata_detail
-- ----------------------------
INSERT INTO `order_recorddata_detail` VALUES ('1', '2', '210052', '-4', '0', '2018-09-22 17:34:31');
INSERT INTO `order_recorddata_detail` VALUES ('2', '2', '210065', '4', '0', '2018-09-22 17:34:31');
INSERT INTO `order_recorddata_detail` VALUES ('3', '3', '210078', '-2', '0', '2018-09-22 18:02:32');
INSERT INTO `order_recorddata_detail` VALUES ('4', '3', '210079', '2', '0', '2018-09-22 18:02:32');
INSERT INTO `order_recorddata_detail` VALUES ('5', '3', '210077', '0', '0', '2018-09-22 18:02:32');
INSERT INTO `order_recorddata_detail` VALUES ('6', '3', '210080', '0', '0', '2018-09-22 18:02:32');
INSERT INTO `order_recorddata_detail` VALUES ('7', '4', '210078', '0', '0', '2018-09-22 18:04:24');
INSERT INTO `order_recorddata_detail` VALUES ('8', '4', '210079', '0', '0', '2018-09-22 18:04:24');
INSERT INTO `order_recorddata_detail` VALUES ('9', '4', '210077', '0', '0', '2018-09-22 18:04:24');
INSERT INTO `order_recorddata_detail` VALUES ('10', '4', '210080', '0', '0', '2018-09-22 18:04:24');
INSERT INTO `order_recorddata_detail` VALUES ('11', '5', '210086', '0', '0', '2018-09-22 18:23:53');
INSERT INTO `order_recorddata_detail` VALUES ('12', '5', '210084', '0', '0', '2018-09-22 18:23:53');
INSERT INTO `order_recorddata_detail` VALUES ('13', '5', '210085', '0', '0', '2018-09-22 18:23:53');
INSERT INTO `order_recorddata_detail` VALUES ('14', '5', '210083', '0', '0', '2018-09-22 18:23:53');
INSERT INTO `order_recorddata_detail` VALUES ('15', '6', '210098', '0', '0', '2018-09-22 19:46:48');
INSERT INTO `order_recorddata_detail` VALUES ('16', '6', '210100', '0', '0', '2018-09-22 19:46:48');
INSERT INTO `order_recorddata_detail` VALUES ('17', '6', '210097', '0', '0', '2018-09-22 19:46:48');
INSERT INTO `order_recorddata_detail` VALUES ('18', '6', '210099', '0', '0', '2018-09-22 19:46:48');
INSERT INTO `order_recorddata_detail` VALUES ('19', '7', '210135', '0', '0', '2018-09-23 14:09:30');
INSERT INTO `order_recorddata_detail` VALUES ('20', '7', '210137', '0', '0', '2018-09-23 14:09:30');
INSERT INTO `order_recorddata_detail` VALUES ('21', '7', '210136', '0', '0', '2018-09-23 14:09:30');
INSERT INTO `order_recorddata_detail` VALUES ('22', '7', '210138', '0', '0', '2018-09-23 14:09:30');
INSERT INTO `order_recorddata_detail` VALUES ('23', '8', '210140', '0', '0', '2018-09-23 14:16:36');
INSERT INTO `order_recorddata_detail` VALUES ('24', '8', '210139', '0', '0', '2018-09-23 14:16:36');
INSERT INTO `order_recorddata_detail` VALUES ('25', '8', '210141', '0', '0', '2018-09-23 14:16:36');
INSERT INTO `order_recorddata_detail` VALUES ('26', '8', '210142', '0', '0', '2018-09-23 14:16:36');
INSERT INTO `order_recorddata_detail` VALUES ('27', '9', '210162', '0', '0', '2018-09-23 15:28:45');
INSERT INTO `order_recorddata_detail` VALUES ('28', '9', '210161', '0', '0', '2018-09-23 15:28:45');
INSERT INTO `order_recorddata_detail` VALUES ('29', '9', '210159', '0', '0', '2018-09-23 15:28:45');
INSERT INTO `order_recorddata_detail` VALUES ('30', '9', '210160', '0', '0', '2018-09-23 15:28:45');
INSERT INTO `order_recorddata_detail` VALUES ('31', '10', '210159', '0', '0', '2018-09-23 15:30:07');
INSERT INTO `order_recorddata_detail` VALUES ('32', '10', '210160', '0', '0', '2018-09-23 15:30:07');
INSERT INTO `order_recorddata_detail` VALUES ('33', '10', '210162', '0', '0', '2018-09-23 15:30:07');
INSERT INTO `order_recorddata_detail` VALUES ('34', '10', '210161', '0', '0', '2018-09-23 15:30:07');
INSERT INTO `order_recorddata_detail` VALUES ('35', '11', '210162', '0', '0', '2018-09-23 15:32:03');
INSERT INTO `order_recorddata_detail` VALUES ('36', '11', '210159', '0', '0', '2018-09-23 15:32:03');
INSERT INTO `order_recorddata_detail` VALUES ('37', '11', '210160', '0', '0', '2018-09-23 15:32:03');
INSERT INTO `order_recorddata_detail` VALUES ('38', '11', '210161', '0', '0', '2018-09-23 15:32:03');
INSERT INTO `order_recorddata_detail` VALUES ('39', '12', '210222', '0', '0', '2018-09-23 16:56:13');
INSERT INTO `order_recorddata_detail` VALUES ('40', '12', '210224', '-2', '0', '2018-09-23 16:56:13');
INSERT INTO `order_recorddata_detail` VALUES ('41', '12', '210223', '0', '0', '2018-09-23 16:56:13');
INSERT INTO `order_recorddata_detail` VALUES ('42', '12', '210225', '2', '0', '2018-09-23 16:56:13');
INSERT INTO `order_recorddata_detail` VALUES ('43', '13', '210228', '-2', '0', '2018-09-23 16:58:39');
INSERT INTO `order_recorddata_detail` VALUES ('44', '13', '210227', '0', '0', '2018-09-23 16:58:39');
INSERT INTO `order_recorddata_detail` VALUES ('45', '13', '210226', '0', '0', '2018-09-23 16:58:39');
INSERT INTO `order_recorddata_detail` VALUES ('46', '13', '210229', '2', '0', '2018-09-23 16:58:39');
INSERT INTO `order_recorddata_detail` VALUES ('47', '14', '210233', '-2', '0', '2018-09-24 16:13:58');
INSERT INTO `order_recorddata_detail` VALUES ('48', '14', '210234', '2', '0', '2018-09-24 16:13:58');
INSERT INTO `order_recorddata_detail` VALUES ('49', '14', '210231', '0', '0', '2018-09-24 16:13:58');
INSERT INTO `order_recorddata_detail` VALUES ('50', '14', '210232', '0', '0', '2018-09-24 16:13:58');
INSERT INTO `order_recorddata_detail` VALUES ('51', '15', '210237', '2', '0', '2018-09-24 16:19:16');
INSERT INTO `order_recorddata_detail` VALUES ('52', '15', '210240', '-2', '0', '2018-09-24 16:19:16');
INSERT INTO `order_recorddata_detail` VALUES ('53', '15', '210238', '0', '0', '2018-09-24 16:19:16');
INSERT INTO `order_recorddata_detail` VALUES ('54', '15', '210239', '0', '0', '2018-09-24 16:19:16');
INSERT INTO `order_recorddata_detail` VALUES ('55', '16', '210241', '2', '0', '2018-09-24 16:23:28');
INSERT INTO `order_recorddata_detail` VALUES ('56', '16', '210243', '0', '0', '2018-09-24 16:23:28');
INSERT INTO `order_recorddata_detail` VALUES ('57', '16', '210244', '-2', '0', '2018-09-24 16:23:28');
INSERT INTO `order_recorddata_detail` VALUES ('58', '16', '210242', '0', '0', '2018-09-24 16:23:28');
INSERT INTO `order_recorddata_detail` VALUES ('59', '17', '210246', '0', '0', '2018-09-24 16:32:33');
INSERT INTO `order_recorddata_detail` VALUES ('60', '17', '210245', '-2', '0', '2018-09-24 16:32:33');
INSERT INTO `order_recorddata_detail` VALUES ('61', '17', '210247', '0', '0', '2018-09-24 16:32:33');
INSERT INTO `order_recorddata_detail` VALUES ('62', '17', '210248', '2', '0', '2018-09-24 16:32:33');
INSERT INTO `order_recorddata_detail` VALUES ('63', '18', '210252', '0', '0', '2018-09-24 16:38:45');
INSERT INTO `order_recorddata_detail` VALUES ('64', '18', '210251', '2', '0', '2018-09-24 16:38:45');
INSERT INTO `order_recorddata_detail` VALUES ('65', '18', '210249', '0', '0', '2018-09-24 16:38:45');
INSERT INTO `order_recorddata_detail` VALUES ('66', '18', '210250', '-2', '0', '2018-09-24 16:38:45');
INSERT INTO `order_recorddata_detail` VALUES ('67', '19', '210253', '0', '0', '2018-09-24 16:49:05');
INSERT INTO `order_recorddata_detail` VALUES ('68', '19', '210249', '0', '0', '2018-09-24 16:49:05');
INSERT INTO `order_recorddata_detail` VALUES ('69', '19', '210255', '2', '0', '2018-09-24 16:49:05');
INSERT INTO `order_recorddata_detail` VALUES ('70', '19', '210254', '-2', '0', '2018-09-24 16:49:05');
INSERT INTO `order_recorddata_detail` VALUES ('71', '20', '210253', '0', '0', '2018-09-24 16:49:18');
INSERT INTO `order_recorddata_detail` VALUES ('72', '20', '210249', '0', '0', '2018-09-24 16:49:18');
INSERT INTO `order_recorddata_detail` VALUES ('73', '20', '210255', '0', '0', '2018-09-24 16:49:18');
INSERT INTO `order_recorddata_detail` VALUES ('74', '20', '210254', '0', '0', '2018-09-24 16:49:18');
INSERT INTO `order_recorddata_detail` VALUES ('75', '21', '210256', '0', '0', '2018-09-24 16:53:24');
INSERT INTO `order_recorddata_detail` VALUES ('76', '21', '210259', '2', '0', '2018-09-24 16:53:24');
INSERT INTO `order_recorddata_detail` VALUES ('77', '21', '210257', '-2', '0', '2018-09-24 16:53:24');
INSERT INTO `order_recorddata_detail` VALUES ('78', '21', '210258', '0', '0', '2018-09-24 16:53:24');
INSERT INTO `order_recorddata_detail` VALUES ('79', '22', '210264', '2', '0', '2018-09-24 16:57:39');
INSERT INTO `order_recorddata_detail` VALUES ('80', '22', '210261', '0', '0', '2018-09-24 16:57:39');
INSERT INTO `order_recorddata_detail` VALUES ('81', '22', '210263', '-2', '0', '2018-09-24 16:57:39');
INSERT INTO `order_recorddata_detail` VALUES ('82', '22', '210262', '0', '0', '2018-09-24 16:57:39');
INSERT INTO `order_recorddata_detail` VALUES ('83', '23', '210264', '0', '0', '2018-09-24 16:57:55');
INSERT INTO `order_recorddata_detail` VALUES ('84', '23', '210261', '0', '0', '2018-09-24 16:57:55');
INSERT INTO `order_recorddata_detail` VALUES ('85', '23', '210263', '0', '0', '2018-09-24 16:57:55');
INSERT INTO `order_recorddata_detail` VALUES ('86', '23', '210262', '0', '0', '2018-09-24 16:57:55');
INSERT INTO `order_recorddata_detail` VALUES ('87', '24', '210267', '0', '0', '2018-09-24 17:00:17');
INSERT INTO `order_recorddata_detail` VALUES ('88', '24', '210266', '-2', '0', '2018-09-24 17:00:17');
INSERT INTO `order_recorddata_detail` VALUES ('89', '24', '210265', '0', '0', '2018-09-24 17:00:17');
INSERT INTO `order_recorddata_detail` VALUES ('90', '24', '210268', '2', '0', '2018-09-24 17:00:17');
INSERT INTO `order_recorddata_detail` VALUES ('91', '25', '210267', '-2', '0', '2018-09-24 17:20:04');
INSERT INTO `order_recorddata_detail` VALUES ('92', '25', '210266', '0', '0', '2018-09-24 17:20:04');
INSERT INTO `order_recorddata_detail` VALUES ('93', '25', '210265', '0', '0', '2018-09-24 17:20:04');
INSERT INTO `order_recorddata_detail` VALUES ('94', '25', '210268', '2', '0', '2018-09-24 17:20:04');
INSERT INTO `order_recorddata_detail` VALUES ('95', '26', '210267', '0', '0', '2018-09-24 17:20:21');
INSERT INTO `order_recorddata_detail` VALUES ('96', '26', '210266', '0', '0', '2018-09-24 17:20:21');
INSERT INTO `order_recorddata_detail` VALUES ('97', '26', '210265', '0', '0', '2018-09-24 17:20:21');
INSERT INTO `order_recorddata_detail` VALUES ('98', '26', '210268', '0', '0', '2018-09-24 17:20:21');
INSERT INTO `order_recorddata_detail` VALUES ('99', '27', '210267', '0', '0', '2018-09-24 17:41:58');
INSERT INTO `order_recorddata_detail` VALUES ('100', '27', '210265', '0', '0', '2018-09-24 17:41:58');
INSERT INTO `order_recorddata_detail` VALUES ('101', '27', '210269', '0', '0', '2018-09-24 17:41:58');
INSERT INTO `order_recorddata_detail` VALUES ('102', '27', '210266', '0', '0', '2018-09-24 17:41:58');
INSERT INTO `order_recorddata_detail` VALUES ('103', '28', '210308', '0', '0', '2018-09-24 19:26:55');
INSERT INTO `order_recorddata_detail` VALUES ('104', '28', '210310', '0', '0', '2018-09-24 19:26:55');
INSERT INTO `order_recorddata_detail` VALUES ('105', '28', '210311', '0', '0', '2018-09-24 19:26:55');
INSERT INTO `order_recorddata_detail` VALUES ('106', '28', '210309', '0', '0', '2018-09-24 19:26:55');
INSERT INTO `order_recorddata_detail` VALUES ('107', '29', '210635', '0', '0', '2018-09-26 09:34:47');
INSERT INTO `order_recorddata_detail` VALUES ('108', '29', '210637', '0', '0', '2018-09-26 09:34:47');
INSERT INTO `order_recorddata_detail` VALUES ('109', '29', '210636', '0', '0', '2018-09-26 09:34:47');
INSERT INTO `order_recorddata_detail` VALUES ('110', '29', '210634', '0', '0', '2018-09-26 09:34:47');
INSERT INTO `order_recorddata_detail` VALUES ('111', '30', '210638', '0', '0', '2018-09-26 10:01:01');
INSERT INTO `order_recorddata_detail` VALUES ('112', '30', '210639', '0', '0', '2018-09-26 10:01:01');
INSERT INTO `order_recorddata_detail` VALUES ('113', '31', '210641', '1', '0', '2018-09-26 10:11:16');
INSERT INTO `order_recorddata_detail` VALUES ('114', '31', '210640', '1', '0', '2018-09-26 10:11:16');
INSERT INTO `order_recorddata_detail` VALUES ('115', '32', '210644', '-1', '0', '2018-09-26 10:19:52');
INSERT INTO `order_recorddata_detail` VALUES ('116', '32', '210643', '1', '0', '2018-09-26 10:19:52');
INSERT INTO `order_recorddata_detail` VALUES ('117', '33', '210680', '0', '0', '2018-09-26 11:50:14');
INSERT INTO `order_recorddata_detail` VALUES ('118', '33', '210677', '2', '0', '2018-09-26 11:50:14');
INSERT INTO `order_recorddata_detail` VALUES ('119', '33', '210679', '0', '0', '2018-09-26 11:50:14');
INSERT INTO `order_recorddata_detail` VALUES ('120', '33', '210678', '-2', '0', '2018-09-26 11:50:14');
INSERT INTO `order_recorddata_detail` VALUES ('121', '34', '210681', '-1', '0', '2018-09-26 11:52:44');
INSERT INTO `order_recorddata_detail` VALUES ('122', '34', '210682', '1', '0', '2018-09-26 11:52:44');
INSERT INTO `order_recorddata_detail` VALUES ('123', '35', '210681', '3', '0', '2018-09-26 11:56:10');
INSERT INTO `order_recorddata_detail` VALUES ('124', '35', '210682', '-3', '0', '2018-09-26 11:56:10');
INSERT INTO `order_recorddata_detail` VALUES ('125', '36', '210688', '0', '0', '2018-09-26 13:08:41');
INSERT INTO `order_recorddata_detail` VALUES ('126', '36', '210685', '36', '0', '2018-09-26 13:08:41');
INSERT INTO `order_recorddata_detail` VALUES ('127', '36', '210687', '-36', '0', '2018-09-26 13:08:41');
INSERT INTO `order_recorddata_detail` VALUES ('128', '36', '210686', '0', '0', '2018-09-26 13:08:41');
INSERT INTO `order_recorddata_detail` VALUES ('129', '37', '210688', '0', '0', '2018-09-26 13:09:24');
INSERT INTO `order_recorddata_detail` VALUES ('130', '37', '210685', '28', '0', '2018-09-26 13:09:24');
INSERT INTO `order_recorddata_detail` VALUES ('131', '37', '210687', '-28', '0', '2018-09-26 13:09:24');
INSERT INTO `order_recorddata_detail` VALUES ('132', '37', '210686', '0', '0', '2018-09-26 13:09:24');
INSERT INTO `order_recorddata_detail` VALUES ('133', '38', '210685', '0', '0', '2018-09-26 13:12:25');
INSERT INTO `order_recorddata_detail` VALUES ('134', '38', '210687', '18', '0', '2018-09-26 13:12:25');
INSERT INTO `order_recorddata_detail` VALUES ('135', '38', '210686', '-18', '0', '2018-09-26 13:12:25');
INSERT INTO `order_recorddata_detail` VALUES ('136', '38', '210688', '0', '0', '2018-09-26 13:12:25');
INSERT INTO `order_recorddata_detail` VALUES ('137', '39', '210687', '0', '0', '2018-09-26 13:14:57');
INSERT INTO `order_recorddata_detail` VALUES ('138', '39', '210685', '40', '0', '2018-09-26 13:14:57');
INSERT INTO `order_recorddata_detail` VALUES ('139', '39', '210686', '-40', '0', '2018-09-26 13:14:57');
INSERT INTO `order_recorddata_detail` VALUES ('140', '39', '210688', '0', '0', '2018-09-26 13:14:57');
INSERT INTO `order_recorddata_detail` VALUES ('141', '40', '210687', '-72', '0', '2018-09-26 13:15:15');
INSERT INTO `order_recorddata_detail` VALUES ('142', '40', '210685', '216', '0', '2018-09-26 13:15:15');
INSERT INTO `order_recorddata_detail` VALUES ('143', '40', '210686', '-72', '0', '2018-09-26 13:15:15');
INSERT INTO `order_recorddata_detail` VALUES ('144', '40', '210688', '-72', '0', '2018-09-26 13:15:15');
INSERT INTO `order_recorddata_detail` VALUES ('145', '41', '210686', '0', '0', '2018-09-26 14:01:21');
INSERT INTO `order_recorddata_detail` VALUES ('146', '41', '210685', '2', '0', '2018-09-26 14:01:21');
INSERT INTO `order_recorddata_detail` VALUES ('147', '41', '210687', '0', '0', '2018-09-26 14:01:21');
INSERT INTO `order_recorddata_detail` VALUES ('148', '41', '210688', '-2', '0', '2018-09-26 14:01:21');
INSERT INTO `order_recorddata_detail` VALUES ('149', '42', '210688', '0', '0', '2018-09-26 14:07:06');
INSERT INTO `order_recorddata_detail` VALUES ('150', '42', '210686', '32', '0', '2018-09-26 14:07:06');
INSERT INTO `order_recorddata_detail` VALUES ('151', '42', '210685', '0', '0', '2018-09-26 14:07:06');
INSERT INTO `order_recorddata_detail` VALUES ('152', '42', '210687', '-32', '0', '2018-09-26 14:07:06');
INSERT INTO `order_recorddata_detail` VALUES ('153', '43', '210688', '0', '0', '2018-09-26 14:09:19');
INSERT INTO `order_recorddata_detail` VALUES ('154', '43', '210686', '0', '0', '2018-09-26 14:09:19');
INSERT INTO `order_recorddata_detail` VALUES ('155', '43', '210685', '0', '0', '2018-09-26 14:09:19');
INSERT INTO `order_recorddata_detail` VALUES ('156', '43', '210687', '0', '0', '2018-09-26 14:09:19');
INSERT INTO `order_recorddata_detail` VALUES ('157', '44', '210685', '-36', '0', '2018-09-26 14:13:19');
INSERT INTO `order_recorddata_detail` VALUES ('158', '44', '210687', '36', '0', '2018-09-26 14:13:19');
INSERT INTO `order_recorddata_detail` VALUES ('159', '44', '210688', '0', '0', '2018-09-26 14:13:19');
INSERT INTO `order_recorddata_detail` VALUES ('160', '44', '210686', '0', '0', '2018-09-26 14:13:19');
INSERT INTO `order_recorddata_detail` VALUES ('161', '45', '210685', '0', '0', '2018-09-26 14:13:50');
INSERT INTO `order_recorddata_detail` VALUES ('162', '45', '210687', '18', '0', '2018-09-26 14:13:50');
INSERT INTO `order_recorddata_detail` VALUES ('163', '45', '210688', '-18', '0', '2018-09-26 14:13:50');
INSERT INTO `order_recorddata_detail` VALUES ('164', '45', '210686', '0', '0', '2018-09-26 14:13:50');
INSERT INTO `order_recorddata_detail` VALUES ('165', '46', '210685', '0', '0', '2018-09-26 14:14:03');
INSERT INTO `order_recorddata_detail` VALUES ('166', '46', '210687', '0', '0', '2018-09-26 14:14:03');
INSERT INTO `order_recorddata_detail` VALUES ('167', '46', '210688', '0', '0', '2018-09-26 14:14:03');
INSERT INTO `order_recorddata_detail` VALUES ('168', '46', '210686', '0', '0', '2018-09-26 14:14:03');
INSERT INTO `order_recorddata_detail` VALUES ('169', '47', '210688', '0', '0', '2018-09-26 14:17:33');
INSERT INTO `order_recorddata_detail` VALUES ('170', '47', '210685', '24', '0', '2018-09-26 14:17:33');
INSERT INTO `order_recorddata_detail` VALUES ('171', '47', '210686', '-24', '0', '2018-09-26 14:17:33');
INSERT INTO `order_recorddata_detail` VALUES ('172', '47', '210687', '0', '0', '2018-09-26 14:17:33');
INSERT INTO `order_recorddata_detail` VALUES ('173', '48', '210688', '0', '0', '2018-09-26 14:17:45');
INSERT INTO `order_recorddata_detail` VALUES ('174', '48', '210685', '40', '0', '2018-09-26 14:17:45');
INSERT INTO `order_recorddata_detail` VALUES ('175', '48', '210686', '0', '0', '2018-09-26 14:17:45');
INSERT INTO `order_recorddata_detail` VALUES ('176', '48', '210687', '-40', '0', '2018-09-26 14:17:45');
INSERT INTO `order_recorddata_detail` VALUES ('177', '49', '210688', '0', '0', '2018-09-26 14:18:28');
INSERT INTO `order_recorddata_detail` VALUES ('178', '49', '210685', '0', '0', '2018-09-26 14:18:28');
INSERT INTO `order_recorddata_detail` VALUES ('179', '49', '210686', '0', '0', '2018-09-26 14:18:28');
INSERT INTO `order_recorddata_detail` VALUES ('180', '49', '210687', '0', '0', '2018-09-26 14:18:28');
INSERT INTO `order_recorddata_detail` VALUES ('181', '50', '210689', '0', '0', '2018-09-26 14:21:59');
INSERT INTO `order_recorddata_detail` VALUES ('182', '50', '210690', '38', '0', '2018-09-26 14:21:59');
INSERT INTO `order_recorddata_detail` VALUES ('183', '50', '210691', '0', '0', '2018-09-26 14:21:59');
INSERT INTO `order_recorddata_detail` VALUES ('184', '50', '210692', '-38', '0', '2018-09-26 14:21:59');
INSERT INTO `order_recorddata_detail` VALUES ('185', '51', '210689', '-64', '0', '2018-09-26 14:22:08');
INSERT INTO `order_recorddata_detail` VALUES ('186', '51', '210690', '192', '0', '2018-09-26 14:22:08');
INSERT INTO `order_recorddata_detail` VALUES ('187', '51', '210691', '-64', '0', '2018-09-26 14:22:08');
INSERT INTO `order_recorddata_detail` VALUES ('188', '51', '210692', '-64', '0', '2018-09-26 14:22:08');
INSERT INTO `order_recorddata_detail` VALUES ('189', '52', '210689', '0', '0', '2018-09-26 14:22:19');
INSERT INTO `order_recorddata_detail` VALUES ('190', '52', '210690', '0', '0', '2018-09-26 14:22:19');
INSERT INTO `order_recorddata_detail` VALUES ('191', '52', '210691', '0', '0', '2018-09-26 14:22:19');
INSERT INTO `order_recorddata_detail` VALUES ('192', '52', '210692', '0', '0', '2018-09-26 14:22:19');
INSERT INTO `order_recorddata_detail` VALUES ('193', '53', '210689', '0', '0', '2018-09-26 14:23:11');
INSERT INTO `order_recorddata_detail` VALUES ('194', '53', '210691', '32', '0', '2018-09-26 14:23:11');
INSERT INTO `order_recorddata_detail` VALUES ('195', '53', '210690', '0', '0', '2018-09-26 14:23:11');
INSERT INTO `order_recorddata_detail` VALUES ('196', '53', '210692', '-32', '0', '2018-09-26 14:23:11');
INSERT INTO `order_recorddata_detail` VALUES ('197', '54', '210689', '0', '0', '2018-09-26 14:23:18');
INSERT INTO `order_recorddata_detail` VALUES ('198', '54', '210691', '0', '0', '2018-09-26 14:23:18');
INSERT INTO `order_recorddata_detail` VALUES ('199', '54', '210690', '0', '0', '2018-09-26 14:23:18');
INSERT INTO `order_recorddata_detail` VALUES ('200', '54', '210692', '0', '0', '2018-09-26 14:23:18');
INSERT INTO `order_recorddata_detail` VALUES ('201', '55', '210690', '0', '0', '2018-09-26 14:23:56');
INSERT INTO `order_recorddata_detail` VALUES ('202', '55', '210689', '38', '0', '2018-09-26 14:23:56');
INSERT INTO `order_recorddata_detail` VALUES ('203', '55', '210692', '-38', '0', '2018-09-26 14:23:56');
INSERT INTO `order_recorddata_detail` VALUES ('204', '55', '210691', '0', '0', '2018-09-26 14:23:56');
INSERT INTO `order_recorddata_detail` VALUES ('205', '56', '210690', '0', '0', '2018-09-26 14:24:08');
INSERT INTO `order_recorddata_detail` VALUES ('206', '56', '210689', '36', '0', '2018-09-26 14:24:08');
INSERT INTO `order_recorddata_detail` VALUES ('207', '56', '210692', '-36', '0', '2018-09-26 14:24:08');
INSERT INTO `order_recorddata_detail` VALUES ('208', '56', '210691', '0', '0', '2018-09-26 14:24:08');
INSERT INTO `order_recorddata_detail` VALUES ('209', '57', '210697', '-38', '0', '2018-09-26 14:27:46');
INSERT INTO `order_recorddata_detail` VALUES ('210', '57', '210696', '38', '0', '2018-09-26 14:27:46');
INSERT INTO `order_recorddata_detail` VALUES ('211', '57', '210695', '0', '0', '2018-09-26 14:27:46');
INSERT INTO `order_recorddata_detail` VALUES ('212', '57', '210694', '0', '0', '2018-09-26 14:27:46');
INSERT INTO `order_recorddata_detail` VALUES ('213', '58', '210697', '-38', '0', '2018-09-26 14:28:10');
INSERT INTO `order_recorddata_detail` VALUES ('214', '58', '210696', '38', '0', '2018-09-26 14:28:10');
INSERT INTO `order_recorddata_detail` VALUES ('215', '58', '210695', '0', '0', '2018-09-26 14:28:10');
INSERT INTO `order_recorddata_detail` VALUES ('216', '58', '210694', '0', '0', '2018-09-26 14:28:10');
INSERT INTO `order_recorddata_detail` VALUES ('217', '59', '210697', '0', '0', '2018-09-26 14:28:54');
INSERT INTO `order_recorddata_detail` VALUES ('218', '59', '210695', '38', '0', '2018-09-26 14:28:54');
INSERT INTO `order_recorddata_detail` VALUES ('219', '59', '210696', '0', '0', '2018-09-26 14:28:54');
INSERT INTO `order_recorddata_detail` VALUES ('220', '59', '210694', '-38', '0', '2018-09-26 14:28:54');
INSERT INTO `order_recorddata_detail` VALUES ('221', '60', '210697', '0', '0', '2018-09-26 14:29:08');
INSERT INTO `order_recorddata_detail` VALUES ('222', '60', '210695', '36', '0', '2018-09-26 14:29:08');
INSERT INTO `order_recorddata_detail` VALUES ('223', '60', '210696', '-36', '0', '2018-09-26 14:29:08');
INSERT INTO `order_recorddata_detail` VALUES ('224', '60', '210694', '0', '0', '2018-09-26 14:29:08');
INSERT INTO `order_recorddata_detail` VALUES ('225', '61', '210697', '0', '0', '2018-09-26 14:29:30');
INSERT INTO `order_recorddata_detail` VALUES ('226', '61', '210695', '36', '0', '2018-09-26 14:29:30');
INSERT INTO `order_recorddata_detail` VALUES ('227', '61', '210696', '-36', '0', '2018-09-26 14:29:30');
INSERT INTO `order_recorddata_detail` VALUES ('228', '61', '210694', '0', '0', '2018-09-26 14:29:30');
INSERT INTO `order_recorddata_detail` VALUES ('229', '62', '210716', '-1', '0', '2018-09-26 15:01:27');
INSERT INTO `order_recorddata_detail` VALUES ('230', '62', '210713', '-1', '0', '2018-09-26 15:01:27');
INSERT INTO `order_recorddata_detail` VALUES ('231', '62', '210715', '4', '0', '2018-09-26 15:01:27');
INSERT INTO `order_recorddata_detail` VALUES ('232', '62', '210714', '-2', '0', '2018-09-26 15:01:27');
INSERT INTO `order_recorddata_detail` VALUES ('233', '63', '210717', '-25', '0', '2018-09-26 15:05:00');
INSERT INTO `order_recorddata_detail` VALUES ('234', '63', '210719', '-22', '0', '2018-09-26 15:05:00');
INSERT INTO `order_recorddata_detail` VALUES ('235', '63', '210718', '-39', '0', '2018-09-26 15:05:00');
INSERT INTO `order_recorddata_detail` VALUES ('236', '63', '210721', '39', '0', '2018-09-26 15:05:00');
INSERT INTO `order_recorddata_detail` VALUES ('237', '63', '210720', '47', '0', '2018-09-26 15:05:00');
INSERT INTO `order_recorddata_detail` VALUES ('238', '64', '210723', '19', '0', '2018-09-26 15:15:07');
INSERT INTO `order_recorddata_detail` VALUES ('239', '64', '210727', '-38', '0', '2018-09-26 15:15:07');
INSERT INTO `order_recorddata_detail` VALUES ('240', '64', '210724', '-35', '0', '2018-09-26 15:15:07');
INSERT INTO `order_recorddata_detail` VALUES ('241', '64', '210726', '23', '0', '2018-09-26 15:15:07');
INSERT INTO `order_recorddata_detail` VALUES ('242', '64', '210725', '31', '0', '2018-09-26 15:15:07');
INSERT INTO `order_recorddata_detail` VALUES ('243', '65', '210729', '2', '0', '2018-09-26 15:15:10');
INSERT INTO `order_recorddata_detail` VALUES ('244', '65', '210731', '-2', '0', '2018-09-26 15:15:10');
INSERT INTO `order_recorddata_detail` VALUES ('245', '65', '210730', '0', '0', '2018-09-26 15:15:10');
INSERT INTO `order_recorddata_detail` VALUES ('246', '65', '210728', '0', '0', '2018-09-26 15:15:10');
INSERT INTO `order_recorddata_detail` VALUES ('247', '66', '210731', '0', '0', '2018-09-26 15:20:47');
INSERT INTO `order_recorddata_detail` VALUES ('248', '66', '210729', '-2', '0', '2018-09-26 15:20:47');
INSERT INTO `order_recorddata_detail` VALUES ('249', '66', '210730', '0', '0', '2018-09-26 15:20:47');
INSERT INTO `order_recorddata_detail` VALUES ('250', '66', '210728', '2', '0', '2018-09-26 15:20:47');
INSERT INTO `order_recorddata_detail` VALUES ('251', '67', '210732', '-2', '0', '2018-09-26 15:27:35');
INSERT INTO `order_recorddata_detail` VALUES ('252', '67', '210733', '-1', '0', '2018-09-26 15:27:35');
INSERT INTO `order_recorddata_detail` VALUES ('253', '67', '210735', '4', '0', '2018-09-26 15:27:35');
INSERT INTO `order_recorddata_detail` VALUES ('254', '67', '210734', '-1', '0', '2018-09-26 15:27:35');
INSERT INTO `order_recorddata_detail` VALUES ('255', '68', '210739', '0', '0', '2018-09-26 15:32:32');
INSERT INTO `order_recorddata_detail` VALUES ('256', '68', '210740', '0', '0', '2018-09-26 15:32:32');
INSERT INTO `order_recorddata_detail` VALUES ('257', '68', '210738', '2', '0', '2018-09-26 15:32:32');
INSERT INTO `order_recorddata_detail` VALUES ('258', '68', '210737', '-2', '0', '2018-09-26 15:32:32');
INSERT INTO `order_recorddata_detail` VALUES ('259', '69', '210741', '19', '0', '2018-09-26 15:42:17');
INSERT INTO `order_recorddata_detail` VALUES ('260', '69', '210745', '-38', '0', '2018-09-26 15:42:17');
INSERT INTO `order_recorddata_detail` VALUES ('261', '69', '210742', '-35', '0', '2018-09-26 15:42:17');
INSERT INTO `order_recorddata_detail` VALUES ('262', '69', '210743', '23', '0', '2018-09-26 15:42:17');
INSERT INTO `order_recorddata_detail` VALUES ('263', '69', '210744', '31', '0', '2018-09-26 15:42:17');
INSERT INTO `order_recorddata_detail` VALUES ('264', '70', '210750', '20', '0', '2018-09-26 15:49:44');
INSERT INTO `order_recorddata_detail` VALUES ('265', '70', '210748', '-38', '0', '2018-09-26 15:49:44');
INSERT INTO `order_recorddata_detail` VALUES ('266', '70', '210749', '-36', '0', '2018-09-26 15:49:44');
INSERT INTO `order_recorddata_detail` VALUES ('267', '70', '210747', '23', '0', '2018-09-26 15:49:44');
INSERT INTO `order_recorddata_detail` VALUES ('268', '70', '210746', '31', '0', '2018-09-26 15:49:44');
INSERT INTO `order_recorddata_detail` VALUES ('269', '71', '210759', '74', '0', '2018-09-26 15:55:04');
INSERT INTO `order_recorddata_detail` VALUES ('270', '71', '210755', '-45', '0', '2018-09-26 15:55:04');
INSERT INTO `order_recorddata_detail` VALUES ('271', '71', '210758', '-46', '0', '2018-09-26 15:55:04');
INSERT INTO `order_recorddata_detail` VALUES ('272', '71', '210756', '41', '0', '2018-09-26 15:55:04');
INSERT INTO `order_recorddata_detail` VALUES ('273', '71', '210757', '-24', '0', '2018-09-26 15:55:04');
INSERT INTO `order_recorddata_detail` VALUES ('274', '72', '210777', '0', '0', '2018-09-26 16:44:14');
INSERT INTO `order_recorddata_detail` VALUES ('275', '72', '210779', '0', '0', '2018-09-26 16:44:14');
INSERT INTO `order_recorddata_detail` VALUES ('276', '72', '210780', '0', '0', '2018-09-26 16:44:14');
INSERT INTO `order_recorddata_detail` VALUES ('277', '72', '210778', '0', '0', '2018-09-26 16:44:14');
INSERT INTO `order_recorddata_detail` VALUES ('278', '73', '210779', '0', '0', '2018-09-26 16:49:40');
INSERT INTO `order_recorddata_detail` VALUES ('279', '73', '210778', '0', '0', '2018-09-26 16:49:40');
INSERT INTO `order_recorddata_detail` VALUES ('280', '73', '210780', '0', '0', '2018-09-26 16:49:40');
INSERT INTO `order_recorddata_detail` VALUES ('281', '73', '210777', '0', '0', '2018-09-26 16:49:40');
INSERT INTO `order_recorddata_detail` VALUES ('282', '74', '210784', '0', '0', '2018-09-26 16:52:56');
INSERT INTO `order_recorddata_detail` VALUES ('283', '74', '210783', '0', '0', '2018-09-26 16:52:56');
INSERT INTO `order_recorddata_detail` VALUES ('284', '74', '210782', '0', '0', '2018-09-26 16:52:56');
INSERT INTO `order_recorddata_detail` VALUES ('285', '74', '210781', '0', '0', '2018-09-26 16:52:56');
INSERT INTO `order_recorddata_detail` VALUES ('286', '75', '210787', '0', '0', '2018-09-26 16:55:35');
INSERT INTO `order_recorddata_detail` VALUES ('287', '75', '210785', '0', '0', '2018-09-26 16:55:35');
INSERT INTO `order_recorddata_detail` VALUES ('288', '75', '210788', '0', '0', '2018-09-26 16:55:35');
INSERT INTO `order_recorddata_detail` VALUES ('289', '75', '210786', '0', '0', '2018-09-26 16:55:35');
INSERT INTO `order_recorddata_detail` VALUES ('290', '76', '210791', '0', '0', '2018-09-26 17:00:48');
INSERT INTO `order_recorddata_detail` VALUES ('291', '76', '210792', '0', '0', '2018-09-26 17:00:48');
INSERT INTO `order_recorddata_detail` VALUES ('292', '76', '210789', '0', '0', '2018-09-26 17:00:48');
INSERT INTO `order_recorddata_detail` VALUES ('293', '76', '210790', '0', '0', '2018-09-26 17:00:48');
INSERT INTO `order_recorddata_detail` VALUES ('294', '77', '210795', '0', '0', '2018-09-26 17:04:03');
INSERT INTO `order_recorddata_detail` VALUES ('295', '77', '210794', '0', '0', '2018-09-26 17:04:03');
INSERT INTO `order_recorddata_detail` VALUES ('296', '77', '210793', '0', '0', '2018-09-26 17:04:03');
INSERT INTO `order_recorddata_detail` VALUES ('297', '77', '210796', '0', '0', '2018-09-26 17:04:03');
INSERT INTO `order_recorddata_detail` VALUES ('298', '78', '210795', '0', '0', '2018-09-26 17:05:33');
INSERT INTO `order_recorddata_detail` VALUES ('299', '78', '210796', '0', '0', '2018-09-26 17:05:33');
INSERT INTO `order_recorddata_detail` VALUES ('300', '78', '210794', '0', '0', '2018-09-26 17:05:33');
INSERT INTO `order_recorddata_detail` VALUES ('301', '78', '210793', '0', '0', '2018-09-26 17:05:33');
INSERT INTO `order_recorddata_detail` VALUES ('302', '79', '210800', '0', '0', '2018-09-26 17:09:29');
INSERT INTO `order_recorddata_detail` VALUES ('303', '79', '210797', '0', '0', '2018-09-26 17:09:29');
INSERT INTO `order_recorddata_detail` VALUES ('304', '79', '210798', '0', '0', '2018-09-26 17:09:29');
INSERT INTO `order_recorddata_detail` VALUES ('305', '79', '210799', '0', '0', '2018-09-26 17:09:29');
INSERT INTO `order_recorddata_detail` VALUES ('306', '80', '210799', '0', '0', '2018-09-26 17:20:59');
INSERT INTO `order_recorddata_detail` VALUES ('307', '80', '210800', '-2', '0', '2018-09-26 17:20:59');
INSERT INTO `order_recorddata_detail` VALUES ('308', '80', '210798', '0', '0', '2018-09-26 17:20:59');
INSERT INTO `order_recorddata_detail` VALUES ('309', '80', '210797', '2', '0', '2018-09-26 17:20:59');
INSERT INTO `order_recorddata_detail` VALUES ('310', '81', '210821', '0', '0', '2018-09-26 17:43:41');
INSERT INTO `order_recorddata_detail` VALUES ('311', '81', '210819', '0', '0', '2018-09-26 17:43:41');
INSERT INTO `order_recorddata_detail` VALUES ('312', '81', '210820', '0', '0', '2018-09-26 17:43:41');
INSERT INTO `order_recorddata_detail` VALUES ('313', '81', '210818', '0', '0', '2018-09-26 17:43:41');

-- ----------------------------
-- Table structure for order_recorddata_path
-- ----------------------------
DROP TABLE IF EXISTS `order_recorddata_path`;
CREATE TABLE `order_recorddata_path` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `recordid` int(11) DEFAULT NULL,
  `recpath` varchar(100) DEFAULT NULL COMMENT '游戏录像文件的路径',
  `mark` varchar(200) DEFAULT NULL COMMENT '本局结算的备注信息',
  `addtime` datetime DEFAULT NULL COMMENT '添加时间',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=81 DEFAULT CHARSET=utf8 COMMENT='保存录像文件字表';

-- ----------------------------
-- Records of order_recorddata_path
-- ----------------------------
INSERT INTO `order_recorddata_path` VALUES ('1', '2', '', null, '2018-09-22 17:34:31');
INSERT INTO `order_recorddata_path` VALUES ('2', '3', 'http://alioss.qileah.cn/gamerec/g/2018/9/22/100/0ad2bc4ebd7c4bcea0df6ee73a00ed92.rpl', null, '2018-09-22 18:02:32');
INSERT INTO `order_recorddata_path` VALUES ('3', '4', 'http://alioss.qileah.cn/gamerec/g/2018/9/22/100/a569ae527032419897f3098cd2b11bef.rpl', null, '2018-09-22 18:04:24');
INSERT INTO `order_recorddata_path` VALUES ('4', '5', 'http://alioss.qileah.cn/gamerec/g/2018/9/22/100/91a176cbaad24e438843a1c78e5d6291.rpl', null, '2018-09-22 18:23:53');
INSERT INTO `order_recorddata_path` VALUES ('5', '6', 'http://alioss.qileah.cn/gamerec/g/2018/9/22/100/bf5725bc02c6471586b2bf748ae20b5b.rpl', null, '2018-09-22 19:46:48');
INSERT INTO `order_recorddata_path` VALUES ('6', '7', 'http://alioss.qileah.cn/gamerec/g/2018/9/23/100/3162e6f02f4540cd962d1a88640cb7db.rpl', null, '2018-09-23 14:09:30');
INSERT INTO `order_recorddata_path` VALUES ('7', '8', 'http://alioss.qileah.cn/gamerec/g/2018/9/23/100/02a5261fc4a84a6fa7d9eccd1f961652.rpl', null, '2018-09-23 14:16:36');
INSERT INTO `order_recorddata_path` VALUES ('8', '9', 'http://alioss.qileah.cn/gamerec/g/2018/9/23/100/d0e17cbde28e4af894bb9b64412a281f.rpl', null, '2018-09-23 15:28:45');
INSERT INTO `order_recorddata_path` VALUES ('9', '10', 'http://alioss.qileah.cn/gamerec/g/2018/9/23/100/a194d084286d48f1bd470b57a09fe97b.rpl', null, '2018-09-23 15:30:07');
INSERT INTO `order_recorddata_path` VALUES ('10', '11', 'http://alioss.qileah.cn/gamerec/g/2018/9/23/100/bd42bee6826a4c9cba60ecc1e2fe5e23.rpl', null, '2018-09-23 15:32:03');
INSERT INTO `order_recorddata_path` VALUES ('11', '12', 'http://alioss.qileah.cn/gamerec/g/2018/9/23/100/ec86e121e5eb45e4b9968ec5cbb6b983.rpl', null, '2018-09-23 16:56:13');
INSERT INTO `order_recorddata_path` VALUES ('12', '13', 'http://alioss.qileah.cn/gamerec/g/2018/9/23/100/12ef5d1e77e74d9496554389e2176fe5.rpl', null, '2018-09-23 16:58:39');
INSERT INTO `order_recorddata_path` VALUES ('13', '14', 'http://alioss.qileah.cn/gamerec/g/2018/9/24/100/b86b1844baa54903b69abf884b3226cf.rpl', null, '2018-09-24 16:13:58');
INSERT INTO `order_recorddata_path` VALUES ('14', '15', 'http://alioss.qileah.cn/gamerec/g/2018/9/24/100/e212f83c269e42e38ca8e0774ea83ba5.rpl', null, '2018-09-24 16:19:16');
INSERT INTO `order_recorddata_path` VALUES ('15', '16', 'http://alioss.qileah.cn/gamerec/g/2018/9/24/100/d3c12e0bb9f7432db02a8d7add4fda76.rpl', null, '2018-09-24 16:23:28');
INSERT INTO `order_recorddata_path` VALUES ('16', '17', 'http://alioss.qileah.cn/gamerec/g/2018/9/24/100/449433b818e045e6b574e733bf9963f4.rpl', null, '2018-09-24 16:32:33');
INSERT INTO `order_recorddata_path` VALUES ('17', '18', 'http://alioss.qileah.cn/gamerec/g/2018/9/24/100/37d2febcf6b84ae6bcdfc696a362222a.rpl', null, '2018-09-24 16:38:45');
INSERT INTO `order_recorddata_path` VALUES ('18', '19', 'http://alioss.qileah.cn/gamerec/g/2018/9/24/100/7ff7ae9f3a604e33b9c58f83dee4b5c1.rpl', null, '2018-09-24 16:49:05');
INSERT INTO `order_recorddata_path` VALUES ('19', '20', 'http://alioss.qileah.cn/gamerec/g/2018/9/24/100/9ef2a298d00a43538c418224349e1922.rpl', null, '2018-09-24 16:49:18');
INSERT INTO `order_recorddata_path` VALUES ('20', '21', 'http://alioss.qileah.cn/gamerec/g/2018/9/24/100/87f85254e9604d7ca66bf1e8213ecf4c.rpl', null, '2018-09-24 16:53:24');
INSERT INTO `order_recorddata_path` VALUES ('21', '22', 'http://alioss.qileah.cn/gamerec/g/2018/9/24/100/fa78dd3b23984477b735b5c34f885926.rpl', null, '2018-09-24 16:57:39');
INSERT INTO `order_recorddata_path` VALUES ('22', '23', 'http://alioss.qileah.cn/gamerec/g/2018/9/24/100/239a321a14494967980900ee35ea3a24.rpl', null, '2018-09-24 16:57:55');
INSERT INTO `order_recorddata_path` VALUES ('23', '24', 'http://alioss.qileah.cn/gamerec/g/2018/9/24/100/d9144c5d898743928598d45a0535502d.rpl', null, '2018-09-24 17:00:17');
INSERT INTO `order_recorddata_path` VALUES ('24', '25', 'http://alioss.qileah.cn/gamerec/g/2018/9/24/100/4e3ea157c71348a9b9b6cdbba1c24253.rpl', null, '2018-09-24 17:20:04');
INSERT INTO `order_recorddata_path` VALUES ('25', '26', 'http://alioss.qileah.cn/gamerec/g/2018/9/24/100/ca5d8cace8b24ea0940d72692106dd3a.rpl', null, '2018-09-24 17:20:21');
INSERT INTO `order_recorddata_path` VALUES ('26', '27', 'http://alioss.qileah.cn/gamerec/g/2018/9/24/100/db1304c0f42a437caadd4d5acaade7ea.rpl', null, '2018-09-24 17:41:58');
INSERT INTO `order_recorddata_path` VALUES ('27', '28', 'http://alioss.qileah.cn/gamerec/g/2018/9/24/100/7baecaf7ac5c4350b1e07bab40e6edd9.rpl', null, '2018-09-24 19:26:55');
INSERT INTO `order_recorddata_path` VALUES ('28', '29', 'http://alioss.qileah.cn/gamerec/g/2018/9/26/100/725a9f2bd5044c2ab4428edafc86761d.rpl', null, '2018-09-26 09:34:47');
INSERT INTO `order_recorddata_path` VALUES ('29', '30', '', null, '2018-09-26 10:01:01');
INSERT INTO `order_recorddata_path` VALUES ('30', '31', '', null, '2018-09-26 10:11:16');
INSERT INTO `order_recorddata_path` VALUES ('31', '32', '', null, '2018-09-26 10:19:52');
INSERT INTO `order_recorddata_path` VALUES ('32', '33', 'http://alioss.qileah.cn/gamerec/g/2018/9/26/100/de8b714c219f443ca4fc06521bcf1020.rpl', null, '2018-09-26 11:50:14');
INSERT INTO `order_recorddata_path` VALUES ('33', '34', '', null, '2018-09-26 11:52:44');
INSERT INTO `order_recorddata_path` VALUES ('34', '35', '', null, '2018-09-26 11:56:10');
INSERT INTO `order_recorddata_path` VALUES ('35', '36', 'http://alioss.qileah.cn/gamerec/g/2018/9/26/100/94ec60a9fb0141379480b7b7815bd101.rpl', null, '2018-09-26 13:08:41');
INSERT INTO `order_recorddata_path` VALUES ('36', '37', 'http://alioss.qileah.cn/gamerec/g/2018/9/26/100/3cbbd1a2b0ba429ea068288c2fd0b5df.rpl', null, '2018-09-26 13:09:24');
INSERT INTO `order_recorddata_path` VALUES ('37', '38', 'http://alioss.qileah.cn/gamerec/g/2018/9/26/100/56adba3f7816487aa9cbc5695bd62561.rpl', null, '2018-09-26 13:12:25');
INSERT INTO `order_recorddata_path` VALUES ('38', '39', 'http://alioss.qileah.cn/gamerec/g/2018/9/26/100/b598093b4970417daf3dfb78f76d9c57.rpl', null, '2018-09-26 13:14:57');
INSERT INTO `order_recorddata_path` VALUES ('39', '40', 'http://alioss.qileah.cn/gamerec/g/2018/9/26/100/2ac1b781e98f4159b689220779012f67.rpl', null, '2018-09-26 13:15:15');
INSERT INTO `order_recorddata_path` VALUES ('40', '41', 'http://alioss.qileah.cn/gamerec/g/2018/9/26/100/637450f84d36460c854a45840f1f6a54.rpl', null, '2018-09-26 14:01:21');
INSERT INTO `order_recorddata_path` VALUES ('41', '42', 'http://alioss.qileah.cn/gamerec/g/2018/9/26/100/9c2ec979e1774295a19a091737c16c8c.rpl', null, '2018-09-26 14:07:06');
INSERT INTO `order_recorddata_path` VALUES ('42', '43', 'http://alioss.qileah.cn/gamerec/g/2018/9/26/100/b468ae103c6d41978bce5b999e5012eb.rpl', null, '2018-09-26 14:09:19');
INSERT INTO `order_recorddata_path` VALUES ('43', '44', 'http://alioss.qileah.cn/gamerec/g/2018/9/26/100/96f51764653544c88ee82365ca43a997.rpl', null, '2018-09-26 14:13:19');
INSERT INTO `order_recorddata_path` VALUES ('44', '45', 'http://alioss.qileah.cn/gamerec/g/2018/9/26/100/e4bbe566c58f4483a83acd534bc349b2.rpl', null, '2018-09-26 14:13:50');
INSERT INTO `order_recorddata_path` VALUES ('45', '46', 'http://alioss.qileah.cn/gamerec/g/2018/9/26/100/b6fe5dc638344ab4afade1e20a15c3a7.rpl', null, '2018-09-26 14:14:03');
INSERT INTO `order_recorddata_path` VALUES ('46', '47', 'http://alioss.qileah.cn/gamerec/g/2018/9/26/100/a7a4b8f93f154569b6452875347d06bc.rpl', null, '2018-09-26 14:17:33');
INSERT INTO `order_recorddata_path` VALUES ('47', '48', 'http://alioss.qileah.cn/gamerec/g/2018/9/26/100/847bdbb88e0c4be9923fa9d689bcd086.rpl', null, '2018-09-26 14:17:45');
INSERT INTO `order_recorddata_path` VALUES ('48', '49', 'http://alioss.qileah.cn/gamerec/g/2018/9/26/100/155c57194934456f8c7087745856f257.rpl', null, '2018-09-26 14:18:28');
INSERT INTO `order_recorddata_path` VALUES ('49', '50', 'http://alioss.qileah.cn/gamerec/g/2018/9/26/100/8e46eeee01e245fe9c93a456c879ec26.rpl', null, '2018-09-26 14:21:59');
INSERT INTO `order_recorddata_path` VALUES ('50', '51', 'http://alioss.qileah.cn/gamerec/g/2018/9/26/100/f629f4cb1d96475b967194fbf3bfeb83.rpl', null, '2018-09-26 14:22:08');
INSERT INTO `order_recorddata_path` VALUES ('51', '52', 'http://alioss.qileah.cn/gamerec/g/2018/9/26/100/34ad2dd53bfb433db0f87d6bb41c797f.rpl', null, '2018-09-26 14:22:19');
INSERT INTO `order_recorddata_path` VALUES ('52', '53', 'http://alioss.qileah.cn/gamerec/g/2018/9/26/100/08108ba12ea34b29b2ae7d17b4227414.rpl', null, '2018-09-26 14:23:11');
INSERT INTO `order_recorddata_path` VALUES ('53', '54', 'http://alioss.qileah.cn/gamerec/g/2018/9/26/100/a9bc3cff76314a2799d7ae8fd68e6d9d.rpl', null, '2018-09-26 14:23:18');
INSERT INTO `order_recorddata_path` VALUES ('54', '55', 'http://alioss.qileah.cn/gamerec/g/2018/9/26/100/d120e814cac6455fbff924000c111af5.rpl', null, '2018-09-26 14:23:56');
INSERT INTO `order_recorddata_path` VALUES ('55', '56', 'http://alioss.qileah.cn/gamerec/g/2018/9/26/100/1972dac314794b74a9314d71eaff4b7f.rpl', null, '2018-09-26 14:24:08');
INSERT INTO `order_recorddata_path` VALUES ('56', '57', 'http://alioss.qileah.cn/gamerec/g/2018/9/26/100/47a0f1ec77ef4e428cc408eb826d95b8.rpl', null, '2018-09-26 14:27:46');
INSERT INTO `order_recorddata_path` VALUES ('57', '58', '', null, '2018-09-26 14:28:10');
INSERT INTO `order_recorddata_path` VALUES ('58', '59', 'http://alioss.qileah.cn/gamerec/g/2018/9/26/100/593a059ef8c2461ba146376cffe853c6.rpl', null, '2018-09-26 14:28:54');
INSERT INTO `order_recorddata_path` VALUES ('59', '60', 'http://alioss.qileah.cn/gamerec/g/2018/9/26/100/b6949a37650d4c8996e2e8cb112ee959.rpl', null, '2018-09-26 14:29:08');
INSERT INTO `order_recorddata_path` VALUES ('60', '61', '', null, '2018-09-26 14:29:30');
INSERT INTO `order_recorddata_path` VALUES ('61', '62', 'http://alioss.qileah.cn/gamerec/g/2018/9/26/100/6c6ba75f9c2e49cb858e0215d4ae03f5.rpl', null, '2018-09-26 15:01:27');
INSERT INTO `order_recorddata_path` VALUES ('62', '63', '', null, '2018-09-26 15:05:00');
INSERT INTO `order_recorddata_path` VALUES ('63', '64', '', null, '2018-09-26 15:15:07');
INSERT INTO `order_recorddata_path` VALUES ('64', '65', 'http://alioss.qileah.cn/gamerec/g/2018/9/26/100/f53851e0290a409dbf0ece1c3bdcb0f9.rpl', null, '2018-09-26 15:15:10');
INSERT INTO `order_recorddata_path` VALUES ('65', '66', 'http://alioss.qileah.cn/gamerec/g/2018/9/26/100/cc945cbcca2f4ba4b2eb3c0c387533ea.rpl', null, '2018-09-26 15:20:47');
INSERT INTO `order_recorddata_path` VALUES ('66', '67', 'http://alioss.qileah.cn/gamerec/g/2018/9/26/100/f3b6d880634846828c433fa910d7c392.rpl', null, '2018-09-26 15:27:35');
INSERT INTO `order_recorddata_path` VALUES ('67', '68', 'http://alioss.qileah.cn/gamerec/g/2018/9/26/100/6f905131a7194755add47aaea3c2a3a7.rpl', null, '2018-09-26 15:32:32');
INSERT INTO `order_recorddata_path` VALUES ('68', '69', '', null, '2018-09-26 15:42:17');
INSERT INTO `order_recorddata_path` VALUES ('69', '70', '', null, '2018-09-26 15:49:44');
INSERT INTO `order_recorddata_path` VALUES ('70', '71', '', null, '2018-09-26 15:55:04');
INSERT INTO `order_recorddata_path` VALUES ('71', '72', 'http://alioss.qileah.cn/gamerec/g/2018/9/26/100/a2786fcd9d8a412b8e2d86784c2c0621.rpl', null, '2018-09-26 16:44:14');
INSERT INTO `order_recorddata_path` VALUES ('72', '73', 'http://alioss.qileah.cn/gamerec/g/2018/9/26/100/abee28b1cedb41c59d41bae40ed620f1.rpl', null, '2018-09-26 16:49:40');
INSERT INTO `order_recorddata_path` VALUES ('73', '74', 'http://alioss.qileah.cn/gamerec/g/2018/9/26/100/50fbb4d395004ae2b6ddcf9ee1336efc.rpl', null, '2018-09-26 16:52:56');
INSERT INTO `order_recorddata_path` VALUES ('74', '75', 'http://alioss.qileah.cn/gamerec/g/2018/9/26/100/4292c1026b1b45a2a7771101ff9fd289.rpl', null, '2018-09-26 16:55:35');
INSERT INTO `order_recorddata_path` VALUES ('75', '76', 'http://alioss.qileah.cn/gamerec/g/2018/9/26/100/1ecb878f8c6943868f0d2e277a29a84f.rpl', null, '2018-09-26 17:00:48');
INSERT INTO `order_recorddata_path` VALUES ('76', '77', 'http://alioss.qileah.cn/gamerec/g/2018/9/26/100/8cdf40a92fb74e6b93383168caaed0ce.rpl', null, '2018-09-26 17:04:03');
INSERT INTO `order_recorddata_path` VALUES ('77', '78', 'http://alioss.qileah.cn/gamerec/g/2018/9/26/100/2f554b071a7d47e9a07e99ca80f2a71e.rpl', null, '2018-09-26 17:05:33');
INSERT INTO `order_recorddata_path` VALUES ('78', '79', 'http://alioss.qileah.cn/gamerec/g/2018/9/26/100/12be2179d2514bf8a6604a88872aeee9.rpl', null, '2018-09-26 17:09:29');
INSERT INTO `order_recorddata_path` VALUES ('79', '80', 'http://alioss.qileah.cn/gamerec/g/2018/9/26/100/0b28766ced5d480fa18207a713694f38.rpl', null, '2018-09-26 17:20:59');
INSERT INTO `order_recorddata_path` VALUES ('80', '81', 'http://alioss.qileah.cn/gamerec/g/2018/9/26/100/10fe66862cda4ed5bbbc249bfecb9cba.rpl', null, '2018-09-26 17:43:41');

-- ----------------------------
-- Table structure for order_settlement
-- ----------------------------
DROP TABLE IF EXISTS `order_settlement`;
CREATE TABLE `order_settlement` (
  `setid` int(11) NOT NULL,
  `roomid` int(11) DEFAULT NULL COMMENT '本局游戏所属的场地Id',
  `gameid` int(11) DEFAULT NULL COMMENT '本局游戏所属的游戏Id',
  `RoomCostType` int(11) DEFAULT NULL COMMENT '房费的结算类型，1AA付费、2房主付费、3圈主付费',
  `RoomCost` int(11) DEFAULT NULL COMMENT '结算房费的多少、这个房费的多少是按照参与游戏的人数收费的',
  `ownerid` int(11) DEFAULT NULL COMMENT '房主信息，可能为空',
  `groupid` int(11) DEFAULT NULL COMMENT '亲友圈圈Id',
  `RoomCostMoneyType` int(11) DEFAULT NULL COMMENT '结算房费使用的道具类型 0无1RMB2钻石3金币',
  `mark` varchar(1000) DEFAULT NULL COMMENT '本局结算的备注信息',
  `MoneyType` int(11) DEFAULT NULL COMMENT '玩家结算的道具类型',
  `FeeUserCount` int(11) DEFAULT NULL COMMENT '参与游戏的人数',
  `addtime` datetime DEFAULT NULL COMMENT '添加时间',
  `gamenum` int(11) DEFAULT '0' COMMENT '局数',
  `tableid` int(11) DEFAULT '0' COMMENT '分享桌号',
  PRIMARY KEY (`setid`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='玩家结算主表';

-- ----------------------------
-- Records of order_settlement
-- ----------------------------
INSERT INTO `order_settlement` VALUES ('2', '3', '100', '0', '0', '210006', '0', '0', '强退扣费', '4', '1', '2018-09-22 16:39:00', '0', '218513');
INSERT INTO `order_settlement` VALUES ('3', '3', '100', '0', '0', '0', '0', '0', '强退扣费', '4', '1', '2018-09-22 17:30:06', '0', '831809');
INSERT INTO `order_settlement` VALUES ('4', '1', '51', '1', '1', '210052', '0', '2', '打10局,AA制,', '0', '5', '2018-09-22 17:34:39', '1', '350485');
INSERT INTO `order_settlement` VALUES ('5', '1', '51', '1', '1', '210067', '0', '2', '打10局,AA制,', '0', '5', '2018-09-22 17:40:53', '1', '811498');
INSERT INTO `order_settlement` VALUES ('6', '3', '100', '0', '0', '210077', '0', '2', '霍邱麻将记分场结算', '0', '4', '2018-09-22 18:02:32', '0', '194492');
INSERT INTO `order_settlement` VALUES ('7', '3', '100', '0', '0', '210077', '0', '2', '霍邱麻将记分场结算', '0', '4', '2018-09-22 18:04:24', '0', '194492');
INSERT INTO `order_settlement` VALUES ('8', '3', '100', '0', '0', '210083', '0', '2', '霍邱麻将记分场结算', '0', '4', '2018-09-22 18:23:53', '0', '115889');
INSERT INTO `order_settlement` VALUES ('9', '3', '100', '0', '0', '210098', '0', '2', '霍邱麻将记分场结算', '0', '4', '2018-09-22 19:46:48', '0', '443940');
INSERT INTO `order_settlement` VALUES ('10', '3', '100', '0', '0', '210135', '0', '2', '霍邱麻将记分场结算', '0', '4', '2018-09-23 14:09:30', '0', '295464');
INSERT INTO `order_settlement` VALUES ('11', '3', '100', '0', '0', '210139', '0', '2', '霍邱麻将记分场结算', '0', '4', '2018-09-23 14:16:36', '0', '839344');
INSERT INTO `order_settlement` VALUES ('12', '3', '100', '0', '0', '210159', '0', '2', '霍邱麻将记分场结算', '0', '4', '2018-09-23 15:28:45', '0', '102408');
INSERT INTO `order_settlement` VALUES ('13', '3', '100', '0', '0', '210159', '0', '2', '霍邱麻将记分场结算', '0', '4', '2018-09-23 15:30:07', '0', '870990');
INSERT INTO `order_settlement` VALUES ('14', '3', '100', '0', '0', '210159', '0', '2', '霍邱麻将记分场结算', '0', '4', '2018-09-23 15:32:03', '0', '714544');
INSERT INTO `order_settlement` VALUES ('15', '3', '100', '0', '0', '210222', '0', '2', '霍邱麻将记分场结算', '0', '4', '2018-09-23 16:56:13', '0', '780410');
INSERT INTO `order_settlement` VALUES ('16', '3', '100', '0', '0', '210226', '0', '2', '霍邱麻将记分场结算', '0', '4', '2018-09-23 16:58:39', '0', '758551');
INSERT INTO `order_settlement` VALUES ('17', '3', '100', '0', '0', '210254', '0', '2', '霍邱麻将记分场结算', '0', '4', '2018-09-24 16:49:18', '2', '366221');
INSERT INTO `order_settlement` VALUES ('18', '3', '100', '0', '0', '210262', '0', '2', '霍邱麻将记分场结算', '0', '4', '2018-09-24 16:57:55', '2', '466880');
INSERT INTO `order_settlement` VALUES ('19', '3', '100', '0', '0', '210266', '0', '2', '霍邱麻将记分场结算', '0', '4', '2018-09-24 17:17:51', '2', '344431');
INSERT INTO `order_settlement` VALUES ('20', '3', '100', '0', '0', '210266', '0', '2', '霍邱麻将记分场结算', '0', '4', '2018-09-24 17:20:21', '2', '667742');
INSERT INTO `order_settlement` VALUES ('21', '3', '100', '0', '0', '210266', '0', '0', '强退扣费', '4', '1', '2018-09-24 17:25:12', '0', '387571');
INSERT INTO `order_settlement` VALUES ('22', '3', '100', '0', '0', '210266', '0', '2', '霍邱麻将记分场结算', '0', '4', '2018-09-24 17:41:58', '1', '753456');
INSERT INTO `order_settlement` VALUES ('23', '3', '100', '0', '0', '210266', '0', '0', '强退扣费', '4', '1', '2018-09-24 17:42:16', '0', '702292');
INSERT INTO `order_settlement` VALUES ('24', '3', '100', '0', '0', '210266', '0', '0', '强退扣费', '4', '1', '2018-09-24 17:45:24', '0', '220748');
INSERT INTO `order_settlement` VALUES ('25', '3', '100', '0', '0', '210266', '0', '0', '强退扣费', '4', '1', '2018-09-24 17:46:42', '0', '673089');
INSERT INTO `order_settlement` VALUES ('26', '3', '100', '0', '0', '210266', '0', '0', '强退扣费', '4', '1', '2018-09-24 17:52:00', '0', '875529');
INSERT INTO `order_settlement` VALUES ('27', '3', '100', '0', '0', '210266', '0', '0', '强退扣费', '4', '1', '2018-09-24 17:53:57', '0', '751151');
INSERT INTO `order_settlement` VALUES ('28', '3', '100', '0', '0', '210276', '0', '0', '强退扣费', '4', '1', '2018-09-24 18:12:44', '0', '955689');
INSERT INTO `order_settlement` VALUES ('29', '3', '100', '0', '0', '210278', '0', '0', '强退扣费', '4', '1', '2018-09-24 18:17:58', '0', '464364');
INSERT INTO `order_settlement` VALUES ('30', '3', '100', '0', '0', '210278', '0', '0', '强退扣费', '4', '1', '2018-09-24 18:21:05', '0', '464364');
INSERT INTO `order_settlement` VALUES ('31', '3', '100', '0', '0', '210278', '0', '0', '强退扣费', '4', '1', '2018-09-24 18:26:39', '0', '464364');
INSERT INTO `order_settlement` VALUES ('32', '3', '100', '0', '0', '210282', '0', '0', '强退扣费', '4', '1', '2018-09-24 18:36:23', '0', '251879');
INSERT INTO `order_settlement` VALUES ('33', '3', '100', '0', '0', '210282', '0', '0', '强退扣费', '4', '1', '2018-09-24 18:36:31', '0', '251879');
INSERT INTO `order_settlement` VALUES ('34', '3', '100', '0', '0', '210290', '0', '0', '强退扣费', '4', '1', '2018-09-24 18:40:44', '0', '274153');
INSERT INTO `order_settlement` VALUES ('35', '3', '100', '0', '0', '210294', '0', '0', '强退扣费', '4', '1', '2018-09-24 19:14:56', '0', '747345');
INSERT INTO `order_settlement` VALUES ('36', '3', '100', '0', '0', '210300', '0', '0', '强退扣费', '4', '1', '2018-09-24 19:20:27', '0', '442175');
INSERT INTO `order_settlement` VALUES ('37', '3', '100', '0', '0', '210304', '0', '0', '强退扣费', '4', '1', '2018-09-24 19:22:34', '0', '748666');
INSERT INTO `order_settlement` VALUES ('38', '3', '100', '0', '0', '210308', '0', '2', '霍邱麻将记分场结算', '0', '4', '2018-09-24 19:26:55', '1', '665317');
INSERT INTO `order_settlement` VALUES ('39', '3', '100', '0', '0', '210316', '0', '0', '强退扣费', '4', '1', '2018-09-24 19:39:20', '0', '756941');
INSERT INTO `order_settlement` VALUES ('40', '3', '100', '0', '0', '210316', '0', '0', '强退扣费', '4', '1', '2018-09-24 19:41:39', '0', '756941');
INSERT INTO `order_settlement` VALUES ('41', '3', '100', '0', '0', '210316', '0', '0', '强退扣费', '4', '1', '2018-09-24 19:43:44', '0', '756941');
INSERT INTO `order_settlement` VALUES ('42', '3', '100', '0', '0', '210316', '0', '0', '强退扣费', '4', '1', '2018-09-24 19:44:02', '0', '756941');
INSERT INTO `order_settlement` VALUES ('43', '3', '100', '0', '0', '210327', '0', '0', '强退扣费', '4', '1', '2018-09-24 20:19:12', '0', '145479');
INSERT INTO `order_settlement` VALUES ('44', '3', '100', '0', '0', '210364', '0', '0', '强退扣费', '4', '1', '2018-09-25 11:21:34', '0', '406792');
INSERT INTO `order_settlement` VALUES ('45', '3', '100', '0', '0', '210368', '0', '0', '强退扣费', '4', '1', '2018-09-25 11:31:19', '0', '724904');
INSERT INTO `order_settlement` VALUES ('46', '3', '100', '0', '0', '210376', '0', '0', '强退扣费', '4', '1', '2018-09-25 11:37:01', '0', '103881');
INSERT INTO `order_settlement` VALUES ('47', '3', '100', '0', '0', '210418', '0', '0', '强退扣费', '4', '1', '2018-09-25 13:57:44', '0', '210287');
INSERT INTO `order_settlement` VALUES ('48', '3', '100', '0', '0', '210434', '0', '0', '强退扣费', '4', '1', '2018-09-25 14:19:14', '0', '332471');
INSERT INTO `order_settlement` VALUES ('49', '3', '100', '0', '0', '210446', '0', '0', '强退扣费', '4', '1', '2018-09-25 14:36:43', '0', '684532');
INSERT INTO `order_settlement` VALUES ('50', '3', '100', '0', '0', '210450', '0', '0', '强退扣费', '4', '1', '2018-09-25 14:49:38', '0', '826097');
INSERT INTO `order_settlement` VALUES ('51', '3', '100', '0', '0', '210455', '0', '0', '强退扣费', '4', '1', '2018-09-25 14:57:32', '0', '379059');
INSERT INTO `order_settlement` VALUES ('52', '3', '100', '0', '0', '210516', '0', '0', '强退扣费', '4', '1', '2018-09-25 16:13:42', '0', '636138');
INSERT INTO `order_settlement` VALUES ('53', '3', '100', '0', '0', '210624', '0', '0', '强退扣费', '4', '1', '2018-09-25 19:38:25', '0', '878217');
INSERT INTO `order_settlement` VALUES ('54', '3', '100', '0', '0', '210625', '0', '0', '强退扣费', '4', '1', '2018-09-25 19:40:41', '0', '185766');
INSERT INTO `order_settlement` VALUES ('55', '3', '100', '0', '0', '210625', '0', '0', '强退扣费', '4', '1', '2018-09-25 19:41:27', '0', '518075');
INSERT INTO `order_settlement` VALUES ('56', '3', '100', '0', '0', '210626', '0', '0', '强退扣费', '4', '1', '2018-09-25 19:44:40', '0', '326354');
INSERT INTO `order_settlement` VALUES ('57', '3', '100', '0', '0', '210626', '0', '0', '强退扣费', '4', '1', '2018-09-25 19:46:30', '0', '297496');
INSERT INTO `order_settlement` VALUES ('58', '3', '100', '0', '0', '210626', '0', '0', '强退扣费', '4', '1', '2018-09-25 19:50:33', '0', '346809');
INSERT INTO `order_settlement` VALUES ('59', '3', '100', '1', '0', '210634', '0', '2', '霍邱麻将记分场结算', '0', '4', '2018-09-26 09:34:47', '1', '496550');
INSERT INTO `order_settlement` VALUES ('60', '3', '100', '0', '0', '210634', '0', '0', '强退扣费', '4', '1', '2018-09-26 09:37:47', '0', '929614');
INSERT INTO `order_settlement` VALUES ('61', '1', '51', '1', '1', '210638', '0', '2', '打10局,AA制,', '0', '5', '2018-09-26 10:01:03', '1', '753565');
INSERT INTO `order_settlement` VALUES ('62', '3', '100', '0', '0', '210645', '0', '0', '强退扣费', '4', '1', '2018-09-26 10:20:53', '0', '425411');
INSERT INTO `order_settlement` VALUES ('63', '3', '100', '0', '0', '210653', '0', '0', '强退扣费', '4', '1', '2018-09-26 11:08:35', '0', '562661');
INSERT INTO `order_settlement` VALUES ('64', '3', '100', '1', '2', '210685', '0', '2', '霍邱麻将记分场结算', '0', '4', '2018-09-26 14:09:27', '2', '933905');
INSERT INTO `order_settlement` VALUES ('65', '3', '100', '0', '0', '210685', '0', '0', '强退扣费', '4', '1', '2018-09-26 14:10:25', '0', '206119');
INSERT INTO `order_settlement` VALUES ('66', '3', '100', '2', '12', '210685', '0', '2', '霍邱麻将记分场结算', '0', '4', '2018-09-26 14:14:03', '3', '206119');
INSERT INTO `order_settlement` VALUES ('67', '3', '100', '2', '12', '210685', '0', '2', '霍邱麻将记分场结算', '0', '4', '2018-09-26 14:18:45', '3', '671354');
INSERT INTO `order_settlement` VALUES ('68', '3', '100', '0', '0', '210692', '0', '0', '强退扣费', '4', '1', '2018-09-26 14:21:42', '0', '195783');
INSERT INTO `order_settlement` VALUES ('69', '3', '100', '2', '3', '210692', '0', '2', '霍邱麻将记分场结算', '0', '4', '2018-09-26 14:22:19', '3', '195783');
INSERT INTO `order_settlement` VALUES ('70', '3', '100', '1', '2', '210692', '0', '2', '霍邱麻将记分场结算', '0', '4', '2018-09-26 14:23:18', '2', '764319');
INSERT INTO `order_settlement` VALUES ('71', '3', '100', '1', '1', '210694', '0', '2', '霍邱麻将记分场结算', '0', '4', '2018-09-26 14:28:10', '1', '781756');
INSERT INTO `order_settlement` VALUES ('72', '3', '100', '1', '2', '210694', '0', '2', '霍邱麻将记分场结算', '0', '4', '2018-09-26 14:29:30', '2', '293750');
INSERT INTO `order_settlement` VALUES ('73', '3', '100', '0', '0', '0', '0', '0', '强退扣费', '4', '1', '2018-09-26 14:58:46', '0', '845810');
INSERT INTO `order_settlement` VALUES ('74', '3', '100', '0', '0', '210713', '0', '0', '强退扣费', '4', '1', '2018-09-26 14:58:56', '0', '487913');
INSERT INTO `order_settlement` VALUES ('75', '3', '100', '1', '1', '210713', '0', '2', '霍邱麻将记分场结算', '0', '4', '2018-09-26 15:01:27', '1', '704827');
INSERT INTO `order_settlement` VALUES ('76', '3', '100', '0', '0', '210712', '0', '0', '强退扣费', '4', '1', '2018-09-26 15:08:33', '0', '437985');
INSERT INTO `order_settlement` VALUES ('77', '3', '100', '1', '1', '210728', '0', '2', '霍邱麻将记分场结算', '0', '4', '2018-09-26 15:15:10', '1', '339882');
INSERT INTO `order_settlement` VALUES ('78', '3', '100', '1', '1', '210728', '0', '2', '霍邱麻将记分场结算', '0', '4', '2018-09-26 15:20:47', '1', '599663');
INSERT INTO `order_settlement` VALUES ('79', '3', '100', '0', '0', '210712', '0', '0', '强退扣费', '4', '1', '2018-09-26 15:58:31', '0', '139216');
INSERT INTO `order_settlement` VALUES ('80', '3', '100', '0', '0', '210712', '0', '0', '强退扣费', '4', '1', '2018-09-26 16:04:37', '0', '666093');
INSERT INTO `order_settlement` VALUES ('81', '3', '100', '0', '0', '210712', '0', '0', '强退扣费', '4', '1', '2018-09-26 16:19:04', '0', '745592');
INSERT INTO `order_settlement` VALUES ('82', '3', '100', '1', '1', '210777', '0', '2', '霍邱麻将记分场结算', '0', '4', '2018-09-26 16:44:14', '1', '108629');
INSERT INTO `order_settlement` VALUES ('83', '3', '100', '1', '1', '210777', '0', '2', '霍邱麻将记分场结算', '0', '4', '2018-09-26 16:49:40', '1', '461795');
INSERT INTO `order_settlement` VALUES ('84', '3', '100', '1', '1', '210781', '0', '2', '霍邱麻将记分场结算', '0', '4', '2018-09-26 16:52:55', '1', '763830');
INSERT INTO `order_settlement` VALUES ('85', '3', '100', '1', '1', '210785', '0', '2', '霍邱麻将记分场结算', '0', '4', '2018-09-26 16:55:35', '1', '542871');
INSERT INTO `order_settlement` VALUES ('86', '3', '100', '1', '1', '210789', '0', '2', '霍邱麻将记分场结算', '0', '4', '2018-09-26 17:00:48', '1', '653059');
INSERT INTO `order_settlement` VALUES ('87', '3', '100', '1', '1', '210793', '0', '2', '霍邱麻将记分场结算', '0', '4', '2018-09-26 17:04:03', '1', '188206');
INSERT INTO `order_settlement` VALUES ('88', '3', '100', '1', '1', '210793', '0', '2', '霍邱麻将记分场结算', '0', '4', '2018-09-26 17:05:33', '1', '859122');
INSERT INTO `order_settlement` VALUES ('89', '3', '100', '0', '0', '210800', '0', '0', '强退扣费', '4', '1', '2018-09-26 17:09:06', '0', '768183');
INSERT INTO `order_settlement` VALUES ('90', '3', '100', '1', '1', '210800', '0', '2', '霍邱麻将记分场结算', '0', '4', '2018-09-26 17:09:29', '1', '768183');
INSERT INTO `order_settlement` VALUES ('91', '3', '100', '0', '0', '210801', '0', '0', '强退扣费', '4', '1', '2018-09-26 17:27:53', '0', '169660');
INSERT INTO `order_settlement` VALUES ('92', '3', '100', '1', '1', '210818', '0', '2', '霍邱麻将记分场结算', '0', '4', '2018-09-26 17:43:41', '1', '314537');

-- ----------------------------
-- Table structure for order_settlement_detail
-- ----------------------------
DROP TABLE IF EXISTS `order_settlement_detail`;
CREATE TABLE `order_settlement_detail` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `setid` int(11) NOT NULL,
  `userid` int(11) DEFAULT NULL COMMENT '结算的玩家Id',
  `moneynum` int(11) DEFAULT NULL COMMENT '结算输赢数量',
  `addtime` datetime DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=206 DEFAULT CHARSET=utf8 COMMENT='玩家结算子表';

-- ----------------------------
-- Records of order_settlement_detail
-- ----------------------------
INSERT INTO `order_settlement_detail` VALUES ('1', '2', '210007', '-1000', '2018-09-22 16:39:00');
INSERT INTO `order_settlement_detail` VALUES ('2', '3', '210061', '-1000', '2018-09-22 17:30:06');
INSERT INTO `order_settlement_detail` VALUES ('3', '4', '210052', '0', '2018-09-22 17:34:39');
INSERT INTO `order_settlement_detail` VALUES ('4', '4', '210065', '0', '2018-09-22 17:34:39');
INSERT INTO `order_settlement_detail` VALUES ('5', '5', '210068', '0', '2018-09-22 17:40:53');
INSERT INTO `order_settlement_detail` VALUES ('6', '5', '210067', '0', '2018-09-22 17:40:53');
INSERT INTO `order_settlement_detail` VALUES ('7', '6', '210078', '0', '2018-09-22 18:02:32');
INSERT INTO `order_settlement_detail` VALUES ('8', '6', '210079', '0', '2018-09-22 18:02:32');
INSERT INTO `order_settlement_detail` VALUES ('9', '6', '210077', '0', '2018-09-22 18:02:32');
INSERT INTO `order_settlement_detail` VALUES ('10', '6', '210080', '0', '2018-09-22 18:02:32');
INSERT INTO `order_settlement_detail` VALUES ('11', '7', '210078', '0', '2018-09-22 18:04:24');
INSERT INTO `order_settlement_detail` VALUES ('12', '7', '210079', '0', '2018-09-22 18:04:24');
INSERT INTO `order_settlement_detail` VALUES ('13', '7', '210077', '0', '2018-09-22 18:04:24');
INSERT INTO `order_settlement_detail` VALUES ('14', '7', '210080', '0', '2018-09-22 18:04:24');
INSERT INTO `order_settlement_detail` VALUES ('15', '8', '210086', '0', '2018-09-22 18:23:53');
INSERT INTO `order_settlement_detail` VALUES ('16', '8', '210084', '0', '2018-09-22 18:23:53');
INSERT INTO `order_settlement_detail` VALUES ('17', '8', '210085', '0', '2018-09-22 18:23:53');
INSERT INTO `order_settlement_detail` VALUES ('18', '8', '210083', '0', '2018-09-22 18:23:53');
INSERT INTO `order_settlement_detail` VALUES ('19', '9', '210098', '0', '2018-09-22 19:46:48');
INSERT INTO `order_settlement_detail` VALUES ('20', '9', '210100', '0', '2018-09-22 19:46:48');
INSERT INTO `order_settlement_detail` VALUES ('21', '9', '210097', '0', '2018-09-22 19:46:48');
INSERT INTO `order_settlement_detail` VALUES ('22', '9', '210099', '0', '2018-09-22 19:46:48');
INSERT INTO `order_settlement_detail` VALUES ('23', '10', '210135', '0', '2018-09-23 14:09:30');
INSERT INTO `order_settlement_detail` VALUES ('24', '10', '210137', '0', '2018-09-23 14:09:30');
INSERT INTO `order_settlement_detail` VALUES ('25', '10', '210136', '0', '2018-09-23 14:09:30');
INSERT INTO `order_settlement_detail` VALUES ('26', '10', '210138', '0', '2018-09-23 14:09:30');
INSERT INTO `order_settlement_detail` VALUES ('27', '11', '210140', '0', '2018-09-23 14:16:36');
INSERT INTO `order_settlement_detail` VALUES ('28', '11', '210139', '0', '2018-09-23 14:16:36');
INSERT INTO `order_settlement_detail` VALUES ('29', '11', '210141', '0', '2018-09-23 14:16:36');
INSERT INTO `order_settlement_detail` VALUES ('30', '11', '210142', '0', '2018-09-23 14:16:36');
INSERT INTO `order_settlement_detail` VALUES ('31', '12', '210162', '0', '2018-09-23 15:28:45');
INSERT INTO `order_settlement_detail` VALUES ('32', '12', '210161', '0', '2018-09-23 15:28:45');
INSERT INTO `order_settlement_detail` VALUES ('33', '12', '210159', '0', '2018-09-23 15:28:45');
INSERT INTO `order_settlement_detail` VALUES ('34', '12', '210160', '0', '2018-09-23 15:28:45');
INSERT INTO `order_settlement_detail` VALUES ('35', '13', '210159', '0', '2018-09-23 15:30:07');
INSERT INTO `order_settlement_detail` VALUES ('36', '13', '210160', '0', '2018-09-23 15:30:07');
INSERT INTO `order_settlement_detail` VALUES ('37', '13', '210162', '0', '2018-09-23 15:30:07');
INSERT INTO `order_settlement_detail` VALUES ('38', '13', '210161', '0', '2018-09-23 15:30:07');
INSERT INTO `order_settlement_detail` VALUES ('39', '14', '210162', '0', '2018-09-23 15:32:03');
INSERT INTO `order_settlement_detail` VALUES ('40', '14', '210159', '0', '2018-09-23 15:32:03');
INSERT INTO `order_settlement_detail` VALUES ('41', '14', '210160', '0', '2018-09-23 15:32:03');
INSERT INTO `order_settlement_detail` VALUES ('42', '14', '210161', '0', '2018-09-23 15:32:03');
INSERT INTO `order_settlement_detail` VALUES ('43', '15', '210222', '0', '2018-09-23 16:56:13');
INSERT INTO `order_settlement_detail` VALUES ('44', '15', '210224', '0', '2018-09-23 16:56:13');
INSERT INTO `order_settlement_detail` VALUES ('45', '15', '210223', '0', '2018-09-23 16:56:13');
INSERT INTO `order_settlement_detail` VALUES ('46', '15', '210225', '0', '2018-09-23 16:56:13');
INSERT INTO `order_settlement_detail` VALUES ('47', '16', '210228', '0', '2018-09-23 16:58:39');
INSERT INTO `order_settlement_detail` VALUES ('48', '16', '210227', '0', '2018-09-23 16:58:39');
INSERT INTO `order_settlement_detail` VALUES ('49', '16', '210226', '0', '2018-09-23 16:58:39');
INSERT INTO `order_settlement_detail` VALUES ('50', '16', '210229', '0', '2018-09-23 16:58:39');
INSERT INTO `order_settlement_detail` VALUES ('51', '17', '210253', '0', '2018-09-24 16:49:18');
INSERT INTO `order_settlement_detail` VALUES ('52', '17', '210249', '0', '2018-09-24 16:49:18');
INSERT INTO `order_settlement_detail` VALUES ('53', '17', '210255', '0', '2018-09-24 16:49:18');
INSERT INTO `order_settlement_detail` VALUES ('54', '17', '210254', '0', '2018-09-24 16:49:18');
INSERT INTO `order_settlement_detail` VALUES ('55', '18', '210264', '0', '2018-09-24 16:57:55');
INSERT INTO `order_settlement_detail` VALUES ('56', '18', '210261', '0', '2018-09-24 16:57:55');
INSERT INTO `order_settlement_detail` VALUES ('57', '18', '210263', '0', '2018-09-24 16:57:55');
INSERT INTO `order_settlement_detail` VALUES ('58', '18', '210262', '0', '2018-09-24 16:57:55');
INSERT INTO `order_settlement_detail` VALUES ('59', '19', '210265', '0', '2018-09-24 17:17:51');
INSERT INTO `order_settlement_detail` VALUES ('60', '19', '210266', '0', '2018-09-24 17:17:51');
INSERT INTO `order_settlement_detail` VALUES ('61', '19', '210268', '0', '2018-09-24 17:17:51');
INSERT INTO `order_settlement_detail` VALUES ('62', '19', '210267', '0', '2018-09-24 17:17:51');
INSERT INTO `order_settlement_detail` VALUES ('63', '20', '210267', '0', '2018-09-24 17:20:21');
INSERT INTO `order_settlement_detail` VALUES ('64', '20', '210266', '0', '2018-09-24 17:20:21');
INSERT INTO `order_settlement_detail` VALUES ('65', '20', '210265', '0', '2018-09-24 17:20:21');
INSERT INTO `order_settlement_detail` VALUES ('66', '20', '210268', '0', '2018-09-24 17:20:21');
INSERT INTO `order_settlement_detail` VALUES ('67', '21', '210266', '-1000', '2018-09-24 17:25:12');
INSERT INTO `order_settlement_detail` VALUES ('68', '22', '210267', '0', '2018-09-24 17:41:58');
INSERT INTO `order_settlement_detail` VALUES ('69', '22', '210265', '0', '2018-09-24 17:41:58');
INSERT INTO `order_settlement_detail` VALUES ('70', '22', '210269', '0', '2018-09-24 17:41:58');
INSERT INTO `order_settlement_detail` VALUES ('71', '22', '210266', '0', '2018-09-24 17:41:58');
INSERT INTO `order_settlement_detail` VALUES ('72', '23', '210266', '-1000', '2018-09-24 17:42:16');
INSERT INTO `order_settlement_detail` VALUES ('73', '24', '210266', '-1000', '2018-09-24 17:45:24');
INSERT INTO `order_settlement_detail` VALUES ('74', '25', '210266', '-1000', '2018-09-24 17:46:42');
INSERT INTO `order_settlement_detail` VALUES ('75', '26', '210266', '-1000', '2018-09-24 17:52:00');
INSERT INTO `order_settlement_detail` VALUES ('76', '27', '210266', '-1000', '2018-09-24 17:53:57');
INSERT INTO `order_settlement_detail` VALUES ('77', '28', '210277', '-1000', '2018-09-24 18:12:44');
INSERT INTO `order_settlement_detail` VALUES ('78', '29', '210280', '-1000', '2018-09-24 18:17:58');
INSERT INTO `order_settlement_detail` VALUES ('79', '30', '210280', '-1000', '2018-09-24 18:21:05');
INSERT INTO `order_settlement_detail` VALUES ('80', '31', '210280', '-1000', '2018-09-24 18:26:39');
INSERT INTO `order_settlement_detail` VALUES ('81', '32', '210285', '-1000', '2018-09-24 18:36:23');
INSERT INTO `order_settlement_detail` VALUES ('82', '33', '210283', '-1000', '2018-09-24 18:36:31');
INSERT INTO `order_settlement_detail` VALUES ('83', '34', '210293', '-1000', '2018-09-24 18:40:44');
INSERT INTO `order_settlement_detail` VALUES ('84', '35', '210297', '-1000', '2018-09-24 19:14:56');
INSERT INTO `order_settlement_detail` VALUES ('85', '36', '210302', '-1000', '2018-09-24 19:20:27');
INSERT INTO `order_settlement_detail` VALUES ('86', '37', '210307', '-1000', '2018-09-24 19:22:34');
INSERT INTO `order_settlement_detail` VALUES ('87', '38', '210308', '0', '2018-09-24 19:26:55');
INSERT INTO `order_settlement_detail` VALUES ('88', '38', '210310', '0', '2018-09-24 19:26:55');
INSERT INTO `order_settlement_detail` VALUES ('89', '38', '210311', '0', '2018-09-24 19:26:55');
INSERT INTO `order_settlement_detail` VALUES ('90', '38', '210309', '0', '2018-09-24 19:26:55');
INSERT INTO `order_settlement_detail` VALUES ('91', '39', '210319', '-1000', '2018-09-24 19:39:20');
INSERT INTO `order_settlement_detail` VALUES ('92', '40', '210317', '-1000', '2018-09-24 19:41:39');
INSERT INTO `order_settlement_detail` VALUES ('93', '41', '210319', '-1000', '2018-09-24 19:43:44');
INSERT INTO `order_settlement_detail` VALUES ('94', '42', '210319', '-1000', '2018-09-24 19:44:02');
INSERT INTO `order_settlement_detail` VALUES ('95', '43', '210330', '-1000', '2018-09-24 20:19:12');
INSERT INTO `order_settlement_detail` VALUES ('96', '44', '210364', '-1000', '2018-09-25 11:21:34');
INSERT INTO `order_settlement_detail` VALUES ('97', '45', '210371', '-1000', '2018-09-25 11:31:19');
INSERT INTO `order_settlement_detail` VALUES ('98', '46', '210376', '-1000', '2018-09-25 11:37:01');
INSERT INTO `order_settlement_detail` VALUES ('99', '47', '210420', '-1000', '2018-09-25 13:57:44');
INSERT INTO `order_settlement_detail` VALUES ('100', '48', '210435', '-1000', '2018-09-25 14:19:14');
INSERT INTO `order_settlement_detail` VALUES ('101', '49', '210448', '-1000', '2018-09-25 14:36:43');
INSERT INTO `order_settlement_detail` VALUES ('102', '50', '210453', '-1000', '2018-09-25 14:49:38');
INSERT INTO `order_settlement_detail` VALUES ('103', '51', '210458', '-1000', '2018-09-25 14:57:32');
INSERT INTO `order_settlement_detail` VALUES ('104', '52', '210515', '-1000', '2018-09-25 16:13:42');
INSERT INTO `order_settlement_detail` VALUES ('105', '53', '210624', '-1000', '2018-09-25 19:38:25');
INSERT INTO `order_settlement_detail` VALUES ('106', '54', '210625', '-1000', '2018-09-25 19:40:41');
INSERT INTO `order_settlement_detail` VALUES ('107', '55', '210625', '-1000', '2018-09-25 19:41:27');
INSERT INTO `order_settlement_detail` VALUES ('108', '56', '210626', '-1000', '2018-09-25 19:44:40');
INSERT INTO `order_settlement_detail` VALUES ('109', '57', '210626', '-1000', '2018-09-25 19:46:30');
INSERT INTO `order_settlement_detail` VALUES ('110', '58', '210626', '-1000', '2018-09-25 19:50:33');
INSERT INTO `order_settlement_detail` VALUES ('111', '59', '210635', '0', '2018-09-26 09:34:47');
INSERT INTO `order_settlement_detail` VALUES ('112', '59', '210637', '0', '2018-09-26 09:34:47');
INSERT INTO `order_settlement_detail` VALUES ('113', '59', '210636', '0', '2018-09-26 09:34:47');
INSERT INTO `order_settlement_detail` VALUES ('114', '59', '210634', '0', '2018-09-26 09:34:47');
INSERT INTO `order_settlement_detail` VALUES ('115', '60', '210635', '-1000', '2018-09-26 09:37:47');
INSERT INTO `order_settlement_detail` VALUES ('116', '61', '210638', '0', '2018-09-26 10:01:03');
INSERT INTO `order_settlement_detail` VALUES ('117', '61', '210639', '0', '2018-09-26 10:01:03');
INSERT INTO `order_settlement_detail` VALUES ('118', '62', '210645', '-1000', '2018-09-26 10:20:53');
INSERT INTO `order_settlement_detail` VALUES ('119', '63', '210653', '-1000', '2018-09-26 11:08:35');
INSERT INTO `order_settlement_detail` VALUES ('120', '64', '210688', '0', '2018-09-26 14:09:27');
INSERT INTO `order_settlement_detail` VALUES ('121', '64', '210686', '0', '2018-09-26 14:09:27');
INSERT INTO `order_settlement_detail` VALUES ('122', '64', '210685', '0', '2018-09-26 14:09:27');
INSERT INTO `order_settlement_detail` VALUES ('123', '64', '210687', '0', '2018-09-26 14:09:27');
INSERT INTO `order_settlement_detail` VALUES ('124', '65', '210688', '-1000', '2018-09-26 14:10:25');
INSERT INTO `order_settlement_detail` VALUES ('125', '66', '210685', '0', '2018-09-26 14:14:03');
INSERT INTO `order_settlement_detail` VALUES ('126', '66', '210687', '0', '2018-09-26 14:14:03');
INSERT INTO `order_settlement_detail` VALUES ('127', '66', '210688', '0', '2018-09-26 14:14:03');
INSERT INTO `order_settlement_detail` VALUES ('128', '66', '210686', '0', '2018-09-26 14:14:03');
INSERT INTO `order_settlement_detail` VALUES ('129', '67', '210688', '0', '2018-09-26 14:18:45');
INSERT INTO `order_settlement_detail` VALUES ('130', '67', '210685', '0', '2018-09-26 14:18:45');
INSERT INTO `order_settlement_detail` VALUES ('131', '67', '210686', '0', '2018-09-26 14:18:45');
INSERT INTO `order_settlement_detail` VALUES ('132', '67', '210687', '0', '2018-09-26 14:18:45');
INSERT INTO `order_settlement_detail` VALUES ('133', '68', '210691', '-1000', '2018-09-26 14:21:42');
INSERT INTO `order_settlement_detail` VALUES ('134', '69', '210689', '0', '2018-09-26 14:22:19');
INSERT INTO `order_settlement_detail` VALUES ('135', '69', '210690', '0', '2018-09-26 14:22:19');
INSERT INTO `order_settlement_detail` VALUES ('136', '69', '210691', '0', '2018-09-26 14:22:19');
INSERT INTO `order_settlement_detail` VALUES ('137', '69', '210692', '0', '2018-09-26 14:22:19');
INSERT INTO `order_settlement_detail` VALUES ('138', '70', '210689', '0', '2018-09-26 14:23:18');
INSERT INTO `order_settlement_detail` VALUES ('139', '70', '210691', '0', '2018-09-26 14:23:18');
INSERT INTO `order_settlement_detail` VALUES ('140', '70', '210690', '0', '2018-09-26 14:23:18');
INSERT INTO `order_settlement_detail` VALUES ('141', '70', '210692', '0', '2018-09-26 14:23:18');
INSERT INTO `order_settlement_detail` VALUES ('142', '71', '210697', '0', '2018-09-26 14:28:10');
INSERT INTO `order_settlement_detail` VALUES ('143', '71', '210696', '0', '2018-09-26 14:28:10');
INSERT INTO `order_settlement_detail` VALUES ('144', '71', '210695', '0', '2018-09-26 14:28:10');
INSERT INTO `order_settlement_detail` VALUES ('145', '71', '210694', '0', '2018-09-26 14:28:10');
INSERT INTO `order_settlement_detail` VALUES ('146', '72', '210697', '0', '2018-09-26 14:29:30');
INSERT INTO `order_settlement_detail` VALUES ('147', '72', '210695', '0', '2018-09-26 14:29:30');
INSERT INTO `order_settlement_detail` VALUES ('148', '72', '210696', '0', '2018-09-26 14:29:30');
INSERT INTO `order_settlement_detail` VALUES ('149', '72', '210694', '0', '2018-09-26 14:29:30');
INSERT INTO `order_settlement_detail` VALUES ('150', '73', '210712', '-1000', '2018-09-26 14:58:46');
INSERT INTO `order_settlement_detail` VALUES ('151', '74', '210713', '-1000', '2018-09-26 14:58:56');
INSERT INTO `order_settlement_detail` VALUES ('152', '75', '210716', '0', '2018-09-26 15:01:27');
INSERT INTO `order_settlement_detail` VALUES ('153', '75', '210713', '0', '2018-09-26 15:01:27');
INSERT INTO `order_settlement_detail` VALUES ('154', '75', '210715', '0', '2018-09-26 15:01:27');
INSERT INTO `order_settlement_detail` VALUES ('155', '75', '210714', '0', '2018-09-26 15:01:27');
INSERT INTO `order_settlement_detail` VALUES ('156', '76', '210712', '-1000', '2018-09-26 15:08:33');
INSERT INTO `order_settlement_detail` VALUES ('157', '77', '210729', '0', '2018-09-26 15:15:10');
INSERT INTO `order_settlement_detail` VALUES ('158', '77', '210731', '0', '2018-09-26 15:15:10');
INSERT INTO `order_settlement_detail` VALUES ('159', '77', '210730', '0', '2018-09-26 15:15:10');
INSERT INTO `order_settlement_detail` VALUES ('160', '77', '210728', '0', '2018-09-26 15:15:10');
INSERT INTO `order_settlement_detail` VALUES ('161', '78', '210731', '0', '2018-09-26 15:20:47');
INSERT INTO `order_settlement_detail` VALUES ('162', '78', '210729', '0', '2018-09-26 15:20:47');
INSERT INTO `order_settlement_detail` VALUES ('163', '78', '210730', '0', '2018-09-26 15:20:47');
INSERT INTO `order_settlement_detail` VALUES ('164', '78', '210728', '0', '2018-09-26 15:20:47');
INSERT INTO `order_settlement_detail` VALUES ('165', '79', '210712', '-1000', '2018-09-26 15:58:31');
INSERT INTO `order_settlement_detail` VALUES ('166', '80', '210712', '-1000', '2018-09-26 16:04:37');
INSERT INTO `order_settlement_detail` VALUES ('167', '81', '210712', '-1000', '2018-09-26 16:19:04');
INSERT INTO `order_settlement_detail` VALUES ('168', '82', '210777', '0', '2018-09-26 16:44:14');
INSERT INTO `order_settlement_detail` VALUES ('169', '82', '210779', '0', '2018-09-26 16:44:14');
INSERT INTO `order_settlement_detail` VALUES ('170', '82', '210780', '0', '2018-09-26 16:44:14');
INSERT INTO `order_settlement_detail` VALUES ('171', '82', '210778', '0', '2018-09-26 16:44:14');
INSERT INTO `order_settlement_detail` VALUES ('172', '83', '210779', '0', '2018-09-26 16:49:40');
INSERT INTO `order_settlement_detail` VALUES ('173', '83', '210778', '0', '2018-09-26 16:49:40');
INSERT INTO `order_settlement_detail` VALUES ('174', '83', '210780', '0', '2018-09-26 16:49:40');
INSERT INTO `order_settlement_detail` VALUES ('175', '83', '210777', '0', '2018-09-26 16:49:40');
INSERT INTO `order_settlement_detail` VALUES ('176', '84', '210784', '0', '2018-09-26 16:52:55');
INSERT INTO `order_settlement_detail` VALUES ('177', '84', '210783', '0', '2018-09-26 16:52:55');
INSERT INTO `order_settlement_detail` VALUES ('178', '84', '210782', '0', '2018-09-26 16:52:55');
INSERT INTO `order_settlement_detail` VALUES ('179', '84', '210781', '0', '2018-09-26 16:52:55');
INSERT INTO `order_settlement_detail` VALUES ('180', '85', '210787', '0', '2018-09-26 16:55:35');
INSERT INTO `order_settlement_detail` VALUES ('181', '85', '210785', '0', '2018-09-26 16:55:35');
INSERT INTO `order_settlement_detail` VALUES ('182', '85', '210788', '0', '2018-09-26 16:55:35');
INSERT INTO `order_settlement_detail` VALUES ('183', '85', '210786', '0', '2018-09-26 16:55:35');
INSERT INTO `order_settlement_detail` VALUES ('184', '86', '210791', '0', '2018-09-26 17:00:48');
INSERT INTO `order_settlement_detail` VALUES ('185', '86', '210792', '0', '2018-09-26 17:00:48');
INSERT INTO `order_settlement_detail` VALUES ('186', '86', '210789', '0', '2018-09-26 17:00:48');
INSERT INTO `order_settlement_detail` VALUES ('187', '86', '210790', '0', '2018-09-26 17:00:48');
INSERT INTO `order_settlement_detail` VALUES ('188', '87', '210795', '0', '2018-09-26 17:04:03');
INSERT INTO `order_settlement_detail` VALUES ('189', '87', '210794', '0', '2018-09-26 17:04:03');
INSERT INTO `order_settlement_detail` VALUES ('190', '87', '210793', '0', '2018-09-26 17:04:03');
INSERT INTO `order_settlement_detail` VALUES ('191', '87', '210796', '0', '2018-09-26 17:04:03');
INSERT INTO `order_settlement_detail` VALUES ('192', '88', '210795', '0', '2018-09-26 17:05:33');
INSERT INTO `order_settlement_detail` VALUES ('193', '88', '210796', '0', '2018-09-26 17:05:33');
INSERT INTO `order_settlement_detail` VALUES ('194', '88', '210794', '0', '2018-09-26 17:05:33');
INSERT INTO `order_settlement_detail` VALUES ('195', '88', '210793', '0', '2018-09-26 17:05:33');
INSERT INTO `order_settlement_detail` VALUES ('196', '89', '210799', '-1000', '2018-09-26 17:09:06');
INSERT INTO `order_settlement_detail` VALUES ('197', '90', '210800', '0', '2018-09-26 17:09:29');
INSERT INTO `order_settlement_detail` VALUES ('198', '90', '210797', '0', '2018-09-26 17:09:29');
INSERT INTO `order_settlement_detail` VALUES ('199', '90', '210798', '0', '2018-09-26 17:09:29');
INSERT INTO `order_settlement_detail` VALUES ('200', '90', '210799', '0', '2018-09-26 17:09:29');
INSERT INTO `order_settlement_detail` VALUES ('201', '91', '210803', '-1000', '2018-09-26 17:27:53');
INSERT INTO `order_settlement_detail` VALUES ('202', '92', '210821', '0', '2018-09-26 17:43:41');
INSERT INTO `order_settlement_detail` VALUES ('203', '92', '210819', '0', '2018-09-26 17:43:41');
INSERT INTO `order_settlement_detail` VALUES ('204', '92', '210820', '0', '2018-09-26 17:43:41');
INSERT INTO `order_settlement_detail` VALUES ('205', '92', '210818', '0', '2018-09-26 17:43:41');

-- ----------------------------
-- Table structure for order_transfer
-- ----------------------------
DROP TABLE IF EXISTS `order_transfer`;
CREATE TABLE `order_transfer` (
  `id` varchar(50) NOT NULL,
  `auid` int(11) DEFAULT NULL COMMENT 'id',
  `toauid` int(11) DEFAULT NULL COMMENT '到账用户',
  `transfertype` char(1) DEFAULT NULL COMMENT '类型1系统给玩家充2系统给代理充3系统赠玩家4系统赠代理',
  `vcoin` int(11) DEFAULT '0' COMMENT '虚拟币',
  `addtime` datetime DEFAULT NULL COMMENT '添加时间',
  `accounttype` char(2) DEFAULT NULL COMMENT '账户类型',
  `remark` varchar(200) DEFAULT NULL COMMENT '备注',
  `rmb` double(10,2) DEFAULT '0.00' COMMENT 'RMB',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='用户转账';

-- ----------------------------
-- Records of order_transfer
-- ----------------------------

-- ----------------------------
-- Table structure for pigcms_menu_url
-- ----------------------------
DROP TABLE IF EXISTS `pigcms_menu_url`;
CREATE TABLE `pigcms_menu_url` (
  `menu_id` int(11) NOT NULL AUTO_INCREMENT,
  `menu_name` varchar(50) NOT NULL,
  `menu_url` varchar(255) NOT NULL,
  `module_id` int(11) NOT NULL,
  `is_show` tinyint(4) NOT NULL COMMENT '是否在sidebar里出现',
  `online` int(11) NOT NULL DEFAULT '1' COMMENT '在线状态，还是下线状态，即可用，不可用。',
  `shortcut_allowed` int(10) unsigned NOT NULL DEFAULT '1' COMMENT '是否允许快捷访问',
  `menu_type` int(11) unsigned NOT NULL DEFAULT '0' COMMENT '1 管理后台 2 代理后台',
  `menu_desc` varchar(255) DEFAULT NULL,
  `father_menu` int(11) NOT NULL DEFAULT '0' COMMENT '上一级菜单',
  PRIMARY KEY (`menu_id`) USING BTREE,
  UNIQUE KEY `menu_url` (`menu_url`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=181 DEFAULT CHARSET=utf8 COMMENT='功能链接（菜单链接）';

-- ----------------------------
-- Records of pigcms_menu_url
-- ----------------------------
INSERT INTO `pigcms_menu_url` VALUES ('1', '首页', '/panel/index.php', '1', '0', '1', '1', '1', '后台首页', '0');
INSERT INTO `pigcms_menu_url` VALUES ('2', '账号列表', '/panel/users.php', '1', '1', '1', '1', '1', '账号列表', '0');
INSERT INTO `pigcms_menu_url` VALUES ('3', '修改账号', '/panel/user_modify.php', '1', '0', '1', '0', '1', '修改账号', '2');
INSERT INTO `pigcms_menu_url` VALUES ('4', '新建账号', '/panel/user_add.php', '1', '0', '1', '1', '1', '新建账号', '2');
INSERT INTO `pigcms_menu_url` VALUES ('5', '个人信息', '/panel/profile.php', '1', '0', '1', '1', '1', '个人信息', '0');
INSERT INTO `pigcms_menu_url` VALUES ('6', '成员管理', '/panel/group.php', '1', '0', '1', '1', '1', '显示账号组详情及该组成员', '7');
INSERT INTO `pigcms_menu_url` VALUES ('7', '角色管理', '/panel/groups.php', '1', '1', '1', '1', '1', '增加管理员', '0');
INSERT INTO `pigcms_menu_url` VALUES ('8', '修改账号组', '/panel/group_modify.php', '1', '0', '1', '0', '1', '修改账号组', '7');
INSERT INTO `pigcms_menu_url` VALUES ('9', '新增角色', '/panel/group_add.php', '1', '0', '1', '1', '1', '新建账号组', '7');
INSERT INTO `pigcms_menu_url` VALUES ('10', '权限管理', '/panel/group_role.php', '1', '1', '1', '1', '1', '用户权限依赖于账号组的权限', '0');
INSERT INTO `pigcms_menu_url` VALUES ('11', '菜单模块', '/panel/modules.php', '1', '1', '1', '1', '1', '菜单里的模块', '0');
INSERT INTO `pigcms_menu_url` VALUES ('12', '编辑菜单模块', '/panel/module_modify.php', '1', '0', '1', '0', '1', '编辑模块', '11');
INSERT INTO `pigcms_menu_url` VALUES ('13', '添加菜单模块', '/panel/module_add.php', '1', '0', '1', '1', '1', '添加菜单模块', '11');
INSERT INTO `pigcms_menu_url` VALUES ('14', '功能列表', '/panel/menus.php', '1', '1', '1', '1', '1', '菜单功能及可访问的链接', '0');
INSERT INTO `pigcms_menu_url` VALUES ('15', '增加功能', '/panel/menu_add.php', '1', '0', '1', '1', '1', '增加功能', '14');
INSERT INTO `pigcms_menu_url` VALUES ('16', '功能修改', '/panel/menu_modify.php', '1', '0', '1', '0', '1', '修改功能', '14');
INSERT INTO `pigcms_menu_url` VALUES ('19', '菜单链接列表', '/panel/module.php', '1', '0', '1', '0', '1', '显示模块详情及该模块下的菜单', '11');
INSERT INTO `pigcms_menu_url` VALUES ('20', '登入', '/login.php', '1', '0', '1', '1', '1', '登入页面', '0');
INSERT INTO `pigcms_menu_url` VALUES ('21', '操作记录', '/panel/syslog.php', '1', '0', '0', '1', '1', '用户操作的历史行为', '0');
INSERT INTO `pigcms_menu_url` VALUES ('22', '系统信息', '/panel/system.php', '1', '1', '1', '1', '1', '显示系统相关信息', '0');
INSERT INTO `pigcms_menu_url` VALUES ('23', 'ajax访问修改快捷菜单', '/ajax/shortcut.php', '1', '0', '1', '0', '1', 'ajax请求', '0');
INSERT INTO `pigcms_menu_url` VALUES ('26', '系统设置', '/panel/setting.php', '1', '0', '1', '0', '1', '系统设置', '0');
INSERT INTO `pigcms_menu_url` VALUES ('101', '代理资料', '/agent/agent.php', '7', '1', '1', '1', '1', '', '0');
INSERT INTO `pigcms_menu_url` VALUES ('103', '提成设置', '/agent/proportionsetting.php', '7', '0', '0', '1', '1', '', '0');
INSERT INTO `pigcms_menu_url` VALUES ('104', '充值订单', '/agent/topupearnings.php', '8', '1', '1', '1', '1', '', '0');
INSERT INTO `pigcms_menu_url` VALUES ('105', '游戏邀请', '/agent/presentgems.php', '7', '0', '0', '1', '1', '', '0');
INSERT INTO `pigcms_menu_url` VALUES ('109', '返利明细', '/agent/myearnings.php', '8', '1', '1', '1', '1', '', '0');
INSERT INTO `pigcms_menu_url` VALUES ('111', '充值记录', '/agentcenter/topuprecord.php', '9', '0', '0', '1', '1', '', '0');
INSERT INTO `pigcms_menu_url` VALUES ('112', '转钻记录', '/agentcenter/sellrecord.php', '3', '0', '0', '1', '1', '', '0');
INSERT INTO `pigcms_menu_url` VALUES ('119', '财务报表', '/agent/financeReport.php', '8', '1', '1', '1', '1', '', '0');
INSERT INTO `pigcms_menu_url` VALUES ('120', '在线牌桌', '/agent/onlineusers.php', '8', '0', '0', '1', '1', '', '0');
INSERT INTO `pigcms_menu_url` VALUES ('123', '留存统计', '/agent/statremain.php', '8', '0', '0', '1', '1', '', '0');
INSERT INTO `pigcms_menu_url` VALUES ('124', '代理提现', '/agentcenter/drawmoney.php', '4', '0', '1', '1', '2', '', '0');
INSERT INTO `pigcms_menu_url` VALUES ('126', '推广明细', '/agentcenter/tuiguangdetaile.php', '5', '1', '1', '1', '1', '', '0');
INSERT INTO `pigcms_menu_url` VALUES ('127', '提现审批', '/agent/drawreview.php', '8', '1', '1', '1', '1', '', '0');
INSERT INTO `pigcms_menu_url` VALUES ('128', '充值报表', '/agent/topusummary.php', '8', '1', '0', '1', '1', '', '0');
INSERT INTO `pigcms_menu_url` VALUES ('129', '玩家资料', '/agent/gameplayer.php', '9', '1', '1', '1', '1', '', '0');
INSERT INTO `pigcms_menu_url` VALUES ('131', '俱乐部玩家', '/agent/clubGameUser.php', '9', '0', '1', '1', '1', '', '0');
INSERT INTO `pigcms_menu_url` VALUES ('132', '公告', '/agentcenter/notice.php', '4', '1', '1', '1', '1', '', '0');
INSERT INTO `pigcms_menu_url` VALUES ('133', 'IOS支付开关', '/agent/iospayswitch.php', '10', '1', '1', '1', '1', '', '0');
INSERT INTO `pigcms_menu_url` VALUES ('134', '公告列表', '/agent/noticelist.php', '3', '1', '0', '1', '1', '', '0');
INSERT INTO `pigcms_menu_url` VALUES ('135', '查看公告', '/agentcenter/noticeview.php', '4', '0', '1', '1', '2', '', '132');
INSERT INTO `pigcms_menu_url` VALUES ('136', '对碰设置', '/agent/touchsetting.php', '10', '1', '1', '1', '1', '', '0');
INSERT INTO `pigcms_menu_url` VALUES ('137', '对碰列表', '/agent/touchlist.php', '10', '1', '1', '1', '1', '', '0');
INSERT INTO `pigcms_menu_url` VALUES ('138', '对碰明细', '/agentcenter/mytouchlist.php', '10', '1', '1', '1', '1', '', '0');
INSERT INTO `pigcms_menu_url` VALUES ('139', '在线玩家', '/agent/onlineplayer.php', '8', '0', '0', '1', '1', '', '0');
INSERT INTO `pigcms_menu_url` VALUES ('140', '游戏公告', '/agent/message.php', '9', '1', '1', '1', '1', '', '0');
INSERT INTO `pigcms_menu_url` VALUES ('141', '强更管理', '/agent/strongupdate.php', '10', '1', '1', '1', '1', '', '0');
INSERT INTO `pigcms_menu_url` VALUES ('142', '增加强更版本', '/agent/strongupdate_add.php', '10', '0', '1', '1', '1', '', '141');
INSERT INTO `pigcms_menu_url` VALUES ('143', '推广概况', '/agentcenter/summary.php', '5', '1', '1', '1', '1', '', '0');
INSERT INTO `pigcms_menu_url` VALUES ('144', '关闭房间', '/agent/closeroom.php', '10', '1', '1', '1', '1', '', '0');
INSERT INTO `pigcms_menu_url` VALUES ('145', '转送钻石', '/agentcenter/sell.php', '9', '0', '0', '1', '1', '', '0');
INSERT INTO `pigcms_menu_url` VALUES ('146', '耗钻记录', '/agent/sellgemslist.php', '3', '0', '0', '1', '1', '', '0');
INSERT INTO `pigcms_menu_url` VALUES ('147', '开房记录', '/agent/openRecord.php', '3', '1', '1', '1', '1', '', '0');
INSERT INTO `pigcms_menu_url` VALUES ('148', '俱乐部管理', '/agent/clubManage.php', '9', '1', '1', '1', '1', '', '0');
INSERT INTO `pigcms_menu_url` VALUES ('149', '代理绑定', '/agent/agentBinding.php', '9', '1', '1', '1', '1', '', '0');
INSERT INTO `pigcms_menu_url` VALUES ('150', '代理报表', '/agent/agentRebate.php', '7', '1', '1', '1', '1', '', '0');
INSERT INTO `pigcms_menu_url` VALUES ('151', '代理进货', '/agent/agentPurchase.php', '7', '1', '0', '1', '1', '', '0');
INSERT INTO `pigcms_menu_url` VALUES ('152', '划拨记录', '/agent/transferRecord.php', '7', '1', '1', '1', '1', '', '0');
INSERT INTO `pigcms_menu_url` VALUES ('153', '局数报表', '/agent/jushuRecord.php', '3', '1', '1', '1', '1', '', '0');
INSERT INTO `pigcms_menu_url` VALUES ('154', '充钻记录', '/agent/rechargeRecord.php', '9', '1', '1', '1', '1', '', '0');
INSERT INTO `pigcms_menu_url` VALUES ('155', '数据统计', '/agent/censusReport.php', '8', '1', '1', '1', '1', '', '0');
INSERT INTO `pigcms_menu_url` VALUES ('156', '代理开通', '/agent/registerAgent.php', '9', '1', '1', '1', '1', '开通 和 玩家升级代理', '0');
INSERT INTO `pigcms_menu_url` VALUES ('157', '代理数据分析', '/agent/agentAnalysis.php', '7', '1', '1', '1', '1', '代理数据分析', '0');
INSERT INTO `pigcms_menu_url` VALUES ('158', '总代报表', '/agent/roseAgentRecord.php', '7', '1', '1', '1', '1', '', '0');
INSERT INTO `pigcms_menu_url` VALUES ('159', '代理首页', '/agentCenter/home.php', '4', '0', '1', '1', '2', '', '0');
INSERT INTO `pigcms_menu_url` VALUES ('160', '玩家', '/agentCenter/players.php', '4', '0', '1', '1', '2', '玩家列表', '0');
INSERT INTO `pigcms_menu_url` VALUES ('161', '代理商', '/agentCenter/agents.php', '4', '0', '1', '1', '2', '代理商首页', '0');
INSERT INTO `pigcms_menu_url` VALUES ('162', '亲友圈', '/agentCenter/friendscircle.php', '4', '0', '1', '1', '2', '亲友圈首页', '0');
INSERT INTO `pigcms_menu_url` VALUES ('163', '个人中心', '/agentCenter/mine.php', '4', '0', '1', '1', '2', '我的', '0');
INSERT INTO `pigcms_menu_url` VALUES ('164', '开通代理', '/agentCenter/openagents.php', '4', '0', '1', '1', '2', '', '0');
INSERT INTO `pigcms_menu_url` VALUES ('165', '代理进货', '/agentCenter/purchase.php', '4', '0', '1', '1', '2', '', '0');
INSERT INTO `pigcms_menu_url` VALUES ('166', '钻石充值', '/agentCenter/gemsrecharge.php', '4', '0', '1', '1', '2', '为某一位玩家充值钻石', '0');
INSERT INTO `pigcms_menu_url` VALUES ('167', '玩家资料', '/agentCenter/playersinfo.php', '4', '0', '1', '1', '2', '显示某一位玩家的个人资料', '0');
INSERT INTO `pigcms_menu_url` VALUES ('168', '代理充值(划拨)', '/agentCenter/sendmoney.php', '4', '0', '1', '1', '2', '为自己下边绑定的代理充值', '0');
INSERT INTO `pigcms_menu_url` VALUES ('169', '代理资料', '/agentCenter/agentsinfo.php', '4', '0', '1', '1', '2', '显示某一位绑定自己的代理的个人资料', '0');
INSERT INTO `pigcms_menu_url` VALUES ('170', '亲友圈资料', '/agentCenter/friendscircleinfo.php', '4', '0', '1', '1', '2', '显示某一个亲友圈的信息', '0');
INSERT INTO `pigcms_menu_url` VALUES ('171', '返佣记录', '/agentCenter/rebaterecord.php', '4', '0', '1', '1', '2', '显示自己收获佣金记录', '0');
INSERT INTO `pigcms_menu_url` VALUES ('172', '提现记录', '/agentCenter/drawmoneyrecord.php', '4', '0', '1', '1', '2', '代理提现钱的记录', '0');
INSERT INTO `pigcms_menu_url` VALUES ('173', '返佣汇总', '/agentCenter/rebatesummary.php', '4', '0', '1', '1', '2', '清晰的展示代理的佣金记录以日月', '0');
INSERT INTO `pigcms_menu_url` VALUES ('174', '钻石记录', '/agentCenter/gemsrecord.php', '4', '0', '1', '1', '2', '钻石充值或者划拨消耗记录', '0');
INSERT INTO `pigcms_menu_url` VALUES ('175', '完善资料', '/agentCenter/updatemyinfo.php', '4', '0', '1', '1', '2', '完善代理的信息资料', '0');
INSERT INTO `pigcms_menu_url` VALUES ('176', '账户安全', '/agentCenter/updatepassword.php', '4', '0', '1', '1', '2', '代理可以修改自己的账号密码', '0');
INSERT INTO `pigcms_menu_url` VALUES ('177', '支付确认', '/agentCenter/confirmRechargeInfo.php', '4', '0', '1', '1', '2', '微信支付确认信息页面', '0');
INSERT INTO `pigcms_menu_url` VALUES ('179', '', '', '0', '0', '1', '1', '0', null, '0');
INSERT INTO `pigcms_menu_url` VALUES ('180', '钻石记录', '/agent/diamondRecord.php', '3', '1', '1', '1', '1', '钻石记录', '0');

-- ----------------------------
-- Table structure for pigcms_module
-- ----------------------------
DROP TABLE IF EXISTS `pigcms_module`;
CREATE TABLE `pigcms_module` (
  `module_id` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `module_name` varchar(50) NOT NULL,
  `module_url` varchar(128) NOT NULL,
  `module_sort` int(11) unsigned NOT NULL DEFAULT '1',
  `module_desc` varchar(255) DEFAULT NULL,
  `module_icon` varchar(32) DEFAULT 'icon-th' COMMENT '菜单模块图标',
  `online` int(11) NOT NULL DEFAULT '1' COMMENT '模块是否在线',
  PRIMARY KEY (`module_id`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8 COMMENT='菜单模块';

-- ----------------------------
-- Records of pigcms_module
-- ----------------------------
INSERT INTO `pigcms_module` VALUES ('1', '系统设置', '/panel/index.php', '999', '', 'fa-cogs', '1');
INSERT INTO `pigcms_module` VALUES ('3', '游戏报表', '/index.php', '0', '', 'fa-hdd-o', '1');
INSERT INTO `pigcms_module` VALUES ('4', '代理中心', '/index.php', '1', '', 'fa-desktop', '0');
INSERT INTO `pigcms_module` VALUES ('5', '推广收益', '/index.php', '1', '', 'fa-briefcase', '0');
INSERT INTO `pigcms_module` VALUES ('7', '代理管理', '/index.php', '2', '', 'fa-comments-o', '1');
INSERT INTO `pigcms_module` VALUES ('8', '财务管理', '/index.php', '3', '', 'fa-bar-chart-o', '1');
INSERT INTO `pigcms_module` VALUES ('9', '用户管理', '/index.php', '1', '', 'fa-users', '1');
INSERT INTO `pigcms_module` VALUES ('10', '平台设置', '/index.php', '90', '', 'fa-cog', '0');

-- ----------------------------
-- Table structure for pigcms_system
-- ----------------------------
DROP TABLE IF EXISTS `pigcms_system`;
CREATE TABLE `pigcms_system` (
  `key_name` varchar(32) COLLATE utf8_unicode_ci NOT NULL,
  `key_value` text COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`key_name`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci COMMENT='系统配置表';

-- ----------------------------
-- Records of pigcms_system
-- ----------------------------
INSERT INTO `pigcms_system` VALUES ('server_maintenance', '');
INSERT INTO `pigcms_system` VALUES ('timezone', '\"Asia/Tokyo\"');

-- ----------------------------
-- Table structure for pigcms_user
-- ----------------------------
DROP TABLE IF EXISTS `pigcms_user`;
CREATE TABLE `pigcms_user` (
  `user_id` int(11) NOT NULL AUTO_INCREMENT,
  `user_name` varchar(50) NOT NULL,
  `password` varchar(255) NOT NULL,
  `real_name` varchar(255) NOT NULL,
  `mobile` varchar(20) NOT NULL,
  `email` varchar(255) NOT NULL,
  `user_desc` varchar(255) DEFAULT NULL,
  `login_time` int(11) DEFAULT NULL COMMENT '登录时间',
  `status` tinyint(4) NOT NULL DEFAULT '1',
  `login_ip` varchar(32) DEFAULT NULL,
  `user_group` int(11) NOT NULL,
  `template` varchar(32) NOT NULL DEFAULT 'default' COMMENT '主题模板',
  `shortcuts` text COMMENT '快捷菜单',
  `show_quicknote` int(11) NOT NULL DEFAULT '1' COMMENT '是否显示quicknote',
  `unionid` varchar(64) DEFAULT '',
  PRIMARY KEY (`user_id`) USING BTREE,
  UNIQUE KEY `user_name` (`user_name`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8 COMMENT='后台用户';

-- ----------------------------
-- Records of pigcms_user
-- ----------------------------
INSERT INTO `pigcms_user` VALUES ('1', 'admin', '4a7d1ed414474e4033ac29ccb8653d9b', '木头', '17157115627', 'a17157115627', '超级管理员!', '1537947395', '1', '127.0.0.1', '1', 'wintertide', '2,7,10,11,13,14,18,21,24', '0', '');
INSERT INTO `pigcms_user` VALUES ('9', '13275720010', 'e10adc3949ba59abbe56e057f20f883e', '泽亚', '13275720010', '13275720010@qq.com', '', '1537600798', '1', '36.5.102.198, 140.205.132.40', '3', 'default', null, '1', '');
INSERT INTO `pigcms_user` VALUES ('10', '18656016001', 'e10adc3949ba59abbe56e057f20f883e', '羽中', '18656016001', '18656016001@qq.com', '', '1537600069', '1', '58.243.254.223, 140.205.253.158', '3', 'default', null, '1', '');
INSERT INTO `pigcms_user` VALUES ('11', '17805652653', 'e10adc3949ba59abbe56e057f20f883e', '杨凯', '17805652653', '17805652653@163.com', '', '1537603423', '1', '117.136.101.37, 139.196.128.75', '3', 'default', null, '1', '');

-- ----------------------------
-- Table structure for pigcms_user_group
-- ----------------------------
DROP TABLE IF EXISTS `pigcms_user_group`;
CREATE TABLE `pigcms_user_group` (
  `group_id` int(11) NOT NULL AUTO_INCREMENT,
  `group_name` varchar(32) DEFAULT NULL,
  `group_role` text CHARACTER SET utf8 COLLATE utf8_unicode_ci COMMENT '初始权限为1,5,17,18,22,23,24,25',
  `owner_id` int(11) DEFAULT NULL COMMENT '创建人ID',
  `group_desc` varchar(64) CHARACTER SET utf8 COLLATE utf8_unicode_ci DEFAULT NULL,
  PRIMARY KEY (`group_id`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8 COMMENT='账号组';

-- ----------------------------
-- Records of pigcms_user_group
-- ----------------------------
INSERT INTO `pigcms_user_group` VALUES ('1', '超级管理员组', '1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,19,20,21,22,23,26,101,104,109,127,129,140,147,148,150,180', '1', '仅开发人员（不提供给任何人使用）');
INSERT INTO `pigcms_user_group` VALUES ('3', 'admin', '147,180,129,148,101,104,109,127,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,19,20,22,23,26', '1', '超级管理员');
INSERT INTO `pigcms_user_group` VALUES ('4', '市场部', '147,180,129,148,101,104,109,1,3,5,15,23', '1', '');
INSERT INTO `pigcms_user_group` VALUES ('5', '运营部', '147,153,129,148,101,104,109,127,1,5', '1', '');

-- ----------------------------
-- Table structure for sys_config
-- ----------------------------
DROP TABLE IF EXISTS `sys_config`;
CREATE TABLE `sys_config` (
  `id` int(11) NOT NULL,
  `syskey` varchar(20) DEFAULT NULL,
  `sysvalue` varchar(50) DEFAULT NULL,
  `mark` varchar(100) DEFAULT NULL,
  `status` char(1) DEFAULT '1' COMMENT '0',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='ϵͳ';

-- ----------------------------
-- Records of sys_config
-- ----------------------------
INSERT INTO `sys_config` VALUES ('1', 'AGENT_RETURN_0_0', '0.025', '非普通平级代理返佣', '9');
INSERT INTO `sys_config` VALUES ('2', 'AGENT_RETURN2', '0.05', '二级代理返佣', '9');
INSERT INTO `sys_config` VALUES ('3', 'AGENT_RETURN3', '0.05', '三级代理返佣', '9');
INSERT INTO `sys_config` VALUES ('4', 'AGENT_RETURN_6_6', '0.05', '普通平级代理返佣', '9');
INSERT INTO `sys_config` VALUES ('5', 'GAME_ServerMaintain', '0', '服务器维护状态', '1');
INSERT INTO `sys_config` VALUES ('6', 'GAME_DefaultGameId', '51', '大厅首页开房间默认游戏Id', '1');
INSERT INTO `sys_config` VALUES ('7', 'LogonNonStr', '12345', '登录态验证用随机字符串', '1');

-- ----------------------------
-- Table structure for sys_sequence
-- ----------------------------
DROP TABLE IF EXISTS `sys_sequence`;
CREATE TABLE `sys_sequence` (
  `name` varchar(20) NOT NULL,
  `current_value` int(11) NOT NULL,
  `increment` int(11) NOT NULL DEFAULT '1',
  PRIMARY KEY (`name`) USING BTREE
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COMMENT='序列表';

-- ----------------------------
-- Records of sys_sequence
-- ----------------------------
INSERT INTO `sys_sequence` VALUES ('agent_info', '10002', '1');
INSERT INTO `sys_sequence` VALUES ('agent_log', '1', '1');
INSERT INTO `sys_sequence` VALUES ('general', '10000000', '1');
INSERT INTO `sys_sequence` VALUES ('order_settlement', '92', '1');
INSERT INTO `sys_sequence` VALUES ('order_recorddata', '81', '1');
INSERT INTO `sys_sequence` VALUES ('friend_info', '10000', '1');
INSERT INTO `sys_sequence` VALUES ('user_info', '210823', '1');
INSERT INTO `sys_sequence` VALUES ('user_log', '1', '1');
INSERT INTO `sys_sequence` VALUES ('user_log_bak', '1', '1');
INSERT INTO `sys_sequence` VALUES ('user_task_log', '1', '1');
INSERT INTO `sys_sequence` VALUES ('user_activity_log', '1', '1');

-- ----------------------------
-- Table structure for sys_shop
-- ----------------------------
DROP TABLE IF EXISTS `sys_shop`;
CREATE TABLE `sys_shop` (
  `id` int(11) NOT NULL AUTO_INCREMENT COMMENT '商城唯一Id',
  `rmb` double(10,2) DEFAULT NULL COMMENT '充值所需的人民币价格，单位分',
  `moneytype` int(11) DEFAULT NULL COMMENT '充值获得道具类型',
  `moneynum` int(11) DEFAULT NULL COMMENT '充值获得道具数量',
  `givetype` char(2) DEFAULT NULL COMMENT '赠送获得道具类型',
  `givenum` int(11) DEFAULT NULL COMMENT '赠送获得道具的数量',
  `img_id` int(11) DEFAULT NULL COMMENT '客户端使用的对应充值项图片编号',
  `mark` varchar(500) DEFAULT NULL COMMENT '备注信息',
  `group` char(2) DEFAULT NULL COMMENT '分组，一般根据不同的业务确定分组。如在公众号充值和应用内充值',
  `isHot` int(255) DEFAULT '1',
  `status` int(255) DEFAULT '1' COMMENT '启用状态',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of sys_shop
-- ----------------------------
INSERT INTO `sys_shop` VALUES ('1', '10.00', '2', '100', '4', '0', '1', null, '1', '0', '1');
INSERT INTO `sys_shop` VALUES ('2', '20.00', '2', '200', '4', '10', '2', null, '1', '1', '1');
INSERT INTO `sys_shop` VALUES ('3', '50.00', '2', '500', '4', '60', '3', null, '1', '1', '1');
INSERT INTO `sys_shop` VALUES ('4', '128.00', '2', '1280', '4', '150', '4', null, '1', '0', '1');
INSERT INTO `sys_shop` VALUES ('5', '249.00', '2', '2490', '4', '300', '5', null, '1', '0', '1');
INSERT INTO `sys_shop` VALUES ('6', '498.00', '2', '4980', '4', '600', '6', null, '1', '0', '1');
INSERT INTO `sys_shop` VALUES ('7', '0.10', '2', '1', '4', '0', '1', null, '1', '0', '0');

-- ----------------------------
-- Table structure for user_account
-- ----------------------------
DROP TABLE IF EXISTS `user_account`;
CREATE TABLE `user_account` (
  `userid` int(11) NOT NULL,
  `rmb` double(12,2) DEFAULT '0.00' COMMENT 'RMB',
  `diamond` double(12,2) DEFAULT '0.00' COMMENT '钻石',
  `gold` double(12,2) DEFAULT '0.00' COMMENT '金币',
  `qidou` double(12,2) DEFAULT '0.00' COMMENT '七豆',
  `grift` double(12,2) DEFAULT '0.00' COMMENT '红包',
  PRIMARY KEY (`userid`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='账户信息';

-- ----------------------------
-- Records of user_account
-- ----------------------------
INSERT INTO `user_account` VALUES ('210001', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210002', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210003', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210004', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210005', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210006', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210007', '0.00', '100.00', '1000.00', '0.00', '0.00');
INSERT INTO `user_account` VALUES ('210008', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210009', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210010', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210011', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210012', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210013', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210014', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210015', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210016', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210017', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210018', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210019', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210020', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210021', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210022', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210023', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210024', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210025', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210026', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210027', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210028', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210029', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210030', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210031', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210032', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210033', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210034', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210035', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210036', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210037', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210038', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210039', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210040', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210041', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210042', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210043', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210044', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210045', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210046', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210047', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210048', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210049', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210050', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210051', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210052', '0.00', '99.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210053', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210054', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210055', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210056', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210057', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210058', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210059', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210060', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210061', '0.00', '100.00', '1000.00', '0.00', '0.00');
INSERT INTO `user_account` VALUES ('210062', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210063', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210064', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210065', '0.00', '99.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210066', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210067', '0.00', '99.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210068', '0.00', '99.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210069', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210070', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210071', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210072', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210073', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210074', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210075', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210076', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210077', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210078', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210079', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210080', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210081', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210082', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210083', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210084', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210085', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210086', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210087', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210088', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210089', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210090', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210091', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210092', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210093', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210094', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210095', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210096', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210097', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210098', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210099', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210100', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210101', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210102', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210103', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210104', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210105', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210106', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210107', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210108', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210109', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210110', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210111', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210112', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210113', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210114', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210115', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210116', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210117', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210118', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210119', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210120', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210121', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210122', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210123', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210124', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210125', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210126', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210127', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210128', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210129', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210130', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210131', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210132', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210133', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210134', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210135', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210136', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210137', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210138', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210139', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210140', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210141', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210142', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210143', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210144', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210145', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210146', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210147', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210148', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210149', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210150', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210151', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210152', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210153', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210154', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210155', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210156', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210157', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210158', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210159', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210160', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210161', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210162', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210163', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210164', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210165', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210166', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210167', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210168', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210169', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210170', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210171', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210172', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210173', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210174', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210175', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210176', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210177', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210178', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210179', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210180', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210181', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210182', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210183', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210184', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210185', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210186', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210187', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210188', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210189', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210190', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210191', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210192', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210193', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210194', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210195', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210196', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210197', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210198', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210199', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210200', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210201', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210202', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210203', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210204', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210205', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210206', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210207', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210208', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210209', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210210', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210211', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210212', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210213', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210214', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210215', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210216', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210217', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210218', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210219', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210220', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210221', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210222', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210223', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210224', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210225', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210226', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210227', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210228', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210229', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210230', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210231', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210232', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210233', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210234', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210235', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210236', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210237', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210238', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210239', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210240', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210241', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210242', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210243', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210244', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210245', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210246', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210247', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210248', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210249', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210250', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210251', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210252', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210253', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210254', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210255', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210256', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210257', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210258', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210259', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210260', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210261', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210262', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210263', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210264', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210265', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210266', '0.00', '100.00', '1000.00', '0.00', '0.00');
INSERT INTO `user_account` VALUES ('210267', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210268', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210269', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210270', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210271', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210272', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210273', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210274', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210275', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210276', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210277', '0.00', '100.00', '1000.00', '0.00', '0.00');
INSERT INTO `user_account` VALUES ('210278', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210279', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210280', '0.00', '100.00', '1000.00', '0.00', '0.00');
INSERT INTO `user_account` VALUES ('210281', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210282', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210283', '0.00', '100.00', '1000.00', '0.00', '0.00');
INSERT INTO `user_account` VALUES ('210284', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210285', '0.00', '100.00', '1000.00', '0.00', '0.00');
INSERT INTO `user_account` VALUES ('210286', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210287', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210288', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210289', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210290', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210291', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210292', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210293', '0.00', '100.00', '1000.00', '0.00', '0.00');
INSERT INTO `user_account` VALUES ('210294', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210295', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210296', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210297', '0.00', '100.00', '1000.00', '0.00', '0.00');
INSERT INTO `user_account` VALUES ('210298', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210299', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210300', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210301', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210302', '0.00', '100.00', '1000.00', '0.00', '0.00');
INSERT INTO `user_account` VALUES ('210303', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210304', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210305', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210306', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210307', '0.00', '100.00', '1000.00', '0.00', '0.00');
INSERT INTO `user_account` VALUES ('210308', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210309', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210310', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210311', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210312', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210313', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210314', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210315', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210316', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210317', '0.00', '100.00', '1000.00', '0.00', '0.00');
INSERT INTO `user_account` VALUES ('210318', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210319', '0.00', '100.00', '1000.00', '0.00', '0.00');
INSERT INTO `user_account` VALUES ('210320', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210321', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210322', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210323', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210324', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210325', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210326', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210327', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210328', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210329', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210330', '0.00', '100.00', '1000.00', '0.00', '0.00');
INSERT INTO `user_account` VALUES ('210331', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210332', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210333', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210334', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210335', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210336', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210337', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210338', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210339', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210340', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210341', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210342', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210343', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210344', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210345', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210346', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210347', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210348', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210349', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210350', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210351', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210352', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210353', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210354', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210355', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210356', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210357', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210358', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210359', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210360', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210361', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210362', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210363', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210364', '0.00', '100.00', '1000.00', '0.00', '0.00');
INSERT INTO `user_account` VALUES ('210365', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210366', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210367', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210368', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210369', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210370', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210371', '0.00', '100.00', '1000.00', '0.00', '0.00');
INSERT INTO `user_account` VALUES ('210372', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210373', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210374', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210375', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210376', '0.00', '100.00', '1000.00', '0.00', '0.00');
INSERT INTO `user_account` VALUES ('210377', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210378', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210379', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210380', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210381', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210382', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210383', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210384', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210385', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210386', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210387', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210388', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210389', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210390', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210391', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210392', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210393', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210394', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210395', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210396', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210397', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210398', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210399', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210400', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210401', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210402', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210403', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210404', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210405', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210406', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210407', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210408', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210409', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210410', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210411', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210412', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210413', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210414', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210415', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210416', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210417', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210418', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210419', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210420', '0.00', '100.00', '1000.00', '0.00', '0.00');
INSERT INTO `user_account` VALUES ('210421', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210422', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210423', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210424', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210425', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210426', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210427', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210428', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210429', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210430', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210431', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210432', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210433', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210434', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210435', '0.00', '100.00', '1000.00', '0.00', '0.00');
INSERT INTO `user_account` VALUES ('210436', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210437', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210438', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210439', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210440', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210441', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210442', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210443', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210444', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210445', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210446', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210447', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210448', '0.00', '100.00', '1000.00', '0.00', '0.00');
INSERT INTO `user_account` VALUES ('210449', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210450', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210451', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210452', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210453', '0.00', '100.00', '1000.00', '0.00', '0.00');
INSERT INTO `user_account` VALUES ('210454', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210455', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210456', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210457', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210458', '0.00', '100.00', '1000.00', '0.00', '0.00');
INSERT INTO `user_account` VALUES ('210459', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210460', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210461', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210462', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210463', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210464', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210465', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210466', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210467', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210468', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210469', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210470', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210471', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210472', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210473', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210474', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210475', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210476', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210477', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210478', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210479', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210480', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210481', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210482', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210483', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210484', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210485', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210486', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210487', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210488', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210489', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210490', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210491', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210492', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210493', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210494', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210495', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210496', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210497', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210498', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210499', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210500', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210501', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210502', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210503', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210504', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210505', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210506', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210507', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210508', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210509', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210510', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210511', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210512', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210513', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210514', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210515', '0.00', '100.00', '1000.00', '0.00', '0.00');
INSERT INTO `user_account` VALUES ('210516', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210517', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210518', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210519', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210520', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210521', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210522', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210523', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210524', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210525', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210526', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210527', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210528', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210529', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210530', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210531', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210532', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210533', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210534', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210535', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210536', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210537', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210538', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210539', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210540', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210541', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210542', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210543', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210544', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210545', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210546', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210547', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210548', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210549', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210550', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210551', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210552', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210553', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210554', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210555', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210556', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210557', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210558', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210559', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210560', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210561', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210562', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210563', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210564', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210565', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210566', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210567', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210568', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210569', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210570', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210571', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210572', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210573', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210574', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210575', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210576', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210577', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210578', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210579', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210580', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210581', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210582', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210583', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210584', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210585', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210586', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210587', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210588', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210589', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210590', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210591', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210592', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210593', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210594', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210595', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210596', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210597', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210598', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210599', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210600', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210601', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210602', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210603', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210604', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210605', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210606', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210607', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210608', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210609', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210610', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210611', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210612', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210613', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210614', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210615', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210616', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210617', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210618', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210619', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210620', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210621', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210622', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210623', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210624', '0.00', '100.00', '1000.00', '0.00', '0.00');
INSERT INTO `user_account` VALUES ('210625', '0.00', '100.00', '1000.00', '0.00', '0.00');
INSERT INTO `user_account` VALUES ('210626', '0.00', '100.00', '1000.00', '0.00', '0.00');
INSERT INTO `user_account` VALUES ('210627', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210628', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210629', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210630', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210631', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210632', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210633', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210634', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210635', '0.00', '100.00', '1000.00', '0.00', '0.00');
INSERT INTO `user_account` VALUES ('210636', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210637', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210638', '0.00', '99.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210639', '0.00', '99.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210640', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210641', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210642', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210643', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210644', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210645', '0.00', '100.00', '1000.00', '0.00', '0.00');
INSERT INTO `user_account` VALUES ('210646', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210647', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210648', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210649', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210650', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210651', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210652', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210653', '0.00', '100.00', '1000.00', '0.00', '0.00');
INSERT INTO `user_account` VALUES ('210654', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210655', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210656', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210657', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210658', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210659', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210660', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210661', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210662', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210663', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210664', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210665', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210666', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210667', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210668', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210669', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210670', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210671', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210672', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210673', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210674', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210675', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210676', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210677', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210678', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210679', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210680', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210681', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210682', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210683', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210684', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210685', '0.00', '2.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210686', '0.00', '98.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210687', '0.00', '98.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210688', '0.00', '98.00', '1000.00', '0.00', '0.00');
INSERT INTO `user_account` VALUES ('210689', '0.00', '98.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210690', '0.00', '98.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210691', '0.00', '98.00', '1000.00', '0.00', '0.00');
INSERT INTO `user_account` VALUES ('210692', '0.00', '86.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210693', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210694', '0.00', '97.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210695', '0.00', '97.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210696', '0.00', '97.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210697', '0.00', '97.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210698', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210699', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210700', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210701', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210702', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210703', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210704', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210705', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210706', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210707', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210708', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210709', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210710', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210711', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210712', '0.00', '100.00', '1000.00', '0.00', '0.00');
INSERT INTO `user_account` VALUES ('210713', '0.00', '99.00', '1000.00', '0.00', '0.00');
INSERT INTO `user_account` VALUES ('210714', '0.00', '99.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210715', '0.00', '99.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210716', '0.00', '99.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210717', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210718', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210719', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210720', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210721', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210722', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210723', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210724', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210725', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210726', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210727', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210728', '0.00', '98.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210729', '0.00', '98.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210730', '0.00', '98.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210731', '0.00', '98.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210732', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210733', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210734', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210735', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210736', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210737', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210738', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210739', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210740', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210741', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210742', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210743', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210744', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210745', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210746', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210747', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210748', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210749', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210750', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210751', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210752', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210753', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210754', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210755', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210756', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210757', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210758', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210759', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210760', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210761', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210762', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210763', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210764', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210765', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210766', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210767', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210768', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210769', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210770', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210771', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210772', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210773', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210774', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210775', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210776', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210777', '0.00', '98.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210778', '0.00', '98.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210779', '0.00', '98.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210780', '0.00', '98.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210781', '0.00', '99.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210782', '0.00', '99.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210783', '0.00', '99.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210784', '0.00', '99.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210785', '0.00', '99.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210786', '0.00', '99.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210787', '0.00', '99.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210788', '0.00', '99.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210789', '0.00', '99.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210790', '0.00', '99.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210791', '0.00', '99.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210792', '0.00', '99.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210793', '0.00', '98.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210794', '0.00', '98.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210795', '0.00', '98.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210796', '0.00', '98.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210797', '0.00', '99.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210798', '0.00', '99.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210799', '0.00', '99.00', '1000.00', '0.00', '0.00');
INSERT INTO `user_account` VALUES ('210800', '0.00', '99.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210801', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210802', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210803', '0.00', '100.00', '1000.00', '0.00', '0.00');
INSERT INTO `user_account` VALUES ('210804', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210805', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210806', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210807', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210808', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210809', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210810', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210811', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210812', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210813', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210814', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210815', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210816', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210817', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210818', '0.00', '99.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210819', '0.00', '99.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210820', '0.00', '99.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210821', '0.00', '99.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210822', '0.00', '100.00', '1000.00', '100.00', '0.00');
INSERT INTO `user_account` VALUES ('210823', '0.00', '100.00', '1000.00', '100.00', '0.00');

-- ----------------------------
-- Table structure for user_activity
-- ----------------------------
DROP TABLE IF EXISTS `user_activity`;
CREATE TABLE `user_activity` (
  `activityid` varchar(50) NOT NULL COMMENT '活动代码',
  `activityname` varchar(100) DEFAULT NULL COMMENT '活动名称',
  `activitymark` varchar(2000) DEFAULT NULL COMMENT '活动说明',
  `addtime` datetime DEFAULT NULL COMMENT '添加时间',
  `begintime` datetime DEFAULT NULL COMMENT '有效期开始时间',
  `endtime` datetime DEFAULT NULL COMMENT '有效期结束时间',
  `status` char(1) DEFAULT '1' COMMENT '0不可用1可用',
  PRIMARY KEY (`activityid`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='用户活动表';

-- ----------------------------
-- Records of user_activity
-- ----------------------------
INSERT INTO `user_activity` VALUES ('20181001_1031TOP20DAILY', '每日排行20奖励', '今日榜--- 只显示前20名玩家信息\n\n第1名288钻、第2名188钻、第3名88钻、第4-20名66七豆', '2018-09-20 17:40:40', '2018-10-01 00:00:00', '2018-10-31 23:59:59', '1');
INSERT INTO `user_activity` VALUES ('20181001_1031TOP50TOTAL', '20181001到20181031总排行50奖励', '总战榜--只显示前50名玩家信息\r\n第1名小米电视，第2名1888钻、第3名888钻，第4-10名800七豆、11-20名500七豆、21-50名300七豆', '2018-09-20 17:44:52', '2018-10-01 00:00:00', '2018-10-31 23:59:59', '1');

-- ----------------------------
-- Table structure for user_activity_log
-- ----------------------------
DROP TABLE IF EXISTS `user_activity_log`;
CREATE TABLE `user_activity_log` (
  `logid` varchar(50) NOT NULL COMMENT 'ID',
  `activityid` varchar(50) DEFAULT NULL COMMENT '活动代码',
  `userid` int(11) DEFAULT NULL COMMENT '用户id',
  `moneytype` char(2) DEFAULT NULL COMMENT '账户类型VD钻石VG金币VQ七乐币',
  `moneynum` double(10,2) DEFAULT '0.00' COMMENT '账户值',
  `addtime` datetime DEFAULT NULL COMMENT '添加时间',
  PRIMARY KEY (`logid`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='用户活动表日志';

-- ----------------------------
-- Records of user_activity_log
-- ----------------------------

-- ----------------------------
-- Table structure for user_info
-- ----------------------------
DROP TABLE IF EXISTS `user_info`;
CREATE TABLE `user_info` (
  `userid` int(11) NOT NULL COMMENT '玩家Id',
  `useraccount` varchar(50) COLLATE utf8mb4_bin DEFAULT NULL COMMENT '玩家账号',
  `pw` varchar(50) COLLATE utf8mb4_bin DEFAULT NULL COMMENT '玩家密码',
  `nickname` varchar(50) COLLATE utf8mb4_bin DEFAULT NULL COMMENT '玩家昵称',
  `gender` char(1) COLLATE utf8mb4_bin DEFAULT NULL COMMENT '玩家性别',
  `email` varchar(50) COLLATE utf8mb4_bin DEFAULT NULL COMMENT '玩家邮箱',
  `mobile` varchar(15) COLLATE utf8mb4_bin DEFAULT NULL COMMENT '手机号码',
  `addtime` datetime DEFAULT NULL COMMENT '注册时间',
  `status` char(1) COLLATE utf8mb4_bin DEFAULT NULL COMMENT '玩家状态',
  `isname` char(1) COLLATE utf8mb4_bin DEFAULT NULL COMMENT '是否实名',
  `realname` varchar(30) COLLATE utf8mb4_bin DEFAULT NULL COMMENT '玩家真实姓名',
  `idcard` varchar(20) COLLATE utf8mb4_bin DEFAULT NULL COMMENT '玩家身份证号',
  `refereeid` int(11) DEFAULT '0' COMMENT '推荐人Id(用户ID)',
  `agentid` int(11) DEFAULT '0' COMMENT '代理商ID)',
  `keystring` varchar(50) COLLATE utf8mb4_bin DEFAULT NULL COMMENT '唯一字符',
  `viplevel` varchar(10) COLLATE utf8mb4_bin DEFAULT NULL COMMENT 'VIP级别',
  `picfile` varchar(500) COLLATE utf8mb4_bin DEFAULT NULL COMMENT '图像地址',
  `logintime` datetime DEFAULT NULL COMMENT '登录时间',
  `loginip` varchar(20) COLLATE utf8mb4_bin DEFAULT NULL COMMENT '登录IP',
  `usertype` char(1) COLLATE utf8mb4_bin DEFAULT '1' COMMENT '1正常玩家2测试玩家',
  `lv` int(11) DEFAULT '0' COMMENT '玩家等级',
  `isFirstLogon` int(255) DEFAULT '1' COMMENT '表示玩家是否是首次登陆的标志',
  PRIMARY KEY (`userid`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_bin COMMENT='玩家信息表';

-- ----------------------------
-- Records of user_info
-- ----------------------------
INSERT INTO `user_info` VALUES ('210001', 'u_210001', 'Q++sYsheZmo=', '游客404988', null, null, null, '2018-09-22 16:31:12', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210002', 'u_210002', 'Q++sYsheZmo=', '游客893969', null, null, null, '2018-09-22 16:31:13', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210003', 'u_210003', 'Q++sYsheZmo=', '游客409849', null, null, null, '2018-09-22 16:31:14', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210004', 'u_210004', 'Q++sYsheZmo=', '游客421102', null, null, null, '2018-09-22 16:31:15', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210005', 'u_210005', 'Q++sYsheZmo=', '游客185035', null, null, null, '2018-09-22 16:34:50', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210006', 'u_210006', 'Q++sYsheZmo=', '游客244721', null, null, null, '2018-09-22 16:38:37', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210007', 'u_210007', 'Q++sYsheZmo=', '游客172961', null, null, null, '2018-09-22 16:38:38', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210008', 'u_210008', 'Q++sYsheZmo=', '游客935322', null, null, null, '2018-09-22 16:38:39', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210009', 'u_210009', 'Q++sYsheZmo=', '游客199422', null, null, null, '2018-09-22 16:38:40', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210010', 'u_210010', 'Q++sYsheZmo=', '游客760626', null, null, null, '2018-09-22 16:39:32', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '1');
INSERT INTO `user_info` VALUES ('210011', 'u_210011', 'Q++sYsheZmo=', '游客255573', null, null, null, '2018-09-22 16:40:25', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210012', 'u_210012', 'Q++sYsheZmo=', '游客838209', null, null, null, '2018-09-22 16:40:26', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210013', 'u_210013', 'Q++sYsheZmo=', '游客273502', null, null, null, '2018-09-22 16:40:27', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210014', 'u_210014', 'Q++sYsheZmo=', '游客254961', null, null, null, '2018-09-22 16:40:28', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210015', 'u_210015', 'Q++sYsheZmo=', '游客490217', null, null, null, '2018-09-22 16:42:04', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '1');
INSERT INTO `user_info` VALUES ('210016', 'u_210016', 'Q++sYsheZmo=', '游客943937', null, null, null, '2018-09-22 16:42:04', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210017', 'u_210017', 'Q++sYsheZmo=', '游客675978', null, null, null, '2018-09-22 16:43:34', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210018', 'u_210018', 'Q++sYsheZmo=', '游客427540', null, null, null, '2018-09-22 16:43:35', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210019', 'u_210019', 'Q++sYsheZmo=', '游客170888', null, null, null, '2018-09-22 16:43:36', null, null, null, null, '0', '10001', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210020', 'u_210020', 'Q++sYsheZmo=', '游客852049', null, null, null, '2018-09-22 16:43:37', null, null, null, null, '0', '10001', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210021', 'u_210021', 'Q++sYsheZmo=', '游客661780', null, null, null, '2018-09-22 16:50:11', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '1');
INSERT INTO `user_info` VALUES ('210022', 'u_210022', 'Q++sYsheZmo=', '游客652793', null, null, null, '2018-09-22 16:57:04', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210023', 'u_210023', 'Q++sYsheZmo=', '游客208203', null, null, null, '2018-09-22 16:57:05', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210024', 'u_210024', 'Q++sYsheZmo=', '游客239528', null, null, null, '2018-09-22 16:57:06', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210025', 'u_210025', 'Q++sYsheZmo=', '游客594101', null, null, null, '2018-09-22 16:57:07', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210026', 'u_210026', 'Q++sYsheZmo=', '游客543242', null, null, null, '2018-09-22 17:08:58', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210027', 'u_210027', 'Q++sYsheZmo=', '游客229549', null, null, null, '2018-09-22 17:09:46', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210028', 'u_210028', 'Q++sYsheZmo=', '游客648895', null, null, null, '2018-09-22 17:09:47', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210029', 'u_210029', 'Q++sYsheZmo=', '游客927742', null, null, null, '2018-09-22 17:09:48', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210030', 'u_210030', 'Q++sYsheZmo=', '游客903725', null, null, null, '2018-09-22 17:09:49', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210031', 'u_210031', 'Q++sYsheZmo=', '游客567954', null, null, null, '2018-09-22 17:14:38', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210032', 'u_210032', 'Q++sYsheZmo=', '游客306240', null, null, null, '2018-09-22 17:14:52', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210033', 'u_210033', 'Q++sYsheZmo=', '游客469443', null, null, null, '2018-09-22 17:15:00', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210034', 'u_210034', 'Q++sYsheZmo=', '游客701471', null, null, null, '2018-09-22 17:15:01', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210035', 'u_210035', 'Q++sYsheZmo=', '游客329614', null, null, null, '2018-09-22 17:16:12', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210036', 'u_210036', 'Q++sYsheZmo=', '游客400397', null, null, null, '2018-09-22 17:18:34', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210037', 'u_210037', 'Q++sYsheZmo=', '游客643533', null, null, null, '2018-09-22 17:19:07', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210038', 'u_210038', 'Q++sYsheZmo=', '游客862634', null, null, null, '2018-09-22 17:19:13', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210039', 'u_210039', 'Q++sYsheZmo=', '游客705717', null, null, null, '2018-09-22 17:19:14', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210040', 'u_210040', 'Q++sYsheZmo=', '游客809415', null, null, null, '2018-09-22 17:19:14', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210041', 'u_210041', 'Q++sYsheZmo=', '游客337464', null, null, null, '2018-09-22 17:19:15', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210042', 'u_210042', 'Q++sYsheZmo=', '游客887232', null, null, null, '2018-09-22 17:20:18', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210043', 'u_210043', 'Q++sYsheZmo=', '游客299232', null, null, null, '2018-09-22 17:20:32', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210044', 'u_210044', 'Q++sYsheZmo=', '游客533059', null, null, null, '2018-09-22 17:21:52', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210045', 'u_210045', 'Q++sYsheZmo=', '游客486398', null, null, null, '2018-09-22 17:23:02', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210046', 'u_210046', 'Q++sYsheZmo=', '游客205240', null, null, null, '2018-09-22 17:23:17', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210047', 'u_210047', 'Q++sYsheZmo=', '游客955122', null, null, null, '2018-09-22 17:23:18', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210048', 'u_210048', 'Q++sYsheZmo=', '游客740739', null, null, null, '2018-09-22 17:23:19', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210049', 'u_210049', 'Q++sYsheZmo=', '游客259971', null, null, null, '2018-09-22 17:23:19', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210050', 'u_210050', 'Q++sYsheZmo=', '游客718603', null, null, null, '2018-09-22 17:23:37', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210051', 'u_210051', 'Q++sYsheZmo=', '游客640767', null, null, null, '2018-09-22 17:23:59', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210052', 'u_210052', 'Q++sYsheZmo=', '游客488256', null, null, null, '2018-09-22 17:25:34', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210053', 'u_210053', 'Q++sYsheZmo=', '游客125182', null, null, null, '2018-09-22 17:26:04', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210054', 'u_210054', 'Q++sYsheZmo=', '游客976346', null, null, null, '2018-09-22 17:26:05', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210055', 'u_210055', 'Q++sYsheZmo=', '游客228892', null, null, null, '2018-09-22 17:26:06', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210056', 'u_210056', 'Q++sYsheZmo=', '游客476112', null, null, null, '2018-09-22 17:26:07', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210057', 'u_210057', 'Q++sYsheZmo=', '游客219272', null, null, null, '2018-09-22 17:28:45', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210058', 'u_210058', 'Q++sYsheZmo=', '游客872761', null, null, null, '2018-09-22 17:28:46', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210059', 'u_210059', 'Q++sYsheZmo=', '游客320534', null, null, null, '2018-09-22 17:28:46', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210060', 'u_210060', 'Q++sYsheZmo=', '游客242079', null, null, null, '2018-09-22 17:28:47', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210061', 'u_210061', 'Q++sYsheZmo=', '游客159197', null, null, null, '2018-09-22 17:29:42', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210062', 'u_210062', 'Q++sYsheZmo=', '游客168308', null, null, null, '2018-09-22 17:29:43', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210063', 'u_210063', 'Q++sYsheZmo=', '游客486087', null, null, null, '2018-09-22 17:29:45', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210064', 'u_210064', 'Q++sYsheZmo=', '游客414921', null, null, null, '2018-09-22 17:29:46', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210065', 'u_210065', 'Q++sYsheZmo=', '游客378481', null, null, null, '2018-09-22 17:33:57', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210066', 'u_210066', 'Q++sYsheZmo=', '游客846990', null, null, null, '2018-09-22 17:39:41', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210067', 'u_210067', 'Q++sYsheZmo=', '游客280182', null, null, null, '2018-09-22 17:40:03', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210068', 'u_210068', 'Q++sYsheZmo=', '游客441953', null, null, null, '2018-09-22 17:40:17', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210069', 'u_210069', 'Q++sYsheZmo=', '游客139569', null, null, null, '2018-09-22 17:41:28', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210070', 'u_210070', 'Q++sYsheZmo=', '游客818916', null, null, null, '2018-09-22 17:41:29', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210071', 'u_210071', 'Q++sYsheZmo=', '游客318076', null, null, null, '2018-09-22 17:41:30', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210072', 'u_210072', 'Q++sYsheZmo=', '游客879120', null, null, null, '2018-09-22 17:41:31', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210073', 'u_210073', 'Q++sYsheZmo=', '游客484791', null, null, null, '2018-09-22 17:42:30', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210074', 'u_210074', 'Q++sYsheZmo=', '游客881327', null, null, null, '2018-09-22 17:42:31', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210075', 'u_210075', 'Q++sYsheZmo=', '游客784633', null, null, null, '2018-09-22 17:42:32', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210076', 'u_210076', 'Q++sYsheZmo=', '游客471853', null, null, null, '2018-09-22 17:42:45', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210077', 'u_210077', 'Q++sYsheZmo=', '游客176823', null, null, null, '2018-09-22 17:58:27', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210078', 'u_210078', 'Q++sYsheZmo=', '游客528658', null, null, null, '2018-09-22 17:58:28', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210079', 'u_210079', 'Q++sYsheZmo=', '游客462062', null, null, null, '2018-09-22 17:58:29', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210080', 'u_210080', 'Q++sYsheZmo=', '游客562713', null, null, null, '2018-09-22 17:58:30', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210081', 'u_210081', 'Q++sYsheZmo=', '游客549625', null, null, null, '2018-09-22 18:01:39', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210082', 'u_210082', 'Q++sYsheZmo=', '游客604512', null, null, null, '2018-09-22 18:01:40', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210083', 'u_210083', 'Q++sYsheZmo=', '游客806251', null, null, null, '2018-09-22 18:19:52', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210084', 'u_210084', 'Q++sYsheZmo=', '游客271000', null, null, null, '2018-09-22 18:20:20', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210085', 'u_210085', 'Q++sYsheZmo=', '游客748720', null, null, null, '2018-09-22 18:20:21', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210086', 'u_210086', 'Q++sYsheZmo=', '游客738411', null, null, null, '2018-09-22 18:20:24', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210087', 'u_210087', 'Q++sYsheZmo=', '游客959310', null, null, null, '2018-09-22 18:28:15', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210088', 'u_210088', 'Q++sYsheZmo=', '游客140388', null, null, null, '2018-09-22 18:28:15', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210089', 'u_210089', 'Q++sYsheZmo=', '游客581930', null, null, null, '2018-09-22 18:28:16', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210090', 'u_210090', 'Q++sYsheZmo=', '游客661904', null, null, null, '2018-09-22 18:28:17', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210091', 'u_210091', 'Q++sYsheZmo=', '游客374711', null, null, null, '2018-09-22 19:03:15', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210092', 'u_210092', 'Q++sYsheZmo=', '游客454208', null, null, null, '2018-09-22 19:04:18', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210093', 'u_210093', 'Q++sYsheZmo=', '游客676722', null, null, null, '2018-09-22 19:04:49', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210094', 'u_210094', 'Q++sYsheZmo=', '游客657810', null, null, null, '2018-09-22 19:06:17', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210095', 'u_210095', 'Q++sYsheZmo=', '游客506716', null, null, null, '2018-09-22 19:09:47', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210096', 'u_210096', 'Q++sYsheZmo=', '游客537490', null, null, null, '2018-09-22 19:12:38', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210097', 'u_210097', 'Q++sYsheZmo=', '游客216761', null, null, null, '2018-09-22 19:44:56', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210098', 'u_210098', 'Q++sYsheZmo=', '游客154733', null, null, null, '2018-09-22 19:44:58', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210099', 'u_210099', 'Q++sYsheZmo=', '游客911619', null, null, null, '2018-09-22 19:44:58', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210100', 'u_210100', 'Q++sYsheZmo=', '游客437525', null, null, null, '2018-09-22 19:45:00', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210101', 'u_210101', 'Q++sYsheZmo=', '游客764564', null, null, null, '2018-09-22 20:10:07', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210102', 'u_210102', 'Q++sYsheZmo=', '游客703305', null, null, null, '2018-09-22 20:10:20', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210103', 'u_210103', 'Q++sYsheZmo=', '游客572674', null, null, null, '2018-09-22 20:10:30', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210104', 'u_210104', 'Q++sYsheZmo=', '游客513697', null, null, null, '2018-09-22 20:10:31', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210105', 'u_210105', 'Q++sYsheZmo=', '游客797989', null, null, null, '2018-09-22 20:12:11', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210106', 'u_210106', 'Q++sYsheZmo=', '游客441603', null, null, null, '2018-09-22 20:12:12', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210107', 'u_210107', 'Q++sYsheZmo=', '游客827490', null, null, null, '2018-09-22 20:12:14', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210108', 'u_210108', 'Q++sYsheZmo=', '游客935739', null, null, null, '2018-09-22 20:12:14', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210109', 'u_210109', 'Q++sYsheZmo=', '游客146069', null, null, null, '2018-09-22 20:13:36', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210110', 'u_210110', 'Q++sYsheZmo=', '游客702562', null, null, null, '2018-09-22 20:13:37', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210111', 'u_210111', 'Q++sYsheZmo=', '游客765202', null, null, null, '2018-09-22 20:13:38', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210112', 'u_210112', 'Q++sYsheZmo=', '游客154895', null, null, null, '2018-09-22 20:13:39', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210113', 'u_210113', 'Q++sYsheZmo=', '游客897446', null, null, null, '2018-09-22 20:18:57', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210114', 'u_210114', 'Q++sYsheZmo=', '游客555043', null, null, null, '2018-09-22 20:18:57', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210115', 'u_210115', 'Q++sYsheZmo=', '游客831462', null, null, null, '2018-09-22 20:18:58', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210116', 'u_210116', 'Q++sYsheZmo=', '游客974076', null, null, null, '2018-09-22 20:18:59', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210117', 'u_210117', 'Q++sYsheZmo=', '游客499977', null, null, null, '2018-09-22 20:51:55', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210118', 'u_210118', 'Q++sYsheZmo=', '游客933012', null, null, null, '2018-09-22 20:51:56', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210119', 'u_210119', 'Q++sYsheZmo=', '游客700984', null, null, null, '2018-09-22 20:51:57', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210120', 'u_210120', 'Q++sYsheZmo=', '游客910507', null, null, null, '2018-09-22 20:51:57', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210121', 'u_210121', 'Q++sYsheZmo=', '游客385514', null, null, null, '2018-09-22 20:53:49', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210122', 'u_210122', 'Q++sYsheZmo=', '游客684129', null, null, null, '2018-09-22 20:53:50', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210123', 'u_210123', 'Q++sYsheZmo=', '游客883010', null, null, null, '2018-09-22 20:53:51', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210124', 'u_210124', 'Q++sYsheZmo=', '游客400108', null, null, null, '2018-09-22 20:53:52', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210125', 'u_210125', 'Q++sYsheZmo=', '游客593203', null, null, null, '2018-09-22 20:56:41', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210126', 'u_210126', 'Q++sYsheZmo=', '游客532394', null, null, null, '2018-09-22 20:56:42', '1', null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210127', 'u_210127', 'Q++sYsheZmo=', '游客230426', null, null, null, '2018-09-22 20:56:43', '1', null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210128', 'u_210128', 'Q++sYsheZmo=', '游客529966', null, null, null, '2018-09-22 20:56:44', '1', null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210129', 'u_210129', 'Q++sYsheZmo=', '游客420234', null, null, null, '2018-09-23 09:49:04', '1', null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210130', 'u_210130', 'Q++sYsheZmo=', '游客717750', null, null, null, '2018-09-23 09:50:30', '1', null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210131', 'u_210131', 'Q++sYsheZmo=', '游客797742', null, null, null, '2018-09-23 14:01:38', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210132', 'u_210132', 'Q++sYsheZmo=', '游客932325', null, null, null, '2018-09-23 14:01:51', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210133', 'u_210133', 'Q++sYsheZmo=', '游客264670', null, null, null, '2018-09-23 14:02:22', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210134', 'u_210134', 'Q++sYsheZmo=', '游客652389', null, null, null, '2018-09-23 14:02:23', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210135', 'u_210135', 'Q++sYsheZmo=', '游客533568', null, null, null, '2018-09-23 14:08:26', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210136', 'u_210136', 'Q++sYsheZmo=', '游客500120', null, null, null, '2018-09-23 14:08:26', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210137', 'u_210137', 'Q++sYsheZmo=', '游客296688', null, null, null, '2018-09-23 14:08:27', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210138', 'u_210138', 'Q++sYsheZmo=', '游客249550', null, null, null, '2018-09-23 14:08:28', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210139', 'u_210139', 'Q++sYsheZmo=', '游客338797', null, null, null, '2018-09-23 14:13:33', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210140', 'u_210140', 'Q++sYsheZmo=', '游客617954', null, null, null, '2018-09-23 14:13:34', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210141', 'u_210141', 'Q++sYsheZmo=', '游客521855', null, null, null, '2018-09-23 14:13:35', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210142', 'u_210142', 'Q++sYsheZmo=', '游客810443', null, null, null, '2018-09-23 14:13:36', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210143', 'u_210143', 'Q++sYsheZmo=', '游客310429', null, null, null, '2018-09-23 14:18:25', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210144', 'u_210144', 'Q++sYsheZmo=', '游客546103', null, null, null, '2018-09-23 14:18:26', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210145', 'u_210145', 'Q++sYsheZmo=', '游客414733', null, null, null, '2018-09-23 14:18:27', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210146', 'u_210146', 'Q++sYsheZmo=', '游客293390', null, null, null, '2018-09-23 14:18:28', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210147', 'u_210147', 'Q++sYsheZmo=', '游客807959', null, null, null, '2018-09-23 15:11:34', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210148', 'u_210148', 'Q++sYsheZmo=', '游客759061', null, null, null, '2018-09-23 15:11:52', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210149', 'u_210149', 'Q++sYsheZmo=', '游客455875', null, null, null, '2018-09-23 15:11:53', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210150', 'u_210150', 'Q++sYsheZmo=', '游客501493', null, null, null, '2018-09-23 15:11:54', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210151', 'u_210151', 'Q++sYsheZmo=', '游客330356', null, null, null, '2018-09-23 15:14:49', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210152', 'u_210152', 'Q++sYsheZmo=', '游客237609', null, null, null, '2018-09-23 15:14:50', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210153', 'u_210153', 'Q++sYsheZmo=', '游客296606', null, null, null, '2018-09-23 15:14:51', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210154', 'u_210154', 'Q++sYsheZmo=', '游客652991', null, null, null, '2018-09-23 15:14:52', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210155', 'u_210155', 'Q++sYsheZmo=', '游客601507', null, null, null, '2018-09-23 15:16:54', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210156', 'u_210156', 'Q++sYsheZmo=', '游客436376', null, null, null, '2018-09-23 15:16:55', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210157', 'u_210157', 'Q++sYsheZmo=', '游客816192', null, null, null, '2018-09-23 15:16:56', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210158', 'u_210158', 'Q++sYsheZmo=', '游客580518', null, null, null, '2018-09-23 15:16:57', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210159', 'u_210159', 'Q++sYsheZmo=', '游客807677', null, null, null, '2018-09-23 15:28:06', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210160', 'u_210160', 'Q++sYsheZmo=', '游客673570', null, null, null, '2018-09-23 15:28:07', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210161', 'u_210161', 'Q++sYsheZmo=', '游客333595', null, null, null, '2018-09-23 15:28:08', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210162', 'u_210162', 'Q++sYsheZmo=', '游客718576', null, null, null, '2018-09-23 15:28:09', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210163', 'u_210163', 'Q++sYsheZmo=', '游客857481', null, null, null, '2018-09-23 15:35:05', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210164', 'u_210164', 'Q++sYsheZmo=', '游客418367', null, null, null, '2018-09-23 15:35:05', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210165', 'u_210165', 'Q++sYsheZmo=', '游客553089', null, null, null, '2018-09-23 15:35:06', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210166', 'u_210166', 'Q++sYsheZmo=', '游客213708', null, null, null, '2018-09-23 15:35:07', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210167', 'u_210167', 'Q++sYsheZmo=', '游客195967', null, null, null, '2018-09-23 15:36:14', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210168', 'u_210168', 'Q++sYsheZmo=', '游客679381', null, null, null, '2018-09-23 15:37:00', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210169', 'u_210169', 'Q++sYsheZmo=', '游客746591', null, null, null, '2018-09-23 15:37:01', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210170', 'u_210170', 'Q++sYsheZmo=', '游客271592', null, null, null, '2018-09-23 15:37:02', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210171', 'u_210171', 'Q++sYsheZmo=', '游客967056', null, null, null, '2018-09-23 15:37:03', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210172', 'u_210172', 'Q++sYsheZmo=', '游客831519', null, null, null, '2018-09-23 15:38:20', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210173', 'u_210173', 'Q++sYsheZmo=', '游客346804', null, null, null, '2018-09-23 15:38:21', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210174', 'u_210174', 'Q++sYsheZmo=', '游客690735', null, null, null, '2018-09-23 15:38:22', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210175', 'u_210175', 'Q++sYsheZmo=', '游客949510', null, null, null, '2018-09-23 15:38:23', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210176', 'u_210176', 'Q++sYsheZmo=', '游客819301', null, null, null, '2018-09-23 15:38:37', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210177', 'u_210177', 'Q++sYsheZmo=', '游客373071', null, null, null, '2018-09-23 15:41:12', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210178', 'u_210178', 'Q++sYsheZmo=', '游客539734', null, null, null, '2018-09-23 15:43:08', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210179', 'u_210179', 'Q++sYsheZmo=', '游客252462', null, null, null, '2018-09-23 15:43:37', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210180', 'u_210180', 'Q++sYsheZmo=', '游客194198', null, null, null, '2018-09-23 15:44:08', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210181', 'u_210181', 'Q++sYsheZmo=', '游客743687', null, null, null, '2018-09-23 15:44:08', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210182', 'u_210182', 'Q++sYsheZmo=', '游客650317', null, null, null, '2018-09-23 15:49:01', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210183', 'u_210183', 'Q++sYsheZmo=', '游客488844', null, null, null, '2018-09-23 15:49:23', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210184', 'u_210184', 'Q++sYsheZmo=', '游客488542', null, null, null, '2018-09-23 15:49:24', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210185', 'u_210185', 'Q++sYsheZmo=', '游客527777', null, null, null, '2018-09-23 15:51:11', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210186', 'u_210186', 'Q++sYsheZmo=', '游客515647', null, null, null, '2018-09-23 15:52:10', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210187', 'u_210187', 'Q++sYsheZmo=', '游客893943', null, null, null, '2018-09-23 15:52:11', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210188', 'u_210188', 'Q++sYsheZmo=', '游客271467', null, null, null, '2018-09-23 15:52:11', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210189', 'u_210189', 'Q++sYsheZmo=', '游客799070', null, null, null, '2018-09-23 15:52:13', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210190', 'u_210190', 'Q++sYsheZmo=', '游客883741', null, null, null, '2018-09-23 15:54:43', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210191', 'u_210191', 'Q++sYsheZmo=', '游客604866', null, null, null, '2018-09-23 15:54:44', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210192', 'u_210192', 'Q++sYsheZmo=', '游客152079', null, null, null, '2018-09-23 15:54:46', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210193', 'u_210193', 'Q++sYsheZmo=', '游客194648', null, null, null, '2018-09-23 16:00:43', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210194', 'u_210194', 'Q++sYsheZmo=', '游客959699', null, null, null, '2018-09-23 16:00:47', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210195', 'u_210195', 'Q++sYsheZmo=', '游客457030', null, null, null, '2018-09-23 16:01:30', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210196', 'u_210196', 'Q++sYsheZmo=', '游客886583', null, null, null, '2018-09-23 16:17:19', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210197', 'u_210197', 'Q++sYsheZmo=', '游客162015', null, null, null, '2018-09-23 16:17:26', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210198', 'u_210198', 'Q++sYsheZmo=', '游客444738', null, null, null, '2018-09-23 16:18:03', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210199', 'u_210199', 'Q++sYsheZmo=', '游客123534', null, null, null, '2018-09-23 16:18:19', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210200', 'u_210200', 'Q++sYsheZmo=', '游客421823', null, null, null, '2018-09-23 16:18:40', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210201', 'u_210201', 'Q++sYsheZmo=', '游客391505', null, null, null, '2018-09-23 16:28:18', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210202', 'u_210202', 'Q++sYsheZmo=', '游客762993', null, null, null, '2018-09-23 16:28:28', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210203', 'u_210203', 'Q++sYsheZmo=', '游客523220', null, null, null, '2018-09-23 16:28:38', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210204', 'u_210204', 'Q++sYsheZmo=', '游客367708', null, null, null, '2018-09-23 16:28:48', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210205', 'u_210205', 'Q++sYsheZmo=', '游客603501', null, null, null, '2018-09-23 16:29:01', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210206', 'u_210206', 'Q++sYsheZmo=', '游客784930', null, null, null, '2018-09-23 16:30:35', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210207', 'u_210207', 'Q++sYsheZmo=', '游客298278', null, null, null, '2018-09-23 16:30:43', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210208', 'u_210208', 'Q++sYsheZmo=', '游客225894', null, null, null, '2018-09-23 16:30:44', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210209', 'u_210209', 'Q++sYsheZmo=', '游客603814', null, null, null, '2018-09-23 16:31:54', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210210', 'u_210210', 'Q++sYsheZmo=', '游客353899', null, null, null, '2018-09-23 16:32:19', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210211', 'u_210211', 'Q++sYsheZmo=', '游客599114', null, null, null, '2018-09-23 16:33:52', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210212', 'u_210212', 'Q++sYsheZmo=', '游客386250', null, null, null, '2018-09-23 16:33:53', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210213', 'u_210213', 'Q++sYsheZmo=', '游客868851', null, null, null, '2018-09-23 16:33:54', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210214', 'u_210214', 'Q++sYsheZmo=', '游客413016', null, null, null, '2018-09-23 16:33:55', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210215', 'u_210215', 'Q++sYsheZmo=', '游客220829', null, null, null, '2018-09-23 16:33:56', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210216', 'u_210216', 'Q++sYsheZmo=', '游客716022', null, null, null, '2018-09-23 16:36:53', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210217', 'u_210217', 'Q++sYsheZmo=', '游客179703', null, null, null, '2018-09-23 16:37:51', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210218', 'u_210218', 'Q++sYsheZmo=', '游客927366', null, null, null, '2018-09-23 16:38:40', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210219', 'u_210219', 'Q++sYsheZmo=', '游客573415', null, null, null, '2018-09-23 16:39:24', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210220', 'u_210220', 'Q++sYsheZmo=', '游客885468', null, null, null, '2018-09-23 16:40:32', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210221', 'u_210221', 'Q++sYsheZmo=', '游客666016', null, null, null, '2018-09-23 16:41:43', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210222', 'u_210222', 'Q++sYsheZmo=', '游客723311', null, null, null, '2018-09-23 16:52:01', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210223', 'u_210223', 'Q++sYsheZmo=', '游客732100', null, null, null, '2018-09-23 16:52:04', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210224', 'u_210224', 'Q++sYsheZmo=', '游客877063', null, null, null, '2018-09-23 16:52:11', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210225', 'u_210225', 'Q++sYsheZmo=', '游客588785', null, null, null, '2018-09-23 16:52:12', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210226', 'u_210226', 'Q++sYsheZmo=', '游客654179', null, null, null, '2018-09-23 16:57:26', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210227', 'u_210227', 'Q++sYsheZmo=', '游客381101', null, null, null, '2018-09-23 16:57:27', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210228', 'u_210228', 'Q++sYsheZmo=', '游客677903', null, null, null, '2018-09-23 16:57:27', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210229', 'u_210229', 'Q++sYsheZmo=', '游客874046', null, null, null, '2018-09-23 16:57:28', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210230', 'u_210230', 'Q++sYsheZmo=', '游客233679', null, null, null, '2018-09-23 17:21:25', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210231', 'u_210231', 'Q++sYsheZmo=', '游客664826', null, null, null, '2018-09-24 16:11:18', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210232', 'u_210232', 'Q++sYsheZmo=', '游客214761', null, null, null, '2018-09-24 16:11:19', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210233', 'u_210233', 'Q++sYsheZmo=', '游客881081', null, null, null, '2018-09-24 16:11:24', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210234', 'u_210234', 'Q++sYsheZmo=', '游客545847', null, null, null, '2018-09-24 16:11:37', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210235', 'u_210235', 'Q++sYsheZmo=', '游客560199', null, null, null, '2018-09-24 16:16:52', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210236', 'u_210236', 'Q++sYsheZmo=', '游客214748', null, null, null, '2018-09-24 16:16:53', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210237', 'u_210237', 'Q++sYsheZmo=', '游客940843', null, null, null, '2018-09-24 16:17:29', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210238', 'u_210238', 'Q++sYsheZmo=', '游客437899', null, null, null, '2018-09-24 16:17:31', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210239', 'u_210239', 'Q++sYsheZmo=', '游客635573', null, null, null, '2018-09-24 16:17:33', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210240', 'u_210240', 'Q++sYsheZmo=', '游客627379', null, null, null, '2018-09-24 16:17:36', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210241', 'u_210241', 'Q++sYsheZmo=', '游客446869', null, null, null, '2018-09-24 16:22:01', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210242', 'u_210242', 'Q++sYsheZmo=', '游客157071', null, null, null, '2018-09-24 16:22:01', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210243', 'u_210243', 'Q++sYsheZmo=', '游客534744', null, null, null, '2018-09-24 16:22:03', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210244', 'u_210244', 'Q++sYsheZmo=', '游客672807', null, null, null, '2018-09-24 16:22:03', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210245', 'u_210245', 'Q++sYsheZmo=', '游客546161', null, null, null, '2018-09-24 16:31:16', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210246', 'u_210246', 'Q++sYsheZmo=', '游客260310', null, null, null, '2018-09-24 16:31:17', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210247', 'u_210247', 'Q++sYsheZmo=', '游客877311', null, null, null, '2018-09-24 16:31:18', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210248', 'u_210248', 'Q++sYsheZmo=', '游客814973', null, null, null, '2018-09-24 16:31:18', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210249', 'u_210249', 'Q++sYsheZmo=', '游客812047', null, null, null, '2018-09-24 16:36:51', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210250', 'u_210250', 'Q++sYsheZmo=', '游客421590', null, null, null, '2018-09-24 16:36:52', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210251', 'u_210251', 'Q++sYsheZmo=', '游客293269', null, null, null, '2018-09-24 16:36:53', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210252', 'u_210252', 'Q++sYsheZmo=', '游客354389', null, null, null, '2018-09-24 16:36:54', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210253', 'u_210253', 'Q++sYsheZmo=', '游客646913', null, null, null, '2018-09-24 16:47:19', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210254', 'u_210254', 'Q++sYsheZmo=', '游客600371', null, null, null, '2018-09-24 16:47:20', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210255', 'u_210255', 'Q++sYsheZmo=', '游客492122', null, null, null, '2018-09-24 16:47:21', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210256', 'u_210256', 'Q++sYsheZmo=', '游客342095', null, null, null, '2018-09-24 16:52:07', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210257', 'u_210257', 'Q++sYsheZmo=', '游客277020', null, null, null, '2018-09-24 16:52:08', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210258', 'u_210258', 'Q++sYsheZmo=', '游客592970', null, null, null, '2018-09-24 16:52:09', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210259', 'u_210259', 'Q++sYsheZmo=', '游客558303', null, null, null, '2018-09-24 16:52:10', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210260', 'u_210260', 'Q++sYsheZmo=', '游客751557', null, null, null, '2018-09-24 16:55:28', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210261', 'u_210261', 'Q++sYsheZmo=', '游客250173', null, null, null, '2018-09-24 16:56:06', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210262', 'u_210262', 'Q++sYsheZmo=', '游客341107', null, null, null, '2018-09-24 16:56:07', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210263', 'u_210263', 'Q++sYsheZmo=', '游客264767', null, null, null, '2018-09-24 16:56:08', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210264', 'u_210264', 'Q++sYsheZmo=', '游客581924', null, null, null, '2018-09-24 16:56:10', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210265', 'u_210265', 'Q++sYsheZmo=', '游客196328', null, null, null, '2018-09-24 16:59:00', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210266', 'u_210266', 'Q++sYsheZmo=', '游客869890', null, null, null, '2018-09-24 16:59:01', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210267', 'u_210267', 'Q++sYsheZmo=', '游客959296', null, null, null, '2018-09-24 16:59:02', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210268', 'u_210268', 'Q++sYsheZmo=', '游客790824', null, null, null, '2018-09-24 16:59:03', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210269', 'u_210269', 'Q++sYsheZmo=', '游客518053', null, null, null, '2018-09-24 17:26:40', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210270', 'u_210270', 'Q++sYsheZmo=', '游客832687', null, null, null, '2018-09-24 18:01:22', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210271', 'u_210271', 'Q++sYsheZmo=', '游客908097', null, null, null, '2018-09-24 18:03:36', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210272', 'u_210272', 'Q++sYsheZmo=', '游客461646', null, null, null, '2018-09-24 18:06:42', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210273', 'u_210273', 'Q++sYsheZmo=', '游客906760', null, null, null, '2018-09-24 18:07:09', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210274', 'u_210274', 'Q++sYsheZmo=', '游客491139', null, null, null, '2018-09-24 18:11:17', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210275', 'u_210275', 'Q++sYsheZmo=', '游客724075', null, null, null, '2018-09-24 18:11:18', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210276', 'u_210276', 'Q++sYsheZmo=', '游客122040', null, null, null, '2018-09-24 18:11:23', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210277', 'u_210277', 'Q++sYsheZmo=', '游客469621', null, null, null, '2018-09-24 18:11:46', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210278', 'u_210278', 'Q++sYsheZmo=', '游客577287', null, null, null, '2018-09-24 18:17:12', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210279', 'u_210279', 'Q++sYsheZmo=', '游客527721', null, null, null, '2018-09-24 18:17:13', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210280', 'u_210280', 'Q++sYsheZmo=', '游客160980', null, null, null, '2018-09-24 18:17:14', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210281', 'u_210281', 'Q++sYsheZmo=', '游客242482', null, null, null, '2018-09-24 18:17:15', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210282', 'u_210282', 'Q++sYsheZmo=', '游客213432', null, null, null, '2018-09-24 18:35:57', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210283', 'u_210283', 'Q++sYsheZmo=', '游客448491', null, null, null, '2018-09-24 18:35:58', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210284', 'u_210284', 'Q++sYsheZmo=', '游客452455', null, null, null, '2018-09-24 18:35:58', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210285', 'u_210285', 'Q++sYsheZmo=', '游客475878', null, null, null, '2018-09-24 18:35:59', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210286', 'u_210286', 'Q++sYsheZmo=', '游客407983', null, null, null, '2018-09-24 18:37:30', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210287', 'u_210287', 'Q++sYsheZmo=', '游客227489', null, null, null, '2018-09-24 18:37:42', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210288', 'u_210288', 'Q++sYsheZmo=', '游客901361', null, null, null, '2018-09-24 18:37:43', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210289', 'u_210289', 'Q++sYsheZmo=', '游客699429', null, null, null, '2018-09-24 18:37:45', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210290', 'u_210290', 'Q++sYsheZmo=', '游客150606', null, null, null, '2018-09-24 18:39:53', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210291', 'u_210291', 'Q++sYsheZmo=', '游客230580', null, null, null, '2018-09-24 18:39:54', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210292', 'u_210292', 'Q++sYsheZmo=', '游客586965', null, null, null, '2018-09-24 18:39:55', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210293', 'u_210293', 'Q++sYsheZmo=', '游客801963', null, null, null, '2018-09-24 18:39:56', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210294', 'u_210294', 'Q++sYsheZmo=', '游客279336', null, null, null, '2018-09-24 19:13:58', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210295', 'u_210295', 'Q++sYsheZmo=', '游客502873', null, null, null, '2018-09-24 19:14:19', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210296', 'u_210296', 'Q++sYsheZmo=', '游客191475', null, null, null, '2018-09-24 19:14:20', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210297', 'u_210297', 'Q++sYsheZmo=', '游客310080', null, null, null, '2018-09-24 19:14:21', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210298', 'u_210298', 'Q++sYsheZmo=', '游客507862', null, null, null, '2018-09-24 19:18:45', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210299', 'u_210299', 'Q++sYsheZmo=', '游客803739', null, null, null, '2018-09-24 19:18:46', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210300', 'u_210300', 'Q++sYsheZmo=', '游客626936', null, null, null, '2018-09-24 19:19:59', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210301', 'u_210301', 'Q++sYsheZmo=', '游客121839', null, null, null, '2018-09-24 19:20:00', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210302', 'u_210302', 'Q++sYsheZmo=', '游客208817', null, null, null, '2018-09-24 19:20:01', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210303', 'u_210303', 'Q++sYsheZmo=', '游客726064', null, null, null, '2018-09-24 19:20:02', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210304', 'u_210304', 'Q++sYsheZmo=', '游客617312', null, null, null, '2018-09-24 19:21:57', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210305', 'u_210305', 'Q++sYsheZmo=', '游客321434', null, null, null, '2018-09-24 19:21:58', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210306', 'u_210306', 'Q++sYsheZmo=', '游客724354', null, null, null, '2018-09-24 19:21:59', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210307', 'u_210307', 'Q++sYsheZmo=', '游客160572', null, null, null, '2018-09-24 19:22:00', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210308', 'u_210308', 'Q++sYsheZmo=', '游客892056', null, null, null, '2018-09-24 19:26:28', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210309', 'u_210309', 'Q++sYsheZmo=', '游客571848', null, null, null, '2018-09-24 19:26:28', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210310', 'u_210310', 'Q++sYsheZmo=', '游客632968', null, null, null, '2018-09-24 19:26:29', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210311', 'u_210311', 'Q++sYsheZmo=', '游客733929', null, null, null, '2018-09-24 19:26:30', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210312', 'u_210312', 'Q++sYsheZmo=', '游客549759', null, null, null, '2018-09-24 19:30:04', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210313', 'u_210313', 'Q++sYsheZmo=', '游客450611', null, null, null, '2018-09-24 19:30:05', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210314', 'u_210314', 'Q++sYsheZmo=', '游客166903', null, null, null, '2018-09-24 19:30:06', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210315', 'u_210315', 'Q++sYsheZmo=', '游客673957', null, null, null, '2018-09-24 19:30:16', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210316', 'u_210316', 'Q++sYsheZmo=', '游客605732', null, null, null, '2018-09-24 19:35:53', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210317', 'u_210317', 'Q++sYsheZmo=', '游客253898', null, null, null, '2018-09-24 19:35:54', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210318', 'u_210318', 'Q++sYsheZmo=', '游客868471', null, null, null, '2018-09-24 19:35:55', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210319', 'u_210319', 'Q++sYsheZmo=', '游客150811', null, null, null, '2018-09-24 19:35:55', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210320', 'u_210320', 'Q++sYsheZmo=', '游客932755', null, null, null, '2018-09-24 19:46:06', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210321', 'u_210321', 'Q++sYsheZmo=', '游客443774', null, null, null, '2018-09-24 19:46:07', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210322', 'u_210322', 'Q++sYsheZmo=', '游客629580', null, null, null, '2018-09-24 19:46:08', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210323', 'u_210323', 'Q++sYsheZmo=', '游客765012', null, null, null, '2018-09-24 19:46:17', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210324', 'u_210324', 'Q++sYsheZmo=', '游客334949', null, null, null, '2018-09-24 20:17:44', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210325', 'u_210325', 'Q++sYsheZmo=', '游客933076', null, null, null, '2018-09-24 20:17:47', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210326', 'u_210326', 'Q++sYsheZmo=', '游客719598', null, null, null, '2018-09-24 20:17:48', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210327', 'u_210327', 'Q++sYsheZmo=', '游客463839', null, null, null, '2018-09-24 20:18:11', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210328', 'u_210328', 'Q++sYsheZmo=', '游客382647', null, null, null, '2018-09-24 20:18:12', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210329', 'u_210329', 'Q++sYsheZmo=', '游客856721', null, null, null, '2018-09-24 20:18:13', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210330', 'u_210330', 'Q++sYsheZmo=', '游客882881', null, null, null, '2018-09-24 20:18:14', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210331', 'u_210331', 'Q++sYsheZmo=', '游客904371', null, null, null, '2018-09-24 20:27:23', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210332', 'u_210332', 'Q++sYsheZmo=', '游客909545', null, null, null, '2018-09-24 20:27:23', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210333', 'u_210333', 'Q++sYsheZmo=', '游客609410', null, null, null, '2018-09-24 20:27:24', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210334', 'u_210334', 'Q++sYsheZmo=', '游客500030', null, null, null, '2018-09-24 20:27:32', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210335', 'u_210335', 'Q++sYsheZmo=', '游客253431', null, null, null, '2018-09-25 10:07:18', null, null, null, null, '0', '10001', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210336', 'u_210336', 'Q++sYsheZmo=', '游客425986', null, null, null, '2018-09-25 10:24:06', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210337', 'u_210337', 'Q++sYsheZmo=', '游客570119', null, null, null, '2018-09-25 10:24:49', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210338', 'u_210338', 'Q++sYsheZmo=', '游客805981', null, null, null, '2018-09-25 10:26:48', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210339', 'u_210339', 'Q++sYsheZmo=', '游客126106', null, null, null, '2018-09-25 10:26:54', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210340', 'u_210340', 'Q++sYsheZmo=', '游客640949', null, null, null, '2018-09-25 10:31:07', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210341', 'u_210341', 'Q++sYsheZmo=', '游客809801', null, null, null, '2018-09-25 10:31:14', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210342', 'u_210342', 'Q++sYsheZmo=', '游客209929', null, null, null, '2018-09-25 10:31:22', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210343', 'u_210343', 'Q++sYsheZmo=', '游客961909', null, null, null, '2018-09-25 10:31:41', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210344', 'u_210344', 'Q++sYsheZmo=', '游客862814', null, null, null, '2018-09-25 10:37:11', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210345', 'u_210345', 'Q++sYsheZmo=', '游客947649', null, null, null, '2018-09-25 10:37:12', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210346', 'u_210346', 'Q++sYsheZmo=', '游客732330', null, null, null, '2018-09-25 10:37:14', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210347', 'u_210347', 'Q++sYsheZmo=', '游客401775', null, null, null, '2018-09-25 10:37:16', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210348', 'u_210348', 'Q++sYsheZmo=', '游客581117', null, null, null, '2018-09-25 10:39:01', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210349', 'u_210349', 'Q++sYsheZmo=', '游客849636', null, null, null, '2018-09-25 10:39:03', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210350', 'u_210350', 'Q++sYsheZmo=', '游客712196', null, null, null, '2018-09-25 10:39:04', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210351', 'u_210351', 'Q++sYsheZmo=', '游客761761', null, null, null, '2018-09-25 10:39:05', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210352', 'u_210352', 'Q++sYsheZmo=', '游客421631', null, null, null, '2018-09-25 10:41:47', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210353', 'u_210353', 'Q++sYsheZmo=', '游客715600', null, null, null, '2018-09-25 10:41:54', '1', null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210354', 'u_210354', 'Q++sYsheZmo=', '游客674919', null, null, null, '2018-09-25 10:50:54', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210355', 'u_210355', 'Q++sYsheZmo=', '游客798340', null, null, null, '2018-09-25 11:00:11', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210356', 'u_210356', 'Q++sYsheZmo=', '游客315179', null, null, null, '2018-09-25 11:07:51', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210357', 'u_210357', 'Q++sYsheZmo=', '游客958363', null, null, null, '2018-09-25 11:08:15', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210358', 'u_210358', 'Q++sYsheZmo=', '游客729442', null, null, null, '2018-09-25 11:08:20', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210359', 'u_210359', 'Q++sYsheZmo=', '游客976388', null, null, null, '2018-09-25 11:08:22', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210360', 'u_210360', 'Q++sYsheZmo=', '游客964759', null, null, null, '2018-09-25 11:16:21', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210361', 'u_210361', 'Q++sYsheZmo=', '游客913665', null, null, null, '2018-09-25 11:16:22', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210362', 'u_210362', 'Q++sYsheZmo=', '游客286923', null, null, null, '2018-09-25 11:16:22', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210363', 'u_210363', 'Q++sYsheZmo=', '游客917613', null, null, null, '2018-09-25 11:16:23', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210364', 'u_210364', 'Q++sYsheZmo=', '游客211006', null, null, null, '2018-09-25 11:21:03', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210365', 'u_210365', 'Q++sYsheZmo=', '游客503241', null, null, null, '2018-09-25 11:21:04', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210366', 'u_210366', 'Q++sYsheZmo=', '游客766586', null, null, null, '2018-09-25 11:21:06', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210367', 'u_210367', 'Q++sYsheZmo=', '游客290417', null, null, null, '2018-09-25 11:21:09', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210368', 'u_210368', 'Q++sYsheZmo=', '游客375440', null, null, null, '2018-09-25 11:30:49', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210369', 'u_210369', 'Q++sYsheZmo=', '游客142194', null, null, null, '2018-09-25 11:30:50', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210370', 'u_210370', 'Q++sYsheZmo=', '游客656724', null, null, null, '2018-09-25 11:30:51', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210371', 'u_210371', 'Q++sYsheZmo=', '游客555763', null, null, null, '2018-09-25 11:30:52', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210372', 'u_210372', 'Q++sYsheZmo=', '游客371532', null, null, null, '2018-09-25 11:32:55', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210373', 'u_210373', 'Q++sYsheZmo=', '游客528379', null, null, null, '2018-09-25 11:33:21', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210374', 'u_210374', 'Q++sYsheZmo=', '游客196927', null, null, null, '2018-09-25 11:33:21', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210375', 'u_210375', 'Q++sYsheZmo=', '游客165601', null, null, null, '2018-09-25 11:33:22', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210376', 'u_210376', 'Q++sYsheZmo=', '游客780025', null, null, null, '2018-09-25 11:34:16', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210377', 'u_210377', 'Q++sYsheZmo=', '游客135779', null, null, null, '2018-09-25 11:36:51', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210378', 'u_210378', 'Q++sYsheZmo=', '游客592521', null, null, null, '2018-09-25 11:36:53', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210379', 'u_210379', 'Q++sYsheZmo=', '游客671901', null, null, null, '2018-09-25 11:36:53', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210380', 'u_210380', 'Q++sYsheZmo=', '游客651379', null, null, null, '2018-09-25 11:37:06', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210381', 'u_210381', 'Q++sYsheZmo=', '游客336700', null, null, null, '2018-09-25 11:38:35', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210382', 'u_210382', 'Q++sYsheZmo=', '游客872367', null, null, null, '2018-09-25 11:40:46', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210383', 'u_210383', 'Q++sYsheZmo=', '游客595230', null, null, null, '2018-09-25 11:41:36', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210384', 'u_210384', 'Q++sYsheZmo=', '游客578473', null, null, null, '2018-09-25 11:42:29', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210385', 'u_210385', 'Q++sYsheZmo=', '游客952074', null, null, null, '2018-09-25 11:43:03', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210386', 'u_210386', 'Q++sYsheZmo=', '游客593859', null, null, null, '2018-09-25 11:43:04', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210387', 'u_210387', 'Q++sYsheZmo=', '游客689033', null, null, null, '2018-09-25 11:43:05', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210388', 'u_210388', 'Q++sYsheZmo=', '游客879693', null, null, null, '2018-09-25 11:43:06', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210389', 'u_210389', 'Q++sYsheZmo=', '游客677526', null, null, null, '2018-09-25 11:43:10', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210390', 'u_210390', 'Q++sYsheZmo=', '游客434535', null, null, null, '2018-09-25 11:43:52', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210391', 'u_210391', 'Q++sYsheZmo=', '游客935725', null, null, null, '2018-09-25 11:48:07', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210392', 'u_210392', 'Q++sYsheZmo=', '游客267639', null, null, null, '2018-09-25 11:48:09', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210393', 'u_210393', 'Q++sYsheZmo=', '游客599996', null, null, null, '2018-09-25 11:48:10', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210394', 'u_210394', 'Q++sYsheZmo=', '游客506314', null, null, null, '2018-09-25 11:48:12', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210395', 'u_210395', 'Q++sYsheZmo=', '游客703604', null, null, null, '2018-09-25 11:48:40', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210396', 'u_210396', 'Q++sYsheZmo=', '游客717806', null, null, null, '2018-09-25 11:51:08', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210397', 'u_210397', 'Q++sYsheZmo=', '游客530395', null, null, null, '2018-09-25 11:52:05', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210398', 'u_210398', 'Q++sYsheZmo=', '游客144515', null, null, null, '2018-09-25 11:52:50', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210399', 'u_210399', 'Q++sYsheZmo=', '游客714328', null, null, null, '2018-09-25 12:05:21', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210400', 'u_210400', 'Q++sYsheZmo=', '游客744144', null, null, null, '2018-09-25 12:06:27', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210401', 'u_210401', 'Q++sYsheZmo=', '游客165189', null, null, null, '2018-09-25 12:07:12', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210402', 'u_210402', 'Q++sYsheZmo=', '游客322229', null, null, null, '2018-09-25 12:08:02', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210403', 'u_210403', 'Q++sYsheZmo=', '游客790101', null, null, null, '2018-09-25 12:08:11', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210404', 'u_210404', 'Q++sYsheZmo=', '游客395109', null, null, null, '2018-09-25 12:12:04', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210405', 'u_210405', 'Q++sYsheZmo=', '游客880461', null, null, null, '2018-09-25 12:13:32', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210406', 'u_210406', 'Q++sYsheZmo=', '游客186777', null, null, null, '2018-09-25 12:15:30', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210407', 'u_210407', 'Q++sYsheZmo=', '游客437338', null, null, null, '2018-09-25 12:15:31', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210408', 'u_210408', 'Q++sYsheZmo=', '游客177949', null, null, null, '2018-09-25 12:15:32', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210409', 'u_210409', 'Q++sYsheZmo=', '游客553549', null, null, null, '2018-09-25 13:12:06', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210410', 'u_210410', 'Q++sYsheZmo=', '游客819017', null, null, null, '2018-09-25 13:12:06', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210411', 'u_210411', 'Q++sYsheZmo=', '游客435556', null, null, null, '2018-09-25 13:12:08', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210412', 'u_210412', 'Q++sYsheZmo=', '游客472960', null, null, null, '2018-09-25 13:12:08', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210413', 'u_210413', '', 'Leon', null, null, null, '2018-09-25 13:13:52', null, null, null, null, '0', '0', null, null, 'http://wxheader.qileah.cn/mmopen/vi_32/Q0j4TwGTfTKYtVBicOCT4dVrdc1RcyMJibicGCKE97LqQxYfFlQZroZ19fa1dQSN5btaxU7sbleO1P9qEePRJgEMg/132', null, null, '1', '0', '1');
INSERT INTO `user_info` VALUES ('210414', 'u_210414', 'Q++sYsheZmo=', '游客714281', null, null, null, '2018-09-25 13:19:09', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210415', 'u_210415', 'Q++sYsheZmo=', '游客677159', null, null, null, '2018-09-25 13:19:11', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210416', 'u_210416', 'Q++sYsheZmo=', '游客705433', null, null, null, '2018-09-25 13:19:13', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210417', 'u_210417', 'Q++sYsheZmo=', '游客744358', null, null, null, '2018-09-25 13:19:14', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210418', 'u_210418', 'Q++sYsheZmo=', '游客671165', null, null, null, '2018-09-25 13:57:14', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210419', 'u_210419', 'Q++sYsheZmo=', '游客449473', null, null, null, '2018-09-25 13:57:15', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210420', 'u_210420', 'Q++sYsheZmo=', '游客899539', null, null, null, '2018-09-25 13:57:16', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210421', 'u_210421', 'Q++sYsheZmo=', '游客347907', null, null, null, '2018-09-25 13:57:17', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210422', 'u_210422', 'Q++sYsheZmo=', '游客489192', null, null, null, '2018-09-25 14:09:01', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210423', 'u_210423', 'Q++sYsheZmo=', '游客479752', null, null, null, '2018-09-25 14:09:02', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210424', 'u_210424', 'Q++sYsheZmo=', '游客669816', null, null, null, '2018-09-25 14:09:03', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210425', 'u_210425', 'Q++sYsheZmo=', '游客834022', null, null, null, '2018-09-25 14:09:04', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210426', 'u_210426', 'Q++sYsheZmo=', '游客885138', null, null, null, '2018-09-25 14:11:06', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210427', 'u_210427', 'Q++sYsheZmo=', '游客693261', null, null, null, '2018-09-25 14:11:07', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210428', 'u_210428', 'Q++sYsheZmo=', '游客567677', null, null, null, '2018-09-25 14:11:08', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210429', 'u_210429', 'Q++sYsheZmo=', '游客223131', null, null, null, '2018-09-25 14:11:09', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210430', 'u_210430', 'Q++sYsheZmo=', '游客496033', null, null, null, '2018-09-25 14:14:13', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210431', 'u_210431', 'Q++sYsheZmo=', '游客602159', null, null, null, '2018-09-25 14:14:14', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210432', 'u_210432', 'Q++sYsheZmo=', '游客339127', null, null, null, '2018-09-25 14:14:15', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210433', 'u_210433', 'Q++sYsheZmo=', '游客916287', null, null, null, '2018-09-25 14:14:16', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210434', 'u_210434', 'Q++sYsheZmo=', '游客907133', null, null, null, '2018-09-25 14:18:48', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210435', 'u_210435', 'Q++sYsheZmo=', '游客164218', null, null, null, '2018-09-25 14:18:50', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210436', 'u_210436', 'Q++sYsheZmo=', '游客276130', null, null, null, '2018-09-25 14:18:51', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210437', 'u_210437', 'Q++sYsheZmo=', '游客230152', null, null, null, '2018-09-25 14:18:56', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210438', 'u_210438', 'Q++sYsheZmo=', '游客298057', null, null, null, '2018-09-25 14:20:37', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210439', 'u_210439', 'Q++sYsheZmo=', '游客384725', null, null, null, '2018-09-25 14:20:38', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210440', 'u_210440', 'Q++sYsheZmo=', '游客959147', null, null, null, '2018-09-25 14:20:39', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210441', 'u_210441', 'Q++sYsheZmo=', '游客599714', null, null, null, '2018-09-25 14:20:40', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210442', 'u_210442', 'Q++sYsheZmo=', '游客265395', null, null, null, '2018-09-25 14:23:35', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210443', 'u_210443', 'Q++sYsheZmo=', '游客842866', null, null, null, '2018-09-25 14:23:36', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210444', 'u_210444', 'Q++sYsheZmo=', '游客931657', null, null, null, '2018-09-25 14:23:37', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210445', 'u_210445', 'Q++sYsheZmo=', '游客880873', null, null, null, '2018-09-25 14:23:38', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210446', 'u_210446', 'Q++sYsheZmo=', '游客656898', null, null, null, '2018-09-25 14:36:08', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210447', 'u_210447', 'Q++sYsheZmo=', '游客695512', null, null, null, '2018-09-25 14:36:09', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210448', 'u_210448', 'Q++sYsheZmo=', '游客859718', null, null, null, '2018-09-25 14:36:10', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210449', 'u_210449', 'Q++sYsheZmo=', '游客210185', null, null, null, '2018-09-25 14:36:11', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210450', 'u_210450', 'Q++sYsheZmo=', '游客160123', null, null, null, '2018-09-25 14:49:15', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210451', 'u_210451', 'Q++sYsheZmo=', '游客836422', null, null, null, '2018-09-25 14:49:16', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210452', 'u_210452', 'Q++sYsheZmo=', '游客213635', null, null, null, '2018-09-25 14:49:17', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210453', 'u_210453', 'Q++sYsheZmo=', '游客230979', null, null, null, '2018-09-25 14:49:18', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210454', 'u_210454', 'Q++sYsheZmo=', '游客214804', null, null, null, '2018-09-25 14:49:44', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210455', 'u_210455', 'Q++sYsheZmo=', '游客267581', null, null, null, '2018-09-25 14:57:08', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210456', 'u_210456', 'Q++sYsheZmo=', '游客772378', null, null, null, '2018-09-25 14:57:10', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210457', 'u_210457', 'Q++sYsheZmo=', '游客816467', null, null, null, '2018-09-25 14:57:10', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210458', 'u_210458', 'Q++sYsheZmo=', '游客419931', null, null, null, '2018-09-25 14:57:11', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210459', 'u_210459', 'Q++sYsheZmo=', '游客841741', null, null, null, '2018-09-25 14:59:23', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210460', 'u_210460', 'Q++sYsheZmo=', '游客977066', null, null, null, '2018-09-25 14:59:23', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210461', 'u_210461', 'Q++sYsheZmo=', '游客292553', null, null, null, '2018-09-25 14:59:24', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210462', 'u_210462', 'Q++sYsheZmo=', '游客607595', null, null, null, '2018-09-25 14:59:25', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210463', 'u_210463', 'Q++sYsheZmo=', '游客390067', null, null, null, '2018-09-25 15:03:29', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210464', 'u_210464', 'Q++sYsheZmo=', '游客929529', null, null, null, '2018-09-25 15:03:30', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210465', 'u_210465', 'Q++sYsheZmo=', '游客951423', null, null, null, '2018-09-25 15:03:31', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210466', 'u_210466', 'Q++sYsheZmo=', '游客354495', null, null, null, '2018-09-25 15:03:32', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210467', 'u_210467', 'Q++sYsheZmo=', '游客253151', null, null, null, '2018-09-25 15:08:26', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210468', 'u_210468', 'Q++sYsheZmo=', '游客524095', null, null, null, '2018-09-25 15:08:27', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210469', 'u_210469', 'Q++sYsheZmo=', '游客794746', null, null, null, '2018-09-25 15:08:28', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210470', 'u_210470', 'Q++sYsheZmo=', '游客339515', null, null, null, '2018-09-25 15:08:29', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210471', 'u_210471', 'Q++sYsheZmo=', '游客766401', null, null, null, '2018-09-25 15:11:09', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210472', 'u_210472', 'Q++sYsheZmo=', '游客940634', null, null, null, '2018-09-25 15:11:09', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210473', 'u_210473', 'Q++sYsheZmo=', '游客978653', null, null, null, '2018-09-25 15:11:10', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210474', 'u_210474', 'Q++sYsheZmo=', '游客933035', null, null, null, '2018-09-25 15:11:11', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210475', 'u_210475', 'Q++sYsheZmo=', '游客602285', null, null, null, '2018-09-25 15:15:52', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210476', 'u_210476', 'Q++sYsheZmo=', '游客431385', null, null, null, '2018-09-25 15:15:53', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210477', 'u_210477', 'Q++sYsheZmo=', '游客435945', null, null, null, '2018-09-25 15:15:55', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210478', 'u_210478', 'Q++sYsheZmo=', '游客731822', null, null, null, '2018-09-25 15:15:55', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210479', 'u_210479', 'Q++sYsheZmo=', '游客442970', null, null, null, '2018-09-25 15:22:32', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210480', 'u_210480', 'Q++sYsheZmo=', '游客828555', null, null, null, '2018-09-25 15:22:33', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210481', 'u_210481', 'Q++sYsheZmo=', '游客405253', null, null, null, '2018-09-25 15:22:34', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210482', 'u_210482', 'Q++sYsheZmo=', '游客211562', null, null, null, '2018-09-25 15:22:35', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210483', 'u_210483', 'Q++sYsheZmo=', '游客598422', null, null, null, '2018-09-25 15:28:28', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210484', 'u_210484', 'Q++sYsheZmo=', '游客220436', null, null, null, '2018-09-25 15:28:29', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210485', 'u_210485', 'Q++sYsheZmo=', '游客264213', null, null, null, '2018-09-25 15:28:31', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210486', 'u_210486', 'Q++sYsheZmo=', '游客154726', null, null, null, '2018-09-25 15:28:32', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210487', 'u_210487', 'Q++sYsheZmo=', '游客787607', null, null, null, '2018-09-25 15:34:02', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210488', 'u_210488', 'Q++sYsheZmo=', '游客524876', null, null, null, '2018-09-25 15:34:03', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210489', 'u_210489', 'Q++sYsheZmo=', '游客145060', null, null, null, '2018-09-25 15:34:04', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210490', 'u_210490', 'Q++sYsheZmo=', '游客749297', null, null, null, '2018-09-25 15:34:05', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210491', 'u_210491', 'Q++sYsheZmo=', '游客847458', null, null, null, '2018-09-25 15:40:19', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210492', 'u_210492', 'Q++sYsheZmo=', '游客701181', null, null, null, '2018-09-25 15:40:19', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210493', 'u_210493', 'Q++sYsheZmo=', '游客971220', null, null, null, '2018-09-25 15:40:21', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210494', 'u_210494', 'Q++sYsheZmo=', '游客802748', null, null, null, '2018-09-25 15:40:22', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210495', 'u_210495', 'Q++sYsheZmo=', '游客821563', null, null, null, '2018-09-25 15:43:03', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210496', 'u_210496', 'Q++sYsheZmo=', '游客414386', null, null, null, '2018-09-25 15:43:04', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210497', 'u_210497', 'Q++sYsheZmo=', '游客758317', null, null, null, '2018-09-25 15:43:05', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210498', 'u_210498', 'Q++sYsheZmo=', '游客723659', null, null, null, '2018-09-25 15:43:05', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210499', 'u_210499', 'Q++sYsheZmo=', '游客232524', null, null, null, '2018-09-25 15:46:40', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210500', 'u_210500', 'Q++sYsheZmo=', '游客700519', null, null, null, '2018-09-25 15:46:40', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210501', 'u_210501', 'Q++sYsheZmo=', '游客378783', null, null, null, '2018-09-25 15:46:41', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210502', 'u_210502', 'Q++sYsheZmo=', '游客339859', null, null, null, '2018-09-25 15:46:42', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210503', 'u_210503', 'Q++sYsheZmo=', '游客159474', null, null, null, '2018-09-25 15:48:45', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210504', 'u_210504', 'Q++sYsheZmo=', '游客282026', null, null, null, '2018-09-25 15:48:46', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210505', 'u_210505', 'Q++sYsheZmo=', '游客638412', null, null, null, '2018-09-25 15:48:47', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210506', 'u_210506', 'Q++sYsheZmo=', '游客499754', null, null, null, '2018-09-25 15:48:48', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210507', 'u_210507', 'Q++sYsheZmo=', '游客546319', null, null, null, '2018-09-25 15:53:03', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210508', 'u_210508', 'Q++sYsheZmo=', '游客820616', null, null, null, '2018-09-25 15:53:04', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210509', 'u_210509', 'Q++sYsheZmo=', '游客403697', null, null, null, '2018-09-25 15:53:04', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210510', 'u_210510', 'Q++sYsheZmo=', '游客581592', null, null, null, '2018-09-25 15:53:05', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210511', 'u_210511', 'Q++sYsheZmo=', '游客253461', null, null, null, '2018-09-25 16:01:29', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210512', 'u_210512', 'Q++sYsheZmo=', '游客736656', null, null, null, '2018-09-25 16:01:30', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210513', 'u_210513', 'Q++sYsheZmo=', '游客598593', null, null, null, '2018-09-25 16:01:30', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210514', 'u_210514', 'Q++sYsheZmo=', '游客437790', null, null, null, '2018-09-25 16:01:56', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210515', 'u_210515', 'Q++sYsheZmo=', '游客479285', null, null, null, '2018-09-25 16:13:17', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210516', 'u_210516', 'Q++sYsheZmo=', '游客858176', null, null, null, '2018-09-25 16:13:18', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210517', 'u_210517', 'Q++sYsheZmo=', '游客815606', null, null, null, '2018-09-25 16:13:19', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210518', 'u_210518', 'Q++sYsheZmo=', '游客556217', null, null, null, '2018-09-25 16:13:20', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210519', 'u_210519', 'Q++sYsheZmo=', '游客933049', null, null, null, '2018-09-25 16:26:12', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210520', 'u_210520', 'Q++sYsheZmo=', '游客405756', null, null, null, '2018-09-25 16:26:13', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210521', 'u_210521', 'Q++sYsheZmo=', '游客733562', null, null, null, '2018-09-25 16:26:14', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210522', 'u_210522', 'Q++sYsheZmo=', '游客472954', null, null, null, '2018-09-25 16:26:15', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210523', 'u_210523', 'Q++sYsheZmo=', '游客925470', null, null, null, '2018-09-25 16:36:55', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210524', 'u_210524', 'Q++sYsheZmo=', '游客729327', null, null, null, '2018-09-25 16:36:56', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210525', 'u_210525', 'Q++sYsheZmo=', '游客280186', null, null, null, '2018-09-25 16:36:57', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210526', 'u_210526', 'Q++sYsheZmo=', '游客466461', null, null, null, '2018-09-25 16:37:30', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210527', 'u_210527', 'Q++sYsheZmo=', '游客824623', null, null, null, '2018-09-25 16:42:15', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210528', 'u_210528', 'Q++sYsheZmo=', '游客617243', null, null, null, '2018-09-25 16:42:15', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210529', 'u_210529', 'Q++sYsheZmo=', '游客881494', null, null, null, '2018-09-25 16:42:17', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210530', 'u_210530', 'Q++sYsheZmo=', '游客790275', null, null, null, '2018-09-25 16:42:17', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210531', 'u_210531', 'Q++sYsheZmo=', '游客470229', null, null, null, '2018-09-25 16:49:06', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210532', 'u_210532', 'Q++sYsheZmo=', '游客923325', null, null, null, '2018-09-25 16:49:07', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210533', 'u_210533', 'Q++sYsheZmo=', '游客271959', null, null, null, '2018-09-25 16:49:08', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210534', 'u_210534', 'Q++sYsheZmo=', '游客302670', null, null, null, '2018-09-25 16:49:09', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210535', 'u_210535', 'Q++sYsheZmo=', '游客980657', null, null, null, '2018-09-25 16:51:36', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210536', 'u_210536', 'Q++sYsheZmo=', '游客189407', null, null, null, '2018-09-25 16:51:37', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210537', 'u_210537', 'Q++sYsheZmo=', '游客779955', null, null, null, '2018-09-25 16:51:38', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210538', 'u_210538', 'Q++sYsheZmo=', '游客898845', null, null, null, '2018-09-25 16:51:39', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210539', 'u_210539', 'Q++sYsheZmo=', '游客682293', null, null, null, '2018-09-25 16:54:20', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210540', 'u_210540', 'Q++sYsheZmo=', '游客751031', null, null, null, '2018-09-25 16:54:20', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210541', 'u_210541', 'Q++sYsheZmo=', '游客532078', null, null, null, '2018-09-25 16:54:21', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210542', 'u_210542', 'Q++sYsheZmo=', '游客454841', null, null, null, '2018-09-25 16:54:22', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210543', 'u_210543', 'Q++sYsheZmo=', '游客329800', null, null, null, '2018-09-25 17:01:48', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210544', 'u_210544', 'Q++sYsheZmo=', '游客197221', null, null, null, '2018-09-25 17:01:48', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210545', 'u_210545', 'Q++sYsheZmo=', '游客837323', null, null, null, '2018-09-25 17:01:50', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210546', 'u_210546', 'Q++sYsheZmo=', '游客700788', null, null, null, '2018-09-25 17:01:50', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210547', 'u_210547', 'Q++sYsheZmo=', '游客254870', null, null, null, '2018-09-25 17:14:37', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210548', 'u_210548', 'Q++sYsheZmo=', '游客217466', null, null, null, '2018-09-25 17:14:37', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210549', 'u_210549', 'Q++sYsheZmo=', '游客708875', null, null, null, '2018-09-25 17:14:38', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210550', 'u_210550', 'Q++sYsheZmo=', '游客368899', null, null, null, '2018-09-25 17:14:39', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210551', 'u_210551', 'Q++sYsheZmo=', '游客745688', null, null, null, '2018-09-25 17:17:25', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210552', 'u_210552', 'Q++sYsheZmo=', '游客144189', null, null, null, '2018-09-25 17:17:27', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210553', 'u_210553', 'Q++sYsheZmo=', '游客738086', null, null, null, '2018-09-25 17:17:28', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210554', 'u_210554', 'Q++sYsheZmo=', '游客380776', null, null, null, '2018-09-25 17:17:29', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210555', 'u_210555', 'Q++sYsheZmo=', '游客174943', null, null, null, '2018-09-25 17:21:05', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210556', 'u_210556', 'Q++sYsheZmo=', '游客715001', null, null, null, '2018-09-25 17:21:05', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210557', 'u_210557', 'Q++sYsheZmo=', '游客802887', null, null, null, '2018-09-25 17:21:07', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210558', 'u_210558', 'Q++sYsheZmo=', '游客533161', null, null, null, '2018-09-25 17:21:08', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210559', 'u_210559', 'Q++sYsheZmo=', '游客566773', null, null, null, '2018-09-25 17:23:58', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210560', 'u_210560', 'Q++sYsheZmo=', '游客848073', null, null, null, '2018-09-25 17:23:58', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210561', 'u_210561', 'Q++sYsheZmo=', '游客499571', null, null, null, '2018-09-25 17:24:00', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210562', 'u_210562', 'Q++sYsheZmo=', '游客150038', null, null, null, '2018-09-25 17:24:10', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210563', 'u_210563', 'Q++sYsheZmo=', '游客893675', null, null, null, '2018-09-25 17:26:17', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210564', 'u_210564', 'Q++sYsheZmo=', '游客509904', null, null, null, '2018-09-25 17:26:17', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210565', 'u_210565', 'Q++sYsheZmo=', '游客621505', null, null, null, '2018-09-25 17:26:18', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210566', 'u_210566', 'Q++sYsheZmo=', '游客757445', null, null, null, '2018-09-25 17:26:19', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210567', 'u_210567', 'Q++sYsheZmo=', '游客216885', null, null, null, '2018-09-25 17:27:53', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210568', 'u_210568', 'Q++sYsheZmo=', '游客551999', null, null, null, '2018-09-25 17:27:54', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210569', 'u_210569', 'Q++sYsheZmo=', '游客825371', null, null, null, '2018-09-25 17:27:55', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210570', 'u_210570', 'Q++sYsheZmo=', '游客239988', null, null, null, '2018-09-25 17:27:56', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210571', 'u_210571', 'Q++sYsheZmo=', '游客208217', null, null, null, '2018-09-25 17:29:31', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210572', 'u_210572', 'Q++sYsheZmo=', '游客645803', null, null, null, '2018-09-25 17:29:32', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210573', 'u_210573', 'Q++sYsheZmo=', '游客278751', null, null, null, '2018-09-25 17:29:33', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210574', 'u_210574', 'Q++sYsheZmo=', '游客395828', null, null, null, '2018-09-25 17:29:34', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210575', 'u_210575', 'Q++sYsheZmo=', '游客636922', null, null, null, '2018-09-25 17:33:42', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210576', 'u_210576', 'Q++sYsheZmo=', '游客129701', null, null, null, '2018-09-25 17:33:43', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210577', 'u_210577', 'Q++sYsheZmo=', '游客486087', null, null, null, '2018-09-25 17:33:44', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210578', 'u_210578', 'Q++sYsheZmo=', '游客433180', null, null, null, '2018-09-25 17:33:45', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210579', 'u_210579', 'Q++sYsheZmo=', '游客193615', null, null, null, '2018-09-25 17:36:18', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210580', 'u_210580', 'Q++sYsheZmo=', '游客305216', null, null, null, '2018-09-25 17:36:18', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210581', 'u_210581', 'Q++sYsheZmo=', '游客679246', null, null, null, '2018-09-25 17:36:19', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210582', 'u_210582', 'Q++sYsheZmo=', '游客892724', null, null, null, '2018-09-25 17:36:21', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210583', 'u_210583', 'Q++sYsheZmo=', '游客458445', null, null, null, '2018-09-25 17:38:46', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210584', 'u_210584', 'Q++sYsheZmo=', '游客196318', null, null, null, '2018-09-25 17:38:47', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210585', 'u_210585', 'Q++sYsheZmo=', '游客710233', null, null, null, '2018-09-25 17:38:48', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210586', 'u_210586', 'Q++sYsheZmo=', '游客379376', null, null, null, '2018-09-25 17:38:49', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210587', 'u_210587', 'Q++sYsheZmo=', '游客432157', null, null, null, '2018-09-25 17:44:55', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210588', 'u_210588', 'Q++sYsheZmo=', '游客672692', null, null, null, '2018-09-25 17:44:56', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210589', 'u_210589', 'Q++sYsheZmo=', '游客451925', null, null, null, '2018-09-25 17:44:57', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210590', 'u_210590', 'Q++sYsheZmo=', '游客938169', null, null, null, '2018-09-25 17:44:58', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210591', 'u_210591', 'Q++sYsheZmo=', '游客199943', null, null, null, '2018-09-25 17:47:19', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210592', 'u_210592', 'Q++sYsheZmo=', '游客717813', null, null, null, '2018-09-25 17:47:20', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210593', 'u_210593', 'Q++sYsheZmo=', '游客353809', null, null, null, '2018-09-25 17:47:21', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210594', 'u_210594', 'Q++sYsheZmo=', '游客480628', null, null, null, '2018-09-25 17:47:22', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210595', 'u_210595', 'Q++sYsheZmo=', '游客681790', null, null, null, '2018-09-25 17:48:54', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210596', 'u_210596', 'Q++sYsheZmo=', '游客798867', null, null, null, '2018-09-25 17:48:54', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210597', 'u_210597', 'Q++sYsheZmo=', '游客162098', null, null, null, '2018-09-25 17:48:55', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210598', 'u_210598', 'Q++sYsheZmo=', '游客600902', null, null, null, '2018-09-25 17:48:56', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210599', 'u_210599', 'Q++sYsheZmo=', '游客507225', null, null, null, '2018-09-25 17:50:21', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210600', 'u_210600', 'Q++sYsheZmo=', '游客679645', null, null, null, '2018-09-25 17:50:22', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210601', 'u_210601', 'Q++sYsheZmo=', '游客754144', null, null, null, '2018-09-25 17:50:22', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210602', 'u_210602', 'Q++sYsheZmo=', '游客746846', null, null, null, '2018-09-25 17:50:23', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210603', 'u_210603', 'Q++sYsheZmo=', '游客569393', null, null, null, '2018-09-25 17:51:42', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210604', 'u_210604', 'Q++sYsheZmo=', '游客462672', null, null, null, '2018-09-25 17:51:43', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210605', 'u_210605', 'Q++sYsheZmo=', '游客548726', null, null, null, '2018-09-25 17:51:44', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210606', 'u_210606', 'Q++sYsheZmo=', '游客154313', null, null, null, '2018-09-25 17:51:45', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210607', 'u_210607', 'Q++sYsheZmo=', '游客816735', null, null, null, '2018-09-25 17:53:24', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210608', 'u_210608', 'Q++sYsheZmo=', '游客566778', null, null, null, '2018-09-25 17:53:25', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210609', 'u_210609', 'Q++sYsheZmo=', '游客989767', null, null, null, '2018-09-25 17:53:26', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210610', 'u_210610', 'Q++sYsheZmo=', '游客537274', null, null, null, '2018-09-25 17:53:27', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210611', 'u_210611', 'Q++sYsheZmo=', '游客395720', null, null, null, '2018-09-25 17:54:49', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210612', 'u_210612', 'Q++sYsheZmo=', '游客569952', null, null, null, '2018-09-25 17:54:50', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210613', 'u_210613', 'Q++sYsheZmo=', '游客168615', null, null, null, '2018-09-25 17:55:16', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210614', 'u_210614', 'Q++sYsheZmo=', '游客490040', null, null, null, '2018-09-25 17:55:17', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210615', 'u_210615', 'Q++sYsheZmo=', '游客518661', null, null, null, '2018-09-25 18:02:41', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210616', 'u_210616', 'Q++sYsheZmo=', '游客807534', null, null, null, '2018-09-25 18:02:41', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210617', 'u_210617', 'Q++sYsheZmo=', '游客481248', null, null, null, '2018-09-25 18:02:42', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210618', 'u_210618', 'Q++sYsheZmo=', '游客518965', null, null, null, '2018-09-25 18:02:44', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210619', 'u_210619', 'Q++sYsheZmo=', '游客472811', null, null, null, '2018-09-25 18:05:49', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210620', 'u_210620', 'Q++sYsheZmo=', '游客200658', null, null, null, '2018-09-25 18:05:49', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210621', 'u_210621', 'Q++sYsheZmo=', '游客421735', null, null, null, '2018-09-25 18:05:50', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210622', 'u_210622', 'Q++sYsheZmo=', '游客328996', null, null, null, '2018-09-25 18:05:51', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210623', 'u_210623', 'Q++sYsheZmo=', '游客865330', null, null, null, '2018-09-25 18:28:40', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210624', 'u_210624', 'Q++sYsheZmo=', '游客605900', null, null, null, '2018-09-25 19:37:07', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210625', 'u_210625', 'Q++sYsheZmo=', '游客794423', null, null, null, '2018-09-25 19:40:02', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210626', 'u_210626', 'Q++sYsheZmo=', '游客980786', null, null, null, '2018-09-25 19:42:39', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210627', 'u_210627', 'Q++sYsheZmo=', '游客655873', null, null, null, '2018-09-25 20:40:25', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210628', 'u_210628', 'Q++sYsheZmo=', '游客240306', null, null, null, '2018-09-25 20:41:37', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210629', 'u_210629', 'Q++sYsheZmo=', '游客572267', null, null, null, '2018-09-25 20:46:13', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210630', 'u_210630', 'Q++sYsheZmo=', '游客526658', null, null, null, '2018-09-25 20:46:13', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210631', 'u_210631', 'Q++sYsheZmo=', '游客831611', null, null, null, '2018-09-25 21:00:37', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210632', 'u_210632', 'Q++sYsheZmo=', '游客433077', null, null, null, '2018-09-25 21:00:52', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210633', 'u_210633', 'Q++sYsheZmo=', '游客554110', null, null, null, '2018-09-25 21:00:53', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210634', 'u_210634', 'Q++sYsheZmo=', '游客347347', null, null, null, '2018-09-26 09:26:32', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210635', 'u_210635', 'Q++sYsheZmo=', '游客450877', null, null, null, '2018-09-26 09:29:05', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210636', 'u_210636', 'Q++sYsheZmo=', '游客348386', null, null, null, '2018-09-26 09:29:07', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210637', 'u_210637', 'Q++sYsheZmo=', '游客185028', null, null, null, '2018-09-26 09:29:12', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210638', 'u_210638', 'Q++sYsheZmo=', '游客198166', null, null, null, '2018-09-26 09:58:09', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210639', 'u_210639', 'Q++sYsheZmo=', '游客144002', null, null, null, '2018-09-26 09:58:13', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210640', 'u_210640', 'Q++sYsheZmo=', '游客853819', null, null, null, '2018-09-26 10:02:04', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210641', 'u_210641', 'Q++sYsheZmo=', '游客518696', null, null, null, '2018-09-26 10:02:05', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210642', 'u_210642', 'Q++sYsheZmo=', '游客292799', null, null, null, '2018-09-26 10:12:05', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210643', 'u_210643', 'Q++sYsheZmo=', '游客361172', null, null, null, '2018-09-26 10:18:29', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210644', 'u_210644', 'Q++sYsheZmo=', '游客480090', null, null, null, '2018-09-26 10:18:31', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210645', 'u_210645', 'Q++sYsheZmo=', '游客549402', null, null, null, '2018-09-26 10:19:51', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210646', 'u_210646', 'Q++sYsheZmo=', '游客132794', null, null, null, '2018-09-26 10:19:52', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210647', 'u_210647', 'Q++sYsheZmo=', '游客470384', null, null, null, '2018-09-26 10:29:50', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210648', 'u_210648', 'Q++sYsheZmo=', '游客664883', null, null, null, '2018-09-26 10:36:58', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210649', 'u_210649', 'Q++sYsheZmo=', '游客878487', null, null, null, '2018-09-26 10:38:12', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210650', 'u_210650', 'Q++sYsheZmo=', '游客986324', null, null, null, '2018-09-26 10:49:00', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210651', 'u_210651', 'Q++sYsheZmo=', '游客255678', null, null, null, '2018-09-26 10:52:12', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210652', 'u_210652', 'Q++sYsheZmo=', '游客905012', null, null, null, '2018-09-26 11:01:51', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210653', 'u_210653', 'Q++sYsheZmo=', '游客965943', null, null, null, '2018-09-26 11:07:58', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210654', 'u_210654', 'Q++sYsheZmo=', '游客236134', null, null, null, '2018-09-26 11:07:59', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210655', 'u_210655', 'Q++sYsheZmo=', '游客353106', null, null, null, '2018-09-26 11:13:49', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210656', 'u_210656', 'Q++sYsheZmo=', '游客319657', null, null, null, '2018-09-26 11:13:49', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210657', 'u_210657', 'Q++sYsheZmo=', '游客245475', null, null, null, '2018-09-26 11:14:13', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210658', 'u_210658', 'Q++sYsheZmo=', '游客895623', null, null, null, '2018-09-26 11:14:13', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210659', 'u_210659', 'Q++sYsheZmo=', '游客236208', null, null, null, '2018-09-26 11:15:29', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210660', 'u_210660', 'Q++sYsheZmo=', '游客565847', null, null, null, '2018-09-26 11:15:30', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210661', 'u_210661', 'Q++sYsheZmo=', '游客459411', null, null, null, '2018-09-26 11:15:31', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210662', 'u_210662', 'Q++sYsheZmo=', '游客571013', null, null, null, '2018-09-26 11:15:32', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210663', 'u_210663', 'Q++sYsheZmo=', '游客771629', null, null, null, '2018-09-26 11:17:16', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210664', 'u_210664', 'Q++sYsheZmo=', '游客770118', null, null, null, '2018-09-26 11:17:17', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210665', 'u_210665', 'Q++sYsheZmo=', '游客386656', null, null, null, '2018-09-26 11:17:18', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210666', 'u_210666', 'Q++sYsheZmo=', '游客503118', null, null, null, '2018-09-26 11:17:19', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210667', 'u_210667', 'Q++sYsheZmo=', '游客681281', null, null, null, '2018-09-26 11:18:47', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210668', 'u_210668', 'Q++sYsheZmo=', '游客703779', null, null, null, '2018-09-26 11:18:48', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210669', 'u_210669', 'Q++sYsheZmo=', '游客861006', null, null, null, '2018-09-26 11:18:49', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210670', 'u_210670', 'Q++sYsheZmo=', '游客412771', null, null, null, '2018-09-26 11:18:50', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210671', 'u_210671', 'Q++sYsheZmo=', '游客317385', null, null, null, '2018-09-26 11:20:50', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210672', 'u_210672', 'Q++sYsheZmo=', '游客912340', null, null, null, '2018-09-26 11:33:32', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210673', 'u_210673', 'Q++sYsheZmo=', '游客433198', null, null, null, '2018-09-26 11:36:48', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210674', 'u_210674', 'Q++sYsheZmo=', '游客243749', null, null, null, '2018-09-26 11:36:49', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210675', 'u_210675', 'Q++sYsheZmo=', '游客318134', null, null, null, '2018-09-26 11:39:06', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210676', 'u_210676', 'Q++sYsheZmo=', '游客793728', null, null, null, '2018-09-26 11:39:08', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210677', 'u_210677', 'Q++sYsheZmo=', '游客844624', null, null, null, '2018-09-26 11:41:39', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210678', 'u_210678', 'Q++sYsheZmo=', '游客841282', null, null, null, '2018-09-26 11:41:40', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210679', 'u_210679', 'Q++sYsheZmo=', '游客979658', null, null, null, '2018-09-26 11:41:42', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210680', 'u_210680', 'Q++sYsheZmo=', '游客270525', null, null, null, '2018-09-26 11:41:44', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210681', 'u_210681', 'Q++sYsheZmo=', '游客125098', null, null, null, '2018-09-26 11:46:45', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210682', 'u_210682', 'Q++sYsheZmo=', '游客213568', null, null, null, '2018-09-26 11:46:47', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210683', 'u_210683', 'Q++sYsheZmo=', '游客642194', null, null, null, '2018-09-26 13:07:21', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210684', 'u_210684', 'Q++sYsheZmo=', '游客748161', null, null, null, '2018-09-26 13:07:32', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210685', 'u_210685', 'Q++sYsheZmo=', '游客816764', null, null, null, '2018-09-26 13:08:05', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210686', 'u_210686', 'Q++sYsheZmo=', '游客657449', null, null, null, '2018-09-26 13:08:07', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210687', 'u_210687', 'Q++sYsheZmo=', '游客419672', null, null, null, '2018-09-26 13:08:10', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210688', 'u_210688', 'Q++sYsheZmo=', '游客595452', null, null, null, '2018-09-26 13:08:11', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210689', 'u_210689', 'Q++sYsheZmo=', '游客387366', null, null, null, '2018-09-26 14:21:03', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210690', 'u_210690', 'Q++sYsheZmo=', '游客926848', null, null, null, '2018-09-26 14:21:07', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210691', 'u_210691', 'Q++sYsheZmo=', '游客304986', null, null, null, '2018-09-26 14:21:08', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210692', 'u_210692', 'Q++sYsheZmo=', '游客521638', null, null, null, '2018-09-26 14:21:18', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210693', 'u_210693', 'Q++sYsheZmo=', '游客676158', null, null, null, '2018-09-26 14:25:20', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210694', 'u_210694', 'Q++sYsheZmo=', '游客699219', null, null, null, '2018-09-26 14:27:11', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210695', 'u_210695', 'Q++sYsheZmo=', '游客192915', null, null, null, '2018-09-26 14:27:13', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210696', 'u_210696', 'Q++sYsheZmo=', '游客699854', null, null, null, '2018-09-26 14:27:14', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210697', 'u_210697', 'Q++sYsheZmo=', '游客721446', null, null, null, '2018-09-26 14:27:16', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210698', 'u_210698', 'Q++sYsheZmo=', '游客763907', null, null, null, '2018-09-26 14:31:32', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210699', 'u_210699', 'Q++sYsheZmo=', '游客962741', null, null, null, '2018-09-26 14:31:36', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210700', 'u_210700', 'Q++sYsheZmo=', '游客721019', null, null, null, '2018-09-26 14:31:39', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210701', 'u_210701', 'Q++sYsheZmo=', '游客444267', null, null, null, '2018-09-26 14:31:43', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210702', 'u_210702', 'Q++sYsheZmo=', '游客653770', null, null, null, '2018-09-26 14:31:44', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210703', 'u_210703', 'Q++sYsheZmo=', '游客260282', null, null, null, '2018-09-26 14:31:45', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210704', 'u_210704', 'Q++sYsheZmo=', '游客602081', null, null, null, '2018-09-26 14:33:44', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210705', 'u_210705', 'Q++sYsheZmo=', '游客861311', null, null, null, '2018-09-26 14:38:14', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210706', 'u_210706', 'Q++sYsheZmo=', '游客607878', null, null, null, '2018-09-26 14:42:21', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210707', 'u_210707', 'Q++sYsheZmo=', '游客476842', null, null, null, '2018-09-26 14:43:10', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210708', 'u_210708', 'Q++sYsheZmo=', '游客493669', null, null, null, '2018-09-26 14:43:46', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210709', 'u_210709', 'Q++sYsheZmo=', '游客383120', null, null, null, '2018-09-26 14:44:19', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210710', 'u_210710', 'Q++sYsheZmo=', '游客387910', null, null, null, '2018-09-26 14:45:49', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210711', 'u_210711', 'Q++sYsheZmo=', '游客554677', null, null, null, '2018-09-26 14:47:23', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210712', 'u_210712', 'Q++sYsheZmo=', '游客322651', null, null, null, '2018-09-26 14:49:31', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210713', 'u_210713', 'Q++sYsheZmo=', '游客861194', null, null, null, '2018-09-26 14:58:33', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210714', 'u_210714', 'Q++sYsheZmo=', '游客384694', null, null, null, '2018-09-26 15:00:19', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210715', 'u_210715', 'Q++sYsheZmo=', '游客894331', null, null, null, '2018-09-26 15:00:22', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210716', 'u_210716', 'Q++sYsheZmo=', '游客912873', null, null, null, '2018-09-26 15:00:23', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210717', 'u_210717', 'Q++sYsheZmo=', '游客560317', null, null, null, '2018-09-26 15:02:26', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210718', 'u_210718', 'Q++sYsheZmo=', '游客311569', null, null, null, '2018-09-26 15:02:27', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210719', 'u_210719', 'Q++sYsheZmo=', '游客766197', null, null, null, '2018-09-26 15:02:29', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210720', 'u_210720', 'Q++sYsheZmo=', '游客515334', null, null, null, '2018-09-26 15:02:30', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210721', 'u_210721', 'Q++sYsheZmo=', '游客785118', null, null, null, '2018-09-26 15:02:36', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210722', 'u_210722', 'Q++sYsheZmo=', '游客855603', null, null, null, '2018-09-26 15:05:28', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210723', 'u_210723', 'Q++sYsheZmo=', '游客519083', null, null, null, '2018-09-26 15:13:08', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210724', 'u_210724', 'Q++sYsheZmo=', '游客798240', null, null, null, '2018-09-26 15:13:08', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210725', 'u_210725', 'Q++sYsheZmo=', '游客350004', null, null, null, '2018-09-26 15:13:10', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210726', 'u_210726', 'Q++sYsheZmo=', '游客366733', null, null, null, '2018-09-26 15:13:11', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210727', 'u_210727', 'Q++sYsheZmo=', '游客633126', null, null, null, '2018-09-26 15:13:12', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210728', 'u_210728', 'Q++sYsheZmo=', '游客171967', null, null, null, '2018-09-26 15:13:29', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210729', 'u_210729', 'Q++sYsheZmo=', '游客200896', null, null, null, '2018-09-26 15:14:08', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210730', 'u_210730', 'Q++sYsheZmo=', '游客544828', null, null, null, '2018-09-26 15:14:09', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210731', 'u_210731', 'Q++sYsheZmo=', '游客237988', null, null, null, '2018-09-26 15:14:11', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210732', 'u_210732', 'Q++sYsheZmo=', '游客372858', null, null, null, '2018-09-26 15:26:09', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210733', 'u_210733', 'Q++sYsheZmo=', '游客674825', null, null, null, '2018-09-26 15:26:10', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210734', 'u_210734', 'Q++sYsheZmo=', '游客481118', null, null, null, '2018-09-26 15:26:11', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210735', 'u_210735', 'Q++sYsheZmo=', '游客720747', null, null, null, '2018-09-26 15:26:13', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210736', 'u_210736', 'Q++sYsheZmo=', '游客580113', null, null, null, '2018-09-26 15:27:28', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210737', 'u_210737', 'Q++sYsheZmo=', '游客522215', null, null, null, '2018-09-26 15:31:09', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210738', 'u_210738', 'Q++sYsheZmo=', '游客806538', null, null, null, '2018-09-26 15:31:10', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210739', 'u_210739', 'Q++sYsheZmo=', '游客459274', null, null, null, '2018-09-26 15:31:11', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210740', 'u_210740', 'Q++sYsheZmo=', '游客456527', null, null, null, '2018-09-26 15:31:12', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210741', 'u_210741', 'Q++sYsheZmo=', '游客955232', null, null, null, '2018-09-26 15:32:48', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210742', 'u_210742', 'Q++sYsheZmo=', '游客956743', null, null, null, '2018-09-26 15:32:49', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210743', 'u_210743', 'Q++sYsheZmo=', '游客415157', null, null, null, '2018-09-26 15:32:49', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210744', 'u_210744', 'Q++sYsheZmo=', '游客474154', null, null, null, '2018-09-26 15:32:50', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210745', 'u_210745', 'Q++sYsheZmo=', '游客693703', null, null, null, '2018-09-26 15:32:51', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210746', 'u_210746', 'Q++sYsheZmo=', '游客141117', null, null, null, '2018-09-26 15:48:23', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210747', 'u_210747', 'Q++sYsheZmo=', '游客146300', null, null, null, '2018-09-26 15:48:23', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210748', 'u_210748', 'Q++sYsheZmo=', '游客470773', null, null, null, '2018-09-26 15:48:24', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210749', 'u_210749', 'Q++sYsheZmo=', '游客386843', null, null, null, '2018-09-26 15:48:25', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210750', 'u_210750', 'Q++sYsheZmo=', '游客627378', null, null, null, '2018-09-26 15:48:26', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210751', 'u_210751', 'Q++sYsheZmo=', '游客637203', null, null, null, '2018-09-26 15:48:51', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210752', 'u_210752', 'Q++sYsheZmo=', '游客628998', null, null, null, '2018-09-26 15:48:52', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210753', 'u_210753', 'Q++sYsheZmo=', '游客187456', null, null, null, '2018-09-26 15:48:53', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210754', 'u_210754', 'Q++sYsheZmo=', '游客319420', null, null, null, '2018-09-26 15:48:54', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210755', 'u_210755', 'Q++sYsheZmo=', '游客210429', null, null, null, '2018-09-26 15:53:19', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210756', 'u_210756', 'Q++sYsheZmo=', '游客390165', null, null, null, '2018-09-26 15:53:20', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210757', 'u_210757', 'Q++sYsheZmo=', '游客721617', null, null, null, '2018-09-26 15:53:21', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210758', 'u_210758', 'Q++sYsheZmo=', '游客443678', null, null, null, '2018-09-26 15:53:23', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210759', 'u_210759', 'Q++sYsheZmo=', '游客896171', null, null, null, '2018-09-26 15:53:23', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210760', 'u_210760', 'Q++sYsheZmo=', '游客596062', null, null, null, '2018-09-26 16:00:13', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210761', 'u_210761', 'Q++sYsheZmo=', '游客858189', null, null, null, '2018-09-26 16:00:14', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210762', 'u_210762', 'Q++sYsheZmo=', '游客456177', null, null, null, '2018-09-26 16:00:15', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210763', 'u_210763', 'Q++sYsheZmo=', '游客226887', null, null, null, '2018-09-26 16:00:16', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210764', 'u_210764', 'Q++sYsheZmo=', '游客341042', null, null, null, '2018-09-26 16:22:26', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210765', 'u_210765', 'Q++sYsheZmo=', '游客458119', null, null, null, '2018-09-26 16:22:26', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210766', 'u_210766', 'Q++sYsheZmo=', '游客504947', null, null, null, '2018-09-26 16:22:27', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210767', 'u_210767', 'Q++sYsheZmo=', '游客820595', null, null, null, '2018-09-26 16:22:29', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210768', 'u_210768', 'Q++sYsheZmo=', '游客827542', null, null, null, '2018-09-26 16:22:59', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210769', 'u_210769', 'Q++sYsheZmo=', '游客486939', null, null, null, '2018-09-26 16:23:50', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210770', 'u_210770', 'Q++sYsheZmo=', '游客787688', null, null, null, '2018-09-26 16:23:50', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210771', 'u_210771', 'Q++sYsheZmo=', '游客715617', null, null, null, '2018-09-26 16:23:51', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210772', 'u_210772', 'Q++sYsheZmo=', '游客877086', null, null, null, '2018-09-26 16:23:52', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210773', 'u_210773', 'Q++sYsheZmo=', '游客894417', null, null, null, '2018-09-26 16:36:26', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210774', 'u_210774', 'Q++sYsheZmo=', '游客701012', null, null, null, '2018-09-26 16:36:27', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210775', 'u_210775', 'Q++sYsheZmo=', '游客264635', null, null, null, '2018-09-26 16:36:28', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210776', 'u_210776', 'Q++sYsheZmo=', '游客718941', null, null, null, '2018-09-26 16:36:29', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210777', 'u_210777', 'Q++sYsheZmo=', '游客212121', null, null, null, '2018-09-26 16:40:29', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210778', 'u_210778', 'Q++sYsheZmo=', '游客466345', null, null, null, '2018-09-26 16:40:30', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210779', 'u_210779', 'Q++sYsheZmo=', '游客785343', null, null, null, '2018-09-26 16:40:31', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210780', 'u_210780', 'Q++sYsheZmo=', '游客783831', null, null, null, '2018-09-26 16:40:32', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210781', 'u_210781', 'Q++sYsheZmo=', '游客383735', null, null, null, '2018-09-26 16:52:11', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210782', 'u_210782', 'Q++sYsheZmo=', '游客311664', null, null, null, '2018-09-26 16:52:12', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210783', 'u_210783', 'Q++sYsheZmo=', '游客154766', null, null, null, '2018-09-26 16:52:13', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210784', 'u_210784', 'Q++sYsheZmo=', '游客558630', null, null, null, '2018-09-26 16:52:17', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210785', 'u_210785', 'Q++sYsheZmo=', '游客413692', null, null, null, '2018-09-26 16:54:59', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210786', 'u_210786', 'Q++sYsheZmo=', '游客169210', null, null, null, '2018-09-26 16:55:00', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210787', 'u_210787', 'Q++sYsheZmo=', '游客724485', null, null, null, '2018-09-26 16:55:01', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210788', 'u_210788', 'Q++sYsheZmo=', '游客431949', null, null, null, '2018-09-26 16:55:02', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210789', 'u_210789', 'Q++sYsheZmo=', '游客126614', null, null, null, '2018-09-26 16:59:45', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210790', 'u_210790', 'Q++sYsheZmo=', '游客509461', null, null, null, '2018-09-26 16:59:45', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210791', 'u_210791', 'Q++sYsheZmo=', '游客635589', null, null, null, '2018-09-26 16:59:52', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210792', 'u_210792', 'Q++sYsheZmo=', '游客531578', null, null, null, '2018-09-26 16:59:54', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210793', 'u_210793', 'Q++sYsheZmo=', '游客811614', null, null, null, '2018-09-26 17:03:21', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210794', 'u_210794', 'Q++sYsheZmo=', '游客749276', null, null, null, '2018-09-26 17:03:21', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210795', 'u_210795', 'Q++sYsheZmo=', '游客405345', null, null, null, '2018-09-26 17:03:22', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210796', 'u_210796', 'Q++sYsheZmo=', '游客379185', null, null, null, '2018-09-26 17:03:23', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210797', 'u_210797', 'Q++sYsheZmo=', '游客121942', null, null, null, '2018-09-26 17:08:03', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210798', 'u_210798', 'Q++sYsheZmo=', '游客568345', null, null, null, '2018-09-26 17:08:03', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210799', 'u_210799', 'Q++sYsheZmo=', '游客121327', null, null, null, '2018-09-26 17:08:04', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210800', 'u_210800', 'Q++sYsheZmo=', '游客249150', null, null, null, '2018-09-26 17:08:41', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210801', 'u_210801', 'Q++sYsheZmo=', '游客741006', null, null, null, '2018-09-26 17:27:32', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210802', 'u_210802', 'Q++sYsheZmo=', '游客122477', null, null, null, '2018-09-26 17:27:32', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210803', 'u_210803', 'Q++sYsheZmo=', '游客402249', null, null, null, '2018-09-26 17:27:33', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210804', 'u_210804', 'Q++sYsheZmo=', '游客446339', null, null, null, '2018-09-26 17:27:34', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210805', 'u_210805', 'Q++sYsheZmo=', '游客764460', null, null, null, '2018-09-26 17:31:16', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210806', 'u_210806', 'Q++sYsheZmo=', '游客767500', null, null, null, '2018-09-26 17:31:17', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210807', 'u_210807', 'Q++sYsheZmo=', '游客329914', null, null, null, '2018-09-26 17:31:18', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210808', 'u_210808', 'Q++sYsheZmo=', '游客816157', null, null, null, '2018-09-26 17:31:19', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210809', 'u_210809', 'Q++sYsheZmo=', '游客737578', null, null, null, '2018-09-26 17:32:33', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210810', 'u_210810', 'Q++sYsheZmo=', '游客489775', null, null, null, '2018-09-26 17:33:10', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210811', 'u_210811', 'Q++sYsheZmo=', '游客543891', null, null, null, '2018-09-26 17:33:11', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210812', 'u_210812', 'Q++sYsheZmo=', '游客753414', null, null, null, '2018-09-26 17:33:12', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210813', 'u_210813', 'Q++sYsheZmo=', '游客765876', null, null, null, '2018-09-26 17:33:12', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210814', 'u_210814', 'Q++sYsheZmo=', '游客759200', null, null, null, '2018-09-26 17:35:00', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210815', 'u_210815', 'Q++sYsheZmo=', '游客121507', null, null, null, '2018-09-26 17:35:00', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210816', 'u_210816', 'Q++sYsheZmo=', '游客183241', null, null, null, '2018-09-26 17:35:01', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210817', 'u_210817', 'Q++sYsheZmo=', '游客811193', null, null, null, '2018-09-26 17:35:02', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210818', 'u_210818', 'Q++sYsheZmo=', '游客583749', null, null, null, '2018-09-26 17:42:25', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210819', 'u_210819', 'Q++sYsheZmo=', '游客711777', null, null, null, '2018-09-26 17:42:26', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210820', 'u_210820', 'Q++sYsheZmo=', '游客765893', null, null, null, '2018-09-26 17:42:26', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210821', 'u_210821', 'Q++sYsheZmo=', '游客599564', null, null, null, '2018-09-26 17:42:27', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210822', 'u_210822', 'Q++sYsheZmo=', '游客527294', null, null, null, '2018-09-26 17:51:56', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');
INSERT INTO `user_info` VALUES ('210823', 'u_210823', 'Q++sYsheZmo=', '游客608646', null, null, null, '2018-09-26 17:52:49', null, null, null, null, '0', '0', null, null, null, null, null, '1', '0', '0');

-- ----------------------------
-- Table structure for user_log
-- ----------------------------
DROP TABLE IF EXISTS `user_log`;
CREATE TABLE `user_log` (
  `id` int(11) NOT NULL AUTO_INCREMENT COMMENT 'id',
  `userid` int(11) DEFAULT NULL COMMENT '玩家ID',
  `logtype` char(1) DEFAULT NULL COMMENT '1绑定关系2解除关系3玩家登陆',
  `addtime` datetime DEFAULT NULL COMMENT '添加时间',
  `remark` varchar(500) DEFAULT NULL COMMENT '备注',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=907 DEFAULT CHARSET=utf8 COMMENT='玩家操作日志';

-- ----------------------------
-- Records of user_log
-- ----------------------------
INSERT INTO `user_log` VALUES ('1', '210001', '3', '2018-09-22 16:31:12', '玩家登录');
INSERT INTO `user_log` VALUES ('2', '210002', '3', '2018-09-22 16:31:13', '玩家登录');
INSERT INTO `user_log` VALUES ('3', '210003', '3', '2018-09-22 16:31:14', '玩家登录');
INSERT INTO `user_log` VALUES ('4', '210004', '3', '2018-09-22 16:31:15', '玩家登录');
INSERT INTO `user_log` VALUES ('5', '210005', '3', '2018-09-22 16:34:50', '玩家登录');
INSERT INTO `user_log` VALUES ('6', '210006', '3', '2018-09-22 16:38:37', '玩家登录');
INSERT INTO `user_log` VALUES ('7', '210007', '3', '2018-09-22 16:38:38', '玩家登录');
INSERT INTO `user_log` VALUES ('8', '210008', '3', '2018-09-22 16:38:39', '玩家登录');
INSERT INTO `user_log` VALUES ('9', '210009', '3', '2018-09-22 16:38:40', '玩家登录');
INSERT INTO `user_log` VALUES ('10', '210011', '3', '2018-09-22 16:40:25', '玩家登录');
INSERT INTO `user_log` VALUES ('11', '210012', '3', '2018-09-22 16:40:26', '玩家登录');
INSERT INTO `user_log` VALUES ('12', '210013', '3', '2018-09-22 16:40:27', '玩家登录');
INSERT INTO `user_log` VALUES ('13', '210014', '3', '2018-09-22 16:40:28', '玩家登录');
INSERT INTO `user_log` VALUES ('14', '210006', '3', '2018-09-22 16:41:56', '玩家登录');
INSERT INTO `user_log` VALUES ('15', '210016', '3', '2018-09-22 16:42:04', '玩家登录');
INSERT INTO `user_log` VALUES ('16', '210006', '3', '2018-09-22 16:42:26', '玩家登录');
INSERT INTO `user_log` VALUES ('17', '210006', '3', '2018-09-22 16:42:28', '玩家登录');
INSERT INTO `user_log` VALUES ('18', '210017', '3', '2018-09-22 16:43:34', '玩家登录');
INSERT INTO `user_log` VALUES ('19', '210018', '3', '2018-09-22 16:43:35', '玩家登录');
INSERT INTO `user_log` VALUES ('20', '210019', '3', '2018-09-22 16:43:36', '玩家登录');
INSERT INTO `user_log` VALUES ('21', '210020', '3', '2018-09-22 16:43:37', '玩家登录');
INSERT INTO `user_log` VALUES ('22', '210020', '1', '2018-09-22 16:57:00', '更改绑定关系');
INSERT INTO `user_log` VALUES ('23', '210022', '3', '2018-09-22 16:57:04', '玩家登录');
INSERT INTO `user_log` VALUES ('24', '210023', '3', '2018-09-22 16:57:05', '玩家登录');
INSERT INTO `user_log` VALUES ('25', '210024', '3', '2018-09-22 16:57:06', '玩家登录');
INSERT INTO `user_log` VALUES ('26', '210019', '1', '2018-09-22 16:57:07', '更改绑定关系');
INSERT INTO `user_log` VALUES ('27', '210025', '3', '2018-09-22 16:57:07', '玩家登录');
INSERT INTO `user_log` VALUES ('28', '210006', '3', '2018-09-22 17:00:11', '玩家登录');
INSERT INTO `user_log` VALUES ('29', '210006', '3', '2018-09-22 17:02:07', '玩家登录');
INSERT INTO `user_log` VALUES ('30', '210026', '3', '2018-09-22 17:08:59', '玩家登录');
INSERT INTO `user_log` VALUES ('31', '210026', '3', '2018-09-22 17:09:25', '玩家登录');
INSERT INTO `user_log` VALUES ('32', '210027', '3', '2018-09-22 17:09:46', '玩家登录');
INSERT INTO `user_log` VALUES ('33', '210028', '3', '2018-09-22 17:09:47', '玩家登录');
INSERT INTO `user_log` VALUES ('34', '210029', '3', '2018-09-22 17:09:48', '玩家登录');
INSERT INTO `user_log` VALUES ('35', '210030', '3', '2018-09-22 17:09:49', '玩家登录');
INSERT INTO `user_log` VALUES ('36', '210006', '3', '2018-09-22 17:10:15', '玩家登录');
INSERT INTO `user_log` VALUES ('37', '210006', '3', '2018-09-22 17:10:40', '玩家登录');
INSERT INTO `user_log` VALUES ('38', '210006', '3', '2018-09-22 17:10:43', '玩家登录');
INSERT INTO `user_log` VALUES ('39', '210006', '3', '2018-09-22 17:12:37', '玩家登录');
INSERT INTO `user_log` VALUES ('40', '210006', '3', '2018-09-22 17:13:09', '玩家登录');
INSERT INTO `user_log` VALUES ('41', '210006', '3', '2018-09-22 17:13:51', '玩家登录');
INSERT INTO `user_log` VALUES ('42', '210006', '3', '2018-09-22 17:13:54', '玩家登录');
INSERT INTO `user_log` VALUES ('43', '210031', '3', '2018-09-22 17:14:38', '玩家登录');
INSERT INTO `user_log` VALUES ('44', '210032', '3', '2018-09-22 17:14:52', '玩家登录');
INSERT INTO `user_log` VALUES ('45', '210033', '3', '2018-09-22 17:15:00', '玩家登录');
INSERT INTO `user_log` VALUES ('46', '210034', '3', '2018-09-22 17:15:01', '玩家登录');
INSERT INTO `user_log` VALUES ('47', '210035', '3', '2018-09-22 17:16:12', '玩家登录');
INSERT INTO `user_log` VALUES ('48', '210036', '3', '2018-09-22 17:18:34', '玩家登录');
INSERT INTO `user_log` VALUES ('49', '210037', '3', '2018-09-22 17:19:07', '玩家登录');
INSERT INTO `user_log` VALUES ('50', '210038', '3', '2018-09-22 17:19:13', '玩家登录');
INSERT INTO `user_log` VALUES ('51', '210039', '3', '2018-09-22 17:19:14', '玩家登录');
INSERT INTO `user_log` VALUES ('52', '210040', '3', '2018-09-22 17:19:15', '玩家登录');
INSERT INTO `user_log` VALUES ('53', '210041', '3', '2018-09-22 17:19:15', '玩家登录');
INSERT INTO `user_log` VALUES ('54', '210042', '3', '2018-09-22 17:20:18', '玩家登录');
INSERT INTO `user_log` VALUES ('55', '210043', '3', '2018-09-22 17:20:32', '玩家登录');
INSERT INTO `user_log` VALUES ('56', '210006', '3', '2018-09-22 17:21:38', '玩家登录');
INSERT INTO `user_log` VALUES ('57', '210044', '3', '2018-09-22 17:21:52', '玩家登录');
INSERT INTO `user_log` VALUES ('58', '210042', '3', '2018-09-22 17:22:20', '玩家登录');
INSERT INTO `user_log` VALUES ('59', '210006', '3', '2018-09-22 17:22:31', '玩家登录');
INSERT INTO `user_log` VALUES ('60', '210045', '3', '2018-09-22 17:23:02', '玩家登录');
INSERT INTO `user_log` VALUES ('61', '210046', '3', '2018-09-22 17:23:17', '玩家登录');
INSERT INTO `user_log` VALUES ('62', '210047', '3', '2018-09-22 17:23:18', '玩家登录');
INSERT INTO `user_log` VALUES ('63', '210048', '3', '2018-09-22 17:23:19', '玩家登录');
INSERT INTO `user_log` VALUES ('64', '210049', '3', '2018-09-22 17:23:19', '玩家登录');
INSERT INTO `user_log` VALUES ('65', '210050', '3', '2018-09-22 17:23:37', '玩家登录');
INSERT INTO `user_log` VALUES ('66', '210051', '3', '2018-09-22 17:23:59', '玩家登录');
INSERT INTO `user_log` VALUES ('67', '210052', '3', '2018-09-22 17:25:34', '玩家登录');
INSERT INTO `user_log` VALUES ('68', '210053', '3', '2018-09-22 17:26:04', '玩家登录');
INSERT INTO `user_log` VALUES ('69', '210054', '3', '2018-09-22 17:26:05', '玩家登录');
INSERT INTO `user_log` VALUES ('70', '210055', '3', '2018-09-22 17:26:06', '玩家登录');
INSERT INTO `user_log` VALUES ('71', '210056', '3', '2018-09-22 17:26:07', '玩家登录');
INSERT INTO `user_log` VALUES ('72', '210057', '3', '2018-09-22 17:28:45', '玩家登录');
INSERT INTO `user_log` VALUES ('73', '210058', '3', '2018-09-22 17:28:46', '玩家登录');
INSERT INTO `user_log` VALUES ('74', '210059', '3', '2018-09-22 17:28:46', '玩家登录');
INSERT INTO `user_log` VALUES ('75', '210060', '3', '2018-09-22 17:28:47', '玩家登录');
INSERT INTO `user_log` VALUES ('76', '210061', '3', '2018-09-22 17:29:42', '玩家登录');
INSERT INTO `user_log` VALUES ('77', '210062', '3', '2018-09-22 17:29:44', '玩家登录');
INSERT INTO `user_log` VALUES ('78', '210063', '3', '2018-09-22 17:29:45', '玩家登录');
INSERT INTO `user_log` VALUES ('79', '210064', '3', '2018-09-22 17:29:46', '玩家登录');
INSERT INTO `user_log` VALUES ('80', '210052', '3', '2018-09-22 17:29:46', '玩家登录');
INSERT INTO `user_log` VALUES ('81', '210052', '3', '2018-09-22 17:33:56', '玩家登录');
INSERT INTO `user_log` VALUES ('82', '210065', '3', '2018-09-22 17:33:57', '玩家登录');
INSERT INTO `user_log` VALUES ('83', '210006', '3', '2018-09-22 17:36:34', '玩家登录');
INSERT INTO `user_log` VALUES ('84', '210066', '3', '2018-09-22 17:39:41', '玩家登录');
INSERT INTO `user_log` VALUES ('85', '210067', '3', '2018-09-22 17:40:04', '玩家登录');
INSERT INTO `user_log` VALUES ('86', '210068', '3', '2018-09-22 17:40:17', '玩家登录');
INSERT INTO `user_log` VALUES ('87', '210069', '3', '2018-09-22 17:41:28', '玩家登录');
INSERT INTO `user_log` VALUES ('88', '210070', '3', '2018-09-22 17:41:29', '玩家登录');
INSERT INTO `user_log` VALUES ('89', '210071', '3', '2018-09-22 17:41:30', '玩家登录');
INSERT INTO `user_log` VALUES ('90', '210072', '3', '2018-09-22 17:41:31', '玩家登录');
INSERT INTO `user_log` VALUES ('91', '210073', '3', '2018-09-22 17:42:30', '玩家登录');
INSERT INTO `user_log` VALUES ('92', '210074', '3', '2018-09-22 17:42:31', '玩家登录');
INSERT INTO `user_log` VALUES ('93', '210075', '3', '2018-09-22 17:42:32', '玩家登录');
INSERT INTO `user_log` VALUES ('94', '210076', '3', '2018-09-22 17:42:45', '玩家登录');
INSERT INTO `user_log` VALUES ('95', '210077', '3', '2018-09-22 17:58:27', '玩家登录');
INSERT INTO `user_log` VALUES ('96', '210078', '3', '2018-09-22 17:58:28', '玩家登录');
INSERT INTO `user_log` VALUES ('97', '210079', '3', '2018-09-22 17:58:29', '玩家登录');
INSERT INTO `user_log` VALUES ('98', '210080', '3', '2018-09-22 17:58:30', '玩家登录');
INSERT INTO `user_log` VALUES ('99', '210081', '3', '2018-09-22 18:01:39', '玩家登录');
INSERT INTO `user_log` VALUES ('100', '210082', '3', '2018-09-22 18:01:40', '玩家登录');
INSERT INTO `user_log` VALUES ('101', '210083', '3', '2018-09-22 18:19:52', '玩家登录');
INSERT INTO `user_log` VALUES ('102', '210084', '3', '2018-09-22 18:20:20', '玩家登录');
INSERT INTO `user_log` VALUES ('103', '210085', '3', '2018-09-22 18:20:21', '玩家登录');
INSERT INTO `user_log` VALUES ('104', '210086', '3', '2018-09-22 18:20:24', '玩家登录');
INSERT INTO `user_log` VALUES ('105', '210087', '3', '2018-09-22 18:28:15', '玩家登录');
INSERT INTO `user_log` VALUES ('106', '210088', '3', '2018-09-22 18:28:16', '玩家登录');
INSERT INTO `user_log` VALUES ('107', '210089', '3', '2018-09-22 18:28:17', '玩家登录');
INSERT INTO `user_log` VALUES ('108', '210090', '3', '2018-09-22 18:28:17', '玩家登录');
INSERT INTO `user_log` VALUES ('109', '210082', '3', '2018-09-22 19:02:38', '玩家登录');
INSERT INTO `user_log` VALUES ('110', '210082', '3', '2018-09-22 19:03:02', '玩家登录');
INSERT INTO `user_log` VALUES ('111', '210091', '3', '2018-09-22 19:03:15', '玩家登录');
INSERT INTO `user_log` VALUES ('112', '210092', '3', '2018-09-22 19:04:18', '玩家登录');
INSERT INTO `user_log` VALUES ('113', '210093', '3', '2018-09-22 19:04:49', '玩家登录');
INSERT INTO `user_log` VALUES ('114', '210094', '3', '2018-09-22 19:06:17', '玩家登录');
INSERT INTO `user_log` VALUES ('115', '210093', '3', '2018-09-22 19:07:39', '玩家登录');
INSERT INTO `user_log` VALUES ('116', '210093', '3', '2018-09-22 19:09:44', '玩家登录');
INSERT INTO `user_log` VALUES ('117', '210095', '3', '2018-09-22 19:09:48', '玩家登录');
INSERT INTO `user_log` VALUES ('118', '210095', '3', '2018-09-22 19:11:53', '玩家登录');
INSERT INTO `user_log` VALUES ('119', '210095', '3', '2018-09-22 19:12:37', '玩家登录');
INSERT INTO `user_log` VALUES ('120', '210096', '3', '2018-09-22 19:12:38', '玩家登录');
INSERT INTO `user_log` VALUES ('121', '210096', '3', '2018-09-22 19:26:01', '玩家登录');
INSERT INTO `user_log` VALUES ('122', '210096', '3', '2018-09-22 19:27:19', '玩家登录');
INSERT INTO `user_log` VALUES ('123', '210096', '3', '2018-09-22 19:29:07', '玩家登录');
INSERT INTO `user_log` VALUES ('124', '210096', '3', '2018-09-22 19:29:24', '玩家登录');
INSERT INTO `user_log` VALUES ('125', '210096', '3', '2018-09-22 19:29:39', '玩家登录');
INSERT INTO `user_log` VALUES ('126', '210096', '3', '2018-09-22 19:30:21', '玩家登录');
INSERT INTO `user_log` VALUES ('127', '210096', '3', '2018-09-22 19:32:58', '玩家登录');
INSERT INTO `user_log` VALUES ('128', '210096', '3', '2018-09-22 19:33:19', '玩家登录');
INSERT INTO `user_log` VALUES ('129', '210096', '3', '2018-09-22 19:33:40', '玩家登录');
INSERT INTO `user_log` VALUES ('130', '210096', '3', '2018-09-22 19:34:51', '玩家登录');
INSERT INTO `user_log` VALUES ('131', '210096', '3', '2018-09-22 19:35:24', '玩家登录');
INSERT INTO `user_log` VALUES ('132', '210096', '3', '2018-09-22 19:36:05', '玩家登录');
INSERT INTO `user_log` VALUES ('133', '210006', '3', '2018-09-22 19:39:14', '玩家登录');
INSERT INTO `user_log` VALUES ('134', '210006', '3', '2018-09-22 19:43:45', '玩家登录');
INSERT INTO `user_log` VALUES ('135', '210097', '3', '2018-09-22 19:44:56', '玩家登录');
INSERT INTO `user_log` VALUES ('136', '210098', '3', '2018-09-22 19:44:58', '玩家登录');
INSERT INTO `user_log` VALUES ('137', '210099', '3', '2018-09-22 19:44:59', '玩家登录');
INSERT INTO `user_log` VALUES ('138', '210100', '3', '2018-09-22 19:45:00', '玩家登录');
INSERT INTO `user_log` VALUES ('139', '210006', '3', '2018-09-22 19:48:33', '玩家登录');
INSERT INTO `user_log` VALUES ('140', '210006', '3', '2018-09-22 19:49:11', '玩家登录');
INSERT INTO `user_log` VALUES ('141', '210101', '3', '2018-09-22 20:10:07', '玩家登录');
INSERT INTO `user_log` VALUES ('142', '210102', '3', '2018-09-22 20:10:20', '玩家登录');
INSERT INTO `user_log` VALUES ('143', '210103', '3', '2018-09-22 20:10:30', '玩家登录');
INSERT INTO `user_log` VALUES ('144', '210104', '3', '2018-09-22 20:10:31', '玩家登录');
INSERT INTO `user_log` VALUES ('145', '210105', '3', '2018-09-22 20:12:11', '玩家登录');
INSERT INTO `user_log` VALUES ('146', '210106', '3', '2018-09-22 20:12:12', '玩家登录');
INSERT INTO `user_log` VALUES ('147', '210107', '3', '2018-09-22 20:12:14', '玩家登录');
INSERT INTO `user_log` VALUES ('148', '210108', '3', '2018-09-22 20:12:15', '玩家登录');
INSERT INTO `user_log` VALUES ('149', '210109', '3', '2018-09-22 20:13:36', '玩家登录');
INSERT INTO `user_log` VALUES ('150', '210110', '3', '2018-09-22 20:13:37', '玩家登录');
INSERT INTO `user_log` VALUES ('151', '210111', '3', '2018-09-22 20:13:38', '玩家登录');
INSERT INTO `user_log` VALUES ('152', '210112', '3', '2018-09-22 20:13:39', '玩家登录');
INSERT INTO `user_log` VALUES ('153', '210113', '3', '2018-09-22 20:18:57', '玩家登录');
INSERT INTO `user_log` VALUES ('154', '210114', '3', '2018-09-22 20:18:57', '玩家登录');
INSERT INTO `user_log` VALUES ('155', '210115', '3', '2018-09-22 20:18:58', '玩家登录');
INSERT INTO `user_log` VALUES ('156', '210116', '3', '2018-09-22 20:18:59', '玩家登录');
INSERT INTO `user_log` VALUES ('157', '210117', '3', '2018-09-22 20:51:55', '玩家登录');
INSERT INTO `user_log` VALUES ('158', '210118', '3', '2018-09-22 20:51:56', '玩家登录');
INSERT INTO `user_log` VALUES ('159', '210119', '3', '2018-09-22 20:51:57', '玩家登录');
INSERT INTO `user_log` VALUES ('160', '210120', '3', '2018-09-22 20:51:58', '玩家登录');
INSERT INTO `user_log` VALUES ('161', '210121', '3', '2018-09-22 20:53:49', '玩家登录');
INSERT INTO `user_log` VALUES ('162', '210122', '3', '2018-09-22 20:53:50', '玩家登录');
INSERT INTO `user_log` VALUES ('163', '210123', '3', '2018-09-22 20:53:51', '玩家登录');
INSERT INTO `user_log` VALUES ('164', '210124', '3', '2018-09-22 20:53:52', '玩家登录');
INSERT INTO `user_log` VALUES ('165', '210125', '3', '2018-09-22 20:56:41', '玩家登录');
INSERT INTO `user_log` VALUES ('166', '210126', '3', '2018-09-22 20:56:42', '玩家登录');
INSERT INTO `user_log` VALUES ('167', '210127', '3', '2018-09-22 20:56:43', '玩家登录');
INSERT INTO `user_log` VALUES ('168', '210128', '3', '2018-09-22 20:56:44', '玩家登录');
INSERT INTO `user_log` VALUES ('169', '210129', '3', '2018-09-23 09:49:04', '玩家登录');
INSERT INTO `user_log` VALUES ('170', '210130', '3', '2018-09-23 09:50:30', '玩家登录');
INSERT INTO `user_log` VALUES ('171', '210131', '3', '2018-09-23 14:01:38', '玩家登录');
INSERT INTO `user_log` VALUES ('172', '210132', '3', '2018-09-23 14:01:51', '玩家登录');
INSERT INTO `user_log` VALUES ('173', '210133', '3', '2018-09-23 14:02:22', '玩家登录');
INSERT INTO `user_log` VALUES ('174', '210134', '3', '2018-09-23 14:02:23', '玩家登录');
INSERT INTO `user_log` VALUES ('175', '210135', '3', '2018-09-23 14:08:26', '玩家登录');
INSERT INTO `user_log` VALUES ('176', '210136', '3', '2018-09-23 14:08:26', '玩家登录');
INSERT INTO `user_log` VALUES ('177', '210137', '3', '2018-09-23 14:08:27', '玩家登录');
INSERT INTO `user_log` VALUES ('178', '210138', '3', '2018-09-23 14:08:28', '玩家登录');
INSERT INTO `user_log` VALUES ('179', '210139', '3', '2018-09-23 14:13:33', '玩家登录');
INSERT INTO `user_log` VALUES ('180', '210140', '3', '2018-09-23 14:13:34', '玩家登录');
INSERT INTO `user_log` VALUES ('181', '210141', '3', '2018-09-23 14:13:35', '玩家登录');
INSERT INTO `user_log` VALUES ('182', '210142', '3', '2018-09-23 14:13:36', '玩家登录');
INSERT INTO `user_log` VALUES ('183', '210143', '3', '2018-09-23 14:18:25', '玩家登录');
INSERT INTO `user_log` VALUES ('184', '210144', '3', '2018-09-23 14:18:26', '玩家登录');
INSERT INTO `user_log` VALUES ('185', '210145', '3', '2018-09-23 14:18:27', '玩家登录');
INSERT INTO `user_log` VALUES ('186', '210146', '3', '2018-09-23 14:18:28', '玩家登录');
INSERT INTO `user_log` VALUES ('187', '210147', '3', '2018-09-23 15:11:34', '玩家登录');
INSERT INTO `user_log` VALUES ('188', '210148', '3', '2018-09-23 15:11:52', '玩家登录');
INSERT INTO `user_log` VALUES ('189', '210149', '3', '2018-09-23 15:11:54', '玩家登录');
INSERT INTO `user_log` VALUES ('190', '210150', '3', '2018-09-23 15:11:54', '玩家登录');
INSERT INTO `user_log` VALUES ('191', '210151', '3', '2018-09-23 15:14:49', '玩家登录');
INSERT INTO `user_log` VALUES ('192', '210152', '3', '2018-09-23 15:14:50', '玩家登录');
INSERT INTO `user_log` VALUES ('193', '210153', '3', '2018-09-23 15:14:51', '玩家登录');
INSERT INTO `user_log` VALUES ('194', '210154', '3', '2018-09-23 15:14:52', '玩家登录');
INSERT INTO `user_log` VALUES ('195', '210155', '3', '2018-09-23 15:16:55', '玩家登录');
INSERT INTO `user_log` VALUES ('196', '210156', '3', '2018-09-23 15:16:55', '玩家登录');
INSERT INTO `user_log` VALUES ('197', '210157', '3', '2018-09-23 15:16:56', '玩家登录');
INSERT INTO `user_log` VALUES ('198', '210158', '3', '2018-09-23 15:16:58', '玩家登录');
INSERT INTO `user_log` VALUES ('199', '210159', '3', '2018-09-23 15:28:06', '玩家登录');
INSERT INTO `user_log` VALUES ('200', '210160', '3', '2018-09-23 15:28:07', '玩家登录');
INSERT INTO `user_log` VALUES ('201', '210161', '3', '2018-09-23 15:28:08', '玩家登录');
INSERT INTO `user_log` VALUES ('202', '210162', '3', '2018-09-23 15:28:09', '玩家登录');
INSERT INTO `user_log` VALUES ('203', '210163', '3', '2018-09-23 15:35:05', '玩家登录');
INSERT INTO `user_log` VALUES ('204', '210164', '3', '2018-09-23 15:35:05', '玩家登录');
INSERT INTO `user_log` VALUES ('205', '210165', '3', '2018-09-23 15:35:06', '玩家登录');
INSERT INTO `user_log` VALUES ('206', '210166', '3', '2018-09-23 15:35:07', '玩家登录');
INSERT INTO `user_log` VALUES ('207', '210167', '3', '2018-09-23 15:36:14', '玩家登录');
INSERT INTO `user_log` VALUES ('208', '210168', '3', '2018-09-23 15:37:01', '玩家登录');
INSERT INTO `user_log` VALUES ('209', '210169', '3', '2018-09-23 15:37:01', '玩家登录');
INSERT INTO `user_log` VALUES ('210', '210170', '3', '2018-09-23 15:37:02', '玩家登录');
INSERT INTO `user_log` VALUES ('211', '210171', '3', '2018-09-23 15:37:03', '玩家登录');
INSERT INTO `user_log` VALUES ('212', '210172', '3', '2018-09-23 15:38:20', '玩家登录');
INSERT INTO `user_log` VALUES ('213', '210173', '3', '2018-09-23 15:38:21', '玩家登录');
INSERT INTO `user_log` VALUES ('214', '210174', '3', '2018-09-23 15:38:22', '玩家登录');
INSERT INTO `user_log` VALUES ('215', '210175', '3', '2018-09-23 15:38:23', '玩家登录');
INSERT INTO `user_log` VALUES ('216', '210176', '3', '2018-09-23 15:38:37', '玩家登录');
INSERT INTO `user_log` VALUES ('217', '210177', '3', '2018-09-23 15:41:12', '玩家登录');
INSERT INTO `user_log` VALUES ('218', '210178', '3', '2018-09-23 15:43:08', '玩家登录');
INSERT INTO `user_log` VALUES ('219', '210179', '3', '2018-09-23 15:43:37', '玩家登录');
INSERT INTO `user_log` VALUES ('220', '210180', '3', '2018-09-23 15:44:08', '玩家登录');
INSERT INTO `user_log` VALUES ('221', '210181', '3', '2018-09-23 15:44:08', '玩家登录');
INSERT INTO `user_log` VALUES ('222', '210182', '3', '2018-09-23 15:49:01', '玩家登录');
INSERT INTO `user_log` VALUES ('223', '210183', '3', '2018-09-23 15:49:23', '玩家登录');
INSERT INTO `user_log` VALUES ('224', '210184', '3', '2018-09-23 15:49:24', '玩家登录');
INSERT INTO `user_log` VALUES ('225', '210185', '3', '2018-09-23 15:51:11', '玩家登录');
INSERT INTO `user_log` VALUES ('226', '210186', '3', '2018-09-23 15:52:10', '玩家登录');
INSERT INTO `user_log` VALUES ('227', '210187', '3', '2018-09-23 15:52:11', '玩家登录');
INSERT INTO `user_log` VALUES ('228', '210188', '3', '2018-09-23 15:52:12', '玩家登录');
INSERT INTO `user_log` VALUES ('229', '210189', '3', '2018-09-23 15:52:13', '玩家登录');
INSERT INTO `user_log` VALUES ('230', '210190', '3', '2018-09-23 15:54:43', '玩家登录');
INSERT INTO `user_log` VALUES ('231', '210191', '3', '2018-09-23 15:54:45', '玩家登录');
INSERT INTO `user_log` VALUES ('232', '210192', '3', '2018-09-23 15:54:46', '玩家登录');
INSERT INTO `user_log` VALUES ('233', '210193', '3', '2018-09-23 16:00:43', '玩家登录');
INSERT INTO `user_log` VALUES ('234', '210194', '3', '2018-09-23 16:00:47', '玩家登录');
INSERT INTO `user_log` VALUES ('235', '210195', '3', '2018-09-23 16:01:30', '玩家登录');
INSERT INTO `user_log` VALUES ('236', '210196', '3', '2018-09-23 16:17:19', '玩家登录');
INSERT INTO `user_log` VALUES ('237', '210197', '3', '2018-09-23 16:17:26', '玩家登录');
INSERT INTO `user_log` VALUES ('238', '210198', '3', '2018-09-23 16:18:03', '玩家登录');
INSERT INTO `user_log` VALUES ('239', '210199', '3', '2018-09-23 16:18:19', '玩家登录');
INSERT INTO `user_log` VALUES ('240', '210200', '3', '2018-09-23 16:18:40', '玩家登录');
INSERT INTO `user_log` VALUES ('241', '210201', '3', '2018-09-23 16:28:18', '玩家登录');
INSERT INTO `user_log` VALUES ('242', '210202', '3', '2018-09-23 16:28:28', '玩家登录');
INSERT INTO `user_log` VALUES ('243', '210203', '3', '2018-09-23 16:28:38', '玩家登录');
INSERT INTO `user_log` VALUES ('244', '210204', '3', '2018-09-23 16:28:48', '玩家登录');
INSERT INTO `user_log` VALUES ('245', '210205', '3', '2018-09-23 16:29:01', '玩家登录');
INSERT INTO `user_log` VALUES ('246', '210206', '3', '2018-09-23 16:30:35', '玩家登录');
INSERT INTO `user_log` VALUES ('247', '210207', '3', '2018-09-23 16:30:43', '玩家登录');
INSERT INTO `user_log` VALUES ('248', '210208', '3', '2018-09-23 16:30:44', '玩家登录');
INSERT INTO `user_log` VALUES ('249', '210209', '3', '2018-09-23 16:31:54', '玩家登录');
INSERT INTO `user_log` VALUES ('250', '210210', '3', '2018-09-23 16:32:19', '玩家登录');
INSERT INTO `user_log` VALUES ('251', '210211', '3', '2018-09-23 16:33:52', '玩家登录');
INSERT INTO `user_log` VALUES ('252', '210212', '3', '2018-09-23 16:33:53', '玩家登录');
INSERT INTO `user_log` VALUES ('253', '210213', '3', '2018-09-23 16:33:54', '玩家登录');
INSERT INTO `user_log` VALUES ('254', '210214', '3', '2018-09-23 16:33:55', '玩家登录');
INSERT INTO `user_log` VALUES ('255', '210215', '3', '2018-09-23 16:33:56', '玩家登录');
INSERT INTO `user_log` VALUES ('256', '210216', '3', '2018-09-23 16:36:53', '玩家登录');
INSERT INTO `user_log` VALUES ('257', '210217', '3', '2018-09-23 16:37:51', '玩家登录');
INSERT INTO `user_log` VALUES ('258', '210218', '3', '2018-09-23 16:38:40', '玩家登录');
INSERT INTO `user_log` VALUES ('259', '210219', '3', '2018-09-23 16:39:24', '玩家登录');
INSERT INTO `user_log` VALUES ('260', '210220', '3', '2018-09-23 16:40:32', '玩家登录');
INSERT INTO `user_log` VALUES ('261', '210221', '3', '2018-09-23 16:41:43', '玩家登录');
INSERT INTO `user_log` VALUES ('262', '210222', '3', '2018-09-23 16:52:01', '玩家登录');
INSERT INTO `user_log` VALUES ('263', '210223', '3', '2018-09-23 16:52:04', '玩家登录');
INSERT INTO `user_log` VALUES ('264', '210224', '3', '2018-09-23 16:52:11', '玩家登录');
INSERT INTO `user_log` VALUES ('265', '210225', '3', '2018-09-23 16:52:12', '玩家登录');
INSERT INTO `user_log` VALUES ('266', '210226', '3', '2018-09-23 16:57:26', '玩家登录');
INSERT INTO `user_log` VALUES ('267', '210227', '3', '2018-09-23 16:57:27', '玩家登录');
INSERT INTO `user_log` VALUES ('268', '210228', '3', '2018-09-23 16:57:28', '玩家登录');
INSERT INTO `user_log` VALUES ('269', '210229', '3', '2018-09-23 16:57:28', '玩家登录');
INSERT INTO `user_log` VALUES ('270', '210230', '3', '2018-09-23 17:21:25', '玩家登录');
INSERT INTO `user_log` VALUES ('271', '210231', '3', '2018-09-24 16:11:18', '玩家登录');
INSERT INTO `user_log` VALUES ('272', '210232', '3', '2018-09-24 16:11:20', '玩家登录');
INSERT INTO `user_log` VALUES ('273', '210233', '3', '2018-09-24 16:11:24', '玩家登录');
INSERT INTO `user_log` VALUES ('274', '210234', '3', '2018-09-24 16:11:37', '玩家登录');
INSERT INTO `user_log` VALUES ('275', '210235', '3', '2018-09-24 16:16:52', '玩家登录');
INSERT INTO `user_log` VALUES ('276', '210236', '3', '2018-09-24 16:16:53', '玩家登录');
INSERT INTO `user_log` VALUES ('277', '210237', '3', '2018-09-24 16:17:29', '玩家登录');
INSERT INTO `user_log` VALUES ('278', '210238', '3', '2018-09-24 16:17:31', '玩家登录');
INSERT INTO `user_log` VALUES ('279', '210239', '3', '2018-09-24 16:17:33', '玩家登录');
INSERT INTO `user_log` VALUES ('280', '210240', '3', '2018-09-24 16:17:36', '玩家登录');
INSERT INTO `user_log` VALUES ('281', '210241', '3', '2018-09-24 16:22:01', '玩家登录');
INSERT INTO `user_log` VALUES ('282', '210242', '3', '2018-09-24 16:22:01', '玩家登录');
INSERT INTO `user_log` VALUES ('283', '210243', '3', '2018-09-24 16:22:03', '玩家登录');
INSERT INTO `user_log` VALUES ('284', '210244', '3', '2018-09-24 16:22:03', '玩家登录');
INSERT INTO `user_log` VALUES ('285', '210245', '3', '2018-09-24 16:31:16', '玩家登录');
INSERT INTO `user_log` VALUES ('286', '210246', '3', '2018-09-24 16:31:17', '玩家登录');
INSERT INTO `user_log` VALUES ('287', '210247', '3', '2018-09-24 16:31:18', '玩家登录');
INSERT INTO `user_log` VALUES ('288', '210248', '3', '2018-09-24 16:31:18', '玩家登录');
INSERT INTO `user_log` VALUES ('289', '210249', '3', '2018-09-24 16:36:51', '玩家登录');
INSERT INTO `user_log` VALUES ('290', '210250', '3', '2018-09-24 16:36:52', '玩家登录');
INSERT INTO `user_log` VALUES ('291', '210251', '3', '2018-09-24 16:36:53', '玩家登录');
INSERT INTO `user_log` VALUES ('292', '210252', '3', '2018-09-24 16:36:54', '玩家登录');
INSERT INTO `user_log` VALUES ('293', '210252', '3', '2018-09-24 16:38:48', '玩家登录');
INSERT INTO `user_log` VALUES ('294', '210251', '3', '2018-09-24 16:38:48', '玩家登录');
INSERT INTO `user_log` VALUES ('295', '210250', '3', '2018-09-24 16:38:48', '玩家登录');
INSERT INTO `user_log` VALUES ('296', '210249', '3', '2018-09-24 16:38:48', '玩家登录');
INSERT INTO `user_log` VALUES ('297', '210249', '3', '2018-09-24 16:47:16', '玩家登录');
INSERT INTO `user_log` VALUES ('298', '210253', '3', '2018-09-24 16:47:19', '玩家登录');
INSERT INTO `user_log` VALUES ('299', '210254', '3', '2018-09-24 16:47:20', '玩家登录');
INSERT INTO `user_log` VALUES ('300', '210255', '3', '2018-09-24 16:47:21', '玩家登录');
INSERT INTO `user_log` VALUES ('301', '210256', '3', '2018-09-24 16:52:07', '玩家登录');
INSERT INTO `user_log` VALUES ('302', '210257', '3', '2018-09-24 16:52:08', '玩家登录');
INSERT INTO `user_log` VALUES ('303', '210258', '3', '2018-09-24 16:52:09', '玩家登录');
INSERT INTO `user_log` VALUES ('304', '210259', '3', '2018-09-24 16:52:10', '玩家登录');
INSERT INTO `user_log` VALUES ('305', '210256', '3', '2018-09-24 16:53:27', '玩家登录');
INSERT INTO `user_log` VALUES ('306', '210257', '3', '2018-09-24 16:53:27', '玩家登录');
INSERT INTO `user_log` VALUES ('307', '210259', '3', '2018-09-24 16:53:27', '玩家登录');
INSERT INTO `user_log` VALUES ('308', '210258', '3', '2018-09-24 16:53:27', '玩家登录');
INSERT INTO `user_log` VALUES ('309', '210260', '3', '2018-09-24 16:55:29', '玩家登录');
INSERT INTO `user_log` VALUES ('310', '210261', '3', '2018-09-24 16:56:06', '玩家登录');
INSERT INTO `user_log` VALUES ('311', '210262', '3', '2018-09-24 16:56:07', '玩家登录');
INSERT INTO `user_log` VALUES ('312', '210263', '3', '2018-09-24 16:56:08', '玩家登录');
INSERT INTO `user_log` VALUES ('313', '210264', '3', '2018-09-24 16:56:10', '玩家登录');
INSERT INTO `user_log` VALUES ('314', '210265', '3', '2018-09-24 16:59:00', '玩家登录');
INSERT INTO `user_log` VALUES ('315', '210266', '3', '2018-09-24 16:59:01', '玩家登录');
INSERT INTO `user_log` VALUES ('316', '210267', '3', '2018-09-24 16:59:02', '玩家登录');
INSERT INTO `user_log` VALUES ('317', '210268', '3', '2018-09-24 16:59:03', '玩家登录');
INSERT INTO `user_log` VALUES ('318', '210268', '3', '2018-09-24 17:00:20', '玩家登录');
INSERT INTO `user_log` VALUES ('319', '210267', '3', '2018-09-24 17:00:20', '玩家登录');
INSERT INTO `user_log` VALUES ('320', '210266', '3', '2018-09-24 17:00:20', '玩家登录');
INSERT INTO `user_log` VALUES ('321', '210265', '3', '2018-09-24 17:00:20', '玩家登录');
INSERT INTO `user_log` VALUES ('322', '210269', '3', '2018-09-24 17:26:40', '玩家登录');
INSERT INTO `user_log` VALUES ('323', '210269', '3', '2018-09-24 17:27:08', '玩家登录');
INSERT INTO `user_log` VALUES ('324', '210269', '3', '2018-09-24 17:38:03', '玩家登录');
INSERT INTO `user_log` VALUES ('325', '210269', '3', '2018-09-24 17:39:57', '玩家登录');
INSERT INTO `user_log` VALUES ('326', '210269', '3', '2018-09-24 17:40:19', '玩家登录');
INSERT INTO `user_log` VALUES ('327', '210267', '3', '2018-09-24 17:42:01', '玩家登录');
INSERT INTO `user_log` VALUES ('328', '210265', '3', '2018-09-24 17:42:01', '玩家登录');
INSERT INTO `user_log` VALUES ('329', '210266', '3', '2018-09-24 17:42:01', '玩家登录');
INSERT INTO `user_log` VALUES ('330', '210269', '3', '2018-09-24 17:42:01', '玩家登录');
INSERT INTO `user_log` VALUES ('331', '210270', '3', '2018-09-24 18:01:22', '玩家登录');
INSERT INTO `user_log` VALUES ('332', '210270', '3', '2018-09-24 18:01:41', '玩家登录');
INSERT INTO `user_log` VALUES ('333', '210271', '3', '2018-09-24 18:03:36', '玩家登录');
INSERT INTO `user_log` VALUES ('334', '210271', '3', '2018-09-24 18:04:43', '玩家登录');
INSERT INTO `user_log` VALUES ('335', '210272', '3', '2018-09-24 18:06:42', '玩家登录');
INSERT INTO `user_log` VALUES ('336', '210273', '3', '2018-09-24 18:07:10', '玩家登录');
INSERT INTO `user_log` VALUES ('337', '210274', '3', '2018-09-24 18:11:17', '玩家登录');
INSERT INTO `user_log` VALUES ('338', '210275', '3', '2018-09-24 18:11:18', '玩家登录');
INSERT INTO `user_log` VALUES ('339', '210276', '3', '2018-09-24 18:11:23', '玩家登录');
INSERT INTO `user_log` VALUES ('340', '210277', '3', '2018-09-24 18:11:46', '玩家登录');
INSERT INTO `user_log` VALUES ('341', '210278', '3', '2018-09-24 18:17:12', '玩家登录');
INSERT INTO `user_log` VALUES ('342', '210279', '3', '2018-09-24 18:17:13', '玩家登录');
INSERT INTO `user_log` VALUES ('343', '210280', '3', '2018-09-24 18:17:14', '玩家登录');
INSERT INTO `user_log` VALUES ('344', '210281', '3', '2018-09-24 18:17:15', '玩家登录');
INSERT INTO `user_log` VALUES ('345', '210282', '3', '2018-09-24 18:35:57', '玩家登录');
INSERT INTO `user_log` VALUES ('346', '210283', '3', '2018-09-24 18:35:58', '玩家登录');
INSERT INTO `user_log` VALUES ('347', '210284', '3', '2018-09-24 18:35:59', '玩家登录');
INSERT INTO `user_log` VALUES ('348', '210285', '3', '2018-09-24 18:35:59', '玩家登录');
INSERT INTO `user_log` VALUES ('349', '210286', '3', '2018-09-24 18:37:30', '玩家登录');
INSERT INTO `user_log` VALUES ('350', '210287', '3', '2018-09-24 18:37:42', '玩家登录');
INSERT INTO `user_log` VALUES ('351', '210288', '3', '2018-09-24 18:37:43', '玩家登录');
INSERT INTO `user_log` VALUES ('352', '210289', '3', '2018-09-24 18:37:45', '玩家登录');
INSERT INTO `user_log` VALUES ('353', '210290', '3', '2018-09-24 18:39:53', '玩家登录');
INSERT INTO `user_log` VALUES ('354', '210291', '3', '2018-09-24 18:39:54', '玩家登录');
INSERT INTO `user_log` VALUES ('355', '210292', '3', '2018-09-24 18:39:55', '玩家登录');
INSERT INTO `user_log` VALUES ('356', '210293', '3', '2018-09-24 18:39:56', '玩家登录');
INSERT INTO `user_log` VALUES ('357', '210294', '3', '2018-09-24 19:13:58', '玩家登录');
INSERT INTO `user_log` VALUES ('358', '210295', '3', '2018-09-24 19:14:19', '玩家登录');
INSERT INTO `user_log` VALUES ('359', '210296', '3', '2018-09-24 19:14:20', '玩家登录');
INSERT INTO `user_log` VALUES ('360', '210297', '3', '2018-09-24 19:14:21', '玩家登录');
INSERT INTO `user_log` VALUES ('361', '210298', '3', '2018-09-24 19:18:45', '玩家登录');
INSERT INTO `user_log` VALUES ('362', '210299', '3', '2018-09-24 19:18:46', '玩家登录');
INSERT INTO `user_log` VALUES ('363', '210300', '3', '2018-09-24 19:19:59', '玩家登录');
INSERT INTO `user_log` VALUES ('364', '210301', '3', '2018-09-24 19:20:00', '玩家登录');
INSERT INTO `user_log` VALUES ('365', '210302', '3', '2018-09-24 19:20:01', '玩家登录');
INSERT INTO `user_log` VALUES ('366', '210303', '3', '2018-09-24 19:20:02', '玩家登录');
INSERT INTO `user_log` VALUES ('367', '210304', '3', '2018-09-24 19:21:57', '玩家登录');
INSERT INTO `user_log` VALUES ('368', '210305', '3', '2018-09-24 19:21:58', '玩家登录');
INSERT INTO `user_log` VALUES ('369', '210306', '3', '2018-09-24 19:22:00', '玩家登录');
INSERT INTO `user_log` VALUES ('370', '210307', '3', '2018-09-24 19:22:00', '玩家登录');
INSERT INTO `user_log` VALUES ('371', '210308', '3', '2018-09-24 19:26:28', '玩家登录');
INSERT INTO `user_log` VALUES ('372', '210309', '3', '2018-09-24 19:26:28', '玩家登录');
INSERT INTO `user_log` VALUES ('373', '210310', '3', '2018-09-24 19:26:29', '玩家登录');
INSERT INTO `user_log` VALUES ('374', '210311', '3', '2018-09-24 19:26:30', '玩家登录');
INSERT INTO `user_log` VALUES ('375', '210312', '3', '2018-09-24 19:30:04', '玩家登录');
INSERT INTO `user_log` VALUES ('376', '210313', '3', '2018-09-24 19:30:05', '玩家登录');
INSERT INTO `user_log` VALUES ('377', '210314', '3', '2018-09-24 19:30:06', '玩家登录');
INSERT INTO `user_log` VALUES ('378', '210315', '3', '2018-09-24 19:30:16', '玩家登录');
INSERT INTO `user_log` VALUES ('379', '210316', '3', '2018-09-24 19:35:53', '玩家登录');
INSERT INTO `user_log` VALUES ('380', '210317', '3', '2018-09-24 19:35:54', '玩家登录');
INSERT INTO `user_log` VALUES ('381', '210318', '3', '2018-09-24 19:35:55', '玩家登录');
INSERT INTO `user_log` VALUES ('382', '210319', '3', '2018-09-24 19:35:55', '玩家登录');
INSERT INTO `user_log` VALUES ('383', '210320', '3', '2018-09-24 19:46:06', '玩家登录');
INSERT INTO `user_log` VALUES ('384', '210321', '3', '2018-09-24 19:46:07', '玩家登录');
INSERT INTO `user_log` VALUES ('385', '210322', '3', '2018-09-24 19:46:08', '玩家登录');
INSERT INTO `user_log` VALUES ('386', '210323', '3', '2018-09-24 19:46:17', '玩家登录');
INSERT INTO `user_log` VALUES ('387', '210324', '3', '2018-09-24 20:17:44', '玩家登录');
INSERT INTO `user_log` VALUES ('388', '210325', '3', '2018-09-24 20:17:47', '玩家登录');
INSERT INTO `user_log` VALUES ('389', '210326', '3', '2018-09-24 20:17:48', '玩家登录');
INSERT INTO `user_log` VALUES ('390', '210327', '3', '2018-09-24 20:18:11', '玩家登录');
INSERT INTO `user_log` VALUES ('391', '210328', '3', '2018-09-24 20:18:12', '玩家登录');
INSERT INTO `user_log` VALUES ('392', '210329', '3', '2018-09-24 20:18:13', '玩家登录');
INSERT INTO `user_log` VALUES ('393', '210330', '3', '2018-09-24 20:18:14', '玩家登录');
INSERT INTO `user_log` VALUES ('394', '210330', '3', '2018-09-24 20:19:05', '玩家登录');
INSERT INTO `user_log` VALUES ('395', '210330', '3', '2018-09-24 20:22:19', '玩家登录');
INSERT INTO `user_log` VALUES ('396', '210331', '3', '2018-09-24 20:27:23', '玩家登录');
INSERT INTO `user_log` VALUES ('397', '210332', '3', '2018-09-24 20:27:23', '玩家登录');
INSERT INTO `user_log` VALUES ('398', '210333', '3', '2018-09-24 20:27:25', '玩家登录');
INSERT INTO `user_log` VALUES ('399', '210334', '3', '2018-09-24 20:27:32', '玩家登录');
INSERT INTO `user_log` VALUES ('400', '210334', '3', '2018-09-24 20:27:58', '玩家登录');
INSERT INTO `user_log` VALUES ('401', '210334', '3', '2018-09-24 20:28:18', '玩家登录');
INSERT INTO `user_log` VALUES ('402', '210334', '1', '2018-09-25 09:23:07', '更改绑定关系');
INSERT INTO `user_log` VALUES ('403', '210335', '3', '2018-09-25 10:07:18', '玩家登录');
INSERT INTO `user_log` VALUES ('404', '210334', '1', '2018-09-25 10:11:21', '更改绑定关系');
INSERT INTO `user_log` VALUES ('405', '210335', '1', '2018-09-25 10:12:08', '更改绑定关系');
INSERT INTO `user_log` VALUES ('406', '210335', '1', '2018-09-25 10:12:15', '更改绑定关系');
INSERT INTO `user_log` VALUES ('407', '210335', '1', '2018-09-25 10:12:27', '更改绑定关系');
INSERT INTO `user_log` VALUES ('408', '210336', '3', '2018-09-25 10:24:06', '玩家登录');
INSERT INTO `user_log` VALUES ('409', '210337', '3', '2018-09-25 10:24:49', '玩家登录');
INSERT INTO `user_log` VALUES ('410', '210338', '3', '2018-09-25 10:26:48', '玩家登录');
INSERT INTO `user_log` VALUES ('411', '210339', '3', '2018-09-25 10:26:54', '玩家登录');
INSERT INTO `user_log` VALUES ('412', '210340', '3', '2018-09-25 10:31:07', '玩家登录');
INSERT INTO `user_log` VALUES ('413', '210341', '3', '2018-09-25 10:31:14', '玩家登录');
INSERT INTO `user_log` VALUES ('414', '210342', '3', '2018-09-25 10:31:22', '玩家登录');
INSERT INTO `user_log` VALUES ('415', '210343', '3', '2018-09-25 10:31:41', '玩家登录');
INSERT INTO `user_log` VALUES ('416', '210344', '3', '2018-09-25 10:37:11', '玩家登录');
INSERT INTO `user_log` VALUES ('417', '210345', '3', '2018-09-25 10:37:12', '玩家登录');
INSERT INTO `user_log` VALUES ('418', '210346', '3', '2018-09-25 10:37:14', '玩家登录');
INSERT INTO `user_log` VALUES ('419', '210347', '3', '2018-09-25 10:37:16', '玩家登录');
INSERT INTO `user_log` VALUES ('420', '210348', '3', '2018-09-25 10:39:01', '玩家登录');
INSERT INTO `user_log` VALUES ('421', '210349', '3', '2018-09-25 10:39:03', '玩家登录');
INSERT INTO `user_log` VALUES ('422', '210350', '3', '2018-09-25 10:39:04', '玩家登录');
INSERT INTO `user_log` VALUES ('423', '210351', '3', '2018-09-25 10:39:05', '玩家登录');
INSERT INTO `user_log` VALUES ('424', '210352', '3', '2018-09-25 10:41:47', '玩家登录');
INSERT INTO `user_log` VALUES ('425', '210353', '3', '2018-09-25 10:41:54', '玩家登录');
INSERT INTO `user_log` VALUES ('426', '210354', '3', '2018-09-25 10:50:54', '玩家登录');
INSERT INTO `user_log` VALUES ('427', '210355', '3', '2018-09-25 11:00:11', '玩家登录');
INSERT INTO `user_log` VALUES ('428', '210356', '3', '2018-09-25 11:07:51', '玩家登录');
INSERT INTO `user_log` VALUES ('429', '210357', '3', '2018-09-25 11:08:15', '玩家登录');
INSERT INTO `user_log` VALUES ('430', '210358', '3', '2018-09-25 11:08:20', '玩家登录');
INSERT INTO `user_log` VALUES ('431', '210359', '3', '2018-09-25 11:08:23', '玩家登录');
INSERT INTO `user_log` VALUES ('432', '210360', '3', '2018-09-25 11:16:21', '玩家登录');
INSERT INTO `user_log` VALUES ('433', '210361', '3', '2018-09-25 11:16:22', '玩家登录');
INSERT INTO `user_log` VALUES ('434', '210362', '3', '2018-09-25 11:16:22', '玩家登录');
INSERT INTO `user_log` VALUES ('435', '210363', '3', '2018-09-25 11:16:23', '玩家登录');
INSERT INTO `user_log` VALUES ('436', '210364', '3', '2018-09-25 11:21:03', '玩家登录');
INSERT INTO `user_log` VALUES ('437', '210365', '3', '2018-09-25 11:21:04', '玩家登录');
INSERT INTO `user_log` VALUES ('438', '210366', '3', '2018-09-25 11:21:06', '玩家登录');
INSERT INTO `user_log` VALUES ('439', '210367', '3', '2018-09-25 11:21:09', '玩家登录');
INSERT INTO `user_log` VALUES ('440', '210368', '3', '2018-09-25 11:30:49', '玩家登录');
INSERT INTO `user_log` VALUES ('441', '210369', '3', '2018-09-25 11:30:50', '玩家登录');
INSERT INTO `user_log` VALUES ('442', '210370', '3', '2018-09-25 11:30:51', '玩家登录');
INSERT INTO `user_log` VALUES ('443', '210371', '3', '2018-09-25 11:30:52', '玩家登录');
INSERT INTO `user_log` VALUES ('444', '210372', '3', '2018-09-25 11:32:55', '玩家登录');
INSERT INTO `user_log` VALUES ('445', '210373', '3', '2018-09-25 11:33:21', '玩家登录');
INSERT INTO `user_log` VALUES ('446', '210374', '3', '2018-09-25 11:33:21', '玩家登录');
INSERT INTO `user_log` VALUES ('447', '210375', '3', '2018-09-25 11:33:22', '玩家登录');
INSERT INTO `user_log` VALUES ('448', '210376', '3', '2018-09-25 11:34:16', '玩家登录');
INSERT INTO `user_log` VALUES ('449', '210376', '3', '2018-09-25 11:36:11', '玩家登录');
INSERT INTO `user_log` VALUES ('450', '210377', '3', '2018-09-25 11:36:51', '玩家登录');
INSERT INTO `user_log` VALUES ('451', '210378', '3', '2018-09-25 11:36:53', '玩家登录');
INSERT INTO `user_log` VALUES ('452', '210379', '3', '2018-09-25 11:36:54', '玩家登录');
INSERT INTO `user_log` VALUES ('453', '210380', '3', '2018-09-25 11:37:06', '玩家登录');
INSERT INTO `user_log` VALUES ('454', '210381', '3', '2018-09-25 11:38:35', '玩家登录');
INSERT INTO `user_log` VALUES ('455', '210382', '3', '2018-09-25 11:40:46', '玩家登录');
INSERT INTO `user_log` VALUES ('456', '210383', '3', '2018-09-25 11:41:36', '玩家登录');
INSERT INTO `user_log` VALUES ('457', '210384', '3', '2018-09-25 11:42:29', '玩家登录');
INSERT INTO `user_log` VALUES ('458', '210385', '3', '2018-09-25 11:43:03', '玩家登录');
INSERT INTO `user_log` VALUES ('459', '210386', '3', '2018-09-25 11:43:04', '玩家登录');
INSERT INTO `user_log` VALUES ('460', '210387', '3', '2018-09-25 11:43:05', '玩家登录');
INSERT INTO `user_log` VALUES ('461', '210388', '3', '2018-09-25 11:43:06', '玩家登录');
INSERT INTO `user_log` VALUES ('462', '210389', '3', '2018-09-25 11:43:10', '玩家登录');
INSERT INTO `user_log` VALUES ('463', '210390', '3', '2018-09-25 11:43:52', '玩家登录');
INSERT INTO `user_log` VALUES ('464', '210391', '3', '2018-09-25 11:48:07', '玩家登录');
INSERT INTO `user_log` VALUES ('465', '210392', '3', '2018-09-25 11:48:09', '玩家登录');
INSERT INTO `user_log` VALUES ('466', '210393', '3', '2018-09-25 11:48:10', '玩家登录');
INSERT INTO `user_log` VALUES ('467', '210394', '3', '2018-09-25 11:48:12', '玩家登录');
INSERT INTO `user_log` VALUES ('468', '210395', '3', '2018-09-25 11:48:40', '玩家登录');
INSERT INTO `user_log` VALUES ('469', '210396', '3', '2018-09-25 11:51:08', '玩家登录');
INSERT INTO `user_log` VALUES ('470', '210397', '3', '2018-09-25 11:52:05', '玩家登录');
INSERT INTO `user_log` VALUES ('471', '210398', '3', '2018-09-25 11:52:50', '玩家登录');
INSERT INTO `user_log` VALUES ('472', '210399', '3', '2018-09-25 12:05:21', '玩家登录');
INSERT INTO `user_log` VALUES ('473', '210400', '3', '2018-09-25 12:06:27', '玩家登录');
INSERT INTO `user_log` VALUES ('474', '210401', '3', '2018-09-25 12:07:12', '玩家登录');
INSERT INTO `user_log` VALUES ('475', '210402', '3', '2018-09-25 12:08:02', '玩家登录');
INSERT INTO `user_log` VALUES ('476', '210403', '3', '2018-09-25 12:08:11', '玩家登录');
INSERT INTO `user_log` VALUES ('477', '210404', '3', '2018-09-25 12:12:04', '玩家登录');
INSERT INTO `user_log` VALUES ('478', '210405', '3', '2018-09-25 12:13:32', '玩家登录');
INSERT INTO `user_log` VALUES ('479', '210406', '3', '2018-09-25 12:15:30', '玩家登录');
INSERT INTO `user_log` VALUES ('480', '210407', '3', '2018-09-25 12:15:31', '玩家登录');
INSERT INTO `user_log` VALUES ('481', '210408', '3', '2018-09-25 12:15:32', '玩家登录');
INSERT INTO `user_log` VALUES ('482', '210409', '3', '2018-09-25 13:12:06', '玩家登录');
INSERT INTO `user_log` VALUES ('483', '210410', '3', '2018-09-25 13:12:06', '玩家登录');
INSERT INTO `user_log` VALUES ('484', '210411', '3', '2018-09-25 13:12:08', '玩家登录');
INSERT INTO `user_log` VALUES ('485', '210412', '3', '2018-09-25 13:12:08', '玩家登录');
INSERT INTO `user_log` VALUES ('486', '210414', '3', '2018-09-25 13:19:09', '玩家登录');
INSERT INTO `user_log` VALUES ('487', '210415', '3', '2018-09-25 13:19:11', '玩家登录');
INSERT INTO `user_log` VALUES ('488', '210416', '3', '2018-09-25 13:19:13', '玩家登录');
INSERT INTO `user_log` VALUES ('489', '210417', '3', '2018-09-25 13:19:14', '玩家登录');
INSERT INTO `user_log` VALUES ('490', '210418', '3', '2018-09-25 13:57:14', '玩家登录');
INSERT INTO `user_log` VALUES ('491', '210419', '3', '2018-09-25 13:57:15', '玩家登录');
INSERT INTO `user_log` VALUES ('492', '210420', '3', '2018-09-25 13:57:16', '玩家登录');
INSERT INTO `user_log` VALUES ('493', '210421', '3', '2018-09-25 13:57:17', '玩家登录');
INSERT INTO `user_log` VALUES ('494', '210422', '3', '2018-09-25 14:09:02', '玩家登录');
INSERT INTO `user_log` VALUES ('495', '210423', '3', '2018-09-25 14:09:02', '玩家登录');
INSERT INTO `user_log` VALUES ('496', '210424', '3', '2018-09-25 14:09:03', '玩家登录');
INSERT INTO `user_log` VALUES ('497', '210425', '3', '2018-09-25 14:09:04', '玩家登录');
INSERT INTO `user_log` VALUES ('498', '210426', '3', '2018-09-25 14:11:06', '玩家登录');
INSERT INTO `user_log` VALUES ('499', '210427', '3', '2018-09-25 14:11:07', '玩家登录');
INSERT INTO `user_log` VALUES ('500', '210428', '3', '2018-09-25 14:11:08', '玩家登录');
INSERT INTO `user_log` VALUES ('501', '210429', '3', '2018-09-25 14:11:09', '玩家登录');
INSERT INTO `user_log` VALUES ('502', '210430', '3', '2018-09-25 14:14:13', '玩家登录');
INSERT INTO `user_log` VALUES ('503', '210431', '3', '2018-09-25 14:14:14', '玩家登录');
INSERT INTO `user_log` VALUES ('504', '210432', '3', '2018-09-25 14:14:15', '玩家登录');
INSERT INTO `user_log` VALUES ('505', '210433', '3', '2018-09-25 14:14:16', '玩家登录');
INSERT INTO `user_log` VALUES ('506', '210434', '3', '2018-09-25 14:18:48', '玩家登录');
INSERT INTO `user_log` VALUES ('507', '210435', '3', '2018-09-25 14:18:50', '玩家登录');
INSERT INTO `user_log` VALUES ('508', '210436', '3', '2018-09-25 14:18:51', '玩家登录');
INSERT INTO `user_log` VALUES ('509', '210437', '3', '2018-09-25 14:18:56', '玩家登录');
INSERT INTO `user_log` VALUES ('510', '210438', '3', '2018-09-25 14:20:37', '玩家登录');
INSERT INTO `user_log` VALUES ('511', '210439', '3', '2018-09-25 14:20:38', '玩家登录');
INSERT INTO `user_log` VALUES ('512', '210440', '3', '2018-09-25 14:20:39', '玩家登录');
INSERT INTO `user_log` VALUES ('513', '210441', '3', '2018-09-25 14:20:40', '玩家登录');
INSERT INTO `user_log` VALUES ('514', '210442', '3', '2018-09-25 14:23:35', '玩家登录');
INSERT INTO `user_log` VALUES ('515', '210443', '3', '2018-09-25 14:23:36', '玩家登录');
INSERT INTO `user_log` VALUES ('516', '210444', '3', '2018-09-25 14:23:37', '玩家登录');
INSERT INTO `user_log` VALUES ('517', '210445', '3', '2018-09-25 14:23:38', '玩家登录');
INSERT INTO `user_log` VALUES ('518', '210446', '3', '2018-09-25 14:36:08', '玩家登录');
INSERT INTO `user_log` VALUES ('519', '210447', '3', '2018-09-25 14:36:09', '玩家登录');
INSERT INTO `user_log` VALUES ('520', '210448', '3', '2018-09-25 14:36:10', '玩家登录');
INSERT INTO `user_log` VALUES ('521', '210449', '3', '2018-09-25 14:36:11', '玩家登录');
INSERT INTO `user_log` VALUES ('522', '210450', '3', '2018-09-25 14:49:15', '玩家登录');
INSERT INTO `user_log` VALUES ('523', '210451', '3', '2018-09-25 14:49:16', '玩家登录');
INSERT INTO `user_log` VALUES ('524', '210452', '3', '2018-09-25 14:49:17', '玩家登录');
INSERT INTO `user_log` VALUES ('525', '210453', '3', '2018-09-25 14:49:18', '玩家登录');
INSERT INTO `user_log` VALUES ('526', '210454', '3', '2018-09-25 14:49:44', '玩家登录');
INSERT INTO `user_log` VALUES ('527', '210455', '3', '2018-09-25 14:57:08', '玩家登录');
INSERT INTO `user_log` VALUES ('528', '210456', '3', '2018-09-25 14:57:10', '玩家登录');
INSERT INTO `user_log` VALUES ('529', '210457', '3', '2018-09-25 14:57:11', '玩家登录');
INSERT INTO `user_log` VALUES ('530', '210458', '3', '2018-09-25 14:57:11', '玩家登录');
INSERT INTO `user_log` VALUES ('531', '210459', '3', '2018-09-25 14:59:23', '玩家登录');
INSERT INTO `user_log` VALUES ('532', '210460', '3', '2018-09-25 14:59:23', '玩家登录');
INSERT INTO `user_log` VALUES ('533', '210461', '3', '2018-09-25 14:59:24', '玩家登录');
INSERT INTO `user_log` VALUES ('534', '210462', '3', '2018-09-25 14:59:25', '玩家登录');
INSERT INTO `user_log` VALUES ('535', '210463', '3', '2018-09-25 15:03:29', '玩家登录');
INSERT INTO `user_log` VALUES ('536', '210464', '3', '2018-09-25 15:03:30', '玩家登录');
INSERT INTO `user_log` VALUES ('537', '210465', '3', '2018-09-25 15:03:31', '玩家登录');
INSERT INTO `user_log` VALUES ('538', '210466', '3', '2018-09-25 15:03:32', '玩家登录');
INSERT INTO `user_log` VALUES ('539', '210467', '3', '2018-09-25 15:08:27', '玩家登录');
INSERT INTO `user_log` VALUES ('540', '210468', '3', '2018-09-25 15:08:27', '玩家登录');
INSERT INTO `user_log` VALUES ('541', '210469', '3', '2018-09-25 15:08:29', '玩家登录');
INSERT INTO `user_log` VALUES ('542', '210470', '3', '2018-09-25 15:08:29', '玩家登录');
INSERT INTO `user_log` VALUES ('543', '210471', '3', '2018-09-25 15:11:09', '玩家登录');
INSERT INTO `user_log` VALUES ('544', '210472', '3', '2018-09-25 15:11:09', '玩家登录');
INSERT INTO `user_log` VALUES ('545', '210473', '3', '2018-09-25 15:11:11', '玩家登录');
INSERT INTO `user_log` VALUES ('546', '210474', '3', '2018-09-25 15:11:11', '玩家登录');
INSERT INTO `user_log` VALUES ('547', '210475', '3', '2018-09-25 15:15:52', '玩家登录');
INSERT INTO `user_log` VALUES ('548', '210476', '3', '2018-09-25 15:15:53', '玩家登录');
INSERT INTO `user_log` VALUES ('549', '210477', '3', '2018-09-25 15:15:55', '玩家登录');
INSERT INTO `user_log` VALUES ('550', '210478', '3', '2018-09-25 15:15:56', '玩家登录');
INSERT INTO `user_log` VALUES ('551', '210479', '3', '2018-09-25 15:22:32', '玩家登录');
INSERT INTO `user_log` VALUES ('552', '210480', '3', '2018-09-25 15:22:33', '玩家登录');
INSERT INTO `user_log` VALUES ('553', '210481', '3', '2018-09-25 15:22:34', '玩家登录');
INSERT INTO `user_log` VALUES ('554', '210482', '3', '2018-09-25 15:22:35', '玩家登录');
INSERT INTO `user_log` VALUES ('555', '210483', '3', '2018-09-25 15:28:28', '玩家登录');
INSERT INTO `user_log` VALUES ('556', '210484', '3', '2018-09-25 15:28:29', '玩家登录');
INSERT INTO `user_log` VALUES ('557', '210485', '3', '2018-09-25 15:28:31', '玩家登录');
INSERT INTO `user_log` VALUES ('558', '210486', '3', '2018-09-25 15:28:32', '玩家登录');
INSERT INTO `user_log` VALUES ('559', '210487', '3', '2018-09-25 15:34:02', '玩家登录');
INSERT INTO `user_log` VALUES ('560', '210488', '3', '2018-09-25 15:34:03', '玩家登录');
INSERT INTO `user_log` VALUES ('561', '210489', '3', '2018-09-25 15:34:04', '玩家登录');
INSERT INTO `user_log` VALUES ('562', '210490', '3', '2018-09-25 15:34:05', '玩家登录');
INSERT INTO `user_log` VALUES ('563', '210491', '3', '2018-09-25 15:40:19', '玩家登录');
INSERT INTO `user_log` VALUES ('564', '210492', '3', '2018-09-25 15:40:20', '玩家登录');
INSERT INTO `user_log` VALUES ('565', '210493', '3', '2018-09-25 15:40:21', '玩家登录');
INSERT INTO `user_log` VALUES ('566', '210494', '3', '2018-09-25 15:40:22', '玩家登录');
INSERT INTO `user_log` VALUES ('567', '210495', '3', '2018-09-25 15:43:03', '玩家登录');
INSERT INTO `user_log` VALUES ('568', '210496', '3', '2018-09-25 15:43:04', '玩家登录');
INSERT INTO `user_log` VALUES ('569', '210497', '3', '2018-09-25 15:43:05', '玩家登录');
INSERT INTO `user_log` VALUES ('570', '210498', '3', '2018-09-25 15:43:05', '玩家登录');
INSERT INTO `user_log` VALUES ('571', '210499', '3', '2018-09-25 15:46:40', '玩家登录');
INSERT INTO `user_log` VALUES ('572', '210500', '3', '2018-09-25 15:46:40', '玩家登录');
INSERT INTO `user_log` VALUES ('573', '210501', '3', '2018-09-25 15:46:41', '玩家登录');
INSERT INTO `user_log` VALUES ('574', '210502', '3', '2018-09-25 15:46:42', '玩家登录');
INSERT INTO `user_log` VALUES ('575', '210503', '3', '2018-09-25 15:48:46', '玩家登录');
INSERT INTO `user_log` VALUES ('576', '210504', '3', '2018-09-25 15:48:46', '玩家登录');
INSERT INTO `user_log` VALUES ('577', '210505', '3', '2018-09-25 15:48:47', '玩家登录');
INSERT INTO `user_log` VALUES ('578', '210506', '3', '2018-09-25 15:48:48', '玩家登录');
INSERT INTO `user_log` VALUES ('579', '210507', '3', '2018-09-25 15:53:03', '玩家登录');
INSERT INTO `user_log` VALUES ('580', '210508', '3', '2018-09-25 15:53:04', '玩家登录');
INSERT INTO `user_log` VALUES ('581', '210509', '3', '2018-09-25 15:53:05', '玩家登录');
INSERT INTO `user_log` VALUES ('582', '210510', '3', '2018-09-25 15:53:05', '玩家登录');
INSERT INTO `user_log` VALUES ('583', '210511', '3', '2018-09-25 16:01:29', '玩家登录');
INSERT INTO `user_log` VALUES ('584', '210512', '3', '2018-09-25 16:01:30', '玩家登录');
INSERT INTO `user_log` VALUES ('585', '210513', '3', '2018-09-25 16:01:31', '玩家登录');
INSERT INTO `user_log` VALUES ('586', '210514', '3', '2018-09-25 16:01:56', '玩家登录');
INSERT INTO `user_log` VALUES ('587', '210515', '3', '2018-09-25 16:13:17', '玩家登录');
INSERT INTO `user_log` VALUES ('588', '210516', '3', '2018-09-25 16:13:18', '玩家登录');
INSERT INTO `user_log` VALUES ('589', '210517', '3', '2018-09-25 16:13:20', '玩家登录');
INSERT INTO `user_log` VALUES ('590', '210518', '3', '2018-09-25 16:13:20', '玩家登录');
INSERT INTO `user_log` VALUES ('591', '210519', '3', '2018-09-25 16:26:12', '玩家登录');
INSERT INTO `user_log` VALUES ('592', '210520', '3', '2018-09-25 16:26:13', '玩家登录');
INSERT INTO `user_log` VALUES ('593', '210521', '3', '2018-09-25 16:26:14', '玩家登录');
INSERT INTO `user_log` VALUES ('594', '210522', '3', '2018-09-25 16:26:16', '玩家登录');
INSERT INTO `user_log` VALUES ('595', '210523', '3', '2018-09-25 16:36:55', '玩家登录');
INSERT INTO `user_log` VALUES ('596', '210524', '3', '2018-09-25 16:36:56', '玩家登录');
INSERT INTO `user_log` VALUES ('597', '210525', '3', '2018-09-25 16:36:57', '玩家登录');
INSERT INTO `user_log` VALUES ('598', '210526', '3', '2018-09-25 16:37:30', '玩家登录');
INSERT INTO `user_log` VALUES ('599', '210527', '3', '2018-09-25 16:42:15', '玩家登录');
INSERT INTO `user_log` VALUES ('600', '210528', '3', '2018-09-25 16:42:16', '玩家登录');
INSERT INTO `user_log` VALUES ('601', '210529', '3', '2018-09-25 16:42:17', '玩家登录');
INSERT INTO `user_log` VALUES ('602', '210530', '3', '2018-09-25 16:42:17', '玩家登录');
INSERT INTO `user_log` VALUES ('603', '210531', '3', '2018-09-25 16:49:06', '玩家登录');
INSERT INTO `user_log` VALUES ('604', '210532', '3', '2018-09-25 16:49:07', '玩家登录');
INSERT INTO `user_log` VALUES ('605', '210533', '3', '2018-09-25 16:49:08', '玩家登录');
INSERT INTO `user_log` VALUES ('606', '210534', '3', '2018-09-25 16:49:09', '玩家登录');
INSERT INTO `user_log` VALUES ('607', '210535', '3', '2018-09-25 16:51:36', '玩家登录');
INSERT INTO `user_log` VALUES ('608', '210536', '3', '2018-09-25 16:51:37', '玩家登录');
INSERT INTO `user_log` VALUES ('609', '210537', '3', '2018-09-25 16:51:38', '玩家登录');
INSERT INTO `user_log` VALUES ('610', '210538', '3', '2018-09-25 16:51:39', '玩家登录');
INSERT INTO `user_log` VALUES ('611', '210539', '3', '2018-09-25 16:54:20', '玩家登录');
INSERT INTO `user_log` VALUES ('612', '210540', '3', '2018-09-25 16:54:21', '玩家登录');
INSERT INTO `user_log` VALUES ('613', '210541', '3', '2018-09-25 16:54:22', '玩家登录');
INSERT INTO `user_log` VALUES ('614', '210542', '3', '2018-09-25 16:54:22', '玩家登录');
INSERT INTO `user_log` VALUES ('615', '210543', '3', '2018-09-25 17:01:48', '玩家登录');
INSERT INTO `user_log` VALUES ('616', '210544', '3', '2018-09-25 17:01:48', '玩家登录');
INSERT INTO `user_log` VALUES ('617', '210545', '3', '2018-09-25 17:01:50', '玩家登录');
INSERT INTO `user_log` VALUES ('618', '210546', '3', '2018-09-25 17:01:51', '玩家登录');
INSERT INTO `user_log` VALUES ('619', '210547', '3', '2018-09-25 17:14:37', '玩家登录');
INSERT INTO `user_log` VALUES ('620', '210548', '3', '2018-09-25 17:14:37', '玩家登录');
INSERT INTO `user_log` VALUES ('621', '210549', '3', '2018-09-25 17:14:38', '玩家登录');
INSERT INTO `user_log` VALUES ('622', '210550', '3', '2018-09-25 17:14:39', '玩家登录');
INSERT INTO `user_log` VALUES ('623', '210551', '3', '2018-09-25 17:17:25', '玩家登录');
INSERT INTO `user_log` VALUES ('624', '210552', '3', '2018-09-25 17:17:27', '玩家登录');
INSERT INTO `user_log` VALUES ('625', '210553', '3', '2018-09-25 17:17:28', '玩家登录');
INSERT INTO `user_log` VALUES ('626', '210554', '3', '2018-09-25 17:17:29', '玩家登录');
INSERT INTO `user_log` VALUES ('627', '210555', '3', '2018-09-25 17:21:05', '玩家登录');
INSERT INTO `user_log` VALUES ('628', '210556', '3', '2018-09-25 17:21:05', '玩家登录');
INSERT INTO `user_log` VALUES ('629', '210557', '3', '2018-09-25 17:21:07', '玩家登录');
INSERT INTO `user_log` VALUES ('630', '210558', '3', '2018-09-25 17:21:08', '玩家登录');
INSERT INTO `user_log` VALUES ('631', '210559', '3', '2018-09-25 17:23:58', '玩家登录');
INSERT INTO `user_log` VALUES ('632', '210560', '3', '2018-09-25 17:23:58', '玩家登录');
INSERT INTO `user_log` VALUES ('633', '210561', '3', '2018-09-25 17:24:00', '玩家登录');
INSERT INTO `user_log` VALUES ('634', '210562', '3', '2018-09-25 17:24:10', '玩家登录');
INSERT INTO `user_log` VALUES ('635', '210563', '3', '2018-09-25 17:26:17', '玩家登录');
INSERT INTO `user_log` VALUES ('636', '210564', '3', '2018-09-25 17:26:17', '玩家登录');
INSERT INTO `user_log` VALUES ('637', '210565', '3', '2018-09-25 17:26:18', '玩家登录');
INSERT INTO `user_log` VALUES ('638', '210566', '3', '2018-09-25 17:26:19', '玩家登录');
INSERT INTO `user_log` VALUES ('639', '210567', '3', '2018-09-25 17:27:53', '玩家登录');
INSERT INTO `user_log` VALUES ('640', '210568', '3', '2018-09-25 17:27:54', '玩家登录');
INSERT INTO `user_log` VALUES ('641', '210569', '3', '2018-09-25 17:27:55', '玩家登录');
INSERT INTO `user_log` VALUES ('642', '210570', '3', '2018-09-25 17:27:56', '玩家登录');
INSERT INTO `user_log` VALUES ('643', '210571', '3', '2018-09-25 17:29:31', '玩家登录');
INSERT INTO `user_log` VALUES ('644', '210572', '3', '2018-09-25 17:29:32', '玩家登录');
INSERT INTO `user_log` VALUES ('645', '210573', '3', '2018-09-25 17:29:33', '玩家登录');
INSERT INTO `user_log` VALUES ('646', '210574', '3', '2018-09-25 17:29:34', '玩家登录');
INSERT INTO `user_log` VALUES ('647', '210575', '3', '2018-09-25 17:33:42', '玩家登录');
INSERT INTO `user_log` VALUES ('648', '210576', '3', '2018-09-25 17:33:43', '玩家登录');
INSERT INTO `user_log` VALUES ('649', '210577', '3', '2018-09-25 17:33:44', '玩家登录');
INSERT INTO `user_log` VALUES ('650', '210578', '3', '2018-09-25 17:33:45', '玩家登录');
INSERT INTO `user_log` VALUES ('651', '210579', '3', '2018-09-25 17:36:18', '玩家登录');
INSERT INTO `user_log` VALUES ('652', '210580', '3', '2018-09-25 17:36:18', '玩家登录');
INSERT INTO `user_log` VALUES ('653', '210581', '3', '2018-09-25 17:36:19', '玩家登录');
INSERT INTO `user_log` VALUES ('654', '210582', '3', '2018-09-25 17:36:21', '玩家登录');
INSERT INTO `user_log` VALUES ('655', '210583', '3', '2018-09-25 17:38:46', '玩家登录');
INSERT INTO `user_log` VALUES ('656', '210584', '3', '2018-09-25 17:38:47', '玩家登录');
INSERT INTO `user_log` VALUES ('657', '210585', '3', '2018-09-25 17:38:48', '玩家登录');
INSERT INTO `user_log` VALUES ('658', '210586', '3', '2018-09-25 17:38:49', '玩家登录');
INSERT INTO `user_log` VALUES ('659', '210587', '3', '2018-09-25 17:44:56', '玩家登录');
INSERT INTO `user_log` VALUES ('660', '210588', '3', '2018-09-25 17:44:57', '玩家登录');
INSERT INTO `user_log` VALUES ('661', '210589', '3', '2018-09-25 17:44:57', '玩家登录');
INSERT INTO `user_log` VALUES ('662', '210590', '3', '2018-09-25 17:44:58', '玩家登录');
INSERT INTO `user_log` VALUES ('663', '210591', '3', '2018-09-25 17:47:19', '玩家登录');
INSERT INTO `user_log` VALUES ('664', '210592', '3', '2018-09-25 17:47:20', '玩家登录');
INSERT INTO `user_log` VALUES ('665', '210593', '3', '2018-09-25 17:47:21', '玩家登录');
INSERT INTO `user_log` VALUES ('666', '210594', '3', '2018-09-25 17:47:22', '玩家登录');
INSERT INTO `user_log` VALUES ('667', '210595', '3', '2018-09-25 17:48:54', '玩家登录');
INSERT INTO `user_log` VALUES ('668', '210596', '3', '2018-09-25 17:48:54', '玩家登录');
INSERT INTO `user_log` VALUES ('669', '210597', '3', '2018-09-25 17:48:55', '玩家登录');
INSERT INTO `user_log` VALUES ('670', '210598', '3', '2018-09-25 17:48:56', '玩家登录');
INSERT INTO `user_log` VALUES ('671', '210599', '3', '2018-09-25 17:50:21', '玩家登录');
INSERT INTO `user_log` VALUES ('672', '210600', '3', '2018-09-25 17:50:22', '玩家登录');
INSERT INTO `user_log` VALUES ('673', '210601', '3', '2018-09-25 17:50:22', '玩家登录');
INSERT INTO `user_log` VALUES ('674', '210602', '3', '2018-09-25 17:50:24', '玩家登录');
INSERT INTO `user_log` VALUES ('675', '210603', '3', '2018-09-25 17:51:43', '玩家登录');
INSERT INTO `user_log` VALUES ('676', '210604', '3', '2018-09-25 17:51:43', '玩家登录');
INSERT INTO `user_log` VALUES ('677', '210605', '3', '2018-09-25 17:51:44', '玩家登录');
INSERT INTO `user_log` VALUES ('678', '210606', '3', '2018-09-25 17:51:45', '玩家登录');
INSERT INTO `user_log` VALUES ('679', '210607', '3', '2018-09-25 17:53:24', '玩家登录');
INSERT INTO `user_log` VALUES ('680', '210608', '3', '2018-09-25 17:53:25', '玩家登录');
INSERT INTO `user_log` VALUES ('681', '210609', '3', '2018-09-25 17:53:26', '玩家登录');
INSERT INTO `user_log` VALUES ('682', '210610', '3', '2018-09-25 17:53:27', '玩家登录');
INSERT INTO `user_log` VALUES ('683', '210611', '3', '2018-09-25 17:54:50', '玩家登录');
INSERT INTO `user_log` VALUES ('684', '210612', '3', '2018-09-25 17:54:50', '玩家登录');
INSERT INTO `user_log` VALUES ('685', '210613', '3', '2018-09-25 17:55:17', '玩家登录');
INSERT INTO `user_log` VALUES ('686', '210614', '3', '2018-09-25 17:55:17', '玩家登录');
INSERT INTO `user_log` VALUES ('687', '210615', '3', '2018-09-25 18:02:41', '玩家登录');
INSERT INTO `user_log` VALUES ('688', '210616', '3', '2018-09-25 18:02:41', '玩家登录');
INSERT INTO `user_log` VALUES ('689', '210617', '3', '2018-09-25 18:02:42', '玩家登录');
INSERT INTO `user_log` VALUES ('690', '210618', '3', '2018-09-25 18:02:44', '玩家登录');
INSERT INTO `user_log` VALUES ('691', '210619', '3', '2018-09-25 18:05:49', '玩家登录');
INSERT INTO `user_log` VALUES ('692', '210620', '3', '2018-09-25 18:05:49', '玩家登录');
INSERT INTO `user_log` VALUES ('693', '210621', '3', '2018-09-25 18:05:50', '玩家登录');
INSERT INTO `user_log` VALUES ('694', '210622', '3', '2018-09-25 18:05:51', '玩家登录');
INSERT INTO `user_log` VALUES ('695', '210623', '3', '2018-09-25 18:28:40', '玩家登录');
INSERT INTO `user_log` VALUES ('696', '210624', '3', '2018-09-25 19:37:07', '玩家登录');
INSERT INTO `user_log` VALUES ('697', '210625', '3', '2018-09-25 19:40:02', '玩家登录');
INSERT INTO `user_log` VALUES ('698', '210626', '3', '2018-09-25 19:42:39', '玩家登录');
INSERT INTO `user_log` VALUES ('699', '210627', '3', '2018-09-25 20:40:25', '玩家登录');
INSERT INTO `user_log` VALUES ('700', '210628', '3', '2018-09-25 20:41:37', '玩家登录');
INSERT INTO `user_log` VALUES ('701', '210629', '3', '2018-09-25 20:46:13', '玩家登录');
INSERT INTO `user_log` VALUES ('702', '210630', '3', '2018-09-25 20:46:13', '玩家登录');
INSERT INTO `user_log` VALUES ('703', '210630', '3', '2018-09-25 20:49:34', '玩家登录');
INSERT INTO `user_log` VALUES ('704', '210631', '3', '2018-09-25 21:00:37', '玩家登录');
INSERT INTO `user_log` VALUES ('705', '210632', '3', '2018-09-25 21:00:52', '玩家登录');
INSERT INTO `user_log` VALUES ('706', '210633', '3', '2018-09-25 21:00:53', '玩家登录');
INSERT INTO `user_log` VALUES ('707', '210634', '3', '2018-09-26 09:26:32', '玩家登录');
INSERT INTO `user_log` VALUES ('708', '210635', '3', '2018-09-26 09:29:05', '玩家登录');
INSERT INTO `user_log` VALUES ('709', '210636', '3', '2018-09-26 09:29:08', '玩家登录');
INSERT INTO `user_log` VALUES ('710', '210637', '3', '2018-09-26 09:29:12', '玩家登录');
INSERT INTO `user_log` VALUES ('711', '210638', '3', '2018-09-26 09:58:09', '玩家登录');
INSERT INTO `user_log` VALUES ('712', '210639', '3', '2018-09-26 09:58:13', '玩家登录');
INSERT INTO `user_log` VALUES ('713', '210640', '3', '2018-09-26 10:02:05', '玩家登录');
INSERT INTO `user_log` VALUES ('714', '210641', '3', '2018-09-26 10:02:05', '玩家登录');
INSERT INTO `user_log` VALUES ('715', '210642', '3', '2018-09-26 10:12:05', '玩家登录');
INSERT INTO `user_log` VALUES ('716', '210643', '3', '2018-09-26 10:18:30', '玩家登录');
INSERT INTO `user_log` VALUES ('717', '210644', '3', '2018-09-26 10:18:31', '玩家登录');
INSERT INTO `user_log` VALUES ('718', '210645', '3', '2018-09-26 10:19:51', '玩家登录');
INSERT INTO `user_log` VALUES ('719', '210646', '3', '2018-09-26 10:19:52', '玩家登录');
INSERT INTO `user_log` VALUES ('720', '210647', '3', '2018-09-26 10:29:50', '玩家登录');
INSERT INTO `user_log` VALUES ('721', '210646', '3', '2018-09-26 10:32:21', '玩家登录');
INSERT INTO `user_log` VALUES ('722', '210648', '3', '2018-09-26 10:36:58', '玩家登录');
INSERT INTO `user_log` VALUES ('723', '210649', '3', '2018-09-26 10:38:12', '玩家登录');
INSERT INTO `user_log` VALUES ('724', '210650', '3', '2018-09-26 10:49:01', '玩家登录');
INSERT INTO `user_log` VALUES ('725', '210651', '3', '2018-09-26 10:52:12', '玩家登录');
INSERT INTO `user_log` VALUES ('726', '210652', '3', '2018-09-26 11:01:51', '玩家登录');
INSERT INTO `user_log` VALUES ('727', '210653', '3', '2018-09-26 11:07:58', '玩家登录');
INSERT INTO `user_log` VALUES ('728', '210654', '3', '2018-09-26 11:07:59', '玩家登录');
INSERT INTO `user_log` VALUES ('729', '210655', '3', '2018-09-26 11:13:49', '玩家登录');
INSERT INTO `user_log` VALUES ('730', '210656', '3', '2018-09-26 11:13:49', '玩家登录');
INSERT INTO `user_log` VALUES ('731', '210657', '3', '2018-09-26 11:14:13', '玩家登录');
INSERT INTO `user_log` VALUES ('732', '210658', '3', '2018-09-26 11:14:13', '玩家登录');
INSERT INTO `user_log` VALUES ('733', '210659', '3', '2018-09-26 11:15:30', '玩家登录');
INSERT INTO `user_log` VALUES ('734', '210660', '3', '2018-09-26 11:15:30', '玩家登录');
INSERT INTO `user_log` VALUES ('735', '210661', '3', '2018-09-26 11:15:31', '玩家登录');
INSERT INTO `user_log` VALUES ('736', '210662', '3', '2018-09-26 11:15:32', '玩家登录');
INSERT INTO `user_log` VALUES ('737', '210663', '3', '2018-09-26 11:17:16', '玩家登录');
INSERT INTO `user_log` VALUES ('738', '210664', '3', '2018-09-26 11:17:17', '玩家登录');
INSERT INTO `user_log` VALUES ('739', '210665', '3', '2018-09-26 11:17:18', '玩家登录');
INSERT INTO `user_log` VALUES ('740', '210666', '3', '2018-09-26 11:17:19', '玩家登录');
INSERT INTO `user_log` VALUES ('741', '210667', '3', '2018-09-26 11:18:47', '玩家登录');
INSERT INTO `user_log` VALUES ('742', '210668', '3', '2018-09-26 11:18:48', '玩家登录');
INSERT INTO `user_log` VALUES ('743', '210669', '3', '2018-09-26 11:18:49', '玩家登录');
INSERT INTO `user_log` VALUES ('744', '210670', '3', '2018-09-26 11:18:50', '玩家登录');
INSERT INTO `user_log` VALUES ('745', '210671', '3', '2018-09-26 11:20:50', '玩家登录');
INSERT INTO `user_log` VALUES ('746', '210672', '3', '2018-09-26 11:33:33', '玩家登录');
INSERT INTO `user_log` VALUES ('747', '210673', '3', '2018-09-26 11:36:49', '玩家登录');
INSERT INTO `user_log` VALUES ('748', '210674', '3', '2018-09-26 11:36:50', '玩家登录');
INSERT INTO `user_log` VALUES ('749', '210675', '3', '2018-09-26 11:39:06', '玩家登录');
INSERT INTO `user_log` VALUES ('750', '210676', '3', '2018-09-26 11:39:08', '玩家登录');
INSERT INTO `user_log` VALUES ('751', '210677', '3', '2018-09-26 11:41:39', '玩家登录');
INSERT INTO `user_log` VALUES ('752', '210678', '3', '2018-09-26 11:41:40', '玩家登录');
INSERT INTO `user_log` VALUES ('753', '210679', '3', '2018-09-26 11:41:42', '玩家登录');
INSERT INTO `user_log` VALUES ('754', '210680', '3', '2018-09-26 11:41:44', '玩家登录');
INSERT INTO `user_log` VALUES ('755', '210681', '3', '2018-09-26 11:46:45', '玩家登录');
INSERT INTO `user_log` VALUES ('756', '210682', '3', '2018-09-26 11:46:47', '玩家登录');
INSERT INTO `user_log` VALUES ('757', '210683', '3', '2018-09-26 13:07:21', '玩家登录');
INSERT INTO `user_log` VALUES ('758', '210684', '3', '2018-09-26 13:07:32', '玩家登录');
INSERT INTO `user_log` VALUES ('759', '210685', '3', '2018-09-26 13:08:05', '玩家登录');
INSERT INTO `user_log` VALUES ('760', '210686', '3', '2018-09-26 13:08:07', '玩家登录');
INSERT INTO `user_log` VALUES ('761', '210687', '3', '2018-09-26 13:08:10', '玩家登录');
INSERT INTO `user_log` VALUES ('762', '210688', '3', '2018-09-26 13:08:11', '玩家登录');
INSERT INTO `user_log` VALUES ('763', '210689', '3', '2018-09-26 14:21:04', '玩家登录');
INSERT INTO `user_log` VALUES ('764', '210689', '3', '2018-09-26 14:21:05', '玩家登录');
INSERT INTO `user_log` VALUES ('765', '210690', '3', '2018-09-26 14:21:07', '玩家登录');
INSERT INTO `user_log` VALUES ('766', '210691', '3', '2018-09-26 14:21:08', '玩家登录');
INSERT INTO `user_log` VALUES ('767', '210692', '3', '2018-09-26 14:21:18', '玩家登录');
INSERT INTO `user_log` VALUES ('768', '210693', '3', '2018-09-26 14:25:20', '玩家登录');
INSERT INTO `user_log` VALUES ('769', '210694', '3', '2018-09-26 14:27:11', '玩家登录');
INSERT INTO `user_log` VALUES ('770', '210695', '3', '2018-09-26 14:27:13', '玩家登录');
INSERT INTO `user_log` VALUES ('771', '210696', '3', '2018-09-26 14:27:15', '玩家登录');
INSERT INTO `user_log` VALUES ('772', '210697', '3', '2018-09-26 14:27:16', '玩家登录');
INSERT INTO `user_log` VALUES ('773', '210698', '3', '2018-09-26 14:31:32', '玩家登录');
INSERT INTO `user_log` VALUES ('774', '210699', '3', '2018-09-26 14:31:36', '玩家登录');
INSERT INTO `user_log` VALUES ('775', '210700', '3', '2018-09-26 14:31:39', '玩家登录');
INSERT INTO `user_log` VALUES ('776', '210701', '3', '2018-09-26 14:31:43', '玩家登录');
INSERT INTO `user_log` VALUES ('777', '210702', '3', '2018-09-26 14:31:44', '玩家登录');
INSERT INTO `user_log` VALUES ('778', '210703', '3', '2018-09-26 14:31:45', '玩家登录');
INSERT INTO `user_log` VALUES ('779', '210704', '3', '2018-09-26 14:33:44', '玩家登录');
INSERT INTO `user_log` VALUES ('780', '210704', '3', '2018-09-26 14:35:32', '玩家登录');
INSERT INTO `user_log` VALUES ('781', '210705', '3', '2018-09-26 14:38:15', '玩家登录');
INSERT INTO `user_log` VALUES ('782', '210706', '3', '2018-09-26 14:42:21', '玩家登录');
INSERT INTO `user_log` VALUES ('783', '210707', '3', '2018-09-26 14:43:10', '玩家登录');
INSERT INTO `user_log` VALUES ('784', '210708', '3', '2018-09-26 14:43:46', '玩家登录');
INSERT INTO `user_log` VALUES ('785', '210709', '3', '2018-09-26 14:44:19', '玩家登录');
INSERT INTO `user_log` VALUES ('786', '210710', '3', '2018-09-26 14:45:49', '玩家登录');
INSERT INTO `user_log` VALUES ('787', '210711', '3', '2018-09-26 14:47:23', '玩家登录');
INSERT INTO `user_log` VALUES ('788', '210712', '3', '2018-09-26 14:49:31', '玩家登录');
INSERT INTO `user_log` VALUES ('789', '210712', '3', '2018-09-26 14:54:33', '玩家登录');
INSERT INTO `user_log` VALUES ('790', '210712', '3', '2018-09-26 14:58:30', '玩家登录');
INSERT INTO `user_log` VALUES ('791', '210713', '3', '2018-09-26 14:58:33', '玩家登录');
INSERT INTO `user_log` VALUES ('792', '210714', '3', '2018-09-26 15:00:19', '玩家登录');
INSERT INTO `user_log` VALUES ('793', '210715', '3', '2018-09-26 15:00:22', '玩家登录');
INSERT INTO `user_log` VALUES ('794', '210716', '3', '2018-09-26 15:00:23', '玩家登录');
INSERT INTO `user_log` VALUES ('795', '210717', '3', '2018-09-26 15:02:26', '玩家登录');
INSERT INTO `user_log` VALUES ('796', '210718', '3', '2018-09-26 15:02:27', '玩家登录');
INSERT INTO `user_log` VALUES ('797', '210719', '3', '2018-09-26 15:02:29', '玩家登录');
INSERT INTO `user_log` VALUES ('798', '210720', '3', '2018-09-26 15:02:30', '玩家登录');
INSERT INTO `user_log` VALUES ('799', '210721', '3', '2018-09-26 15:02:36', '玩家登录');
INSERT INTO `user_log` VALUES ('800', '210722', '3', '2018-09-26 15:05:28', '玩家登录');
INSERT INTO `user_log` VALUES ('801', '210712', '3', '2018-09-26 15:05:46', '玩家登录');
INSERT INTO `user_log` VALUES ('802', '210712', '3', '2018-09-26 15:07:42', '玩家登录');
INSERT INTO `user_log` VALUES ('803', '210712', '3', '2018-09-26 15:08:18', '玩家登录');
INSERT INTO `user_log` VALUES ('804', '210723', '3', '2018-09-26 15:13:08', '玩家登录');
INSERT INTO `user_log` VALUES ('805', '210724', '3', '2018-09-26 15:13:09', '玩家登录');
INSERT INTO `user_log` VALUES ('806', '210725', '3', '2018-09-26 15:13:10', '玩家登录');
INSERT INTO `user_log` VALUES ('807', '210726', '3', '2018-09-26 15:13:11', '玩家登录');
INSERT INTO `user_log` VALUES ('808', '210727', '3', '2018-09-26 15:13:12', '玩家登录');
INSERT INTO `user_log` VALUES ('809', '210728', '3', '2018-09-26 15:13:29', '玩家登录');
INSERT INTO `user_log` VALUES ('810', '210729', '3', '2018-09-26 15:14:08', '玩家登录');
INSERT INTO `user_log` VALUES ('811', '210730', '3', '2018-09-26 15:14:09', '玩家登录');
INSERT INTO `user_log` VALUES ('812', '210731', '3', '2018-09-26 15:14:12', '玩家登录');
INSERT INTO `user_log` VALUES ('813', '210732', '3', '2018-09-26 15:26:09', '玩家登录');
INSERT INTO `user_log` VALUES ('814', '210733', '3', '2018-09-26 15:26:10', '玩家登录');
INSERT INTO `user_log` VALUES ('815', '210734', '3', '2018-09-26 15:26:11', '玩家登录');
INSERT INTO `user_log` VALUES ('816', '210735', '3', '2018-09-26 15:26:13', '玩家登录');
INSERT INTO `user_log` VALUES ('817', '210712', '3', '2018-09-26 15:27:18', '玩家登录');
INSERT INTO `user_log` VALUES ('818', '210736', '3', '2018-09-26 15:27:28', '玩家登录');
INSERT INTO `user_log` VALUES ('819', '210737', '3', '2018-09-26 15:31:09', '玩家登录');
INSERT INTO `user_log` VALUES ('820', '210738', '3', '2018-09-26 15:31:10', '玩家登录');
INSERT INTO `user_log` VALUES ('821', '210739', '3', '2018-09-26 15:31:11', '玩家登录');
INSERT INTO `user_log` VALUES ('822', '210740', '3', '2018-09-26 15:31:12', '玩家登录');
INSERT INTO `user_log` VALUES ('823', '210741', '3', '2018-09-26 15:32:48', '玩家登录');
INSERT INTO `user_log` VALUES ('824', '210742', '3', '2018-09-26 15:32:49', '玩家登录');
INSERT INTO `user_log` VALUES ('825', '210743', '3', '2018-09-26 15:32:49', '玩家登录');
INSERT INTO `user_log` VALUES ('826', '210744', '3', '2018-09-26 15:32:50', '玩家登录');
INSERT INTO `user_log` VALUES ('827', '210745', '3', '2018-09-26 15:32:51', '玩家登录');
INSERT INTO `user_log` VALUES ('828', '210712', '3', '2018-09-26 15:45:51', '玩家登录');
INSERT INTO `user_log` VALUES ('829', '210746', '3', '2018-09-26 15:48:23', '玩家登录');
INSERT INTO `user_log` VALUES ('830', '210747', '3', '2018-09-26 15:48:23', '玩家登录');
INSERT INTO `user_log` VALUES ('831', '210748', '3', '2018-09-26 15:48:24', '玩家登录');
INSERT INTO `user_log` VALUES ('832', '210749', '3', '2018-09-26 15:48:25', '玩家登录');
INSERT INTO `user_log` VALUES ('833', '210750', '3', '2018-09-26 15:48:26', '玩家登录');
INSERT INTO `user_log` VALUES ('834', '210751', '3', '2018-09-26 15:48:51', '玩家登录');
INSERT INTO `user_log` VALUES ('835', '210752', '3', '2018-09-26 15:48:52', '玩家登录');
INSERT INTO `user_log` VALUES ('836', '210753', '3', '2018-09-26 15:48:53', '玩家登录');
INSERT INTO `user_log` VALUES ('837', '210754', '3', '2018-09-26 15:48:54', '玩家登录');
INSERT INTO `user_log` VALUES ('838', '210755', '3', '2018-09-26 15:53:19', '玩家登录');
INSERT INTO `user_log` VALUES ('839', '210756', '3', '2018-09-26 15:53:20', '玩家登录');
INSERT INTO `user_log` VALUES ('840', '210757', '3', '2018-09-26 15:53:21', '玩家登录');
INSERT INTO `user_log` VALUES ('841', '210758', '3', '2018-09-26 15:53:23', '玩家登录');
INSERT INTO `user_log` VALUES ('842', '210759', '3', '2018-09-26 15:53:23', '玩家登录');
INSERT INTO `user_log` VALUES ('843', '210760', '3', '2018-09-26 16:00:13', '玩家登录');
INSERT INTO `user_log` VALUES ('844', '210761', '3', '2018-09-26 16:00:14', '玩家登录');
INSERT INTO `user_log` VALUES ('845', '210762', '3', '2018-09-26 16:00:15', '玩家登录');
INSERT INTO `user_log` VALUES ('846', '210763', '3', '2018-09-26 16:00:16', '玩家登录');
INSERT INTO `user_log` VALUES ('847', '210764', '3', '2018-09-26 16:22:26', '玩家登录');
INSERT INTO `user_log` VALUES ('848', '210765', '3', '2018-09-26 16:22:27', '玩家登录');
INSERT INTO `user_log` VALUES ('849', '210766', '3', '2018-09-26 16:22:27', '玩家登录');
INSERT INTO `user_log` VALUES ('850', '210767', '3', '2018-09-26 16:22:29', '玩家登录');
INSERT INTO `user_log` VALUES ('851', '210768', '3', '2018-09-26 16:22:59', '玩家登录');
INSERT INTO `user_log` VALUES ('852', '210769', '3', '2018-09-26 16:23:50', '玩家登录');
INSERT INTO `user_log` VALUES ('853', '210770', '3', '2018-09-26 16:23:50', '玩家登录');
INSERT INTO `user_log` VALUES ('854', '210771', '3', '2018-09-26 16:23:51', '玩家登录');
INSERT INTO `user_log` VALUES ('855', '210772', '3', '2018-09-26 16:23:52', '玩家登录');
INSERT INTO `user_log` VALUES ('856', '210773', '3', '2018-09-26 16:36:26', '玩家登录');
INSERT INTO `user_log` VALUES ('857', '210774', '3', '2018-09-26 16:36:27', '玩家登录');
INSERT INTO `user_log` VALUES ('858', '210775', '3', '2018-09-26 16:36:28', '玩家登录');
INSERT INTO `user_log` VALUES ('859', '210776', '3', '2018-09-26 16:36:29', '玩家登录');
INSERT INTO `user_log` VALUES ('860', '210777', '3', '2018-09-26 16:40:29', '玩家登录');
INSERT INTO `user_log` VALUES ('861', '210778', '3', '2018-09-26 16:40:30', '玩家登录');
INSERT INTO `user_log` VALUES ('862', '210779', '3', '2018-09-26 16:40:31', '玩家登录');
INSERT INTO `user_log` VALUES ('863', '210780', '3', '2018-09-26 16:40:32', '玩家登录');
INSERT INTO `user_log` VALUES ('864', '210781', '3', '2018-09-26 16:52:12', '玩家登录');
INSERT INTO `user_log` VALUES ('865', '210782', '3', '2018-09-26 16:52:13', '玩家登录');
INSERT INTO `user_log` VALUES ('866', '210783', '3', '2018-09-26 16:52:13', '玩家登录');
INSERT INTO `user_log` VALUES ('867', '210784', '3', '2018-09-26 16:52:17', '玩家登录');
INSERT INTO `user_log` VALUES ('868', '210785', '3', '2018-09-26 16:54:59', '玩家登录');
INSERT INTO `user_log` VALUES ('869', '210786', '3', '2018-09-26 16:55:00', '玩家登录');
INSERT INTO `user_log` VALUES ('870', '210787', '3', '2018-09-26 16:55:01', '玩家登录');
INSERT INTO `user_log` VALUES ('871', '210788', '3', '2018-09-26 16:55:02', '玩家登录');
INSERT INTO `user_log` VALUES ('872', '210789', '3', '2018-09-26 16:59:45', '玩家登录');
INSERT INTO `user_log` VALUES ('873', '210790', '3', '2018-09-26 16:59:45', '玩家登录');
INSERT INTO `user_log` VALUES ('874', '210791', '3', '2018-09-26 16:59:52', '玩家登录');
INSERT INTO `user_log` VALUES ('875', '210792', '3', '2018-09-26 16:59:54', '玩家登录');
INSERT INTO `user_log` VALUES ('876', '210793', '3', '2018-09-26 17:03:21', '玩家登录');
INSERT INTO `user_log` VALUES ('877', '210794', '3', '2018-09-26 17:03:21', '玩家登录');
INSERT INTO `user_log` VALUES ('878', '210795', '3', '2018-09-26 17:03:22', '玩家登录');
INSERT INTO `user_log` VALUES ('879', '210796', '3', '2018-09-26 17:03:23', '玩家登录');
INSERT INTO `user_log` VALUES ('880', '210797', '3', '2018-09-26 17:08:03', '玩家登录');
INSERT INTO `user_log` VALUES ('881', '210798', '3', '2018-09-26 17:08:03', '玩家登录');
INSERT INTO `user_log` VALUES ('882', '210799', '3', '2018-09-26 17:08:04', '玩家登录');
INSERT INTO `user_log` VALUES ('883', '210800', '3', '2018-09-26 17:08:41', '玩家登录');
INSERT INTO `user_log` VALUES ('884', '210801', '3', '2018-09-26 17:27:32', '玩家登录');
INSERT INTO `user_log` VALUES ('885', '210802', '3', '2018-09-26 17:27:32', '玩家登录');
INSERT INTO `user_log` VALUES ('886', '210803', '3', '2018-09-26 17:27:33', '玩家登录');
INSERT INTO `user_log` VALUES ('887', '210804', '3', '2018-09-26 17:27:34', '玩家登录');
INSERT INTO `user_log` VALUES ('888', '210805', '3', '2018-09-26 17:31:16', '玩家登录');
INSERT INTO `user_log` VALUES ('889', '210806', '3', '2018-09-26 17:31:17', '玩家登录');
INSERT INTO `user_log` VALUES ('890', '210807', '3', '2018-09-26 17:31:18', '玩家登录');
INSERT INTO `user_log` VALUES ('891', '210808', '3', '2018-09-26 17:31:19', '玩家登录');
INSERT INTO `user_log` VALUES ('892', '210809', '3', '2018-09-26 17:32:34', '玩家登录');
INSERT INTO `user_log` VALUES ('893', '210810', '3', '2018-09-26 17:33:10', '玩家登录');
INSERT INTO `user_log` VALUES ('894', '210811', '3', '2018-09-26 17:33:11', '玩家登录');
INSERT INTO `user_log` VALUES ('895', '210812', '3', '2018-09-26 17:33:12', '玩家登录');
INSERT INTO `user_log` VALUES ('896', '210813', '3', '2018-09-26 17:33:13', '玩家登录');
INSERT INTO `user_log` VALUES ('897', '210814', '3', '2018-09-26 17:35:00', '玩家登录');
INSERT INTO `user_log` VALUES ('898', '210815', '3', '2018-09-26 17:35:01', '玩家登录');
INSERT INTO `user_log` VALUES ('899', '210816', '3', '2018-09-26 17:35:01', '玩家登录');
INSERT INTO `user_log` VALUES ('900', '210817', '3', '2018-09-26 17:35:02', '玩家登录');
INSERT INTO `user_log` VALUES ('901', '210818', '3', '2018-09-26 17:42:25', '玩家登录');
INSERT INTO `user_log` VALUES ('902', '210819', '3', '2018-09-26 17:42:26', '玩家登录');
INSERT INTO `user_log` VALUES ('903', '210820', '3', '2018-09-26 17:42:27', '玩家登录');
INSERT INTO `user_log` VALUES ('904', '210821', '3', '2018-09-26 17:42:28', '玩家登录');
INSERT INTO `user_log` VALUES ('905', '210822', '3', '2018-09-26 17:51:56', '玩家登录');
INSERT INTO `user_log` VALUES ('906', '210823', '3', '2018-09-26 17:52:49', '玩家登录');

-- ----------------------------
-- Table structure for user_log_bak
-- ----------------------------
DROP TABLE IF EXISTS `user_log_bak`;
CREATE TABLE `user_log_bak` (
  `id` int(11) NOT NULL,
  `userid` int(11) DEFAULT NULL,
  `logtype` tinyint(255) DEFAULT NULL,
  `addtime` datetime DEFAULT NULL,
  `remark` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of user_log_bak
-- ----------------------------

-- ----------------------------
-- Table structure for user_snsinfo
-- ----------------------------
DROP TABLE IF EXISTS `user_snsinfo`;
CREATE TABLE `user_snsinfo` (
  `id` int(11) NOT NULL AUTO_INCREMENT COMMENT '编号',
  `unionId` varchar(200) DEFAULT NULL COMMENT '三方登录的联合用户Id',
  `openId` varchar(200) DEFAULT NULL COMMENT '三方登录的用户Id',
  `snsId` int(11) DEFAULT NULL COMMENT '三方登录的编码',
  `userid` int(11) DEFAULT NULL COMMENT '绑定到的平台用户Id',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of user_snsinfo
-- ----------------------------
INSERT INTO `user_snsinfo` VALUES ('1', 'oxMJn1e-S_wiHJre8vjJf_rfIb7k', 'op1JS1iOxTOEeK_kqaaAZo49thCs', '1', '210413');

-- ----------------------------
-- Table structure for user_stat
-- ----------------------------
DROP TABLE IF EXISTS `user_stat`;
CREATE TABLE `user_stat` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `userid` int(11) NOT NULL COMMENT '玩家id',
  `gameid` int(11) NOT NULL COMMENT '游戏id',
  `roomcnt` int(11) DEFAULT '0' COMMENT '总局数',
  `roomamt` int(11) DEFAULT '0' COMMENT '房费耗钻',
  `totalamt` int(11) DEFAULT '0' COMMENT '总计分',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE=MyISAM AUTO_INCREMENT=79 DEFAULT CHARSET=utf8 COMMENT='玩家统计';

-- ----------------------------
-- Records of user_stat
-- ----------------------------
INSERT INTO `user_stat` VALUES ('1', '210007', '100', '0', '0', '0');
INSERT INTO `user_stat` VALUES ('2', '210052', '51', '1', '0', '0');
INSERT INTO `user_stat` VALUES ('3', '210061', '100', '0', '0', '0');
INSERT INTO `user_stat` VALUES ('4', '210065', '51', '1', '0', '0');
INSERT INTO `user_stat` VALUES ('5', '210067', '51', '1', '0', '0');
INSERT INTO `user_stat` VALUES ('6', '210068', '51', '1', '0', '0');
INSERT INTO `user_stat` VALUES ('7', '210077', '100', '0', '0', '0');
INSERT INTO `user_stat` VALUES ('8', '210078', '100', '0', '0', '0');
INSERT INTO `user_stat` VALUES ('9', '210079', '100', '0', '0', '0');
INSERT INTO `user_stat` VALUES ('10', '210080', '100', '0', '0', '0');
INSERT INTO `user_stat` VALUES ('11', '210083', '100', '0', '0', '0');
INSERT INTO `user_stat` VALUES ('12', '210084', '100', '0', '0', '0');
INSERT INTO `user_stat` VALUES ('13', '210085', '100', '0', '0', '0');
INSERT INTO `user_stat` VALUES ('14', '210086', '100', '0', '0', '0');
INSERT INTO `user_stat` VALUES ('15', '210097', '100', '0', '0', '0');
INSERT INTO `user_stat` VALUES ('16', '210098', '100', '0', '0', '0');
INSERT INTO `user_stat` VALUES ('17', '210099', '100', '0', '0', '0');
INSERT INTO `user_stat` VALUES ('18', '210100', '100', '0', '0', '0');
INSERT INTO `user_stat` VALUES ('19', '210135', '100', '0', '0', '0');
INSERT INTO `user_stat` VALUES ('20', '210136', '100', '0', '0', '0');
INSERT INTO `user_stat` VALUES ('21', '210137', '100', '0', '0', '0');
INSERT INTO `user_stat` VALUES ('22', '210138', '100', '0', '0', '0');
INSERT INTO `user_stat` VALUES ('23', '210139', '100', '0', '0', '0');
INSERT INTO `user_stat` VALUES ('24', '210140', '100', '0', '0', '0');
INSERT INTO `user_stat` VALUES ('25', '210141', '100', '0', '0', '0');
INSERT INTO `user_stat` VALUES ('26', '210142', '100', '0', '0', '0');
INSERT INTO `user_stat` VALUES ('27', '210159', '100', '0', '0', '0');
INSERT INTO `user_stat` VALUES ('28', '210160', '100', '0', '0', '0');
INSERT INTO `user_stat` VALUES ('29', '210161', '100', '0', '0', '0');
INSERT INTO `user_stat` VALUES ('30', '210162', '100', '0', '0', '0');
INSERT INTO `user_stat` VALUES ('31', '210222', '100', '0', '0', '0');
INSERT INTO `user_stat` VALUES ('32', '210223', '100', '0', '0', '0');
INSERT INTO `user_stat` VALUES ('33', '210224', '100', '0', '0', '0');
INSERT INTO `user_stat` VALUES ('34', '210225', '100', '0', '0', '0');
INSERT INTO `user_stat` VALUES ('35', '210226', '100', '0', '0', '0');
INSERT INTO `user_stat` VALUES ('36', '210227', '100', '0', '0', '0');
INSERT INTO `user_stat` VALUES ('37', '210228', '100', '0', '0', '0');
INSERT INTO `user_stat` VALUES ('38', '210229', '100', '0', '0', '0');
INSERT INTO `user_stat` VALUES ('39', '210249', '100', '2', '0', '0');
INSERT INTO `user_stat` VALUES ('40', '210253', '100', '2', '0', '0');
INSERT INTO `user_stat` VALUES ('41', '210254', '100', '2', '0', '0');
INSERT INTO `user_stat` VALUES ('42', '210255', '100', '2', '0', '0');
INSERT INTO `user_stat` VALUES ('43', '210261', '100', '2', '0', '0');
INSERT INTO `user_stat` VALUES ('44', '210262', '100', '2', '0', '0');
INSERT INTO `user_stat` VALUES ('45', '210263', '100', '2', '0', '0');
INSERT INTO `user_stat` VALUES ('46', '210264', '100', '2', '0', '0');
INSERT INTO `user_stat` VALUES ('47', '210265', '100', '5', '0', '0');
INSERT INTO `user_stat` VALUES ('48', '210266', '100', '5', '0', '0');
INSERT INTO `user_stat` VALUES ('49', '210267', '100', '5', '0', '0');
INSERT INTO `user_stat` VALUES ('50', '210268', '100', '4', '0', '0');
INSERT INTO `user_stat` VALUES ('51', '210269', '100', '1', '0', '0');
INSERT INTO `user_stat` VALUES ('52', '210277', '100', '0', '0', '0');
INSERT INTO `user_stat` VALUES ('53', '210280', '100', '0', '0', '0');
INSERT INTO `user_stat` VALUES ('54', '210283', '100', '0', '0', '0');
INSERT INTO `user_stat` VALUES ('55', '210285', '100', '0', '0', '0');
INSERT INTO `user_stat` VALUES ('56', '210293', '100', '0', '0', '0');
INSERT INTO `user_stat` VALUES ('57', '210297', '100', '0', '0', '0');
INSERT INTO `user_stat` VALUES ('58', '210302', '100', '0', '0', '0');
INSERT INTO `user_stat` VALUES ('59', '210307', '100', '0', '0', '0');
INSERT INTO `user_stat` VALUES ('60', '210308', '100', '1', '0', '0');
INSERT INTO `user_stat` VALUES ('61', '210309', '100', '1', '0', '0');
INSERT INTO `user_stat` VALUES ('62', '210310', '100', '1', '0', '0');
INSERT INTO `user_stat` VALUES ('63', '210311', '100', '1', '0', '0');
INSERT INTO `user_stat` VALUES ('64', '210317', '100', '0', '0', '0');
INSERT INTO `user_stat` VALUES ('65', '210319', '100', '0', '0', '0');
INSERT INTO `user_stat` VALUES ('66', '210330', '100', '0', '0', '0');
INSERT INTO `user_stat` VALUES ('67', '210364', '100', '0', '0', '0');
INSERT INTO `user_stat` VALUES ('68', '210371', '100', '0', '0', '0');
INSERT INTO `user_stat` VALUES ('69', '210376', '100', '0', '0', '0');
INSERT INTO `user_stat` VALUES ('70', '210420', '100', '0', '0', '0');
INSERT INTO `user_stat` VALUES ('71', '210435', '100', '0', '0', '0');
INSERT INTO `user_stat` VALUES ('72', '210448', '100', '0', '0', '0');
INSERT INTO `user_stat` VALUES ('73', '210453', '100', '0', '0', '0');
INSERT INTO `user_stat` VALUES ('74', '210458', '100', '0', '0', '0');
INSERT INTO `user_stat` VALUES ('75', '210515', '100', '0', '0', '0');
INSERT INTO `user_stat` VALUES ('76', '210624', '100', '0', '0', '0');
INSERT INTO `user_stat` VALUES ('77', '210625', '100', '0', '0', '0');
INSERT INTO `user_stat` VALUES ('78', '210626', '100', '0', '0', '0');

-- ----------------------------
-- Table structure for user_stat_day
-- ----------------------------
DROP TABLE IF EXISTS `user_stat_day`;
CREATE TABLE `user_stat_day` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `userid` int(11) NOT NULL COMMENT '玩家id',
  `gameid` int(11) NOT NULL COMMENT '游戏id',
  `dateid` varchar(10) DEFAULT NULL COMMENT '日期yyyy-mm-dd',
  `roomcnt` int(11) DEFAULT '0' COMMENT '局数',
  `roomamt` int(11) DEFAULT '0' COMMENT '房费耗钻',
  `totalamt` int(11) DEFAULT '0' COMMENT '总计分',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE=MyISAM AUTO_INCREMENT=79 DEFAULT CHARSET=utf8 COMMENT='玩家统计';

-- ----------------------------
-- Records of user_stat_day
-- ----------------------------
INSERT INTO `user_stat_day` VALUES ('1', '210007', '100', '2018-09-22', '0', '0', '0');
INSERT INTO `user_stat_day` VALUES ('2', '210052', '51', '2018-09-22', '1', '0', '0');
INSERT INTO `user_stat_day` VALUES ('3', '210061', '100', '2018-09-22', '0', '0', '0');
INSERT INTO `user_stat_day` VALUES ('4', '210065', '51', '2018-09-22', '1', '0', '0');
INSERT INTO `user_stat_day` VALUES ('5', '210067', '51', '2018-09-22', '1', '0', '0');
INSERT INTO `user_stat_day` VALUES ('6', '210068', '51', '2018-09-22', '1', '0', '0');
INSERT INTO `user_stat_day` VALUES ('7', '210077', '100', '2018-09-22', '0', '0', '0');
INSERT INTO `user_stat_day` VALUES ('8', '210078', '100', '2018-09-22', '0', '0', '0');
INSERT INTO `user_stat_day` VALUES ('9', '210079', '100', '2018-09-22', '0', '0', '0');
INSERT INTO `user_stat_day` VALUES ('10', '210080', '100', '2018-09-22', '0', '0', '0');
INSERT INTO `user_stat_day` VALUES ('11', '210083', '100', '2018-09-22', '0', '0', '0');
INSERT INTO `user_stat_day` VALUES ('12', '210084', '100', '2018-09-22', '0', '0', '0');
INSERT INTO `user_stat_day` VALUES ('13', '210085', '100', '2018-09-22', '0', '0', '0');
INSERT INTO `user_stat_day` VALUES ('14', '210086', '100', '2018-09-22', '0', '0', '0');
INSERT INTO `user_stat_day` VALUES ('15', '210097', '100', '2018-09-22', '0', '0', '0');
INSERT INTO `user_stat_day` VALUES ('16', '210098', '100', '2018-09-22', '0', '0', '0');
INSERT INTO `user_stat_day` VALUES ('17', '210099', '100', '2018-09-22', '0', '0', '0');
INSERT INTO `user_stat_day` VALUES ('18', '210100', '100', '2018-09-22', '0', '0', '0');
INSERT INTO `user_stat_day` VALUES ('19', '210135', '100', '2018-09-23', '0', '0', '0');
INSERT INTO `user_stat_day` VALUES ('20', '210136', '100', '2018-09-23', '0', '0', '0');
INSERT INTO `user_stat_day` VALUES ('21', '210137', '100', '2018-09-23', '0', '0', '0');
INSERT INTO `user_stat_day` VALUES ('22', '210138', '100', '2018-09-23', '0', '0', '0');
INSERT INTO `user_stat_day` VALUES ('23', '210139', '100', '2018-09-23', '0', '0', '0');
INSERT INTO `user_stat_day` VALUES ('24', '210140', '100', '2018-09-23', '0', '0', '0');
INSERT INTO `user_stat_day` VALUES ('25', '210141', '100', '2018-09-23', '0', '0', '0');
INSERT INTO `user_stat_day` VALUES ('26', '210142', '100', '2018-09-23', '0', '0', '0');
INSERT INTO `user_stat_day` VALUES ('27', '210159', '100', '2018-09-23', '0', '0', '0');
INSERT INTO `user_stat_day` VALUES ('28', '210160', '100', '2018-09-23', '0', '0', '0');
INSERT INTO `user_stat_day` VALUES ('29', '210161', '100', '2018-09-23', '0', '0', '0');
INSERT INTO `user_stat_day` VALUES ('30', '210162', '100', '2018-09-23', '0', '0', '0');
INSERT INTO `user_stat_day` VALUES ('31', '210222', '100', '2018-09-23', '0', '0', '0');
INSERT INTO `user_stat_day` VALUES ('32', '210223', '100', '2018-09-23', '0', '0', '0');
INSERT INTO `user_stat_day` VALUES ('33', '210224', '100', '2018-09-23', '0', '0', '0');
INSERT INTO `user_stat_day` VALUES ('34', '210225', '100', '2018-09-23', '0', '0', '0');
INSERT INTO `user_stat_day` VALUES ('35', '210226', '100', '2018-09-23', '0', '0', '0');
INSERT INTO `user_stat_day` VALUES ('36', '210227', '100', '2018-09-23', '0', '0', '0');
INSERT INTO `user_stat_day` VALUES ('37', '210228', '100', '2018-09-23', '0', '0', '0');
INSERT INTO `user_stat_day` VALUES ('38', '210229', '100', '2018-09-23', '0', '0', '0');
INSERT INTO `user_stat_day` VALUES ('39', '210249', '100', '2018-09-24', '2', '0', '0');
INSERT INTO `user_stat_day` VALUES ('40', '210253', '100', '2018-09-24', '2', '0', '0');
INSERT INTO `user_stat_day` VALUES ('41', '210254', '100', '2018-09-24', '2', '0', '0');
INSERT INTO `user_stat_day` VALUES ('42', '210255', '100', '2018-09-24', '2', '0', '0');
INSERT INTO `user_stat_day` VALUES ('43', '210261', '100', '2018-09-24', '2', '0', '0');
INSERT INTO `user_stat_day` VALUES ('44', '210262', '100', '2018-09-24', '2', '0', '0');
INSERT INTO `user_stat_day` VALUES ('45', '210263', '100', '2018-09-24', '2', '0', '0');
INSERT INTO `user_stat_day` VALUES ('46', '210264', '100', '2018-09-24', '2', '0', '0');
INSERT INTO `user_stat_day` VALUES ('47', '210265', '100', '2018-09-24', '5', '0', '0');
INSERT INTO `user_stat_day` VALUES ('48', '210266', '100', '2018-09-24', '5', '0', '0');
INSERT INTO `user_stat_day` VALUES ('49', '210267', '100', '2018-09-24', '5', '0', '0');
INSERT INTO `user_stat_day` VALUES ('50', '210268', '100', '2018-09-24', '4', '0', '0');
INSERT INTO `user_stat_day` VALUES ('51', '210269', '100', '2018-09-24', '1', '0', '0');
INSERT INTO `user_stat_day` VALUES ('52', '210277', '100', '2018-09-24', '0', '0', '0');
INSERT INTO `user_stat_day` VALUES ('53', '210280', '100', '2018-09-24', '0', '0', '0');
INSERT INTO `user_stat_day` VALUES ('54', '210283', '100', '2018-09-24', '0', '0', '0');
INSERT INTO `user_stat_day` VALUES ('55', '210285', '100', '2018-09-24', '0', '0', '0');
INSERT INTO `user_stat_day` VALUES ('56', '210293', '100', '2018-09-24', '0', '0', '0');
INSERT INTO `user_stat_day` VALUES ('57', '210297', '100', '2018-09-24', '0', '0', '0');
INSERT INTO `user_stat_day` VALUES ('58', '210302', '100', '2018-09-24', '0', '0', '0');
INSERT INTO `user_stat_day` VALUES ('59', '210307', '100', '2018-09-24', '0', '0', '0');
INSERT INTO `user_stat_day` VALUES ('60', '210308', '100', '2018-09-24', '1', '0', '0');
INSERT INTO `user_stat_day` VALUES ('61', '210309', '100', '2018-09-24', '1', '0', '0');
INSERT INTO `user_stat_day` VALUES ('62', '210310', '100', '2018-09-24', '1', '0', '0');
INSERT INTO `user_stat_day` VALUES ('63', '210311', '100', '2018-09-24', '1', '0', '0');
INSERT INTO `user_stat_day` VALUES ('64', '210317', '100', '2018-09-24', '0', '0', '0');
INSERT INTO `user_stat_day` VALUES ('65', '210319', '100', '2018-09-24', '0', '0', '0');
INSERT INTO `user_stat_day` VALUES ('66', '210330', '100', '2018-09-24', '0', '0', '0');
INSERT INTO `user_stat_day` VALUES ('67', '210364', '100', '2018-09-25', '0', '0', '0');
INSERT INTO `user_stat_day` VALUES ('68', '210371', '100', '2018-09-25', '0', '0', '0');
INSERT INTO `user_stat_day` VALUES ('69', '210376', '100', '2018-09-25', '0', '0', '0');
INSERT INTO `user_stat_day` VALUES ('70', '210420', '100', '2018-09-25', '0', '0', '0');
INSERT INTO `user_stat_day` VALUES ('71', '210435', '100', '2018-09-25', '0', '0', '0');
INSERT INTO `user_stat_day` VALUES ('72', '210448', '100', '2018-09-25', '0', '0', '0');
INSERT INTO `user_stat_day` VALUES ('73', '210453', '100', '2018-09-25', '0', '0', '0');
INSERT INTO `user_stat_day` VALUES ('74', '210458', '100', '2018-09-25', '0', '0', '0');
INSERT INTO `user_stat_day` VALUES ('75', '210515', '100', '2018-09-25', '0', '0', '0');
INSERT INTO `user_stat_day` VALUES ('76', '210624', '100', '2018-09-25', '0', '0', '0');
INSERT INTO `user_stat_day` VALUES ('77', '210625', '100', '2018-09-25', '0', '0', '0');
INSERT INTO `user_stat_day` VALUES ('78', '210626', '100', '2018-09-25', '0', '0', '0');

-- ----------------------------
-- Table structure for user_task
-- ----------------------------
DROP TABLE IF EXISTS `user_task`;
CREATE TABLE `user_task` (
  `taskid` varchar(50) NOT NULL COMMENT '任务代码',
  `taskname` varchar(50) DEFAULT NULL COMMENT '任务名称',
  `addtime` datetime DEFAULT NULL COMMENT '添加时间',
  `begintime` datetime DEFAULT NULL COMMENT '有效期开始时间',
  `endtime` datetime DEFAULT NULL COMMENT '有效期结束时间',
  `taskremark` varchar(2000) DEFAULT NULL COMMENT '任务说明',
  `status` char(1) DEFAULT '1' COMMENT '0不可用1可用',
  `issubtask` char(1) DEFAULT '0' COMMENT '是否有子任务0没有1有',
  `isview` char(1) DEFAULT '1' COMMENT '是否显示0不显示1显示',
  `diamond` double(12,2) DEFAULT '0.00' COMMENT '钻石',
  `gold` double(12,2) DEFAULT '0.00' COMMENT '金币',
  `qidou` double(12,2) DEFAULT '0.00' COMMENT '七豆',
  PRIMARY KEY (`taskid`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='任务主表';

-- ----------------------------
-- Records of user_task
-- ----------------------------
INSERT INTO `user_task` VALUES ('share_diamond', '分享送钻石', '2018-09-01 00:00:22', '2018-09-01 00:00:00', '2099-12-31 00:00:00', '分享送钻石', '1', '0', '1', '10.00', '0.00', '0.00');

-- ----------------------------
-- Table structure for user_task_log
-- ----------------------------
DROP TABLE IF EXISTS `user_task_log`;
CREATE TABLE `user_task_log` (
  `logid` varchar(20) NOT NULL COMMENT 'ID',
  `taskid` varchar(50) NOT NULL DEFAULT '' COMMENT '任务代码',
  `userid` int(11) NOT NULL COMMENT '用户ID',
  `addtime` datetime DEFAULT NULL COMMENT '添加时间',
  `remark` varchar(200) DEFAULT NULL COMMENT '备注',
  `diamond` double(12,2) DEFAULT '0.00' COMMENT '钻石',
  `gold` double(12,2) DEFAULT '0.00' COMMENT '金币',
  `qidou` double(12,2) DEFAULT '0.00' COMMENT '七豆',
  PRIMARY KEY (`logid`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='任务日志表';

-- ----------------------------
-- Records of user_task_log
-- ----------------------------

-- ----------------------------
-- Table structure for web_apikeysecretconfig
-- ----------------------------
DROP TABLE IF EXISTS `web_apikeysecretconfig`;
CREATE TABLE `web_apikeysecretconfig` (
  `ID` varchar(200) NOT NULL COMMENT '编号',
  `APPID` varchar(300) DEFAULT NULL COMMENT '接口分配的应用AppId',
  `Type` varchar(100) DEFAULT NULL COMMENT '应用类型',
  `SNSSetID` int(11) DEFAULT NULL COMMENT '平台和接口绑定的约定编号',
  `AppSecret` varchar(500) DEFAULT NULL COMMENT '接口应用对应分配的密钥',
  `ReMark` varchar(300) DEFAULT NULL COMMENT '备注说明',
  `PRsaKey` varchar(500) DEFAULT NULL COMMENT '接口私钥',
  `AP1` varchar(500) DEFAULT NULL COMMENT '附加特殊参数1',
  `AP2` varchar(500) DEFAULT NULL COMMENT '附加特殊参数2',
  `Auth` varchar(500) DEFAULT NULL COMMENT '认证参数',
  PRIMARY KEY (`ID`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of web_apikeysecretconfig
-- ----------------------------
INSERT INTO `web_apikeysecretconfig` VALUES ('alioss', 'LTAIeqe3R31343fA', 'alioss', '0', '1BCaeAUaVOQgS4IQN9NfD7sp9oZM5s', '阿里云对象存储密钥', null, 'qile-files', null, null);
INSERT INTO `web_apikeysecretconfig` VALUES ('ql_1', 'ql_1', 'ql', '0', 'q3cIoll2w20Cjk6s9hTKjSq8qH4baxF6oAleBZbK', '网站和平台协调接口调用密钥', null, null, null, null);
INSERT INTO `web_apikeysecretconfig` VALUES ('wx4a98d29526a1f737', 'wx4a98d29526a1f737', 'wx', '1', '41a9b68c15f9e09201f20de590125b92', '七乐安徽麻将公众号', null, null, null, null);
INSERT INTO `web_apikeysecretconfig` VALUES ('wx5456e44c2f73280b', 'wx5456e44c2f73280b', 'wx', '1', 'a5f4485e9c4358c24cee3dd8b09d71f6', '合肥娱乐在线', null, null, null, null);
INSERT INTO `web_apikeysecretconfig` VALUES ('wx6ea708f4d025efa5', 'wx6ea708f4d025efa5', 'wx', '1', '055f22cf77a753b80f9d28d04c3431ba', '七乐安徽麻将', null, null, null, null);
INSERT INTO `web_apikeysecretconfig` VALUES ('wxd27d6a0f37c728d8', 'wxd27d6a0f37c728d8', 'wx', '1', '1fa79835c656db1b855fc3edd46c18ab', '七乐互娱测试', null, null, null, null);
INSERT INTO `web_apikeysecretconfig` VALUES ('wxpay_wx16b93c7ce7fa04b7', 'wx16b93c7ce7fa04b7', 'wxpay', '0', '9afa4617f688b12d010e19e9f5236f51', '七乐公众号支付', null, '1495734452', null, null);
INSERT INTO `web_apikeysecretconfig` VALUES ('wxpay_wx6ea708f4d025efa5', 'wx6ea708f4d025efa5', 'wxpay', '0', 'NqIiuyxgCv0Su8cR7umSSIdkR7e8siCK', '七乐安徽麻将应用支付', null, '1511958991', null, null);

-- ----------------------------
-- Table structure for web_hotupdateconf
-- ----------------------------
DROP TABLE IF EXISTS `web_hotupdateconf`;
CREATE TABLE `web_hotupdateconf` (
  `id` int(11) NOT NULL AUTO_INCREMENT COMMENT '编号',
  `region` varchar(50) NOT NULL COMMENT '分包渠道',
  `device_type` int(11) DEFAULT NULL COMMENT '设备类别，1 安卓 2 iOS',
  `pkg_version` int(11) DEFAULT NULL COMMENT '发布包的版本号',
  `downloadurl` varchar(500) DEFAULT NULL COMMENT '当检查发现有新的大版本发布，需要更新外壳时更新包的下载地址',
  `js_version` varchar(50) DEFAULT NULL COMMENT '热更新版本号',
  `packageUrl` varchar(500) DEFAULT NULL COMMENT '热更新相关的更新包下载根地址',
  `remoteManifestUrl` varchar(500) DEFAULT NULL COMMENT '用于更新检查的远端 project.Manifest 文件下载地址',
  `remoteVersionUrl` varchar(500) DEFAULT NULL COMMENT '用于更新检查的远端 version.Manifest 文件下载地址',
  `mark` varchar(500) DEFAULT NULL COMMENT '备注说明',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8 COMMENT='热更新的配置用管理表';

-- ----------------------------
-- Records of web_hotupdateconf
-- ----------------------------
INSERT INTO `web_hotupdateconf` VALUES ('1', 'qlahmj', '1', '2', 'https://fir.im/ahmjandroid', '180921214816', 'http://update.test.qileah.cn/hotupdate/qlahmj/hall/180921214816/', 'http://update.test.qileah.cn/hotupdate/qlahmj/hall/180921214816/project.manifest', 'http://update.test.qileah.cn/hotupdate/qlahmj/hall/180921214816/version.manifest', null);
INSERT INTO `web_hotupdateconf` VALUES ('2', 'qlahmj', '2', '2', 'https://fir.im/qlahmjios', '180921214816', 'http://update.test.qileah.cn/hotupdate/qlahmj/hall/180921214816/', 'http://update.test.qileah.cn/hotupdate/qlahmj/hall/180921214816/project.manifest', 'http://update.test.qileah.cn/hotupdate/qlahmj/hall/180921214816/version.manifest', null);
INSERT INTO `web_hotupdateconf` VALUES ('3', 'ceshi', '1', '1', 'https://fir.im/ghyq', '180925101937', 'http://update.test.qileah.cn/hotupdate/qlahmj/hall/180925101937/', 'http://update.test.qileah.cn/hotupdate/qlahmj/hall/180925101937/project.manifest', 'http://update.test.qileah.cn/hotupdate/qlahmj/hall/180925101937/version.manifest', null);
INSERT INTO `web_hotupdateconf` VALUES ('4', 'ceshi', '2', '1', 'https://fir.im/ghyq', '180925101937', 'http://update.test.qileah.cn/hotupdate/qlahmj/hall/180925101937/', 'http://update.test.qileah.cn/hotupdate/qlahmj/hall/180925101937/project.manifest', 'http://update.test.qileah.cn/hotupdate/qlahmj/hall/180925101937/version.manifest', null);

-- ----------------------------
-- Procedure structure for CSLoadForAIInfo
-- ----------------------------
DROP PROCEDURE IF EXISTS `CSLoadForAIInfo`;
DELIMITER ;;
CREATE DEFINER=`user76`@`%` PROCEDURE `CSLoadForAIInfo`(out `returnvalue` int)
BEGIN


	SELECT  1 as t LIMIT 0;


	set returnvalue = 1;
	
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for CSLoadGameList
-- ----------------------------
DROP PROCEDURE IF EXISTS `CSLoadGameList`;
DELIMITER ;;
CREATE DEFINER=`user76`@`%` PROCEDURE `CSLoadGameList`(out `returnvalue` int)
BEGIN

	SELECT * from game_info;
	set returnvalue = 1;
	
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for CSLoadSysConfigFromDB
-- ----------------------------
DROP PROCEDURE IF EXISTS `CSLoadSysConfigFromDB`;
DELIMITER ;;
CREATE DEFINER=`user76`@`%` PROCEDURE `CSLoadSysConfigFromDB`(in `sysStatus` int ,out `returnvalue` int)
BEGIN
	
	SELECT SysKey,SysValue from sys_config where `Status` =sysStatus ;
	set returnvalue = 1;
	
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for CSRegOLogin
-- ----------------------------
DROP PROCEDURE IF EXISTS `CSRegOLogin`;
DELIMITER ;;
CREATE DEFINER=`user76`@`%` PROCEDURE `CSRegOLogin`(
IN `_Pwd` VARCHAR ( 100 ),
IN `_ParentUser` INT,
IN `_Ip` VARCHAR ( 50 ),
IN `_NickName` VARCHAR ( 50 ),
IN `_RegStatus` INT,
IN `_Gender` INT,
OUT `OUT_UserID` INT,
OUT `returnvalue` INT 
)
BEGIN
DECLARE
	__UserId INT;

SET @@autocommit = off;

SET __UserId = fc_nextval ( 'user_info' );
INSERT INTO `user_info` ( `userid`, `useraccount`, `nickname`, `pw`, `addtime` )
VALUES
	( __UserId, ( CONCAT( 'u_', __UserId ) ), `_NickName`, _Pwd, NOW( ) );
-- 插入玩家账务信息表
INSERT INTO `user_account` ( `userid`, `rmb`, `diamond`, `gold`, `qidou`, `grift` )
VALUES
	( __UserId, 0.00, 100, 1000, 100.00, 0.00);
COMMIT;
-- 获取最新注册的玩家Id

SET `OUT_UserID` = __UserId;

SET returnvalue = 1;

END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for CS_User_Info_InitUser_dp_Query
-- ----------------------------
DROP PROCEDURE IF EXISTS `CS_User_Info_InitUser_dp_Query`;
DELIMITER ;;
CREATE DEFINER=`user76`@`%` PROCEDURE `CS_User_Info_InitUser_dp_Query`(IN `_UserID` INT, OUT `returnvalue` INT)
lable :
BEGIN
DECLARE __rmb INT DEFAULT 0;
DECLARE __gold INT DEFAULT 0;
DECLARE __diamond INT DEFAULT 0;
DECLARE __qidou INT DEFAULT 0;

DECLARE __msgCount int DEFAULT 0;
DECLARE __isFirstLogon int DEFAULT 0;
DECLARE __agentId int DEFAULT 0;


  SELECT agent_info.agentid into __agentId FROM agent_info WHERE agent_info.userid = `_UserID`;

SELECT
	user_info.userid AS UserID,
	user_info.picfile Header,
	user_info.nickname NickName,
	user_info.pw `PASSWORD`,
	user_info.agentid AgentId,
	user_info.isname AS HasIDChard,
	user_info.gender Gender,
	user_info.viplevel VipLV,
	user_info.usertype AS UserType
FROM
	`user_info`
WHERE
	user_info.UserId = `_UserID`;

IF (FOUND_ROWS() < 1) THEN
	-- 玩家不存在
SET returnvalue = - 1;

LEAVE lable;


END IF;


set @@autocommit =off;


-- __isFirstLogon
-- 获取玩家是不是首次登录等数据
SELECT ui.isFirstLogon into __isFirstLogon from user_info ui where ui.userid = `_UserID`;
UPDATE user_info  set user_info.isFirstLogon = 0 where user_info.userid = `_UserID`;


call sp_get_user_moneybag(`_UserID`);
 
INSERT INTO  `user_log`(`userid`, `logtype`, `addtime`, `remark`) VALUES (_UserID, '3', now(), '玩家登录');

 IF (SELECT COUNT(mcu.id) FROM msg_content_user mcu WHERE mcu.userid=_UserID AND mcu.status='0')>0 THEN
     SET __msgCount=1;
 ELSE
     SELECT COUNT(mc.id) INTO __msgCount
                FROM msg_content mc
                WHERE mc.msgstatus='1'
                  AND mc.msgobject='U'
                  AND mc.begintime<=SYSDATE()
                  AND mc.endtime>=SYSDATE()
                  AND NOT EXISTS(SELECT mcu.id FROM msg_content_user mcu WHERE mcu.msgid=mc.id AND mcu.userid=_UserID); 

 END IF;   

				

SELECT __msgCount as MessageNum,
	__isFirstLogon as isFirstLogon,
	__agentId as LinkAgentId;


				
				

commit;
SET returnvalue = 1;


END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for GSLoadAgentRoomList
-- ----------------------------
DROP PROCEDURE IF EXISTS `GSLoadAgentRoomList`;
DELIMITER ;;
CREATE DEFINER=`user76`@`%` PROCEDURE `GSLoadAgentRoomList`(in `ServerID` int ,out `returnvalue` int)
BEGIN


SELECT * from gameroom_info;


	set returnvalue = 1;
	
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for GS_PlayerSettlementMultiple
-- ----------------------------
DROP PROCEDURE IF EXISTS `GS_PlayerSettlementMultiple`;
DELIMITER ;;
CREATE DEFINER=`user76`@`%` PROCEDURE `GS_PlayerSettlementMultiple`(IN in_RoomId int, 
                                                       IN in_GameId int,
                                                       IN in_RoomCostType int,  
                                                       IN in_RoomCost int, 
                                                       IN in_OwnerId int, 
                                                       IN in_GroupId int, 
                                                       IN in_RoomCostMoneyType int,
                                                       IN in_mark varchar(1000), 
                                                       IN in_MoneyType int,
                                                       IN in_FeeUserCount int, 
                                                       IN in_UserId varchar(500), 
                                                       IN in_MoneyNum varchar(500),
                                                       IN in_GameNum int,
                                                       IN in_tableid int,
                                                       OUT returnvalue int )
BEGIN
 DECLARE v_setid int ;
  DECLARE v_i int DEFAULT 0;
  DECLARE v_in_userid int DEFAULT 0;
  DECLARE v_in_moneynum int DEFAULT 0;
  DECLARE v_group_userid int DEFAULT 0;
  DECLARE v_is_owner int DEFAULT 0;
  DECLARE v_is_group int DEFAULT 0;
  DECLARE v_o_roomcost int DEFAULT 0;
  DECLARE v_realmoney int DEFAULT 0;
  DECLARE v_sql1 varchar(2000) DEFAULT ' ';
  DECLARE v_sql2 varchar(2000) DEFAULT ' ';
  set @@autocommit=off;
  SET returnvalue=0;
  SET v_setid=fc_nextval('order_settlement');
  /* order_settlement*/
  INSERT INTO order_settlement(setid, roomid, gameid, RoomCostType, RoomCost, ownerid, groupid, RoomCostMoneyType, mark, MoneyType, FeeUserCount, addtime,gamenum,tableid)
       VALUES(v_setid, in_roomid, in_gameid, in_RoomCostType, in_RoomCost, in_ownerid, in_groupid, in_RoomCostMoneyType, in_mark, in_MoneyType, in_FeeUserCount, SYSDATE(),in_GameNum,in_tableid);
  /*如果是圈主支付 取圈主ID*/
  IF in_RoomCostType=3 THEN
    SELECT fi.userid INTO v_group_userid FROM friend_info fi WHERE fi.friendid=in_GroupId;
  END IF;
  /*--order_recorddata_detail*/
  SET v_i=0;
  loop_label:loop
      SET v_i=v_i+1;
      SET v_in_userid=fc_split_str(in_UserId,';',v_i)+0;
      SET v_in_moneynum=fc_split_str(in_MoneyNum,';',v_i)+0;
      IF ISNULL(v_in_userid) THEN
           leave loop_label;
      END IF;
      INSERT INTO order_settlement_detail(setid, userid, moneynum,addtime)
              VALUES(v_setid,v_in_userid,v_in_moneynum,SYSDATE());
  /*结算房费1AA2房主3圈主*/
  /*结算房费类型0无1RMB2钻石3金币*/
    IF in_RoomCostType=1 THEN
      CALL GS_SettlementOne(v_setid,'20',v_in_userid,in_RoomCostMoneyType,-in_RoomCost,v_o_roomcost);
    END IF;
  /*玩家结算类型0无1RMB2钻石3金币*/
    CALL GS_SettlementOne(v_setid,'21',v_in_userid,in_MoneyType,v_in_moneynum,v_realmoney);
  /*结算后返回*/
    /*SET o_UserID=CONCAT(CAST(v_in_userid AS CHAR),';');
    SET o_MoneyNum=CONCAT(CAST(v_in_moneynum AS CHAR),';');
    SET o_RealFeeMoneyNum=CONCAT(CAST(v_in_moneynum AS CHAR),';');*/
    SET v_sql1 = CONCAT_WS(' ',v_sql1,'UNION ALL SELECT ','1 as AuditResult,' 
                                               , v_in_moneynum,' as MoneyNum,'
                                               , v_in_userid,' as UserID,'
                                               , v_realmoney,' as RealFeeMoneyNum ' );
  /*是否玩家有owner*/
     IF in_OwnerId=v_in_userid THEN
        SET v_is_owner=1;
     END IF;
   /*是否玩家有group*/
     IF v_group_userid=v_in_userid THEN
        SET v_is_group=1;
     END IF;
  end loop;
  /*结算房费1AA2房主3圈主*/
  /*结算房费类型0无1RMB2钻石3金币*/
  IF in_RoomCostType=2 THEN
      CALL GS_SettlementOne(v_setid,'20',in_OwnerId,in_RoomCostMoneyType,-in_RoomCost*in_FeeUserCount,v_o_roomcost); 
  ELSEIF in_RoomCostType=3 THEN
      CALL GS_SettlementOne(v_setid,'20',v_group_userid,in_RoomCostMoneyType,-in_RoomCost*in_FeeUserCount,v_o_roomcost);
  END IF; 
  COMMIT;
 /*获取账户余额*/
   SET v_i=0;
  loop_label:loop
      SET v_i=v_i+1;
      SET v_in_userid=fc_split_str(in_UserId,';',v_i)+0;
      SET v_in_moneynum=fc_split_str(in_MoneyNum,';',v_i)+0;
      IF ISNULL(v_in_userid) THEN
           leave loop_label;
      END IF;
  /*结算房费1AA2房主3圈主*/
  /*结算房费类型0无1RMB2钻石3金币*/
  /*玩家结算类型0无1RMB2钻石3金币*/
   /*账户余额*/
   /* SET o_UserId2=CONCAT(CAST(v_in_userid AS CHAR),';');
    SET o_MoneyNum2=CONCAT(CAST(fc_get_user_account(v_in_userid,in_MoneyType) AS CHAR),';');
    SET o_MoneyType2=CONCAT(CAST(in_MoneyType AS CHAR),';');*/
    SET v_sql2 = CONCAT_WS(' ',v_sql2,'UNION ALL SELECT ', fc_get_user_account(v_in_userid,in_MoneyType),' as MoneyNum,'
                                               , v_in_userid,' as UserID,'
                                               , in_MoneyType,' as MoneyType ' );
    IF in_RoomCostMoneyType<>in_MoneyType AND in_RoomCostType=1  THEN
      SET v_sql2 = CONCAT_WS(' ',v_sql2,'UNION ALL SELECT ', fc_get_user_account(v_in_userid,in_RoomCostMoneyType),' as MoneyNum,'
                                               , v_in_userid,' as UserID,'
                                               , in_RoomCostMoneyType,' as MoneyType ' );
    END IF;
  end loop;
  IF in_RoomCostType=2 AND v_is_owner=0 THEN
      SET v_sql2 = CONCAT_WS(' ',v_sql2,'UNION ALL SELECT ', fc_get_user_account(in_OwnerId,in_RoomCostMoneyType),' as MoneyNum,'
                                               , in_OwnerId,' as UserID,'
                                               , in_RoomCostMoneyType,' as MoneyType ' );
  ELSEIF in_RoomCostType=3 AND v_is_group=0 THEN
      SET v_sql2 = CONCAT_WS(' ',v_sql2,'UNION ALL SELECT ', fc_get_user_account(v_group_userid,in_RoomCostMoneyType),' as MoneyNum,'
                                               , v_group_userid,' as UserID,'
                                               , in_RoomCostMoneyType,' as MoneyType ' );
  ELSEIF in_RoomCostMoneyType<>in_MoneyType AND in_RoomCostType=2 AND v_is_owner=1 THEN
      SET v_sql2 = CONCAT_WS(' ',v_sql2,'UNION ALL SELECT ', fc_get_user_account(in_OwnerId,in_RoomCostMoneyType),' as MoneyNum,'
                                               , in_OwnerId,' as UserID,'
                                               , in_RoomCostMoneyType,' as MoneyType ' );
  ELSEIF in_RoomCostMoneyType<>in_MoneyType AND in_RoomCostType=3 AND v_is_group=1 THEN
      SET v_sql2 = CONCAT_WS(' ',v_sql2,'UNION ALL SELECT ', fc_get_user_account(v_group_userid,in_RoomCostMoneyType),' as MoneyNum,'
                                               , v_group_userid,' as UserID,'
                                               , in_RoomCostMoneyType,' as MoneyType ' );
  END IF; 
  IF v_sql1<>' ' THEN
  SET v_sql1=substring(v_sql1, 13);
  SET @sql=v_sql1;
  PREPARE s1 from @sql;
  EXECUTE s1;
  DEALLOCATE PREPARE s1;
  END IF;
  IF v_sql2<>' ' THEN
  SET v_sql2=substring(v_sql2, 13);
  SET @sql=v_sql2;
  PREPARE s2 from @sql;
  EXECUTE s2;
  DEALLOCATE PREPARE s2;
  END IF;
  SET returnvalue=1;

END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for GS_SaveGameUserRecordData
-- ----------------------------
DROP PROCEDURE IF EXISTS `GS_SaveGameUserRecordData`;
DELIMITER ;;
CREATE DEFINER=`user76`@`%` PROCEDURE `GS_SaveGameUserRecordData`(IN in_MId VARCHAR(100), IN in_SId VARCHAR(100), IN in_RoomId INT, IN in_GameId INT, IN in_RecPath VARCHAR(100), IN in_RecordType INT, IN in_OwnerId INT, IN in_GroupId INT, IN in_Mark VARCHAR(200), IN in_friendgameid INT, IN in_UserId VARCHAR(500), IN in_MoneyNum VARCHAR(500), IN in_MoneyType VARCHAR(100), OUT returnvalue INT)
BEGIN
  DECLARE v_recordid int ;
  DECLARE v_i int DEFAULT 0;
  DECLARE v_userid int DEFAULT 0;
  DECLARE v_moneynum int DEFAULT 0;
  DECLARE v_moneytype int DEFAULT 0;
  set @@autocommit=off;
  SET returnvalue=-1;
  SELECT re.recordid INTO v_recordid
    FROM order_recorddata re 
    WHERE re.mid=in_MId and re.sid=in_SId;
  IF ISNULL(v_recordid) THEN
     SET v_recordid=fc_nextval('order_recorddata');
  /*--order_recorddata*/
     INSERT INTO order_recorddata(recordid, mid, sid, roomid, gameid, recordtype, ownerid, groupid, addtime, friendgameid)
                          VALUES(v_recordid,in_mid, in_sid, in_roomid, in_gameid, in_recordtype, in_ownerid, in_groupid, SYSDATE(), in_friendgameid);
  END IF;
  /*--order_recorddata_path*/
  INSERT INTO order_recorddata_path(recordid, recpath, mark, addtime)
        VALUES(v_recordid, in_recpath, in_mark,SYSDATE());
  /*--order_recorddata_detail*/
  loop_label:loop
      SET v_i=v_i+1;
      SET v_userid=fc_split_str(in_UserId,';',v_i)+0;
      SET v_moneynum=fc_split_str(in_MoneyNum,';',v_i)+0;
      SET v_moneytype=fc_split_str(in_MoneyType,';',v_i)+0;
      IF ISNULL(v_userid) THEN
           leave loop_label;
      END IF;
      INSERT INTO order_recorddata_detail(recordid, userid, moneynum, moneytype,addtime)
              VALUES(v_recordid,v_userid,v_moneynum,v_moneytype,SYSDATE());
  end loop;
  COMMIT;
  SET returnvalue=1;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for GS_SettlementOne
-- ----------------------------
DROP PROCEDURE IF EXISTS `GS_SettlementOne`;
DELIMITER ;;
CREATE DEFINER=`user76`@`%` PROCEDURE `GS_SettlementOne`(IN in_setid int,IN in_fundtype char(2),IN in_UserId int,IN in_MoneyType int,IN in_MoneyNum int,OUT o_MoneyNum int)
BEGIN
  DECLARE v_rmb double(12,2);
  DECLARE v_diamond double(12,2);
  DECLARE v_gold double(12,2);
  DECLARE v_qidou double(12,2);
  SET o_MoneyNum=in_MoneyNum;
/*结算类型0无1RMB2钻石3金币*/
  /*RMB*/
  IF in_MoneyType=1 THEN
     SELECT ua.rmb INTO v_rmb FROM user_account ua WHERE ua.userid=in_UserId;
     IF v_rmb<ABS(in_MoneyNum) AND in_MoneyNum<0 THEN
        INSERT INTO log_funds_user(userid, accounttype, fundtype,  fundmoney, addtime, relationid,agomoney)
                            VALUES(in_UserId,'RM',in_fundtype,-v_rmb,SYSDATE(),in_setid,v_rmb);
        UPDATE user_account ua SET ua.rmb=0 WHERE ua.userid=in_UserId;
        SET o_MoneyNum=-v_rmb;
     ELSE
        INSERT INTO log_funds_user(userid, accounttype, fundtype,  fundmoney, addtime, relationid,agomoney)
                            VALUES(in_UserId,'RM',in_fundtype,in_MoneyNum,SYSDATE(),in_setid,v_rmb);
        UPDATE user_account ua SET ua.rmb=ua.rmb+in_MoneyNum WHERE ua.userid=in_UserId;
        SET o_MoneyNum=in_MoneyNum;
     END IF;
    /*钻石*/
  ELSEIF in_MoneyType=2 THEN
    SELECT ua.diamond INTO v_diamond FROM user_account ua WHERE ua.userid=in_UserId;
     IF v_diamond<ABS(in_MoneyNum) AND in_MoneyNum<0 THEN
        INSERT INTO log_funds_user(userid, accounttype, fundtype,  fundmoney, addtime, relationid,agomoney)
                            VALUES(in_UserId,'VD',in_fundtype,-v_diamond,SYSDATE(),in_setid,v_diamond);
        UPDATE user_account ua SET ua.diamond=0 WHERE ua.userid=in_UserId;
        SET o_MoneyNum=-v_diamond;
     ELSE
        INSERT INTO log_funds_user(userid, accounttype, fundtype,  fundmoney, addtime, relationid,agomoney)
                            VALUES(in_UserId,'VD',in_fundtype,in_MoneyNum,SYSDATE(),in_setid,v_diamond);
        UPDATE user_account ua SET ua.diamond=ua.diamond+in_MoneyNum WHERE ua.userid=in_UserId;
        SET o_MoneyNum=in_MoneyNum;
     END IF;
  /*金币*/
  ELSEIF in_MoneyType=3 THEN
     SELECT ua.gold INTO v_gold FROM user_account ua WHERE ua.userid=in_UserId;
     IF v_gold<ABS(in_MoneyNum) AND in_MoneyNum<0 THEN
        INSERT INTO log_funds_user(userid, accounttype, fundtype,  fundmoney, addtime, relationid,agomoney)
                            VALUES(in_UserId,'VG',in_fundtype,-v_gold,SYSDATE(),in_setid,v_gold);
        UPDATE user_account ua SET ua.gold=0 WHERE ua.userid=in_UserId;
        SET o_MoneyNum=-v_gold;
     ELSE
        INSERT INTO log_funds_user(userid, accounttype, fundtype,  fundmoney, addtime, relationid,agomoney)
                            VALUES(in_UserId,'VG',in_fundtype,in_MoneyNum,SYSDATE(),in_setid,v_gold);
        UPDATE user_account ua SET ua.gold=ua.gold+in_MoneyNum WHERE ua.userid=in_UserId;
        SET o_MoneyNum=in_MoneyNum;
     END IF;
  /*七豆*/
  ELSEIF in_MoneyType=4 THEN
     SELECT ua.qidou INTO v_qidou FROM user_account ua WHERE ua.userid=in_UserId;
     IF v_qidou<ABS(in_MoneyNum) AND in_MoneyNum<0 THEN
        INSERT INTO log_funds_user(userid, accounttype, fundtype,  fundmoney, addtime, relationid,agomoney)
                            VALUES(in_UserId,'VQ',in_fundtype,-v_qidou,SYSDATE(),in_setid,v_qidou);
        UPDATE user_account ua SET ua.qidou=0 WHERE ua.userid=in_UserId;
        SET o_MoneyNum=-v_qidou;
     ELSE
        INSERT INTO log_funds_user(userid, accounttype, fundtype,  fundmoney, addtime, relationid,agomoney)
                            VALUES(in_UserId,'VQ',in_fundtype,in_MoneyNum,SYSDATE(),in_setid,v_qidou);
        UPDATE user_account ua SET ua.qidou=ua.qidou+in_MoneyNum WHERE ua.userid=in_UserId;
        SET o_MoneyNum=in_MoneyNum;
     END IF;
  END IF;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for NewProc
-- ----------------------------
DROP PROCEDURE IF EXISTS `NewProc`;
DELIMITER ;;
CREATE DEFINER=`user76`@`%` PROCEDURE `NewProc`()
BEGIN
	#Routine body goes here...

END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for sp_admin_agent_transfer
-- ----------------------------
DROP PROCEDURE IF EXISTS `sp_admin_agent_transfer`;
DELIMITER ;;
CREATE DEFINER=`user76`@`%` PROCEDURE `sp_admin_agent_transfer`(IN`in_adminid`int,IN `in_agentid` int,IN `in_diamond` int,IN `in_money` decimal,IN `in_type` int,IN `in_remark` tinytext,OUT p_out varchar(20))
BEGIN
	#管理员划拨给代理或者赠送钻石给代理
	/*
		in_adminid   管理员id
	*	in_agentid 	 代理ID
	*	in_diamond	 增加钻石
	*	in_money		 付款
	*	in_type      类型 1 代理购钻 -1 系统赠送
	*	in_remark    备注
	* p_out			   返回结果
	*/

  DECLARE v_toagentdiamond double(12,2);
	DECLARE v_id varchar(20);
	SET @@autocommit=off;
	SET p_out = "划拨失败";
	IF (SELECT count(ai.agentid) FROM agent_info ai WHERE ai.agentid=in_agentid)=1 THEN
	SELECT CONCAT( DATE_FORMAT(now(),'%y%m%d') ,fc_nextval('general')) into v_id;
  SELECT aa.diamond INTO v_toagentdiamond FROM agent_account aa WHERE aa.agentid=in_agentid;
			IF in_type = 1 THEN 
			INSERT INTO order_transfer(id,auid,  toauid, transfertype, addtime,accounttype,remark,rmb)
									VALUES(v_id,in_adminid,in_agentid,'2',SYSDATE(),'VD',in_remark,in_money);
			INSERT INTO log_funds_agent(agentid, accounttype, fundtype,  fundmoney, addtime, relationid,agomoney)  
									VALUES(in_agentid,'VD','91',in_diamond,SYSDATE(),v_id,v_toagentdiamond);
			INSERT INTO log_funds_admin(adminid,accounttype,fundtype,fundmoney,addtime,relationid)
									VALUES(in_adminid,'VD','91',-in_diamond,SYSDATE(),v_id);
			UPDATE agent_account aa 
									SET aa.diamond = aa.diamond+in_diamond
							WHERE aa.agentid = in_agentid;
			COMMIT;
			SET p_out = "充值成功";
			ELSEIF in_type = -1 THEN
			INSERT INTO order_transfer(id,auid,  toauid, transfertype, addtime,accounttype,remark,rmb)
									VALUES(v_id,in_adminid,in_agentid,'4',SYSDATE(),'VD',in_remark,in_money);
			INSERT INTO log_funds_agent(agentid, accounttype, fundtype,  fundmoney, addtime, relationid,agomoney)
									VALUES(in_agentid,'VD','92',in_diamond,SYSDATE(),v_id,v_toagentdiamond);
			INSERT INTO log_funds_admin(adminid,accounttype,fundtype,fundmoney,addtime,relationid)
									VALUES(in_adminid,'VD','92',-in_diamond,SYSDATE(),v_id);
			UPDATE agent_account aa
									SET aa.diamond = aa.diamond+in_diamond
							WHERE aa.agentid = in_agentid;
			COMMIT;
			SET p_out = "赠送成功";
			ELSE
			SET p_out = "未知错误";
			END IF;
		END IF;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for sp_admin_user_transfer
-- ----------------------------
DROP PROCEDURE IF EXISTS `sp_admin_user_transfer`;
DELIMITER ;;
CREATE DEFINER=`user76`@`%` PROCEDURE `sp_admin_user_transfer`(IN`in_adminid`int,IN `in_userid` int,IN `in_diamond` int,IN `in_money` decimal,IN `in_type` int,IN `in_remark` tinytext,OUT p_out varchar(20))
BEGIN
	#管理员划拨给代理或者赠送钻石给代理
	/*
		in_adminid   管理员id
	*	in_userid 	 代理ID
	*	in_diamond	 增加钻石
	*	in_money		 付款
	*	in_type      类型 1 代理购钻 -1 系统赠送
	*	in_remark    备注
	* p_out			   返回结果
	*/

  DECLARE v_toagentdiamond double(12,2);
	DECLARE v_id varchar(20);
	SET @@autocommit=off;
	SET p_out = "划拨失败";
	IF (SELECT count(ui.userid) FROM user_info ui WHERE ui.userid=in_userid)=1 THEN
	SELECT CONCAT( DATE_FORMAT(now(),'%y%m%d') ,fc_nextval('general')) into v_id;
  SELECT ua.diamond INTO v_toagentdiamond FROM user_account ua WHERE ua.userid=in_userid;
			IF in_type = 1 THEN 
			INSERT INTO order_transfer(id,auid,  toauid, transfertype, addtime,accounttype,remark,rmb)
									VALUES(v_id,in_adminid,in_userid,'1',SYSDATE(),'VD',in_remark,in_money);
			INSERT INTO log_funds_user(userid, accounttype, fundtype,  fundmoney, addtime, relationid,agomoney)  
									VALUES(in_userid,'VD','93',in_diamond,SYSDATE(),v_id,v_toagentdiamond);
			INSERT INTO log_funds_admin(adminid,accounttype,fundtype,fundmoney,addtime,relationid)
									VALUES(in_adminid,'VD','93',-in_diamond,SYSDATE(),v_id);
			UPDATE user_account ua 
									SET ua.diamond = ua.diamond+in_diamond
									WHERE ua.userid = in_userid;
			COMMIT;
			SET p_out = "充值成功";
			ELSEIF in_type = -1 THEN
			INSERT INTO order_transfer(id,auid,  toauid, transfertype, addtime,accounttype,remark,rmb)
									VALUES(v_id,in_adminid,in_userid,'3',SYSDATE(),'VD',in_remark,in_money);
			INSERT INTO log_funds_user(userid, accounttype, fundtype,  fundmoney, addtime, relationid,agomoney)
									VALUES(in_userid,'VD','94',in_diamond,SYSDATE(),v_id,v_toagentdiamond);
			INSERT INTO log_funds_admin(adminid,accounttype,fundtype,fundmoney,addtime,relationid)
									VALUES(in_adminid,'VD','94',-in_diamond,SYSDATE(),v_id);
			UPDATE user_account ua 
									SET ua.diamond = ua.diamond+in_diamond
							WHERE ua.userid = in_userid;
			COMMIT;
			SET p_out = "赠送成功";
			ELSE
			SET p_out = "未知错误";
			END IF;
		END IF;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for sp_agent_add
-- ----------------------------
DROP PROCEDURE IF EXISTS `sp_agent_add`;
DELIMITER ;;
CREATE DEFINER=`user76`@`%` PROCEDURE `sp_agent_add`(in_userid int,
                              in_mobilenum varchar(15), 
                              in_wechatnum varchar(50), 
                              in_wechatname varchar(100),
                              in_pw varchar(50),
                              in_levelid char(1),
                              in_agentname varchar(30),
                              in_parentid int,
                          out p_out varchar(50))
BEGIN
  declare v_id int ;
  set @@autocommit=off;
  if (select count(agentid) from agent_info where mobilenum=trim(in_mobilenum))>=1 then
      set p_out='号码已注册';
  else
      if (select count(agentid) from agent_info where userid=trim(in_userid))>=1 then
          set p_out='游戏ID已绑定';
      else
          set v_id=fc_nextval('agent_info');
          insert into agent_info(agentid,userid,pw,mobilenum,wechatnum,wechatname,addtime,levelid,agentname,parentid)
                          values(v_id,in_userid,in_pw,in_mobilenum,in_wechatnum,in_wechatname,sysdate(),in_levelid,in_agentname,in_parentid);
          insert into agent_account(agentid)
                          values(v_id);
          commit;
          set p_out='注册成功';
      end if;      
  end if;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for sp_agent_log
-- ----------------------------
DROP PROCEDURE IF EXISTS `sp_agent_log`;
DELIMITER ;;
CREATE DEFINER=`user76`@`%` PROCEDURE `sp_agent_log`(IN `in_agentid` int,IN `in_parentid` int,IN `in_type` int,OUT `p_out` int)
BEGIN
	/*
		代理操作日志
		输入：in_agentid 代理ID
					in_parentid 上级代理ID
					in_type 日志类型
		输出  p_out 输出 -1 失败 0 代理不存在 1 成功
					
	*/

	DECLARE v_parentid INT;
	DECLARE v_id INT;
	DECLARE v_remark VARCHAR(30);
	SET @@autocommit=off;
  SET p_out=-1;
	IF(SELECT COUNT(agentid) FROM agent_info WHERE agentid = in_agentid)>0 THEN 
		set v_id=fc_nextval('agent_log');
		IF (1 = in_type) THEN 
			IF(SELECT count(ai.agentid) FROM agent_info ai WHERE ai.agentid=in_parentid ) > 0 THEN
				SET v_remark = CONCAT(in_agentid,'绑定',in_parentid);
				/*添加绑定日志*/
				INSERT INTO agent_log(id,agentid, logtype, addtime,remark)
										VALUES(v_id,in_agentid,in_type,SYSDATE(),v_remark);
				/*更新绑定关系*/
				UPDATE agent_info ai SET ai.parentid = in_parentid WHERE ai.agentid = in_agentid;
			END IF;
		ELSEIF (2 = in_type) THEN
				SELECT ai.parentid INTO v_parentid  FROM agent_info ai WHERE ai.agentid=in_agentid;
				SET v_remark = CONCAT(in_agentid,'解散',v_parentid) ;
				/*添加绑定日志*/
				INSERT INTO agent_log(id,agentid, logtype, addtime,remark)
										VALUES(v_id,in_agentid,in_type,SYSDATE(),v_remark);
				/*解散绑定关系*/
				UPDATE agent_info ai SET ai.parentid = 0 WHERE ai.agentid = in_agentid;

		ELSEIF(3 = in_type) THEN
			SET v_remark = CONCAT(in_agentid,'登录代理系统');
			/*添加绑定日志*/
			INSERT INTO agent_log(id,agentid, logtype, addtime,remark)
                  VALUES(v_id,in_agentid,in_type,SYSDATE(),v_remark);
			/*更新登录时间*/
			UPDATE agent_info ai SET ai.logintime = SYSDATE() WHERE ai.agentid =in_agentid;
		END IF;
		COMMIT;
		set p_out = 1;
	ELSE
      SET p_out=0;
   END IF;

END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for sp_agent_out_cash
-- ----------------------------
DROP PROCEDURE IF EXISTS `sp_agent_out_cash`;
DELIMITER ;;
CREATE DEFINER=`user76`@`%` PROCEDURE `sp_agent_out_cash`(
														IN in_orderid varchar(50),
														IN in_agentid int,
                            IN  in_rmb int,                              
														IN  in_gift int,
														IN in_cashratio double(3,2) ,
														out o_out varchar(50))
BEGIN
  /* 代理提现金
   输入：in_agentid 代理id
         in_rmb RMB  
				in_gift 手续费
				in_cashratio 提现手续费比率 
    输出：o_out  订单号 */
  SET @@autocommit=off;
  SET o_out='-1';
	IF (SELECT aa.rmb FROM agent_account aa WHERE aa.agentid=in_agentid)>=in_rmb + in_gift THEN
		/*插入订单数据*/
		INSERT INTO agent_transfer(  id,  agentid,  auid,  rmb,  diamond,  cashratio,  gift,  cashtype,  status,  addtime)
         VALUES(in_orderid,in_agentid,0,in_rmb,0,in_cashratio,in_gift,'C','0',SYSDATE());
		
		/*修改账户*/
		UPDATE agent_account SET rmb=rmb-in_rmb-in_gift WHERE agentid=in_agentid;
		
		COMMIT;
		set o_out=in_orderid;
	END IF;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for sp_agent_out_cash_update
-- ----------------------------
DROP PROCEDURE IF EXISTS `sp_agent_out_cash_update`;
DELIMITER ;;
CREATE DEFINER=`user76`@`%` PROCEDURE `sp_agent_out_cash_update`(

														IN in_orderid  varchar(50),
                            IN in_agentid int,
														IN in_remark varchar(100),
														IN in_status char(1),
														out o_out int)
BEGIN
  /* 代理提现金
   输入：in_orderid 订单号
         in_agentid 代理id
         in_remark 微信订单号 
         in_status 1成功 2失败
    输出：o_out  -1体现失败 0 无订单号 1成功 */
  DECLARE vo_rmb double(12,2); -- 账户余额
  DECLARE v_rmb double(12,2);-- 支付余额
  DECLARE v_gift double(12,2); -- 支付费率
  SET @@autocommit=off;
  SET o_out=-1;
	
  /* 检查订单是否存在 */
  IF (SELECT COUNT(*) from agent_transfer atr where atr.id=in_orderid and atr.status='0' and atr.agentid=in_agentid)=1 THEN
		SELECT aa.rmb INTO vo_rmb  FROM agent_account aa WHERE aa.agentid=in_agentid;
		SELECT ar.rmb ,ar.gift INTO v_rmb,v_gift FROM agent_transfer ar WHERE ar.id = in_orderid;
    IF  in_status='1' THEN
    /* 插入资金记录 */
      INSERT INTO log_funds_agent(agentid, accounttype, fundtype, fundmoney, addtime, relationid,agomoney)
                       VALUES(in_agentid,'RM','85',-v_rmb-v_gift,sysdate(),in_orderid,vo_rmb+v_rmb+v_gift);

		ELSEIF in_status = '2' THEN
    /* 修改账户 */
      UPDATE agent_account SET rmb=rmb+v_rmb+v_gift WHERE agentid=in_agentid;

    END IF;
    /* 更新订单记录 */
      UPDATE agent_transfer atr
         SET atr.status=in_status,atr.dealtime=sysdate(),atr.remark=in_remark
         WHERE id=in_orderid;
      COMMIT;
      SET o_out=1;
  ELSE
   SET o_out=0;
  END IF;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for sp_agent_out_diamond
-- ----------------------------
DROP PROCEDURE IF EXISTS `sp_agent_out_diamond`;
DELIMITER ;;
CREATE DEFINER=`user76`@`%` PROCEDURE `sp_agent_out_diamond`(IN in_agentid int,IN in_rmb int,IN in_diamond int,IN in_cashratio double(3,2),OUT o_out int)
BEGIN
  /* 代理取现到钻石
   输入：in_agentid 代理id
         in_rmb RMB
         in_diamond 钻石数 
         in_cashratio 进货折扣 
    输出：o_out  -1 失败 0 余额不足 1成功*/
  DECLARE v_agentdiamond double(12,2);
  DECLARE v_agentdrmb double(12,2);
  DECLARE v_id varchar(20);
  SET @@autocommit=off;
  SET o_out=-1;
  SELECT aa.rmb,aa.diamond INTO v_agentdrmb,v_agentdiamond FROM agent_account aa WHERE aa.agentid=in_agentid;
  IF  v_agentdrmb>= in_rmb  THEN
      SELECT DATE_FORMAT(now(6),'%y%m%d%h%i%s%f') into v_id;
           INSERT INTO agent_transfer(id,agentid,  auid, rmb, diamond, cashratio, gift, cashtype, status, addtime)
                  VALUES(v_id,in_agentid,0,in_rmb,in_diamond,in_cashratio,0,'D','1',SYSDATE());
           INSERT INTO log_funds_agent(agentid, accounttype, fundtype,  fundmoney, addtime, relationid,agomoney)
                  VALUES(in_agentid,'RM','83',-in_rmb,SYSDATE(),v_id,v_agentdrmb);
           INSERT INTO log_funds_agent(agentid, accounttype, fundtype,  fundmoney, addtime, relationid,agomoney)
                  VALUES(in_agentid,'VD','83',in_diamond,SYSDATE(),v_id,v_agentdiamond);

           /* 修改账户 */
             UPDATE agent_account aa
                SET aa.diamond=aa.diamond+in_diamond,aa.rmb=aa.rmb-in_rmb
              WHERE aa.agentid=in_agentid;
       COMMIT;
       SET o_out=1;
   ELSE
      SET o_out=0;
   END IF;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for sp_agent_pay
-- ----------------------------
DROP PROCEDURE IF EXISTS `sp_agent_pay`;
DELIMITER ;;
CREATE DEFINER=`user76`@`%` PROCEDURE `sp_agent_pay`(
															in_orderNo varchar(50),
															in_auid int,
                              in_rmb int, 
                              in_vcoin int,
                          out p_out varchar(50))
BEGIN
  
	DECLARE v_userid INT ;
  set @@autocommit=off;
  set p_out='-1';
	SELECT userid INTO v_userid FROM agent_info WHERE agentid = in_auid;
	IF v_userid > 0 THEN
		insert into order_pay(id, auid, accounttype, rmb, vcoin, addtime, userflag, status)
                values(in_orderNo,v_userid,'VD',in_rmb,in_vcoin,sysdate(),'A','0');
		commit;
		set p_out=in_orderNo;
	END IF;
  
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for sp_agent_pay_update
-- ----------------------------
DROP PROCEDURE IF EXISTS `sp_agent_pay_update`;
DELIMITER ;;
CREATE DEFINER=`user76`@`%` PROCEDURE `sp_agent_pay_update`(
                              in_orderid varchar(50),
                              in_status char(1),
                              in_realrmb int,
                              in_remark  varchar(100),
                              in_paytype char(1),
                          out o_out int)
BEGIN
  /* 代理充值
   输入：in_orderid 订单号
         in_realrmb 实际提现金额  
         in_status 1成功 2失败
         in_remark 微信订单号
         in_paytype 0线下支付1微信支付2支付宝
    输出：o_out  -1充值失败 0 无订单号 1成功 */
  declare v_auid int DEFAULT NULL;
  declare v_coin int; 
  DECLARE v_accounttype char(2);
  DECLARE v_diamond double(12,2);
	DECLARE v_userid INT ;
  set @@autocommit=off;
  SET o_out=-1;
  select auid,vcoin,accounttype into v_auid,v_coin,v_accounttype
   from order_pay where id=in_orderid and status='0' and userflag='A';
	SELECT agentid INTO v_userid FROM agent_info WHERE userid = v_auid;
  /* 充钻 */
  IF NOT ISNULL(v_userid) AND v_accounttype='VD' THEN
    IF  in_status='1' THEN
    /* 插入资金记录 */
      SELECT aa.diamond INTO v_diamond FROM agent_account aa WHERE aa.agentid=v_userid;
      insert into log_funds_agent(agentid, accounttype, fundtype, fundmoney, addtime, relationid,agomoney)
                       values(v_userid,'VD','80',v_coin,sysdate(),in_orderid,v_diamond);
    /* 修改账户 */
      update agent_account
         set diamond=diamond+v_coin
       where agentid=v_userid;
    end if;
    /* 更新订单记录 */
      update order_pay
         set status=in_status,paytime=sysdate(),realrmb=in_realrmb,remark=in_remark,paytype=in_paytype
         where id=in_orderid;
      commit;
      set o_out=1;
  else
   set o_out=0;
  end if;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for sp_agent_stat
-- ----------------------------
DROP PROCEDURE IF EXISTS `sp_agent_stat`;
DELIMITER ;;
CREATE DEFINER=`user76`@`%` PROCEDURE `sp_agent_stat`(IN in_dateid varchar(10))
BEGIN
  /*代理统计
    每天运行一次*/
  DELETE FROM agent_stat_day  WHERE dateid=in_dateid;
  INSERT INTO agent_stat_day(agentid, dateid,dayreturn)
       SELECT arl.agentid, in_dateid,SUM(arl.returnrmb) 
         FROM agent_return_log arl
        WHERE arl.addtime>= str_to_date(in_dateid, '%Y-%m-%d')
         AND  arl.addtime<date_add(str_to_date(in_dateid, '%Y-%m-%d'), interval 1 day)
       GROUP BY arl.agentid;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for sp_agent_transfer_agent
-- ----------------------------
DROP PROCEDURE IF EXISTS `sp_agent_transfer_agent`;
DELIMITER ;;
CREATE DEFINER=`user76`@`%` PROCEDURE `sp_agent_transfer_agent`(IN in_agentid int,IN in_to_agentid int,IN in_diamond int,OUT o_out int)
BEGIN
  /* 代理给代理划拨
   输入：in_agentid 代理id
         in_to_agentid 下级代理id
         in_diamond 钻石数  
    输出：o_out  -1 失败 0 代理不存在或代理非下级 1成功*/
  DECLARE v_agentdiamond double(12,2);
  DECLARE v_toagentdiamond double(12,2);
  DECLARE v_id varchar(20);
  SET @@autocommit=off;
  SET o_out=-1;
  IF (SELECT COUNT(ai.agentid)   FROM agent_info ai   WHERE ai.agentid=in_to_agentid AND ai.parentid=in_agentid)=1 THEN
      SELECT CONCAT( DATE_FORMAT(now(),'%y%m%d') ,fc_nextval('general')) into v_id;
      SELECT aa.diamond INTO v_agentdiamond FROM agent_account aa WHERE aa.agentid=in_agentid;
      SELECT aa.diamond INTO v_toagentdiamond FROM agent_account aa WHERE aa.agentid=in_to_agentid;
      IF v_agentdiamond>= in_diamond THEN 
           INSERT INTO agent_transfer(id,agentid,  auid, rmb, diamond, cashratio, gift, cashtype, status, addtime)
                  VALUES(v_id,in_agentid,in_to_agentid,0,in_diamond,0,0,'H','1',SYSDATE());
           INSERT INTO log_funds_agent(agentid, accounttype, fundtype,  fundmoney, addtime, relationid,agomoney)
                  VALUES(in_agentid,'VD','82',-in_diamond,SYSDATE(),v_id,v_agentdiamond);
           INSERT INTO log_funds_agent(agentid, accounttype, fundtype,  fundmoney, addtime, relationid,agomoney)
                  VALUES(in_to_agentid,'VD','82',in_diamond,SYSDATE(),v_id,v_toagentdiamond);

           /* 修改账户 */
             UPDATE agent_account aa
                SET aa.diamond=aa.diamond-in_diamond
              WHERE aa.agentid=in_agentid;
             UPDATE agent_account aa
                SET aa.diamond=aa.diamond+in_diamond
              WHERE aa.agentid=in_to_agentid;

					COMMIT;
					SET o_out=1;
       END IF;  
   ELSE
      SET o_out=0;
   END IF;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for sp_agent_transfer_user
-- ----------------------------
DROP PROCEDURE IF EXISTS `sp_agent_transfer_user`;
DELIMITER ;;
CREATE DEFINER=`user76`@`%` PROCEDURE `sp_agent_transfer_user`(IN in_agentid int,IN in_userid int,IN in_rmb int,IN in_diamond int,IN in_gift int,OUT o_out int)
BEGIN
  /* 代理给玩家充钻石
   输入：in_agentid 代理id
         in_userid 玩家id
         in_rmb RMB 
         in_diamond 钻石数 
         in_gift 送多少钻石 
    输出：o_out  -1 失败 0 玩家不存在或玩家非代理下级 1成功*/
  DECLARE v_agentdiamond double(12,2);
  DECLARE v_userdiamond double(12,2);
  DECLARE v_id varchar(20);
  SET @@autocommit=off;
  SET o_out=-1;
  IF (SELECT COUNT(ui.userid)   FROM user_info ui   WHERE ui.userid=in_userid AND ui.agentid=in_agentid)=1 THEN
      SELECT CONCAT( DATE_FORMAT(now(),'%y%m%d') ,fc_nextval('general')) into v_id;
      SELECT aa.diamond INTO v_agentdiamond FROM agent_account aa WHERE aa.agentid=in_agentid;
      SELECT ua.diamond INTO v_userdiamond FROM user_account ua WHERE ua.userid=in_userid;
      IF v_agentdiamond>=in_diamond+in_gift THEN 
           INSERT INTO agent_transfer(id,agentid,  auid, rmb, diamond, cashratio, gift, cashtype, status, addtime)
                  VALUES(v_id,in_agentid,in_userid,in_rmb,in_diamond,0,in_gift,'U',1,SYSDATE());
           INSERT INTO log_funds_agent(agentid, accounttype, fundtype,  fundmoney, addtime, relationid,agomoney)
                  VALUES(in_agentid,'VD','81',-in_diamond-in_gift,SYSDATE(),v_id,v_agentdiamond);
           INSERT INTO log_funds_user(userid, accounttype, fundtype, fundmoney, addtime, relationid,agomoney)
                  VALUES(in_userid,'VD','22',in_diamond+in_gift,SYSDATE(),v_id,v_userdiamond);
           /* 修改账户 */
             UPDATE agent_account aa
                SET aa.diamond=aa.diamond-in_diamond-in_gift
              WHERE aa.agentid=in_agentid;
             UPDATE user_account ua
                SET ua.diamond=ua.diamond+in_diamond+in_gift
              WHERE ua.userid=in_userid;
            COMMIT;
           SET o_out=1;
       ELSE
        SET o_out=-1;
       END IF;    
   ELSE
      SET o_out=0;
   END IF;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for sp_friend_stat
-- ----------------------------
DROP PROCEDURE IF EXISTS `sp_friend_stat`;
DELIMITER ;;
CREATE DEFINER=`user76`@`%` PROCEDURE `sp_friend_stat`(IN in_dateid varchar(10))
BEGIN
  /*亲友圈统计
    每天运行一次*/
  DECLARE v_groupid int;
  DECLARE v_gameid int;
  DECLARE v_cnt int;
  DECLARE v_amt int;
  DECLARE done int default 0;
  DECLARE friendCur CURSOR FOR
    SELECT os.groupid,os.gameid,COUNT(setid) AS cnt,SUM(os.RoomCost*os.FeeUserCount) AS amt
      FROM order_settlement os
      WHERE os.groupid>0
        AND os.RoomCostType=2
        AND os.addtime>= str_to_date(in_dateid, '%Y-%m-%d')
        AND os.addtime<date_add(str_to_date(in_dateid, '%Y-%m-%d'), interval 1 day)
     GROUP BY os.groupid,os.gameid;
  DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = 1;
  DELETE FROM friend_stat_day  WHERE dateid=in_dateid;
  OPEN friendCur;
  REPEAT
    FETCH friendCur INTO v_groupid,v_gameid,v_cnt,v_amt;
    IF NOT done THEN
       INSERT INTO friend_stat_day(friendid,  gameid ,  dateid,  roomcnt,  roomamt)
           VALUES(v_groupid,v_gameid,in_dateid,v_cnt,v_amt);
       UPDATE friend_game fg
          SET fg.totalcnt=fg.totalcnt+v_cnt,fg.totalamt=fg.totalamt+v_amt
         WHERE fg.friendid=v_groupid 
           AND fg.gameid=v_gameid;
    END IF;
  UNTIL done END REPEAT;
  CLOSE friendCur;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for sp_get_user_moneybag
-- ----------------------------
DROP PROCEDURE IF EXISTS `sp_get_user_moneybag`;
DELIMITER ;;
CREATE DEFINER=`user76`@`%` PROCEDURE `sp_get_user_moneybag`(in _UserID int)
BEGIN
DECLARE __rmb INT DEFAULT 0;
DECLARE __gold INT DEFAULT 0;
DECLARE __diamond INT DEFAULT 0;
DECLARE __qidou INT DEFAULT 0;




SELECT
	user_account.rmb,
	user_account.diamond,
	user_account.gold,
	user_account.qidou INTO __rmb,
	__diamond,
	__gold,
	__qidou
FROM
	`user_account`
WHERE
	user_account.userid = `_UserID`
LIMIT 1;


SELECT 1 as MoneyType ,__rmb as MoneyNum
union all select  2,__diamond
union all select  3,__gold
union all select  4,__qidou;


END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for sp_log_fund_user
-- ----------------------------
DROP PROCEDURE IF EXISTS `sp_log_fund_user`;
DELIMITER ;;
CREATE DEFINER=`user76`@`%` PROCEDURE `sp_log_fund_user`(IN in_relationid varchar(20), IN in_user int, IN in_amt double(12, 2), IN in_accounttype char(2), IN in_fundtype char(2))
BEGIN
  /* 用户添加资金记录
   输入：in_relationid 关联订单号
         in_user 用户  
         in_amt 充值数
         in_accounttype 账户类型
         in_fundtype 资金类型*/
  DECLARE v_diamond double(12,2);
  DECLARE v_gold double(12,2);
  DECLARE v_qidou double(12,2);
       IF in_amt>0 AND in_accounttype='VD' THEN
        /* 插入资金记录 */
          SELECT ua.diamond INTO v_diamond FROM user_account ua  WHERE ua.userid=in_user;
          insert into log_funds_user(userid, accounttype, fundtype, fundmoney, addtime, relationid, agomoney)
                       values(in_user,in_accounttype,in_fundtype,in_amt,SYSDATE(),in_relationid,v_diamond);
        /* 修改账户 */
          update user_account ua
             set ua.diamond=ua.diamond+in_amt
           where ua.userid=in_user;
       ELSEIF in_amt>0 AND in_accounttype='VG' THEN
        /* 插入资金记录 */
          SELECT ua.gold INTO v_gold FROM user_account ua  WHERE ua.userid=in_user;
          insert into log_funds_user(userid, accounttype, fundtype, fundmoney, addtime, relationid, agomoney)
                       values(in_user,in_accounttype,in_fundtype,in_amt,SYSDATE(),in_relationid,v_gold);
        /* 修改账户 */
          update user_account ua
             set ua.gold=ua.gold+in_amt
           where ua.userid=in_user;
       ELSEIF in_amt>0 AND in_accounttype='VQ' THEN
        /* 插入资金记录 */
          SELECT ua.qidou INTO v_qidou FROM user_account ua  WHERE ua.userid=in_user;
          insert into log_funds_user(userid, accounttype, fundtype, fundmoney, addtime, relationid, agomoney)
                       values(in_user,in_accounttype,in_fundtype,in_amt,SYSDATE(),in_relationid,v_qidou);
        /* 修改账户 */
          update user_account ua
             set ua.qidou=ua.qidou+in_amt
           where ua.userid=in_user;
       END IF;
    
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for sp_msg_content_get
-- ----------------------------
DROP PROCEDURE IF EXISTS `sp_msg_content_get`;
DELIMITER ;;
CREATE DEFINER=`user76`@`%` PROCEDURE `sp_msg_content_get`(
                              IN in_msgobject char(1) ,IN in_objectid int,OUT returnvalue int)
BEGIN
	#用户和代理获取消息
	/*
		in_msgobject  A代理U用户
	*	in_objectid 	userid或者agentid

	* returnvalue	  返回结果-1 失败 1成功
	*/
	SET returnvalue = -1;
  IF in_msgobject='U' THEN
    INSERT INTO msg_content_agent( msgid, agentid, addtime,title,content,status)
               SELECT mc.id,in_objectid,SYSDATE(),mc.title,mc.content,'0'
                FROM msg_content mc
                WHERE mc.msgstatus='1'
                  AND mc.msgobject='U'
                  AND mc.begintime<=SYSDATE()
                  AND mc.endtime>=SYSDATE()
                  AND NOT EXISTS(SELECT mca.id FROM msg_content_agent mca WHERE mca.msgid=mc.id AND mca.agentid=in_objectid);
     COMMIT; 
     SELECT mca.id,mca.addtime,mca.title,mca.content,mca.status AS opstatus,mca.opentime AS optime
       FROM msg_content_agent mca 
      WHERE mca.agentid=in_objectid
        ORDER BY mca.addtime DESC;
  ELSEIF  in_msgobject='A' THEN
    INSERT INTO msg_content_user( msgid, userid, addtime,title,content,status)
               SELECT mc.id,in_objectid,SYSDATE(),mc.title,mc.content,'0'
                FROM msg_content mc
                WHERE mc.msgstatus='1'
                  AND mc.msgobject='A'
                  AND mc.begintime<=SYSDATE()
                  AND mc.endtime>=SYSDATE()
                  AND NOT EXISTS(SELECT mcu.id FROM msg_content_user mcu WHERE mcu.msgid=mc.id AND mcu.userid=in_objectid);
    COMMIT;
    SELECT mcu.id,mcu.addtime,mcu.title,mcu.content,mcu.status AS opstatus,mcu.opentime AS optime
       FROM msg_content_user mcu 
      WHERE mcu.userid=in_objectid
        ORDER BY mcu.addtime DESC;
  END IF;
  SET returnvalue = 1;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for sp_msg_content_put
-- ----------------------------
DROP PROCEDURE IF EXISTS `sp_msg_content_put`;
DELIMITER ;;
CREATE DEFINER=`user76`@`%` PROCEDURE `sp_msg_content_put`(
                              IN in_msgobject char(1) ,IN in_objectid int,IN in_msgid int,OUT returnvalue int)
BEGIN
	#用户和代理查看消息后，消息已读
	/*
		in_msgobject  A代理U用户
	*	in_objectid 	userid或者agentid
    in_msgid      消息ID
	* returnvalue	  返回结果-1 失败 1成功
	*/
	SET returnvalue = -1;
  IF in_msgobject='U' THEN
     UPDATE msg_content_user mcu
        SET mcu.status='1',mcu.opentime=SYSDATE()
     WHERE mcu.id=in_objectid;
  ELSEIF  in_msgobject='A' THEN
     UPDATE msg_content_agent mca
        SET mca.status='1',mca.opentime=SYSDATE()
     WHERE mca.id=in_objectid;
  END IF;
  COMMIT;
  SET returnvalue = 1;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for sp_run_daily
-- ----------------------------
DROP PROCEDURE IF EXISTS `sp_run_daily`;
DELIMITER ;;
CREATE DEFINER=`user76`@`%` PROCEDURE `sp_run_daily`()
BEGIN
   DECLARE v_dateid varchar(10);
   DECLARE v_begintime datetime;
   SELECT sysdate() INTO v_begintime;
   SELECT date_format(date_sub(sysdate(),interval 1 day), '%Y-%m-%d') INTO v_dateid;
  /*调用存储过程*/
   call sp_user_stat(v_dateid);
   call sp_agent_stat(v_dateid);
   call sp_friend_stat(v_dateid);
  /*插入日志*/
   INSERT INTO log_run(runname ,  begindate ,  enddate ,  remark )
         values('STAT',v_begintime,sysdate(),'sp_user_stat,sp_agent_stat,sp_friend_stat');
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for sp_user_add
-- ----------------------------
DROP PROCEDURE IF EXISTS `sp_user_add`;
DELIMITER ;;
CREATE DEFINER=`user76`@`%` PROCEDURE `sp_user_add`(IN `in_name` varchar(50),IN `in_sex` int,IN `in_agentid` int,IN `in_picpath` varchar(500),IN `in_unionid` varchar(200),IN `in_openid` varchar(200),OUT `p_out` int)
BEGIN
	/*
		输入：
					in_name :名称
					in_sex :性别
					in_agentid:上级代理Id
					in_picpath:头像路径
					in_unionid:unionid
					in_openid: openid
	输出 
			p_out : -1 失败 0 代理有误,或者unionid ,openid 存在 1 成功

	*/

	DECLARE v_refereeid INT DEFAULT 0;

	DECLARE v_id INT;

	SET @@autocommit = off;

	SET p_out =-1;

	IF (SELECT COUNT(userid) from agent_info WHERE agentid = in_agentid)>0 OR in_agentid = 76 THEN

			SELECT userid INTO v_refereeid from agent_info WHERE agentid = in_agentid;

			SET v_id = fc_nextval('user_info');

			-- 添加玩家账户
			IF in_agentid =76 THEN

				INSERT INTO `user_info` ( `userid`, `useraccount`, `nickname`, gender, `addtime`, `status`,refereeid,agentid,picfile)

						VALUES ( v_id, ( CONCAT( 'u_', v_id ) ), in_name, in_sex, NOW(),1,v_refereeid,0 ,in_picpath);
			ELSE
				INSERT INTO `user_info` ( `userid`, `useraccount`, `nickname`, gender, `addtime`, `status`,refereeid,agentid,picfile)

						VALUES ( v_id, ( CONCAT( 'u_', v_id ) ), in_name, in_sex, NOW(),1,v_refereeid,in_agentid ,in_picpath);
			END IF;
			

			-- 插入玩家账务信息表
			INSERT INTO `user_account` ( `userid`, `rmb`, `diamond`, `gold`, `qidou`, `grift` )

						VALUES ( v_id, 0.00, 100, 0, 100, 0.00);

			-- 更新玩家unionid openid 
			INSERT INTO  user_snsinfo (unionId,openId,snsId,userid) 
						
						VALUES (in_unionid,in_openid,1,v_id);

			COMMIT;

			SET p_out = 1;

	ELSE

		SET p_out = 0;

	END IF;

END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for sp_user_bind_change
-- ----------------------------
DROP PROCEDURE IF EXISTS `sp_user_bind_change`;
DELIMITER ;;
CREATE DEFINER=`user76`@`%` PROCEDURE `sp_user_bind_change`(IN `in_userid` int,IN `in_agentid` int,OUT `p_out` varchar(20))
BEGIN
	DECLARE v_agentid INT;
	SET @@autocommit=off;
	IF in_agentid = 0 THEN 
		UPDATE user_info SET agentid = 0 WHERE userid = in_userid;
		INSERT user_log(userid,logtype,addtime,remark) VALUE(in_userid,1,SYSDATE(),'更改绑定关系');
		COMMIT;
		SET p_out='修改代理成功';
	ELSE
			IF(SELECT count(agentid) FROM agent_info WHERE userid = in_agentid)<1 THEN
				SET p_out = '该代理不存在';
			ELSE
					IF((SELECT agentid FROM user_info WHERE userid = in_userid)=(SELECT agentid FROM agent_info WHERE userid = in_agentid)) THEN
						SET p_out = '请输入新的代理ID';
					ELSE
						SELECT agentid into v_agentid from agent_info WHERE userid = in_agentid;
						UPDATE user_info SET agentid = v_agentid WHERE userid = in_userid;
						INSERT user_log(userid,logtype,addtime,remark) VALUE(in_userid,1,SYSDATE(),'更改绑定关系');
						COMMIT;
						SET p_out='修改代理成功';
					END IF;
			END IF;
	END IF;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for sp_user_log
-- ----------------------------
DROP PROCEDURE IF EXISTS `sp_user_log`;
DELIMITER ;;
CREATE DEFINER=`user76`@`%` PROCEDURE `sp_user_log`(IN `in_userid` int,IN `in_agentid` int,IN `in_type` int,OUT `p_out` int)
BEGIN
	/*
		玩家操作日志
		输入：in_userid 玩家ID
					in_agentid 代理ID
					in_type 日志类型
		输出  p_out 输出 -1 失败 0 玩家不存在 1 成功
					
	*/

	DECLARE v_parentid INT;
	DECLARE v_id INT;
	DECLARE v_remark VARCHAR(30);
	SET @@autocommit=off;
  SET p_out=-1;
	IF(SELECT COUNT(userid) FROM user_info WHERE userid = in_userid)>0 THEN 
		set v_id=fc_nextval('user_log');
		IF (1 = in_type) THEN 
			IF(SELECT count(ai.agentid) FROM agent_info ai WHERE ai.agentid=in_agentid ) > 0 THEN
				SET v_remark = CONCAT(in_userid,'绑定',in_agentid);
				/*添加绑定日志*/
				INSERT INTO user_log(id,userid, logtype, addtime,remark)
										VALUES(v_id,in_userid,in_type,SYSDATE(),v_remark);
				/*更新绑定关系*/
				UPDATE user_info ui SET ui.agentid = in_agentid WHERE ui.userid = in_userid;
			END IF;
		ELSEIF (2 = in_type) THEN
				SELECT ui.agentid INTO v_parentid  FROM user_info ui WHERE ui.userid=in_userid;
				SET v_remark = CONCAT(in_userid,'解散',v_parentid) ;
				/*添加绑定日志*/
				INSERT INTO user_log(id,userid, logtype, addtime,remark)
										VALUES(v_id,in_userid,in_type,SYSDATE(),v_remark);
				/*解散绑定关系*/
				/*UPDATE agent_info ai SET ai.parentid = 0 WHERE ai.agentid = in_agentid;*/
				UPDATE user_info ui SET ui.agentid = 0 WHERE ui.userid = in_userid;

		ELSEIF(3 = in_type) THEN
			SET v_remark = CONCAT(in_userid,'登录代理系统');
			/*添加绑定日志*/
			INSERT INTO user_log(id,userid, logtype, addtime,remark)
                  VALUES(v_id,in_userid,in_type,SYSDATE(),v_remark);
			/*更新登录时间*/
			UPDATE user_info ui SET ui.logintime = SYSDATE() WHERE ui.userid =in_userid;
		END IF;
		COMMIT;
		set p_out = 1;
	ELSE
      SET p_out=0;
   END IF;

END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for sp_user_pay
-- ----------------------------
DROP PROCEDURE IF EXISTS `sp_user_pay`;
DELIMITER ;;
CREATE DEFINER=`user76`@`%` PROCEDURE `sp_user_pay`(IN in_userid int,IN in_rmb int,IN in_vcoin int, IN in_gift double(12,2), IN in_accounttype char(2),IN in_gifttype char(2),out o_out varchar(20))
BEGIN
  /* 玩家充值下单
   输入：in_userid 玩家id
         in_rmb  支付金额
         in_vcoin 钻石数量
         in_gift 送数量
         in_accounttype 充值账户类型VD 钻石 VG金币 VQ 七乐币
         in_gifttype 送账户类型VD 钻石 VG金币 VQ 七乐币
    输出：o_out  订单号 ‘ ‘ 下单失败 */
     /*Unknown = 0,
        RMB = 1,
        Diamond = 2,
        Gold = 3,
        QiDou = 4,
        MatchScore = 10*/
  DECLARE v_id varchar(20);
  SET @@autocommit=off;
  SET o_out=' ';
  SELECT CONCAT( DATE_FORMAT(now(),'%y%m%d') ,fc_nextval('general')) INTO v_id;
  IF in_accounttype='VD' THEN
      INSERT INTO order_pay(id, auid, accounttype, rmb, vcoin, gift, addtime, userflag, status,gifttype)
                VALUES(v_id,in_userid,in_accounttype,in_rmb,in_vcoin,in_gift,now(),'U','0',in_gifttype);
  END IF;
  commit;
  set o_out=v_id;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for sp_user_pay_return
-- ----------------------------
DROP PROCEDURE IF EXISTS `sp_user_pay_return`;
DELIMITER ;;
CREATE DEFINER=`user76`@`%` PROCEDURE `sp_user_pay_return`(
                             IN in_orderid varchar(50),
                             IN in_userid int,
                             IN in_realrmb DOUBLE(10,2))
lable :
BEGIN
  /* 用户充值，代理返佣
   输入：in_orderid 订单号
         in_realrmb 实际充值金额  
         in_userid 用户id
     */
  DECLARE v_agentid1 int ;
  DECLARE v_agentid2 int ;
  DECLARE v_agentid3 int ;
  DECLARE v_status1 char(1) DEFAULT 0;
  DECLARE v_status2 char(1) DEFAULT 0;
  DECLARE v_status3 char(1) DEFAULT 0;
  DECLARE v_discount1 double(4,3)  DEFAULT 0;
  DECLARE v_discount2 double(4,3)  DEFAULT 0;
  DECLARE v_discount3 double(4,3)  DEFAULT 0;
  DECLARE v_agentlevel1 char(1);
  DECLARE v_agentlevel2 char(1);
  DECLARE v_agentlevel3 char(1);
  DECLARE v_returnrmb1 double(10,2)  DEFAULT 0;
  DECLARE v_returnrmb2 double(10,2)  DEFAULT 0;
  DECLARE v_returnrmb3 double(10,2)  DEFAULT 0;
  DECLARE v_rmb1 double(10,2)  DEFAULT 0;
  DECLARE v_rmb2 double(10,2)  DEFAULT 0;
  DECLARE v_rmb3 double(10,2)  DEFAULT 0;
  DECLARE v_returnflag int DEFAULT 0;
  /*SET@@autocommit=off;*/
  /*SET o_out=-1;*/
  /***************************************一级***************************************/
  /* 查询上级代理 */
  SELECT ui.agentid INTO v_agentid1 FROM user_info ui WHERE ui.userid=in_userid;
  SELECT ai.status ,CASE WHEN ai.discount=0  THEN al.discount ELSE ai.discount END ,ai.levelid
    INTO v_status1,v_discount1,v_agentlevel1
    FROM agent_info ai,agent_level al 
   WHERE ai.levelid=al.levelid
     AND ai.agentid=v_agentid1;
  /* 一级返佣 */
  IF v_status1='1'  THEN
    SET v_returnrmb1=in_realrmb*v_discount1;
    /* 插入返佣记录 */
      INSERT INTO agent_return_log(agentid,agentlevel,userid,paynum,returnrmb,returnratio,relationid,returnlevel,addtime)
                  VALUES(v_agentid1,v_agentlevel1,in_userid,in_realrmb,v_returnrmb1,v_discount1,in_orderid,1,NOW());
      SELECT aa.rmb INTO v_rmb1 FROM agent_account aa  WHERE aa.agentid=v_agentid1;
      INSERT INTO log_funds_agent(agentid, accounttype, fundtype, fundmoney, addtime, relationid, agomoney)
                       VALUES(v_agentid1,'RM','86',v_returnrmb1,now(),in_orderid,v_rmb1);
    /* 修改账户 */
      update agent_account aa
         set aa.rmb=aa.rmb+v_returnrmb1
       where aa.agentid=v_agentid1;
  ELSEIF ISNULL(v_status1)  THEN
   /*SET o_out=0;*/
   LEAVE lable ;
  END if;
 /***************************************一级***************************************/
  SET v_returnflag=0;
 /***************************************二级***************************************/
  /* 查询上级代理 */
  SELECT ai.parentid INTO v_agentid2 FROM agent_info ai WHERE ai.agentid=v_agentid1;
  SELECT ai.status ,ai.levelid,al.discount
    INTO v_status2,v_agentlevel2,v_discount2
     FROM agent_info ai,agent_level al 
   WHERE ai.levelid=al.levelid
     AND ai.agentid=v_agentid2;
  /* 二级返佣 */
  IF v_status2='1'  THEN
    IF v_agentlevel1='4' THEN
      IF v_agentlevel1=v_agentlevel2  THEN
         SET v_discount2=fc_get_sysconfig('AGENT_RETURN_6_6')+0;
         SET v_returnflag=1;
      ELSEIF v_agentlevel1>v_agentlevel2  THEN 
         SET v_discount2=v_discount2-v_discount1;
      END IF;
    ELSE
      IF v_agentlevel1=v_agentlevel2 THEN
         SET v_discount2=fc_get_sysconfig('AGENT_RETURN_0_0')+0;
      /*ELSEIF v_agentlevel1<v_agentlevel2  THEN 
         SET v_discount2=fc_get_sysconfig('AGENT_RETURN_0_0')+0; */
         SET v_returnflag=1;
      ELSE
         SET v_discount2=v_discount2-v_discount1;
      END IF;
     END IF;

    SET v_returnrmb2=in_realrmb*v_discount2;
    /* 插入返佣记录 */
      INSERT INTO agent_return_log(agentid,agentlevel,userid,paynum,returnrmb,returnratio,relationid,returnlevel,addtime)
                  VALUES(v_agentid2,v_agentlevel2,in_userid,in_realrmb,v_returnrmb2,v_discount2,in_orderid,2,NOW());
      SELECT aa.rmb INTO v_rmb2 FROM agent_account aa  WHERE aa.agentid=v_agentid2;
      INSERT INTO log_funds_agent(agentid, accounttype, fundtype, fundmoney, addtime, relationid, agomoney)
                       VALUES(v_agentid2,'RM','86',v_returnrmb2,now(),in_orderid,v_rmb2);
    /* 修改账户 */
      update agent_account aa
         set aa.rmb=aa.rmb+v_returnrmb2
       where aa.agentid=v_agentid2;
      IF v_returnflag=1 THEN
         LEAVE lable ;
      END IF;
  ELSEIF ISNULL(v_status2)  THEN
   LEAVE lable ;
  END if;
 /***************************************二级***************************************/
  SET v_returnflag=0;
/***************************************三级***************************************/
  /* 查询上级代理 */
  SELECT ai.parentid INTO v_agentid3 FROM agent_info ai WHERE ai.agentid=v_agentid2;
  SELECT ai.status ,ai.levelid,al.discount
    INTO v_status3,v_agentlevel3,v_discount3
     FROM agent_info ai,agent_level al 
   WHERE ai.levelid=al.levelid
     AND ai.agentid=v_agentid3;
  /* 一级返佣 */
  IF v_status3='1'  THEN
    IF v_agentlevel2='4' THEN
      IF v_agentlevel2=v_agentlevel3  THEN
         SET v_discount3=fc_get_sysconfig('AGENT_RETURN_6_6')+0;
         SET v_returnflag=1;
      ELSEIF v_agentlevel2>v_agentlevel3  THEN 
         SET v_discount3=v_discount3-v_discount2;
      END IF;
    ELSE
      IF v_agentlevel2=v_agentlevel3 THEN
         SET v_discount3=fc_get_sysconfig('AGENT_RETURN_0_0')+0;
      /*ELSEIF v_agentlevel2<v_agentlevel3  THEN 
         SET v_discount3=fc_get_sysconfig('AGENT_RETURN_0_0')+0;*/
         SET v_returnflag=1;
      ELSE
         SET v_discount3=fc_get_sysconfig('AGENT_RETURN3')+0;
      END IF;
     END IF;
    SET v_returnrmb3=in_realrmb*v_discount3;
    /* 插入返佣记录 */
      INSERT INTO agent_return_log(agentid,agentlevel,userid,paynum,returnrmb,returnratio,relationid,returnlevel,addtime)
                  VALUES(v_agentid3,v_agentlevel3,in_userid,in_realrmb,v_returnrmb3,v_discount3,in_orderid,3,NOW());
      SELECT aa.rmb INTO v_rmb3 FROM agent_account aa  WHERE aa.agentid=v_agentid3;
      INSERT INTO log_funds_agent(agentid, accounttype, fundtype, fundmoney, addtime, relationid, agomoney)
                       VALUES(v_agentid3,'RM','86',v_returnrmb3,now(),in_orderid,v_rmb3);
    /* 修改账户 */
      update agent_account aa
         set aa.rmb=aa.rmb+v_returnrmb3
       where aa.agentid=v_agentid3;
      IF v_returnflag=1 THEN
         LEAVE lable ;
      END IF;
  ELSEIF ISNULL(v_status3)  THEN
   LEAVE lable ;
  END if;
  /*SET o_out=1;*/
 /***************************************三级***************************************/
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for sp_user_pay_update
-- ----------------------------
DROP PROCEDURE IF EXISTS `sp_user_pay_update`;
DELIMITER ;;
CREATE DEFINER=`user76`@`%` PROCEDURE `sp_user_pay_update`(
                              in_orderid varchar(50),
                              in_status char(1),
                              in_realrmb int,
                              in_paytype char(1),
                              in_remark  varchar(100),
                              in_returnflage char(1),
                          out o_out int)
BEGIN
  /* 代理充值
   输入：in_orderid 订单号
         in_realrmb 实际提现金额  
         in_status 1成功 2失败
         in_remark 微信订单号
         in_paytype 0线下支付1微信支付2支付宝
    输出：o_out  -1充值失败 0 无订单号 1成功 */
  declare v_auid int DEFAULT NULL;
  declare v_coin int; 
  DECLARE v_accounttype char(2);
  DECLARE v_diamond double(12,2);
	DECLARE v_userid INT ;
  set @@autocommit=off;
  SET o_out=-1;
  select auid,vcoin,accounttype into v_auid,v_coin,v_accounttype
   from order_pay where id=in_orderid and status='0' and userflag='A';
	SELECT agentid INTO v_userid FROM agent_info WHERE userid = in_auid;
  /* 充钻 */
  IF NOT ISNULL(v_userid) AND v_accounttype='VD' THEN
    IF  in_status='1' THEN
    /* 插入资金记录 */
      SELECT aa.diamond INTO v_diamond FROM agent_account aa WHERE aa.agentid=v_auid;
      insert into log_funds_agent(agentid, accounttype, fundtype, fundmoney, addtime, relationid,agomoney)
                       values(v_userid,'VD','80',v_coin,sysdate(),in_orderid,v_diamond);
    /* 修改账户 */
      update agent_account
         set diamond=diamond+v_coin
       where agentid=v_userid;
    end if;
    /* 更新订单记录 */
      update order_pay
         set status=in_status,paytime=sysdate(),realrmb=in_realrmb,remark=in_remark,paytype=in_paytype
         where id=in_orderid;
      commit;
      set o_out=1;
  else
   set o_out=0;
  end if;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for sp_user_pay_vd
-- ----------------------------
DROP PROCEDURE IF EXISTS `sp_user_pay_vd`;
DELIMITER ;;
CREATE DEFINER=`user76`@`%` PROCEDURE `sp_user_pay_vd`(
                              in_orderid varchar(50),
                              in_user int,
                              in_diamond double(12,2),
                              in_gift double(12,2),
                              in_gifttype char(2)
                             )
BEGIN
  /* 用户充值钻石
   输入：in_orderid 订单号
         in_user 用户  
         in_diamond 充值钻石数
         in_gift 送的数量
         in_gifttype 送账户类型 */
  DECLARE v_diamond double(12,2);
  DECLARE v_gold double(12,2);
  DECLARE v_qidou double(12,2);
  /*充*/
    /* 插入资金记录 */
      SELECT ua.diamond INTO v_diamond FROM user_account ua  WHERE ua.userid=in_user;
      insert into log_funds_user(userid, accounttype, fundtype, fundmoney, addtime, relationid, agomoney)
                       values(in_user,'VD','23',in_diamond,now(),in_orderid,v_diamond);
    /* 修改账户 */
      update user_account ua
         set ua.diamond=ua.diamond+in_diamond
       where ua.userid=in_user;
  /*送*/
       IF in_gift>0 AND in_gifttype='VD' THEN
        /* 插入资金记录 */
          SELECT ua.diamond INTO v_diamond FROM user_account ua  WHERE ua.userid=in_user;
          insert into log_funds_user(userid, accounttype, fundtype, fundmoney, addtime, relationid, agomoney)
                       values(in_user,in_gifttype,'24',in_gift,now(),in_orderid,v_diamond);
        /* 修改账户 */
          update user_account ua
             set ua.diamond=ua.diamond+in_gift
           where ua.userid=in_user;
       ELSEIF in_gift>0 AND in_gifttype='VG' THEN
        /* 插入资金记录 */
          SELECT ua.gold INTO v_gold FROM user_account ua  WHERE ua.userid=in_user;
          insert into log_funds_user(userid, accounttype, fundtype, fundmoney, addtime, relationid, agomoney)
                       values(in_user,in_gifttype,'24',in_gift,now(),in_orderid,v_gold);
        /* 修改账户 */
          update user_account ua
             set ua.gold=ua.gold+in_gift
           where ua.userid=in_user;
       ELSEIF in_gift>0 AND in_gifttype='VQ' THEN
        /* 插入资金记录 */
          SELECT ua.qidou INTO v_qidou FROM user_account ua  WHERE ua.userid=in_user;
          insert into log_funds_user(userid, accounttype, fundtype, fundmoney, addtime, relationid, agomoney)
                       values(in_user,in_gifttype,'24',in_gift,now(),in_orderid,v_qidou);
        /* 修改账户 */
          update user_account ua
             set ua.qidou=ua.qidou+in_gift
           where ua.userid=in_user;
       END IF;
    
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for sp_user_stat
-- ----------------------------
DROP PROCEDURE IF EXISTS `sp_user_stat`;
DELIMITER ;;
CREATE DEFINER=`user76`@`%` PROCEDURE `sp_user_stat`(IN in_dateid varchar(10))
BEGIN
  /*玩家统计
    每天运行一次*/
  DECLARE v_userid int;
  DECLARE v_gameid int;
  DECLARE v_cnt int;
  /*DECLARE v_roomamt int;
  DECLARE v_totalamt int;*/
  DECLARE done int default 0;
  DECLARE v_n int;
   /*,SUM(CASE WHEN os.RoomCostType='1' THEN os.RoomCost 
                                                              WHEN os.RoomCostType='2' AND os.ownerid=osd.userid THEN os.RoomCost*os.FeeUserCount
                                                              WHEN os.RoomCostType='3' AND os.groupid=osd.userid THEN os.RoomCost*os.FeeUserCount
                                                              ELSE 0 
                                                          END) AS roomamt,
          SUM(osd.moneynum) AS totalamt */
  DECLARE userCur CURSOR FOR
    SELECT osd.userid,os.gameid,SUM(os.gamenum) AS cnt
      FROM order_settlement os,order_settlement_detail osd 
      WHERE os.setid=osd.setid
        AND os.addtime>= str_to_date(in_dateid, '%Y-%m-%d')
        AND os.addtime<date_add(str_to_date(in_dateid, '%Y-%m-%d'), interval 1 day)
     GROUP BY osd.userid,os.gameid;
  DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = 1;
  DELETE FROM user_stat_day  WHERE dateid=in_dateid;
  OPEN userCur;
  REPEAT
    FETCH userCur INTO v_userid,v_gameid,v_cnt;
    IF NOT done THEN
       SET v_n=0;
       INSERT INTO user_stat_day(userid ,  gameid ,  dateid ,  roomcnt )
           VALUES(v_userid,v_gameid,in_dateid, v_cnt);
       SELECT COUNT(id) INTO v_n FROM user_stat us WHERE us.userid=v_userid  AND us.gameid=v_gameid;
      IF v_n=0 THEN
          INSERT INTO user_stat(userid, gameid, roomcnt)
                      VALUES(v_userid,v_gameid,v_cnt);
      ELSEIF v_n=1 THEN
          UPDATE user_stat us
             SET us.roomcnt=us.roomcnt+v_cnt
           WHERE us.userid=v_userid 
             AND us.gameid=v_gameid;
      END IF;
    END IF;
  UNTIL done END REPEAT;
  CLOSE userCur;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for SystemInitializer
-- ----------------------------
DROP PROCEDURE IF EXISTS `SystemInitializer`;
DELIMITER ;;
CREATE DEFINER=`user76`@`%` PROCEDURE `SystemInitializer`()
BEGIN
set @@autocommit =off;

 
truncate table agent_account;
truncate table agent_info;
truncate table agent_log;
truncate table agent_return_log;
truncate table agent_stat_day;
truncate table agent_transfer;
truncate table agent_upgrade;

truncate table friend_game;
truncate table friend_info;
truncate table friend_stat_day;
truncate table friend_user;

truncate table log_friend_user; 
truncate table log_funds_admin; 
truncate table log_funds_agent;
truncate table log_funds_user;
truncate table log_run;

-- truncate table msg_content;
truncate table msg_content_agent;
truncate table msg_content_user;

truncate table order_pay;
truncate table order_recorddata;
truncate table order_recorddata_detail;
truncate table order_recorddata_path;
truncate table order_settlement;
truncate table order_settlement_detail;
truncate table order_transfer;


truncate table user_account;
truncate table user_info;
truncate table user_log;
truncate table user_log_bak;
truncate table user_snsinfo;
truncate table user_stat;
truncate table user_stat_day; 
truncate table user_task_log;
truncate table user_activity_log ;



truncate table sys_sequence;


INSERT INTO `sys_sequence`(`name`, `current_value`, `increment`) VALUES ('agent_info', 10000, 1);
INSERT INTO `sys_sequence`(`name`, `current_value`, `increment`) VALUES ('agent_log', 1, 1);
INSERT INTO `sys_sequence`(`name`, `current_value`, `increment`) VALUES ('general', 10000000, 1);
INSERT INTO `sys_sequence`(`name`, `current_value`, `increment`) VALUES ('order_settlement', 1, 1);
INSERT INTO `sys_sequence`(`name`, `current_value`, `increment`) VALUES ('order_recorddata', 1, 1);
INSERT INTO `sys_sequence`(`name`, `current_value`, `increment`) VALUES ('friend_info', 10000, 1);
INSERT INTO `sys_sequence`(`name`, `current_value`, `increment`) VALUES ('user_info', 210000, 1);
INSERT INTO `sys_sequence`(`name`, `current_value`, `increment`) VALUES ('user_log', 1, 1);
INSERT INTO `sys_sequence`(`name`, `current_value`, `increment`) VALUES ('user_log_bak', 1, 1);
INSERT INTO `sys_sequence`(`name`, `current_value`, `increment`) VALUES ('user_task_log', 1, 1);
INSERT INTO `sys_sequence`(`name`, `current_value`, `increment`) VALUES ('user_activity_log', 1, 1);



commit;

END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for WEB_ALL_UserLogon
-- ----------------------------
DROP PROCEDURE IF EXISTS `WEB_ALL_UserLogon`;
DELIMITER ;;
CREATE DEFINER=`user76`@`%` PROCEDURE `WEB_ALL_UserLogon`(
IN _unionId VARCHAR ( 200 ),
IN _openId VARCHAR ( 200 ),
IN _nickName VARCHAR ( 100 ),
IN _header VARCHAR ( 500 ),
IN _snsId INT,
IN _ip VARCHAR ( 100 ),
IN _Gender INT,
OUT returnvalue INT 
)
la : BEGIN
DECLARE
	__UserId INT DEFAULT 0;
DECLARE
	__returnvalue INT DEFAULT 0;

SET @@autocommit = off;

SELECT
	user_snsinfo.userid INTO __UserId 
FROM
	user_snsinfo 
WHERE
	user_snsinfo.unionId = _unionId 
	AND user_snsinfo.snsId = _snsId;
	
	
IF
	__UserId > 0 
	AND __UserId <> 1 THEN
	
	UPDATE user_info 
SET user_info.nickname = _nickName,
user_info.picfile = _header 
WHERE
user_info.userid = __UserId;

SELECT
__UserId userid;  

SET returnvalue = 1;
COMMIT;

LEAVE la;

END IF;
-- 
-- IN `_Pwd` VARCHAR ( 100 ),
-- IN `_ParentUser` INT,
-- IN `_Ip` VARCHAR ( 50 ),
-- IN `_NickName` VARCHAR ( 50 ),
-- IN `_RegStatus` INT,
-- IN `_Gender` INT,
-- OUT `OUT_UserID` INT,
-- OUT `returnvalue` INT 
-- )

if __UserId <= 0 then 


INSERT INTO `user_snsinfo` ( `id`, `unionId`, `openId`, `snsId`, `userid` )
VALUES
	( NULL, _unionId, _openId, _snsId, 1 );
end if;

CALL CSRegOLogin ( '', 0, _ip, _nickName, 0, _Gender, __UserId, __returnvalue );



IF
	__returnvalue <> 1 THEN
		
		SET returnvalue = __returnvalue;
	
END IF;


UPDATE user_snsinfo 
set user_snsinfo.userid = __UserId   
where 
	user_snsinfo.unionId = _unionId 
	AND user_snsinfo.snsId = _snsId;
	
UPDATE user_info set 
	user_info.picfile = _header,
	user_info.nickname = _nickName
where user_info.userid = __UserId;


SELECT
__UserId userid;

SET returnvalue = 1;

COMMIT;



END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for WEB_GetRankList
-- ----------------------------
DROP PROCEDURE IF EXISTS `WEB_GetRankList`;
DELIMITER ;;
CREATE DEFINER=`user76`@`%` PROCEDURE `WEB_GetRankList`(in _userId int,in _count int, in rankType int, out returnvalue int)
BEGIN

  /*rankType 1 今日 2历史*/

/**

"userId",
"header",
"nickName",
"number",
"giveType",
"giveNum",
"rank",


*/ 
IF rankType=1 THEN

SET @j := 0;
SET @pre_num := - 1;
SET @k := 1;

SELECT
	userid,
	header,
	nickname,
	number,
	2 giveType,
	( 55 - rank ) giveNum,
	rank 
FROM
	(
	SELECT
		*,
		@j := @j + 1 AS j,
		@k := ( CASE WHEN @pre_num = number THEN @k ELSE @j END ) rank,
		@pre_num := number AS pre_num 
	FROM
		(
		SELECT
			r.userid,
			ui.picfile header,
			ui.nickname,
			r.number 
		FROM
			/*( SELECT ord.userid, COUNT( ord.userid ) number FROM order_settlement_detail ord GROUP BY ord.userid ) r*/
      (SELECT osd.userid,SUM(os.gamenum ) AS number 
          FROM order_settlement os ,order_settlement_detail osd 
          WHERE os.setid=osd.setid
           and os.addtime>=str_to_date(SYSDATE(), '%Y-%m-%d')
          GROUP BY osd.userid ) r
			LEFT JOIN user_info ui ON ui.userid = r.userid 
		ORDER BY
			number DESC 
		) rank_data 
) r 
WHERE 1=2;
-- where r.userid = _userId or r.rank<=_count;

ELSEIF rankType=2 THEN

SET @j := 0;
SET @pre_num := - 1;
SET @k := 1;

SELECT
	userid,
	header,
	nickname,
	number,
	2 giveType,
	( 55 - rank ) giveNum,
	rank 
FROM
	(
	SELECT
		*,
		@j := @j + 1 AS j,
		@k := ( CASE WHEN @pre_num = number THEN @k ELSE @j END ) rank,
		@pre_num := number AS pre_num 
	FROM
		(
		SELECT
			r.userid,
			ui.picfile header,
			ui.nickname,
			r.number 
		FROM
			/*( SELECT ord.userid, COUNT( ord.userid ) number FROM order_settlement_detail ord GROUP BY ord.userid ) r*/
        (SELECT us.userid,SUM(us.roomcnt) AS number
            FROM user_stat us
         GROUP BY us.userid) r
			LEFT JOIN user_info ui ON ui.userid = r.userid 
		ORDER BY
			number DESC 
		) rank_data 
) r
  WHERE 1=2;
 -- where r.userid = _userId or r.rank<=_count;

END IF;


set returnvalue = 1;

  /*(SELECT aa.userid,SUM(aa.cnt) AS number
        FROM
        (SELECT ord.userid, COUNT( ord.id ) cnt 
          FROM order_settlement_detail ord  
          WHERE ord.addtime>=str_to_date(SYSDATE(), '%Y-%m-%d')
          GROUP BY ord.userid 
         UNION ALL
          SELECT us.userid,SUM(us.roomcnt) cnt
            FROM user_stat us
         GROUP BY us.userid) aa
       GROUP BY aa.userid)*/
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for WEB_GetUserReplayList
-- ----------------------------
DROP PROCEDURE IF EXISTS `WEB_GetUserReplayList`;
DELIMITER ;;
CREATE DEFINER=`user76`@`%` PROCEDURE `WEB_GetUserReplayList`(in _userId int ,in _startId int,in _count int,out returnvalue int )
lable:BEGIN
-- DECLARE __now datetime DEFAULT now();  
set @startDate = DATE_SUB(now(),INTERVAL 15 DAY); 
-- select @startDate;

 drop table if EXISTS `tp_replay_group`;
 drop table if EXISTS `user_replaylist`;
 
  
 
  create TEMPORARY table user_replaylist
select 

rec.recordid,
rec.mid,
rec.sid,
rec.roomid,
rec.gameid,
rec.ownerid,
ui.picfile,
rule.rulestr,
rule.ruledesc,
rec.addtime,
rp.recpath

from order_recorddata rec 
	left join order_recorddata_detail rd on rec.recordid = rd.id 
	left join user_info ui on ui.userid = rec.ownerid
	left join friend_game rule on rule.id = rec.friendgameid
	left join order_recorddata_path rp on rec.recordid = rp.recordid
	where	(rd.userid = _userId) and rd.addtime > @startDate
  ;
	/*rec.ownerid = _userId or */

  create TEMPORARY table tp_replay_group 
	select ur.mid ,COUNT(*) from (select * from   user_replaylist  where (_startId = 0 or user_replaylist.recordid > _startId)) ur 
	group by ur.mid 
  ORDER BY 2 desc 
	limit _count;  


	select ur.* from user_replaylist ur right join tp_replay_group gp on ur.mid = gp.mid;
	SELECT 
	rd.* ,
	ui.nickname,
	ui.picfile
	from order_recorddata_detail rd
		left join user_info ui on ui.userid = rd.userid 
	where rd.recordid  in (select ur.recordid from user_replaylist ur right join tp_replay_group gp on ur.mid = gp.mid);


 set returnvalue =1;

END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for WEB_GetUserReplayListDD
-- ----------------------------
DROP PROCEDURE IF EXISTS `WEB_GetUserReplayListDD`;
DELIMITER ;;
CREATE DEFINER=`user76`@`%` PROCEDURE `WEB_GetUserReplayListDD`(in _mid varchar(100) ,in _userId int,out returnvalue int )
BEGIN
-- 1
select 
     rec.recordid,
     orp.recpath
 from order_recorddata rec ,order_recorddata_path orp
 where	rec.recordid=orp.recordid
   AND rec.mid=_mid
  ORDER BY orp.addtime;
-- 2
  select 
     rec.recordid,ord.userid,ord.moneynum
  from order_recorddata rec ,order_recorddata_detail ord
  WHERE rec.recordid=ord.recordid
  AND rec.mid=_mid
    ORDER BY ord.addtime;

  set returnvalue =1;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for WEB_GetUserReplayListMM
-- ----------------------------
DROP PROCEDURE IF EXISTS `WEB_GetUserReplayListMM`;
DELIMITER ;;
CREATE DEFINER=`user76`@`%` PROCEDURE `WEB_GetUserReplayListMM`(in _userId int ,in _startId int,in _count int,out returnvalue int )
lable:BEGIN
-- DECLARE __now datetime DEFAULT now();  
set @startDate = DATE_SUB(now(),INTERVAL 15 DAY); 
-- select @startDate;

drop table if EXISTS `user_replaylist`;

-- 1
/*create TEMPORARY table user_replaylist
SELECT kk.mid,kk.addtime,kk.recordid
  FROM (select 
     rec.mid,MAX(rec.addtime) AS addtime,MIN(rec.recordid) AS recordid
from order_recorddata rec ,order_recorddata_detail ord
where	rec.recordid=ord.recordid
  and ord.userid = _userId 
  and rec.addtime > @startDate
  GROUP BY rec.mid) kk
  WHERE kk.recordid< _startId
  ORDER BY kk.addtime DESC
  LIMIT _count;
 
select 
     rec.mid,
     rec.roomid,
     rec.gameid,
     rec.ownerid,
     rec.groupid,
     rec.tableid,
     MAX(rec.addtime) AS addtime,
     MIN(rec.recordid) AS recordid
from order_recorddata rec
   WHERE rec.mid in (SELECT mid FROM user_replaylist )
    GROUP BY rec.mid,
     rec.roomid,
     rec.gameid,
     rec.ownerid,
     rec.groupid,
     rec.tableid;
 */
  create TEMPORARY table user_replaylist
SELECT kk.mid,kk.roomid,kk.gameid,kk.ownerid,kk.groupid,kk.tableid,kk.addtime,kk.recordid
  FROM (select 
     rec.mid,rec.roomid,
     rec.gameid,
     rec.ownerid,
     rec.groupid,
     rec.tableid,MAX(rec.addtime) AS addtime,MIN(rec.recordid) AS recordid
from order_recorddata rec ,order_recorddata_detail ord
where	rec.recordid=ord.recordid
  and ord.userid = _userId 
  and rec.addtime > @startDate
  GROUP BY rec.mid,rec.roomid,
     rec.gameid,
     rec.ownerid,
     rec.groupid,
     rec.tableid) kk
  WHERE kk.recordid< _startId
  ORDER BY kk.addtime DESC
  LIMIT _count;

SELECT * FROM user_replaylist;
  


-- 2
 SELECT rec.mid,ord.userid,ui.nickname,SUM(ord.moneynum) AS moneynum
    FROM order_recorddata rec,order_recorddata_detail ord,user_info ui
   WHERE rec.recordid=ord.recordid
     and ord.userid=ui.userid
     -- and ord.userid = _userId 
     -- and ord.addtime > @startDate
     AND rec.mid in (SELECT mid FROM user_replaylist)
    GROUP BY rec.mid,ord.userid,ui.nickname 
    ;
 set returnvalue =1;

END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for WEB_HallMsgList
-- ----------------------------
DROP PROCEDURE IF EXISTS `WEB_HallMsgList`;
DELIMITER ;;
CREATE DEFINER=`user76`@`%` PROCEDURE `WEB_HallMsgList`(
                              IN in_msgobject char(1) ,IN in_objectid int,OUT returnvalue int)
BEGIN
	#用户和代理获取消息
	/*
		in_msgobject  A代理U用户
	*	in_objectid 	userid或者agentid

	* returnvalue	  返回结果-1 失败 1成功
	*/
	SET returnvalue = -1;
  IF in_msgobject='A' THEN
    INSERT INTO msg_content_agent( msgid, agentid, addtime,title,content,status)
               SELECT mc.id,in_objectid,SYSDATE(),mc.title,mc.content,'0'
                FROM msg_content mc
                WHERE mc.msgstatus='1'
                  AND mc.msgobject='A'
                  AND mc.begintime<=SYSDATE()
                  AND mc.endtime>=SYSDATE()
                  AND NOT EXISTS(SELECT mca.id FROM msg_content_agent mca WHERE mca.msgid=mc.id AND mca.agentid=in_objectid);
     COMMIT; 
     SELECT mca.id,mca.addtime,mca.title,mca.content,mca.status AS opstatus,mca.opentime AS optime
       FROM msg_content_agent mca 
      WHERE mca.agentid=in_objectid
        ORDER BY mca.addtime DESC;
  ELSEIF  in_msgobject='U' THEN
    INSERT INTO msg_content_user( msgid, userid, addtime,title,content,status)
               SELECT mc.id,in_objectid,SYSDATE(),mc.title,mc.content,'0'
                FROM msg_content mc
                WHERE mc.msgstatus='1'
                  AND mc.msgobject='U'
                  AND mc.begintime<=SYSDATE()
                  AND mc.endtime>=SYSDATE()
                  AND NOT EXISTS(SELECT mcu.id FROM msg_content_user mcu WHERE mcu.msgid=mc.id AND mcu.userid=in_objectid);
    COMMIT;
    SELECT mcu.id,mcu.addtime,mcu.title,mcu.content,mcu.status AS opstatus,mcu.opentime AS optime
       FROM msg_content_user mcu 
      WHERE mcu.userid=in_objectid
        ORDER BY mcu.addtime DESC;
  END IF;
  SET returnvalue = 1;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for WEB_PyGroupAcceptJoin
-- ----------------------------
DROP PROCEDURE IF EXISTS `WEB_PyGroupAcceptJoin`;
DELIMITER ;;
CREATE DEFINER=`user76`@`%` PROCEDURE `WEB_PyGroupAcceptJoin`( IN _userid INT, IN _joinid INT, IN _friendid INT, IN _status INT, OUT returnvalue INT )
la : BEGIN

set @joinUserId :=0;
set @logStatus :=-1;

-- 接受玩家加入亲友圈

SET @@autocommit = off;
IF
	( fc_isfriend_admin ( _userid, _friendid ) <= 0 ) THEN
-- 只有管理员才能进行操作
	
		SET returnvalue = - 1;
	LEAVE la;
	
	END IF;
	
	SELECT log_friend_user.userid,log_friend_user.`status` into @joinUserId,@logStatus
	from log_friend_user
WHERE
	log_friend_user.id = _joinid 
	AND log_friend_user.friendid = _friendid;
	
	if(@logStatus = -1 or @logStatus <> 0) then
	
	set returnvalue = -1;
	LEAVE la;
	end if;
	
UPDATE log_friend_user 
SET log_friend_user.`status` = _status,
log_friend_user.dealuser = _userid,
log_friend_user.dealtype = _status,
log_friend_user.dealtime = now( )
WHERE
	log_friend_user.id = _joinid 
	AND log_friend_user.friendid = _friendid;
IF
	( @joinUserId = 0 ) THEN
		
		SET returnvalue = 1;
		LEAVE la;
END IF;


if (_status = 1)
then 

-- 自动添加玩家信息
INSERT INTO `friend_user` ( `id`, `friendid`, `userid`, `isadmin`, `addtime` )
VALUES
	( NULL, _friendid, @joinUserId, '0', now( ) );
	end if ;
COMMIT;

SET returnvalue = 1;

END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for WEB_PyGroupAddRule
-- ----------------------------
DROP PROCEDURE IF EXISTS `WEB_PyGroupAddRule`;
DELIMITER ;;
CREATE DEFINER=`user76`@`%` PROCEDURE `WEB_PyGroupAddRule`(in _userid int ,in _friendid int ,in _gameid int ,
in _rulestr VARCHAR(500), in _ruledesc VARCHAR(500),out returnvalue int)
lable:BEGIN

set @@autocommit = off;


IF not EXISTS ( SELECT 1 FROM friend_user WHERE friend_user.userid = _userid and friend_user.friendid = _friendid and friend_user.isadmin in ('1','2') ) THEN
	-- 玩家不是管理员，操作失败
	SET returnvalue = - 1;
	LEAVE lable;
END IF;

-- 添加规则玩法信息
INSERT INTO `friend_game` (`id`, `friendid`, `gameid`, `rulestr`, `ruledesc`, `status`, `addtime`) 
													VALUES (NULL, _friendid,_gameid  , _rulestr, _ruledesc   , 1, now());

commit;

set returnvalue = 1;

END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for WEB_PyGroupCreate
-- ----------------------------
DROP PROCEDURE IF EXISTS `WEB_PyGroupCreate`;
DELIMITER ;;
CREATE DEFINER=`user76`@`%` PROCEDURE `WEB_PyGroupCreate`( IN `_userid` INT, IN `_name` VARCHAR ( 100 ), OUT returnvalue INT )
lable : BEGIN
declare __fid int ;
DECLARE _picfile VARCHAR(500);
set @@autocommit = off;

IF not EXISTS ( SELECT 1 FROM agent_info WHERE agent_info.userid = _userid ) THEN
	-- 玩家没有成为代理，无法完成亲友圈的创建
	SET returnvalue = - 1;
	LEAVE lable;
END IF;

 

 
set __fid = fc_nextval('friend_info');
SELECT ui.picfile into _picfile from user_info as ui where ui.userid = _userid;

-- 插入亲友圈圈信息
insert into friend_info
(
friendid,
userid,
friendname,
addtime,
maxnum,
picpath,
`status`
)
values(
__fid,
_userid,
_name,
now(),
500,
_picfile,
1
);

-- 自动添加圈主信息
INSERT INTO  `friend_user`(`id`, `friendid`, `userid`, `isadmin`, `addtime`) VALUES (NULL, __fid, _userid, '2', now());


SET returnvalue = 1;
COMMIT;


END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for WEB_PyGroupDeleteRule
-- ----------------------------
DROP PROCEDURE IF EXISTS `WEB_PyGroupDeleteRule`;
DELIMITER ;;
CREATE DEFINER=`user76`@`%` PROCEDURE `WEB_PyGroupDeleteRule`(IN _userid int, IN _friendid int, IN _ruleid int, OUT returnvalue int)
lable:BEGIN

IF not EXISTS ( SELECT 1 FROM friend_user WHERE friend_user.userid = _userid and friend_user.friendid = _friendid and friend_user.isadmin in ('1','2') ) THEN
	-- 玩家不是管理员，操作失败
	SET returnvalue = -1;
	LEAVE lable;
END IF;
set @@autocommit = off;

UPDATE friend_game set friend_game.`status` = '0' where friend_game.friendid = _friendid and friend_game.id = _ruleid;

commit;
set returnvalue = 1;

END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for WEB_PyGroupList
-- ----------------------------
DROP PROCEDURE IF EXISTS `WEB_PyGroupList`;
DELIMITER ;;
CREATE DEFINER=`user76`@`%` PROCEDURE `WEB_PyGroupList`(in _userid int  ,out returnvalue int)
BEGIN

SELECT
	fi.friendid AS id,
	fi.friendname AS `name`,
	fi.notice AS `notice`,
	fi.picpath AS `header`,
	fi.userid AS userid,
	(SELECT COUNT(1) from friend_user where friend_user.friendid = fi.friendid) as UserCount,
	500 as MaxUserCount
FROM
	friend_info fi
	INNER JOIN friend_user fu ON fu.friendid = fi.friendid 
WHERE
	fu.userid = _userid;
	
	
set returnvalue = 1;

END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for WEB_PyGroupMsgList
-- ----------------------------
DROP PROCEDURE IF EXISTS `WEB_PyGroupMsgList`;
DELIMITER ;;
CREATE DEFINER=`user76`@`%` PROCEDURE `WEB_PyGroupMsgList`(in _friendid int ,in _userId int ,out returnvalue int)
la:BEGIN



SELECT 
lfu.id,
lfu.userid,
ui.nickname,
ui.picfile header,
lfu.addtime,
lfu.`status`

from log_friend_user lfu left join user_info ui on ui.userid = lfu.userid
where lfu.friendid = _friendid;


SET returnvalue = 1;

END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for WEB_PyGroupRuleList
-- ----------------------------
DROP PROCEDURE IF EXISTS `WEB_PyGroupRuleList`;
DELIMITER ;;
CREATE DEFINER=`user76`@`%` PROCEDURE `WEB_PyGroupRuleList`(IN _friendid int, OUT returnvalue int)
la:BEGIN

SELECT
	fg.gameid gameid,
	fg.id,
	fg.rulestr,
	fg.ruledesc,
	g.modulename,
	g.gamename 
FROM
	friend_game fg
	LEFT JOIN game_info g ON fg.gameid = g.gameid 
WHERE
	fg.friendid = _friendid 
	AND fg.`status` = '1';

SET returnvalue = 1;
 

END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for WEB_PyGroupSetAdmin
-- ----------------------------
DROP PROCEDURE IF EXISTS `WEB_PyGroupSetAdmin`;
DELIMITER ;;
CREATE DEFINER=`user76`@`%` PROCEDURE `WEB_PyGroupSetAdmin`(in _userid int , in _aid int ,in _isadmin int, in _friendid int,out returnvalue int)
la:BEGIN

set @isAdmin := '0';


if not EXISTS(SELECT 1 from friend_user where friend_user.userid = _userid and friend_user.friendid = _friendid and friend_user.isadmin = '2' )
then  
	set returnvalue = -1;
	leave la;
end if;

if(_aid = _userid) then 
 
	set returnvalue = -1;
leave la;
end if;

if( _isadmin = 1) then
	set @isAdmin := '1';
end if;

set @@autocommit = off;

update friend_user set friend_user.isadmin = @isAdmin where friend_user.userid = _aid and friend_user.friendid  = _friendid;

commit;

set returnvalue =1;

END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for WEB_PyGroupSetInfo
-- ----------------------------
DROP PROCEDURE IF EXISTS `WEB_PyGroupSetInfo`;
DELIMITER ;;
CREATE DEFINER=`user76`@`%` PROCEDURE `WEB_PyGroupSetInfo`(in _userid int ,in _friendid int , in _title VARCHAR(50) , in _notice VARCHAR(500) 
,out _errMsg VARCHAR(50)
,out returnvalue int)
la:BEGIN


set _errMsg ='OK';


IF
	( fc_isfriend_admin ( _userid, _friendid ) <= 0 ) THEN
-- 只有管理员才能进行操作
	
		SET returnvalue = - 1;
		set _errMsg = '只有管理员才能进行操作';
	LEAVE la;
	
	END IF;

update friend_info set 
friend_info.friendname = _title,
friend_info.notice =_notice

where friend_info.friendid = _friendid;


set returnvalue =1;

END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for WEB_PyGroupUpdate
-- ----------------------------
DROP PROCEDURE IF EXISTS `WEB_PyGroupUpdate`;
DELIMITER ;;
CREATE DEFINER=`user76`@`%` PROCEDURE `WEB_PyGroupUpdate`( IN `_userid` INT, IN `_friendid` INT, IN `_name` VARCHAR ( 100 ), IN `_notice` VARCHAR ( 100 ),OUT returnvalue INT )
lable : BEGIN 


set @@autocommit = off;

IF not EXISTS ( SELECT 1 FROM friend_user WHERE friend_user.userid = _userid and friend_user.friendid = _friendid and friend_user.isadmin in ('1','2') ) THEN
	-- 玩家不是管理员，操作失败
	SET returnvalue = - 1;
	LEAVE lable;
END IF;
-- 修改亲友圈基本信息
update `friend_info` set `friend_info`.`friendname` = _name ,friend_info.friendgamennum = _notice where friend_info.friendid = _friendid;

SET returnvalue = 1;

commit;

END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for WEB_PyGroupUserExit
-- ----------------------------
DROP PROCEDURE IF EXISTS `WEB_PyGroupUserExit`;
DELIMITER ;;
CREATE DEFINER=`user76`@`%` PROCEDURE `WEB_PyGroupUserExit`( IN _userid INT, IN _friendid INT, IN _exitid INT, OUT returnvalue INT )
la : BEGIN

SET @@autocommit = off;
IF
	( _userid <> _exitid ) THEN
IF
	( fc_isfriend_admin ( _userid, _friendid ) <= 0 ) THEN
-- 玩家是当前亲友圈的管理员，拒绝操作
	
	SET returnvalue = - 1;
LEAVE la;

END IF;

END IF;
IF
	NOT EXISTS ( SELECT 1 FROM friend_user WHERE friend_user.userid = _exitid AND friend_user.friendid = _friendid ) THEN
-- 玩家玩家不在当前的亲友圈，停止操作
		
		SET returnvalue = - 1;
	LEAVE la;
	
END IF;

-- 删除玩家信息
delete from friend_user where	friend_user.userid = _exitid 	AND friend_user.friendid = _friendid;

-- 插入玩家退出的日志信息
INSERT INTO `log_friend_user` ( `id`, `userid`, `friendid`, `dealuser`, `addtime`, `status`, `dealtime`, `remark`, `dealtype` )
VALUES
	( NULL, _exitid, _friendid, _userid, now( ), '2', now( ), NULL, '0' );
	
	set returnvalue = 1;
	commit;

END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for WEB_PyGroupUserJoin
-- ----------------------------
DROP PROCEDURE IF EXISTS `WEB_PyGroupUserJoin`;
DELIMITER ;;
CREATE DEFINER=`user76`@`%` PROCEDURE `WEB_PyGroupUserJoin`(in _userid int, in _friendid int 
,out _errmsg VARCHAR(50)
, out returnvalue int)
la:BEGIN

set @@autocommit = off;
set _errmsg ='OK';
set returnvalue = -1;

if not exists (SELECT 1  from friend_info where friend_info.friendid = _friendid)
then 

-- 玩家已经成功加入了改亲友圈
set _errmsg ='亲友圈信息不存在';
set returnvalue = -1;
leave la;

end if;

if EXISTS(SELECT 1 from friend_user where friend_user.userid = _userid and friend_user.friendid = _friendid)
then
-- 玩家已经成功加入了该亲友圈
set _errmsg ='玩家已经加入指定的亲友圈';
set returnvalue = -1;
leave la;

end if;


-- 检查玩家是否已经提交了加入亲友圈的申请
if exists (SELECT 1 from log_friend_user where log_friend_user.userid = _userid and _friendid = log_friend_user.friendid and log_friend_user.`status` =0)
then 
-- 玩家已经提交了加入当前亲友圈的申请
set _errmsg = '玩家已经提交了加入当前亲友圈的申请';
set  returnvalue = -1;

leave la;

end if ;



INSERT INTO `log_friend_user`(`id`, `userid`, `friendid`, `dealuser`, `addtime`, `status`, `dealtime`, `remark`, `dealtype`) 
											VALUES (NULL, _userid , _friendid , 0         , now()			, '0'			, NULL			, NULL		, '1'	);




commit;

set  returnvalue = 1;

END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for WEB_PyGroupUserList
-- ----------------------------
DROP PROCEDURE IF EXISTS `WEB_PyGroupUserList`;
DELIMITER ;;
CREATE DEFINER=`user76`@`%` PROCEDURE `WEB_PyGroupUserList`(in _userid int  ,in _friendid int , in _startid int, in _size int ,  out returnvalue int)
lable:BEGIN



IF not EXISTS ( SELECT 1 FROM friend_user WHERE friend_user.userid = _userid and friend_user.friendid = _friendid) THEN
	-- 玩家不是管理员，操作失败
	SET returnvalue = - 1;
	LEAVE lable;
END IF;


SELECT
fu.userid,
ui.nickname as `name`,
ui.picfile as `header`,
fu.isadmin



from friend_user fu left join  user_info ui on fu.userid = ui.userid where fu.friendid = _friendid and (_startid = 0 or fu.id < _startid ) LIMIT _size;






set returnvalue = 1;

END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for WEB_SetUserReadMsg
-- ----------------------------
DROP PROCEDURE IF EXISTS `WEB_SetUserReadMsg`;
DELIMITER ;;
CREATE DEFINER=`user76`@`%` PROCEDURE `WEB_SetUserReadMsg`(
                              IN in_msgobject char(1) ,IN in_objectid int,IN in_msgid int,OUT returnvalue int)
BEGIN
	#用户和代理查看消息后，消息已读
	/*
		in_msgobject  A代理U用户
	*	in_objectid 	userid或者agentid
    in_msgid      消息ID
	* returnvalue	  返回结果-1 失败 1成功
	*/
	SET returnvalue = -1;
	set @@autocommit =off;
	
  IF in_msgobject='U' THEN
     UPDATE msg_content_user mcu
        SET mcu.`status`='1',mcu.opentime=SYSDATE()
     WHERE mcu.id=in_msgid;
  ELSEIF  in_msgobject='A' THEN
     UPDATE msg_content_agent mca
        SET mca.`status`='1',mca.opentime=SYSDATE()
     WHERE mca.id=in_msgid;
	 
  END IF;
	
  COMMIT;
  SET returnvalue = 1;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for WEB_UserPayRequest
-- ----------------------------
DROP PROCEDURE IF EXISTS `WEB_UserPayRequest`;
DELIMITER ;;
CREATE DEFINER=`user76`@`%` PROCEDURE `WEB_UserPayRequest`(IN in_userid int,IN _shopId int,in in_outNo varchar(50),out _rmb DOUBLE(10,2),out returnvalue int)
lable:BEGIN

DECLARE in_rmb DOUBLE(10,2);
DECLARE in_vcoin int;
DECLARE in_gift int; 
DECLARE in_accounttype int;
DECLARE in_gifttype int;
DECLARE v_gifttype char(2); 


SELECT rmb,moneytype,moneynum,givetype,givenum into 
			in_rmb,	in_accounttype,in_vcoin,in_gifttype,in_gift
from sys_shop where id = _shopId;

set _rmb = in_rmb;

IF (FOUND_ROWS() < 1) THEN
	-- 玩家不存在
SET returnvalue = -1;

LEAVE lable;
end if;

       /*Unknown = 0,
        RMB = 1,
        Diamond = 2,
        Gold = 3,
        QiDou = 4,
        MatchScore = 10*/


  /* 玩家充值下单
   输入：in_userid 玩家id
         in_rmb  支付金额
         in_vcoin 钻石数量
         in_gift 送数量
         in_accounttype 充值账户类型VD 钻石 VG金币 VQ 七乐币
         in_gifttype 送账户类型VD 钻石 VG金币 VQ 七乐币
    输出：o_out  订单号 ‘ ‘ 下单失败 */
		
  SET @@autocommit=off; 
  IF in_accounttype=2 THEN
      SELECT CASE in_gifttype WHEN 2 THEN 'VD' WHEN 3 THEN 'VG' WHEN 4 THEN 'VQ' ELSE in_gifttype END INTO v_gifttype;
      INSERT INTO order_pay(id, auid, accounttype, rmb, vcoin, gift, addtime, userflag, status,gifttype)
                VALUES(in_outNo,in_userid,'VD',in_rmb,in_vcoin,in_gift,now(),'U','0',v_gifttype);
  END IF;
  commit;
	set returnvalue = 1;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for WEB_UserPayResult
-- ----------------------------
DROP PROCEDURE IF EXISTS `WEB_UserPayResult`;
DELIMITER ;;
CREATE DEFINER=`user76`@`%` PROCEDURE `WEB_UserPayResult`(
                              in_orderid varchar(50),
                              in_status char(1),
                              in_realrmb DOUBLE(10,2),
                              in_paytype char(1),
                              in_remark  varchar(100),
                              in_returnflage char(1),
                          out returnvalue int)
BEGIN
  /* 用户充值
   输入：in_orderid 订单号
         in_realrmb 实际付款金额  
         in_status 1成功 2失败
         in_remark 微信订单号
         in_paytype 0线下支付1微信支付2支付宝
         in_returnflag 0不返佣 1返佣
    输出：returnvalue  -1充值失败 0 无订单号 1成功 */
  DECLARE v_auid int DEFAULT NULL;
  DECLARE v_vcoin int; 
  DECLARE v_accounttype char(2);
  DECLARE v_gifttype char(2);
  DECLARE v_gift double(12,2);
  set @@autocommit=off;
  SET returnvalue=-1;
  select op.auid,op.vcoin,op.accounttype,op.gifttype,op.gift into v_auid,v_vcoin,v_accounttype,v_gifttype,v_gift
   from order_pay op where op.id=in_orderid and op.status='0' and op.userflag='U';
  /* 充钻 */
  IF NOT ISNULL(v_auid) AND v_accounttype='VD' THEN
    IF  in_status='1' THEN
    /* 充送 */
      CALL sp_user_pay_vd(in_orderid,v_auid,v_vcoin,v_gift,v_gifttype);
    /* 返佣 */
      IF in_returnflage='1' THEN
        CALL sp_user_pay_return(in_orderid,v_auid,in_realrmb);
      END IF;
    END IF;
    /* 更新订单记录 */
      update order_pay
         set status=in_status,paytime=now(),realrmb=in_realrmb,remark=in_remark,paytype=in_paytype
         where id=in_orderid;
      commit;
      set returnvalue=1;
			
			
--     SELECT 1 AS MoneyType ,ua.rmb AS MoneyNum ,ua.userid UserId FROM user_account ua   WHERE ua.userid=v_auid
--       UNION ALL
    SELECT 2 AS MoneyType ,ua.diamond AS MoneyNum ,ua.userid UserId FROM user_account ua WHERE ua.userid=v_auid
     UNION ALL
--     SELECT 3 AS MoneyType ,ua.gold AS MoneyNum,ua.userid UserId FROM user_account ua   WHERE ua.userid=v_auid
--      UNION ALL
    SELECT 4 AS MoneyType ,ua.qidou AS MoneyNum,ua.userid UserId FROM user_account ua   WHERE ua.userid=v_auid;

  ELSE
   set returnvalue=0;
  END if;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for WEB_UserSharedResult
-- ----------------------------
DROP PROCEDURE IF EXISTS `WEB_UserSharedResult`;
DELIMITER ;;
CREATE DEFINER=`user76`@`%` PROCEDURE `WEB_UserSharedResult`(IN in_taskid varchar(50), IN in_user int, IN in_remark varchar(200), OUT returnvalue int)
BEGIN
  /* 用户分享结果返回
   输入：in_taskid 任务ID
         in_user 用户  
         in_remark 备注，可填写分享用户ID
   输出：returnvalue  -1失败 0已经分享  1分享成功 */
  DECLARE v_diamond double(12,2);
  DECLARE v_gold double(12,2);
  DECLARE v_qidou double(12,2);
  DECLARE v_cnt int;
  DECLARE v_logid varchar(20);
  SET @@autocommit=off;
  SET returnvalue=-1;
    /*判断今天是否已经分享*/
    SELECT COUNT(utl.logid) INTO v_cnt
      FROM user_task_log utl 
     WHERE utl.addtime>=str_to_date(SYSDATE(), '%Y-%m-%d') AND utl.userid=in_user and utl.taskid = in_taskid;
    IF v_cnt<=0 THEN
       /*获取任务信息 */
       SELECT ut.diamond,ut.gold,ut.qidou INTO v_diamond,v_gold,v_qidou
         FROM user_task ut 
        WHERE ut.taskid=in_taskid;
      /*  */
        SELECT CONCAT( DATE_FORMAT(now(),'%y%m%d') ,fc_nextval('user_task_log')) INTO v_logid;
        INSERT INTO user_task_log(logid,taskid,userid,addtime,remark,diamond,gold,qidou)
             VALUES(v_logid,in_taskid,in_user,SYSDATE(),in_remark,v_diamond,v_gold,v_qidou);
        IF v_diamond>0 THEN
           CALL sp_log_fund_user(v_logid,in_user,v_diamond,'VD','25');
        END IF;
        IF v_gold>0 THEN
           CALL sp_log_fund_user(v_logid,in_user,v_gold,'VG','25');
        END IF;
        IF v_qidou>0 THEN
           CALL sp_log_fund_user(v_logid,in_user,v_diamond,'VQ','25');
        END IF;
				
			call sp_get_user_moneybag(in_user);
			SELECT 	v_diamond as diamond,
							v_gold as gold,
							v_qidou as qidou;
			
			
			SET returnvalue=1;
     ELSE
       SET returnvalue=0;
     END IF;
	 COMMIT;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for WEB_UserSharedResult_bak
-- ----------------------------
DROP PROCEDURE IF EXISTS `WEB_UserSharedResult_bak`;
DELIMITER ;;
CREATE DEFINER=`user76`@`%` PROCEDURE `WEB_UserSharedResult_bak`(IN in_taskid varchar(50), IN in_user int, IN in_remark varchar(200), OUT returnvalue int)
BEGIN
  /* 用户分享结果返回
   输入：in_taskid 任务ID
         in_user 用户  
         in_remark 备注，可填写分享用户ID
   输出：returnvalue  -1失败 0已经分享  1分享成功 */
  DECLARE v_diamond double(12,2);
  DECLARE v_gold double(12,2);
  DECLARE v_qidou double(12,2);
  DECLARE v_cnt int;
  DECLARE v_logid varchar(20);
  SET @@autocommit=off;
  SET returnvalue=-1;
    /*判断今天是否已经分享*/
    SELECT COUNT(utl.logid) INTO v_cnt
      FROM user_task_log utl 
     WHERE utl.addtime>=str_to_date(SYSDATE(), '%Y-%m-%d') AND utl.userid=in_user;
    IF v_cnt>0 THEN
       /*获取任务信息 */
       SELECT ut.diamond,ut.gold,ut.qidou INTO v_diamond,v_gold,v_qidou
         FROM user_task ut 
        WHERE ut.taskid=in_taskid;
				/*  */
        SELECT CONCAT( DATE_FORMAT(now(),'%y%m%d') ,fc_nextval('user_task_log')) INTO v_logid;
        INSERT INTO user_task_log(logid,taskid,userid,addtime,remark,diamond,gold,qidou)
             VALUES(v_logid,in_taskid,in_user,SYSDATE(),in_remark,v_diamond,v_gold,v_qidou);
        IF v_diamond>0 THEN
           CALL sp_log_fund_user(v_logid,in_user,v_diamond,'VD','25');
        END IF;
        IF v_gold>0 THEN
           CALL sp_log_fund_user(v_logid,in_user,v_gold,'VG','25');
        END IF;
        IF v_qidou>0 THEN
           CALL sp_log_fund_user(v_logid,in_user,v_diamond,'VQ','25');
        END IF;
     ELSE
       SET returnvalue=0;
     END IF;
   call sp_get_user_moneybag(in_user);
	 COMMIT;
  SET returnvalue=1;
END
;;
DELIMITER ;

-- ----------------------------
-- Function structure for fc_currval
-- ----------------------------
DROP FUNCTION IF EXISTS `fc_currval`;
DELIMITER ;;
CREATE DEFINER=`user76`@`%` FUNCTION `fc_currval`(seq_name VARCHAR(20)) RETURNS int(11)
    READS SQL DATA
    DETERMINISTIC
BEGIN  
DECLARE v_VALUE int;  
SELECT current_value INTO v_VALUE FROM sys_sequence WHERE NAME = seq_name;  
RETURN v_VALUE;  
END
;;
DELIMITER ;

-- ----------------------------
-- Function structure for fc_get_sysconfig
-- ----------------------------
DROP FUNCTION IF EXISTS `fc_get_sysconfig`;
DELIMITER ;;
CREATE DEFINER=`user76`@`%` FUNCTION `fc_get_sysconfig`(in_syskey varchar(20)) RETURNS varchar(50) CHARSET utf8
    READS SQL DATA
    DETERMINISTIC
BEGIN
  DECLARE v_sysvalue varchar(50);
  SELECT sc.sysvalue INTO v_sysvalue FROM sys_config sc WHERE sc.syskey=in_syskey;
RETURN v_sysvalue;
END
;;
DELIMITER ;

-- ----------------------------
-- Function structure for fc_get_user_account
-- ----------------------------
DROP FUNCTION IF EXISTS `fc_get_user_account`;
DELIMITER ;;
CREATE DEFINER=`user76`@`%` FUNCTION `fc_get_user_account`(in_userid int,in_moneytype int) RETURNS double(12,2)
    READS SQL DATA
    DETERMINISTIC
BEGIN  
DECLARE v_VALUE double(12,2) DEFAULT 0;  
/*结算类型0无1RMB2钻石3金币*/
  IF in_MoneyType=1 THEN
     SELECT ua.rmb INTO v_VALUE FROM user_account ua WHERE ua.userid=in_userid;
  ELSEIF in_MoneyType=2 THEN
     SELECT ua.diamond INTO v_VALUE FROM user_account ua WHERE ua.userid=in_userid;
  ELSEIF in_MoneyType=3 THEN
     SELECT ua.gold INTO v_VALUE FROM user_account ua WHERE ua.userid=in_userid;
  END IF;  
 RETURN v_VALUE;  
END
;;
DELIMITER ;

-- ----------------------------
-- Function structure for fc_isfriend_admin
-- ----------------------------
DROP FUNCTION IF EXISTS `fc_isfriend_admin`;
DELIMITER ;;
CREATE DEFINER=`user76`@`%` FUNCTION `fc_isfriend_admin`(`_userid` int,`_friendid` int) RETURNS int(11)
BEGIN

DECLARE __val int DEFAULT -1;


SELECT friend_user.isadmin into __val from friend_user where friend_user.userid = _userid and friend_user.friendid = _friendid limit 1;

return __val;

END
;;
DELIMITER ;

-- ----------------------------
-- Function structure for fc_nextval
-- ----------------------------
DROP FUNCTION IF EXISTS `fc_nextval`;
DELIMITER ;;
CREATE DEFINER=`user76`@`%` FUNCTION `fc_nextval`(seq_name VARCHAR(20)) RETURNS int(11)
    DETERMINISTIC
BEGIN  
  
UPDATE sys_sequence SET current_value = current_value + increment WHERE NAME = seq_name;  
RETURN fc_currval(seq_name);  
  
END
;;
DELIMITER ;

-- ----------------------------
-- Function structure for fc_split_str
-- ----------------------------
DROP FUNCTION IF EXISTS `fc_split_str`;
DELIMITER ;;
CREATE DEFINER=`user76`@`%` FUNCTION `fc_split_str`(in_str varchar(500), in_split varchar(5), in_postion int) RETURNS varchar(10) CHARSET utf8
    DETERMINISTIC
BEGIN
  DECLARE v_str varchar(10) DEFAULT NULL;
  IF LENGTH(SUBSTRING_INDEX(in_str, in_split, in_postion))<LENGTH(in_str) 
    OR (LENGTH(SUBSTRING_INDEX(in_str, in_split, in_postion))=LENGTH(in_str) AND LENGTH(SUBSTRING_INDEX(in_str, in_split, in_postion-1))<LENGTH(in_str) )THEN
    SELECT
      SUBSTRING_INDEX(SUBSTRING_INDEX(in_str, in_split, in_postion), in_split, -1) INTO v_str;
  END IF;
  IF v_str='' THEN 
    SET v_str=NULL;
  END IF;
  RETURN v_str;
END
;;
DELIMITER ;

-- ----------------------------
-- Event structure for Event_Stat_Daily
-- ----------------------------
DROP EVENT IF EXISTS `Event_Stat_Daily`;
DELIMITER ;;
CREATE DEFINER=`user76`@`%` EVENT `Event_Stat_Daily` ON SCHEDULE EVERY 1 DAY STARTS '2018-09-14 16:40:00' ON COMPLETION NOT PRESERVE ENABLE COMMENT '定时执行统计' DO BEGIN
   DECLARE v_dateid varchar(10);
   DECLARE v_begintime datetime;
   SELECT sysdate() INTO v_begintime;
   SELECT date_format(date_sub(sysdate(),interval 1 day), '%Y-%m-%d') INTO v_dateid;
  /*调用存储过程*/
   call sp_user_stat(v_dateid);
   call sp_agent_stat(v_dateid);
   call sp_friend_stat(v_dateid);
  /*插入日志*/
   INSERT INTO log_run(runname ,  begindate ,  enddate ,  remark )
         values('STAT',v_begintime,sysdate(),'sp_user_stat,sp_agent_stat,sp_friend_stat');
END
;;
DELIMITER ;
