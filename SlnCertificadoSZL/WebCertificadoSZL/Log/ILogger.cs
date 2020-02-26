﻿using System;

namespace WebCertificadoSZL.Log
{
    public interface ILogger
    {
        void Debug(string mensaje);
        void Error(string mensaje);
        void Error(string mensaje, Exception ex);
        void Info(string mensaje);
    }
}
