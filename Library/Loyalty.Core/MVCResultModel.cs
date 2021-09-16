using Loyalty.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loyalty.Core
{
    public class MVCResultModel<T> : IDisposable
    {

        public MVCResultModel()
        {
            this.Status = ResultStatusEnum.UnSuccess;
        }

        public void Dispose()
        {
        }

        public void SetData(T data)
        {
            this.Data = data;
            this.Status = ResultStatusEnum.Success;
        }

        public void SetCount(int count)
        {
            this.DataCount = count;
        }

        public void SetException(Exception err)
        {
            this.Status = ResultStatusEnum.Error;
            this.Message = err.Message;
        }

        public void SetMessage(string message)
        {
            this.Message = message;
        }

        public T Data { get; set; }

        public int DataCount { get; set; }
        public bool IsLocked { get; set; }
        public string Message { get; set; }
        public ResultStatusEnum Status { get; set; }

    }
}
