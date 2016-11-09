using HW4.Homework.Models;
using System;

namespace HW4.Interface
{
    public interface ITarget
    {
        void CreateUser(DbUserEntity user);
        void CreateUserInfo(DbUserInfoEntity userInfo);
        DbUserEntity ReadUser(int id);
        DbUserInfoEntity ReadUserInfo(int id);
        void UpdateUser(DbUserEntity user);
        void UpdateUserInfo(DbUserInfoEntity userInfo);
        void DeleteUser(DbUserEntity user);
        void DeleteUserInfo(DbUserInfoEntity userInfo);

    }
}
