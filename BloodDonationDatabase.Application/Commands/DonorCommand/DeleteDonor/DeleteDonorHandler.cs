using BloodDonationDatabase.Application.Model;
using BloodDonationDatabase.Core.Repository;
using MediatR;

namespace BloodDonationDatabase.Application.Commands.DonorCommand.DeleteDonor
{
    public class DeleteDonorHandler : IRequestHandler<DeleteDonorCommand, ResultViewModel>
    {
        public DeleteDonorHandler(IDonorRepository repository)
        {
            _repository = repository;
        }

        private readonly IDonorRepository _repository;

        public async Task<ResultViewModel> Handle(DeleteDonorCommand request, CancellationToken cancellationToken)
        {
            var donor = await _repository.GetById(request.Id);

            if (donor is null) return ResultViewModel.Error("Doador não existe");

            donor.SetAsDeleted();

            await _repository.Update(donor);

            return ResultViewModel.Success();
        }
    }
}
