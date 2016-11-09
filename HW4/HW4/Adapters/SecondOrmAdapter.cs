using HW4.Homework.Models;
using HW4.Homework.SecondOrmLibrary;
using HW4.Interface;
using System;
using System.Linq;

namespace HW4.Adapters
{
    public class SecondOrmAdapter : ITarget
    {
        private ISecondOrm _iSecondOrm;

        SecondOrmAdapter(ISecondOrm iSecondOrm)
        {
            _iSecondOrm = iSecondOrm;
        }
        public void CreateUser(DbUserEntity user)
        {
            _iSecondOrm.Context.Users.Add(user);
        }
        public void CreateUserInfo(DbUserInfoEntity userInfo)
        {
            _iSecondOrm.Context.UserInfos.Add(userInfo);
        }
        public DbUserEntity ReadUser(int id)
        {
            return _iSecondOrm.Context.Users.ElementAt(id);
        }
        public DbUserInfoEntity ReadUserInfo(int id)
        {
            return _iSecondOrm.Context.UserInfos.ElementAt(id);
        }
        public void UpdateUser(DbUserEntity user)
        {
            var element = ReadUser(user.Id);
            _iSecondOrm.Context.Users.Remove(element);
            _iSecondOrm.Context.Users.Add(user);
        }
        public void UpdateUserInfo(DbUserInfoEntity userInfo)
        {
            var element = ReadUserInfo(userInfo.Id);
            _iSecondOrm.Context.UserInfos.Remove(element);
            _iSecondOrm.Context.UserInfos.Add(userInfo);
        }
        public void DeleteUser(DbUserEntity user)
        {
            _iSecondOrm.Context.Users.Remove(user);
        }
        public void DeleteUserInfo(DbUserInfoEntity userInfo)
        {
            _iSecondOrm.Context.UserInfos.Remove(userInfo);
        }

    }
}
