using BloodDonationDatabase.Application.Model;
using MediatR;

namespace BloodDonationDatabase.Application.Commands.DonorCommand.InsertDonor
{
    public class InsertDonorHandler : IRequestHandler<InsertDonorCommand, ResultModel>
    {
        public async Task<ResultModel> Handle(InsertDonorCommand request, CancellationToken cancellationToken)
        {

            return ResultModel.Success();
        }
    }
}
