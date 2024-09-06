namespace BloodDonationDatabase.Application.Model
{
    public class ResultModel
    {
        public ResultModel(bool isSuccess = true, string message = "")
        {
            IsSuccess = isSuccess;
            Message = message;
        }

        public bool IsSuccess { get; private set; }
        public string Message { get; private set; }

        public static ResultModel Success()
            => new();

        public static ResultModel Error(string message)
            => new(false, message);
    }

    public class ResultModel<T> : ResultModel
    {
        public ResultModel(T? data, bool isSuccess = true, string message = "")
            : base(isSuccess, message)
        {
            Data = data;
        }

        public T? Data { get; private set; }

        public static ResultModel<T> Success(T data)
            => new(data);

        public static ResultModel<T> Error(string message)
            => new(default, false, message);
    }
}