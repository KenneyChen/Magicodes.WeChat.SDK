﻿// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : CardInfoCustomConverter.cs
//          description :
//  
//          created by 李文强 at  2016/11/9 17:10
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace Magicodes.WeChat.SDK.Apis.Card
{
    /// <summary>
    ///     使用日期自定义对象创建转换器
    ///     根据日期类型自定义创建
    /// </summary>
    public class MemberCardCustomConverter : CustomCreationConverter<MemberCard>
    {
        /// <summary>
        ///     读取目标对象的JSON表示
        /// </summary>
        /// <param name="reader">JsonReader</param>
        /// <param name="objectType">对象类型</param>
        /// <param name="existingValue"></param>
        /// <param name="serializer"></param>
        /// <returns>对象</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var jObject = JObject.Load(reader);
            MemberCard target = new MemberCard();
            serializer.Populate(jObject.CreateReader(), target);
            return target;
        }

        /// <summary>
        ///     创建对象（会被填充）
        /// </summary>
        /// <param name="objectType">对象类型</param>
        /// <returns>对象</returns>
        public override MemberCard Create(Type objectType)
        {
            return new MemberCard();
        }
    }
}