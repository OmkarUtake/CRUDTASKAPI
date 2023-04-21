using System;

namespace Crud.UtilityHelper
{
    public class ServiceResult
    {
        public int Status { get; set; }
        public string Message { get; set; }

        public ServiceResult()
        {
            Status = 404;
            Message = "No Recorde";
        }
        public void SetSuccess()
        {
            Status = 200;
            Message = "Success";
        }
    }
}
