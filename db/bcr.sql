/*
Navicat MySQL Data Transfer

Source Server         : local
Source Server Version : 50722
Source Host           : localhost:3306
Source Database       : bcr

Target Server Type    : MYSQL
Target Server Version : 50722
File Encoding         : 65001

Date: 2018-12-11 23:43:25
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for sys_area
-- ----------------------------
DROP TABLE IF EXISTS `sys_area`;
CREATE TABLE `sys_area` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) DEFAULT NULL,
  `abbreviation` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8 COMMENT='区域表';

-- ----------------------------
-- Records of sys_area
-- ----------------------------
INSERT INTO `sys_area` VALUES ('1', '河北志晟', 'zccninfo');
INSERT INTO `sys_area` VALUES ('2', '北京君晟', 'jchz');
INSERT INTO `sys_area` VALUES ('3', '山东思晟', 'sdsc');

-- ----------------------------
-- Table structure for sys_bookinfo
-- ----------------------------
DROP TABLE IF EXISTS `sys_bookinfo`;
CREATE TABLE `sys_bookinfo` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `roomid` varchar(255) DEFAULT NULL COMMENT '会议室id',
  `starttime` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  `endtime` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  `status` int(11) DEFAULT NULL COMMENT '预定状态',
  `uid` varchar(255) DEFAULT NULL COMMENT '预订人id',
  `meetname` varchar(255) DEFAULT NULL COMMENT '会议名称',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=49 DEFAULT CHARSET=utf8 COMMENT='会议室预定情况表';

-- ----------------------------
-- Records of sys_bookinfo
-- ----------------------------
INSERT INTO `sys_bookinfo` VALUES ('3', '1', '2018-12-07 07:15:00', '2018-12-07 08:00:00', '3', '84d47545-f6fa-11e8-a43b-c85b7627326a', '8765');
INSERT INTO `sys_bookinfo` VALUES ('5', '1', '2018-12-07 08:15:00', '2018-12-07 09:00:00', '3', '84d47545-f6fa-11e8-a43b-c85b7627326a', '8765');
INSERT INTO `sys_bookinfo` VALUES ('6', '2', '2018-12-07 11:00:00', '2018-12-07 12:15:00', '3', '84d47545-f6fa-11e8-a43b-c85b7627326a', '7654');
INSERT INTO `sys_bookinfo` VALUES ('7', '2', '2018-12-07 12:15:00', '2018-12-07 13:00:00', '3', '84d47545-f6fa-11e8-a43b-c85b7627326a', '7654');
INSERT INTO `sys_bookinfo` VALUES ('9', '2', '2018-12-07 13:00:00', '2018-12-07 13:15:00', '1', '84d47545-f6fa-11e8-a43b-c85b7627326a', '7654');
INSERT INTO `sys_bookinfo` VALUES ('23', '3', '2018-12-09 07:00:00', '2018-12-09 08:00:00', '3', '84d47545-f6fa-11e8-a43b-c85b7627326a', '7890890');
INSERT INTO `sys_bookinfo` VALUES ('24', '2', '2018-12-09 07:00:00', '2018-12-09 08:00:00', '3', '84d47545-f6fa-11e8-a43b-c85b7627326a', '7890890');
INSERT INTO `sys_bookinfo` VALUES ('25', '2', '2018-12-09 08:00:00', '2018-12-09 22:00:00', '1', '84d47545-f6fa-11e8-a43b-c85b7627326a', '7890890');
INSERT INTO `sys_bookinfo` VALUES ('26', '3', '2018-12-09 17:00:00', '2018-12-09 22:00:00', '3', '84d47545-f6fa-11e8-a43b-c85b7627326a', '7890890');
INSERT INTO `sys_bookinfo` VALUES ('28', '1', '2018-12-12 10:15:00', '2018-12-12 11:00:00', '3', '84d47545-f6fa-11e8-a43b-c85b7627326a', '7654');
INSERT INTO `sys_bookinfo` VALUES ('29', '1', '2018-12-12 11:15:00', '2018-12-12 12:00:00', '3', '84d47545-f6fa-11e8-a43b-c85b7627326a', '周会');
INSERT INTO `sys_bookinfo` VALUES ('31', '1', '2018-12-12 12:30:00', '2018-12-12 13:30:00', '3', '84d47545-f6fa-11e8-a43b-c85b7627326a', '周会');
INSERT INTO `sys_bookinfo` VALUES ('32', '1', '2018-12-10 20:00:00', '2018-12-10 21:00:00', '3', '84d47545-f6fa-11e8-a43b-c85b7627326a', '23423');
INSERT INTO `sys_bookinfo` VALUES ('33', '1', '2018-12-10 18:00:00', '2018-12-10 19:30:00', '3', '84d47545-f6fa-11e8-a43b-c85b7627326a', '2342342');
INSERT INTO `sys_bookinfo` VALUES ('37', '5', '2018-12-11 16:00:00', '2018-12-11 17:00:00', '3', '748658cc-3e96-4ac3-8352-f2ef6089c061', '内部会议');
INSERT INTO `sys_bookinfo` VALUES ('38', '1', '2018-12-11 16:00:00', '2018-12-11 18:00:00', '3', '84d47545-f6fa-11e8-a43b-c85b7627326a', '会议');
INSERT INTO `sys_bookinfo` VALUES ('39', '1', '2018-12-11 18:00:00', '2018-12-11 20:00:00', '2', '84d47545-f6fa-11e8-a43b-c85b7627326a', '会议');
INSERT INTO `sys_bookinfo` VALUES ('40', '1', '2018-12-11 21:00:00', '2018-12-11 23:00:00', '2', '84d47545-f6fa-11e8-a43b-c85b7627326a', '会议');
INSERT INTO `sys_bookinfo` VALUES ('41', '1', '2018-12-11 20:00:00', '2018-12-11 21:00:00', '1', '84d47545-f6fa-11e8-a43b-c85b7627326a', '会议');
INSERT INTO `sys_bookinfo` VALUES ('42', '4', '2018-12-11 19:00:00', '2018-12-11 21:00:00', '3', 'f6006da8-0040-4de6-9650-11afc914be21', '测试');
INSERT INTO `sys_bookinfo` VALUES ('43', '4', '2018-12-11 16:30:00', '2018-12-11 17:00:00', '2', 'f6006da8-0040-4de6-9650-11afc914be21', '34');
INSERT INTO `sys_bookinfo` VALUES ('44', '4', '2018-12-11 17:00:00', '2018-12-11 17:15:00', '3', 'f6006da8-0040-4de6-9650-11afc914be21', '34');
INSERT INTO `sys_bookinfo` VALUES ('45', '4', '2018-12-11 17:30:00', '2018-12-11 19:00:00', '1', 'f6006da8-0040-4de6-9650-11afc914be21', '34');
INSERT INTO `sys_bookinfo` VALUES ('46', '5', '2018-12-11 21:00:00', '2018-12-11 23:00:00', '3', 'f6006da8-0040-4de6-9650-11afc914be21', '345634');
INSERT INTO `sys_bookinfo` VALUES ('47', '4', '2018-12-11 17:15:00', '2018-12-11 17:30:00', '3', '0b77acd4-1e36-4cd0-8d4e-c70de13df738', '765');
INSERT INTO `sys_bookinfo` VALUES ('48', '4', '2018-12-11 21:00:00', '2018-12-11 22:00:00', '2', '0b77acd4-1e36-4cd0-8d4e-c70de13df738', '7654');

-- ----------------------------
-- Table structure for sys_priority
-- ----------------------------
DROP TABLE IF EXISTS `sys_priority`;
CREATE TABLE `sys_priority` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) DEFAULT NULL,
  `color` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COMMENT='优先级';

-- ----------------------------
-- Records of sys_priority
-- ----------------------------
INSERT INTO `sys_priority` VALUES ('1', '一般', '#0000f8');
INSERT INTO `sys_priority` VALUES ('2', '紧急', '#faf805');
INSERT INTO `sys_priority` VALUES ('3', '特别紧急', '#fa000a');

-- ----------------------------
-- Table structure for sys_roominfo
-- ----------------------------
DROP TABLE IF EXISTS `sys_roominfo`;
CREATE TABLE `sys_roominfo` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) DEFAULT NULL,
  `area` int(11) DEFAULT NULL,
  `status` int(11) DEFAULT NULL COMMENT '会议室状态1-正常使用0-暂停使用',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8 COMMENT='会议室信息表';

-- ----------------------------
-- Records of sys_roominfo
-- ----------------------------
INSERT INTO `sys_roominfo` VALUES ('1', '大会议室', '3', '1');
INSERT INTO `sys_roominfo` VALUES ('2', '南1', '3', '1');
INSERT INTO `sys_roominfo` VALUES ('3', '南2', '3', '1');
INSERT INTO `sys_roominfo` VALUES ('4', '大会议室', '2', '1');
INSERT INTO `sys_roominfo` VALUES ('5', '环保组', '2', '1');
INSERT INTO `sys_roominfo` VALUES ('6', '3楼大会议室', '1', '1');
INSERT INTO `sys_roominfo` VALUES ('7', '2楼会议室', '1', '1');

-- ----------------------------
-- Table structure for sys_status
-- ----------------------------
DROP TABLE IF EXISTS `sys_status`;
CREATE TABLE `sys_status` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8 COMMENT='状态信息';

-- ----------------------------
-- Records of sys_status
-- ----------------------------
INSERT INTO `sys_status` VALUES ('1', '已停用');
INSERT INTO `sys_status` VALUES ('2', '已保留');
INSERT INTO `sys_status` VALUES ('3', '已预约');
INSERT INTO `sys_status` VALUES ('4', '空闲中');

-- ----------------------------
-- Table structure for sys_todolist
-- ----------------------------
DROP TABLE IF EXISTS `sys_todolist`;
CREATE TABLE `sys_todolist` (
  `id` varchar(255) NOT NULL,
  `title` varchar(255) DEFAULT NULL COMMENT '事项标题',
  `content` varchar(255) DEFAULT NULL COMMENT '事项内容',
  `priority` int(11) DEFAULT NULL COMMENT '优先级',
  `endtime` varchar(255) DEFAULT NULL COMMENT '需要完成时间',
  `progress` double DEFAULT NULL COMMENT '进展',
  `uid` varchar(255) DEFAULT NULL COMMENT '用户id',
  `createtime` datetime DEFAULT NULL COMMENT '创建时间',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='待办事项';

-- ----------------------------
-- Records of sys_todolist
-- ----------------------------
INSERT INTO `sys_todolist` VALUES ('02b36549-6269-4e35-8282-d34f2f6db7c4', 'ewtwert', 'wetwerte', '2', '2018/12/11 23:30:42', '100', '84d47545-f6fa-11e8-a43b-c85b7627326a', '2018-12-11 23:29:48');
INSERT INTO `sys_todolist` VALUES ('08ae129a-c8e7-4186-ac76-7c02da0713a9', '23452', '24634634', '1', '2018/12/11 23:35:38', '100', 'f6006da8-0040-4de6-9650-11afc914be21', '2018-12-11 22:52:53');
INSERT INTO `sys_todolist` VALUES ('36bdc5dc-df9a-47e1-917a-1b079141b1bb', '345', '23452345', '1', null, '0', 'a3ea5af8-f943-11e8-acc1-00ff539c4d3a', '2018-12-11 23:36:43');
INSERT INTO `sys_todolist` VALUES ('37345a4b-22dd-4b81-ac95-594d39959ed8', '周会', '周会', '1', '', '25', 'a3ea5af8-f943-11e8-acc1-00ff539c4d3a', '2018-12-11 23:35:23');
INSERT INTO `sys_todolist` VALUES ('5245b297-69c3-4610-b38c-80f82e811ffb', '23452345', '23452345', '1', null, '0', 'a3ea5af8-f943-11e8-acc1-00ff539c4d3a', '2018-12-11 23:36:48');
INSERT INTO `sys_todolist` VALUES ('7283cbdb-d2d4-44d5-8efb-bedbe43ff51a', '3tw4', 'wertwert', '3', '2018/12/11 23:04:08', '100', 'f6006da8-0040-4de6-9650-11afc914be21', '2018-12-11 22:52:58');
INSERT INTO `sys_todolist` VALUES ('77e070a9-729b-468d-94b9-0a4444f00fd1', '2452345', '234523543245', '3', null, '0', 'a3ea5af8-f943-11e8-acc1-00ff539c4d3a', '2018-12-11 23:36:52');
INSERT INTO `sys_todolist` VALUES ('84640793-d1b4-4561-a43b-c7913f039426', '㔿', '而他也', '1', null, '0', 'a3ea5af8-f943-11e8-acc1-00ff539c4d3a', '2018-12-11 23:36:29');
INSERT INTO `sys_todolist` VALUES ('8c65b92a-ca5c-44eb-ad60-f54ef0042c99', '人头', '阿斯蒂芬', '1', null, '0', 'a3ea5af8-f943-11e8-acc1-00ff539c4d3a', '2018-12-11 23:36:35');
INSERT INTO `sys_todolist` VALUES ('948643a4-bedb-4545-bf15-3238291157de', '3463', '3456345634', '1', '2018/12/11 23:35:43', '100', '84d47545-f6fa-11e8-a43b-c85b7627326a', '2018-12-11 23:29:43');
INSERT INTO `sys_todolist` VALUES ('94b172fb-c798-49d1-8efe-0f28cfbb694e', 'yyy', 'yyyy', '1', '2018/12/11 23:04:02', '100', 'f6006da8-0040-4de6-9650-11afc914be21', '2018-12-11 22:55:28');
INSERT INTO `sys_todolist` VALUES ('a1ff98db-498e-4113-8630-4ccf22f9f2ec', '阿斯蒂芬', '阿斯蒂芬', '1', null, '0', 'a3ea5af8-f943-11e8-acc1-00ff539c4d3a', '2018-12-11 23:36:38');
INSERT INTO `sys_todolist` VALUES ('a279812e-eeea-4922-b72a-dd2f9c9b49c4', '2456', '3456345', '2', '', '66', 'f6006da8-0040-4de6-9650-11afc914be21', '2018-12-11 22:38:57');
INSERT INTO `sys_todolist` VALUES ('a9b04032-4617-4fa8-9faa-ed40a9d237b4', '2345', '23453245', '1', '2018/12/11 23:35:32', '100', 'a3ea5af8-f943-11e8-acc1-00ff539c4d3a', '2018-12-11 23:35:04');
INSERT INTO `sys_todolist` VALUES ('d7d5a063-7976-4d77-8b6c-2bcd87b6ee1e', '2345234', '23452345', '1', null, '0', 'a3ea5af8-f943-11e8-acc1-00ff539c4d3a', '2018-12-11 23:36:46');

-- ----------------------------
-- Table structure for sys_user
-- ----------------------------
DROP TABLE IF EXISTS `sys_user`;
CREATE TABLE `sys_user` (
  `id` varchar(255) NOT NULL,
  `username` varchar(255) DEFAULT NULL,
  `password` varchar(255) DEFAULT NULL,
  `email` varchar(255) DEFAULT NULL,
  `area` int(11) DEFAULT NULL,
  `updatetime` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='用户表';

-- ----------------------------
-- Records of sys_user
-- ----------------------------
INSERT INTO `sys_user` VALUES ('0b77acd4-1e36-4cd0-8d4e-c70de13df738', 'test1', '098f6bcd4621d373cade4e832627b4f6', '', '2', '2018-12-11 16:56:30');
INSERT INTO `sys_user` VALUES ('84d47545-f6fa-11e8-a43b-c85b7627326a', 'liuxu', 'e10adc3949ba59abbe56e057f20f883e', 'liuxu@zccninfo.com', '3', '2018-12-11 15:42:52');
INSERT INTO `sys_user` VALUES ('a3ea5af8-f943-11e8-acc1-00ff539c4d3a', 'admin', 'd3dec78abf71c9656a6df4705ef5bf15', '', '0', '2018-12-11 15:43:51');
INSERT INTO `sys_user` VALUES ('f6006da8-0040-4de6-9650-11afc914be21', 'test', '098f6bcd4621d373cade4e832627b4f6', '', '2', '2018-12-11 17:43:27');
