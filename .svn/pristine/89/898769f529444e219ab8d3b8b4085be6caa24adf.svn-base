/*-----------------------------------------------------------------------------------------------------
 *   Company:   Chengdu Winfotian Infomation Technology Co.,Ltd
 *    Author:   yuanyang@winfotian.com
 *  DateTime:   2014/11/3 10:07:17
 *   Purpose:
 *           Version           DateTime                    Author               Description
 *            v1.0       2014/11/3 10:07:17       yuanyang@winfotian.com        枚举类集              
 *----------------------------------------------------------------------------------------------------*/
using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace Com.Winfotian.Model
{
    /// <summary>
    /// 规定页面返回状态值说明
    /// </summary>
    [Serializable]
    [DataContract]
    public enum EmReStatus
    {
        /// <summary>
        /// 成功
        /// </summary>
        [Description("成功")]
        [EnumMember]
        success = 1,
        /// <summary>
        /// 失败
        /// </summary>
        [Description("失败")]
        [EnumMember]
        fail = -1,
        /// <summary>
        /// 错误
        /// </summary>
        [Description("错误")]
        [EnumMember]
        error = -2,
        /// <summary>
        /// 无数据
        /// </summary>
        [Description("无数据")]
        [EnumMember]
        noData = 0,
        /// <summary>
        /// 无效请求
        /// </summary>
        [Description("无效请求")]
        [EnumMember]
        invalid = -3,
        /// <summary>
        /// 服务器未响应
        /// </summary>
        [Description("服务器未响应")]
        [EnumMember]
        serverNoReply = -4,
        /// <summary>
        /// 日志记录失败
        /// </summary>
        [Description("日志记录失败")]
        [EnumMember]
        logFail = -5,
        /// <summary>
        /// 数据异常
        /// </summary>
        [Description("数据异常")]
        [EnumMember]
        exception = -6
    }
}
