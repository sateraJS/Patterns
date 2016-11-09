using HW4.Interface;
using HW4.Homework.FirstOrmLibrary;
using HW4.Homework.Models;

namespace HW4.Adapters
{
    public class FirstOrmAdapter : ITarget
    {
        private IFirstOrm<DbUserEntity> _iFirstOrmDbUserEntity;
        private IFirstOrm<DbUserInfoEntity> _iFirstOrmDbUserInfoEntity;

        FirstOrmAdapter(IFirstOrm<DbUserEntity> iFirstOrmDbUserEntity, IFirstOrm<DbUserInfoEntity> iFirstOrmDbUserInfoEntity)
        {
            _iFirstOrmDbUserEntity = iFirstOrmDbUserEntity;
            _iFirstOrmDbUserInfoEntity = iFirstOrmDbUserInfoEntity;
        }
        public void CreateUser(DbUserEntity dbUserEntity)
        {
            _iFirstOrmDbUserEntity.Create(dbUserEntity);
        }
        public void CreateUserInfo(DbUserInfoEntity dbUserInfoEntity)
        {
            _iFirstOrmDbUserInfoEntity.Create(dbUserInfoEntity);
        }
        public DbUserEntity ReadUser(int id)
        {
            return _iFirstOrmDbUserEntity.Read(id) as DbUserEntity;
        }
        public DbUserInfoEntity ReadUser(int id)
        {
            return _iFirstOrmDbUserInfoEntity.Read(id) as DbUserInfoEntity;
        }
        public void UpdateUser(DbUserEntity dbUserEntity)
        {
            _iFirstOrmDbUserEntity.Update(dbUserEntity);
        }
        public void UpdateUserInfo(DbUserInfoEntity dbUserInfoEntity)
        {
            _iFirstOrmDbUserInfoEntity.Update(dbUserInfoEntity);
        }
        public void DeleteUser(DbUserEntity dbUserEntity)
        {
            _iFirstOrmDbUserEntity.Delete(dbUserEntity);
        }
        public void DeleteUserInfo(DbUserInfoEntity dbUserInfoEntity)
        {
            _iFirstOrmDbUserInfoEntity.Delete(dbUserInfoEntity);
        }

    }
}
