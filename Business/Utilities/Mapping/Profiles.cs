using Business.Models.Request;
using Business.Models.Request.Create;
using Business.Models.Request.Functional;
using Business.Models.Request.Update;
using Business.Models.Response;
using Infrastructure.Data.Postgres.Entities;

namespace Business.Utilities.Mapping;

public class Profiles : AutoMapper.Profile
{
    public Profiles()
    {
    CreateMap<RegisterDto, User>();
    CreateMap<UserUpdateDto, User>();
    CreateMap<User, RegisterResponseDto>();


    CreateMap<CreateUserDto, User>();
    CreateMap<UserUpdateDto, User>();
    CreateMap<User, UserInfoDto>();

    CreateMap<CreateEmployeeDto, Employee>();
    CreateMap<UpdateEmployeeDto, Employee>();
    CreateMap<Employee, EmployeeInfoDto>();

        CreateMap<CreateBankAccountDto, BankAccount>();
        CreateMap<UpdateBankAccountDto, BankAccount>();
        CreateMap<BankAccount, BankAccountInfoDto>();

        CreateMap<CreateTransactionsDto, Transactions>();
        CreateMap<UpdateTransactionsDto, Transactions>();
        CreateMap<Transactions, TransactionsInfoDto>();


        CreateMap<CreateCommentDto, Comment>();
        CreateMap<UpdateCommentDto, Comment>();
        CreateMap<Comment, CommentInfoDto>();

        CreateMap<ChangePasswordDto, User>();
        CreateMap<User, EmailInfoDTO>();







    }
}
