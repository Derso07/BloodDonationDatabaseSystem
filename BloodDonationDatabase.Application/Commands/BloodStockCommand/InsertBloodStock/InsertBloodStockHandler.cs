using BloodDonationDatabase.Application.Model;
using BloodDonationDatabase.Core.Repositories;
using MediatR;

namespace BloodDonationDatabase.Application.Commands.BloodStockCommand.InsertBloodStock
{
    public class InsertBloodStockHandler : IRequestHandler<InsertBloodStockCommand, ResultViewModel<int>>
    {
        public InsertBloodStockHandler(IBloodStockRespository respository)
        {
            _respository = respository;
        }

        private readonly IBloodStockRespository _respository;

        public async Task<ResultViewModel<int>> Handle(InsertBloodStockCommand request, CancellationToken cancellationToken)
        {
            var model = request.ToEntity();

            await _respository.Insert(model);

            return ResultViewModel<int>.Success(model.Id);
        }
    }
}
