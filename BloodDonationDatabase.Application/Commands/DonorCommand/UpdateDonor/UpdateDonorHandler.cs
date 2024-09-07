using BloodDonationDatabase.Application.Model;
using BloodDonationDatabase.Core.Entities;
using BloodDonationDatabase.Core.Repository;
using MediatR;

namespace BloodDonationDatabase.Application.Commands.DonorCommand.UpdateDonor
{
    public class UpdateDonorHandler : IRequestHandler<UpdateDonorCommand, ResultViewModel>
    {
        public UpdateDonorHandler(IDonorRepository repository)
        {
            _repository = repository;
        }

        private readonly IDonorRepository _repository;

        public async Task<ResultViewModel> Handle(UpdateDonorCommand request, CancellationToken cancellationToken)
        {
            var donor = await _repository.GetById(request.IdDonor);

            if (donor is null) return ResultViewModel.Error("Doador não existe");

            donor.Update(request.FullName,request.Email, request.Gender,request.Weight,request.BloodType,request.RhFactor);
            await _repository.Update(donor);

            return ResultViewModel.Success();
        }
    }
}