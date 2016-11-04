﻿/**********************************************************************************************************************
 * 描述：
 *      字符串类型扩展方法静态类。
 * 
 * 变更历史：
 *      作者：李亮  时间：2016年11月04日	 新建
 *********************************************************************************************************************/

using System;
using System.Text;
using System.Xml.Linq;
using Wlitsoft.Framework.Common.Abstractions.Serialize;
using Wlitsoft.Framework.Common.Exception;

namespace Wlitsoft.Framework.Common.Extensions
{
    /// <summary>
    /// 字符串类型扩展方法静态类。
    /// </summary>
    public static class StringExtensions
    {
        #region 将 json 字符串转换为指定类型的对象表示形式

        /// <summary>
        /// 将 json 字符串转换为指定类型的对象表示形式。
        /// </summary>
        /// <typeparam name="T">要转换成的对象类型。</typeparam>
        /// <param name="json">json 字符串。</param>
        /// <returns>转换完后的 JSON 对象。</returns>
        public static T ToJsonObject<T>(this string json)
        {
            #region 参数校验

            if (string.IsNullOrEmpty(json))
                throw new StringNullOrEmptyException(nameof(json));

            #endregion

            ISerializer serializer = GlobalConfig.SerializerFactory.GetJsonSerializer();
            return serializer.Deserialize<T>(json);
        }

        #endregion

        #region 将 xml 字符串转换为指定类型的对象表示形式

        /// <summary>
        /// 将给定 XML 字符串（<see paracref="xml"/>）转换为指定类型的对象表示形式。
        /// </summary>
        /// <typeparam name="T">要转换成的对象类型。</typeparam>
        /// <param name="xml">json 字符串。</param>
        /// <returns>转换完后的 Xml 对象。</returns>
        public static T ToXmlObject<T>(this string xml)
        {
            #region 参数校验

            if (string.IsNullOrEmpty(xml))
                throw new StringNullOrEmptyException(nameof(xml));

            #endregion

            ISerializer serializer = GlobalConfig.SerializerFactory.GetXmlSerializer();
            return serializer.Deserialize<T>(xml);
        }

        /// <summary>
        /// 将给定 XML 字符串（<see paracref="xml"/>）转换为对象表示形式。
        /// </summary>
        /// <param name="xml">要转换的 XML 字符串。</param>
        /// <param name="type">要转换成的对象类型。</param>
        /// <returns>转换完后的 Xml 对象。</returns>
        public static object ToXmlObject(this string xml, Type type)
        {
            #region 参数校验

            if (string.IsNullOrEmpty(xml))
                throw new StringNullOrEmptyException(nameof(xml));

            if (type == null)
                throw new ObjectNullException(nameof(type));

            #endregion

            ISerializer serializer = GlobalConfig.SerializerFactory.GetXmlSerializer();
            return serializer.Deserialize(type, xml);
        }

        #endregion

        #region 格式化 Xml 字符串

        /// <summary>
        /// 将给定 XML 字符串（<see paracref="xml"/>）去除格式并返回一个新的 XML 字符串。
        /// </summary>
        /// <param name="xml">要格式化的原始 XML 字符串。</param>
        /// <returns>格式化后的 XML 字符串。</returns>
        public static string FormatXmlString(this string xml)
        {
            // ReSharper disable once IntroduceOptionalParameters.Global
            return FormatXmlString(xml, SaveOptions.DisableFormatting);
        }

        /// <summary>
        /// 根据 <see paracref="saveOptions"/> 提供的选项将给定 XML 字符串（<see paracref="xml"/>）格式化后并返回一个新的 XML 字符串。
        /// </summary>
        /// <param name="xml">要格式化的原始 XML 字符串。</param>
        /// <param name="saveOptions">指定序列化选项。</param>
        /// <returns>格式化后的 XML 字符串。</returns>
        public static string FormatXmlString(this string xml, SaveOptions saveOptions)
        {
            #region 参数校验

            if (string.IsNullOrEmpty(xml))
                throw new StringNullOrEmptyException(nameof(xml));

            #endregion

            XDocument xDoc = XDocument.Parse(xml);
            return xDoc.ToString(saveOptions);
        }

        #endregion

        #region 将给定的要加密的字符串（<see cref="encypStr"/>）使用 GB2312 编码方式，获取大写的 MD5 签名字符串

        /// <summary>
        /// 将给定的要加密的字符串（<see paracref="encypStr"/>）使用 GB2312 编码方式，获取大写的 MD5 签名字符串。
        /// </summary>
        /// <param name="encypStr">要加密的字符串。</param>
        /// <returns>大写的 MD5 签名字符串。</returns>
        public static string GetMD5(this string encypStr)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
