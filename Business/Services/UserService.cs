using Business.Models.Request.Functional;
using Business.Models.Response;
using Business.Services.Base;
using Business.Services.Interface;
using Business.Utilities.Mapping.Interface;
using Business.Utilities.Security.Auth.Jwt.Interface;
using Core.Results;
using Infrastructure.Data.Postgres;
using Infrastructure.Data.Postgres.Entities;
using Infrastructure.Data.Postgres.EntityFramework;

namespace Business.Services
{
    
    public class UserService : BaseService<User, int, UserInfoDto>, IUserService

    {
        private readonly PostgresContext dbContext;

        IHashingHelper _hashingHelper;
        public UserService(IUnitOfWork unitOfWork, IMapperHelper mapperHelper, IHashingHelper hashingHelper, PostgresContext dbContext) : base(unitOfWork, unitOfWork.User, mapperHelper)
        {

            _hashingHelper = hashingHelper;
            this.dbContext = dbContext;
        }
       
        public async Task<Result> ChangePasswordAsync(ChangePasswordDto passwordDto)
        {
            User? user = await _unitOfWork.User.FirstOrDefaultAsync(u => u.Email == passwordDto.Email);

            if (user != null && passwordDto.Password.Length > 7)
            {
                _hashingHelper.CreatePasswordHash(passwordDto.Password, out var passwordHash, out var passwordSalt);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                _unitOfWork.User.Update(user);

                int a = await _unitOfWork.CommitAsync();
                if (a >= 0)
                {
                    return new Result("Þifre baþarýlý bir þekilde güncellendi.", ResultStatus.Ok);
                }
            }

            return new Result("Þifre güncelleme baþarýsýz.", ResultStatus.Error);
        }

    }
}
