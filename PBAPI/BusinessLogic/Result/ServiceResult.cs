using BusinessLogic.Enums;

namespace BusinessLogic.Result
{
    public record ServiceResult<TResultData>(TResultData? Data, ServiceResultStatus ServiceResultStatus) : ServiceResult(ServiceResultStatus)
    {
        public ServiceResult(ServiceResultStatus serviceResultStatus) : this(default, serviceResultStatus) {}

        public ServiceResult(TResultData? data) : this(data, ServiceResultStatus.Success) {}

        public override bool IsSuccess => Data is not null && base.IsSuccess;
    }

    public record ServiceResult(ServiceResultStatus ServiceResultStatus)
    {
        public virtual bool IsSuccess => ServiceResultStatus == ServiceResultStatus.Success;
    }
}
