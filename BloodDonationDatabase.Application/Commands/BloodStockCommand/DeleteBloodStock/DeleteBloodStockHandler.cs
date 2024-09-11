using BloodDonationDatabase.Application.Model;
using BloodDonationDatabase.Core.Repositories;
using MediatR;

namespace BloodDonationDatabase.Application.Commands.BloodStockCommand.DeleteBloodStock
{
    public class DeleteBloodStockHandler : IRequestHandler<DeleteBloodStockCommand, ResultViewModel>
    {
        public DeleteBloodStockHandler(IBloodStockRespository respository)
        {
            _respository = respository;
        }

        private readonly IBloodStockRespository _respository;
        public async Task<ResultViewModel> Handle(DeleteBloodStockCommand request, CancellationToken cancellationToken)
        {
            var bloodStock = await _respository.GetById(request.Id);

            if (bloodStock is null) return ResultViewModel.Error("Estoque não encontrado");

            bloodStock.SetAsDeleted();
            await _respository.Update(bloodStock);

            return ResultViewModel.Success();
        }
    }
}
