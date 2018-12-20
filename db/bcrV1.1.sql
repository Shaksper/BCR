/*
Navicat MySQL Data Transfer

Source Server         : local
Source Server Version : 50722
Source Host           : localhost:3306
Source Database       : bcr

Target Server Type    : MYSQL
Target Server Version : 50722
File Encoding         : 65001

Date: 2018-12-20 23:22:26
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
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COMMENT='区域表';

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
) ENGINE=InnoDB AUTO_INCREMENT=61 DEFAULT CHARSET=utf8 COMMENT='会议室预定情况表';

-- ----------------------------
-- Table structure for sys_departinfo
-- ----------------------------
DROP TABLE IF EXISTS `sys_departinfo`;
CREATE TABLE `sys_departinfo` (
  `id` int(11) NOT NULL,
  `depname` varchar(255) DEFAULT NULL COMMENT '部门名称',
  `area` int(11) DEFAULT NULL COMMENT '所属区域',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='部门信息表';

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
-- Table structure for sys_projectinfo
-- ----------------------------
DROP TABLE IF EXISTS `sys_projectinfo`;
CREATE TABLE `sys_projectinfo` (
  `id` varchar(255) NOT NULL,
  `proj_name` varchar(255) DEFAULT NULL COMMENT '项目名称',
  `priority` int(11) DEFAULT NULL COMMENT '优先级',
  `manager` varchar(255) DEFAULT NULL COMMENT '项目经理',
  `starttime` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP COMMENT '项目开始时间',
  `endtime` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP COMMENT '项目结束时间',
  `status` int(11) DEFAULT NULL COMMENT '项目状态',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='项目信息表';

-- ----------------------------
-- Table structure for sys_proj_userinfo
-- ----------------------------
DROP TABLE IF EXISTS `sys_proj_userinfo`;
CREATE TABLE `sys_proj_userinfo` (
  `id` varchar(255) NOT NULL,
  `projid` varchar(255) DEFAULT NULL COMMENT '项目id',
  `userid` varchar(255) DEFAULT NULL COMMENT '用户id',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='项目关联人员表';

-- ----------------------------
-- Table structure for sys_roleinfo
-- ----------------------------
DROP TABLE IF EXISTS `sys_roleinfo`;
CREATE TABLE `sys_roleinfo` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `role_name` varchar(255) DEFAULT NULL COMMENT '角色名称',
  `role_level` int(255) DEFAULT NULL COMMENT '角色级别',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8 COMMENT='角色信息表';

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
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8 COMMENT='会议室信息表';

-- ----------------------------
-- Table structure for sys_status
-- ----------------------------
DROP TABLE IF EXISTS `sys_status`;
CREATE TABLE `sys_status` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) DEFAULT NULL,
  `type` varchar(255) DEFAULT NULL COMMENT '类型',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8 COMMENT='状态信息';

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
  `proj_id` varchar(255) DEFAULT NULL COMMENT '项目编号，为空则表示非项目中的待办',
  `status` int(11) DEFAULT NULL COMMENT '待办状态',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='待办事项';

-- ----------------------------
-- Table structure for sys_todo_status
-- ----------------------------
DROP TABLE IF EXISTS `sys_todo_status`;
CREATE TABLE `sys_todo_status` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) DEFAULT NULL COMMENT '待办状态',
  `color` varchar(255) DEFAULT NULL COMMENT '颜色',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COMMENT='待办状态表';

-- ----------------------------
-- Table structure for sys_user
-- ----------------------------
DROP TABLE IF EXISTS `sys_user`;
CREATE TABLE `sys_user` (
  `id` varchar(255) NOT NULL,
  `nickname` varchar(255) DEFAULT NULL COMMENT '昵称',
  `username` varchar(255) DEFAULT NULL,
  `password` varchar(255) DEFAULT NULL,
  `email` varchar(255) DEFAULT NULL,
  `area` int(11) DEFAULT NULL,
  `depid` int(11) DEFAULT NULL COMMENT '部门id',
  `updatetime` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='用户表';

-- ----------------------------
-- Table structure for sys_user_roleinfo
-- ----------------------------
DROP TABLE IF EXISTS `sys_user_roleinfo`;
CREATE TABLE `sys_user_roleinfo` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `userid` varchar(255) DEFAULT NULL COMMENT '用户id',
  `roleid` int(11) DEFAULT NULL COMMENT '角色id',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='用户角色表';
