/// ------------------------------------------------------------------------------
/// <copyright company="United-Imaging">
/// Copyright (c) 2014 United-Imaging. All rights reserved.
/// </copyright>
/// <author>Yang Bu</author>
/// <date>8/25/2014 9:35:34 AM</date>
/// <updateauthor>Yang Bu</updateauthor>
/// <updatedate>8/25/2014 9:35:34 AM</updatedate>
/// <description>
/// </description>
/// ------------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace MyUIDemo.Config
{
    public static class SerializerHelper
    {
        /*
        常用的Attribute使用说明:       
        [Serializable]：用于标志这个类是可进行序列化的。注意此属性只能用于类定义上，另外类也可以通过实现System.Runtime.Serialization.ISerializable进行自定义序列化控制。
        [XmlRoot]：用于定义xml根节点的节点名称。
        [XmlElement]：用于定义类属性在序列化中对应节点的名称。
        [XmlIgnore]：标志此属性不参与序列化。
        [XmlArray]：通常与[XmlArrayItem]配合使用，定义数组的父节点名称与子节点名称。
        [XmlAttribute]：用于定义类属性在序列化中对应节点的特性。
        
        使用注意
        1. 需序列化的字段必须是公共的(public) 
        2. Serializable的类必须有无参数的构造函数
        */

        #region Serializer

        /// <summary>
        /// Serializer To String
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string SerializerToString(object obj)
        {
            string xmlString = string.Empty;
            try
            {
                Type t = obj.GetType();
                StringBuilder buffer = new StringBuilder();
                XmlSerializer xmlSerializer = new XmlSerializer(t);
                using (TextWriter writer = new StringWriter(buffer))
                {
                    xmlSerializer.Serialize(writer, obj);
                    xmlString = writer.ToString();
                }
            }
            catch { }
            return xmlString;
        }

        /// <summary>
        /// Deserializer From String
        /// </summary>
        /// <param name="xmlString"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object DeserializerFromString(string xmlString, Type type)
        {
            try
            {
                StringBuilder buffer = new StringBuilder();
                buffer.Append(xmlString);
                XmlSerializer serializer = new XmlSerializer(type);
                using (TextReader reader = new StringReader(buffer.ToString()))
                {
                    Object obj = serializer.Deserialize(reader);
                    return obj;
                }
            }
            catch { }
            return null;
        }

        /// <summary>
        /// Deserializer From String
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xmlString"></param>
        /// <returns></returns>
        public static T DeserializerFromString<T>(string xmlString)
        {
            Object obj = DeserializerFromString(xmlString, typeof(T));
            if (obj != null && obj is T)
            {
                return (T)obj;
            }
            return default(T);
        }



        /// <summary>
        /// Serializer To File
        /// </summary>
        /// <param name="obj">Source object</param>
        /// <param name="output">XML file path</param>
        /// <param name="types">Serializable object types in source object</param>
        /// <returns></returns>
        public static bool SerializerToFile(object obj, string filePath)
        {
            try
            {
                Type t = obj.GetType();
                XmlSerializer xmlSerializer = new XmlSerializer(t);
                using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    xmlSerializer.Serialize(fs, obj);
                    return true;
                }
            }
            catch { }
            return false;
        }

        /// <summary>
        /// Deserializer From File
        /// </summary>
        /// <param name="output">XML file path</param>
        /// <param name="type">Source object type</param>
        /// <param name="types">Serializable object types in source object</param>
        /// <returns></returns>
        public static object DeserializerFromFile(string filePath, Type type)
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(type);
                using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    return xmlSerializer.Deserialize(fs);
                }
            }
            catch { }
            return null;
        }


        /// <summary>
        /// Deserializer From File
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filePath">XML file path</param>
        /// <returns></returns>
        public static T DeserializerFromFile<T>(string filePath)
        {
            Object obj = DeserializerFromFile(filePath, typeof(T));
            if (obj != null && obj is T)
            {
                return (T)obj;
            }
            return default(T);
        }

        #endregion


    }
}
