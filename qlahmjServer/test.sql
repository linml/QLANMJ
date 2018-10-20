/*
 Navicat Premium Data Transfer

 Source Server         : 本机mysql
 Source Server Type    : MySQL
 Source Server Version : 50553
 Source Host           : localhost:3306
 Source Schema         : test

 Target Server Type    : MySQL
 Target Server Version : 50553
 File Encoding         : 65001

 Date: 20/07/2018 17:06:43
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for gameinfo
-- ----------------------------
DROP TABLE IF EXISTS `gameinfo`;
CREATE TABLE `gameinfo`  (
  `GameID` int(11) NOT NULL COMMENT '游戏ID',
  `GameName` text CHARACTER SET utf8 COLLATE utf8_general_ci COMMENT '游戏名称',
  `LatestVersion` text CHARACTER SET utf8 COLLATE utf8_general_ci COMMENT '游戏版本号',
  `ModuleName` text CHARACTER SET utf8 COLLATE utf8_general_ci COMMENT '游戏包名',
  `GameType` int(11) DEFAULT NULL COMMENT '游戏类型',
  `GameStatus` int(11) DEFAULT NULL COMMENT '游戏状态',
  `SortID` int(11) DEFAULT NULL COMMENT '游戏排序Id',
  PRIMARY KEY (`GameID`) USING BTREE
) ENGINE = MyISAM CHARACTER SET = utf8 COLLATE = utf8_general_ci COMMENT = '游戏信息' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of gameinfo
-- ----------------------------
INSERT INTO `gameinfo` VALUES (161, 'M_LQMJ', NULL, 'M_LQMJ', 2, 0, NULL);

-- ----------------------------
-- Table structure for gameroominfo
-- ----------------------------
DROP TABLE IF EXISTS `gameroominfo`;
CREATE TABLE `gameroominfo`  (
  `ID` int(11) NOT NULL AUTO_INCREMENT COMMENT '场地编号',
  `BaseMoney` int(11) DEFAULT NULL COMMENT '底金',
  `Name` text CHARACTER SET utf8 COLLATE utf8_general_ci COMMENT '场地名称',
  `GameId` int(11) DEFAULT NULL COMMENT '游戏编号',
  `RoomType` int(11) DEFAULT NULL COMMENT '场地类型',
  `BaseMoneyType` int(11) DEFAULT NULL COMMENT '底金类型',
  `LimitAICount` int(11) DEFAULT NULL COMMENT '场地AI数量上限',
  `MaxCount` int(11) DEFAULT NULL COMMENT '最大开始人数',
  `MinCount` int(11) DEFAULT NULL COMMENT '最小开始人数',
  `RoomLV` int(11) DEFAULT NULL COMMENT '场地等级',
  `RoomState` int(11) DEFAULT NULL COMMENT '场地状态',
  `PlayerReadTimeOut` int(11) DEFAULT NULL COMMENT '玩家准备时间',
  `MaxLookCount` int(11) DEFAULT NULL COMMENT '最大旁观次数',
  `GameRule` text CHARACTER SET utf8 COLLATE utf8_general_ci COMMENT '游戏规则',
  `Attribute1` text CHARACTER SET utf8 COLLATE utf8_general_ci,
  `Attribute2` text CHARACTER SET utf8 COLLATE utf8_general_ci,
  `Attribute3` text CHARACTER SET utf8 COLLATE utf8_general_ci,
  `Attribute4` text CHARACTER SET utf8 COLLATE utf8_general_ci,
  `Attribute5` text CHARACTER SET utf8 COLLATE utf8_general_ci,
  `Attribute6` text CHARACTER SET utf8 COLLATE utf8_general_ci,
  `Mark` text CHARACTER SET utf8 COLLATE utf8_general_ci COMMENT '备注说明',
  `ServerId` int(11) DEFAULT NULL COMMENT '服务器编号',
  PRIMARY KEY (`ID`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 4 CHARACTER SET = utf8 COLLATE = utf8_general_ci COMMENT = '游戏的场地信息' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of gameroominfo
-- ----------------------------
INSERT INTO `gameroominfo` VALUES (2, 100, 'M_LQMJ', 161, 9, 100, 0, 1, 1, 9, 3, 20, 2, NULL, '4|1|2_8|1|3_16|2|6_8,', NULL, NULL, NULL, NULL, NULL, NULL, 201);

-- ----------------------------
-- Table structure for sysconfig
-- ----------------------------
DROP TABLE IF EXISTS `sysconfig`;
CREATE TABLE `sysconfig`  (
  `ID` int(11) NOT NULL AUTO_INCREMENT COMMENT '编号',
  `SysKey` text CHARACTER SET utf8 COLLATE utf8_general_ci COMMENT '配置项的键',
  `SysValue` text CHARACTER SET utf8 COLLATE utf8_general_ci COMMENT '配置项的值',
  `Mark` text CHARACTER SET utf8 COLLATE utf8_general_ci COMMENT '配置项说明',
  `Status` text CHARACTER SET utf8 COLLATE utf8_general_ci COMMENT '配置启用状态',
  PRIMARY KEY (`ID`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 2 CHARACTER SET = utf8 COLLATE = utf8_general_ci COMMENT = '系统配置表' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of sysconfig
-- ----------------------------
INSERT INTO `sysconfig` VALUES (1, 'ShareTitle', '分享的标题', NULL, '1');

-- ----------------------------
-- Table structure for user_bag
-- ----------------------------
DROP TABLE IF EXISTS `user_bag`;
CREATE TABLE `user_bag`  (
  `ID` int(11) NOT NULL AUTO_INCREMENT COMMENT '编号',
  `UserID` int(11) DEFAULT NULL,
  `MoneyNum` bigint(20) DEFAULT NULL,
  `MoneyType` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci COMMENT = '玩家余额背包表' ROW_FORMAT = Fixed;

-- ----------------------------
-- Table structure for user_info
-- ----------------------------
DROP TABLE IF EXISTS `user_info`;
CREATE TABLE `user_info`  (
  `UserId` int(11) NOT NULL AUTO_INCREMENT COMMENT '玩家Id',
  `UserAccount` text CHARACTER SET utf8 COLLATE utf8_general_ci COMMENT '玩家账号',
  `Password` text CHARACTER SET utf8 COLLATE utf8_general_ci COMMENT '玩家密码',
  `NickName` text CHARACTER SET utf8 COLLATE utf8_general_ci COMMENT '玩家昵称',
  `Gender` int(11) DEFAULT 1 COMMENT '玩家性别',
  `Email` text CHARACTER SET utf8 COLLATE utf8_general_ci COMMENT '玩家邮箱',
  `CellPhone` text CHARACTER SET utf8 COLLATE utf8_general_ci COMMENT '手机号码',
  `Header` text CHARACTER SET utf8 COLLATE utf8_general_ci COMMENT '玩家头像',
  `RegDate` datetime DEFAULT NULL COMMENT '注册时间',
  `Status` int(11) DEFAULT 1 COMMENT '玩家状态',
  `RealName` text CHARACTER SET utf8 COLLATE utf8_general_ci COMMENT '玩家真实姓名',
  `IDCard` text CHARACTER SET utf8 COLLATE utf8_general_ci COMMENT '玩家身份证号',
  `RegStatus` int(11) DEFAULT 1 COMMENT '玩家的注册状态',
  `SNSID` text CHARACTER SET utf8 COLLATE utf8_general_ci COMMENT '玩家与微信的绑定编号',
  `OrgID` int(11) DEFAULT NULL,
  `ParentUser` int(11) DEFAULT NULL COMMENT '上级玩家',
  `KeyString` text CHARACTER SET utf8 COLLATE utf8_general_ci,
  `LV` int(11) DEFAULT 1,
  `Type` int(11) DEFAULT 1,
  `AgentId` int(11) DEFAULT 150000 COMMENT '代理Id',
  PRIMARY KEY (`UserId`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 850001 CHARACTER SET = utf8 COLLATE = utf8_general_ci COMMENT = '玩家信息表' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of user_info
-- ----------------------------
INSERT INTO `user_info` VALUES (850000, 'u_850000', '123456', 'u_850000', 1, NULL, NULL, NULL, '2018-07-20 17:06:30', 1, NULL, NULL, 1, NULL, NULL, NULL, NULL, 1, 1, 150000);

-- ----------------------------
-- Procedure structure for CSLoadForAIInfo
-- ----------------------------
DROP PROCEDURE IF EXISTS `CSLoadForAIInfo`;
delimiter ;;
CREATE PROCEDURE `CSLoadForAIInfo`(out `returnvalue` int)
BEGIN


	SELECT  1 as t LIMIT 0;


	set returnvalue = 1;
	
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for CSLoadGameList
-- ----------------------------
DROP PROCEDURE IF EXISTS `CSLoadGameList`;
delimiter ;;
CREATE PROCEDURE `CSLoadGameList`(out `returnvalue` int)
BEGIN

	SELECT * from gameinfo;
	set returnvalue = 1;
	
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for CSLoadSysConfigFromDB
-- ----------------------------
DROP PROCEDURE IF EXISTS `CSLoadSysConfigFromDB`;
delimiter ;;
CREATE PROCEDURE `CSLoadSysConfigFromDB`(in `sysStatus` int ,out `returnvalue` int)
BEGIN
	
	SELECT SysKey,SysValue from sysconfig where `Status` =sysStatus ;
	set returnvalue = 1;
	
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for CSRegOLogin
-- ----------------------------
DROP PROCEDURE IF EXISTS `CSRegOLogin`;
delimiter ;;
CREATE PROCEDURE `CSRegOLogin`(In `_Pwd` VARCHAR(100),in  `_ParentUser` int,in `_Ip` VARCHAR(50), in `_NickName` VARCHAR(50),in `_RegStatus` int 
, in `_Gender` int, out `OUT_UserID` int ,out `returnvalue` int)
BEGIN

INSERT into user_info (`UserID`,`NickName`,`Password`,`RegStatus`,`RegDate`) 
								VALUES(NULL,`_NickName`,_Pwd,_RegStatus,NOW());

-- 获取最新注册的玩家Id
SET `OUT_UserID` = LAST_INSERT_ID();

UPDATE `user_info` set `UserAccount` = (CONCAT('u_',OUT_UserID))  where `UserID` = `OUT_UserID`;



SET returnvalue = 1;


END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for CS_User_Info_InitUser_dp_Query
-- ----------------------------
DROP PROCEDURE IF EXISTS `CS_User_Info_InitUser_dp_Query`;
delimiter ;;
CREATE PROCEDURE `CS_User_Info_InitUser_dp_Query`( IN `UserID` INT, OUT `returnvalue` INT )
lable:BEGIN

SELECT
	user_info.UserId AS UserID,
	user_info.Header,
	user_info.NickName,
	user_info.PASSWORD,
	user_info.AgentId,
	if(user_info.IDCard  is NULL,0,1) AS HasIDChard,
	'' AS RewardContext,
	user_info.Gender,
	1 AS VipLV,
	user_info.LV,
	'' AS UPassword,
	1 AS ContinuityDays,
	NOW( ) AS LastSignTime,
	user_info.Type AS UserType

FROM
	`user_info` 
WHERE
	user_info.UserId = `UserID`;
	
IF (FOUND_ROWS() < 1) THEN 
-- 玩家不存在
		SET returnvalue = -1;
		leave lable;
END IF;
		
		
		
	SELECT
		2 MoneyType,
		1000 MoneyNum UNION ALL
	SELECT
		4,
		1000;
	
	SET returnvalue = 1; 
	 
	
	END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for GSLoadAgentRoomList
-- ----------------------------
DROP PROCEDURE IF EXISTS `GSLoadAgentRoomList`;
delimiter ;;
CREATE PROCEDURE `GSLoadAgentRoomList`(in `ServerID` int ,out `returnvalue` int)
BEGIN


SELECT * from gameroominfo;


	set returnvalue = 1;
	
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for System_InitializerData
-- ----------------------------
DROP PROCEDURE IF EXISTS `System_InitializerData`;
delimiter ;;
CREATE PROCEDURE `System_InitializerData`()
BEGIN

TRUNCATE TABLE user_info;

INSERT into user_info (`UserID`,`UserAccount`,`NickName`,`Password`,`RegStatus`,`RegDate`) 
								VALUES(850000,'u_850000','u_850000','123456',1,NOW());



end
;;
delimiter ;

SET FOREIGN_KEY_CHECKS = 1;
