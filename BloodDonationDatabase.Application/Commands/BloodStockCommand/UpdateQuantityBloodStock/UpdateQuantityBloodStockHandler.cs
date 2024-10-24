using BloodDonationDatabase.Application.Model;
using BloodDonationDatabase.Core.Repositories;
using MediatR;

namespace BloodDonationDatabase.Application.Commands.BloodStockCommand.UpdateQuantityBloodStock
{
    public class UpdateQuantityBloodStockHandler : IRequestHandler<UpdateQuantityBloodStockCommand, ResultViewModel>
    {
        public UpdateQuantityBloodStockHandler(IBloodStockRespository respository)
        {
            _respository = respository;
        }

        private readonly IBloodStockRespository _respository;

        public async Task<ResultViewModel> Handle(UpdateQuantityBloodStockCommand request, CancellationToken cancellationToken)
        {
            var bloodStock = await _respository.GetById(request.Id);
            
            if (bloodStock is null) 
            {
                return ResultViewModel.Error("Não há estoque com esse Id!");
            }
            var result = await _respository.WithdrawBlood(request.Id, request.RemoveQuantity);

            if (result)
            {
                return ResultViewModel.Success();
            }
            else
            {
                return ResultViewModel.Error("Quantidade igual a 0 ou maior que estoque!");
            };
            
            
        }
    }
}
