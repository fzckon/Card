using System;
using System.Collections.Generic;
using System.Text;
using NLog;

namespace Common.Utils
{
    public class Logger : IDisposable
    {
        protected static Logger loggerDefault;
        protected NLog.Logger nLogger;
        protected static NLog.Logger nLoggerDefault;
        protected static NLog.Logger nLoggerFactory;

        public Logger(string name) : this(LogManager.LogFactory.GetLogger(name))
        {

        }

        private Logger(NLog.Logger nLogger)
        {
            this.nLogger = nLogger;
        }

        public static NLog.Logger Default
        {
            get
            {
                if (nLoggerDefault == null)
                    nLoggerDefault = LogManager.LogFactory.GetCurrentClassLogger();
                return nLoggerDefault;
            }
        }

        static Logger()
        {

        }

        public static NLog.Logger Factory(string name)
        {
            if (nLoggerFactory == null)
                nLoggerFactory = LogManager.LogFactory.GetLogger(name);
            return nLoggerFactory;
        }

        #region IDisposable Support
        private bool disposedValue = false; // 要检测冗余调用

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 释放托管状态(托管对象)。
                    if (LogManager.LogFactory != null)
                    {
                        LogManager.LogFactory.Flush();
                        LogManager.LogFactory.Dispose();
                    }                    
                }

                // TODO: 释放未托管的资源(未托管的对象)并在以下内容中替代终结器。
                // TODO: 将大型字段设置为 null。

                disposedValue = true;
            }
        }

        // TODO: 仅当以上 Dispose(bool disposing) 拥有用于释放未托管资源的代码时才替代终结器。
        // ~Logger() {
        //   // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
        //   Dispose(false);
        // }

        // 添加此代码以正确实现可处置模式。
        void IDisposable.Dispose()
        {
            // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
            Dispose(true);
            // TODO: 如果在以上内容中替代了终结器，则取消注释以下行。
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}
