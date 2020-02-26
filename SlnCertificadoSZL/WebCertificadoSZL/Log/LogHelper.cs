﻿using System;

namespace WebCertificadoSZL.Log
{
    public static class LogHelper
    {
        public static void Configure()
        {
            Log4NetWrapper.Configure();
        }
               
        
        public static ILogger GetLogger(Type type)
        {
            return new Log4NetWrapper(type);
        }
    }
}
